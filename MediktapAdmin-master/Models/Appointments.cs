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
        public DateTime AppointmentDate { get; set; }
        public int ProspectsAge { get; set; }
        public string ProspectsSex { get; set; }
        public string PatientName { get; set; }
        public bool AppointmentForSomeoneElse { get; set; }
#nullable enable
        public string? ProspectName { get; set; }
      
#nullable disable
    }


}