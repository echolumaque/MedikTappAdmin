using MediktapAdmin.Services.NavigationService;
using Microsoft.Win32;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MediktapAdmin.Views.AddEditPromos.ViewModel
{
    public partial class AddEditPromoViewModel
    {
        private async Task AddPromo()
        {
            if (AddEditPromoText == "Save")
            {
                var newPromoId = await _httpService.AddPromo(new Models.Service
                {
                    ServiceDescription = PromoDescription,
                    ServiceImage = ImageToBase64(PromoImage),
                    ServiceName = $"(Promo) {PromoName}",
                    ServicePrice = PromoPrice,
                    EndDate = EndDate,
                    StartDate = StartDate
                });

                var promoDescription = $"{PromoDescription}\nPrice starts at {PromoPrice.ToString("C", CultureInfo.GetCultureInfo("fil-PH"))}\nPromo period: {StartDate:MMMM dd, yyyy} - {EndDate:MMMM dd, yyyy}";
                await _pushNotificationService.SendPushNotification(PromoName, promoDescription, newPromoId);

                MessageBox.Show("Promo has been added to MedikTapp's database", "Promo added");
            }
            else
            {
                await _httpService.EditPromo(new Models.Service
                {
                    ServiceDescription = PromoDescription,
                    ServiceImage = ImageToBase64(PromoImage),
                    ServiceName = PromoName,
                    ServicePrice = PromoPrice,
                    ServiceId = _passedPromo.ServiceId,
                    EndDate = EndDate,
                    StartDate = StartDate
                });

                MessageBox.Show("Promo has been edited to MedikTapp's database", "Promo edited");
            }

            //Reset values
            var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("MediktapAdmin.Assets.img-placeholder.png");
            PromoImage = StreamToImage(resource);

            PromoName = string.Empty;
            PromoDescription = string.Empty;
            PromoPrice = default;
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
            PromoImage = StreamToImage(resource);

            PromoName = string.Empty;
            PromoDescription = string.Empty;
            PromoPrice = default;
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
                Title = "Select the promo image ",
                AddExtension = true,
                ValidateNames = true,
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png| JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg| Portable Network Graphic (*.png)|*.png"
            };
            if (openDialog.ShowDialog().Value)
            {
                var stream = openDialog.OpenFile();
                PromoImage = StreamToImage(stream);
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
                _passedPromo = parameters.GetValue<Models.Service>("selectedPromo");
                AddEditPromoText = parameters.GetValue<bool>("isEdit") ? "Edit Service" : "Add Service";

                PromoName = _passedPromo.ServiceName;
                PromoDescription = _passedPromo.ServiceDescription;
                PromoPrice = _passedPromo.ServicePrice;
                StartDate = _passedPromo.StartDate.Value;
                EndDate = _passedPromo.EndDate.Value;
                PromoImage = Base64ToImage(_passedPromo.ServiceImage);
            }
            else
            {
                AddEditPromoText = "Save";
                PromoName = "";
                PromoDescription = "";
                PromoPrice = 0;
                StartDate = DateTime.Now;
                EndDate = DateTime.Now.AddDays(1);

                var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("MediktapAdmin.Assets.img-placeholder.png");
                PromoImage = StreamToImage(resource);
            }
        }
    }
}