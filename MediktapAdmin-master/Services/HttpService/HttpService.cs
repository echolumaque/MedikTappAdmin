using MediktapAdmin.Constants;
using MediktapAdmin.Models;
using MediktapAdmin.Views.Appointments;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedikTapp.Services.HttpService
{
    public class HttpService
    {
        private readonly IMedikTappApi _medikTappApi;

        public HttpService()
        {
            _medikTappApi = RestService.For<IMedikTappApi>(MedikTappRemoteKeys.FunctionUrl,
                new RefitSettings(new SystemTextJsonContentSerializer()));
        }

        public Task<IEnumerable<Service>> GetServices() => _medikTappApi.GetService();

        public Task<IEnumerable<ServicesWithId>> GetServiceNameAndId() => _medikTappApi.GetServiceNameAndId();

        public Task<IEnumerable<Appointments>>  GetAppointmentsByDate (int year, int month, int day, int hour) => 
            _medikTappApi.GetAppointmentsByDate(year,month, day, hour );

        public Task AddService(Service service) => _medikTappApi.AddService(service);

        public Task AddPromo(Promo promo) => _medikTappApi.AddPromo(promo);

        Task DeleteService(Service service) => _medikTappApi.DeleteService(service);
        Task EditService(Service service) => _medikTappApi.DeleteService(service);

        public  Task<IEnumerable<Appointments>>  GetAppointmentsByServiceId(int serviceId) =>
            _medikTappApi.GetAppointmentsByServiceId(serviceId);

        

    }
}