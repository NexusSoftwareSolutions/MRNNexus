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
    class LoginViewModel : BaseViewModel
    {
        #region Fields
        private bool _loginIsEnabled = true;
        #endregion

        #region Properties
        public bool LoginIsEnabled
        {
            get { return _loginIsEnabled; }
            set
            {
                _loginIsEnabled = value;
                RaisePropertyChanged("LoginIsEnabled");
            }
        }
        #endregion

        #region Commands
        public ICommand Login
        {
            get { return new RelayCommand(new Action<object>(login)); }
        }
        #endregion

        public LoginViewModel()
        {
            LoggedInUser = new User();
        }

        async private void login(object o)
        {
            LoginIsEnabled = false;
            IsBusyLoading = true;

            /////////////////// SO I DONT HAVE TO TYPE LOGIN INFO FOR TESTING //////////////////
            LoggedInUser.Username = "aharvey@gmail.com";
            LoggedInUser.Pass = "Harvey1214";
            ////////////////////////////////////////////////////////////////////////////////////
            if((ErrorMessage = await new ServiceLayer().Login(LoggedInUser.toDTO())) != null)
            {
                LoginIsEnabled = true;
                return;
            }
            else if ((ErrorMessage = await new ServiceLayer().GetUser(LoggedInUser.toDTO())) != null)
            {
                LoginIsEnabled = true;
                return;
            }
            else if (!ServiceLayer.LoggedInUser.Active)
            {
                ErrorMessage = "This user is inactive please contact a system adminitrator.";
                LoginIsEnabled = true;
                return;
            }
            else
            {
               loadData();
                IsBusyLoading = true;
                
            }
        }
    

        async private Task loadData()
        {
            
            if (ServiceLayer.LoggedInEmployee.EmployeeID > 0 && ServiceLayer.LoggedInUser.Active)
            {
                LoggedInEmployee = new Employee(ServiceLayer.LoggedInEmployee);
                LoggedInUser = new User(ServiceLayer.LoggedInUser);

                if (LoggedInUser.PermissionID == 1)
                {
                    if ((ErrorMessage = await new ServiceLayer().GetAllClaims()) != null)
                    {
                        LoginIsEnabled = true;
                        return;
                    }
                    if ((ErrorMessage = await new ServiceLayer().GetAllLeads()) != null)
                    {
                        LoginIsEnabled = true;
                        return;
                    }
                    if ((ErrorMessage = await new ServiceLayer().GetAllInspections()) != null)
                    {
                        LoginIsEnabled = true;
                        return;
                    }
                    if((ErrorMessage = await new ServiceLayer().GetEmployeesByEmployeeTypeID(new DTO_LU_EmployeeType { EmployeeTypeID = 14 })) != null)
                    {
                        LoginIsEnabled = true;
                        return;
                    }

                    Inspections = new ObservableCollection<Inspection>();

                    foreach (DTO_Inspection i in ServiceLayer.InspectionsList)
                    {
                        Inspections.Add(new Inspection(i));
                    }

                    Employees = new ObservableCollection<Employee>();
                    foreach(DTO_Employee e in ServiceLayer.EmployeesList)
                    {
                        Employees.Add(new Employee(e));
                    }
                }
                else {
                    if ((ErrorMessage = await new ServiceLayer().GetRecentClaimsBySalesPersonID(LoggedInEmployee.toDTO())) != null)
                    {
                        LoginIsEnabled = true;
                        return;
                    }
                    if ((ErrorMessage = await new ServiceLayer().GetRecentLeadsBySalesPersonID(LoggedInEmployee.toDTO())) != null)
                    {
                        LoginIsEnabled = true;
                        return;
                    }
                    if ((ErrorMessage = await new ServiceLayer().GetRecentInspectionsBySalesPersonID(LoggedInEmployee.toDTO())) != null)
                    {
                        LoginIsEnabled = true;
                        return;
                    }
                }

                MenuBarIsEnabled = true;
                CurrentPage = new ScheduleView();
            }
        }

    }
}
