using MediktapAdmin.Models;
using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.ViewModels.Base;
using MedikTapp.Services.HttpService;
using System;
using System.Collections.ObjectModel;
using System.Linq;

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
            var dateToday = DateTime.Now;
            var services = await _httpService.GetServices();
            Appointments = new ObservableCollection<Models.Appointments>(await _httpService.GetAppointments(dateToday.Year,
                dateToday.Month, dateToday.Day, services.First().ServiceId));

            ServiceNameAndId = new ObservableCollection<ServiceNameAndId>(await _httpService.GetServiceNameAndId());
            SelectedService = ServiceNameAndId.First();
        }

        private async void SelectedServiceChanged()
        {
            Appointments = new ObservableCollection<Models.Appointments>(await _httpService.GetAppointments(SelectedAppointmentDate.Year,
                SelectedAppointmentDate.Month, SelectedAppointmentDate.Day, SelectedService.ServiceId));
        }

        private async void SelectedAppointmentDateChanged()
        {
            Appointments = new ObservableCollection<Models.Appointments>(await _httpService.GetAppointments(SelectedAppointmentDate.Year,
                SelectedAppointmentDate.Month, SelectedAppointmentDate.Day, SelectedService.ServiceId));
        }
    }
}