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

        public Task<IEnumerable<Service>> GetServices() => _medikTappApi.GetService();

        public Task AddService(Service service) => _medikTappApi.AddService(service);
    }
}