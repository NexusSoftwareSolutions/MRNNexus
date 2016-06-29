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
            #region Customer
            if (Customer.CustomerID == 0) // If the Customer doesn't exist (it should exist)
            {
                // Create the Customer
                if ((ErrorMessage = await new ServiceLayer().AddCustomer(Customer.toDTO())) != null)
                {
                    return;
                }

                Customer = new Customer(ServiceLayer.Customer);

                // Add it to the Customers list
                Customers.Add(Customer);
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
                Customer = Customers[index];

                // Reassign the CustomerName property in any Claims it is attached to in case it changed.
                var claims = Claims.Where(c => c.CustomerID == Customer.CustomerID).ToList();
                foreach (var c in claims)
                {
                    int i = Claims.IndexOf(c);
                    Claims[i].CustomerName = Customer.FullName;
                }
            }
            #endregion

            #region PropertyAddress

            if(PropertyAddress.AddressID == 0) // If the PropertyAddress does not exist.
            {
                // Create the Address
                if ((ErrorMessage = await new ServiceLayer().AddAddress(PropertyAddress.toDTO())) != null)
                {
                    return;
                }

                PropertyAddress = new Address(ServiceLayer.Address);
                Addresses.Add(PropertyAddress);
            }
            else if (PropertyAddress.AddressID > 0) // If the PropertyAddress does exist (it should)
            {
                // Update the PropertyAddress
                if ((ErrorMessage = await new ServiceLayer().UpdateAddress(PropertyAddress.toDTO())) != null)
                {
                    return;
                }

                // Overwrite the original Address in the Addresses list with the updated information
                Address address = Addresses.Where(a => a.AddressID == PropertyAddress.AddressID).Single();
                int index = Addresses.IndexOf(address);
                Addresses[index] = new Address(ServiceLayer.Address);
            }
            #endregion

            #region BillingAddress
            if (!BillingSameAsProperty) // If BillingAddress is NOT the same as PropertyAddress
            {
                if (BillingAddress.AddressID == 0) // If the PropertyAddress does not exist.
                {
                    // Create the Address
                    if ((ErrorMessage = await new ServiceLayer().AddAddress(BillingAddress.toDTO())) != null)
                    {
                        return;
                    }

                    BillingAddress = new Address(ServiceLayer.Address);
                    Addresses.Add(BillingAddress);
                }
                else if (BillingAddress.AddressID > 0) // If the PropertyAddress does exist (it should)
                {
                    // Update the PropertyAddress
                    if ((ErrorMessage = await new ServiceLayer().UpdateAddress(BillingAddress.toDTO())) != null)
                    {
                        return;
                    }

                    // Overwrite the original Address in the Addresses list with the updated information
                    Address address = Addresses.Where(a => a.AddressID == BillingAddress.AddressID).Single();
                    int index = Addresses.IndexOf(address);
                    Addresses[index] = new Address(ServiceLayer.Address);
                }
            }
            #endregion
        }

        // Cancel any changes to the Customer and remove the page from the frame
        public void cancel(object o)
        {
            Customer = Customers.Where(c => c.CustomerID == Customer.CustomerID).Single();
            CurrentClaimPage = null;
        }
    }
}
