using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Windows;

namespace MediktapAdmin.Services.NavigationService
{
    public class NavigationService
    {
        public void Goto<TWindow>() where TWindow : Window
        {
            var destinationWindow = ActivatorUtilities.CreateInstance<TWindow>(App.ServiceProvider);
            var currentWindow = Application.Current.Windows.OfType<Window>()
                .SingleOrDefault(x => x.IsActive);
            currentWindow.Close();
            destinationWindow.Show();
        }
    }
}
