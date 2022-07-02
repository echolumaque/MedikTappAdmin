using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.ViewModels.Base;
using MedikTapp.Services.HttpService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediktapAdmin.Views.Appointments.ViewModel
{
    public partial class AppointmentViewModel : BaseViewModel
    {
        private readonly HttpService _httpService;

        public AppointmentViewModel(NavigationService navigationService, HttpService httpService) : base(navigationService)
        {
            _httpService = httpService;
            
        }

        public  override  async void OnContentRendered()
        {
            Services = new System.Collections.ObjectModel.ObservableCollection<Models.ServicesWithId>(await _httpService.GetServiceNameAndId());

        }

        private async void SelectedServiceChanged()
        {
            
            var test = await _httpService.GetAppointmentsByServiceId(SelectedService.ServiceId);

        }

        private async void SelectedAppointmentDateChanged()
        {
            var test = await _httpService.GetAppointmentsByDate(SelectedAppointmentDate.Year, SelectedAppointmentDate.Month
                , SelectedAppointmentDate.Day, 7);
        }

        
        

    }
}
