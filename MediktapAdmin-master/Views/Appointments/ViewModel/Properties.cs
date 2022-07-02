using MediktapAdmin.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediktapAdmin.Views.Appointments.ViewModel
{
    public partial class AppointmentViewModel
    {
        public ObservableCollection<Models.ServicesWithId> Services { get; set; }
        [OnChangedMethod(nameof(SelectedServiceChanged))]

        public ServicesWithId SelectedService { get; set; }

        [OnChangedMethod(nameof(SelectedAppointmentDateChanged))]
        public DateTime SelectedAppointmentDate { get; set; }

     
    }
}
