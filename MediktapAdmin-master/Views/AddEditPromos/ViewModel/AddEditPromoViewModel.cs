using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.Templates;
using MediktapAdmin.ViewModels.Base;
using MedikTapp.Services.HttpService;
using System.IO;

namespace MediktapAdmin.Views.AddEditPromos.ViewModel
{
    public partial class AddEditPromoViewModel : BaseViewModel
    {
        

        private MemoryStream _memoryStream;
        private Stream _imageStream;
        private readonly HttpService _httpService;

        public AddEditPromoViewModel(NavigationService navigationService, HttpService httpService) : base(navigationService)
        {
            _httpService = httpService;
            OpenImageCmd = new Command(OpenImage);
            AddPromoCmd = new Command(async () => await AddPromo());

            ClearFieldsCmd = new Command(() =>
            {
                PromoName = string.Empty;
                PromoDesrcripton = string.Empty;
                PromoImage = "/Assets/img-placeholder.png";
                PromoPrice = default;

            });

        }

       
    }
}
