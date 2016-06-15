using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Models
{
    internal class MappedAppointment : BaseModel
    {
        #region Fields
        private string _mappedSubject;
        private DateTime _mappedStartTime;
        private DateTime _mappedEndTime;
        private string _mappedNote;
        private string _mappedLocation;
        private int _calednarDataID;
        private int _leadID;
        private int _addressID;
        #endregion

        #region Properties
        public string MappedSubject
        {
            get { return _mappedSubject; }
            set
            {
                _mappedSubject = value;
                RaisePropertyChanged("MappedSubject");
            }
        }
        public DateTime MappedStartTime
        {
            get { return _mappedStartTime; }
            set
            {
                _mappedStartTime = value;
                RaisePropertyChanged("MappedStartTime");
            }
        }
        public DateTime MappedEndTime
        {
            get { return _mappedEndTime; }
            set
            {
                _mappedEndTime = value;
                RaisePropertyChanged("MappedEndTime");
            }
        }
        public string MappedNote
        {
            get { return _mappedNote; }
            set
            {
                _mappedNote = value;
                RaisePropertyChanged("MappedNote");
            }
        }
        public string MappedLocation
        {
            get { return _mappedLocation; }
            set
            {
                _mappedLocation = value;
                RaisePropertyChanged("MappedLocation");
            }
        }

		public int CalendarDataID
        {
            get { return _calednarDataID; }
            set
            {
                _calednarDataID = value;
                RaisePropertyChanged("CalendarDataID");
            }
        }
		public int LeadID
        {
            get { return _leadID; }
            set
            {
                _leadID = value;
                RaisePropertyChanged("LeadID");
            }
        }
        public int AddressID
        {
            get { return _addressID; }
            set
            {
                _addressID = value;
                RaisePropertyChanged("AddressID");
            }
        }
        #endregion

        //public event PropertyChangedEventHandler PropertyChanged;

        //// Property change Notification
        //public void RaisePropertyChanged(string propertyName)
        //{
        //    //take a copy to prevent thread issues
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if(handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        public override bool Equals(object obj)
			{
				MappedAppointment mp = obj as MappedAppointment;
				if (string.Equals(this.MappedSubject, mp.MappedSubject) &&
					this.MappedStartTime == mp.MappedStartTime &&
					this.MappedEndTime == mp.MappedEndTime &&
					string.Equals(this.MappedNote, mp.MappedNote) &&
					string.Equals(this.MappedLocation, mp.MappedLocation))
					return true;
				else
					return false;
			}
        


    }
}
