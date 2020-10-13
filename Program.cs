using System.Collections.Generic;
using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            DoctorService doctorService = new DoctorService();
            List<DoctorAppointment> inputs = GetInput();
            List<DoctorAppointment> timeSchedule = doctorService.GenerateSchedule(
                DateTime.Now.Date.Add(new TimeSpan(9, 0, 0)), DateTime.Now.Date.Add(new TimeSpan(23, 0, 0)));
            List<DoctorAppointment> output = doctorService.GetSchedule(timeSchedule, inputs);
            foreach (var item in output)
            {
                Console.WriteLine("Start: " + item.StartTime + " - End: " + item.EndTime);
            }
        }


        static List<DoctorAppointment> GetInput()
        {
            List<DoctorAppointment> doctorAppointments = new List<DoctorAppointment>();
            DoctorAppointment input1 = new DoctorAppointment
            {
                Name = "Slot 1",
                StartTime = DateTime.Now.Date.Add(new TimeSpan(9, 0, 0)),
                EndTime = DateTime.Now.Date.Add(new TimeSpan(9, 30, 0))
            };

            DoctorAppointment input2 = new DoctorAppointment
            {
                Name = "Slot 2",
                StartTime = DateTime.Now.Date.Add(new TimeSpan(9, 45, 0)),
                EndTime = DateTime.Now.Date.Add(new TimeSpan(10, 15, 0))
            };

            doctorAppointments.Add(input1);
            doctorAppointments.Add(input2);
            return doctorAppointments;
        }

    }
}
