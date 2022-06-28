namespace MediktapAdmin.Models
{
    public class Service
    {
        public string ServiceImage { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public double ServicePrice { get; set; }
        public bool IsPromo { get; set; }
    }
}