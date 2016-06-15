using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Models
{
    internal class Referrer : BaseModel
    {
        #region Fields
        private int _referrerID;
        private string _firstName;
        private string _lastName;
        private string _suffix;
        private string _maillingAddress;
        private string _zip;
        private string _email;
        private string _cellPhone;
        #endregion

        #region Properties
        public int ReferrerID
        {
            get { return _referrerID; }
            set
            {
                _referrerID = value;
                RaisePropertyChanged("ReferrerID");
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }
        public string Suffix
        {
            get { return _suffix; }
            set
            {
                _suffix = value;
                RaisePropertyChanged("Suffix");
            }
        }
        public string MaillingAddress
        {
            get { return _maillingAddress; }
            set
            {
                _maillingAddress = value;
                RaisePropertyChanged("MaillingAddress");
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
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }
        public string CellPhone
        {
            get { return _cellPhone; }
            set
            {
                _cellPhone = value;
                RaisePropertyChanged("CellPhone");
            }
        }
        #endregion

        #region Constructors
        public Referrer() { }
        public Referrer(DTO_Referrer referrer)
        {
            this.ReferrerID = referrer.ReferrerID;
            this.FirstName = referrer.FirstName;
            this.LastName = referrer.LastName;
            this.Suffix = referrer.Suffix;
            this.MaillingAddress = referrer.MailingAddress;
            this.Zip = referrer.Zip;
            this.Email = referrer.Email;
            this.CellPhone = referrer.CellPhone;
        }
        #endregion

        public DTO_Referrer toDTO()
        {
            return new DTO_Referrer
            {
                ReferrerID = this.ReferrerID,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Suffix = this.Suffix,
                MailingAddress = this.MaillingAddress,
                Zip = this.Zip,
                Email = this.Email,
                CellPhone = this.CellPhone
            };
        }
    }
}
