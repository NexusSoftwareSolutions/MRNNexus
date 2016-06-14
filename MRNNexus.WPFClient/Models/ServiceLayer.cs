using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

using Newtonsoft.Json;
using MRNNexusDTOs;
using MRNNexus.WPFClient.Services;

namespace MRNNexus.WPFClient.Models
{
    internal partial class ServiceLayer
    {

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

        HttpClient httpClient = new HttpClient();



        private const string URL = @"http://services.mrncontracting.com/MRNNexus_Service.svc/";
        //private const string URL = @"http://localhost:50899/MRNNexus_Service.svc/";
        private HttpClient client = new HttpClient();


        public ServiceLayer()
        {
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 5, 0);
        }

        public async Task<string> MakeRequest(DTO_Base token, string methodName)
        {
            try
            {
                var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, methodName),
                    token);
                /// HttpRequestMessage msg = new HttpRequestMessage(new HttpMethod("POST"), new Uri(URL + methodName));
                /// msg.Content = new HttpStringContent(json);
                /// msg.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
                /// HttpResponseMessage response = await client.SendRequestAsync(msg).AsTask();
                /// response.EnsureSuccessStatusCode();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return await response.Content.ReadAsStringAsync();
                else
                {
                    return "Status Code: " + (int)response.StatusCode + "\nMethod: " + methodName + "\nReason: " + response.ReasonPhrase;

                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        async static public Task<string> buildLUs()
        {
            try {
                AdjustmentResults = JsonConvert.DeserializeObject<List<DTO_LU_AdjustmentResult>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetAdjustmentResults"));
                AppointmentTypes = JsonConvert.DeserializeObject<List<DTO_LU_AppointmentTypes>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetAppointmentTypes"));
                ClaimDocTypes = JsonConvert.DeserializeObject<List<DTO_LU_ClaimDocumentType>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetClaimDocumentTypes"));
                ClaimStatusTypes = JsonConvert.DeserializeObject<List<DTO_LU_ClaimStatusTypes>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetClaimStatusTypes"));
                DamageTypes = JsonConvert.DeserializeObject<List<DTO_LU_DamageTypes>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetDamageTypes"));
                EmployeeTypes = JsonConvert.DeserializeObject<List<DTO_LU_EmployeeType>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetEmployeeTypes"));
                InvoiceTypes = JsonConvert.DeserializeObject<List<DTO_LU_InvoiceType>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetInvoiceTypes"));
                KnockResponseTypes = JsonConvert.DeserializeObject<List<DTO_LU_KnockResponseType>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetKnockResponseTypes"));
                LeadTypes = JsonConvert.DeserializeObject<List<DTO_LU_LeadType>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetLeadTypes"));
                PayFrequencies = JsonConvert.DeserializeObject<List<DTO_LU_PayFrequncy>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetPayFrequencies"));
                PaymentDescriptions = JsonConvert.DeserializeObject<List<DTO_LU_PaymentDescription>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetPayDescriptions"));
                PaymentTypes = JsonConvert.DeserializeObject<List<DTO_LU_PaymentType>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetPaymentTypes"));
                PayTypes = JsonConvert.DeserializeObject<List<DTO_LU_PayType>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetPayTypes"));
                Permissions = JsonConvert.DeserializeObject<List<DTO_LU_Permissions>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetPermissions"));
                PlaneTypes = JsonConvert.DeserializeObject<List<DTO_LU_PlaneTypes>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetPlaneTypes"));
                Products = JsonConvert.DeserializeObject<List<DTO_LU_Product>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetProducts"));
                ProductTypes = JsonConvert.DeserializeObject<List<DTO_LU_ProductType>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetProductTypes"));
                RidgeMaterialTypes = JsonConvert.DeserializeObject<List<DTO_LU_RidgeMaterialType>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetRidgeMaterialTypes"));
                ScopeTypes = JsonConvert.DeserializeObject<List<DTO_LU_ScopeType>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetScopeTypes"));
                ServiceTypes = JsonConvert.DeserializeObject<List<DTO_LU_ServiceTypes>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetServiceTypes"));
                ShingleTypes = JsonConvert.DeserializeObject<List<DTO_LU_ShingleType>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetShingleTypes"));
                UnitsOfMeasure = JsonConvert.DeserializeObject<List<DTO_LU_UnitOfMeasure>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetUnitsOfMeasure"));
                VendorTypes = JsonConvert.DeserializeObject<List<DTO_LU_VendorTypes>>(await new ServiceLayer().MakeRequest(new DTO_Base(), "GetVendorTypes"));
                return null;
            }
            catch (Exception ex)
            {
                return "Error Loading Required Data. Please exit the progam and try again. If the problem persists please contact support.";
            }

        }

        public void setResults(string json, Type type, string methodName)
        {

            if(methodName == "Login")
            {
                LoggedInEmployee = JsonConvert.DeserializeObject<DTO_Employee>(json);
                return;
            }

            #region Single Objects
            if (type == typeof(DTO_Address))
			{
				Address = JsonConvert.DeserializeObject<DTO_Address>(json);
                return;
            }

            if (type == typeof(DTO_Claim))
            {
                Claim = JsonConvert.DeserializeObject<DTO_Claim>(json);
                return;
            }

            if (type == typeof(DTO_Customer))
            {
                Customer = JsonConvert.DeserializeObject<DTO_Customer>(json);
                return;
            }

            if (type == typeof(DTO_Employee))
            {
                Employee = JsonConvert.DeserializeObject<DTO_Employee>(json);
                return;
            }

            if (type == typeof(DTO_Inspection))
            {
                Inspection = JsonConvert.DeserializeObject<DTO_Inspection>(json);
                return;
            }


            if (type == typeof(DTO_Lead))
            {
                Lead = JsonConvert.DeserializeObject<DTO_Lead>(json);
                return;
            }
            #endregion

            #region Object Lists
			if (type == typeof(List<DTO_CalendarData>))
            {
                CalendarDataList = JsonConvert.DeserializeObject<List<DTO_CalendarData>>(json);
                return;
            }

            if (type == typeof(List<DTO_Claim>))
            {
                ClaimsList = JsonConvert.DeserializeObject<List<DTO_Claim>>(json);
                return;
            }

            if (type == typeof(List<DTO_Employee>))
            {
                EmployeesList = JsonConvert.DeserializeObject<List<DTO_Employee>>(json);
                return;
            }

            if (type == typeof(List<DTO_InsuranceCompany>))
            {
                InsuranceCompaniesList = JsonConvert.DeserializeObject<List<DTO_InsuranceCompany>>(json);
                return;
            }

            if (type == typeof(List<DTO_Lead>))
            {
                LeadsList = JsonConvert.DeserializeObject<List<DTO_Lead>>(json);
                return;
            }

            #endregion

            #region Lookup Lists

            if (type == typeof(List<DTO_LU_AdjustmentResult>))
            {
                AdjustmentResults = JsonConvert.DeserializeObject<List<DTO_LU_AdjustmentResult>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_AppointmentTypes>))
            {
                AppointmentTypes = JsonConvert.DeserializeObject<List<DTO_LU_AppointmentTypes>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_ClaimDocumentType>))
            {
                ClaimDocTypes = JsonConvert.DeserializeObject<List<DTO_LU_ClaimDocumentType>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_ClaimStatusTypes>))
            {
                ClaimStatusTypes = JsonConvert.DeserializeObject<List<DTO_LU_ClaimStatusTypes>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_DamageTypes>))
            {
                DamageTypes = JsonConvert.DeserializeObject<List<DTO_LU_DamageTypes>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_EmployeeType>))
            {
                EmployeeTypes = JsonConvert.DeserializeObject<List<DTO_LU_EmployeeType>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_InvoiceType>))
            {
                InvoiceTypes = JsonConvert.DeserializeObject<List<DTO_LU_InvoiceType>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_KnockResponseType>))
            {
                KnockResponseTypes = JsonConvert.DeserializeObject<List<DTO_LU_KnockResponseType>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_LeadType>))
            {
                LeadTypes = JsonConvert.DeserializeObject<List<DTO_LU_LeadType>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_PayFrequncy>))
            {
                PayFrequencies = JsonConvert.DeserializeObject<List<DTO_LU_PayFrequncy>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_PaymentDescription>))
            {
                PaymentDescriptions = JsonConvert.DeserializeObject<List<DTO_LU_PaymentDescription>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_PaymentType>))
            {
                PaymentTypes = JsonConvert.DeserializeObject<List<DTO_LU_PaymentType>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_PayType>))
            {
                PayTypes = JsonConvert.DeserializeObject<List<DTO_LU_PayType>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_Permissions>))
            {
                Permissions = JsonConvert.DeserializeObject<List<DTO_LU_Permissions>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_PlaneTypes>))
            {
                PlaneTypes = JsonConvert.DeserializeObject<List<DTO_LU_PlaneTypes>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_Product>))
            {
                Products = JsonConvert.DeserializeObject<List<DTO_LU_Product>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_ProductType>))
            {
                ProductTypes = JsonConvert.DeserializeObject<List<DTO_LU_ProductType>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_RidgeMaterialType>))
            {
                RidgeMaterialTypes = JsonConvert.DeserializeObject<List<DTO_LU_RidgeMaterialType>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_ScopeType>))
            {
                ScopeTypes = JsonConvert.DeserializeObject<List<DTO_LU_ScopeType>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_ServiceTypes>))
            {
                ServiceTypes = JsonConvert.DeserializeObject<List<DTO_LU_ServiceTypes>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_ShingleType>))
            {
                ShingleTypes = JsonConvert.DeserializeObject<List<DTO_LU_ShingleType>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_UnitOfMeasure>))
            {
                UnitsOfMeasure = JsonConvert.DeserializeObject<List<DTO_LU_UnitOfMeasure>>(json);
                return;
            }

            if (type == typeof(List<DTO_LU_VendorTypes>))
            {
                VendorTypes = JsonConvert.DeserializeObject<List<DTO_LU_VendorTypes>>(json);
                return;
            }

            #endregion


        }

        async public Task<string> Login(DTO_User token)
        {
            LoggedInEmployee = JsonConvert.DeserializeObject<DTO_Employee>(await MakeRequest(token, "Login"));
            return LoggedInEmployee.Message;
        }

        async public Task<string> GetUser(DTO_User token)
        {
            LoggedInUser = JsonConvert.DeserializeObject<DTO_User>(await MakeRequest(token, "GetUser"));
            return LoggedInUser.Message;
        }

        #region Add

        async public Task<string> AddAddress(DTO_Address token)
        {
            Address = JsonConvert.DeserializeObject<DTO_Address>(await MakeRequest(token, "AddAddress"));
            return Address.Message;
        }

        async public Task<string> AddAdjuster(DTO_Adjuster token)
        {
            Adjuster = JsonConvert.DeserializeObject<DTO_Adjuster>(await MakeRequest(token, "AddAdjuster"));
            return Adjuster.Message;
        }

        async public Task<string> AddClaim(DTO_Claim token)
        {
            Claim = JsonConvert.DeserializeObject<DTO_Claim>(await MakeRequest(token, "AddClaim"));
            return Claim.Message;
        }

        async public Task<string> AddCustomer(DTO_Customer token)
        {
            Customer = JsonConvert.DeserializeObject<DTO_Customer>(await MakeRequest(token, "AddCustomer"));
            return Customer.Message;
        }

        async public Task<string> AddCalendarData(DTO_CalendarData token)
        {
            CalendarData = JsonConvert.DeserializeObject<DTO_CalendarData>(await MakeRequest(token, "AddCalendarData"));
            return CalendarData.Message;
        }

        async public Task<string> AddInspection(DTO_Inspection token)
        {
            Inspection = JsonConvert.DeserializeObject<DTO_Inspection>(await MakeRequest(token, "AddInspection"));
            return Inspection.Message;
        }

        async public Task<string> AddKnockerResponse(DTO_KnockerResponse token)
        {
            KnockerResponse = JsonConvert.DeserializeObject<DTO_KnockerResponse>(await MakeRequest(token, "AddKnockerResponse"));
            return KnockerResponse.Message;
        }

        async public Task<string> AddLead(DTO_Lead token)
        {
            Lead = JsonConvert.DeserializeObject<DTO_Lead>(await MakeRequest(token, "AddLead"));
            return Lead.Message;
        }

        async public Task<string> AddReferrer(DTO_Referrer token)
        {
            Referrer = JsonConvert.DeserializeObject<DTO_Referrer>(await MakeRequest(token, "AddReferrer"));
            return Referrer.Message;
        }

        #endregion

        #region Get
        async public Task<string> GetAddressByID(DTO_Address token)
        {
            Address = JsonConvert.DeserializeObject<DTO_Address>(await MakeRequest(token, "GetAddressByID"));
            return Address.Message;
        }

        async public Task<string> GetCustomerByID(DTO_Customer token)
        {
            Customer = JsonConvert.DeserializeObject<DTO_Customer>(await MakeRequest(token, "GetCustomerByID"));
            return Customer.Message;
        }

        async public Task<string> GetEmployeeByID(DTO_Employee token)
        {
            Employee = JsonConvert.DeserializeObject<DTO_Employee>(await MakeRequest(token, "GetEmployeeByID"));
            return Employee.Message;
        }

        async public Task<string> GetKnockerResponseByID(DTO_KnockerResponse token)
        {
            KnockerResponse = JsonConvert.DeserializeObject<DTO_KnockerResponse>(await MakeRequest(token, "GetKnockerResponseByID"));
            return KnockerResponse.Message;
        }

        async public Task<string> GetLeadByLeadID(DTO_Lead token)
        {
            Lead = JsonConvert.DeserializeObject<DTO_Lead>(await MakeRequest(token, "GetLeadByLeadID"));
            return Lead.Message;
        }

        async public Task<string> GetReferrerByID(DTO_Referrer token)
        {
            Referrer = JsonConvert.DeserializeObject<DTO_Referrer>(await MakeRequest(token, "GetReferrerByID"));
            return Referrer.Message;
        }

        #region Get All

        async public Task<string> GetAllAddresses()
        {
            AddressesList = JsonConvert.DeserializeObject<List<DTO_Address>>(await MakeRequest(new DTO_Base(), "GetAllAddresses"));
            return AddressesList.Last().Message;
        }

        async public Task<string> GetAllAdjusters()
        {
            AdjustersList = JsonConvert.DeserializeObject<List<DTO_Adjuster>>(await MakeRequest(new DTO_Base(), "GetAllAdjusters"));
            return AdjustersList.Last().Message;
        }

        async public Task<string> GetAllClaims()
        {
            ClaimsList = JsonConvert.DeserializeObject<List<DTO_Claim>>(await MakeRequest(new DTO_Base(), "GetAllClaims"));
            return ClaimsList.Last().Message;
        }

        async public Task<string> GetAllCustomers()
        {
            CustomersList = JsonConvert.DeserializeObject<List<DTO_Customer>>(await MakeRequest(new DTO_Base(), "GetAllCustomers"));
            return CustomersList.Last().Message;
        }

        async public Task<string> GetAllInsuranceCompanyNames()
        {
            InsuranceCompaniesList = JsonConvert.DeserializeObject<List<DTO_InsuranceCompany>>(await MakeRequest(new DTO_Base(), "GetAllInsuranceCompanyNames"));
            return InsuranceCompaniesList.Last().Message;
        }

        async public Task<string> GetAllLeads()
        {
            LeadsList = JsonConvert.DeserializeObject<List<DTO_Lead>>(await MakeRequest(new DTO_Base(), "GetAllLeads"));
            return LeadsList.Last().Message;
        }

        #endregion Get ALL


        #region Lists
        async public Task<string> GetCalendarDataByEmployeeID(DTO_Employee token)
        {
            CalendarDataList = JsonConvert.DeserializeObject<List<DTO_CalendarData>>(await MakeRequest(token, "GetCalendarDataByEmployeeID"));
            return CalendarDataList.Last().Message;
        }

        async public Task<string> GetEmployeesByEmployeeTypeID(DTO_LU_EmployeeType token)
        {
            EmployeesList = JsonConvert.DeserializeObject<List<DTO_Employee>>(await MakeRequest(token, "GetEmployeesByEmployeeTypeID"));
            return EmployeesList.Last().Message;
        }

        async public Task<string> GetInspectionsByClaimID(DTO_Claim token)
        {
            InspectionsList = JsonConvert.DeserializeObject<List<DTO_Inspection>>(await MakeRequest(token, "GetInspectionsByClaimID"));
            return InspectionsList.Last().Message;
        }

        async public Task<string> GetLeadsBySalesPersonID(DTO_Employee token)
        {
            LeadsList = JsonConvert.DeserializeObject<List<DTO_Lead>>(await MakeRequest(token, "GetLeadsBySalesPersonID"));
            return LeadsList.Last().Message;
        }

        async public Task<string> GetOpenClaimsBySalesPersonID(DTO_Employee token)
        {
            ClaimsList = JsonConvert.DeserializeObject<List<DTO_Claim>>(await MakeRequest(token, "GetOpenClaimsBySalesPersonID"));
            return ClaimsList.Last().Message;
        }
        #endregion Lists

        #endregion Get

        #region Update
        async public Task<string> UpdateAddress(DTO_Address token)
        {
            Address = JsonConvert.DeserializeObject<DTO_Address>(await MakeRequest(token, "UpdateAddress"));
            return Address.Message;
        }

        async public Task<string> UpdateAdjuster(DTO_Adjuster token)
        {
            Adjuster = JsonConvert.DeserializeObject<DTO_Adjuster>(await MakeRequest(token, "UpdateAdjuster"));
            return Adjuster.Message;
        }

        async public Task<string> UpdateCalendarData(DTO_CalendarData token)
        {
            CalendarData = JsonConvert.DeserializeObject<DTO_CalendarData>(await MakeRequest(token, "UpdateCalendarData"));
            return CalendarData.Message;
        }

        async public Task<string> UpdateClaim(DTO_Claim token)
        {
            Claim = JsonConvert.DeserializeObject<DTO_Claim>(await MakeRequest(token, "UpdateClaim"));
            return Claim.Message;
        }

        async public Task<string> UpdateCustomer(DTO_Customer token)
        {
            Customer = JsonConvert.DeserializeObject<DTO_Customer>(await MakeRequest(token, "UpdateCustomer"));
            return Customer.Message;
        }

        async public Task<string> UpdateInspection(DTO_Inspection token)
        {
            Inspection = JsonConvert.DeserializeObject<DTO_Inspection>(await MakeRequest(token, "UpdateInspection"));
            return Inspection.Message;
        }

        async public Task<string> UpdateLead(DTO_Lead token)
        {
            Lead = JsonConvert.DeserializeObject<DTO_Lead>(await MakeRequest(token, "UpdateLead"));
            return Lead.Message;
        }
        #endregion

    }
}

