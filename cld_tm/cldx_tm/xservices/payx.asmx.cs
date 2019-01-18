using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Configuration;


namespace cld.xservices
{
    /// <summary>
    /// Summary description for payx
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class payx : System.Web.Services.WebService
    {
        public string ConnectXpay()
        {
            return ConfigurationManager.ConnectionStrings["xpayConnectionString"].ConnectionString;
        }

        [WebMethod]
        public int UpdateHwallet(string xid, string used_status, string used_date, string product_title)
        {
            SqlConnection connection;
            SqlCommand command;
            int num = 0;
            using (connection = new SqlConnection(ConnectXpay()))
            {
                using (command = connection.CreateCommand())
                {
                  //  command.CommandText = "UPDATE hwallet SET used_status='" + used_status + "',product_title='" + product_title + "',used_date='" + used_date + "'  WHERE xid='" + xid + "' ";

                    command.CommandText = "UPDATE hwallet SET used_status=@used_status,product_title=@product_title,used_date=@used_date   WHERE xid='" + xid + "' ";
                    command.Parameters.Add("@used_status", SqlDbType.NVarChar, 50);
                    command.Parameters.Add("@product_title", SqlDbType.NVarChar);
                    command.Parameters.Add("@used_date", SqlDbType.NVarChar, 50);

                    command.Parameters["@used_status"].Value = used_status;
                    command.Parameters["@product_title"].Value = product_title;
                    command.Parameters["@used_date"].Value = used_date;

                    command.Connection.Open();
                    num = Convert.ToInt32(command.ExecuteNonQuery());
                }
            }
            return num;
        }
    }
}
