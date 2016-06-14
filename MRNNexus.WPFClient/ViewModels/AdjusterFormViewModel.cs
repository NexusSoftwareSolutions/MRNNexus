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
    class AdjusterFormViewModel : BaseViewModel
    {
        public event EventHandler OnRequestClose;

        public ObservableCollection<DTO_InsuranceCompany> InsuranceCompanies { get; set; }

        #region Commands
        public ICommand SaveAdjuster
        {
            get { return new RelayCommand( new Action<object>(saveAdjuster)); }
        }
        #endregion

        public AdjusterFormViewModel()
        {
            if(Adjuster == null)
            {
                Adjuster = new Adjuster();
            }
            InsuranceCompanies = new ObservableCollection<DTO_InsuranceCompany>(ServiceLayer.InsuranceCompaniesList);
        }

        async private void saveAdjuster(object o)
        {
            if (Adjuster.AdjusterID == 0)
            {
                if ((ErrorMessage = await new ServiceLayer().AddAdjuster(Adjuster.toDTO())) != null)
                    return;

                Adjuster = new Adjuster(ServiceLayer.Adjuster);
                Adjusters.Add(Adjuster);
            }
            else
            {
                if ((ErrorMessage = await new ServiceLayer().UpdateAdjuster(Adjuster.toDTO())) != null)
                    return;

                Adjuster = new Adjuster(ServiceLayer.Adjuster);
            }

            OnRequestClose(this, new EventArgs());
        }
    }
}
