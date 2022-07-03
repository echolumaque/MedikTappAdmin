using MediktapAdmin.Templates;
using MediktapAdmin.Views.Services.ViewModel;

namespace MediktapAdmin.Views.Services
{
    public partial class Services : BaseWindow<ServiceViewModel>
    {
        public Services(ServiceViewModel vm) : base(vm)
        {
            InitializeComponent();
           
        }
    }
}