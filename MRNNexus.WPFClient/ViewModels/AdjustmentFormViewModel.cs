using MRNNexus.WPFClient.Models;
using MRNNexus.WPFClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MRNNexus.WPFClient.ViewModels
{
    class AdjustmentFormViewModel : BaseViewModel
    {
        public event EventHandler OnRequestClose;

        public ICommand SelectAdjuster
        {
            get { return new RelayCommand(new Action<object>(selectAdjuster)); }
        }

        public ICommand SelectClaim
        {
            get { return new RelayCommand(new Action<object>(selectClaim)); }
        }

        public ICommand SubmitAdjustment
        {
            get { return new RelayCommand(new Action<object>(submitAdjustment)); }
        }

        public ICommand CancelAdjustment
        {
            get { return new RelayCommand(new Action<object>(cancelAdjustment)); }
        }

        public AdjustmentFormViewModel()
        {
            if(Adjustment == null)
            {
                Adjustment = new Adjustment();
            }
            if (Claim != null && Claim.ClaimID > 0)
            {
                Adjustment.ClaimID = Claim.ClaimID;
            }
        }

        private void selectAdjuster(object o)
        {
            //AccountSelectView view = new AccountSelectView(6);
            //view.SizeToContent = SizeToContent.WidthAndHeight;
            //view.WindowStyle = WindowStyle.ThreeDBorderWindow;
            //view.ResizeMode = ResizeMode.NoResize;
            //view.ShowDialog();

            if(Adjuster != null && Adjuster.AdjusterID > 0)
            {
                Adjustment.AdjusterID = Adjuster.AdjusterID;
            }
        }

        private void selectClaim(object o)
        {
            //AccountSelectView view = new AccountSelectView(1);
            //view.SizeToContent = SizeToContent.WidthAndHeight;
            //view.WindowStyle = WindowStyle.ThreeDBorderWindow;
            //view.ResizeMode = ResizeMode.NoResize;
            //view.ShowDialog();

            if(Claim != null && Claim.ClaimID > 0)
            {
                Adjustment.ClaimID = Claim.ClaimID;
            }
        }

        async private void submitAdjustment(object o)
        {
            if(Adjustment.AdjustmentID == 0)
            {
                if ((ErrorMessage = await new ServiceLayer().AddAdjustment(Adjustment.toDTO())) != null)
                    return;

                Adjustment = new Adjustment(ServiceLayer.Adjustment);

                if(Adjustments != null) Adjustments.Add(Adjustment);
            }
            else
            {
                if ((ErrorMessage = await new ServiceLayer().UpdateAdjustment(Adjustment.toDTO())) != null)
                    return;
                Adjustment = new Adjustment(ServiceLayer.Adjustment);
            }

            Adjuster = null;
            Adjustment = null;

            OnRequestClose(this, new EventArgs());
        }

        private void cancelAdjustment(object o)
        {
            Adjuster = null;
            Adjustment = null;
            CurrentClaimPage = null;
        }


        
    }
}
