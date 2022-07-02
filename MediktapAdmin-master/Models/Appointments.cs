using System;

namespace MediktapAdmin.Models
{
    public class Appointments
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ServiceId { get; set; }
        public int BookingStatus { get; set; }
    }
}