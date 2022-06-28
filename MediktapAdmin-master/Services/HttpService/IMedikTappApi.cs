using MediktapAdmin.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedikTapp.Services.HttpService
{
    public interface IMedikTappApi
    {
        #region Services
        [Headers("x-functions-key : bfVH99ZkhaBIiY9KKSbrfn-MuQQjJ9gpad2-eDJVdkU3AzFu94stKg==")]
        [Get("/api/GetService")]
        Task<IEnumerable<Service>> GetService();

        [Headers("x-functions-key : 6pEd_fiTFVTB3tR6OkjbgFW-OwHt4h38VlfV1br1NTAvAzFu_oeq-Q==")]
        [Post("/api/AddService")]
        Task AddService([Body(BodySerializationMethod.Serialized)] Service service);
        #endregion
    }
}