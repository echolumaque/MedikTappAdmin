using MediktapAdmin.Templates;
using MediktapAdmin.Views.Appointments.ViewModel;

namespace MediktapAdmin.Views.Appointments
{
    public partial class Appointment : BaseWindow<AppointmentViewModel>
    {
        public Appointment(AppointmentViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {

        }
    }
}