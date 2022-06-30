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
    /// Interaction logic for AddEditPromo.xaml
    /// </summary>
    public partial class AddEditPromo : Window
    {
        public AddEditPromo(string PromoName, string Action)
        {
            InitializeComponent();
            Promo promo = new Promo(PromoName, "PromoName");
            if (promo.IsEmpty)
            {
                txtpromoname.Text = "";
                txtpromodescription.Text = "";
                txtpromoprice.Text = "";
                dtptomoperiodStart.SelectedDate = DateTime.Now;
                dtpromoperiod.SelectedDate = DateTime.Now;
                btnsavepromo.Tag = Action;
            }
            else
            {
                txtpromoname.Text = promo.PromoName;
                txtpromodescription.Text = promo.PromoDescription;
                txtpromoprice.Text = promo.PromoPrice.ToString();
                dtptomoperiodStart.SelectedDate = DateTime.Now;
                dtpromoperiod.SelectedDate = promo.PromoPeriod;
                btnsavepromo.Tag = Action;
            }
        }

        private void btnsavepromo_Click(object sender, RoutedEventArgs e)
        {
            string action = btnsavepromo.Tag.ToString();
            Promo promo = new Promo();
            promo.PromoName = txtpromoname.Text;
            promo.PromoDescription = txtpromodescription.Text;
            promo.PromoPrice = txtpromoprice.Text == "" ? 0 : Convert.ToDouble(txtpromoprice.Text);
            promo.PromoPeriod = dtpromoperiod.SelectedDate.Value;
            promo.PromoPeriod = dtptomoperiodStart.SelectedDate.Value;
            MessageReturn mr = promo.SavePromo(action);
            MessageBox.Show(mr.Message);
            if (mr.IsSuccess)
            {
                txtpromoname.Text = "";
                txtpromodescription.Text = "";
                txtpromoprice.Text = "";
            }
            if (action == "Edit" && mr.IsSuccess)
            {
                this.Close();
            }




        }
    }
}
