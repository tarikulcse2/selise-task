using System;
using System.Collections.Generic;

namespace test
{
    public class DoctorService
    {
        public List<DoctorAppointment> GenerateSchedule(DateTime startTime, DateTime endTime)
        {
            List<DoctorAppointment> doctorAppointments = new List<DoctorAppointment>();
            DateTime currentTime = startTime;
            int i = 1;
            while (currentTime < endTime)
            {
                DateTime currentEndTime = currentTime.Add(new TimeSpan(0, 30, 0));
                DoctorAppointment appointment = new DoctorAppointment
                {
                    Name = "Slot" + i,
                    StartTime = currentTime,
                    EndTime = currentEndTime
                };
                doctorAppointments.Add(appointment);
                currentTime = currentEndTime.Add(new TimeSpan(0, 15, 0));
                i++;
            }
            return doctorAppointments;
        }

        public List<DoctorAppointment> GetSchedule(List<DoctorAppointment> list, List<DoctorAppointment> inputs)
        {
            foreach (DoctorAppointment item in inputs)
            {
                if (CheckedBookedSlot(list, item))
                    list.Remove(item);
            }
            return list;
        }

        private bool CheckedBookedSlot(List<DoctorAppointment> list, DoctorAppointment doctorAppointment)
        {
            return list.FindAll(r => r.StartTime == doctorAppointment.StartTime && r.EndTime == doctorAppointment.EndTime).Count > 0;
        }

    }
}