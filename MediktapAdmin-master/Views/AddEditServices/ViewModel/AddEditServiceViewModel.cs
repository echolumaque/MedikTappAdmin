using MediktapAdmin.Models;
using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.Templates;
using MediktapAdmin.ViewModels.Base;
using MedikTapp.Services.HttpService;
using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace MediktapAdmin.Views.AddEditServices
{
    public partial class AddEditServiceViewModel : BaseViewModel
    {
        private readonly HttpService _httpService;
        private Stream _imageStream;

        public AddEditServiceViewModel(NavigationService navigationService, HttpService httpService) : base(navigationService)
        {
            _httpService = httpService;

            AddServiceCmd = new Command(async () => await AddService());
            OpenImageCmd = new Command(OpenImage);
        }

        private ConfiguredTaskAwaitable AddService()
        {
            using var ms = new MemoryStream();
            _imageStream.CopyTo(ms);

            return _httpService.AddService(new Service
            {
                IsPromo = false,
                ServiceDescription = ServiceDescription,
                ServiceImage = Convert.ToBase64String(ms.ToArray()),
                ServiceName = ServiceName,
                ServicePrice = ServicePrice
            });
        }

        private void OpenImage()
        {
            var openDialog = new OpenFileDialog
            {
                Title = "Select the service image",
                AddExtension = true,
                ValidateNames = true,
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png| JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg| Portable Network Graphic (*.png)|*.png"
            };

            if (openDialog.ShowDialog().Value)
            {
                _imageStream = openDialog.OpenFile();
                ServiceImage = openDialog.FileName;
            }
        }
    }
}