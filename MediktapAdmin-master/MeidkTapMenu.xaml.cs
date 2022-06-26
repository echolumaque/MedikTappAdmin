using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MediktapAdmin
{
    /// <summary>
    /// Interaction logic for MeidkTapMenu.xaml
    /// </summary>
    public partial class MeidkTapMenu : Window
    {
        public MeidkTapMenu()
        {
            InitializeComponent();
        }

        private void btnservice_Click(object sender, RoutedEventArgs e)
        {
            Services services = new Services();
            services.Show();
        }

        private void btnappointment_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.Show();
        }
    }
}
