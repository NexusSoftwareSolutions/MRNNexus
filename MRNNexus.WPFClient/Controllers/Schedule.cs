using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MRNNexusDTOs;
using MRNNexus.WPFClient.Models;
using System.Collections.ObjectModel;
using System.Windows;


namespace MRNNexus.WPFClient.Controllers
{
    internal class Schedule
    {
        public ObservableCollection<MappedAppointment> MappedAppointments = new ObservableCollection<MappedAppointment>();
        public ObservableCollection<MappedAppointment> TodaysAppointments = new ObservableCollection<MappedAppointment>();

        public async Task GetEmployeeAppointments()
        {
            ServiceLayer s = new ServiceLayer();

            //await s.MakeRequest(new DTO_User { Username = usernameBox.Text, Pass = passwordBox.Text }, typeof(DTO_Employee), "Login");
            await new ServiceLayer().GetCalendarDataByEmployeeID(ServiceLayer.LoggedInEmployee);

            foreach (var calData in ServiceLayer.CalendarDataList)
            {

				await new ServiceLayer().GetLeadByLeadID(new DTO_Lead { LeadID = (int)calData.LeadID });
				await new ServiceLayer().GetAddressByID(new DTO_Address { AddressID = (int)ServiceLayer.Lead.AddressID });
				MappedAppointments.Add(new MappedAppointment
                {
                    MappedSubject = ServiceLayer.AppointmentTypes[calData.AppointmentTypeID - 1].AppointmentType,
                    MappedStartTime = calData.StartTime,
                    MappedEndTime = calData.EndTime,
                    MappedNote = calData.Note,
                    MappedLocation = "Some Location",
					CalendarDataID = calData.EntryID,
					LeadID = (int) calData.LeadID,
					AddressID = ServiceLayer.Lead.AddressID

					
                });


                /* TODAYS APPOINTMENTS*/
                DateTime time = new DateTime(calData.StartTime.Year, calData.StartTime.Month, calData.StartTime.Day);
                //if(time == DateTime.Today)
                if (time == new DateTime(2016, 5, 10))
                {
                    
                    await new ServiceLayer().GetLeadByLeadID(new DTO_Lead { LeadID = (int)calData.LeadID });
                    await new ServiceLayer().GetAddressByID(new DTO_Address { AddressID = (int)ServiceLayer.Lead.AddressID });
                    
                    TodaysAppointments.Add(new MappedAppointment
                    {
                        MappedSubject = ServiceLayer.AppointmentTypes[calData.AppointmentTypeID - 1].AppointmentType,
                        //MappedStartTime = calData.StartTime.ToString("h:mm tt"), //calData.StartTime.TimeOfDay.ToString("tt"),
                        //MappedEndTime = calData.EndTime.ToString("h:mm tt"), //calData.EndTime.TimeOfDay.ToString(),
                        MappedNote = calData.Note,
                        MappedLocation = ServiceLayer.Address.Address + " " + ServiceLayer.Address.Zip,
                        CalendarDataID = calData.EntryID,
                        LeadID = (int)calData.LeadID,
                        AddressID = ServiceLayer.Lead.AddressID
                    });
                }
            }
        }

		public async Task UpdateCalendarData(Syncfusion.UI.Xaml.Schedule.AppointmentEditorClosedEventArgs e)
		{
			MappedAppointment appointment = e.EditedAppointment as MappedAppointment;
			MappedAppointment original = e.OriginalAppointment as MappedAppointment;

			appointment.CalendarDataID = original.CalendarDataID;
			appointment.LeadID = original.LeadID;
			

			ServiceLayer s = new ServiceLayer();
            ServiceLayer.CalendarData = ServiceLayer.CalendarDataList.Find (c => c.EntryID == appointment.CalendarDataID);
            ServiceLayer.CalendarData.StartTime = appointment.MappedStartTime;
            ServiceLayer.CalendarData.EndTime = appointment.MappedEndTime;
            ServiceLayer.CalendarData.Note = appointment.MappedNote;

			await new ServiceLayer().UpdateCalendarData(ServiceLayer.CalendarData);

			if (ServiceLayer.CalendarData.SuccessFlag)
			{
				MessageBox.Show(ServiceLayer.CalendarData.SuccessFlag.ToString(), "Success", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			else
			{
				MessageBox.Show(ServiceLayer.CalendarData.SuccessFlag.ToString(), "Failure", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		//public async Task AddCalendarData()
		//{

		//}
    }
}
