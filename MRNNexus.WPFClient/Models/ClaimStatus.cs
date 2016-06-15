using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Models
{
    internal class ClaimStatus : BaseModel
    {
        #region Fields
        private int _claimStatusID;
        private int _claimID;
        private int _claimStatusTypeID;
        private DateTime _claimStatusDate;
        #endregion

        #region Properties
        public int ClaimStatusID
        {
            get { return _claimStatusID; }
            set
            {
                _claimStatusID = value;
                RaisePropertyChanged("ClaimStatusID");
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
        public int ClaimStatusTypeID
        {
            get { return _claimStatusTypeID; }
            set
            {
                _claimStatusTypeID = value;
                RaisePropertyChanged("ClaimStatusTypeID");
            }
        }
        public DateTime ClaimStatusDate
        {
            get { return _claimStatusDate; }
            set
            {
                _claimStatusDate = value;
                RaisePropertyChanged("ClaimStatusDate");
            }
        }
        #endregion

        #region Constructors
        public ClaimStatus() { }
        public ClaimStatus(DTO_ClaimStatus claimStatus)
        {
            ClaimStatusID = claimStatus.ClaimStatusID;
            ClaimID = claimStatus.ClaimID;
            ClaimStatusTypeID = claimStatus.ClaimStatusTypeID;
            ClaimStatusDate = claimStatus.ClaimStatusDate;
        }
        #endregion

        public DTO_ClaimStatus toDTO()
        {
            return new DTO_ClaimStatus
            {
                ClaimStatusID = this.ClaimStatusID,
                ClaimID = this.ClaimID,
                ClaimStatusTypeID = this.ClaimStatusTypeID,
                ClaimStatusDate = this.ClaimStatusDate
            };
        }
    }
}
