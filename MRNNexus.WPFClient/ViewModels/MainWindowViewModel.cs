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
    class MainWindowViewModel : BaseViewModel
    {

        public MainWindowViewModel()
        {
            getLookups();

        }
        
        async private void getLookups()
        {
            if ((ErrorMessage = await new ServiceLayer().GetAllInsuranceCompanyNames()) != null)
                return;

            if ((ErrorMessage = await ServiceLayer.buildLUs()) != null)
            {
                IsBusyLoading = false;
            }

            while (IsBusyLoading)
            {
                if (ServiceLayer.VendorTypes != null)
                {
                    IsBusyLoading = false;

                    CurrentPage = new LoginView();

            loadBaseModelLookUps();
        }
    }
}

        private void loadBaseModelLookUps()
        {

            AdjustmentResults = new ObservableCollection<DTO_LU_AdjustmentResult>(ServiceLayer.AdjustmentResults);
            ServiceLayer.AdjustmentResults = null;
            AppointmentTypes = new ObservableCollection<DTO_LU_AppointmentTypes>(ServiceLayer.AppointmentTypes);
            ServiceLayer.AppointmentTypes = null;
            ClaimDocTypes = new ObservableCollection<DTO_LU_ClaimDocumentType>(ServiceLayer.ClaimDocTypes);
            ServiceLayer.ClaimDocTypes = null;
            DamageTypes = new ObservableCollection<DTO_LU_DamageTypes>(ServiceLayer.DamageTypes);
            ServiceLayer.DamageTypes = null;
            EmployeeTypes = new ObservableCollection<DTO_LU_EmployeeType>(ServiceLayer.EmployeeTypes);
            ServiceLayer.EmployeeTypes = null;
            InvoiceTypes = new ObservableCollection<DTO_LU_InvoiceType>(ServiceLayer.InvoiceTypes);
            ServiceLayer.InvoiceTypes = null;
            KnockResponseTypes = new ObservableCollection<DTO_LU_KnockResponseType>(ServiceLayer.KnockResponseTypes);
            ServiceLayer.KnockResponseTypes = null;
            LeadTypes = new ObservableCollection<DTO_LU_LeadType>(ServiceLayer.LeadTypes);
            ServiceLayer.LeadTypes = null;
            PayFrequencies = new ObservableCollection<DTO_LU_PayFrequncy>(ServiceLayer.PayFrequencies);
            ServiceLayer.PayFrequencies = null;
            PaymentDescriptions = new ObservableCollection<DTO_LU_PaymentDescription>(ServiceLayer.PaymentDescriptions);
            ServiceLayer.PaymentDescriptions = null;
            PaymentTypes = new ObservableCollection<DTO_LU_PaymentType>(ServiceLayer.PaymentTypes);
            ServiceLayer.PaymentTypes = null;
            PayTypes = new ObservableCollection<DTO_LU_PayType>(ServiceLayer.PayTypes);
            ServiceLayer.PayTypes = null;
            Permissions = new ObservableCollection<DTO_LU_Permissions>(ServiceLayer.Permissions);
            ServiceLayer.Permissions = null;
            PlaneTypes = new ObservableCollection<DTO_LU_PlaneTypes>(ServiceLayer.PlaneTypes);
            ServiceLayer.PlaneTypes = null;
            Products = new ObservableCollection<DTO_LU_Product>(ServiceLayer.Products);
            ServiceLayer.Products = null;
            ProductTypes = new ObservableCollection<DTO_LU_ProductType>(ServiceLayer.ProductTypes);
            ServiceLayer.ProductTypes = null;
            RidgeMaterialTypes = new ObservableCollection<DTO_LU_RidgeMaterialType>(ServiceLayer.RidgeMaterialTypes);
            ServiceLayer.RidgeMaterialTypes = null;
            ScopeTypes = new ObservableCollection<DTO_LU_ScopeType>(ServiceLayer.ScopeTypes);
            ServiceLayer.ScopeTypes = null;
            ServiceTypes = new ObservableCollection<DTO_LU_ServiceTypes>(ServiceLayer.ServiceTypes);
            ServiceLayer.ServiceTypes = null;
            ShingleTypes = new ObservableCollection<DTO_LU_ShingleType>(ServiceLayer.ShingleTypes);
            ServiceLayer.ShingleTypes = null;
            UnitsOfMeasure = new ObservableCollection<DTO_LU_UnitOfMeasure>(ServiceLayer.UnitsOfMeasure);
            ServiceLayer.UnitsOfMeasure = null;
            VendorTypes = new ObservableCollection<DTO_LU_VendorTypes>(ServiceLayer.VendorTypes);
            ServiceLayer.VendorTypes = null;
        }
    }
}
