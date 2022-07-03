using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.Templates;
using MediktapAdmin.ViewModels.Base;
using System.Windows.Input;

namespace MediktapAdmin.Views.MedikTappMenus
{
    public class MedikTappMenuViewModel : BaseViewModel
    {
        public MedikTappMenuViewModel(NavigationService navigationService) : base(navigationService)
        {
            GotoServicesCmd = new Command(() => NavigationService.Goto<Services.Services>());
            helpCmd = new Command(() => NavigationService.Goto<HelpWindow.HelpWindow>());
        }
        public ICommand GotoAppointmentsCmd { get; }
        public ICommand GotoServicesCmd { get; }
        public ICommand helpCmd { get; }
    }
}