using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MediktapAdmin
{
    public class DatabaseConnection
    {
        public static string ConString = Properties.Settings.Default.ConnectionString;

        public bool ExecSQL(string sql)
        {
            SqlConnection con = new SqlConnection(ConString);
            if (con.State == ConnectionState.Open )
            {
                con.Close();
            }
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
        }

        public DataSet GetTableResult(string sql)
        {
            DataSet dset = new DataSet();
            SqlConnection con = new SqlConnection(ConString);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter sdap = new SqlDataAdapter(cmd);
                sdap.Fill(dset);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return dset;
        }
    }
}
