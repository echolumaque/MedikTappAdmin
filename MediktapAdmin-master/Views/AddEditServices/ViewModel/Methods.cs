using MediktapAdmin.Models;
using MediktapAdmin.Services.NavigationService;
using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MediktapAdmin.Views.AddEditServices
{
    public partial class AddEditServiceViewModel
    {
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            _memoryStream = new MemoryStream();
            if (parameters.Count > 0)
            {
                _passedService = parameters.GetValue<Service>("selectedService");
                AddEditServiceText = parameters.GetValue<bool>("isEdit") ? "Edit Service" : "Add Service";
                var byteArr = Convert.FromBase64String(_passedService.ServiceImage);
                _memoryStream.Write(byteArr, 0, byteArr.Length);

                ServiceName = _passedService.ServiceName;
                ServiceDescription = _passedService.ServiceDescription;
                ServicePrice = _passedService.ServicePrice;
                ServiceImage = BitmapFrame.Create(_memoryStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);


            }
            else
            {
                AddEditServiceText = "Save";
                ServiceName = "";
                ServiceDescription = "";
                ServicePrice = 0;

                var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("MediktapAdmin.Assets.img-placeholder.png");
                resource.CopyTo(_memoryStream);
                ServiceImage = BitmapFrame.Create(_memoryStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            _memoryStream.Dispose();
        }

        private async Task AddOrEditService()
        {
            if (AddEditServiceText == "Add Service")
            {
                _imageStream.CopyTo(_memoryStream);
                await _httpService.AddService(new Service
                {
                    IsPromo = false,
                    ServiceDescription = ServiceDescription,
                    ServiceImage = Convert.ToBase64String(_memoryStream.ToArray()),
                    ServiceName = ServiceName,
                    ServicePrice = ServicePrice
                }).ConfigureAwait(false);

                MessageBox.Show("Service has been added to MedikTapp's database", "Service added");
                _memoryStream.SetLength(0);
            }
            else
            {
                await _httpService.EditService(new Service
                {
                    IsPromo = false,
                    ServiceDescription = ServiceDescription,
                    ServiceImage = Convert.ToBase64String(_memoryStream.ToArray()),
                    ServiceName = ServiceName,
                    ServicePrice = ServicePrice,
                    ServiceId = _passedService.ServiceId
                }).ConfigureAwait(false);

                MessageBox.Show("Service has been edited to MedikTapp's database", "Service edited");
                _memoryStream.SetLength(0);
            }

            //Reset values
            var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("MediktapAdmin.Assets.img-placeholder.png");
            resource.CopyTo(_memoryStream);
            ServiceImage = BitmapFrame.Create(_memoryStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

            ServiceName = string.Empty;
            ServiceDescription = string.Empty;
            ServicePrice = default;
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

                ServiceImage = BitmapFrame.Create(_imageStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }
    }
}