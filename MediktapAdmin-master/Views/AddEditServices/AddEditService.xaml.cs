using MediktapAdmin.Templates;

namespace MediktapAdmin.Views.AddEditServices
{
    public partial class AddEditService : BaseWindow<AddEditServiceViewModel>
    {
        public AddEditService(AddEditServiceViewModel vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}