using MediktapAdmin.Models;
using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.Templates;
using MediktapAdmin.ViewModels.Base;
using MedikTapp.Services.HttpService;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MediktapAdmin.Views.Services.ViewModel
{
    public partial class ServiceViewModel : BaseViewModel
    {
        private readonly HttpService _httpService;
        public ServiceViewModel(NavigationService navigationService, HttpService httpService) : base(navigationService)
        {
            _httpService = httpService;

            AddNewCmd = new Command(() => NavigationService.Goto<AddEditServices.AddEditService>());
            AddNewPromo = new Command(() => NavigationService.Goto<AddEditPromos.AddEditPromo>());
        }

        public override async void OnContentRendered()
        {
            Services = new ObservableCollection<Service>(await _httpService.GetServices()); 
        }


        public ObservableCollection <Service> Services { get; set; }
        public ICommand AddNewCmd { get; }
        public ICommand AddNewPromo { get; }
    }
}
