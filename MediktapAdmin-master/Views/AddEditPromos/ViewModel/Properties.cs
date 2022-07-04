using System;
using System.Windows.Input;
using System.Windows.Media;

namespace MediktapAdmin.Views.AddEditPromos.ViewModel
{
    public partial class AddEditPromoViewModel
    {
        public ICommand AddPromoCmd { get; }
        public ICommand OpenImageCmd { get; }
        public ICommand ClearFieldsCmd { get; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ImageSource PromoImage { get; set; }
        public string PromoDescription { get; set; }
        public double PromoPrice { get; set; }
        public string PromoName { get; set; }
        public string AddEditPromoText { get; set; }
    }
}