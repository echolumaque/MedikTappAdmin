using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.Templates;
using MediktapAdmin.ViewModels.Base;
using MediktapAdmin.Views.MedikTappMenus;
using System.Windows.Input;

namespace MediktapAdmin.Views.MainWindows
{
    public class MainWindowViewModel : BaseViewModel
    {

        public MainWindowViewModel(NavigationService navigationService) : base(navigationService)
        {
            LoginCmd = new Command(() => NavigationService.GoTo<MedikTappMenu>());

            helpCmd = new Command(() => NavigationService.GoTo<HelpWindow.HelpWindow>());
        }

        public ICommand helpCmd { get; set; }
        public ICommand LoginCmd { get; }

    }
}