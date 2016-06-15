using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MRNNexusDTOs;

namespace MRNNexus.WPFClient.Models
{
    internal partial class ServiceLayer
    {
        public static double SumOfInvoices { get; set; }
        public static double SumOfPayments { get; set; }
        //Single Objects
        public static DTO_Employee LoggedInEmployee { get; set; }
        public static DTO_User LoggedInUser { get; set; }
        public static DTO_CalculatedResults CalculatedResults { get; set; }

        public static DTO_AdditionalSupply AdditionalSupply { get; set; }
        public static DTO_Address Address { get; set; }
        public static DTO_Address Address1 { get; set; }
        public static DTO_Address Address2 { get; set; }
        public static DTO_Adjuster Adjuster { get; set; }
        public static DTO_Adjustment Adjustment { get; set; }
        public static DTO_CalendarData CalendarData { get; set; }
        public static DTO_CallLog CallLog { get; set; }
        public static DTO_Claim Claim { get; set; }
        public static DTO_ClaimContacts ClaimContacts { get; set; }
        public static DTO_ClaimDocument ClaimDocument { get; set; }
        public static DTO_ClaimStatus ClaimStatus { get; set; }
        public static DTO_ClaimVendor ClaimVendor { get; set; }
        public static DTO_Customer Customer { get; set; }
        public static DTO_Damage Damage { get; set; }
        public static DTO_Employee Employee { get; set; }
        public static DTO_Inspection Inspection { get; set; }
        public static DTO_InsuranceCompany InsuranceCompany { get; set; }
        public static DTO_Invoice Invoice { get; set; }
        public static DTO_KnockerResponse KnockerResponse { get; set; }
        public static DTO_Lead Lead { get; set; }
        public static DTO_NewRoof NewRoof { get; set; }
        public static DTO_Order Order { get; set; }
        public static DTO_OrderItem OrderItem { get; set; }
        public static DTO_Payment Payment { get; set; }
        public static DTO_Plane Plane { get; set; }
        public static DTO_Referrer Referrer { get; set; }
        public static DTO_Scope Scope { get; set; }
        public static DTO_SurplusSupplies SurplusSupplies { get; set; }
        public static DTO_User User { get; set; }
        public static DTO_Vendor Vendor { get; set; }




        //Non LU Lists
        public static List<DTO_AdditionalSupply> AdditionalSuppliesList { get; set; }
        public static List<DTO_Address> AddressesList { get; set; }
        public static List<DTO_Adjuster> AdjustersList { get; set; }
        public static List<DTO_Adjustment> AdjustmentsList { get; set; }
        public static List<DTO_CalendarData> CalendarDataList { get; set; }
        public static List<DTO_CallLog> CallLogsList { get; set; }
        public static List<DTO_Claim> ClaimsList { get; set; }
        public static List<DTO_ClaimContacts> ClaimContactsList { get; set; }
        public static List<DTO_ClaimDocument> ClaimDocumentsList { get; set; }
        public static List<DTO_ClaimStatus> ClaimStatusList { get; set; }
        public static List<DTO_ClaimVendor> ClaimVendorsList { get; set; }
        public static List<DTO_Customer> CustomersList { get; set; }
        public static List<DTO_Damage> DamagesList { get; set; }
        public static List<DTO_Employee> EmployeesList { get; set; }
        public static List<DTO_Inspection> InspectionsList { get; set; }
        public static List<DTO_InsuranceCompany> InsuranceCompaniesList { get; set; }
        public static List<DTO_Invoice> InvoicesList { get; set; }
        public static List<DTO_KnockerResponse> KnockerResponsesList { get; set; }
        public static List<DTO_Lead> LeadsList { get; set; }
        public static List<DTO_NewRoof> NewRoofsList { get; set; }
        public static List<DTO_Order> OrdersList { get; set; }
        public static List<DTO_OrderItem> OrderItemsList { get; set; }
        public static List<DTO_Payment> PaymentsList { get; set; }
        public static List<DTO_Plane> PlanesList { get; set; }
        public static List<DTO_Referrer> ReferrersList { get; set; }
        public static List<DTO_Scope> ScopesList { get; set; }
        public static List<DTO_SurplusSupplies> SurplusSuppliesList { get; set; }
        public static List<DTO_User> UsersList { get; set; }
        public static List<DTO_Vendor> VendorsList { get; set; }


        //LU Lists
        public static List<DTO_LU_AdjustmentResult> AdjustmentResults { get; set; }
        public static List<DTO_LU_AppointmentTypes> AppointmentTypes { get; set; }
        public static List<DTO_LU_ClaimDocumentType> ClaimDocTypes { get; set; }
        public static List<DTO_LU_ClaimStatusTypes> ClaimStatusTypes { get; set; }
        public static List<DTO_LU_DamageTypes> DamageTypes { get; set; }
        public static List<DTO_LU_EmployeeType> EmployeeTypes { get; set; }
        public static List<DTO_LU_InvoiceType> InvoiceTypes { get; set; }
        public static List<DTO_LU_KnockResponseType> KnockResponseTypes { get; set; }
        public static List<DTO_LU_LeadType> LeadTypes { get; set; }
        public static List<DTO_LU_PayFrequncy> PayFrequencies { get; set; }
        public static List<DTO_LU_PaymentDescription> PaymentDescriptions { get; set; }
        public static List<DTO_LU_PaymentType> PaymentTypes { get; set; }
        public static List<DTO_LU_PayType> PayTypes { get; set; }
        public static List<DTO_LU_Permissions> Permissions { get; set; }
        public static List<DTO_LU_PlaneTypes> PlaneTypes { get; set; }
        public static List<DTO_LU_Product> Products { get; set; }
        public static List<DTO_LU_ProductType> ProductTypes { get; set; }
        public static List<DTO_LU_RidgeMaterialType> RidgeMaterialTypes { get; set; }
        public static List<DTO_LU_ScopeType> ScopeTypes { get; set; }
        public static List<DTO_LU_ServiceTypes> ServiceTypes { get; set; }
        public static List<DTO_LU_ShingleType> ShingleTypes { get; set; }
        public static List<DTO_LU_UnitOfMeasure> UnitsOfMeasure { get; set; }
        public static List<DTO_LU_VendorTypes> VendorTypes { get; set; }
    }
}
