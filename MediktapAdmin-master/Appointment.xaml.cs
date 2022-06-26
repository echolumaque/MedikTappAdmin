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
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class Appointment : Window
    {
        public Appointment()
        {
            InitializeComponent();
            Service service = new Service();
            LoadSchedule( service, DateTime.Now);
            LoadServices();
        }
        private void LoadServices()
        {
            Service service = new Service();
            List<Service> services = service.ServiceList("*");
            cbservices.Items.Clear();
            for (int i = 0; i < services.Count; i++)
            {
                cbservices.Items.Add(services[i].ServiceName);
            }
        }

        private void LoadSchedule(Service service, DateTime schedtime)
        {
            Appointments appointments = new Appointments();
            List<Appointments> appointmentslist = appointments.AppointmentsList(schedtime, service.ServiceID);
            DateTime referencedate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
            List<SchedView> SchedViewList = new List<SchedView>();
            for (int i = 0; i < 48; i++)
            {
                string names = "";
                for (int j = 0; j < appointmentslist.Count; j++)
                {
                    names = appointmentslist[j].AppointmentDate.ToString("HH:mm") == referencedate.ToString("HH:mm") ? appointmentslist[j].Appointee : "";
                }
                SchedView schedView = new SchedView();
                schedView.Time = referencedate.ToString("HH:mm");
                schedView.Names = names;
                SchedViewList.Add(schedView);
                referencedate = referencedate.AddMinutes(30);
            }
            dtschedule.ItemsSource = SchedViewList;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbservices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime appointmentdate = cal1.SelectedDate.Value;
            Service service = new Service(cbservices.Text, "ServiceName");
            LoadSchedule(service, appointmentdate);
        }
    }

    public class SchedView
    {
        public string Time { get; set; }
        public string Names { get; set; }
    }
}
