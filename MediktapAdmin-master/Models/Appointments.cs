using System;

namespace MediktapAdmin.Models
{
    // USED FOR PICKER'S DATA CONTEXT
    public class Appointments
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string BookingStatus { get; set; }
    }

    public class AppointmentsWithPatientId
    {
        public string Name { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}