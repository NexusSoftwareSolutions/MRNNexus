
using MRNNexus.WPFClient.Models;
using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MRNNexus.WPFClient.ViewModels
{
    class AccountSelectViewModel : BaseViewModel
    {

        public event EventHandler OnRequestClose;

        #region Fields
        private bool _claimsTabIsSelected = true;
        private bool _claimsTabIsEnabled = true;
        private bool _customerTabIsSelected = false;
        private bool _customerTabIsEnabled = true;
        private bool _leadsTabIsSelected = false;
        private bool _leadsTabIsEnabled = true;
        private bool _addressTabIsSelected = false;
        private bool _addressTabIsEnabled = true;
        private bool _adjustersTabIsSelected = false;
        private bool _adjustersTabIsEnabled = true;
        private Claim _selectedClaim = null;
        private Lead _selectedLead = null;
        private Customer _selectedCustomer = null;
        private Address _selectedAddress = null;
        private Adjuster _selectedAdjuster = null;
        private int code;

        #endregion

        #region Properties
        public bool ClaimsTabIsSelected
        {
            get { return _claimsTabIsSelected; }
            set
            {
                _claimsTabIsSelected = value;
                RaisePropertyChanged("ClaimsTabIsSelected");
            }
        }
        public bool ClaimsTabIsEnabled
        {
            get { return _claimsTabIsEnabled; }
            set
            {
                _claimsTabIsEnabled = value;
                RaisePropertyChanged("ClaimsTabIsEnabled");
            }
        }
        public bool CustomerTabIsSelected
        {
            get { return _customerTabIsSelected; }
            set
            {
                _customerTabIsSelected = value;
                RaisePropertyChanged("CustomerTabIsSelected");
            }
        }
        public bool CustomerTabIsEnabled
        {
            get { return _customerTabIsEnabled; }
            set
            {
                _customerTabIsEnabled = value;
                RaisePropertyChanged("CustomerTabIsEnabled");
            }
        }
        public bool LeadsTabIsSelected
        {
            get { return _leadsTabIsSelected; }
            set
            {
                _leadsTabIsSelected = value;
                RaisePropertyChanged("LeadsTabIsSelected");
            }
        }
        public bool LeadsTabIsEnabled
        {
            get { return _leadsTabIsEnabled; }
            set
            {
                _leadsTabIsEnabled = value;
                RaisePropertyChanged("LeadsTabIsEnabled");
            }
        }
        public bool AddressTabIsSelected
        {
            get { return _addressTabIsSelected; }
            set
            {
                _addressTabIsSelected = value;
                RaisePropertyChanged("AddressTabIsSelected");
            }
        }
        public bool AddressTabIsEnabled
        {
            get { return _addressTabIsEnabled; }
            set
            {
                _addressTabIsEnabled = value;
                RaisePropertyChanged("AddressTabIsEnabled");
            }
        }
        public bool AdjustersTabIsSelected
        {
            get { return _adjustersTabIsSelected; }
            set
            {
                _adjustersTabIsSelected = value;
                RaisePropertyChanged("AdjustersTabIsSelected");
            }
        }
        public bool AdjustersTabIsEnabled
        {
            get { return _adjustersTabIsEnabled; }
            set
            {
                _adjustersTabIsEnabled = value;
                RaisePropertyChanged("AdjustersTabIsEnabled");
            }
        }
        public Claim SelectedClaim
        {
            get { return _selectedClaim; }
            set
            {
                _selectedClaim = value;
                RaisePropertyChanged("SelectedClaim");
            }
        }
        public Lead SelectedLead
        {
            get { return _selectedLead; }
            set
            {
                _selectedLead = value;
                RaisePropertyChanged("SelectedLead");
            }
        }
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged("SelectedCustomer");
            }
        }
        public Address SelectedAddress
        {
            get { return _selectedAddress; }
            set
            {
                _selectedAddress = value;
                RaisePropertyChanged("SelectedAddress");
            }
        }
        public Adjuster SelectedAdjuster
        {
            get { return _selectedAdjuster; }
            set
            {
                _selectedAdjuster = value;
                RaisePropertyChanged("SelectedAdjuster");
            }
        }
        #endregion

        #region Commands
        private ICommand _accountSelected;
        public ICommand AccountSelected
        {
            get { return _accountSelected; }
            set { _accountSelected = value; }
        }
        private ICommand _cancelAccountSelect;
        public ICommand CancelAccountSelect
        {
            get { return _cancelAccountSelect; }
            set { _cancelAccountSelect = value; }
        }
        #endregion


        /// code param will denote which tab to have enabled if not all(0)
        public static Task<AccountSelectViewModel> CreateAsync(int code)
        {
            var ret = new AccountSelectViewModel();
            return ret.InitializeAsync(code);            
        }

        async private Task<AccountSelectViewModel> InitializeAsync(int code)
        {
            this.code = code;

            if (code == 0) // No code all available
            {
                ClaimsTabIsSelected = true;
                LeadsTabIsEnabled = true;
                ClaimsTabIsEnabled = true;
                CustomerTabIsEnabled = true;
                AddressTabIsEnabled = true;
                AdjustersTabIsEnabled = true;
            }
            else if (code == 1) // Claim code 1
            {
                ClaimsTabIsSelected = true;
                LeadsTabIsEnabled = false;
                ClaimsTabIsEnabled = true;
                CustomerTabIsEnabled = false;
                AddressTabIsEnabled = false;
                AdjustersTabIsEnabled = false;
            }
            else if (code == 2) // Lead code 2
            {
                LeadsTabIsSelected = true;
                LeadsTabIsEnabled = true;
                ClaimsTabIsEnabled = false;
                CustomerTabIsEnabled = false;
                AddressTabIsEnabled = false;
                AdjustersTabIsEnabled = false;

            }
            else if (code == 3) // Customer code 3
            {
                CustomerTabIsSelected = true;
                LeadsTabIsEnabled = false;
                ClaimsTabIsEnabled = false;
                CustomerTabIsEnabled = true;
                AddressTabIsEnabled = false;
                AdjustersTabIsEnabled = false;
            }
            else if (code == 4 || code == 5) // Address code 4/5
            {
                AddressTabIsSelected = true;
                LeadsTabIsEnabled = false;
                ClaimsTabIsEnabled = false;
                CustomerTabIsEnabled = false;
                AddressTabIsEnabled = true;
                AdjustersTabIsEnabled = false;
                if (Customer != null && Customer.CustomerID > 0)
                {
                    Addresses = new ObservableCollection<Address>(Addresses.Where(a => a.CustomerID == Customer.CustomerID).ToList());
                }
                else
                {
                    ErrorMessage = "You must use an existing Customer in order to use an existing Address." +
                        "If there is a new customer for a previous Address please enter the address as if it were new.";
                }
            }
            else if(code == 6) // Adjuster code 6
            {
                AdjustersTabIsSelected = true;
                LeadsTabIsEnabled = false;
                ClaimsTabIsEnabled = false;
                CustomerTabIsEnabled = false;
                AddressTabIsEnabled = false;
                AdjustersTabIsEnabled = true;
            }

            if ((ErrorMessage = await new ServiceLayer().GetAllCustomers()) != null)
                return null;

            if ((ErrorMessage = await new ServiceLayer().GetAllAddresses()) != null)
                return null;

            if (LoggedInUser.PermissionID == 1)
            {
                if ((ErrorMessage = await new ServiceLayer().GetAllLeads()) != null)
                    return null;

                if ((ErrorMessage = await new ServiceLayer().GetAllClaims()) != null)
                    return null;
            }
            else
            {
                if ((ErrorMessage = await new ServiceLayer().GetLeadsBySalesPersonID(LoggedInEmployee.toDTO())) != null)
                    return null;

                if ((ErrorMessage = await new ServiceLayer().GetOpenClaimsBySalesPersonID(LoggedInEmployee.toDTO())) != null)
                    return null;
            }

            ///
            /// May need to query for only adjuster related to logged in salespersons accounts
            /// 
            #region Adjusters
            if ((ErrorMessage = await new ServiceLayer().GetAllAdjusters()) != null)
                return null;

            Adjusters = new ObservableCollection<Adjuster>();
            foreach(DTO_Adjuster adjuster in ServiceLayer.AdjustersList)
            {
                Adjusters.Add(new Adjuster(adjuster));
            }
            #endregion

            #region Customers
            Customers = new ObservableCollection<Customer>();
            foreach (DTO_Customer c in ServiceLayer.CustomersList)
            {
                Customers.Add(new Customer(c));
            }
            #endregion

            #region Addresses
            Addresses = new ObservableCollection<Address>();
            foreach (DTO_Address a in ServiceLayer.AddressesList)
            {
                Addresses.Add(new Address(a));
            }
            #endregion

            #region Leads
            Leads = new ObservableCollection<Lead>();

            foreach(DTO_Lead l in ServiceLayer.LeadsList)
            {
                try {
                    Leads.Add(new Lead(l));
                    Customer cust = Customers.Where(c => c.CustomerID == Leads.Last().CustomerID).Single();
                    Leads.Last().CustomerName = cust.FirstName + " " + cust.LastName;
                    Address address = Addresses.Where(a => a.AddressID == Leads.Last().AddressID).Single();
                    Leads.Last().Address = address.StreetAddress + ", " + address.Zip;
                    Leads.Last().LeadType = LeadTypes[Leads.Last().LeadTypeID - 1].LeadType;
                    if (Leads.Last().KnockerResponseID == 0 || Leads.Last().KnockerResponseID == null && Leads.Last().CreditToID != 0)
                    {
                        if ((ErrorMessage = await new ServiceLayer().GetReferrerByID(new Referrer { ReferrerID = (int)Leads.Last().CreditToID }.toDTO())) != null)
                            return null;
                        Leads.Last().CreditTo = ServiceLayer.Referrer.FirstName + " " + ServiceLayer.Referrer.LastName;
                        Referrer = new Referrer(ServiceLayer.Referrer);
                    }
                    else if(Leads.Last().KnockerResponseID != 0)
                    {
                        if ((ErrorMessage = await new ServiceLayer().GetEmployeeByID(new Employee { EmployeeID = (int)Leads.Last().CreditToID }.toDTO())) != null)
                            return null;
                        Leads.Last().CreditTo = ServiceLayer.Employee.FirstName + " " + ServiceLayer.Employee.LastName;
                    }
                }
                catch(Exception EX)
                {

                }
            }
            #endregion

            #region Claims
            Claims = new ObservableCollection<Claim>();

            foreach (DTO_Claim claim in ServiceLayer.ClaimsList)
            {
                Claims.Add(new Claim(claim));
                Customer cust = Customers.Where(c => c.CustomerID == Claims.Last().CustomerID).Single();
                Claims.Last().CustomerName = cust.FirstName + " " + cust.LastName;
                Address address = Addresses.Where(a => a.AddressID == Claims.Last().PropertyID).Single();
                Claims.Last().Address = address.StreetAddress + ", " + address.Zip;
                //if ((ErrorMessage = await new ServiceLayer().GetCustomerByID(new Customer { CustomerID = Claims.Last().CustomerID }.toDTO())) != null)
                //    return null;
                //if ((ErrorMessage = await new ServiceLayer().GetAddressByID(new Address { AddressID = Claims.Last().PropertyID }.toDTO())) != null)
                //    return null;

                //Claims.Last().CustomerName = ServiceLayer.Customer.FirstName + " " + ServiceLayer.Customer.LastName;
                //Claims.Last().Address = ServiceLayer.Address.Address + ", " + ServiceLayer.Address.Zip;
            }
            #endregion

            AccountSelected = new RelayCommand(new Action<object>(accountSelected));
            CancelAccountSelect = new RelayCommand(new Action<object>(cancelAccountSelect));         

            return this;
        }

        async private void accountSelected(object o)
        {
            //Claim = null;
            //Lead = null;
            //Customer = null;
            //PropertyAddress = null;
            //BillingAddress = null;

            if (o is Claim)
            {
                Claim = o as Claim;
                // Retrieve the Customer, Property Address, Billing Address, previous Inspection, and Lead information.
                Customer = Customers.Where(c => c.CustomerID == Claim.CustomerID).Single();
                IsExistingCustomer = true;

                PropertyAddress = Addresses.Where(a => a.AddressID == Claim.PropertyID).Single();
                IsExistingAddress = true;

                // Check if the BillingID is the same as PropertyID
                if (Claim.BillingID == Claim.PropertyID)
                {
                   /// BillingSameAsProperty = true;
                    BillingAddress = PropertyAddress;
                }
                else // If it's not retrieve the BillingAddress from the server
                {
                    ///BillingSameAsProperty = false;
                    BillingAddress = Addresses.Where(a => a.AddressID == Claim.BillingID).Single();
                }

                // Retrieve the Inspection attached to the Claim
                if ((ErrorMessage = await new ServiceLayer().GetInspectionsByClaimID(Claim.toDTO())) != null)
                    return;

                // Retrieve the Lead attached to the Claim
                if ((ErrorMessage = await new ServiceLayer().GetLeadByLeadID(new DTO_Lead { LeadID = Claim.LeadID })) != null)
                    return;

                Lead = new Lead(ServiceLayer.Lead);
                ///LeadIsAttached = true;

                Inspection = new Inspection(ServiceLayer.InspectionsList.Last());
            }
            else if(o is Lead)
            {
                Lead = o as Lead;
                // Retrieve the Customer and Property Address Information, and Claim if there is one attached.
                Customer = Customers.Where(c => c.CustomerID == Lead.CustomerID).Single();
                IsExistingCustomer = true;
                PropertyAddress = Addresses.Where(a => a.AddressID == Lead.AddressID).Single();
                IsExistingAddress = true;
                BillingAddress = null;

                // Check if any Claims are connected to the Lead
                if (Claims.Any(c => c.LeadID == Lead.LeadID))
                {
                    Claim = Claims.Where(c => c.LeadID == Lead.LeadID).Single();

                    // Check if BillingID is the same as PropertyID
                    if (Claim.BillingID == Claim.PropertyID)
                    {
                        ///BillingSameAsProperty = true;
                        BillingAddress = PropertyAddress;
                        IsExistingAddressB = true;
                    }
                    else // If it's not retrieve the BillingAddress from the server
                    {
                        ///BillingSameAsProperty = false;
                        BillingAddress = Addresses.Where(a => a.AddressID == Claim.BillingID).Single();
                    }

                    // Retrieve the Inspection attached to the Claim
                    if ((ErrorMessage = await new ServiceLayer().GetInspectionsByClaimID(Claim.toDTO())) != null)
                        return;

                    Inspection = new Inspection(ServiceLayer.InspectionsList.Last());
                }
                else // Instantiate the Claim object
                {
                    Claim = new Claim { LeadID = Lead.LeadID };
                }

                BillingAddress = new Address();
                ///LeadIsAttached = true;
            }
            else if(o is Customer)
            {
                Customer = o as Customer;

            }
            else if(o is Address && code == 4)
            {
                PropertyAddress = o as Address;

            }
            else if (o is Address && code == 5)
            {
                BillingAddress = o as Address;

            }

            else if(o is Adjuster && code == 6)
            {
                Adjuster = o as Adjuster;
            }
            else if(o == null)
            {
                AddLead.Execute(o);
            }

            OnRequestClose(this, new EventArgs());
        }

        private void cancelAccountSelect(object o)
        {
            IsExistingCustomer = false;
            IsExistingAddress = false;
            OnRequestClose(this, new EventArgs());
        }

    }
}
