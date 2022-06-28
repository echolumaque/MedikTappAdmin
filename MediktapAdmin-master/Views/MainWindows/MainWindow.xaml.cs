using MediktapAdmin.Templates;

namespace MediktapAdmin.Views.MainWindows
{
    public partial class MainWindow : BaseWindow<MainWindowViewModel>
    {
        public MainWindow(MainWindowViewModel vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}