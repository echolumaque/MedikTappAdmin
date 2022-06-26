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
    /// Interaction logic for AddEditService.xaml
    /// </summary>
    public partial class AddEditService : Window
    {
        public AddEditService(string ServiceName, string action)
        {
            InitializeComponent();
            Service service = new Service(ServiceName, "ServiceName");
            if (service.IsEmpty)
            {
                txtservicename.Text = "";
                txtservicedescription.Text = "";
                txtserviceprice.Text = "";
                btnsaveservice.Tag = action;
            }
            else
            {
                txtservicename.Text = service.ServiceName;
                txtservicedescription.Text = service.ServiceDescription;
                txtserviceprice.Text = service.ServicePrice.ToString();
                btnsaveservice.Tag = action;
            }
        }

        private void btnsaveservice_Click(object sender, RoutedEventArgs e)
        {
            string action = btnsaveservice.Tag.ToString();
            //MessageBox.Show(action);
            Service service = new Service();
            service.ServiceName = txtservicename.Text;
            service.ServiceDescription = txtservicedescription.Text;
            service.ServicePrice = Convert.ToDouble(txtserviceprice.Text);
            MessageReturn mr = service.SaveService(action);
            MessageBox.Show(mr.Message);
            if (mr.IsSuccess)
            {
                txtservicename.Text = "";
                txtservicedescription.Text = "";
                txtserviceprice.Text = "";
            }
            if (action == "Edit" && mr.IsSuccess)
            {
                this.Close();
            }
        }
    }
}
