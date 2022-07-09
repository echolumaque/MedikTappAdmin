using MediktapAdmin.Templates;
using MediktapAdmin.Views.AddEditPromos.ViewModel;
using System.Windows.Navigation;

namespace MediktapAdmin.Views.AddEditPromos
{
    public partial class AddEditPromo : BaseWindow<AddEditPromoViewModel>
    {
        public AddEditPromo(AddEditPromoViewModel vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}