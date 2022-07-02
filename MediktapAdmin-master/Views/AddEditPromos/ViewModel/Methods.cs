using MediktapAdmin.Models;
using Microsoft.Win32;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace MediktapAdmin.Views.AddEditPromos.ViewModel
{
    public partial class AddEditPromoViewModel
    {
        public override void OnContentRendered()
        {
            _memoryStream = new MemoryStream();
        }

        public override void OnClosed()
        {
            _memoryStream.Dispose();
        }
        private void OpenImage()
        {
            var openDialog = new OpenFileDialog
            {
                Title = "Select the promo Image ",
                AddExtension = true,
                ValidateNames = true,
                Filter= "All supported graphics|*.jpg;*.jpeg;*.png| JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg| Portable Network Graphic (*.png)|*.png"
            };
            if (openDialog.ShowDialog().Value)
            {
                _imageStream = openDialog.OpenFile();
                PromoImage = openDialog.FileName;
            }


        }
        private async Task AddPromo()
        {
            _imageStream.CopyTo(_memoryStream);

            await _httpService.AddPromo(new Promo
            {
                PromoDescription = PromoDesrcripton,
                PromoName = PromoName,
                PromoImage = Convert.ToBase64String(_memoryStream.ToArray()),
                PromoPrice = PromoPrice
            }).ConfigureAwait(false);

            MessageBox.Show("Promo has been added to MedikTapp's database", "Promo added");
            _memoryStream.SetLength(0);

            PromoImage = "Assets/img-placeholder.png";
            PromoName = string.Empty;
            PromoDesrcripton = string.Empty;
            PromoPrice = default;
            

        }
    }
}
