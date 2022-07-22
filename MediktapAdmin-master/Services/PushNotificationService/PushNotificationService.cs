using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediktapAdmin.Services.PushNotificationService
{
    public class PushNotificationService
    {
        public PushNotificationService()
        {
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile("MedikTappFCMKey.json")
            });
        }

        public Task SendPushNotification(string promoName, string promoDescription, int promoNotifId)
        {
            var notificationMessagePayload = new Message
            {
                Topic = "promo",
                Notification = new Notification
                {
                    Title = promoName,
                    Body = promoDescription,
                },
                Data = new Dictionary<string, string>
                {
                    { "title", promoName },
                    { "body", promoDescription },
                    { "promoNotifId", promoNotifId.ToString() }
                }
            };

            return FirebaseMessaging.DefaultInstance.SendAsync(notificationMessagePayload);
        }
    }
}