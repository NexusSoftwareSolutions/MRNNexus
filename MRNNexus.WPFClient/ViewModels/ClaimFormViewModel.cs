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
    class ClaimFormViewModel : BaseViewModel
    {
        #region Fields
        private bool _attachLeadBtnIsEnabled = true;
        private bool _addNewLeadBtnIsEnabled = true;
        private bool _modifyLeadBtnIsEnabled = false;
        private ObservableCollection<DTO_InsuranceCompany> _insuranceCompanies;
        #endregion

        #region Properties
        public bool AttachLeadBtnIsEnabled
        {
            get { return _attachLeadBtnIsEnabled; }
            set
            {
                _attachLeadBtnIsEnabled = value;
                RaisePropertyChanged("AttachLeadBtnIsEnabled");
            }
        }
        public bool AddNewLeadBtnIsEnabled
        {
            get { return _addNewLeadBtnIsEnabled; }
            set
            {
                _addNewLeadBtnIsEnabled = value;
                RaisePropertyChanged("AddNewLeadBtnIsEnabled");
            }
        }
        public bool ModifyLeadBtnIsEnabled
        {
            get { return _modifyLeadBtnIsEnabled; }
            set
            {
                _modifyLeadBtnIsEnabled = value;
                RaisePropertyChanged("ModifyLeadBtnIsEnabled");
            }
        }
        public ObservableCollection<DTO_InsuranceCompany> InsuranceCompanies
        {
            get { return _insuranceCompanies; }
            set
            {
                _insuranceCompanies = value;
                RaisePropertyChanged("InsuranceComapnies");
            }
        }
        #endregion

        #region Commands
        public ICommand AttachLead
        {
            get { return new RelayCommand(new Action<object>(o => 
                {
                    new AccountSelectView(2).ShowDialog();
                    if(Lead != null && Lead.LeadID > 0)
                    {
                        AttachLeadBtnIsEnabled = false;
                        AddNewLeadBtnIsEnabled = false;
                        ModifyLeadBtnIsEnabled = true;
                    }
                }));
            }
        }
        public ICommand AddNewLead
        {
            get
            {
                return new RelayCommand(new Action<object>(o =>
                {
                    LeadView leadView = new LeadView();
                    leadView.SizeToContent = SizeToContent.WidthAndHeight;
                    leadView.WindowStyle = WindowStyle.ThreeDBorderWindow;
                    leadView.ResizeMode = ResizeMode.NoResize;
                    leadView.ShowDialog();

                    if (Lead != null && Lead.LeadID > 0)
                    {
                        AttachLeadBtnIsEnabled = false;
                        AddNewLeadBtnIsEnabled = false;
                        ModifyLeadBtnIsEnabled = true;
                    }
                }));
            }
        }
        public ICommand ModifyLead
        {
            get
            {
                return new RelayCommand(new Action<object>(o =>
                {
                    LeadView leadView = new LeadView();
                    leadView.SizeToContent = SizeToContent.WidthAndHeight;
                    leadView.WindowStyle = WindowStyle.ThreeDBorderWindow;
                    leadView.ResizeMode = ResizeMode.NoResize;
                    leadView.ShowDialog();

                    if (Lead != null && Lead.LeadID > 0)
                    {
                        AttachLeadBtnIsEnabled = false;
                        AddNewLeadBtnIsEnabled = false;
                        ModifyLeadBtnIsEnabled = true;
                    }
                }));
            }
        }
        #endregion

        public ClaimFormViewModel()
        {
            InsuranceCompanies = new ObservableCollection<DTO_InsuranceCompany>(ServiceLayer.InsuranceCompaniesList);
        }




    }
}
