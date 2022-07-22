using MediktapAdmin.Models;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;

namespace MediktapAdmin.Views.Appointments.ViewModel
{
    public partial class AppointmentViewModel
    {
        public ObservableCollection<Models.Appointments> Appointments { get; set; }
        [OnChangedMethod(nameof(SelectedAppointmentDateChanged))]
        public DateTime SelectedAppointmentDate { get; set; } = DateTime.Today;
        // ----------------------------------Combobox -------------------------------
        [OnChangedMethod(nameof(SelectedServiceChanged))]
        public ServiceNameAndId SelectedService { get; set; }
        public ObservableCollection<ServiceNameAndId> ServiceNameAndId { get; set; }
        // ----------------------------------Combobox -------------------------------
        public DateTime StartDate => DateTime.Now.Date;

    }
}
