using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Models
{
    class KnockerResponse : BaseModel
    {
        #region Fields
        private int _knockerResponseID;
        private int _knockerID;
        private int _knockerResponseTypeID;
        private string _address;
        private string _zip;
        private double? _latitude;
        private double? _longitude;
        #endregion

        #region Properties
        public int KnockerResponseID
        {
            get { return _knockerResponseID; }
            set
            {
                _knockerResponseID = value;
                RaisePropertyChanged("KnockerResponseID");
            }
        }
        public int KnockerID
        {
            get { return _knockerID; }
            set
            {
                _knockerID = value;
                RaisePropertyChanged("KnockerID");
            }
        }
        public int KnockerResponseTypeID
        {
            get { return _knockerResponseTypeID; }
            set
            {
                _knockerResponseTypeID = value;
                RaisePropertyChanged("KnockerResponseTypeID");
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                RaisePropertyChanged("Address");
            }
        }
        public string Zip
        {
            get { return _zip; }
            set
            {
                _zip = value;
                RaisePropertyChanged("Zip");
            }
        }
        public double? Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                RaisePropertyChanged("Latitude");
            }
        }
        public double? Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                RaisePropertyChanged("Longitude");
            }
        }
        #endregion

        #region Constructors
        public KnockerResponse() { }
        public KnockerResponse(DTO_KnockerResponse kr)
        {
            KnockerResponseID = kr.KnockerResponseID;
            KnockerID = kr.KnockerID;
            KnockerResponseTypeID = kr.KnockResponseTypeID;
            Address = kr.Address;
            Zip = kr.Zip;
            Latitude = kr.Latitude;
            Longitude = kr.Longitude;
        }
        #endregion

        public DTO_KnockerResponse toDTO()
        {
            return new DTO_KnockerResponse
            {
                KnockerResponseID = this.KnockerResponseID,
                KnockerID = this.KnockerID,
                KnockResponseTypeID = this.KnockerResponseTypeID,
                Address = this.Address,
                Zip = this.Zip,
                Latitude = this.Latitude,
                Longitude = this.Longitude
            };
        }
    }
}
