using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace cld.admin.tm.search_unit
{
    
    public partial class _Default : System.Web.UI.Page
    {
        protected Label lblmsg;
        protected GridView GridView1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insertdata_Click(object sender, EventArgs e)
        {
            OleDbConnection oconn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("example.xls") + ";Extended Properties=Excel 8.0");
            try
            {
                OleDbCommand ocmd = new OleDbCommand("select * from [Sheet1$]", oconn);
                oconn.Open();
                OleDbDataReader odr = ocmd.ExecuteReader();
                string fname = "";
                string lname = "";
                string mobnum = "";
                string city = "";
                string state = "";
                string zip = "";
                while (odr.Read())
                {
                    fname = valid(odr, 0);
                    lname = valid(odr, 1);
                    mobnum = valid(odr, 2);
                    city = valid(odr, 3);
                    state = valid(odr, 4);
                    zip = valid(odr, 5);
                    insertdataintosql(fname, lname, mobnum, city, state, zip);
                }
                oconn.Close();
            }
            catch (DataException ee)
            {
                lblmsg.Text = ee.Message;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                lblmsg.Text = "Data Inserted Sucessfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
            }
        }
        protected string valid(OleDbDataReader myreader, int stval)//if any columns are found null then they are replaced by zero
        {
            object val = myreader[stval];
            if (val != DBNull.Value)
                return val.ToString();
            else
                return Convert.ToString(0);
        }

        protected void viewdata_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;AttachDbFileName=|DataDirectory|exceltosql.mdf;Trusted_Connection=yes");
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from emp", conn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (DataException de)
            {
                lblmsg.Text = de.Message;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                lblmsg.Text = "Data Shown Sucessfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
            }
        }
        public void insertdataintosql(string fname, string lname, string mobnum, string city, string state, string zip)
        {
            SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;AttachDbFileName=|DataDirectory|exceltosql.mdf;Trusted_Connection=yes");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into emp(fname,lname,mobnum,city,state,zip) values(@fname,@lname,@mobnum,@city,@state,@zip)";
            cmd.Parameters.Add("@fname", SqlDbType.NVarChar).Value = fname;
            cmd.Parameters.Add("@lname", SqlDbType.NVarChar).Value = lname;
            cmd.Parameters.Add("@mobnum", SqlDbType.NVarChar).Value = mobnum;
            cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = city;
            cmd.Parameters.Add("@state", SqlDbType.NVarChar).Value = state;
            cmd.Parameters.Add("@zip", SqlDbType.Int).Value = Convert.ToInt32(zip);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        protected void deletedata_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;AttachDbFileName=|DataDirectory|exceltosql.mdf;Trusted_Connection=yes");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete from emp";
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteScalar();
                conn.Close();
            }
            catch (DataException de1)
            {
                lblmsg.Text = de1.Message;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                lblmsg.Text = "Data Deleted Sucessfully";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}
