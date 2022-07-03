using MediktapAdmin.Templates;
using MediktapAdmin.Views.HelpWindow.ViewModel;

namespace MediktapAdmin.Views.HelpWindow
{
    /// <summary>
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : BaseWindow<HelpWindowViewModel>
    {
        public HelpWindow(HelpWindowViewModel vm):base(vm)
        {
            InitializeComponent();
        }
    }
}
