using MRNNexus.WPFClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MRNNexus.WPFClient.ViewModels
{
    class CustomerFormViewModel : BaseViewModel
    {
        #region Fields
        private bool _billingSameAsProperty = false;
        private bool _billingAddressIsEnabled = true;
        #endregion

        #region Properties
        public bool BillingSameAsProperty
        {
            get {
                if (PropertyAddress.Equals(BillingAddress))
                {
                    _billingSameAsProperty = true;
                    BillingAddressIsEnabled = false;
                }
                else
                {
                    _billingSameAsProperty = false;
                    BillingAddressIsEnabled = true;
                }
                return _billingSameAsProperty; }
            set
            {
                _billingSameAsProperty = value;
                if (!value)
                {
                    BillingAddress = new Address();
                    BillingAddressIsEnabled = true;
                }
                else
                {
                    BillingAddress = PropertyAddress;
                }
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
        #endregion

        #region Commands
        public ICommand SubmitCustomer
        {
            get { return new RelayCommand(new Action<object>(submitCustomer)); }
        }
        public ICommand Cancel
        {
            get { return new RelayCommand(new Action<object>(cancel)); }
        }
        #endregion

        public CustomerFormViewModel() { }

        async public void submitCustomer(object o)
        {
            if(Customer.CustomerID == 0) // If the Customer doesn't exist (it should exist)
            {
                // Create the Customer
                if ((ErrorMessage = await new ServiceLayer().AddCustomer(Customer.toDTO())) != null)
                {
                    return;
                }

                // Add it to the Customers list
                Customers.Add(new Customer(ServiceLayer.Customer));
            }
            else if(Customer.CustomerID > 0) // If the Claim does exist (it should)
            {
                // Update the Customer
                if((ErrorMessage = await new ServiceLayer().UpdateCustomer(Customer.toDTO())) != null)
                {
                    return;
                }

                // Overwrite the original Customer in the Customers list with the updated information
                Customer customer = Customers.Where(c => c.CustomerID == Customer.CustomerID).Single();
                int index = Customers.IndexOf(customer);
                Customers[index] = new Customer(ServiceLayer.Customer);
            }
        }

        // Cancel any changes to the Customer and remove the page from the frame
        public void cancel(object o)
        {
            Customer = Customers.Where(c => c.CustomerID == Customer.CustomerID).Single();
            CurrentClaimPage = null;
        }
    }
}
