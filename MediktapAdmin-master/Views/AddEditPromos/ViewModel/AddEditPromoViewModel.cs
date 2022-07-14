using MediktapAdmin.Models;
using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.Services.PushNotificationService;
using MediktapAdmin.Templates;
using MediktapAdmin.ViewModels.Base;
using MedikTapp.Services.HttpService;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace MediktapAdmin.Views.AddEditPromos.ViewModel
{
    public partial class AddEditPromoViewModel : BaseViewModel
    {
        private MemoryStream _memoryStream;
        private Stream _imageStream;
        private readonly HttpService _httpService;
        private Promo _passedPromo;
        private readonly PushNotificationService _pushNotificationService;

        public AddEditPromoViewModel(NavigationService navigationService,
            HttpService httpService,
            PushNotificationService pushNotificationService) : base(navigationService)
        {
            _httpService = httpService;
            _pushNotificationService = pushNotificationService;

            OpenImageCmd = new Command(OpenImage);
            AddPromoCmd = new Command(async () => await AddPromo());
            ClearFieldsCmd = new Command(() =>
            {
                var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("MediktapAdmin.Assets.img-placeholder.png");
                resource.CopyTo(_memoryStream);
                var imageSource = new BitmapImage();
                imageSource.BeginInit();
                imageSource.StreamSource = _memoryStream;
                imageSource.EndInit();
                PromoImage = imageSource;

                PromoName = string.Empty;
                PromoDescription = string.Empty;
                PromoPrice = default;

            });
        }
    }
}
