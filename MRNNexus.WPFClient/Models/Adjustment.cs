using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Models
{
    internal class Adjustment : BaseModel
    {
        private int _adjustmentID;
        private int _adjusterID;
        private int _claimID;
        private bool _gutters;
        private bool _exterior;
        private bool _interior;
        private DateTime _adjustmentDate;
        private int _adjustmentResultID;
        private string _adjustmentComment;


        #region Properties

        public int AdjustmentID
        {
            get { return _adjustmentID; }
            set
            {
                if (value != _adjustmentID)
                {
                    _adjustmentID = value;
                    RaisePropertyChanged("AdjustmentID");
                }
            }
        }

        public int AdjusterID
        {
            get { return _adjusterID; }
            set
            {
                if (value != _adjusterID)
                {
                    _adjusterID = value;
                    RaisePropertyChanged("AdjusterID");
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

        public bool Gutters
        {
            get { return _gutters; }
            set
            {
                if (value != _gutters)
                {
                    _gutters = value;
                    RaisePropertyChanged("Gutters");
                }
            }
        }

        public bool Exterior
        {
            get { return _exterior; }
            set
            {
                if (value != _exterior)
                {
                    _exterior = value;
                    RaisePropertyChanged("Exterior");
                }
            }
        }

        public bool Interior
        {
            get { return _interior; }
            set
            {
                if (value != _interior)
                {
                    _interior = value;
                    RaisePropertyChanged("Interior");
                }
            }
        }

        public DateTime AdjustmentDate
        {
            get
            {
                if (_adjustmentDate == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                    return _adjustmentDate;
            }
            set
            {
                if (value != _adjustmentDate)
                {
                    _adjustmentDate = value;
                    RaisePropertyChanged("AdjustmentDate");
                }
            }
        }

        public int AdjustmentResultID
        {
            get { return _adjustmentResultID; }
            set
            {
                if (value != _adjustmentResultID)
                {
                    _adjustmentResultID = value;
                    RaisePropertyChanged("AdjustmentResultID");
                }
            }
        }

        public string AdjustmentComment
        {
            get { return _adjustmentComment; }
            set
            {
                if (value != _adjustmentComment)
                {
                    _adjustmentComment = value;
                    RaisePropertyChanged("AdjustmentComment");
                }
            }
        }

        #endregion

        #region Constructors
        public Adjustment() { }
        public Adjustment(DTO_Adjustment adj)
        {
            AdjustmentID = adj.AdjustmentID;
            AdjusterID = adj.AdjusterID;
            ClaimID = adj.ClaimID;
            Gutters = adj.Gutters;
            Exterior = adj.Exterior;
            Interior = adj.Interior;
            AdjustmentDate = adj.AdjustmentDate;
            AdjustmentResultID = adj.AdjustmentResultID;
            AdjustmentComment = adj.AdjustmentComment;
        }
        #endregion

        public DTO_Adjustment toDTO()
        {
            return new DTO_Adjustment
            {
                AdjustmentID = this.AdjustmentID,
                AdjusterID = this.AdjusterID,
                ClaimID = this.ClaimID,
                Gutters = this.Gutters,
                Exterior = this.Exterior,
                Interior = this.Interior,
                AdjustmentDate = this.AdjustmentDate,
                AdjustmentResultID = this.AdjustmentResultID,
                AdjustmentComment = this.AdjustmentComment
            };
        }
    }
}
