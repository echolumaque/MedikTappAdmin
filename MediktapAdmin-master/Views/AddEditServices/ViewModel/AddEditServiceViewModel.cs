using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.Templates;
using MediktapAdmin.ViewModels.Base;
using MedikTapp.Services.HttpService;
using System.IO;

namespace MediktapAdmin.Views.AddEditServices
{
    public partial class AddEditServiceViewModel : BaseViewModel
    {
        private readonly HttpService _httpService;
        private MemoryStream _memoryStream;
        private Stream _imageStream;

        public AddEditServiceViewModel(NavigationService navigationService, HttpService httpService) : base(navigationService)
        {
            _httpService = httpService;

            AddServiceCmd = new Command(async () => await AddService());
            OpenImageCmd = new Command(OpenImage);
            ClearFieldsCmd = new Command(() =>
            {
                ServiceImage = "/Assets/img-placeholder.png";
                ServiceName = string.Empty;
                ServiceDescription = string.Empty;
                ServicePrice = default;
            });
        }
    }
}