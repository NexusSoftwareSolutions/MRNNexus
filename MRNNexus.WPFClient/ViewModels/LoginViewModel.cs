using MRNNexus.WPFClient.Models;
using MRNNexusDTOs;
using System;
using System.Collections.Generic;
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

            /////////////////// SO I DONT HAVE TO TYPE LOGIN INFO FOR TESTING //////////////////
            LoggedInUser.Username = "aharvey@gmail.com";
            LoggedInUser.Pass = "Harvey1214";
            ////////////////////////////////////////////////////////////////////////////////////
            if((ErrorMessage = await new ServiceLayer().Login(LoggedInUser.toDTO())) != null)
            {
                LoginIsEnabled = true;
                return;
            }
            else
            {
                if((ErrorMessage = await new ServiceLayer().GetUser(LoggedInUser.toDTO())) != null)
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
                else if (ServiceLayer.LoggedInEmployee.EmployeeID > 0 && ServiceLayer.LoggedInUser.Active)
                {
                    LoggedInEmployee = new Employee(ServiceLayer.LoggedInEmployee);
                    LoggedInUser = new User(ServiceLayer.LoggedInUser);
                    MenuBarIsEnabled = true;
                    CurrentPage = new ScheduleView();
                }
            }
        }

    }
}
