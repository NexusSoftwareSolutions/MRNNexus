using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MRNNexusDTOs;
using System.ComponentModel.DataAnnotations;

namespace MRNNexus.WPFClient.Models
{
    internal class Lead : BaseModel
    {
        #region Fields
        private int _leadID;
        private int _leadTypeID;
        private int? _knockerResponseID;
        private int _salespersonID;
        private int _customerID;
        private int _addressID;
        private DateTime _leadDate = DateTime.Now;
        private string _status;
        private int? _creditToID;
        private string _temperature = "W";
        private int? _numberOfDays;
        #endregion

        #region Properties
        [Display(AutoGenerateField = true, Order = 1)]
        public int LeadID
        {
            get { return _leadID; }
            set
            {
                _leadID = value;
                RaisePropertyChanged("LeadID");
            }
        }
        [Display(AutoGenerateField = false)]
        public int LeadTypeID
        {
            get { return _leadTypeID; }
            set
            {
                _leadTypeID = value;
                RaisePropertyChanged("LeadTypeID");
            }
        }
        [Display(AutoGenerateField = false)]
        public int? KnockerResponseID
        {
            get { return _knockerResponseID; }
            set
            {
                _knockerResponseID = value;
                RaisePropertyChanged("KnockerResponseID");
            }
        }
        [Display(AutoGenerateField = false)]
        public int SalespersonID
        {
            get { return _salespersonID; }
            set
            {
                _salespersonID = value;
                RaisePropertyChanged("SalespersonID");
            }
        }
        [Display(AutoGenerateField = false)]
        public int CustomerID
        {
            get { return _customerID; }
            set
            {
                _customerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }
        [Display(AutoGenerateField = false)]
        public int AddressID
        {
            get { return _addressID; }
            set
            {
                _addressID = value;
                RaisePropertyChanged("AddressID");
            }
        }
        [Display(AutoGenerateField = true, Order = 2)]
        public DateTime LeadDate
        {
            get { return _leadDate; }
            set
            {
                _leadDate = value;
                RaisePropertyChanged("LeadDate");
            }
        }
        [Display(AutoGenerateField = true, Order = 8)]
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }
        [Display(AutoGenerateField = false)]
        public int? CreditToID
        {
            get { return _creditToID; }
            set
            {
                _creditToID = value;
                RaisePropertyChanged("CreditToID");
            }
        }
        [Display(AutoGenerateField = true, Order = 4)]
        public string Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                RaisePropertyChanged("Temperature");
            }
        }
        [Display(AutoGenerateField = false)]
        public int? NumberOfDays
        {
            get { return _numberOfDays; }
            set
            {
                _numberOfDays = value;
                RaisePropertyChanged("NumberOfDays");
            }
        }

        #region Properties for Grid Display
        [Display(AutoGenerateField = true, Order = 3)]
            public string LeadType { get; set; }

            [Display(AutoGenerateField = true, Order = 9)]
            public string CreditTo { get; set; }

            [Display(AutoGenerateField = true, Order = 5)]
            public string CustomerName { get; set; }

            [Display(AutoGenerateField = true, Order = 6)]
            public string Address { get; set; }
            #endregion
        #endregion

        #region Constructors
        public Lead() { }
        public Lead(DTO_Lead lead)
        {
            this._leadID = lead.LeadID;
            this._leadTypeID = lead.LeadTypeID;
            this._knockerResponseID = lead.KnockerResponseID;
            this._salespersonID = lead.SalesPersonID;
            this._customerID = lead.CustomerID;
            this._addressID = lead.AddressID;
            this._leadDate = lead.LeadDate;
            this._status = lead.Status;
            this._creditToID = lead.CreditToID;
            this._temperature = lead.Temperature;
        }
        #endregion

        public DTO_Lead toDTO()
        {
            
            return new DTO_Lead
            {
                LeadID = this._leadID,
                LeadTypeID = this._leadTypeID,
                KnockerResponseID = this._knockerResponseID,
                SalesPersonID = this._salespersonID,
                CustomerID = this._customerID,
                AddressID = this._addressID,
                LeadDate = this._leadDate,
                Status = this._status,
                CreditToID = this._creditToID,
                Temperature = this.Temperature,
                NumberOfDays = this.NumberOfDays
            };
        }
    }
}
