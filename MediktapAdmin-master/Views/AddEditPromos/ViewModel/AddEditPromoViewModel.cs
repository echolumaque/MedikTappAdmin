using MediktapAdmin.Models;
using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.Services.PushNotificationService;
using MediktapAdmin.Templates;
using MediktapAdmin.ViewModels.Base;
using MedikTapp.Services.HttpService;

namespace MediktapAdmin.Views.AddEditPromos.ViewModel
{
    public partial class AddEditPromoViewModel : BaseViewModel
    {
        private readonly HttpService _httpService;
        private Service _passedPromo;
        private readonly PushNotificationService _pushNotificationService;

        public AddEditPromoViewModel(NavigationService navigationService,
            HttpService httpService,
            PushNotificationService pushNotificationService) : base(navigationService)
        {
            _httpService = httpService;
            _pushNotificationService = pushNotificationService;

            OpenImageCmd = new Command(OpenImage);
            AddPromoCmd = new Command(async () => await AddPromo());
            ClearFieldsCmd = new Command(ClearFields);
        }
    }
}
