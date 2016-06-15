using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Models
{
    internal class Customer : BaseModel
    {
        #region Fields
        private int _customerID;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _suffix;
        private string _primaryNumber;
        private string _secondaryNumber;
        private string _email;
        private bool _mailPromos = true;
        #endregion


        #region Properties

        [Display(AutoGenerateField = true, Order = 1)]
        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }

        [Display(AutoGenerateField = true, Order = 2, Name = "First Name")]
        public string FirstName
        {
            get { return _firstName; }
            set {
                if (value.Trim() == "")
                    _firstName = null;
                else
                    _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        [Display(AutoGenerateField = true, Order = 3, Name = "Middle Name")]
        public string MiddleName
        {
            get { return _middleName; }
            set {
                if (value.Trim() == "")
                    _middleName = null;
                else
                    _middleName = value;
                RaisePropertyChanged("MiddleName");
            }
        }

        [Display(AutoGenerateField = true, Order = 4, Name = "Last Name")]
        public string LastName
        {
            get { return _lastName; }
            set {
                if (value.Trim() == "")
                    _lastName = null;
                else
                    _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        [Display(AutoGenerateField = true, Order = 5)]
        public string Suffix
        {
            get { return _suffix; }
            set {
                if (value.Trim() == "")
                    _suffix = null;
                else
                    _suffix = value;
                RaisePropertyChanged("Suffix");
            }
        }

        [Display(AutoGenerateField = true, Order = 6, Name = "Primary #")]
        public string PrimaryNumber
        {
            get { return _primaryNumber; }
            set {
                if (value.Trim() == "")
                    _primaryNumber = null;
                else
                    _primaryNumber = value;
                RaisePropertyChanged("PrimaryNumber");
            }
        }

        [Display(AutoGenerateField = true, Order = 7, Name = "Seconday #")]
        public string SecondaryNumber
        {
            get { return _secondaryNumber; }
            set {
                if (value.Trim() == "")
                    _secondaryNumber = null;
                else
                    _secondaryNumber = value;
                RaisePropertyChanged("SecondaryNumber");
            }
        }

        [Display(AutoGenerateField = true, Order = 8)]
        public string Email
        {
            get { return _email; }
            set {
                if (value.Trim() == "")
                    _email = null;
                else
                    _email = value;
                RaisePropertyChanged("Email");
            }
        }

        [Display(AutoGenerateField = true, Order = 9, Name = "Promotional Mail")]
        public bool MailPromos
        {
            get { return _mailPromos; }
            set { _mailPromos = value;
                RaisePropertyChanged("MailPromos");
            }
        }

            #region Properties for Grid Display

            [Display(AutoGenerateField = true, Order = 1)]
            public string Address { get; set; }

            #endregion

        #endregion

        #region Constructors
        public Customer() { }
        public Customer(DTO_Customer customer)
        {
            this._customerID = customer.CustomerID;
            this._firstName = customer.FirstName;
            this._middleName = customer.MiddleName;
            this._lastName = customer.LastName;
            this._suffix = customer.Suffix;
            this._primaryNumber = customer.PrimaryNumber;
            this._secondaryNumber = customer.SecondaryNumber;
            this._email = customer.Email;
            this._mailPromos = customer.MailPromos;
        }
        #endregion

        public DTO_Customer toDTO()
        {
            return new DTO_Customer
            {
                CustomerID = this._customerID,
                FirstName = this._firstName,
                MiddleName = this._middleName,
                LastName = this._lastName,
                Suffix = this._suffix,
                PrimaryNumber = this._primaryNumber,
                SecondaryNumber = this._secondaryNumber,
                Email = this._email,
                MailPromos = this._mailPromos
            };                
        }




        
    }
}
