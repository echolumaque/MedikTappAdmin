using MediktapAdmin.Constants;
using MediktapAdmin.Models;
using Refit;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
        public ConfiguredTaskAwaitable AddService(Service service)
        {
            return _medikTappApi.AddService(service).ConfigureAwait(false);
        }

        public ConfiguredTaskAwaitable<IEnumerable<Service>> GetServices()
        {
            return _medikTappApi.GetServices().ConfigureAwait(false);
        }

        public ConfiguredTaskAwaitable<IEnumerable<ServiceNameAndId>> GetServiceNameAndId()
        {
            return _medikTappApi.GetServiceNameAndId().ConfigureAwait(false);
        }

        public ConfiguredTaskAwaitable EditService(Service service)
        {
            return _medikTappApi.EditService(service).ConfigureAwait(false);
        }

        public ConfiguredTaskAwaitable DeleteService(int serviceId)
        {
            return _medikTappApi.DeleteService(serviceId).ConfigureAwait(false);
        }
        #endregion

        #region Appointments
        public ConfiguredTaskAwaitable<IEnumerable<Appointments>> GetAppointments(int year, int month, int day, int serviceId)
        {
            return _medikTappApi.GetAppointments(year, month, day, serviceId).ConfigureAwait(false);
        }
        #endregion

        #region Promos
        public ConfiguredTaskAwaitable<int> AddPromo(Service service)
        {
            return _medikTappApi.AddPromo(service).ConfigureAwait(false);
        }

        public ConfiguredTaskAwaitable<IEnumerable<Service>> GetPromos()
        {
            return _medikTappApi.GetPromo().ConfigureAwait(false);
        }

        public ConfiguredTaskAwaitable EditPromo(Service service)
        {
            return _medikTappApi.EditPromo(service).ConfigureAwait(false);
        }

        public ConfiguredTaskAwaitable DeletePromo(int serviceId)
        {
            return _medikTappApi.DeletePromo(serviceId).ConfigureAwait(false);
        }
        #endregion
    }
}