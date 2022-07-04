using MediktapAdmin.Models;
using MediktapAdmin.Services.NavigationService;
using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MediktapAdmin.Views.AddEditPromos.ViewModel
{
    public partial class AddEditPromoViewModel
    {
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            _memoryStream = new MemoryStream();
            if (parameters.Count > 0)
            {
                _passedPromo = parameters.GetValue<Promo>("selectedPromo");
                AddEditPromoText = parameters.GetValue<bool>("isEdit") ? "Edit Service" : "Add Service";
                var byteArr = Convert.FromBase64String(_passedPromo.PromoImage);
                _memoryStream.Write(byteArr, 0, byteArr.Length);

                PromoName = _passedPromo.PromoName;
                PromoDescription = _passedPromo.PromoDescription;
                PromoPrice = _passedPromo.PromoPrice;
                StartDate = _passedPromo.StartDate;
                EndDate = _passedPromo.EndDate;
                PromoImage = BitmapFrame.Create(_memoryStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
            else
            {
                AddEditPromoText = "Add Promo";
                PromoName = "";
                PromoDescription = "";
                PromoPrice = 0;
                StartDate = DateTime.Now;
                EndDate = DateTime.Now;

                var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("MediktapAdmin.Assets.img-placeholder.png");
                resource.CopyTo(_memoryStream);
                PromoImage = BitmapFrame.Create(_memoryStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
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
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png| JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg| Portable Network Graphic (*.png)|*.png"
            };
            if (openDialog.ShowDialog().Value)
            {
                _imageStream = openDialog.OpenFile();
                PromoImage = BitmapFrame.Create(_imageStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }


        }
        private async Task AddPromo()
        {
            if (AddEditPromoText == "Add Promo")
            {
                _imageStream.CopyTo(_memoryStream);
                await _httpService.AddPromo(new Promo
                {
                    PromoDescription = PromoDescription,
                    PromoImage = Convert.ToBase64String(_memoryStream.ToArray()),
                    PromoName = PromoName,
                    PromoPrice = PromoPrice,
                    EndDate = EndDate,
                    StartDate = StartDate
                }).ConfigureAwait(false);

                MessageBox.Show("Promo has been added to MedikTapp's database", "Service added");
                _memoryStream.SetLength(0);
            }
            else
            {
                await _httpService.EditPromo(new Promo
                {
                    PromoDescription = PromoDescription,
                    PromoImage = Convert.ToBase64String(_memoryStream.ToArray()),
                    PromoName = PromoName,
                    PromoPrice = PromoPrice,
                    PromoId = _passedPromo.PromoId,
                    EndDate = EndDate,
                    StartDate = StartDate
                }).ConfigureAwait(false);

                MessageBox.Show("Promo has been edited to MedikTapp's database", "Service edited");
                _memoryStream.SetLength(0);
            }

            //Reset values
            var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("MediktapAdmin.Assets.img-placeholder.png");
            resource.CopyTo(_memoryStream);
            PromoImage = BitmapFrame.Create(_memoryStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

            PromoName = string.Empty;
            PromoDescription = string.Empty;
            PromoPrice = default;
        }
    }
}