using MediktapAdmin.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedikTapp.Services.HttpService
{
    public interface IMedikTappApi
    {
        #region Services
        [Headers("x-functions-key : 6pEd_fiTFVTB3tR6OkjbgFW-OwHt4h38VlfV1br1NTAvAzFu_oeq-Q==")]
        [Post("/api/AddService")]
        public Task AddService(Service service);

        [Headers("x-functions-key : bfVH99ZkhaBIiY9KKSbrfn-MuQQjJ9gpad2-eDJVdkU3AzFu94stKg==")]
        [Get("/api/GetService")]
        public Task<IEnumerable<Service>> GetServices();

        [Headers("x-functions-key : sonKK22hiVFI8H2W47BYLGTx7A_tb3mdSHUh_vDOtwS9AzFuhHPfSw==")]
        [Get("/api/GetServiceNameAndId")]
        public Task<IEnumerable<ServiceNameAndId>> GetServiceNameAndId();

        [Headers("x-functions-key : noUdbqHzFatCfmP_lbBBfYTMTXNZGU2Im_uSe2OLylE0AzFu-wIEFw==")]
        [Put("/api/EditService")]
        public Task EditService(Service service);

        [Headers("x-functions-key : yls6-YZr6d8GgD4D1pUMULYyjdpiZY8JMGj__pF_di_VAzFuggSIOQ==")]
        [Delete("/api/DeleteService?serviceId={serviceId}")]
        public Task DeleteService(int serviceId);
        #endregion

        #region Appointments
        [Headers("x-functions-key : N9Wcep0oIotBjDXne2344-wRsUMHVRfdvjDnZgbNTZi5AzFuWOen1A==")]
        [Get("/api/GetAppointments?year={year}&month={month}&day={day}&serviceId={serviceId}")]
        public Task<IEnumerable<Appointments>> GetAppointments(int year, int month, int day, int serviceId);
        #endregion

        #region Promos
        [Headers("x-functions-key : Ag8-ptghu5s42DyQoR5ZqxA-_gjwlfv1_4QaHKHDRPTNAzFuFdMHCQ==")]
        [Post("/api/AddPromo")]
        Task<int> AddPromo(Service service);

        [Headers("x-functions-key : n8UzakNdDPgEFSjkFZv9ZQl9qsc0jTanPakzEVz4hCb9AzFuRZ4y8A==")]
        [Get("/api/GetPromo")]
        Task<IEnumerable<Service>> GetPromo();

        [Headers("x-functions-key : VS9Fq0KeRJmr6tnfOdN5Z2J2rFdZZavdO9g-sEwX4YSzAzFui1dEPg==")]
        [Put("/api/EditPromo")]
        Task EditPromo(Service service);

        [Headers("x-functions-key : if6Wuo4-imKg6yNKgTg4z5EGBFBwPpd9ad8IOwTbxaL-AzFu2Ksj4Q==")]
        [Delete("/api/DeletePromo?serviceId={serviceId}")]
        Task DeletePromo(int serviceId);
        #endregion
    }
}