using MediktapAdmin.Models;
using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.Templates;
using MediktapAdmin.ViewModels.Base;
using MedikTapp.Services.HttpService;

namespace MediktapAdmin.Views.AddEditServices
{
    public partial class AddEditServiceViewModel : BaseViewModel
    {
        private readonly HttpService _httpService;
        private Service _passedService;

        public AddEditServiceViewModel(NavigationService navigationService, HttpService httpService) : base(navigationService)
        {
            _httpService = httpService;

            AddSOrEditerviceCmd = new Command(async () => await AddOrEditService());
            OpenImageCmd = new Command(OpenImage);
            ClearFieldsCmd = new Command(ClearFields);
        }
    }
}