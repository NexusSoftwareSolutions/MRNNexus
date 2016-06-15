using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Models
{
    class Employee : BaseModel
    {
        #region Fields
        private int _employeeID;
        private int _employeeTypeID;
        private string _firstName;
        private string _lastName;
        private string _suffix;
        private string _email;
        private string _cellPhone;
        private bool _active;
        #endregion

        #region Properties
        public int EmployeeID {
            get { return _employeeID; }
            set
            {
                _employeeID = value;
                RaisePropertyChanged("EmployeeID");
            }
        }
        public int EmployeeTypeID {
            get { return _employeeTypeID; }
            set
            {
                _employeeTypeID = value;
                RaisePropertyChanged("EmployeeTypeID");
            }
        }
        public string FirstName {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }
        public string LastName {
            get { return _lastName; }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }
        public string Suffix {
            get { return _suffix; }
            set
            {
                _suffix = value;
                RaisePropertyChanged("Suffix");
            }
        }
        public string Email {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }
        public string CellPhone {
            get { return _cellPhone; }
            set
            {
                _cellPhone = value;
                RaisePropertyChanged("CellPhone");
            }
        }
        public bool Active {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("Active");
            }
        }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        #endregion

        #region Constructors
        public Employee() { }
        public Employee(DTO_Employee employee)
        {
            EmployeeID = employee.EmployeeID;
            EmployeeTypeID = employee.EmployeeTypeID;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Suffix = employee.Suffix;
            Email = employee.Email;
            CellPhone = employee.CellPhone;
            Active = employee.Active;
        }
        #endregion

        public DTO_Employee toDTO()
        {
            return new DTO_Employee
            {
                EmployeeID = this._employeeID,
                EmployeeTypeID = this.EmployeeTypeID,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Suffix = this.Suffix,
                Email = this.Email,
                CellPhone = this._cellPhone,
                Active = this._active
            };
        }


    }
}
