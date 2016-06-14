using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Models
{
    internal class Invoice : BaseModel
    {
        private int _invoiceID;
        private int _claimID;
        private int _invoiceTypeID;
        private int _vendorID;
        private double _invoiceAmount;
        private DateTime _invoiceDate;
        private bool _paid;

        #region Properties
        public int InvoiceID
        {
            get { return _invoiceID; }
            set
            {
                if(value != _invoiceID)
                {
                    _invoiceID = value;
                    RaisePropertyChanged("InvoiceID");
                }
            }
        }

        public int ClaimID
        {
            get { return _claimID; }
            set
            {
                if (value != _claimID)
                {
                    _claimID = value;
                    RaisePropertyChanged("ClaimID");
                }
            }
        }

        public int InvoiceTypeID
        {
            get { return _invoiceTypeID; }
            set
            {
                if (value != _invoiceTypeID)
                {
                    _invoiceTypeID = value;
                    RaisePropertyChanged("InvoiceTypeID");
                }
            }
        }

        public int VendorID
        {
            get { return _vendorID; }
            set
            {
                if (value != _vendorID)
                {
                    _vendorID = value;
                    RaisePropertyChanged("VendorID");
                }
            }
        }

        public double InvoiceAmount
        {
            get { return _invoiceAmount; }
            set
            {
                if (value != _invoiceAmount)
                {
                    _invoiceAmount = value;
                    RaisePropertyChanged("InvoiceAmount");
                }
            }
        }

        public DateTime InvoiceDate
        {
            get
            {
                if (_invoiceDate == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                    return _invoiceDate;
            }
            set
            {
                if (value != _invoiceDate)
                {
                    _invoiceDate = value;
                    RaisePropertyChanged("InvoiceDate");
                }
            }
        }

        public bool Paid
        {
            get { return _paid; }
            set
            {
                if (value != _paid)
                {
                    _paid = value;
                    RaisePropertyChanged("Paid");
                }
            }
        }
        #endregion

        #region Constructors
        public Invoice() { }
        public Invoice(DTO_Invoice inv)
        {
            InvoiceID = inv.InvoiceID;
            ClaimID = inv.ClaimID;
            InvoiceTypeID = inv.InvoiceTypeID;
            VendorID = inv.VendorID;
            InvoiceAmount = inv.InvoiceAmount;
            InvoiceDate = inv.InvoiceDate;
            Paid = inv.Paid;
        }
        #endregion

        public DTO_Invoice toDTO()
        {
            return new DTO_Invoice
            {
                InvoiceID = this.InvoiceID,
                ClaimID = this.ClaimID,
                InvoiceTypeID = this.InvoiceTypeID,
                VendorID = this.VendorID,
                InvoiceAmount = this.InvoiceAmount,
                InvoiceDate = this.InvoiceDate,
                Paid = this.Paid
            };
        }
    }
}
