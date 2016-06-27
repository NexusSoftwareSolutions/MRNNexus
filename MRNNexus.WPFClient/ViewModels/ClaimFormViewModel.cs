﻿using MRNNexus.WPFClient.Models;
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
        //public ObservableCollection<DTO_InsuranceCompany> InsuranceCompanies
        //{
        //    get { return _insuranceCompanies; }
        //    set
        //    {
        //        _insuranceCompanies = value;
        //        RaisePropertyChanged("InsuranceCompanies");
        //    }
        //}
        #endregion

        #region Commands
        //public ICommand AttachLead
        //{
        //    get { return new RelayCommand(new Action<object>(o => 
        //        {
        //            //new AccountSelectView(2).ShowDialog();
        //            if(Lead != null && Lead.LeadID > 0)
        //            {
        //                AttachLeadBtnIsEnabled = false;
        //                AddNewLeadBtnIsEnabled = false;
        //                ModifyLeadBtnIsEnabled = true;
        //            }
        //        }));
        //    }
        //}

        //public ICommand AddNewLead
        //{
        //    get
        //    {
        //        return new RelayCommand(new Action<object>(o =>
        //        {
        //            LeadView leadView = new LeadView();
        //            leadView.SizeToContent = SizeToContent.WidthAndHeight;
        //            leadView.WindowStyle = WindowStyle.ThreeDBorderWindow;
        //            leadView.ResizeMode = ResizeMode.NoResize;
        //            leadView.ShowDialog();

        //            if (Lead != null && Lead.LeadID > 0)
        //            {
        //                AttachLeadBtnIsEnabled = false;
        //                AddNewLeadBtnIsEnabled = false;
        //                ModifyLeadBtnIsEnabled = true;
        //            }
        //        }));
        //    }
        //}

        //public ICommand ModifyLead
        //{
        //    get
        //    {
        //        return new RelayCommand(new Action<object>(o =>
        //        {
        //            LeadView leadView = new LeadView();
        //            leadView.SizeToContent = SizeToContent.WidthAndHeight;
        //            leadView.WindowStyle = WindowStyle.ThreeDBorderWindow;
        //            leadView.ResizeMode = ResizeMode.NoResize;
        //            leadView.ShowDialog();

        //            if (Lead != null && Lead.LeadID > 0)
        //            {
        //                AttachLeadBtnIsEnabled = false;
        //                AddNewLeadBtnIsEnabled = false;
        //                ModifyLeadBtnIsEnabled = true;
        //            }
        //        }));
        //    }
        //}

        public ICommand SubmitClaim
        {
            get { return new RelayCommand(new Action<object>(submitClaim)); }
        }
        public ICommand Cancel
        {
            get { return new RelayCommand(new Action<object>(cancel)); }
        }
        #endregion

        public ClaimFormViewModel()
        {
            InsuranceCompanies = new ObservableCollection<DTO_InsuranceCompany>(ServiceLayer.InsuranceCompaniesList);
        }

        async public void submitClaim(object o)
        {
            if (Claim.ClaimID == 0) // If the claim doesn't exist (it should exist)
            {
                // Create the Claim
                if((ErrorMessage = await new ServiceLayer().AddClaim(Claim.toDTO())) != null)
                {
                    return;
                }

                // Add it to the Claims list
                Claims.Add(new Claim(ServiceLayer.Claim));
            }
            else if (Claim.ClaimID > 0) // If the Claim does exist (it should)
            {
                // Update the Claim
                if((ErrorMessage = await new ServiceLayer().UpdateClaim(Claim.toDTO())) != null)
                {
                    return;
                }

                // Overwrite the original Claim in the Claims list with the updated information
                Claim claim = Claims.Where(c => c.ClaimID == Claim.ClaimID).Single();
                int index = Claims.IndexOf(claim);
                Claims[index] = new Claim(ServiceLayer.Claim);
            }
        }

        // Cancel any changes to the Claim and remove the page from the frame
        public void cancel(object o)
        {
            Claim = Claims.Where(c => c.ClaimID == Claim.ClaimID).Single();
            CurrentClaimPage = null;
        }

        




    }
}
