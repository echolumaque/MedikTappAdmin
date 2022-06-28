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

        public ConfiguredTaskAwaitable<IEnumerable<Service>> GetServices() =>
            _medikTappApi.GetService().ConfigureAwait(false);

        public ConfiguredTaskAwaitable AddService(Service service) =>
            _medikTappApi.AddService(service).ConfigureAwait(false);
    }
}