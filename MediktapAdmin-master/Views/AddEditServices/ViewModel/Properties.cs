using System.Windows.Input;

namespace MediktapAdmin.Views.AddEditServices
{
    public partial class AddEditServiceViewModel
    {
        public ICommand AddServiceCmd { get; }
        public ICommand OpenImageCmd { get; }
        public string ServiceImage { get; set; } = "/Assets/img-placeholder.png";
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public double ServicePrice { get; set; }
    }
}