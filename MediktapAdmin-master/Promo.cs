using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MediktapAdmin
{
    public class Promo
    {
        DatabaseConnection dbcon = new DatabaseConnection();
        public string PromoID { get; set; }
        public string PromoName { get; set; }
        public string PromoDescription { get; set; }
        public double PromoPrice { get; set; }
        public DateTime PromoPeriod { get; set; }
        public bool IsEmpty { get; set; }
        public Promo(string filter, string type="Id")
        {
            string where = type == "Id" ? " PromoID='" + filter + "'" : " PromoName='" + filter + "'";
            DataSet dset = dbcon.GetTableResult("SELECT * FROM dbo.Promo_Table where " + where);
            if (dset.Tables[0].Rows.Count > 0)
            {
                var row = dset.Tables[0].Rows[0];
                PromoID = row["PromoID"].ToString();
                PromoName = row["PromoName"].ToString();
                PromoDescription = row["PromoDescription"].ToString();
                PromoPrice = Convert.ToDouble(row["PromoPrice"].ToString());
                PromoPeriod = DateTime.Parse(row["PromoPeriod"].ToString());
                IsEmpty = false;
            }
            else
            {
                IsEmpty = true;
            }
        }
        public Promo()
        {

        }
        /// <summary>
        /// Returns the List of promo base on Filter
        /// </summary>
        /// <param name="filter">Left blank or '*' returns all promo else returns promo with letter in the keyword in PromoName</param>
        /// <returns></returns>
        public List<Promo> PromoList(string filter)
        {
            List<Promo> promolist = new List<Promo>();
            string where = filter == "" || filter == "*" ? "" : " WHERE PromoName like '%" + filter + "%'";
            DataSet dset = dbcon.GetTableResult("SELECT * FROM dbo.Promo_Table " + where);
            if (dset.Tables[0].Rows.Count >0)
            {
                for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
                {
                    Promo promo = new Promo();
                    var row = dset.Tables[0].Rows[i];
                    promo.PromoID = row["PromoID"].ToString();
                    promo.PromoName = row["PromoName"].ToString();
                    promo.PromoDescription = row["PromoDescription"].ToString();
                    promo.PromoPrice = Convert.ToDouble(row["PromoPrice"].ToString());
                    promo.PromoPeriod = DateTime.Parse(row["PromoPeriod"].ToString());
                    promo.IsEmpty = false;
                    promolist.Add(promo);
                }
            }
            return promolist;
        }
        /// <summary>
        /// Save Values set on Object in teh Database
        /// </summary>
        /// <param name="SaveAction">Add or Update Events</param>
        /// <returns></returns>
        public MessageReturn SavePromo(string SaveAction="Add")
        {
            MessageReturn mr = new MessageReturn();
            // Add
            if (SaveAction == "Add")
            {
                // Input Validation
                if (PromoName == "" || PromoName == null)
                {
                    mr.IsSuccess = false;
                    mr.Message = "Invalid/Missing Promo Name";
                    return mr;
                }
                if (PromoPrice == 0)
                {
                    mr.IsSuccess = false;
                    mr.Message = "Invalid Value. Price cannot be equal to zero";
                    return mr;
                }
                if (PromoPeriod == null || PromoPeriod.ToString("yyyy-MM-dd HH:mm:ss") == "0000-00-00 00:00:00")
                {
                    mr.IsSuccess = false;
                    mr.Message = "Please set Promo period date (promo end date)";
                    return mr;
                }
                // Check if Promo Exist
                Promo promochecker = new Promo(PromoName, "PromoName");
                if (!promochecker.IsEmpty)
                {
                    mr.IsSuccess = false;
                    mr.Message = "Promo Already Exist";
                    return mr;
                }
                // If Not Exist, Save Promo.
                mr.IsSuccess = dbcon.ExecSQL("INSERT INTO dbo.Promo_table(PromoName, PromoDescription, PromoPrice, PromoPeriod) VALUES (" +
                    "'"+PromoName+"'," + // PromoName
                    "'"+PromoDescription+"'," + // PromoDescription
                    "'"+PromoPrice+"'," + // PromoPrice
                    "'"+PromoPeriod.ToString("yyyy-MM-dd HH:mm:ss")+"')"); // PromoPeriod
                mr.Message = mr.IsSuccess ? "Successfully Saved new promo" : "Something went wrong, please check your connections";
                return mr;

            }
            // Edit
            else
            {
                Promo promochecker = new Promo(PromoName, "PromoName");
                if (promochecker.IsEmpty)
                {
                    mr.IsSuccess = false;
                    mr.Message = "No Promo with Name :  " + PromoName + " Exist!";
                    return mr;
                }
                // Validation
                if (promochecker.PromoName == PromoName && promochecker.PromoPrice == PromoPrice && promochecker.PromoPeriod == PromoPeriod && promochecker.PromoDescription == PromoDescription)
                {
                    mr.IsSuccess = false;
                    mr.Message = "No Changes detected on the Promo being saved.";
                    return mr;
                }
                string oldpromoname = promochecker.PromoName;
                // If there are changes
                mr.IsSuccess = dbcon.ExecSQL("UPDATE dbo.Promo_table set " +
                    "PromoName='"+PromoName+"', " +
                    "PromoDescription='"+PromoDescription+"'," +
                    "PromoPrice='"+PromoPrice.ToString()+"', " +
                    "PromoPeriod='"+PromoPeriod.ToString("yyyy-MM-dd HH:mm:ss")+"' " +
                    "WHERE PromoName='"+PromoName+"'");
                mr.Message = mr.IsSuccess ? "Successfully updated Promo " + oldpromoname : "Something Went Wrong, please check your connections";
                return mr;
            }
        }

        public MessageReturn DeletePromo()
        {
            MessageReturn mr = new MessageReturn();
            Promo promochecker = new Promo(PromoName, "");
            if (promochecker.IsEmpty)
            {
                mr.IsSuccess = false;
                mr.Message = "No Such Promo Exist!";
                return mr;
            }
            mr.IsSuccess = dbcon.ExecSQL("DELETE FROM dbo.Promo_table where PromoID='" + promochecker.PromoID + "'");
            mr.Message = mr.IsSuccess ? "Successfully deleted Promo!" : "Something went wrong, please try again";
            return mr;
        }
    }
}
