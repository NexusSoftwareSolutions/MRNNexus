using Microsoft.Win32;
using MRNNexus.WPFClient.Models;
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
        private string _file;

        public string File
        {
            get { return _file; }
            set
            {
                _file = value;
                RaisePropertyChanged("File");
            }
        }

        public ICommand SelectFile { get { return new RelayCommand(new Action<object>(selectFile)); } }
        public ICommand SaveFile { get { return new RelayCommand(new Action<object>(saveFile)); } }
        public ICommand Cancel { get { return new RelayCommand(new Action<object>(cancel)); } }


        public ClaimDocumentFormViewModel()
        {
            ClaimDocument = new ClaimDocument { ClaimID = Claim.ClaimID };
        }

        public void selectFile(object o)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();

            if ((bool)result)
            {
                File = openFileDialog.FileName;
                ClaimDocument.FileName = System.IO.Path.GetFileNameWithoutExtension(_file).Replace(" ", "_");
                ClaimDocument.FileBytes = Convert.ToBase64String(System.IO.File.ReadAllBytes(_file));
                ClaimDocument.FileExt = System.IO.Path.GetExtension(_file);
            }
            else
            {

            }


        }

        async public void saveFile(object o)
        {
            if(ClaimDocument.DocumentID == 0) // If the ClaimDocument does not already exist.
            {
                if ((ErrorMessage = await new ServiceLayer().AddClaimDocument(ClaimDocument.toDTO())) != null)
                    return;

                ClaimDocument = new ClaimDocument(ServiceLayer.ClaimDocument);
            }
            else // If the ClaimDocument already exists.
            {
                if ((ErrorMessage = await new ServiceLayer().UpdateClaimDocument(ClaimDocument.toDTO())) != null)
                    return;
            }
        }

        public void cancel(object o)
        {
            ClaimDocument = null;
            CurrentClaimPage = null;
        }
    }
}
