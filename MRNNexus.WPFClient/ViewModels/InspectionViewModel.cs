using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

using MRNNexusDTOs;
using MRNNexus.WPFClient.Models;

namespace MRNNexus.WPFClient.ViewModels
{
    class InspectionViewModel : BaseViewModel
    {
        #region Fields
        private ClaimFormView _claimFormView;
        private bool _billingSameAsProperty = true;
        private bool _billingAddressIsEnabled = false;
        private bool _leadIsAttached = false;
        #endregion

        #region Properties
        public ClaimFormView ClaimFormView
        {
            get { return _claimFormView; }
            set
            {
                _claimFormView = value;
                RaisePropertyChanged("ClaimFormViewO");
            }
        }
        public bool BillingSameAsProperty
        {
            get { return _billingSameAsProperty; }
            set
            {
                _billingSameAsProperty = value;
                if (_billingSameAsProperty) BillingAddressIsEnabled = false;
                else BillingAddressIsEnabled = true;
                RaisePropertyChanged("BillingSameAsProperty");
            }
        }
        public bool BillingAddressIsEnabled
        {
            get { return _billingAddressIsEnabled; }
            set
            {
                _billingAddressIsEnabled = value;
                RaisePropertyChanged("BillingAddressIsEnabled");
            }
        }
        public bool LeadIsAttached
        {
            get { return _leadIsAttached; }
            set
            {
                _leadIsAttached = value;
                RaisePropertyChanged("LeadIsAttached");
                if (_leadIsAttached)
                {
                    (ClaimFormView.DataContext as ClaimFormViewModel).AttachLeadBtnIsEnabled = false;
                    (ClaimFormView.DataContext as ClaimFormViewModel).AddNewLeadBtnIsEnabled = false;
                    (ClaimFormView.DataContext as ClaimFormViewModel).ModifyLeadBtnIsEnabled = true;
                }
                else
                {
                    (ClaimFormView.DataContext as ClaimFormViewModel).AttachLeadBtnIsEnabled = true;
                    (ClaimFormView.DataContext as ClaimFormViewModel).AddNewLeadBtnIsEnabled = true;
                    (ClaimFormView.DataContext as ClaimFormViewModel).ModifyLeadBtnIsEnabled = false;
                }
            }
        }
        
        
        #endregion

        #region Commands
        private ICommand _saveInspection;
        private ICommand _cancelInspection;

        public ICommand SaveInspection
        {
            get { return _saveInspection; }
            set { _saveInspection = value; }
        }
        public ICommand CancelInspection
        {
            get { return _cancelInspection; }
            set { _cancelInspection = value; }
        }
        #endregion

        public static Task<InspectionViewModel> CreateAsync()
        {
            var ret = new InspectionViewModel();
            return ret.InitializeAsync();
        }

        async private Task<InspectionViewModel> InitializeAsync()
        {
            // Retrieve Required Data

            if(Claim != null && Claim.ClaimID != 0) // If a claim was selected.
            {
                //// Retrieve the Customer, Property Address, Billing Address, previous Inspection, and Lead information.
                //Customer = Customers.Where(c => c.CustomerID == Claim.CustomerID).Single();
                //IsExistingCustomer = true;

                //PropertyAddress = Addresses.Where(a => a.AddressID == Claim.PropertyID).Single();
                //IsExistingAddress = true;
        
                //// Check if the BillingID is the same as PropertyID
                //if (Claim.BillingID == Claim.PropertyID)
                //{
                //    BillingSameAsProperty = true;
                //    BillingAddress = PropertyAddress;
                //}
                //else // If it's not retrieve the BillingAddress from the server
                //{
                //    BillingSameAsProperty = false;
                //    BillingAddress = Addresses.Where(a => a.AddressID == Claim.BillingID).Single();
                //}

                // Retrieve the Inspection attached to the Claim
                if ((ErrorMessage = await new ServiceLayer().GetInspectionsByClaimID(Claim.toDTO())) != null)
                    return this;

                //// Retrieve the Lead attached to the Claim
                //if ((ErrorMessage = await new ServiceLayer().GetLeadByLeadID(new DTO_Lead { LeadID = Claim.LeadID })) != null)
                //    return this;

                //Lead = new Lead(ServiceLayer.Lead);
                //LeadIsAttached = true;

                Inspection = new Inspection(ServiceLayer.InspectionsList.Last());
            }
            else if(Lead != null && Lead.LeadID != 0) // (Lead != null) // If a lead was selected
            {
                // Retrieve the Customer and Property Address Information, and Claim if there is one attached.
                Customer = Customers.Where(c => c.CustomerID == Lead.CustomerID).Single();
                PropertyAddress = Addresses.Where(a => a.AddressID == Lead.AddressID).Single();
                BillingAddress = null;
                
                // Check if any Claims are connected to the Lead
                if (Claims.Any(c=> c.LeadID == Lead.LeadID))
                {
                    Claim = Claims.Where(c => c.LeadID == Lead.LeadID).Single();
                    
                    // Check if BillingID is the same as PropertyID
                    if(Claim.BillingID == Claim.PropertyID)
                    {
                        BillingSameAsProperty = true;
                        BillingAddress = PropertyAddress;
                    }
                    else // If it's not retrieve the BillingAddress from the server
                    {
                        BillingSameAsProperty = false;
                        BillingAddress = Addresses.Where(a => a.AddressID == Claim.BillingID).Single();
                    }

                    // Retrieve the Inspection attached to the Claim
                    if ((ErrorMessage = await new ServiceLayer().GetInspectionsByClaimID(Claim.toDTO())) != null)
                        return this;

                    Inspection = new Inspection(ServiceLayer.InspectionsList.Last());
                }
                else // Instantiate the Claim object
                {
                    Claim = new Claim { LeadID = Lead.LeadID };
                }
                
                BillingAddress = new Address();
                LeadIsAttached = true;
            }
            else
            {
                Claim = new Claim();
                PropertyAddress = new Address();
                BillingAddress = new Address();
                LeadIsAttached = false;

            }

            if(Inspection == null)
            {
                Inspection = new Inspection();
            }

            //if (BillingAddress != null && PropertyAddress.AddressID == BillingAddress.AddressID)
            //{
            //    _billingSameAsProperty = true;
            //}

            // Set up Commands
            _saveInspection = new RelayCommand(new Action<object>(saveInspection));
            _cancelInspection = new RelayCommand(new Action<object>(cancelInspection));

            return this;
        }

        

        async private void saveInspection(object e)
        {

            //if (Lead == null || Lead.LeadID <= 0)
            //{
            //    ErrorMessage = "Every MRN Claim must have a lead. Please either attach a lead or create a new one.";
            //    return;
            //}

            //// If CustomerID doesn't exist create customer.
            //if (Customer.CustomerID == 0)
            //{
            //    if ((ErrorMessage = await new ServiceLayer().AddCustomer(Customer.toDTO())) != null)
            //        return;

            //    Customer.CustomerID = ServiceLayer.Customer.CustomerID;
            //    PropertyAddress.CustomerID = Customer.CustomerID;
            //    BillingAddress.CustomerID = Customer.CustomerID;
            //    Claim.CustomerID = Customer.CustomerID;
            //}
            //else // If Customer does exist.
            //{
            //    PropertyAddress.CustomerID = Customer.CustomerID;
            //    BillingAddress.CustomerID = Customer.CustomerID;
            //    Claim.CustomerID = Customer.CustomerID;

            //    if ((ErrorMessage = await new ServiceLayer().UpdateCustomer(Customer.toDTO())) != null)
            //        return;
            //}

            //// If PropertyAddress doesn't exist create address.
            //if (PropertyAddress.AddressID == 0)
            //{
            //    if ((ErrorMessage = await new ServiceLayer().AddAddress(PropertyAddress.toDTO())) != null)
            //        return;

            //    PropertyAddress.AddressID = ServiceLayer.Address.AddressID;
            //    Claim.PropertyID = PropertyAddress.AddressID;
            //}
            //else // If ProeprtyAddress does exist.
            //{
            //    Claim.PropertyID = PropertyAddress.AddressID;

            //    if ((ErrorMessage = await new ServiceLayer().UpdateAddress(PropertyAddress.toDTO())) != null)
            //        return;
            //}

            //// If BillingAddress ID different from PropertyAddress and doesn't esits create address.
            //if (!_billingSameAsProperty && BillingAddress.AddressID == 0)
            //{
            //    if ((ErrorMessage = await new ServiceLayer().AddAddress(BillingAddress.toDTO())) != null)
            //        return;
            //    BillingAddress.AddressID = ServiceLayer.Address.AddressID;
            //    Claim.BillingID = BillingAddress.AddressID;

            //}
            //else if (_billingSameAsProperty)
            //{
            //    Claim.BillingID = PropertyAddress.AddressID;
            //}
            //else // If BillingAddress does exist.
            //{
            //    ////////////////////////////////////////
            //    /// LOOK INTO THIS CONDITION FURTHER ///
            //    ////////////////////////////////////////
            //    Claim.BillingID = BillingAddress.AddressID;
            //    if ((ErrorMessage = await new ServiceLayer().UpdateAddress(BillingAddress.toDTO())) != null)
            //        return;
            //}

            // If Claim doesn't exist create new claim.
            if (Claim.ClaimID == 0)
            {
                if ((ErrorMessage = await new ServiceLayer().AddClaim(Claim.toDTO())) != null)
                    return;
                Claim.ClaimID = ServiceLayer.Claim.ClaimID;
                Inspection.ClaimID = Claim.ClaimID;
            }
            else //If Claim does exist.
            {
                Inspection.ClaimID = Claim.ClaimID;
                if ((ErrorMessage = await new ServiceLayer().UpdateClaim(Claim.toDTO())) != null)
                    return;
            }

            // Add New Inspection
            if(Inspection.InspectionID == 0)
            {
                if ((ErrorMessage = await new ServiceLayer().AddInspection(Inspection.toDTO())) != null)
                    return;
                Inspection.InspectionID = ServiceLayer.Inspection.InspectionID;
            }
            else
            {
                if ((ErrorMessage = await new ServiceLayer().UpdateInspection(Inspection.toDTO())) != null)
                    return;
            }

            CurrentClaimPage = null;

            

        }

        private void cancelInspection(object e)
        {
            Inspection = null;
            CurrentClaimPage = null;
        }
    }
}
