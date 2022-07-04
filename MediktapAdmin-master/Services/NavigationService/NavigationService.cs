﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows;

namespace MediktapAdmin.Services.NavigationService
{
    public class NavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Window GetCurrentWindow() => Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

        public void GoTo<TWindow>(NavigationParameters parameters = null) where TWindow : Window
        {
            var destinationWindow = ActivatorUtilities.CreateInstance<TWindow>(_serviceProvider);
            NavigationUtilities.DoNavigate(GetCurrentWindow(), destinationWindow, parameters,
                () => PerformNavigationEvents(GetCurrentWindow(), destinationWindow));
        }

        private void PerformNavigationEvents(Window currentWindow, Window destinationWindow)
        {
            currentWindow.Close();
            destinationWindow.Show();
        }
    }
}