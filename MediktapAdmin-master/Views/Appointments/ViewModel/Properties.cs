using MediktapAdmin.Models;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;

namespace MediktapAdmin.Views.Appointments.ViewModel
{
    public partial class AppointmentViewModel
    {
        public ObservableCollection<Models.ServicesWithId> Services { get; set; }
        [OnChangedMethod(nameof(SelectedServiceChanged))]

        public ServicesWithId SelectedService { get; set; }

        [OnChangedMethod(nameof(SelectedAppointmentDateChanged))]
        public DateTime SelectedAppointmentDate { get; set; } = DateTime.Today;
        public ObservableCollection<AppointmentsWithPatientId> AppointmentsWithPatientId { get; set; }
        public DateTime StartDate => DateTime.Now.Date;
        public bool isOnBehalf { get; set; }
        public string ProspectName { get; set; }
    }
}
