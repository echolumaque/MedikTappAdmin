using MediktapAdmin.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MediktapAdmin.Services.NavigationService
{
    public static class NavigationUtilities
    {
        public static bool IsSystemBackButtonPressed = true;

        public static void DoNavigate(Window fromPage, Window toPage, NavigationParameters parameters, Action action)
        {
            var navParameters = parameters ?? new();
            InvokeOnNavigatedFrom(fromPage, navParameters);
            InvokeSetBindings(toPage, navParameters);
            action();
            InvokeOnNavigatedTo(toPage, navParameters);
            IsSystemBackButtonPressed = true;
        }

        public static async Task DoNavigateAsync(Window fromPage, Window toPage, NavigationParameters parameters, Func<Task> action)
        {
            var navParameters = parameters ?? new();
            InvokeOnNavigatedFrom(fromPage, navParameters);
            InvokeSetBindings(toPage, navParameters);
            await action();
            InvokeOnNavigatedTo(toPage, navParameters);
            IsSystemBackButtonPressed = true;
        }

        public static void InvokeNavigatedEvents(Window fromPage, Window toPage, NavigationParameters parameters)
        {
            var navParameters = parameters ?? new();
            InvokeOnNavigatedFrom(fromPage, navParameters);
            InvokeSetBindings(toPage, navParameters);
            InvokeOnNavigatedTo(toPage, navParameters);
            IsSystemBackButtonPressed = true;
        }

        private static void InvokeOnNavigatedFrom(Window page, NavigationParameters parameters)
        {
            if (page != null)
            {
                if (page.DataContext is BaseViewModel vm) vm.OnNavigatedFrom(parameters);
            }

        }

        private static void InvokeOnNavigatedTo(Window page, NavigationParameters parameters)
        {
            if (page != null)
            {
                if (page.DataContext is BaseViewModel vm) vm.OnNavigatedTo(parameters);
            }
        }

        private static void InvokeSetBindings(Window page, NavigationParameters parameters)
        {
            if (page != null)
            {
                if (page.DataContext is BaseViewModel vm) vm.SetBindings(parameters);
            }
        }
    }
}