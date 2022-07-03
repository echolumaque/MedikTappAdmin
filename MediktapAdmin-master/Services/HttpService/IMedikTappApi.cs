using MediktapAdmin.Models;
using MediktapAdmin.Views.Appointments;
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

        [Headers("x-functions-key : Ag8-ptghu5s42DyQoR5ZqxA-_gjwlfv1_4QaHKHDRPTNAzFuFdMHCQ==")]
        [Post("/api/AddPromo")]
        
        Task AddPromo ([Body(BodySerializationMethod.Serialized)] Promo promo);

        [Headers("x-functions-key : l-RVwmtpSC3kNIhZqTrr1e9MGRLWEcf6G9y7DSEUepDCAzFuseNwWg==")]
        [Get("/api/GetAppointmentsByServiceId?serviceId={serviceId}")]
        Task<IEnumerable<Appointments>> GetAppointmentsByServiceId(int serviceId);

        [Headers("x-functions-key : sonKK22hiVFI8H2W47BYLGTx7A_tb3mdSHUh_vDOtwS9AzFuhHPfSw==")]
        [Get("/api/GetServiceNameAndId")]
        Task<IEnumerable<ServicesWithId>> GetServiceNameAndId();



        [Headers("x-functions-key : swcCdvqL0MMZ2gsSgwXAqEFSkbEtuvJ4Ip3-kMYeYma8AzFuDSJFGw==")]
        [Get("/api/GetAppointmentsByDate?year={year}&month={month}&day={day}&hour={hour}")]
        Task<IEnumerable<Appointments>> GetAppointmentsByDate(int year, int month, int day, int hour);


        [Headers("x-functions-key : yls6-YZr6d8GgD4D1pUMULYyjdpiZY8JMGj__pF_di_VAzFuggSIOQ==")]
        [Get("api/DeleteService")]
        Task DeleteService(Service service);

        [Headers("x-functions-key : noUdbqHzFatCfmP_lbBBfYTMTXNZGU2Im_uSe2OLylE0AzFu-wIEFw==")]
        [Get("api/EditService")]
        Task EditService(Service service);


        #endregion
    }
}