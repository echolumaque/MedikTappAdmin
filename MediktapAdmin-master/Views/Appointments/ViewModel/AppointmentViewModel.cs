using MediktapAdmin.Models;
using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.ViewModels.Base;
using MedikTapp.Services.HttpService;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MediktapAdmin.Views.Appointments.ViewModel
{
    public partial class AppointmentViewModel : BaseViewModel
    {
        private readonly HttpService _httpService;

        public AppointmentViewModel(NavigationService navigationService, HttpService httpService) : base(navigationService)
        {
            _httpService = httpService;

        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            Services = new ObservableCollection<ServicesWithId>(await _httpService.GetServiceNameAndId());
        }


        private async void SelectedServiceChanged()
        {
            var appointmentsBasedOnService = await _httpService.GetAppointmentsByServiceId(SelectedService.ServiceId);

            var listOfIds = new List<int>();
            foreach (var item in appointmentsBasedOnService)
                listOfIds.Add(item.PatientId);

            AppointmentsWithPatientId = new ObservableCollection<AppointmentsWithPatientId>
                (await _httpService.GetPatientAppointmentsBasedOnServiceId(SelectedService.ServiceId));
        }

        private async void SelectedAppointmentDateChanged()
        {
            AppointmentsWithPatientId = new ObservableCollection<AppointmentsWithPatientId>
                (await _httpService.GetPatientAppointmentsBasedOnServiceIdAndDate(SelectedService.ServiceId,
                SelectedAppointmentDate.Year, SelectedAppointmentDate.Month, SelectedAppointmentDate.Day));
        }

        
    }
}