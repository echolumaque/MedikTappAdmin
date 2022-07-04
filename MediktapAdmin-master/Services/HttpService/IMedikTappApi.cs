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

        [Headers("x-functions-key : Ag8-ptghu5s42DyQoR5ZqxA-_gjwlfv1_4QaHKHDRPTNAzFuFdMHCQ==")]
        [Post("/api/AddPromo")]
        Task AddPromo([Body(BodySerializationMethod.Serialized)] Promo promo);
        [Headers("x-functions-key : sonKK22hiVFI8H2W47BYLGTx7A_tb3mdSHUh_vDOtwS9AzFuhHPfSw==")]
        [Get("/api/GetServiceNameAndId")]
        Task<IEnumerable<ServicesWithId>> GetServiceNameAndId();

        [Headers("x-functions-key : yls6-YZr6d8GgD4D1pUMULYyjdpiZY8JMGj__pF_di_VAzFuggSIOQ==")]
        [Delete("/api/DeleteService")]
        Task DeleteService(int serviceId);

        [Headers("x-functions-key : noUdbqHzFatCfmP_lbBBfYTMTXNZGU2Im_uSe2OLylE0AzFu-wIEFw==")]
        [Post("/api/EditService")]
        Task EditService(Service service);
        #endregion

        #region Appointments
        [Headers("x-functions-key : l-RVwmtpSC3kNIhZqTrr1e9MGRLWEcf6G9y7DSEUepDCAzFuseNwWg==")]
        [Get("/api/GetAppointmentsByServiceId?serviceId={serviceId}")]
        Task<IEnumerable<Appointments>> GetAppointmentsByServiceId(int serviceId);

        [Headers("x-functions-key : swcCdvqL0MMZ2gsSgwXAqEFSkbEtuvJ4Ip3-kMYeYma8AzFuDSJFGw==")]
        [Get("/api/GetAppointmentsByDate?year={year}&month={month}&day={day}&hour={hour}")]
        Task<IEnumerable<Appointments>> GetAppointmentsByDate(int year, int month, int day, int hour);

        [Headers("x-functions-key : I012SyoY8TeDb7hH5X-2XQTP1Qo7OplWNpcowK_TFXMhAzFuQg49cg==")]
        [Get("/api/GetAppointmentsByPatientId?patiendId={patiendId}")]
        Task<IEnumerable<Appointments>> GetAppointmentsByPatientId(int patiendId);

        [Headers("x-functions-key : 2h7CBtPnNt4WNRzt3Q_az3h9wjDHukl24TxFVdsq4_hmAzFucUsCdA==")]
        [Get("/api/GetPatientAppointmentsBasedOnServiceId?serviceId={serviceId}")]
        Task<IEnumerable<AppointmentsWithPatientId>> GetPatientAppointmentsBasedOnServiceId(int serviceId);

        [Headers("x-functions-key : EDRzF-UelyVwHsXevWBMRkqAPFjkB9J-lkrhRtsVmioPAzFuXiBGrQ==")]
        [Get("/api/GetPatientAppointmentsBasedOnServiceIdAndDate?serviceId={serviceId}&year={year}&month={month}&day={day}")]
        Task<IEnumerable<AppointmentsWithPatientId>> GetPatientAppointmentsBasedOnServiceIdAndDate(int serviceId, int year,
            int month, int day);
        #endregion

        #region Promos
        [Headers("x-functions-key : n8UzakNdDPgEFSjkFZv9ZQl9qsc0jTanPakzEVz4hCb9AzFuRZ4y8A==")]
        [Get("/api/GetPromo")]
        Task<IEnumerable<Promo>> GetPromos();

        [Headers("x-functions-key : if6Wuo4-imKg6yNKgTg4z5EGBFBwPpd9ad8IOwTbxaL-AzFu2Ksj4Q==")]
        [Delete("/api/DeletePromo")]
        Task DeletePromo(int promoId);

        [Headers("x-functions-key : VS9Fq0KeRJmr6tnfOdN5Z2J2rFdZZavdO9g-sEwX4YSzAzFui1dEPg==")]
        [Post("/api/EditPromo")]
        Task EditPromo(Promo promo);
        #endregion
    }
}
//https://mediktapp.azurewebsites.net/api/GetPatientNameById?code=