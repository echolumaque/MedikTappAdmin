using MediktapAdmin.Models;
using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.Templates;
using MediktapAdmin.ViewModels.Base;
using MedikTapp.Services.HttpService;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

            AddNewCmd = new Command(() => NavigationService.GoTo<AddEditServices.AddEditService>());
            EditCmd = new Command(async () => await EditService());
            DeleteCmd = new Command(async () => await DeleteService());
        }

        public ObservableCollection<Service> Services { get; set; }
        public ObservableCollection<Promo> Promos { get; set; }
        public Promo SelectedPromo { get; set; }
        public ICommand AddNewCmd { get; set; }
        public ICommand EditCmd { get; set; }
        public ICommand DeleteCmd { get; set; }
        public string AddButtonText { get; set; }
        public string EditButtonText { get; set; }
        public string DeleteButtonText { get; set; }
        public Service SelectedService { get; set; }
        [OnChangedMethod(nameof(SelectedTabChanged))]
        public TabItem SelectedTab { get; set; }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            Services = new ObservableCollection<Service>(await _httpService.GetServices());
            Promos = new ObservableCollection<Promo>(await _httpService.GetPromos());
        }

        private void SelectedTabChanged()
        {
            if (SelectedTab.Header.ToString() == "Service")
            {
                AddButtonText = "Add Service";
                EditButtonText = "Edit Service";
                DeleteButtonText = "Delete Service";
                AddNewCmd = new Command(() => NavigationService.GoTo<AddEditServices.AddEditService>());
                EditCmd = new Command(async () => await EditService());
                DeleteCmd = new Command(async () => await DeleteService());
            }
            else
            {
                AddButtonText = "Add Promo";
                EditButtonText = "Edit Promo";
                DeleteButtonText = "Delete Promo";
                AddNewCmd = new Command(() => NavigationService.GoTo<AddEditPromos.AddEditPromo>());
                EditCmd = new Command(async () => await EditPromo());
                DeleteCmd = new Command(async () => await DeletePromo());
            }
        }

        private async Task EditService()
        {
            NavigationService.GoTo<AddEditServices.AddEditService>(new NavigationParameters()
            {
                { "selectedService", SelectedService },
                { "isEdit", true }
            });
            Services = new ObservableCollection<Service>(await _httpService.GetServices());
        }

        private async Task DeleteService()
        {
            await _httpService.DeleteService(SelectedService.ServiceId);
            Services = new ObservableCollection<Service>(await _httpService.GetServices());
        }

        private async Task EditPromo()
        {
            NavigationService.GoTo<AddEditPromos.AddEditPromo>(new NavigationParameters()
            {
                { "selectedPromo", SelectedPromo },
                { "isEdit", true }
            });
            Promos = new ObservableCollection<Promo>(await _httpService.GetPromos());
        }

        private async Task DeletePromo()
        {
            await _httpService.DeletePromo(SelectedPromo.PromoId);
            Promos = new ObservableCollection<Promo>(await _httpService.GetPromos());
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            Services = new()
            {
                new()
                {
                    ServiceImage = "/Assets/docImage.png",
                }
            };
        }
    }
}