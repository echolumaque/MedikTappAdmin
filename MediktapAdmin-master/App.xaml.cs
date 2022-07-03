using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.Views.AddEditPromos;
using MediktapAdmin.Views.AddEditPromos.ViewModel;
using MediktapAdmin.Views.AddEditServices;
using MediktapAdmin.Views.Appointments;
using MediktapAdmin.Views.Appointments.ViewModel;
using MediktapAdmin.Views.HelpWindow.ViewModel;
using MediktapAdmin.Views.MainWindows;
using MediktapAdmin.Views.MedikTappMenus;
using MedikTapp.Services.HttpService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace MediktapAdmin
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Current.MainWindow = new MedikTappMenu(ActivatorUtilities.CreateInstance<MedikTappMenuViewModel>(ServiceProvider));
            Current.MainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<NavigationService>()
                .AddSingleton<HttpService>()

                .AddTransient<MainWindowViewModel>()
                .AddTransient<AddEditPromoViewModel>()
                .AddTransient<HelpWindowViewModel>()
                .AddTransient<AppointmentViewModel>()
                .AddTransient<AddEditServiceViewModel>()
                .AddTransient<MedikTappMenuViewModel>();
        }
    }
}
