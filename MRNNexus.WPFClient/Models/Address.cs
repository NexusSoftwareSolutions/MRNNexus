using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Models
{
    
    internal class Address :BaseModel
    {
        #region Fields
        private int _addressID;
        private int _customerID;
        private string _streetAddress;
        private string _zip;
        #endregion

        #region Properties
        public int AddressID
        {
            get { return _addressID; }
            set { _addressID = value;
                RaisePropertyChanged("AddressID");
            }
        }
        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }
        public string StreetAddress
        {
            get { return _streetAddress; }
            set { _streetAddress = value;
                RaisePropertyChanged("StreetAddress");
            }
        }
        public string Zip
        {
            get { return _zip; }
            set { _zip = value;
                RaisePropertyChanged("Zip");
            }
        }
        #endregion  

        #region Constructors
        public Address() { }
        public Address(DTO_Address address)
        {
            this._addressID = address.AddressID;
            this._customerID = address.CustomerID;
            this._streetAddress = address.Address;
            this._zip = address.Zip;
        }
        #endregion

        public DTO_Address toDTO()
        {
            return new DTO_Address
            {
                AddressID = this._addressID,
                CustomerID = this._customerID,
                Address = this._streetAddress,
                Zip = this._zip
            };
        }



    }
}
