using MediktapAdmin.Views.Services;
using System;

namespace MediktapAdmin.Views.Appointments
{
    public class Appointments
    {
        public string AppointmentID { get; set; }
        public string Appointee { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Service Service { get; set; }
        public bool IsEmpty { get; set; }
    }
}