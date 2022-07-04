using MediktapAdmin.Constants;
using MediktapAdmin.Models;
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

        #region Services
        public Task<IEnumerable<Service>> GetServices() => _medikTappApi.GetService();
        public Task<IEnumerable<ServicesWithId>> GetServiceNameAndId() => _medikTappApi.GetServiceNameAndId();
        public Task AddService(Service service) => _medikTappApi.AddService(service);
        public Task DeleteService(int serviceId) => _medikTappApi.DeleteService(serviceId);
        public Task EditService(Service service) => _medikTappApi.EditService(service);
        #endregion

        #region Appointments
        public Task<IEnumerable<Appointments>> GetAppointmentsByDate(int year, int month, int day, int hour) =>
            _medikTappApi.GetAppointmentsByDate(year, month, day, hour);
        public Task<IEnumerable<Appointments>> GetAppointmentsByServiceId(int serviceId) =>
            _medikTappApi.GetAppointmentsByServiceId(serviceId);

        public Task<IEnumerable<AppointmentsWithPatientId>> GetPatientAppointmentsBasedOnServiceId(int servicecId)
            => _medikTappApi.GetPatientAppointmentsBasedOnServiceId(servicecId);

        public Task<IEnumerable<AppointmentsWithPatientId>> GetPatientAppointmentsBasedOnServiceIdAndDate(int serviceId, int year,
            int month, int day) => _medikTappApi.GetPatientAppointmentsBasedOnServiceIdAndDate(serviceId, year, month, day);
        #endregion

        #region Promos
        public Task<IEnumerable<Promo>> GetPromos() => _medikTappApi.GetPromos();
        public Task AddPromo(Promo promo) => _medikTappApi.AddPromo(promo);
        public Task EditPromo(Promo promo) => _medikTappApi.EditPromo(promo);
        public Task DeletePromo(int serviceId) => _medikTappApi.DeletePromo(serviceId);
        #endregion
    }
}