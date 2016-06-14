using MRNNexus.WPFClient.Models;
using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MRNNexus.WPFClient.ViewModels
{
    class LeadViewModel : BaseViewModel
    {
        public event EventHandler OnRequestClose;

        #region Fields
        private bool _submitButtonIsEnabled = false;
        #endregion

        #region Properties
        public bool SubmitButtonIsEnabled
        {
            get { return _submitButtonIsEnabled; }
            set
            {
                _submitButtonIsEnabled = value;
                RaisePropertyChanged("SubmitButtonIsEnabled");
            }
        }
        

        #endregion

        #region Commands
        public ICommand SubmitLead
        {
            get { return new RelayCommand(new Action<object>(submitLead)); }
        }
        public ICommand CancelLead
        {
            get { return new RelayCommand(new Action<object>(cancelLead)); }
        }
        #endregion

        public LeadViewModel()
        {
            setup();
        }

        async private void setup()
        {
            Employees = new ObservableCollection<Employee>();

            ServiceLayer.EmployeesList = null;

            if ((ErrorMessage = await new ServiceLayer().GetEmployeesByEmployeeTypeID(new DTO_LU_EmployeeType { EmployeeTypeID = 14 })) != null)
                return;

            foreach (DTO_Employee e in ServiceLayer.EmployeesList) { Employees.Add(new Employee(e)); }

            if (Lead == null || Lead.LeadID <= 0){
                Lead = new Lead();
                Customer = new Customer();
                PropertyAddress = new Address();
                KnockerResponse = new KnockerResponse();
                Referrer = new Referrer();
            }
            else
            {
                if(Lead.SalespersonID <= 0)
                {
                    if((ErrorMessage = await new ServiceLayer().GetLeadByLeadID(Lead.toDTO())) != null)
                        return;
                }
                if ((ErrorMessage = await new ServiceLayer().GetCustomerByID(new DTO_Customer { CustomerID = Lead.CustomerID })) != null)
                    return;
                Customer = new Customer(ServiceLayer.Customer);

                if ((ErrorMessage = await new ServiceLayer().GetAddressByID(new DTO_Address { AddressID = Lead.AddressID })) != null)
                    return;
                PropertyAddress = new Address(ServiceLayer.Address);

                if (Lead.KnockerResponseID != null && Lead.KnockerResponseID > 0)
                {
                    if ((ErrorMessage = await new ServiceLayer().GetKnockerResponseByID(new DTO_KnockerResponse { KnockerResponseID = (int)Lead.KnockerResponseID })) != null)
                        return;
                    KnockerResponse = new KnockerResponse(ServiceLayer.KnockerResponse);
                    Employee = Employees.Where(e => e.EmployeeID == KnockerResponse.KnockerID).Single();
                }
            }
        }

        async private void submitLead(object o)
        {
            #region Process Customer
            if (!IsExistingCustomer)
            {
                if ((ErrorMessage = await new ServiceLayer().AddCustomer(Customer.toDTO())) != null)
                    return;

                Customer = new Customer(ServiceLayer.Customer);
                PropertyAddress.CustomerID = Customer.CustomerID;
            }

            else // If Customer does exist.
            {
                PropertyAddress.CustomerID = Customer.CustomerID;

                if ((ErrorMessage = await new ServiceLayer().UpdateCustomer(Customer.toDTO())) != null)
                    return;
            }
            #endregion

            #region Process Address
            if (PropertyAddress.AddressID == 0)
            {
                if ((ErrorMessage = await new ServiceLayer().AddAddress(PropertyAddress.toDTO())) != null)
                    return;

                PropertyAddress.AddressID = ServiceLayer.Address.AddressID;
            }
            else // If ProeprtyAddress does exist.
            {
                if ((ErrorMessage = await new ServiceLayer().UpdateAddress(PropertyAddress.toDTO())) != null)
                    return;
            }
            #endregion

            #region Process Lead
            if (Lead.LeadTypeID == 1)
            {
                // If KnockerResponse does not exist
                
                if (KnockerResponse.KnockerResponseID == 0)
                {
                    if ((ErrorMessage = await new ServiceLayer().AddKnockerResponse(KnockerResponse.toDTO())) != null)
                        return;

                    KnockerResponse = new KnockerResponse(ServiceLayer.KnockerResponse);
                    Lead.KnockerResponseID = KnockerResponse.KnockerResponseID;
                    Lead.CreditToID = KnockerResponse.KnockerID;
                }
                else
                {   
                    /// If KnockerRepsonse does exist? 
                    /// Perhaps add checkbox to signal create window to select knocker response from table?
                    /// In which case this becomes a KnockerResponseUpdate area.
                }
            }
            else if(Lead.LeadTypeID == 2)
            {

                if(Referrer.ReferrerID == 0)
                {
                    if ((ErrorMessage = await new ServiceLayer().AddReferrer(Referrer.toDTO())) != null)
                        return;

                    Referrer = new Referrer(ServiceLayer.Referrer);
                    Lead.CreditToID = Referrer.ReferrerID;
                }
                else
                {
                    /// If Referrer does exist? 
                    /// Perhaps add checkbox to signal create window to select Referrer from table?
                    /// In which case this becomes a ReferrerUpdate area.
                }
            }

            Lead.SalespersonID = LoggedInEmployee.EmployeeID;
            Lead.CustomerID = Customer.CustomerID;
            Lead.AddressID = PropertyAddress.AddressID;
            Lead.Status = "A";

            if (Lead.LeadID == 0) { 
                if ((ErrorMessage = await new ServiceLayer().AddLead(Lead.toDTO())) != null)
                    return;

                Lead.LeadID = ServiceLayer.Lead.LeadID;
            }
            else
            {
                if ((ErrorMessage = await new ServiceLayer().UpdateLead(Lead.toDTO())) != null)
                    return;                
            }

            OnRequestClose(this, new EventArgs());
            #endregion
        }

        private void cancelLead(object o)
        {
            //OnRequestClose(this, new EventArgs());
            double height = CurrentPage.ActualHeight;
            //if(CurrentPage.DataContext.GetType() != typeof(ScheduleViewModel))
            //{
            //    CurrentPage = new ScheduleView();
            //}
            //else
            //{
                OnRequestClose(this, new EventArgs());
            //}
        }
    }
}
