
using MRNNexus.WPFClient.Models;
using MRNNexus.WPFClient.Services;
using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MRNNexus.WPFClient.ViewModels
{
    internal class BaseViewModel : INotifyPropertyChanged
    {        

        public static int HeaderFontSize { get { return 24; } }
        public static string Header { get; set; }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region StaticPropertyChanged
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        public static void RaiseStaticPropertyChanged(string propertyName)
        {
            EventHandler<PropertyChangedEventArgs> handler = StaticPropertyChanged;
            if (handler != null)
            {
                handler(null, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region ErrorMessages
        protected static IMessageBoxService messageService = new MessageBoxService();

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                if (_errorMessage != null)
                {
                    messageService.ShowError(_errorMessage);
                    _errorMessage = null;
                }
            }
        }
        #endregion

        #region Commands

        #region Menu Commands
        public static ICommand AddLead
        {
            get { return new RelayCommand(new Action<object>(addLead)); }
        }
        public static ICommand EditLead
        {
            get { return new RelayCommand(new Action<object>(editLead)); }
        }
        //public static ICommand ViewLeads
        //{
        //    get { return new RelayCommand(new Action<object>(viewLeads)); }
        //}
        public static ICommand ViewSchedule
        {
            get { return new RelayCommand(new Action<object>(viewSchedule)); }
        }
        public static ICommand AddInspection
        {
            get { return new RelayCommand(new Action<object>(addInspection)); }
        }
        public static ICommand EditInspection
        {
            get { return new RelayCommand(new Action<object>(editInspection)); }
        }
        //public static ICommand ViewInspections
        //{
        //    get { return new RelayCommand(new Action<object>(viewInspections)); }
        //}
        public static ICommand AddAdjuster
        {
            get { return new RelayCommand(new Action<object>(addAdjuster)); }
        }
        public static ICommand EditAdjuster
        {
            get { return new RelayCommand(new Action<object>(editAdjuster)); }
        }
        public static ICommand AddAdjustment
        {
            get { return new RelayCommand(new Action<object>(addAdjustment)); }
        }
        //public static ICommand EditAdjustment
        //{
        //    get { return new RelayCommand(new Action<object>(editAdjustment)); }
        //}
        //public static ICommand ViewAdjustments
        //{
        //    get { return new RelayCommand(new Action<object>(viewAdjustments)); }
        //}
        public static ICommand AddInvoice
        {
            get { return new RelayCommand(new Action<object>(addInvoice)); }
        }
        //public static ICommand EditInvoice
        //{
        //    get { return new RelayCommand(new Action<object>(editInvoice)); }
        //}
        //public static ICommand ViewInvoices
        //{
        //    get { return new RelayCommand(new Action<object>(viewInvoices)); }
        //}

        #endregion

        public ICommand LeadTemperatureSelected
        {
            get { return new RelayCommand(new Action<object>(setLeadTemperature)); }
        }


        #endregion

        #region Command Methods

        #region Menu Commands
        private static void addLead(object o)
        {
            Header = "Add Lead";
            LeadView leadView = new LeadView();
            leadView.SizeToContent = SizeToContent.WidthAndHeight;
            leadView.WindowStyle = WindowStyle.ThreeDBorderWindow;
            leadView.ResizeMode = ResizeMode.NoResize;
            leadView.ShowDialog();
        }
        private static void editLead(object o)
        {
            AccountSelectView accountSelectWindow = new AccountSelectView(2);
            accountSelectWindow.ShowDialog();
            Header = "Edit Lead";
            LeadView leadView = new LeadView();
            leadView.SizeToContent = SizeToContent.WidthAndHeight;
            leadView.WindowStyle = WindowStyle.ThreeDBorderWindow;
            leadView.ResizeMode = ResizeMode.NoResize;
            leadView.ShowDialog();
        }
        private static void addInspection(object o)
        {
            Header = "Add Inspection";
            Claim = null;
            Customer = null;
            Lead = null;
            Inspection = null;
            PropertyAddress = null;
            BillingAddress = null;
            IsExistingAddress = false;
            IsExistingCustomer = false;
            CurrentPage = new InspectionView();
                
        }
        private static void editInspection(object o)
        {
            AccountSelectView accountSelectWindow = new AccountSelectView();
            Header = "Edit Inspection";
            accountSelectWindow.ShowDialog();
            CurrentPage = new InspectionView();
        }
        private static void addAdjuster(object o)
        {
            Header = "Add Adjuster";
            AdjusterFormView view = new AdjusterFormView();
            view.SizeToContent = SizeToContent.WidthAndHeight;
            view.WindowStyle = WindowStyle.ThreeDBorderWindow;
            view.ResizeMode = ResizeMode.NoResize;
            view.ShowDialog();

        }
        private static void editAdjuster(object o)
        {
            if(Adjuster == null)
            {
                AccountSelectView accountSelectWindow = new AccountSelectView(6);
                accountSelectWindow.ShowDialog();
            }
            Header = "Edit Adjuster";
            AdjusterFormView view = new AdjusterFormView();
            view.SizeToContent = SizeToContent.WidthAndHeight;
            view.WindowStyle = WindowStyle.ThreeDBorderWindow;
            view.ResizeMode = ResizeMode.NoResize;
            view.ShowDialog();

        }
        private static void addAdjustment(object o)
        {
            Header = "Add Adjustment";

            Adjuster = null;
            if (Claim != null && !Claim.MRNClaimNumber.Contains("-"))
            {
                Claim = null;
            }

            AdjustmentFormView view = new AdjustmentFormView();
            view.SizeToContent = SizeToContent.WidthAndHeight;
            view.WindowStyle = WindowStyle.ThreeDBorderWindow;
            view.ResizeMode = ResizeMode.NoResize;
            view.ShowDialog();
            //IWindowService ws = new WindowService();
            //ws.showWindow(new AdjustmentFormView());
        }
        private static void editAdjustment(object o)
        {
            Header = "Edit Adjustment";

            if (Claim != null && !Claim.MRNClaimNumber.Contains("-"))
            {
                Claim = null;
            }

            AdjustmentFormView view = new AdjustmentFormView();
            view.SizeToContent = SizeToContent.WidthAndHeight;
            view.WindowStyle = WindowStyle.ThreeDBorderWindow;
            view.ResizeMode = ResizeMode.NoResize;
            view.ShowDialog();
            //IWindowService ws = new WindowService();
            //ws.showWindow(new AdjustmentFormView());
        }

        private static void addInvoice(object o)
        {
            Header = "Add Invoice";
            IWindowService ws = new WindowService();
            ws.showWindow(new AdjustmentFormView());
        }
        private static void viewSchedule(object o)
        {
            CurrentPage = new ScheduleView();
        }
            #endregion

        private void setLeadTemperature(object o) // WHY IS THIS HERE???
        {
            if (o as string == "C")
            {
                Lead.Temperature = "C";
            }
            else if (o as string == "W")
            {
                Lead.Temperature = "W";
            }
            else Lead.Temperature = "H";
        }

        #endregion

        #region MainWindow Fields and Prooperties
        private static Page _currentPage;
        private static bool _menuBarIsEnabled = false;
        private bool _isBusyLoading = true;

        public static Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                RaiseStaticPropertyChanged("CurrentPage");
            }
        }
        public static bool MenuBarIsEnabled
        {
            get { return _menuBarIsEnabled; }
            set
            {
                _menuBarIsEnabled = value;
                RaiseStaticPropertyChanged("MenuBarIsEnabled");
            }
        }
        public bool IsBusyLoading
        {
            get { return _isBusyLoading; }
            set
            {
                _isBusyLoading = value;
                RaisePropertyChanged("IsBusyLoading");
            }
        }
        #endregion  

        private static bool _isExistingCustomer = false;
        public static bool IsExistingCustomer
        {
            get { return _isExistingCustomer; }
            set
            {
                if (_isExistingCustomer != value)
                {
                    _isExistingCustomer = value;
                    RaiseStaticPropertyChanged("IsExistingCustomer");
                    if (_isExistingCustomer && (Customer == null || Customer.CustomerID <= 0))
                        new AccountSelectView(3).ShowDialog();
                    else if(!_isExistingCustomer && Customer != null)
                    {
                        Customer = null;
                    }
                }
            }
        }

        private static bool _isExistingAddress = false;
        public static bool IsExistingAddress
        {
            get { return _isExistingAddress; }
            set
            {
                if (_isExistingAddress != value)
                {
                    _isExistingAddress = value;
                    RaiseStaticPropertyChanged("IsExistingAddress");
                    if (_isExistingAddress && (PropertyAddress == null ||PropertyAddress.AddressID <= 0))
                        new AccountSelectView(4).ShowDialog();
                    else if (!_isExistingAddress && PropertyAddress != null)
                    {
                        PropertyAddress = null;
                    }
                }
            }
        }

        private static bool _isExistingAddressB = false;
        public static bool IsExistingAddressB
        {
            get { return _isExistingAddressB; }
            set
            {
                if (_isExistingAddressB != value)
                {
                    _isExistingAddressB = value;
                    RaiseStaticPropertyChanged("IsExistingAddress");
                    if (_isExistingAddressB)
                        new AccountSelectView(5).ShowDialog();
                }
            }
        }

        #region Static Fields
        private static Employee _loggedInEmployee;
        private static User _loggedInUser;

        #region Single Objects
        private static Adjuster _adjuster;
        private static Adjustment _adjustment;
        private static Address _billingAddress;
        private static Claim _claim;
        private static ClaimStatus _claimStatus;
        private static Customer _customer;
        private static Employee _employee;
        private static Inspection _inspection;
        private static KnockerResponse _knockerResponse;
        private static Lead _lead;
        private static Address _propertyAddress;
        private static Referrer _referrer;
        #endregion

        #region Single Object Lists
        private static ObservableCollection<Address> _addresses;
        private static ObservableCollection<Adjuster> _adjusters;
        private static ObservableCollection<Adjustment> _adjustments;
        private static ObservableCollection<Claim> _claims;
        private static ObservableCollection<Customer> _customers;
        private static ObservableCollection<Employee> _employees;
        private static ObservableCollection<Inspection> _inspections;
        private static ObservableCollection<Lead> _leads;
        #endregion

        #region Lookup Lists
        private static ObservableCollection<DTO_LU_AdjustmentResult> _adjustmentResults;
        private static ObservableCollection<DTO_LU_AppointmentTypes> _appointmentTypes;
        private static ObservableCollection<DTO_LU_ClaimDocumentType> _claimDocTypes;
        private static ObservableCollection<DTO_LU_ClaimStatusTypes> _claimStatusTypes;
        private static ObservableCollection<DTO_LU_DamageTypes> _damageTypes;
        private static ObservableCollection<DTO_LU_EmployeeType> _employeeTypes;
        private static ObservableCollection<DTO_LU_InvoiceType> _invoiceTypes;
        private static ObservableCollection<DTO_LU_KnockResponseType> _knockResponseTypes;
        private static ObservableCollection<DTO_LU_LeadType> _leadTypes;
        private static ObservableCollection<DTO_LU_PayFrequncy> _payFrequencies;
        private static ObservableCollection<DTO_LU_PaymentDescription> _paymentDescriptions;
        private static ObservableCollection<DTO_LU_PaymentType> _paymentTypes;
        private static ObservableCollection<DTO_LU_PayType> _payTypes;
        private static ObservableCollection<DTO_LU_Permissions> _permissions;
        private static ObservableCollection<DTO_LU_PlaneTypes> _planeTypes;
        private static ObservableCollection<DTO_LU_Product> _products;
        private static ObservableCollection<DTO_LU_ProductType> _productTypes;
        private static ObservableCollection<DTO_LU_RidgeMaterialType> _ridgeMaterialTypes;
        private static ObservableCollection<DTO_LU_ScopeType> _scopeTypes;
        private static ObservableCollection<DTO_LU_ServiceTypes> _serviceTypes;
        private static ObservableCollection<DTO_LU_ShingleType> _shingleTypes;
        private static ObservableCollection<DTO_LU_UnitOfMeasure> _unitsOfMeasure;
        private static ObservableCollection<DTO_LU_VendorTypes> _vendorTypes;
        #endregion

        #endregion Fields

        #region Static Properties

        /// Single Objects
        public static Employee LoggedInEmployee
        {
            get { return _loggedInEmployee; }
            set
            {
                _loggedInEmployee = value;
                RaiseStaticPropertyChanged("LoggedInEmployee");
            }
        }
        public static User LoggedInUser
        {
            get { return _loggedInUser; }
            set
            {
                _loggedInUser = value;
                RaiseStaticPropertyChanged("LoggedInUser");
            }
        }
        //public static CalculatedResults CalculatedResults { get; set; }

        //public static AdditionalSupply AdditionalSupply { get; set; }
        public static Address PropertyAddress {
            get { return _propertyAddress; }
            set
            {
                _propertyAddress = value;
                RaiseStaticPropertyChanged("PropertyAddress");
            }
        }
        public static Address BillingAddress {
            get { return _billingAddress; }
            set
            {
                _billingAddress = value;
                RaiseStaticPropertyChanged("BillingAddress");
            }
        }
        public static Adjuster Adjuster {
            get { return _adjuster; }
            set
            {
                _adjuster = value;
                RaiseStaticPropertyChanged("Adjuster");
            }
        }
        public static Adjustment Adjustment {
            get { return _adjustment; }
            set
            {
                _adjustment = value;
                RaiseStaticPropertyChanged("Adjustment");
            }
        }
        //public static CalendarData CalendarData { get; set; }
        //public static CallLog CallLog { get; set; }
        public static Claim Claim
        {
            get { return _claim; }
            set
            {
                _claim = value;
                RaiseStaticPropertyChanged("Claim");
            }
        }
        //public static ClaimContacts ClaimContacts { get; set; }
        //public static ClaimDocument ClaimDocument { get; set; }
        public static ClaimStatus ClaimStatus {
            get { return _claimStatus; }
            set
            {
                _claimStatus = value;
                RaiseStaticPropertyChanged("ClaimStatus");
            }
        }
        //public static ClaimVendor ClaimVendor { get; set; }
        public static Customer Customer {
            get { return _customer; }
            set
            {
                _customer = value;
                RaiseStaticPropertyChanged("Customer");
            }
        }
        //public static Damage Damage { get; set; }
        public static Employee Employee {
            get { return _employee; }
            set
            {
                _employee = value;
                RaiseStaticPropertyChanged("Employee");
            }
        }
        public static Inspection Inspection {
            get { return _inspection; }
            set
            {
                _inspection = value;
                RaiseStaticPropertyChanged("Inspection");
            }
        }
        //public static InsuranceCompany InsuranceCompany { get; set; }
        //public static Invoice Invoice { get; set; }
        public static KnockerResponse KnockerResponse
        {
            get { return _knockerResponse; }
            set
            {
                _knockerResponse = value;
                RaiseStaticPropertyChanged("KnockerResponse");
            }
        }
        public static Lead Lead {
            get { return _lead; }
            set
            {
                _lead = value;
                RaiseStaticPropertyChanged("Lead");
            }
        }
        //public static NewRoof NewRoof { get; set; }
        //public static Order Order { get; set; }
        //public static OrderItem OrderItem { get; set; }
        //public static Payment Payment { get; set; }
        //public static Plane Plane { get; set; }
        public static Referrer Referrer
        {
            get { return _referrer; }
            set
            {
                _referrer = value;
                RaiseStaticPropertyChanged("Referrer");
            }
        }
        //public static Scope Scope { get; set; }
        //public static SurplusSupplies SurplusSupplies { get; set; }
        //public static User User { get; set; }
        //public static Vendor Vendor { get; set; }

        /// Non LU Lists
        //public static List<AdditionalSupply> AdditionalSuppliesList { get; set; }
        public static ObservableCollection<Address> Addresses {
            get { return _addresses; }
            set
            {
                _addresses = value;
                RaiseStaticPropertyChanged("Lead");
            }
        }
        public static ObservableCollection<Adjuster> Adjusters {
            get { return _adjusters; }
            set
            {
                _adjusters = value;
                RaiseStaticPropertyChanged("Adjusters");
            }
        }
        public static ObservableCollection<Adjustment> Adjustments
        {
            get { return _adjustments; }
            set
            {
                _adjustments = value;
                RaiseStaticPropertyChanged("Adjustments");
            }
        }
        //public static List<CalendarData> CalendarDataList { get; set; }
        //public static List<CallLog> CallLogsList { get; set; }
        public static ObservableCollection<Claim> Claims {
            get { return _claims; }
            set
            {
                _claims = value;
                RaiseStaticPropertyChanged("Claims");
            }
        }
        //public static List<ClaimContacts> ClaimContactsList { get; set; }
        //public static List<ClaimDocument> ClaimDocumentsList { get; set; }
        //public static List<ClaimStatus> ClaimStatusList { get; set; }
        //public static List<ClaimVendor> ClaimVendorsList { get; set; }
        public static ObservableCollection<Customer> Customers {
            get { return _customers; }
            set
            {
                _customers = value;
                RaiseStaticPropertyChanged("Customers");
            }
        }
        //public static List<Damage> DamagesList { get; set; }
        public static ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                RaiseStaticPropertyChanged("Employees");
            }
        }
        public static ObservableCollection<Inspection> Inspections {
            get { return _inspections; }
            set
            {
                _inspections = value;
                RaiseStaticPropertyChanged("Inspections");
            }
        }
        //public static List<InsuranceCompany> InsuranceCompaniesList { get; set; }
        //public static List<Invoice> InvoicesList { get; set; }
        //public static List<KnockerResponse> KnockerResponsesList { get; set; }
        public static ObservableCollection<Lead> Leads {
            get { return _leads; }
            set
            {
                _leads = value;
                RaiseStaticPropertyChanged("Leads");
            }
        }
        //public static List<NewRoof> NewRoofsList { get; set; }
        //public static List<Order> OrdersList { get; set; }
        //public static List<OrderItem> OrderItemsList { get; set; }
        //public static List<Payment> PaymentsList { get; set; }
        //public static List<Plane> PlanesList { get; set; }
        //public static List<Referrer> ReferrersList { get; set; }
        //public static List<Scope> ScopesList { get; set; }
        //public static List<SurplusSupplies> SurplusSuppliesList { get; set; }
        //public static List<User> UsersList { get; set; }
        //public static List<Vendor> VendorsList { get; set; }

        #region Lookup Lists
        public static ObservableCollection<DTO_LU_AdjustmentResult> AdjustmentResults
        {
            get { return _adjustmentResults; }
            set
            {
                _adjustmentResults = value;
                RaiseStaticPropertyChanged("AdjustmentResults");
            }
        }
        public static ObservableCollection<DTO_LU_AppointmentTypes> AppointmentTypes {
            get { return _appointmentTypes; }
            set
            {
                _appointmentTypes = value;
                RaiseStaticPropertyChanged("AppointmentTypes");
            }
        }
        public static ObservableCollection<DTO_LU_ClaimDocumentType> ClaimDocTypes {
            get { return _claimDocTypes; }
            set
            {
                _claimDocTypes = value;
                RaiseStaticPropertyChanged("ClaimDocTypes");
            }
        }
        public static ObservableCollection<DTO_LU_ClaimStatusTypes> ClaimStatusTypes {
            get { return _claimStatusTypes; }
            set
            {
                _claimStatusTypes = value;
                RaiseStaticPropertyChanged("ClaimStatusTypes");
            }
        }
        public static ObservableCollection<DTO_LU_DamageTypes> DamageTypes {
            get { return _damageTypes; }
            set
            {
                _damageTypes = value;
                RaiseStaticPropertyChanged("DamageTypes");
            }
        }
        public static ObservableCollection<DTO_LU_EmployeeType> EmployeeTypes {
            get { return _employeeTypes; }
            set
            {
                _employeeTypes = value;
                RaiseStaticPropertyChanged("EmployeeTypes");
            }
        }
        public static ObservableCollection<DTO_LU_InvoiceType> InvoiceTypes {
            get { return _invoiceTypes; }
            set
            {
                _invoiceTypes = value;
                RaiseStaticPropertyChanged("InvoiceTypes");
            }
        }
        public static ObservableCollection<DTO_LU_KnockResponseType> KnockResponseTypes {
            get { return _knockResponseTypes; }
            set
            {
                _knockResponseTypes = value;
                RaiseStaticPropertyChanged("KnockResponseTypes");
            }
        }
        public static ObservableCollection<DTO_LU_LeadType> LeadTypes {
            get { return _leadTypes; }
            set
            {
                _leadTypes = value;
                RaiseStaticPropertyChanged("LeadTypes");
            }
        }
        public static ObservableCollection<DTO_LU_PayFrequncy> PayFrequencies {
            get { return _payFrequencies; }
            set
            {
                _payFrequencies = value;
                RaiseStaticPropertyChanged("PayFrequencies");
            }
        }
        public static ObservableCollection<DTO_LU_PaymentDescription> PaymentDescriptions {
            get { return _paymentDescriptions; }
            set
            {
                _paymentDescriptions = value;
                RaiseStaticPropertyChanged("PaymentDescriptions");
            }
        }
        public static ObservableCollection<DTO_LU_PaymentType> PaymentTypes {
            get { return _paymentTypes; }
            set
            {
                _paymentTypes = value;
                RaiseStaticPropertyChanged("PaymentTypes");
            }
        }
        public static ObservableCollection<DTO_LU_PayType> PayTypes {
            get { return _payTypes; }
            set
            {
                _payTypes = value;
                RaiseStaticPropertyChanged("PayTypes");
            }
        }
        public static ObservableCollection<DTO_LU_Permissions> Permissions {
            get { return _permissions; }
            set
            {
                _permissions = value;
                RaiseStaticPropertyChanged("Permissions");
            }
        }
        public static ObservableCollection<DTO_LU_PlaneTypes> PlaneTypes {
            get { return _planeTypes; }
            set
            {
                _planeTypes = value;
                RaiseStaticPropertyChanged("PlaneTypes");
            }
        }
        public static ObservableCollection<DTO_LU_Product> Products {
            get { return _products; }
            set
            {
                _products = value;
                RaiseStaticPropertyChanged("Products");
            }
        }
        public static ObservableCollection<DTO_LU_ProductType> ProductTypes {
            get { return _productTypes; }
            set
            {
                _productTypes = value;
                RaiseStaticPropertyChanged("ProductTypes");
            }
        }
        public static ObservableCollection<DTO_LU_RidgeMaterialType> RidgeMaterialTypes {
            get { return _ridgeMaterialTypes; }
            set
            {
                _ridgeMaterialTypes = value;
                RaiseStaticPropertyChanged("RidgeMaterialTypes");
            }
        }
        public static ObservableCollection<DTO_LU_ScopeType> ScopeTypes {
            get { return _scopeTypes; }
            set
            {
                _scopeTypes = value;
                RaiseStaticPropertyChanged("ScopeTypes");
            }
        }
        public static ObservableCollection<DTO_LU_ServiceTypes> ServiceTypes {
            get { return _serviceTypes; }
            set
            {
                _serviceTypes = value;
                RaiseStaticPropertyChanged("ServiceTypes");
            }
        }
        public static ObservableCollection<DTO_LU_ShingleType> ShingleTypes {
            get { return _shingleTypes; }
            set
            {
                _shingleTypes = value;
                RaiseStaticPropertyChanged("ShingleTypes");
            }
        }
        public static ObservableCollection<DTO_LU_UnitOfMeasure> UnitsOfMeasure {
            get { return _unitsOfMeasure; }
            set
            {
                _unitsOfMeasure = value;
                RaiseStaticPropertyChanged("UnitsOfMeasure");
            }
        }
        public static ObservableCollection<DTO_LU_VendorTypes> VendorTypes {
            get { return _vendorTypes; }
            set
            {
                _vendorTypes = value;
                RaiseStaticPropertyChanged("VendorTypes");
            }
        }
        #endregion
        #endregion
    }
}
