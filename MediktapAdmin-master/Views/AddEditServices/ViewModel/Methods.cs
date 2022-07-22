using MediktapAdmin.Models;
using MediktapAdmin.Services.NavigationService;
using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MediktapAdmin.Views.AddEditServices
{
    public partial class AddEditServiceViewModel
    {
        private async Task AddOrEditService()
        {
            if (AddEditServiceText == "Save")
            {
                await _httpService.AddService(new Service
                {
                    ServiceDescription = ServiceDescription,
                    ServiceImage = ImageToBase64(ServiceImage),
                    ServiceName = ServiceName,
                    ServicePrice = ServicePrice
                });

                MessageBox.Show("Service has been added to MedikTapp's database", "Service added");
            }
            else
            {
                await _httpService.EditService(new Service
                {
                    ServiceDescription = ServiceDescription,
                    ServiceImage = ImageToBase64(ServiceImage),
                    ServiceName = ServiceName,
                    ServicePrice = ServicePrice,
                    ServiceId = _passedService.ServiceId
                });

                MessageBox.Show("Service has been edited to MedikTapp's database", "Service edited");
            }

            //Reset values
            var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("MediktapAdmin.Assets.img-placeholder.png");
            ServiceImage = StreamToImage(resource);

            ServiceName = string.Empty;
            ServiceDescription = string.Empty;
            ServicePrice = default;
        }

        private ImageSource Base64ToImage(string base64String)
        {
            var byteArr = Convert.FromBase64String(base64String);
            using var memStream = new MemoryStream();
            memStream.Write(byteArr, 0, byteArr.Length);
            return BitmapFrame.Create(memStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }

        private void ClearFields()
        {
            var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("MediktapAdmin.Assets.img-placeholder.png");
            ServiceImage = StreamToImage(resource);

            ServiceName = string.Empty;
            ServiceDescription = string.Empty;
            ServicePrice = default;
        }

        private string ImageToBase64(ImageSource imageSource)
        {
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageSource as BitmapSource));
            using var memStream = new MemoryStream();
            encoder.Save(memStream);

            return Convert.ToBase64String(memStream.ToArray());
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
                var imageStream = openDialog.OpenFile();
                ServiceImage = StreamToImage(imageStream);
            }
        }

        private ImageSource StreamToImage(Stream stream)
        {
            return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.Count > 0)
            {
                _passedService = parameters.GetValue<Service>("selectedService");
                AddEditServiceText = parameters.GetValue<bool>("isEdit") ? "Edit Service" : "Add Service";

                ServiceName = _passedService.ServiceName;
                ServiceDescription = _passedService.ServiceDescription;
                ServicePrice = _passedService.ServicePrice;
                ServiceImage = Base64ToImage(_passedService.ServiceImage);

            }
            else
            {
                AddEditServiceText = "Save";
                ServiceName = "";
                ServiceDescription = "";
                ServicePrice = 0;

                var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("MediktapAdmin.Assets.img-placeholder.png");
                ServiceImage = StreamToImage(resource);
            }
        }
    }
}