using System;

namespace MediktapAdmin.Views.AddEditPromos
{
    public class Promo
    {
        public string PromoID { get; set; }
        public string PromoName { get; set; }
        public string PromoDescription { get; set; }
        public double PromoPrice { get; set; }
        public DateTime PromoPeriod { get; set; }
        public bool IsEmpty { get; set; }
    }
}