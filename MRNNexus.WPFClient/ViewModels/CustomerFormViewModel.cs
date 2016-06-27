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

        public void submitCustomer(object o)
        {

        }

        public void cancel(object o)
        {
            CurrentClaimPage = null;
        }
    }
}
