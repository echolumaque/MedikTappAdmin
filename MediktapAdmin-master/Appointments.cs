using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MediktapAdmin
{
    public class Appointments
    {
        DatabaseConnection dbcon = new DatabaseConnection();
        public string AppointmentID { get; set; }
        public string Appointee { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Service Service { get; set; }
        public bool IsEmpty { get; set; }

        public Appointments(string filter)
        {
            DataSet dset = dbcon.GetTableResult("SELECT * FROM dbo.Appointment WHERE AppointmentID='" + filter + "'");
            if (dset.Tables[0].Rows.Count > 0)
            {
                var row = dset.Tables[0].Rows[0];
                AppointmentID = row["AppointmentID"].ToString();
                Appointee = row["Appointee"].ToString();
                AppointmentDate = DateTime.Parse(row["AppointmentDate"].ToString());
                Service = new Service(row["ServiceID"].ToString());
                IsEmpty = false;
            }
            else
            {
                IsEmpty = true;
            }
        }
        public Appointments()
        {

        }
        /// <summary>
        /// Appointment List By Name
        /// </summary>
        /// <param name="filter">Name</param>
        /// <returns></returns>
        public List<Appointments> AppointmentsListbyName(string filter)
        {
            List<Appointments> appointmentslist = new List<Appointments>();
            return appointmentslist;
        }
        /// <summary>
        /// AppointmentList By Date
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns></returns>
        public List<Appointments> AppointmentsList(DateTime appdate, string serviceid)
        {
            DataSet dset = dbcon.GetTableResult("SELECT * FROM dbo.Appointment WHERE serviceid='"+serviceid+"' and apointmentdate between '"+appdate.ToString("yyyy-mm-dd") + " 00:00:00"+"' and '"+ appdate.ToString("yyyy-mm-dd") + " 23:59:59" + "'");
            List<Appointments> appointmentslist = new List<Appointments>();
            if (dset.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
                {
                    var row = dset.Tables[0].Rows[i];
                    Appointments appointments = new Appointments();
                    appointments.AppointmentID = row["AppointmentID"].ToString();
                    appointments.Appointee = row["Appointee"].ToString();
                    appointments.AppointmentDate = DateTime.Parse(row["ApointmentDate"].ToString());
                    appointments.Service = new Service(row["ServiceID"].ToString());
                    appointments.IsEmpty = false;
                    appointmentslist.Add(appointments);
                }
            }
            return appointmentslist;
        }


    }
}
