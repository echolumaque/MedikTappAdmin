using MediktapAdmin.Templates;

namespace MediktapAdmin.Views.MedikTappMenus
{
    public partial class MedikTappMenu : BaseWindow<MedikTappMenuViewModel>
    {
        public MedikTappMenu(MedikTappMenuViewModel vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}