using System;

namespace MediktapAdmin.Models
{
    public class Appointments
    {
        public DateTime AppointmentDate { get; set; }
        public string PatientFullName { get; set; }
        public bool InBehalf { get; set; }
#nullable enable
        public string? ProspectFullName { get; set; }
        public string? ProspectGender { get; set; }
        public int? ProspectAge { get; set; }
#nullable disable
    }
}