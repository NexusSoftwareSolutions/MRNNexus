using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Models
{
    internal class Scope : BaseModel
    {
        #region Fields
        private int _scopeID;
        private int _scopeTypeID;
        private int _claimID;
        private double _interior;
        private double _exterior;
        private double _gutter;
        private double _roofAmount;
        private double _tax;
        private double _deductible;
        private double _total;
        private double _oAndP;
        private bool _accepted;
        #endregion

        #region Properties
        public int ScopeID
        {
            get { return _scopeID; }
            set {
                _scopeID = value;
                RaisePropertyChanged("ScopeID");
            }
        }
        public int ScopeTypeID
        {
            get { return _scopeTypeID; }
            set
            {
                _scopeTypeID = value;
                RaisePropertyChanged("ScopeTypeID");
            }
        }
        public int ClaimID
        {
            get { return _claimID; }
            set
            {
                _claimID = value;
                RaisePropertyChanged("ClaimID");
            }
        }
        public double Interior
        {
            get { return _interior; }
            set
            {
                _interior = value;
                RaisePropertyChanged("Interior");
            }
        }
        public double Exterior
        {
            get { return _exterior; }
            set
            {
                _exterior = value;
                RaisePropertyChanged("Exterior");
            }
        }
        public double Gutter
        {
            get { return _gutter; }
            set
            {
                _gutter = value;
                RaisePropertyChanged("Gutter");
            }
        }
        public double RoofAmount
        {
            get { return _roofAmount; }
            set
            {
                _roofAmount = value;
                RaisePropertyChanged("RoofAmount");
            }
        }
        public double Tax
        {
            get { return _tax; }
            set
            {
                _tax = value;
                RaisePropertyChanged("Tax");
            }
        }
        public double Deductible
        {
            get { return _deductible; }
            set
            {
                _deductible = value;
                RaisePropertyChanged("Deductible");
            }
        }
        public double Total
        {
            get { return _total; }
            set
            {
                _total = value;
                RaisePropertyChanged("Total");
            }
        }
        public double OandP
        {
            get { return _oAndP; }
            set
            {
                _oAndP = value;
                RaisePropertyChanged("OAndP");
            }
        }
        public bool Accepted
        {
            get { return _accepted; }
            set
            {
                _accepted = value;
                RaisePropertyChanged("Accepted");
            }
        }

        #endregion

        #region Constructors
        public Scope() { }
        public Scope(DTO_Scope s)
        {
            ScopeID = s.ScopeID;
            ScopeTypeID = s.ScopeTypeID;
            ClaimID = s.ClaimID;
            Interior = s.Interior;
            Exterior = s.Exterior;
            Gutter = s.Gutter;
            RoofAmount = s.RoofAmount;
            Tax = s.Tax;
            Deductible = s.Deductible;
            Total = s.Total;
            OandP = s.OandP;
            Accepted = s.Accepted;
        }
        #endregion

        public DTO_Scope toDTO()
        {
            return new DTO_Scope
            {
                ScopeID = this.ScopeID,
                ScopeTypeID = this.ScopeTypeID,
                ClaimID = this.ClaimID,
                Interior = this.Interior,
                Exterior = this.Exterior,
                Gutter = this.Gutter,
                RoofAmount = this.RoofAmount,
                Tax = this.Tax,
                Deductible = this.Deductible,
                Total = this.Total,
                OandP = this.OandP,
                Accepted = this.Accepted
        };
        }
    }
}
