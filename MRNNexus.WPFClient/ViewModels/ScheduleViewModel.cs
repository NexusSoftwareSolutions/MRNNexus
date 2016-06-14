using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MRNNexus.WPFClient.Models;
using MRNNexusDTOs;

using MRNNexus.WPFClient.Commands;
using Syncfusion.UI.Xaml.Schedule;

using System.Windows.Input;

namespace MRNNexus.WPFClient.ViewModels
{
    class ScheduleViewModel : BaseViewModel
    {
        #region Fields
        // Observable Collection for Calendar
        private ObservableCollection<MappedAppointment> _mappedAppointments;
        private ObservableCollection<MappedAppointment> _todaysAppointments;
        #endregion

        #region Properties
        public ObservableCollection<MappedAppointment> MappedAppointments
        {
            get { return _mappedAppointments; }
            set { _mappedAppointments = value;
                RaisePropertyChanged("MappedAppointments");
            }
        }
        public ObservableCollection<MappedAppointment> TodaysAppointments
        {
            get { return _todaysAppointments; }
            set { _todaysAppointments = value;
                RaisePropertyChanged("TodaysAppointments"); }
        }
        #endregion

        #region Commands
        private ICommand _appointmentEditorClosed;
        public ICommand AppointmentEditorClosed
        {
            get { return _appointmentEditorClosed; }
            set { _appointmentEditorClosed = value; }
        }
        #endregion

        // Event for PropertyChanged Notification
        ///public event PropertyChangedEventHandler PropertyChanged;

        // Constructor of ViewModel
        public ScheduleViewModel()
        {
            this._mappedAppointments = new ObservableCollection<MappedAppointment>();
            this._todaysAppointments = new ObservableCollection<MappedAppointment>();

            getCalendarData();

            _appointmentEditorClosed = new DelegateCommand<AppointmentEditorClosedEventArgs>(saveAppointment); //RelayCommand(new Action<object>(saveAppointment));


        }

        async private void getCalendarData()
        {
            ServiceLayer s = new ServiceLayer();

            ErrorMessage = await new ServiceLayer().GetCalendarDataByEmployeeID(LoggedInEmployee.toDTO());

            foreach (var calData in ServiceLayer.CalendarDataList)
            {

                ErrorMessage = await new ServiceLayer().GetLeadByLeadID(new Lead { LeadID = (int)calData.LeadID }.toDTO());
                ErrorMessage = await new ServiceLayer().GetAddressByID(new Address { AddressID = (int)ServiceLayer.Lead.AddressID }.toDTO());
                MappedAppointments.Add(new MappedAppointment
                {
                    MappedSubject = AppointmentTypes[calData.AppointmentTypeID - 1].AppointmentType,
                    MappedStartTime = calData.StartTime,
                    MappedEndTime = calData.EndTime,
                    MappedNote = calData.Note,
                    MappedLocation = ServiceLayer.Address.Address + " " + ServiceLayer.Address.Zip,
                    CalendarDataID = calData.EntryID,
                    LeadID = (int)calData.LeadID,
                    AddressID = ServiceLayer.Lead.AddressID
                });

                
            }

            foreach (MappedAppointment m in MappedAppointments)
            {
                /* TODAYS APPOINTMENTS*/
                DateTime time = new DateTime(m.MappedStartTime.Year, m.MappedStartTime.Month, m.MappedStartTime.Day);
                //if(time == DateTime.Today)
                if (time == new DateTime(2016, 6, 7))
                {
                    TodaysAppointments.Add(m);
                }
            }
        }

        async private void saveAppointment(AppointmentEditorClosedEventArgs e)
        {
            if (e.EditedAppointment != null && e.Action == Syncfusion.UI.Xaml.Schedule.EditorClosedAction.Save)
            {
                MappedAppointment appt = e.EditedAppointment as MappedAppointment;                

                if (e.IsNew)
                {
                    ServiceLayer s = new ServiceLayer();
                    ServiceLayer.CalendarData = new DTO_CalendarData
                    {
                        AppointmentTypeID = Int32.Parse(appt.MappedSubject),
                        EmployeeID = ServiceLayer.LoggedInEmployee.EmployeeID,
                        StartTime = appt.MappedStartTime,
                        EndTime = appt.MappedEndTime,
                        Note = appt.MappedNote
                    };

                    /// FIX THIS!!!!!!!!~!
                    //await new ServiceLayer().AddCalendarData(ServiceLayer.CalendarData);
                    await new ServiceLayer().AddCalendarData(ServiceLayer.CalendarData);

                    if (ServiceLayer.CalendarData.SuccessFlag)
                    {

                    }
                    else
                    {

                    }
                }
                else if (!e.OriginalAppointment.Equals(e.EditedAppointment))
                {

                    MappedAppointment original = e.OriginalAppointment as MappedAppointment;

                    appt.CalendarDataID = original.CalendarDataID;
                    appt.LeadID = original.LeadID;


                    ServiceLayer s = new ServiceLayer();
                    ServiceLayer.CalendarData = ServiceLayer.CalendarDataList.Find(c => c.EntryID == appt.CalendarDataID);
                    ServiceLayer.CalendarData.StartTime = appt.MappedStartTime;
                    ServiceLayer.CalendarData.EndTime = appt.MappedEndTime;
                    ServiceLayer.CalendarData.Note = appt.MappedNote;

                    await new ServiceLayer().UpdateCalendarData(ServiceLayer.CalendarData);

                    if (ServiceLayer.CalendarData.SuccessFlag)
                    {
                        //MessageBox.Show(s.CalendarData.SuccessFlag.ToString(), "Success", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        //MessageBox.Show(s.CalendarData.SuccessFlag.ToString(), "Failure", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        
        }

        // PropertyChanged EventHandler
        //public void RaisePropertyChanged(string propertyName)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if(handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
    }
}
