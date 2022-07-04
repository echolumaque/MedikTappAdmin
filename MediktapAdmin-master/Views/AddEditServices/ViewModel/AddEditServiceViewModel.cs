using MediktapAdmin.Models;
using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.Templates;
using MediktapAdmin.ViewModels.Base;
using MedikTapp.Services.HttpService;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace MediktapAdmin.Views.AddEditServices
{
    public partial class AddEditServiceViewModel : BaseViewModel
    {
        private readonly HttpService _httpService;
        private MemoryStream _memoryStream;
        private Stream _imageStream;
        private Service _passedService;
        private readonly BitmapImage _byteArrayImageSource;

        public AddEditServiceViewModel(NavigationService navigationService, HttpService httpService) : base(navigationService)
        {
            _httpService = httpService;

            AddSOrEditerviceCmd = new Command(async () => await AddOrEditService());
            OpenImageCmd = new Command(OpenImage);
            ClearFieldsCmd = new Command(() =>
            {
                var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("MediktapAdmin.Assets.img-placeholder.png");
                resource.CopyTo(_memoryStream);
                var imageSource = new BitmapImage();
                imageSource.BeginInit();
                imageSource.StreamSource = _memoryStream;
                imageSource.EndInit();
                ServiceImage = imageSource;

                ServiceName = string.Empty;
                ServiceDescription = string.Empty;
                ServicePrice = default;
            });
        }
    }
}