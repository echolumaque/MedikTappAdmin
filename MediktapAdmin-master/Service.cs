using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MediktapAdmin
{
    public class Service
    {
        DatabaseConnection dbcon = new DatabaseConnection();
        public string ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public double ServicePrice { get; set; }
        public bool IsEmpty { get; set; }
        public Service(string filter, string type="Id")
        {
            string where = type == "Id" ? " ServiceID='" + filter + "'" : " ServiceName='" + filter + "'";
            DataSet dset = dbcon.GetTableResult("SELECT * FROM dbo.ServiceTable where " + where);
            if (dset.Tables[0].Rows.Count > 0)
            {
                var row = dset.Tables[0].Rows[0];
                ServiceID = row["ServiceID"].ToString();
                ServiceName = row["ServiceName"].ToString();
                ServiceDescription = row["ServiceDescription"].ToString();
                ServicePrice = Convert.ToDouble(row["ServicePrice"].ToString());
                IsEmpty = false;
            }
            else
            {
                IsEmpty = true;
            }
        }
        public Service()
        {

        }
        /// <summary>
        /// Get List of Services
        /// </summary>
        /// <param name="filter">left blank or '*' returns all Services</param>
        /// <returns></returns>
        public List<Service> ServiceList(string filter)
        {
            string where = filter == "" || filter == "*" ? "" : " WHERE ServiceName like '%" + filter + "%'";
            DataSet dset = dbcon.GetTableResult("SELECT * FROM dbo.ServiceTable " + where);
            List<Service> servicelist = new List<Service>();
            if (dset.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
                {
                    var row = dset.Tables[0].Rows[i];
                    Service service = new Service();
                    service.ServiceID = row["ServiceID"].ToString();
                    service.ServiceName = row["ServiceName"].ToString();
                    service.ServiceDescription = row["ServiceDescription"].ToString();
                    service.ServicePrice = Convert.ToDouble(row["ServicePrice"].ToString());
                    service.IsEmpty = false;
                    servicelist.Add(service);
                }
            }
            return servicelist;
        }
        /// <summary>
        /// Save Service Object to Database
        /// </summary>
        /// <param name="SaveAction">Add or Edit</param>
        /// <returns></returns>
        public MessageReturn SaveService(string SaveAction="Add")
        {
            MessageReturn mr = new MessageReturn();
            if (SaveAction == "Add")
            {
                // Input validation
                if (ServiceName == "" || ServiceName == null )
                {
                    mr.IsSuccess = false;
                    mr.Message = "Invalid Service name!";
                    return mr;
                }
                if (ServicePrice == 0)
                {
                    mr.IsSuccess = false;
                    mr.Message = "Invalid Price!";
                    return mr;
                }
                // ServiceChecker
                Service servicechecker = new Service(ServiceName, "ServiceName");
                if (!servicechecker.IsEmpty)
                {
                    mr.IsSuccess = false;
                    mr.Message = "Service Already Exist!";
                    return mr;
                }

                mr.IsSuccess = dbcon.ExecSQL("INSERT INTO dbo.ServiceTable(ServiceName, ServiceDescription, ServicePrice) VALUES(" +
                    "'" + ServiceName + "'," +
                    "'" + ServiceDescription + "'," +
                    "'" + ServicePrice.ToString() + "')");
                mr.Message = mr.IsSuccess ? "Successfully Added New Service!" : "Something went wrong please try again";
                return mr;
            }
            else
            {
                // Service checker
                Service servicechecker = new Service(ServiceName, "ServiceName");
                if (servicechecker.IsEmpty)
                {
                    mr.IsSuccess = false;
                    mr.Message = "No such service exist!";
                    return mr;
                }

                // Input validation
                if (ServiceName == servicechecker.ServiceName && ServiceDescription == servicechecker.ServiceDescription && ServicePrice == servicechecker.ServicePrice)
                {
                    mr.IsSuccess = false;
                    mr.Message = "No changes detected on the Service";
                    return mr;
                }
                string oldservicename = servicechecker.ServiceName;
                mr.IsSuccess = dbcon.ExecSQL("UPDATE dbo.ServiceTable set " +
                    "ServiceName='" + ServiceName + "', " +
                    "ServiceDescription='" + ServiceDescription + "', " +
                    "ServicePrice='" + ServicePrice.ToString() + "' WHERE ServiceName='" + ServiceName + "'");
                mr.Message = mr.IsSuccess ? "Successfully updated Service: " + ServiceName : "Something went wrong please try again";
                return mr;
            }
        }

        public MessageReturn DeleteService()
        {
            MessageReturn mr = new MessageReturn();
            Service servicechecker = new Service(ServiceName, "ServiceName");
            if (servicechecker.IsEmpty)
            {
                mr.IsSuccess = false;
                mr.Message = "No Such Service Exist";
                return mr;
            }
            mr.IsSuccess = dbcon.ExecSQL("DELETE FROM dbo.Servicetable where ServiceID='" + servicechecker.ServiceID + "'");
            mr.Message = mr.IsSuccess ? "Successfully deleted " + ServiceName : "Something went wrong please try again";
            return mr;
        }

    }
}
