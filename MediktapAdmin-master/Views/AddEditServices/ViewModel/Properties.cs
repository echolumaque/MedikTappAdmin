using System.Windows.Input;
using System.Windows.Media;

namespace MediktapAdmin.Views.AddEditServices
{
    public partial class AddEditServiceViewModel
    {
        public ICommand AddSOrEditerviceCmd { get; }
        public ICommand OpenImageCmd { get; }
        public ImageSource ServiceImage { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public double ServicePrice { get; set; }
        public ICommand ClearFieldsCmd { get; }
        public string AddEditServiceText { get; set; }
    }
}