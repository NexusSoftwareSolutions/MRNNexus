using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Models
{
    internal class Adjuster : BaseModel
    {
        #region Fields
        private int _adjusterID;
        private string _firstName;
        private string _lastName;
        private string _suffix;
        private string _phoneNumber;
        private string _phoneExt;
        private string _email;
        private int _insuranceCompanyID;
        private string _comments;
        #endregion

        #region Properties
        [Display(AutoGenerateField = true, Order = 0, Name = "ID")]
        public int AdjusterID {
            get { return _adjusterID; }
            set
            {
                _adjusterID = value;
                RaisePropertyChanged("AdjusterID");
            }
        }
        [Display(AutoGenerateField = true, Order = 1, Name = "First Name")]
        public string FirstName {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }
        [Display(AutoGenerateField = true, Order = 2, Name = "Last Name")]
        public string LastName {
            get { return _lastName; }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }
        [Display(AutoGenerateField = true, Order = 3)]
        public string Suffix {
            get { return _suffix; }
            set
            {
                _suffix = value;
                RaisePropertyChanged("Suffix");
            }
        }
        [Display(AutoGenerateField = true, Order = 4, Name = "Phone")]
        public string PhoneNumber {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                RaisePropertyChanged("PhoneNumber");
            }
        }
        [Display(AutoGenerateField = true, Order = 5, Name = "Ext.")]
        public string PhoneExt {
            get { return _phoneExt; }
            set
            {
                _phoneExt = value;
                RaisePropertyChanged("PhoneExt");
            }
        }
        [Display(AutoGenerateField = true, Order = 6, Name = "Phone")]
        public string Email {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }
        [Display(AutoGenerateField = false)]
        public int InsuranceCompanyID {
            get { return _insuranceCompanyID; }
            set
            {
                _insuranceCompanyID = value;
                RaisePropertyChanged("InsuranceCompanyID");
            }
        }
        [Display(AutoGenerateField = true, Order = 8)]
        public string Comments {
            get { return _comments; }
            set
            {
                _comments = value;
                RaisePropertyChanged("Comments");
            }
        }

        #region Properties for DisplayGrid
        [Display(AutoGenerateField = true, Order = 7, Name = "InsuranceCompany")]
        public string InsuranceCompany { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        #endregion
        #endregion

        #region Constructors
        public Adjuster() { }
        public Adjuster(DTO_Adjuster adj)
        {
            AdjusterID = adj.AdjusterID;
            FirstName = adj.FirstName;
            LastName = adj.LastName;
            Suffix = adj.Suffix;
            PhoneNumber = adj.PhoneNumber;
            PhoneExt = adj.PhoneExt;
            Email = adj.Email;
            InsuranceCompanyID = adj.InsuranceCompanyID;
            Comments = adj.Comments;
        }
        #endregion

        public DTO_Adjuster toDTO()
        {
            return new DTO_Adjuster
            {
                AdjusterID = AdjusterID,
                FirstName = FirstName,
                LastName = LastName,
                Suffix = Suffix,
                PhoneNumber = PhoneNumber,
                PhoneExt = PhoneExt,
                Email = Email,
                InsuranceCompanyID = InsuranceCompanyID,
                Comments = Comments
            };
        }
    }
}
