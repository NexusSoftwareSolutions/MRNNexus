using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(AutoGenerateField = true, Order = 0, Name = "ID")]
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

        [Display(AutoGenerateField = false)]
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

        [Display(AutoGenerateField = false)]
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

        [Display(AutoGenerateField = true, Order = 5)]
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

        [Display(AutoGenerateField = true, Order = 6)]
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

        [Display(AutoGenerateField = true, Order = 7)]
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

        [Display(AutoGenerateField = true, Order = 3, Name = "Date")]
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

        [Display(AutoGenerateField = false)]
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

        [Display(AutoGenerateField = true, Order = 8, Name = "Comment")]
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

        [Display(AutoGenerateField = true, Order = 1, Name = "Adjuster")]
        public string AdjusterName { get; set; }

        [Display(AutoGenerateField = true, Order = 2, Name = "MRN #")]
        public string MRNNumber { get; set; }

        [Display(AutoGenerateField = true, Order = 4, Name = "Result")]
        public string AdjustmentResult { get; set; }

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
