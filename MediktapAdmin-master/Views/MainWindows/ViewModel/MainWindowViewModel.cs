using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.Templates;
using MediktapAdmin.ViewModels.Base;
using MediktapAdmin.Views.MedikTappMenus;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MediktapAdmin.Views.MainWindows
{
    public class MainWindowViewModel : BaseViewModel
    {

        public MainWindowViewModel(NavigationService navigationService) : base(navigationService)
        {
            LoginCmd = new Command<PasswordBox>(Login);

            helpCmd = new Command(() => NavigationService.GoTo<HelpWindow.HelpWindow>());
        }

        public ICommand helpCmd { get; set; }
        public ICommand LoginCmd { get; }
        public string Username { get; set; }
        public PasswordBox Password { get; set; }

        private void Login(PasswordBox passwordBox)
        {
            if (Username == "admin" && passwordBox.Password == "1234")
                NavigationService.GoTo<MedikTappMenu>();
            else
                MessageBox.Show("You entered a wrong password, please try again", "Wrong password");
        }
    }
}