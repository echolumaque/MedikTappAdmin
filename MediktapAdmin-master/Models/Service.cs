using System;

namespace MediktapAdmin.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceImage { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public double ServicePrice { get; set; }
#nullable enable
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
#nullable disable
    }

    public class ServiceNameAndId
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }
}