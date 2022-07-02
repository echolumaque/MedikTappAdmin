using MediktapAdmin.Models;
using Microsoft.Win32;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace MediktapAdmin.Views.AddEditServices
{
    public partial class AddEditServiceViewModel
    {
        public override void OnContentRendered()
        {
            _memoryStream = new MemoryStream();
        }

        public override void OnClosed()
        {
            _memoryStream.Dispose();
        }

        private async Task AddService()
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
            //_imageStream.SetLength(0);
            _memoryStream.SetLength(0);

            ServiceImage = "/Assets/img-placeholder.png";
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
                ServiceImage = openDialog.FileName;
            }
        }
    }
}