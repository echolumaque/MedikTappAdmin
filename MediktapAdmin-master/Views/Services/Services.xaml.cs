using System.Windows;

namespace MediktapAdmin.Views.Services
{
    public partial class Services : Window
    {
        public Services()
        {
            InitializeComponent();
            servicetab.Width = (this.Width / 2) - 10;
            promotab.Width = (this.Width / 2) - 10;
        }
    }
}