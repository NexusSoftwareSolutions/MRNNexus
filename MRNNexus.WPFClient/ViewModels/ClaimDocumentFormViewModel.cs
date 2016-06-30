using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MRNNexus.WPFClient.ViewModels
{
    class ClaimDocumentFormViewModel :BaseViewModel
    {
        public ICommand SelectFile { get { return new RelayCommand(new Action<object>(selectFile)); } }
        public ICommand SaveFile { get { return new RelayCommand(new Action<object>(saveFile)); } }
        public ICommand Cancel { get { return new RelayCommand(new Action<object>(cancel)); } }

        public void selectFile(object o)
        {

        }

        public void saveFile(object o)
        {

        }

        public void cancel(object o)
        {
            ClaimDocument = null;
            CurrentClaimPage = null;
        }
    }
}
