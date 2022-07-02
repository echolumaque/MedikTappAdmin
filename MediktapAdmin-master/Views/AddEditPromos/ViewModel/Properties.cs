using System.Windows.Input;

namespace MediktapAdmin.Views.AddEditPromos.ViewModel
{
    public partial class AddEditPromoViewModel
    {
        public ICommand AddPromoCmd { get; }
        public ICommand OpenImageCmd { get; }
        public ICommand ClearFieldsCmd { get; }
        public string PromoImage { get; set; } = "/Assets/img-placeholder.png";
        public string PromoDesrcripton { get; set; }
        public double PromoPrice { get; set; }
        public string PromoName { get; set; }

    }
}
