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
    class AdjusterSelectViewModel : BaseViewModel
    {
        public event EventHandler OnRequestClose;

        #region Fields
        private Adjuster _selectedAdjuster;
        #endregion

        #region Properties
        public Adjuster SelectedAdjuster
        {
            get { return _selectedAdjuster; }
            set {
                _selectedAdjuster = value;
                RaisePropertyChanged("SelectedAdjuster");
            }

        }
        #endregion

        #region Commands
        public ICommand AdjusterSelected
        {
            get { return new RelayCommand(new Action<object>(adjusterSelected)); }
        }
        public ICommand CancelAdjusterSelect
        {
            get { return new RelayCommand(new Action<object>(cancelAdjusterSelect)); }
        }
        #endregion

        public AdjusterSelectViewModel()
        {
            setUp();   
        }

        async private void setUp()
        {
            if ((ErrorMessage = await new ServiceLayer().GetAllAdjusters()) != null)
                return;

            Adjusters = new ObservableCollection<Adjuster>();

            foreach (DTO_Adjuster a in ServiceLayer.AdjustersList)
            {
                Adjusters.Add(new Adjuster(a));
                Adjusters.Last().InsuranceCompany = ServiceLayer.InsuranceCompaniesList.Where(i => i.InsuranceCompanyID == Adjusters.Last().InsuranceCompanyID).Single().CompanyName;
            }
        }

        private void adjusterSelected(object o)
        {
            if(o is Adjuster)
            {
                Adjuster = o as Adjuster;
            }

            OnRequestClose(this, new EventArgs());
        }

        private void cancelAdjusterSelect(object o)
        {
            OnRequestClose(this, new EventArgs());
        }
    }
}
