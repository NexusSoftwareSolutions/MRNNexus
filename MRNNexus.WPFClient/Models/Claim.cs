using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Models
{
    internal class Claim : BaseModel
    {
        #region Fields
        private int _claimID;
        private int _customerID;
        private int _leadID;
        private int _billingID;
        private int _propertyID;
        private int _insuranceCompanyID;
        private string _insuranceClaimNumber;
        private string _mrnClaimNumber = "Not Generated Yet.";
        private DateTime _lossDate = DateTime.Now;
        private string _mortgageCompany;
        private string _mortgageAccount;
        private bool _isOpen = true;
        #endregion

        #region Properties
        [Display(AutoGenerateField = false)]
        public int ClaimID
        {
            get { return _claimID; }
            set { _claimID = value;
                RaisePropertyChanged("ClaimID");
            }
        }

        [Display(AutoGenerateField = false)]
        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }

        [Display(AutoGenerateField = false)]
        public int LeadID
        {
            get { return _leadID; }
            set { _leadID = value;
                RaisePropertyChanged("LeadID");
            }
        }

        [Display(AutoGenerateField = false)]
        public int BillingID
        {
            get { return _billingID; }
            set { _billingID = value;
                RaisePropertyChanged("BillingID");
            }
        }

        [Display(AutoGenerateField = false)]
        public int PropertyID
        {
            get { return _propertyID; }
            set { _propertyID = value;
                RaisePropertyChanged("PropertyID");
            }
        }

        [Display(AutoGenerateField = true)]
        public int InsuranceCompanyID
        {
            get { return _insuranceCompanyID; }
            set { _insuranceCompanyID = value;
                RaisePropertyChanged("InsuranceCompanyID");
            }
        }

        [Display(AutoGenerateField = true, Order = 4)]
        public string InsuranceClaimNumber
        {
            get { return _insuranceClaimNumber; }
            set {
                if (value.Trim() == "")
                    _insuranceClaimNumber = null;
                else
                    _insuranceClaimNumber = value;

                RaisePropertyChanged("InsuranceClaimNumber");
            }
        }

        [Display(AutoGenerateField = true, Order = 0)]
        public string MRNClaimNumber
        {
            get { return _mrnClaimNumber; }
            set {
                if (value.Trim() == "")
                    _mrnClaimNumber = null;
                else
                    _mrnClaimNumber = value;
                RaisePropertyChanged("MRNClaimNumber");
            }
        }

        [Display(AutoGenerateField = true, Order = 3)]
        public DateTime LossDate
        {
            get {
                if (_lossDate == DateTime.MinValue)
                    return DateTime.Now;
                else
                    return _lossDate; }
            set { _lossDate = value;
                RaisePropertyChanged("LossDate");
            }
        }

        [Display(AutoGenerateField = true, Order = 6)]
        public string MortgageCompany
        {
            get { return _mortgageCompany; }
            set {
                if (value.Trim() == "")
                    _mortgageCompany = null;
                else
                    _mortgageCompany = value;
                RaisePropertyChanged("MortgageCompany");
            }
        }

        [Display(AutoGenerateField = true, Order = 5)]
        public string MortgageAccount
        {
            get { return _mortgageAccount; }
            set {
                if (value.Trim() == "")
                    _mortgageAccount = null;
                else
                    _mortgageAccount = value;
                RaisePropertyChanged("MortgageAccount");
            }
        }

        [Display(AutoGenerateField = true, Order = 2)]
        public bool IsOpen
        {
            get { return _isOpen; }
            set { _isOpen = value;
                RaisePropertyChanged("IsOpen");
            }
        }

            #region Properties for Grid Display

            [Display(AutoGenerateField = true, Order = 1)]
            public string CustomerName { get; set; }

            [Display(AutoGenerateField = true, Order = 2)]
            public string Address { get; set; }
            #endregion
        #endregion

        #region Constructors
        public Claim() { }
        public Claim(DTO_Claim claim)
        {
            this._claimID = claim.ClaimID;
            this._customerID = claim.CustomerID;
            this._leadID = claim.LeadID;
            this._billingID = claim.BillingID;
            this._propertyID = claim.PropertyID;
            this._insuranceCompanyID = claim.InsuranceCompanyID;
            this._insuranceClaimNumber = claim.InsuranceClaimNumber;
            this._mrnClaimNumber = claim.MRNNumber;
            this._lossDate = claim.LossDate;
            this._mortgageAccount = claim.MortgageAccount;
            this._mortgageCompany = claim.MortgageCompany;
            this._isOpen = claim.IsOpen;
        }
        #endregion

        public DTO_Claim toDTO()
        {
            return new DTO_Claim
            {
                ClaimID = this._claimID,
                CustomerID = this._customerID,
                LeadID = this._leadID,
                BillingID = this._billingID,
                PropertyID = this._propertyID,
                InsuranceCompanyID = this._insuranceCompanyID,
                InsuranceClaimNumber = this._insuranceClaimNumber,
                MRNNumber = this._mrnClaimNumber,
                LossDate = this._lossDate,
                MortgageAccount = this._mortgageAccount,
                MortgageCompany = this._mortgageCompany,
                IsOpen = this._isOpen
                
            };
        }
    }
}
