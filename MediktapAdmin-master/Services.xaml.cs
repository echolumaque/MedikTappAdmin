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
    /// Interaction logic for Services.xaml
    /// </summary>
    public partial class Services : Window
    {
        public Services()
        {
            InitializeComponent();
            servicetab.Width = (this.Width / 2) -10;
            promotab.Width = (this.Width / 2) - 10;
            LoadServices();
            LoadPromos();
        }
        public void LoadServices()
        {
            Service service = new Service();
            List<Service> services = service.ServiceList("*");
            lstservicelist.Items.Clear();
            for (int i = 0; i < services.Count; i++)
            {
                lstservicelist.Items.Add(services[i].ServiceName);
            }
            lstservicelistaction.ItemsSource = services;
        }

        public void LoadPromos()
        {
            Promo promo = new Promo();
            List<Promo> promos = promo.PromoList("*");
            lstpromo.Items.Clear();
            for (int i = 0; i < promos.Count; i++)
            {
                lstpromo.Items.Add(promos[i].PromoName);
            }
            lstpromoaction.ItemsSource = promos;
        }

        private void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Service service = b.CommandParameter as Service;
            if (MessageBox.Show("Are you sure you want to delete this Service?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MessageReturn mr = service.DeleteService();
                MessageBox.Show(mr.Message);
            }
            LoadServices();
        }

        private void Editbtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Service service = b.CommandParameter as Service;
            AddEditService addEditService = new AddEditService(service.ServiceName, "Edit");
            addEditService.Show();
        }

        private void btnaddnewservice_Click(object sender, RoutedEventArgs e)
        {
            AddEditService addEditService = new AddEditService("", "Add");
            addEditService.Show();
        }

        private void EditPromobtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Promo promo = b.CommandParameter as Promo;
            AddEditPromo addEditPromo = new AddEditPromo(promo.PromoName, "Edit");
            addEditPromo.Show();
        }

        private void DeletePromobtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Promo promo = b.CommandParameter as Promo;
            if (MessageBox.Show("Are you sure you want to delete this Service?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MessageReturn mr = promo.DeletePromo();
                MessageBox.Show(mr.Message);
            }
            LoadPromos();
        }

        private void btnpromoadd_Click(object sender, RoutedEventArgs e)
        {
            AddEditPromo addEditPromo = new AddEditPromo("", "Add");
            addEditPromo.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadPromos();
            LoadServices();
        }
    }
}
