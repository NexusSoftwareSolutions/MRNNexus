using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Models
{
    internal class User : BaseModel
    {
        #region Fields
        private int _userID;
        private int _employeeID;
        private string _username;
        private string _pass;
        private int _permissionID;
        private bool _active;
        #endregion

        #region Properties
        public int UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
                RaisePropertyChanged("UserID");
            }
        }
        public int EmployeeID {
            get { return _employeeID; }
            set
            {
                _employeeID = value;
                RaisePropertyChanged("EmployeeID");
            }
        }
        public string Username {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged("Username");
            }
        }
        public string Pass {
            get { return _pass; }
            set
            {
                _pass = value;
                RaisePropertyChanged("Pass");
            }
        }
        public int PermissionID {
            get { return _permissionID; }
            set
            {
                _permissionID = value;
                RaisePropertyChanged("PermissionID");
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
        #endregion

        #region Constructors
        public User() { }
        public User(DTO_User user)
        {
            UserID = user.UserID;
            EmployeeID = user.EmployeeID;
            Username = user.Username;
            Pass = user.Pass;
            PermissionID = user.PermissionID;
            Active = user.Active;
        }
        #endregion

        public DTO_User toDTO()
        {
            return new DTO_User
            {
                UserID = this._userID,
                EmployeeID = this._employeeID,
                Username = this._username,
                Pass = this._pass,
                PermissionID = this._permissionID,
                Active = this._active
            };
        }
    }
}
