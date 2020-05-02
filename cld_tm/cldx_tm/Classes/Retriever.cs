using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace cld.Classes
{
    public class Retriever
    {
        public string EncodeChar(string x)
        {
            string y = "";

            if ((x != null) &&(x != ""))
            {
                y = x;
                if (x.Contains("'"))
                {
                    y = x.Replace("'", "|");
                }
                if (x.Contains("("))
                {
                    y = x.Replace("(", "~~");
                }

                if (x.Contains(")"))
                {
                    y = x.Replace(")", "**");
                }
            }
            return y;
        }
        public string DecodeChar(string x)
        {
            string y = "";

            if ((x != null) && (x != ""))
            {
                y = x;
                if (x.Contains("|"))
                {
                    y = x.Replace("|", "'");
                }
                if (x.Contains("~~"))
                {
                    y = x.Replace("~~", "(");
                }

                if (x.Contains("**"))
                {
                    y = x.Replace("**", ")");
                }
                if (x.Contains(" %26"))
                {
                    y = x.Replace("%26", " &");
                }

            }
            return y;
        }

        public string a_xadminz(string uname, string xpass, string serverpath)
        {
            List<XObjs.Pwallet> list = new List<XObjs.Pwallet>();
            string str = "Xavier";
            string path = serverpath + @"\Handlers\bf.kez";
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path, true);
                str = reader.ReadToEnd();
                reader.Close();
                if (str != null)
                {
                    string oldValue = str.Substring(0, str.IndexOf("</BitStrength>") + 14);
                    str = str.Replace(oldValue, "");
                }
            }
            new Odyssey.Odyssey();
            this.ConnectXpay();
            string str4 = "";
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("select xid,xemail,xpass from pwallet ", connection);
            connection.Open();
            SqlDataReader reader2 = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader2.Read())
            {
                XObjs.Pwallet item = new XObjs.Pwallet
                {
                    xid = reader2["xID"].ToString(),
                    xemail = reader2["xemail"].ToString(),
                    xpass = reader2["xpass"].ToString()
                };
                list.Add(item);
            }
            reader2.Close();
            for (int i = 0; i < list.Count; i++)
            {
                if ((uname == list[i].xemail) && (xpass == list[i].xpass))
                {
                    str4 = list[i].xid.ToString();
                }
            }
            return str4;
        }

        public string addAdminLog(string adminID, string ip_addy, string remote_host, string remote_user, string server_name, string server_url)
        {
            string str = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str2 = DateTime.Now.ToLongTimeString();
            string connectionString = this.ConnectXpay();
            string str4 = "0";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO admin_lg (adminID,ip_addy,remote_host,remote_user,server_name,server_url,log_date,log_time) VALUES (@adminID,@ip_addy,@remote_host,@remote_user,@server_name,@server_url,@log_date,@log_time) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@adminID", SqlDbType.NVarChar, 200);
            command.Parameters.Add("@ip_addy", SqlDbType.Text);
            command.Parameters.Add("@remote_host", SqlDbType.Text);
            command.Parameters.Add("@remote_user", SqlDbType.Text);
            command.Parameters.Add("@server_name", SqlDbType.Text);
            command.Parameters.Add("@server_url", SqlDbType.Text);
            command.Parameters.Add("@log_date", SqlDbType.NVarChar, 200);
            command.Parameters.Add("@log_time", SqlDbType.NVarChar, 200);
            command.Parameters["@adminID"].Value = adminID;
            command.Parameters["@ip_addy"].Value = ip_addy;
            command.Parameters["@remote_host"].Value = remote_host;
            command.Parameters["@remote_user"].Value = remote_user;
            command.Parameters["@server_name"].Value = server_name;
            command.Parameters["@server_url"].Value = server_url;
            command.Parameters["@log_date"].Value = str;
            command.Parameters["@log_time"].Value = str2;
            str4 = command.ExecuteScalar().ToString();
            connection.Close();
            return str4;
        }



        public string addEmail(string Comment, string subject, string agent_code, string pt_id)
        {
            string str = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str2 = DateTime.Now.ToLongTimeString();
            string connectionString = this.ConnectXhome();
            string str4 = "0";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Agent_Mail (Message,Subject,Date_Sent,Agent_Code,Status,pt_id) VALUES (@Message,@Subject,@Date_Sent,@Agent_Code,@Status,@pt_id) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@Message", SqlDbType.NVarChar, 5000);
            command.Parameters.Add("@Subject", SqlDbType.NVarChar, 500);
            command.Parameters.Add("@Date_Sent", SqlDbType.DateTime);
            command.Parameters.Add("@Agent_Code", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@Status", SqlDbType.Bit);
            command.Parameters.Add("@pt_id", SqlDbType.NVarChar, 50);
            
            command.Parameters["@Message"].Value = Comment;
            command.Parameters["@Subject"].Value = subject;
            command.Parameters["@Date_Sent"].Value = DateTime.Now;
            command.Parameters["@Agent_Code"].Value = agent_code;
            command.Parameters["@Status"].Value = 0;

            command.Parameters["@pt_id"].Value = pt_id;

            str4 = command.ExecuteScalar().ToString();
            connection.Close();
            return str4;
        }

        public string Connect()
        {
            return ConfigurationManager.ConnectionStrings["cldConnectionString"].ConnectionString;
        }

        public string ConnectXhome()
        {
            return ConfigurationManager.ConnectionStrings["homeConnectionString"].ConnectionString;
        }

        public string ConnectXpay()
        {
            return ConfigurationManager.ConnectionStrings["xpayConnectionString"].ConnectionString;
        }

        public XObjs.Address getAddressByID(string xid)
        {
            XObjs.Address address = new XObjs.Address();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT * FROM address WHERE ID='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                address.ID = reader["ID"].ToString();
                address.city = reader["city"].ToString();
                address.countryID = reader["countryID"].ToString();
                address.email1 = reader["email1"].ToString();
                address.email2 = reader["email2"].ToString();
                address.lgaID = reader["lgaID"].ToString();
                address.log_staff = reader["log_staff"].ToString();
                address.reg_date = reader["reg_date"].ToString();
                address.stateID = reader["stateID"].ToString();
                address.street = reader["street"].ToString();
                address.telephone1 = reader["telephone1"].ToString();
                address.telephone2 = reader["telephone2"].ToString();
                address.visible = reader["visible"].ToString();
                address.xsync = reader["xsync"].ToString();
                address.zip = reader["zip"].ToString();
            }
            reader.Close();
            connection.Close();
            return address;
        }

        public XObjs.G_Agent_info getAgentByID(string xid)
        {
            XObjs.G_Agent_info _info = new XObjs.G_Agent_info();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM xagent WHERE xid='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _info.xid = reader["xid"].ToString();
                _info.xname = reader["xname"].ToString();
                _info.cname = reader["cname"].ToString();
                _info.xpassword = reader["xpassword"].ToString();
                _info.nationality = reader["nationality"].ToString();
                _info.addressID = reader["addressID"].ToString();
                _info.sys_ID = reader["sys_ID"].ToString();
                _info.xreg_date = reader["xreg_date"].ToString();
                _info.xvisible = reader["xvisible"].ToString();
                _info.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return _info;
        }

        public List<string> getAllEmails()
        {
            List<string> list = new List<string>();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT email1 FROM address", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                string item = reader["email1"].ToString();
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Fee_list> getAllFee_list()
        {
            List<XObjs.Fee_list> list = new List<XObjs.Fee_list>();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT * FROM fee_list", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Fee_list item = new XObjs.Fee_list
                {
                    xid = reader["xid"].ToString(),
                    init_amt = reader["init_amt"].ToString(),
                    item = reader["item"].ToString(),
                    item_code = reader["item_code"].ToString(),
                    tech_amt = reader["tech_amt"].ToString(),
                    xcategory = reader["xcategory"].ToString(),
                    xdesc = reader["xdesc"].ToString(),
                    xlogstaff = reader["xlogstaff"].ToString(),
                    xreg_date = reader["xreg_date"].ToString(),
                    xsync = reader["xsync"].ToString(),
                    xvisible = reader["xvisible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<string> getAllMobileNumbers()
        {
            List<string> list = new List<string>();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT telephone1 FROM address", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                string item = reader["telephone1"].ToString();
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public int getAllPaidFee_detail_ItemsCntByCat(string memberID, string cat)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("select count(hwallet.xid) as cnt from fee_list  INNER JOIN fee_details ON fee_details.fee_listID=fee_list.xid  INNER JOIN twallet ON  twallet.xid=fee_details.twalletID  INNER JOIN hwallet ON hwallet.fee_detailsID=fee_details.xid where fee_list.xcategory='" + cat + "' AND twallet.xmemberID='" + memberID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }

        public int getPaymentRecordal( string cat)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select count(TRANSACTIONID) as cnt from Recordal   where TRANSACTIONID='" + cat + "'  ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }

        public XObjs.XBanker getBankerByID(string xid)
        {
            XObjs.XBanker banker = new XObjs.XBanker();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT * FROM xbanker WHERE xid='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                banker.xid = reader["xid"].ToString();
                banker.xname = reader["xname"].ToString();
                banker.bankname = reader["bankname"].ToString();
                banker.xpassword = reader["xpassword"].ToString();
                banker.nationality = reader["nationality"].ToString();
                banker.addressID = reader["addressID"].ToString();
                banker.xposition = reader["xposition"].ToString();
                banker.sys_ID = reader["sys_ID"].ToString();
                banker.xreg_date = reader["xreg_date"].ToString();
                banker.xvisible = reader["xvisible"].ToString();
                banker.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return banker;
        }

        public string getCountryName(string ID)
        {
            string str = "";
            try
            {
                SqlConnection connection = new SqlConnection(this.Connect());
                SqlCommand command = new SqlCommand("SELECT name FROM country WHERE ID='" + ID + "' ", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    str = reader["name"].ToString();
                }
                reader.Close();
                connection.Close();
                string str2 = str.Substring(0, 1).ToUpper();
                string str3 = str.Substring(1, str.Length - 1).ToLower();
                return (str2 + str3);
            }
            catch(Exception ee)
            {
                return "";
            }
        }


        public List<NationClass> getNationalClass()
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT type,description FROM national_classes ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            List<NationClass> ap = new List<NationClass>();
            while (reader.Read())
            {
                NationClass bb = new NationClass();
                bb.classtype = reader["type"].ToString();
                bb.description = reader["description"].ToString();
                ap.Add(bb);
              //  str = reader["name"].ToString();
            }
            reader.Close();
            connection.Close();
           // string str2 = str.Substring(0, 1).ToUpper();
           // string str3 = str.Substring(1, str.Length - 1).ToLower();
            return ap;
        }

        public string getCountryId(string ID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT ID FROM country WHERE name='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["ID"].ToString();
            }
            reader.Close();
            connection.Close();
            string str2 = str.Substring(0, 1).ToUpper();
            string str3 = str.Substring(1, str.Length - 1).ToLower();
            return (str2 + str3);
        }

        public int UpdateRenewal(int vid,int vrenewal )
        {
           
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE g_renewal_info SET renewal_type=@renewal_type WHERE xID=@ID";
          
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@renewal_type", SqlDbType.Int);

            command.Parameters["@ID"].Value = vid;

            command.Parameters["@renewal_type"].Value = vrenewal;
         
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }
        public int getFee_detailCntByCat(string memberID, string cat)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("select count(fee_details.xid) AS cnt from fee_list INNER JOIN fee_details ON fee_details.fee_listID=fee_list.xid INNER JOIN twallet ON  twallet.xid=fee_details.twalletID where fee_list.xcategory='" + cat + "' AND twallet.xmemberID='" + memberID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }

        public XObjs.Fee_details getFee_detailsByHwalletID(string hID)
        {
            XObjs.Fee_details _details = new XObjs.Fee_details();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("select fee_details.* from fee_details where xid in (select hwallet.fee_detailsID from hwallet where hwallet.xid='" + hID + "') ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _details.xid = reader["xid"].ToString();
                _details.fee_listID = reader["fee_listID"].ToString();
                _details.twalletID = reader["twalletID"].ToString();
                _details.xqty = reader["xqty"].ToString();
                _details.xused = reader["xused"].ToString();
                _details.tot_amt = reader["tot_amt"].ToString();
                _details.init_amt = reader["init_amt"].ToString();
                _details.tech_amt = reader["tech_amt"].ToString();
                _details.xreg_date = reader["xlogstaff"].ToString();
                _details.xreg_date = reader["xreg_date"].ToString();
                _details.xsync = reader["xsync"].ToString();
                _details.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            connection.Close();
            return _details;
        }

        public XObjs.Fee_details getFee_detailsByID(string xid, string cat, string xmemberID)
        {
            XObjs.Fee_details _details = new XObjs.Fee_details();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("select fee_details.*,fee_list.* from fee_list  INNER JOIN fee_details ON fee_details.fee_listID=fee_list.xid  INNER JOIN twallet ON  twallet.xid=fee_details.twalletID where fee_list.xcategory='" + cat + "' AND twallet.xmemberID='" + xmemberID + "' AND twallet.xpay_status='1' AND xid='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _details.xid = reader["xid"].ToString();
                _details.fee_listID = reader["fee_listID"].ToString();
                _details.twalletID = reader["twalletID"].ToString();
                _details.xqty = reader["xqty"].ToString();
                _details.xused = reader["xused"].ToString();
                _details.tot_amt = reader["tot_amt"].ToString();
                _details.init_amt = reader["init_amt"].ToString();
                _details.tech_amt = reader["tech_amt"].ToString();
                _details.xreg_date = reader["xlogstaff"].ToString();
                _details.xreg_date = reader["xreg_date"].ToString();
                _details.xsync = reader["xsync"].ToString();
                _details.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            connection.Close();
            return _details;
        }

        public List<XObjs.Fee_details> getFee_detailsByTwalletID(string twalletID)
        {
            List<XObjs.Fee_details> list = new List<XObjs.Fee_details>();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT * from fee_details where  twalletID='" + twalletID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Fee_details item = new XObjs.Fee_details
                {
                    xid = reader["xid"].ToString(),
                    fee_listID = reader["fee_listID"].ToString(),
                    twalletID = reader["twalletID"].ToString(),
                    xqty = reader["xqty"].ToString(),
                    xused = reader["xused"].ToString(),
                    tot_amt = reader["tot_amt"].ToString(),
                    init_amt = reader["init_amt"].ToString(),
                    tech_amt = reader["tech_amt"].ToString(),
                    xreg_date = reader["xlogstaff"].ToString(),
                    xsync = reader["xsync"].ToString(),
                    xvisible = reader["xvisible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Fee_list> getFee_listByCat(string cat)
        {
            List<XObjs.Fee_list> list = new List<XObjs.Fee_list>();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT * FROM fee_list WHERE xcategory='" + cat + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Fee_list item = new XObjs.Fee_list
                {
                    xid = reader["xid"].ToString(),
                    init_amt = reader["init_amt"].ToString(),
                    item = reader["item"].ToString(),
                    item_code = reader["item_code"].ToString(),
                    tech_amt = reader["tech_amt"].ToString(),
                    xcategory = reader["xcategory"].ToString(),
                    xdesc = reader["xdesc"].ToString(),
                    xlogstaff = reader["xlogstaff"].ToString(),
                    xreg_date = reader["xreg_date"].ToString(),
                    xsync = reader["xsync"].ToString(),
                    xvisible = reader["xvisible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public XObjs.Fee_list getFee_listByID(string xid)
        {
            XObjs.Fee_list _list = new XObjs.Fee_list();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT * FROM fee_list WHERE xid='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _list.xid = reader["xid"].ToString();
                _list.init_amt = reader["init_amt"].ToString();
                _list.item = reader["item"].ToString();
                _list.item_code = reader["item_code"].ToString();
                _list.tech_amt = reader["tech_amt"].ToString();
                _list.xcategory = reader["xcategory"].ToString();
                _list.xdesc = reader["xdesc"].ToString();
                _list.xlogstaff = reader["xlogstaff"].ToString();
                _list.xreg_date = reader["xreg_date"].ToString();
                _list.xsync = reader["xsync"].ToString();
                _list.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            connection.Close();
            return _list;
        }

        public XObjs.G_App_info getG_App_infoByID(string ID)
        {
            XObjs.G_App_info _info = new XObjs.G_App_info();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_app_info WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _info.id = reader["ID"].ToString();
                _info.rtm_number = reader["rtm_number"].ToString();
                _info.application_no = reader["application_no"].ToString();
                _info.item_code = reader["item_code"].ToString();
                _info.reg_no = reader["reg_no"].ToString();
                _info.filing_date = reader["filing_date"].ToString();
                _info.log_staff = reader["log_staff"].ToString();
                _info.reg_date = reader["reg_date"].ToString();
                _info.visible = reader["visible"].ToString();
            }
            reader.Close();
            connection.Close();
            return _info;
        }

        public XObjs.G_App_info getG_App_infoByPwalletID(string pwallet)
        {
            XObjs.G_App_info _info = new XObjs.G_App_info();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_app_info WHERE log_staff='" + pwallet + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _info.id = reader["ID"].ToString();
                _info.rtm_number = reader["rtm_number"].ToString();
                _info.application_no = reader["application_no"].ToString();
                _info.item_code = reader["item_code"].ToString();
                _info.reg_no = reader["reg_no"].ToString();
                _info.filing_date = reader["filing_date"].ToString();
                _info.log_staff = reader["log_staff"].ToString();
                _info.reg_date = reader["reg_date"].ToString();
                _info.visible = reader["visible"].ToString();
            }
            reader.Close();
            connection.Close();
            return _info;
        }

        public XObjs.G_Applicant_info getG_Applicant_infoByPwalletID(string pwallet)
        {
            XObjs.G_Applicant_info _info = new XObjs.G_Applicant_info();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_applicant_info WHERE log_staff='" + pwallet + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _info.id = reader["ID"].ToString();
                _info.xname = reader["xname"].ToString();
                _info.address = reader["address"].ToString();
                _info.xemail = reader["xemail"].ToString();
                _info.xmobile = reader["xmobile"].ToString();
                _info.nationality = reader["nationality"].ToString();
                _info.trading_as = reader["trading_as"].ToString();
                _info.log_staff = reader["log_staff"].ToString();
                _info.visible = reader["visible"].ToString();
            }
            reader.Close();
            connection.Close();
            return _info;
        }

        public XObjs.G_Ass_info getG_Ass_infoByPwalletID(string pwallet)
        {
            XObjs.G_Ass_info _info = new XObjs.G_Ass_info();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_ass_info WHERE log_staff='" + pwallet + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _info.xid = reader["xID"].ToString();
                _info.date_of_assignment = reader["date_of_assignment"].ToString();
                _info.assignee_name = reader["assignee_name"].ToString();
                _info.assignee_address = reader["assignee_address"].ToString();
                _info.assignee_nationality = reader["assignee_nationality"].ToString();
                _info.assignor_name = reader["assignor_name"].ToString();
                _info.assignor_address = reader["assignor_address"].ToString();
                _info.assignor_nationality = reader["assignor_nationality"].ToString();
                _info.ass_doc = reader["ass_doc"].ToString();
                _info.log_staff = reader["log_staff"].ToString();
                _info.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            connection.Close();
            return _info;
        }

        public XObjs.G_Cert_info getG_Cert_infoByPwalletID(string pwallet)
        {
            XObjs.G_Cert_info _info = new XObjs.G_Cert_info();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_cert_info WHERE log_staff='" + pwallet + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _info.xid = reader["xID"].ToString();
                _info.pub_date = reader["pub_date"].ToString();
                _info.pub_details = reader["pub_details"].ToString();
                _info.cert_doc = reader["cert_doc"].ToString();
                _info.pub_doc = reader["pub_doc"].ToString();
                _info.log_staff = reader["log_staff"].ToString();
                _info.reg_date = reader["reg_date"].ToString();
                _info.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            connection.Close();
            return _info;
        }

        public XObjs.G_Change_info getG_Change_infoByPwalletID(string pwallet)
        {
            XObjs.G_Change_info _info = new XObjs.G_Change_info();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_change_info WHERE log_staff='" + pwallet + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _info.xid = reader["xID"].ToString();
                _info.old_name = reader["old_name"].ToString();
                _info.old_address = reader["old_address"].ToString();
                _info.old_goods = reader["old_goods"].ToString();
                _info.old_tm_class = reader["old_tm_class"].ToString();
                _info.new_name = reader["new_name"].ToString();
                _info.new_address = reader["new_address"].ToString();
                _info.new_goods = reader["new_goods"].ToString();
                _info.new_tm_class = reader["new_tm_class"].ToString();
                _info.log_staff = reader["log_staff"].ToString();
                _info.reg_date = reader["reg_date"].ToString();
                _info.visible = reader["visible"].ToString();
            }
            reader.Close();
            connection.Close();
            return _info;
        }

        public XObjs.G_Merger_info getG_Merger_infoByPwalletID(string pwallet)
        {
            XObjs.G_Merger_info _info = new XObjs.G_Merger_info();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_merger_info WHERE log_staff='" + pwallet + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _info.xid = reader["ID"].ToString();
                _info.original_name = reader["original_name"].ToString();
                _info.original_address = reader["original_address"].ToString();
                _info.merging_name = reader["merging_name"].ToString();
                _info.merging_address = reader["merging_address"].ToString();
                _info.merged_coy_name = reader["merged_coy_name"].ToString();
                _info.merger_date = reader["merger_date"].ToString();
                _info.merger_doc = reader["merger_doc"].ToString();
                _info.log_staff = reader["log_staff"].ToString();
                _info.visible = reader["visible"].ToString();
            }
            reader.Close();
            connection.Close();
            return _info;
        }

        public XObjs.G_Other_items_info getG_Other_items_infoByPwalletID(string pwallet)
        {
            XObjs.G_Other_items_info _info = new XObjs.G_Other_items_info();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_other_items_info WHERE log_staff='" + pwallet + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _info.xid = reader["xID"].ToString();
                _info.req_details = reader["req_details"].ToString();
                _info.log_staff = reader["log_staff"].ToString();
                _info.reg_date = reader["reg_date"].ToString();
                _info.visible = reader["visible"].ToString();
            }
            reader.Close();
            connection.Close();
            return _info;
        }

        public XObjs.G_Prelim_search_info getG_Prelim_search_infoByPwalletID(string pwallet)
        {
            XObjs.G_Prelim_search_info _info = new XObjs.G_Prelim_search_info();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_prelim_search_info WHERE log_staff='" + pwallet + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _info.xid = reader["xID"].ToString();
                _info.xtitle = reader["xtitle"].ToString();
                _info.xclass = reader["xclass"].ToString();
                _info.xclass_desc = reader["xclass_desc"].ToString();
                _info.log_staff = reader["log_staff"].ToString();
                _info.reg_date = reader["reg_date"].ToString();
                _info.visible = reader["visible"].ToString();
            }
            reader.Close();
            connection.Close();
            return _info;
        }

        public XObjs.G_Pwallet getG_PwalletByID(string ID)
        {
            XObjs.G_Pwallet pwallet = new XObjs.G_Pwallet();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_pwallet WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                pwallet.xid = reader["ID"].ToString();
                pwallet.twalletID = reader["twalletID"].ToString();
                pwallet.validationID = reader["validationID"].ToString();
                pwallet.applicantID = reader["applicantID"].ToString();
                pwallet.log_officer = reader["log_officer"].ToString();
                pwallet.amt = reader["amt"].ToString();
                pwallet.stage = reader["stage"].ToString();
                pwallet.status = reader["status"].ToString();
                pwallet.data_status = reader["data_status"].ToString();
                pwallet.reg_date = reader["reg_date"].ToString();
                pwallet.visible = reader["visible"].ToString();
            }
            reader.Close();
            connection.Close();
            return pwallet;
        }

        public string getCheckStatusDetails(string validationID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT ID FROM pwallet WHERE validationID='" + validationID + "'  ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = Convert.ToInt64(reader["ID"]).ToString();
            }
            reader.Close();
            return str;
        }

        public XObjs.G_Pwallet getG_PwalletByValidationID(string ValidationID)
        {
            XObjs.G_Pwallet pwallet = new XObjs.G_Pwallet();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE validationID='" + ValidationID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                pwallet.xid = reader["ID"].ToString();
                pwallet.twalletID = reader["twalletID"].ToString();
                pwallet.validationID = reader["validationID"].ToString();
                pwallet.applicantID = reader["applicantID"].ToString();
                pwallet.log_officer = reader["log_officer"].ToString();
                pwallet.amt = reader["amt"].ToString();
                pwallet.stage = reader["stage"].ToString();
                pwallet.status = reader["status"].ToString();
                pwallet.data_status = reader["data_status"].ToString();
                pwallet.reg_date = reader["reg_date"].ToString();
                pwallet.visible = reader["visible"].ToString();
            }
            reader.Close();
            connection.Close();
            return pwallet;
        }


        public XObjs.G_Pwallet getG_PwalletByValidationID2(string ValidationID)
        {
            XObjs.G_Pwallet pwallet = new XObjs.G_Pwallet();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_pwallet WHERE validationID='" + ValidationID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                pwallet.xid = reader["ID"].ToString();
                pwallet.twalletID = reader["twalletID"].ToString();
                pwallet.validationID = reader["validationID"].ToString();
                pwallet.applicantID = reader["applicantID"].ToString();
                pwallet.log_officer = reader["log_officer"].ToString();
                pwallet.amt = reader["amt"].ToString();
                pwallet.stage = reader["stage"].ToString();
                pwallet.status = reader["status"].ToString();
                pwallet.data_status = reader["data_status"].ToString();
                pwallet.reg_date = reader["reg_date"].ToString();
                pwallet.visible = reader["visible"].ToString();
            }
           


            reader.Close();
            connection.Close();
            return pwallet;
        }

        public   List<Recordal> getG_PwalletByID2(string ValidationID)
        {
            List<Recordal> pp2 = new List<Recordal>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM Recordal WHERE log_staff='" + ValidationID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            while (reader.Read())
            {
                Recordal pp = new Recordal();

                try
                {
                    pp.ID = reader["ID"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.OLD_APPLICANTNAME = reader["OLD_APPLICANTNAME"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.OLD_AGENTNAME = reader["OLD_AGENTNAME"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.NEW_AGENTNAME = reader["NEW_AGENTNAME"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.OLD_AGENTEMAIL = reader["OLD_AGENTEMAIL"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.NEW_AGENTEMAIL = reader["NEW_AGENTEMAIL"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.OLD_AGENTCODE = reader["OLD_AGENTCODE"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.NEW_AGENTCODE = reader["NEW_AGENTCODE"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.OLD_AGENTPHONE = reader["OLD_AGENTPHONE"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.NEW_AGENTPHONE = reader["NEW_AGENTPHONE"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.OLDAGENT_ADDRESS = reader["OLDAGENT_ADDRESS"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.NEWAGENT_ADDRESS = reader["NEWAGENT_ADDRESS"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.NEW_APPLICANTNAME = reader["NEW_APPLICANTNAME"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.RECORDAL_REQUEST_DATE = Convert.ToDateTime(reader["RECORDAL_REQUEST_DATE"]);
                }
                catch (Exception ee)
                {

                }


                try
                {
                    pp.RECORDAL_REQUEST_DATE2 = Convert.ToString(reader["RECORDAL_REQUEST_DATE"]);
                }
                catch (Exception ee)
                {

                }
                try
                {

               
                pp.RECORDAL_APPROVE_DATE = Convert.ToDateTime(reader["RECORDAL_APPROVE_DATE"]);
                     }

                catch (Exception ee)
                {

                }
                try
                {
                    pp.AMOUNT = reader["AMOUNT"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.TRANSACTIONID = reader["TRANSACTIONID"].ToString();
                }
                catch (Exception ee)
                {

                }
                try { 
                pp.OFFICER = reader["XOFFICER"].ToString();
                    }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.VSTATUS = reader["STATUS"].ToString();
                }
                catch (Exception ee)
                {

                }


                try
                {
                    pp.OLD_APPLICANTADDRESS = reader["OLD_APPLICANTADDRESS"].ToString();
                }
                catch (Exception ee)
                {

                }


                try
                {
                    pp.NEW_APPLICANTADDRESS = reader["NEW_APPLICANTADDRESS"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.RECORDAL_TYPE = reader["RECORDAL_TYPE"].ToString();
                }
                catch (Exception ee)
                {

                }


                try
                {
                    pp.Xcomment = reader["Xcomment"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.OLD_PRODUCT_TITLE = reader["OLD_PRODUCT_TITLE"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.NEW_PRODUCT_TITLE = reader["NEW_PRODUCT_TITLE"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.OLD_PRODUCT_LOGO = reader["OLD_PRODUCT_LOGO"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.NEW_PRODUCT_LOGO = reader["NEW_PRODUCT_LOGO"].ToString();
                }
                catch (Exception ee)
                {

                }


                try
                {
                    pp.LOGO_DESC = reader["LOGO_DESC"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.Detail_Id = reader["Detail_Id"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.data_status = reader["data_status"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.data_status2 = reader["data_status2"].ToString();
                }
                catch (Exception ee)
                {

                }


                if (reader["RECORDAL_TYPE"].ToString() == "Change_Name")
                {
                    pp.RECORDAL_TYPE3 = "FORM 22";

                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Address")
                {

                   pp.RECORDAL_TYPE3 = "FORM 19";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Rectification")
                {

                    pp.RECORDAL_TYPE3 = "FORM 26";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Assignment")
                {

                    pp.RECORDAL_TYPE3 = "FORM 16";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Assignment2")
                {

                    pp.RECORDAL_TYPE3 = "FORM 17";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Renewal")
                {

                    pp.RECORDAL_TYPE3 = "FORM 12";
                }

                pp2.Add(pp);
               
            }
            reader.Close();
            connection.Close();
            return pp2;
        }
        public XObjs.Registration getAgentByVID(String Transid)
        {
            XObjs.Registration dd4 = new XObjs.Registration();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT ID FROM pwallet  WHERE validationID='" + Transid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

            while (reader.Read())
            {
                String xmember = reader["ID"].ToString();
                dd4 = getAgent2(xmember);

            }
            return dd4;
        }
        public XObjs.Registration getAgent(String  Transid)
        {
            XObjs.Registration dd4 = new XObjs.Registration();
           SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT xmemberid FROM twallet  WHERE transid='" + Transid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

            while (reader.Read())
            {
                String xmember = reader["xmemberid"].ToString();
                dd4 = getAgent2(xmember);
               
            }

            if ((dd4.Sys_ID == null))
            {

                dd4 = getAgent3(Transid);
            }
            return dd4;
            }

        public XObjs.Registration getAgent2(String Transid)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT *  FROM registrations  WHERE xid='" + Transid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            Classes.XObjs.Registration zz = new XObjs.Registration();
            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

            while (reader.Read())
            {
                try {
                    zz.Firstname = reader["Firstname"].ToString();
                }
                catch(Exception ee)
                {

                }

                try
                {
                    zz.Surname = reader["Surname"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    zz.CompanyAddress = reader["CompanyAddress"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    zz.Email = reader["Email"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    zz.PhoneNumber = reader["PhoneNumber"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    zz.Sys_ID = reader["Sys_ID"].ToString();
                }
                catch (Exception ee)
                {

                }

            }

            return zz;
        }

        public XObjs.Registration getAgent3(String Transid)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT agentcode ,ApplicantName,Applicantaddress,ApplicantEmail,ApplicantPhone  FROM branchcollecttransactions  WHERE TransactionId='" + Transid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            Classes.XObjs.Registration zz = new XObjs.Registration();
            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

            while (reader.Read())
            {
                try
                {
                    zz.Firstname = reader["ApplicantName"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    zz.Surname = reader["ApplicantName"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    zz.CompanyAddress = reader["Applicantaddress"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    zz.Email = reader["ApplicantEmail"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    zz.PhoneNumber = reader["ApplicantPhone"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    zz.Sys_ID = reader["agentcode"].ToString();
                }
                catch (Exception ee)
                {

                }

            }

            return zz;
        }
        public List<Recordal> getG_PwalletByID3(Int32 ValidationID)
        {
            List<Recordal> pp2 = new List<Recordal>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM Recordal WHERE ID='" + ValidationID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            while (reader.Read())
            {
                Recordal pp = new Recordal();
                try
                {
                    pp.OLD_APPLICANTNAME = reader["OLD_APPLICANTNAME"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.OLD_AGENTNAME = reader["OLD_AGENTNAME"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.NEW_AGENTNAME = reader["NEW_AGENTNAME"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.OLD_AGENTEMAIL = reader["OLD_AGENTEMAIL"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.NEW_AGENTEMAIL = reader["NEW_AGENTEMAIL"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.OLD_AGENTCODE = reader["OLD_AGENTCODE"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.NEW_AGENTCODE = reader["NEW_AGENTCODE"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.OLD_AGENTPHONE = reader["OLD_AGENTPHONE"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.NEW_AGENTPHONE = reader["NEW_AGENTPHONE"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.OLDAGENT_ADDRESS = reader["OLDAGENT_ADDRESS"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.NEWAGENT_ADDRESS = reader["NEWAGENT_ADDRESS"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.NEW_APPLICANTNAME = reader["NEW_APPLICANTNAME"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.RECORDAL_REQUEST_DATE = Convert.ToDateTime(reader["RECORDAL_REQUEST_DATE"]);
                }
                catch (Exception ee)
                {

                }
                try
                {


                    pp.RECORDAL_APPROVE_DATE = Convert.ToDateTime(reader["RECORDAL_APPROVE_DATE"]);
                }

                catch (Exception ee)
                {

                }
                try
                {
                    pp.AMOUNT = reader["AMOUNT"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.TRANSACTIONID = reader["TRANSACTIONID"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.OFFICER = reader["XOFFICER"].ToString();
                }
                catch (Exception ee)
                {
                    pp.OFFICER = null;
                }
                try
                {
                    pp.VSTATUS = reader["STATUS"].ToString();
                }
                catch (Exception ee)
                {

                }


                try
                {
                    pp.OLD_APPLICANTADDRESS = reader["OLD_APPLICANTADDRESS"].ToString();
                }
                catch (Exception ee)
                {

                }


                try
                {
                    pp.NEW_APPLICANTADDRESS = reader["NEW_APPLICANTADDRESS"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.RECORDAL_TYPE = reader["RECORDAL_TYPE"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.Xcomment = reader["Xcomment"].ToString();
                }
                catch (Exception ee)
                {

                }


                try
                {
                    pp.OLDCLASS = reader["old_class"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.NEWCLASS = reader["new_class"].ToString();
                }
                catch (Exception ee)
                {

                }



                try
                {
                    pp.OLD_PRODUCT_TITLE = reader["OLD_PRODUCT_TITLE"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.NEW_PRODUCT_TITLE = reader["NEW_PRODUCT_TITLE"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.description = reader["Description"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.OLD_PRODUCT_LOGO = reader["OLD_PRODUCT_LOGO"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.NEW_PRODUCT_LOGO= reader["NEW_PRODUCT_LOGO"].ToString();
                }
                catch (Exception ee)
                {

                }


                try
                {
                    pp.LOGO_DESC= reader["LOGO_DESC"].ToString();
                }
                catch (Exception ee)
                {

                }



                try
                {
                    pp.Detail_Id = reader["Detail_Id"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.data_status = reader["data_status"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.data_status2 = reader["data_status2"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.UPLOADPATH = reader["UPLOADPATH"].ToString();
                }
                catch (Exception ee)
                {


                }

                try
                {
                    pp.UPLOADPATH2 = reader["UPLOADPATH2"].ToString();
                }
                catch (Exception ee)
                {


                }


                try
                {
                    pp.UPLOADPATH3 = reader["UPLOADPATH3"].ToString();
                }
                catch (Exception ee)
                {


                }



                pp2.Add(pp);

            }
            reader.Close();
            connection.Close();
            return pp2;
        }


        public List<Recordal_Detail> get_RecordalDetail(String  ValidationID)
        {
            List<Recordal_Detail> pp2 = new List<Recordal_Detail>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM Recordal2 WHERE ID='" + ValidationID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            while (reader.Read())
            {
                Recordal_Detail pp = new Recordal_Detail();
                try
                {
                    pp.oldApplicantName = reader["oldApplicantName"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.assignment_date = reader["Assignment_Date"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.newApplicantName = reader["newApplicantName"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.newApplicantAddress = reader["newApplicantAddress"].ToString(); 
                }
                catch (Exception ee)
                {

                }
                try
                {


                    pp.oldApplicantAddress = reader["oldApplicantAddress"].ToString(); 
                }

                catch (Exception ee)
                {

                }
                try
                {
                    pp.newApplicantNationality = reader["newApplicantNationality"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.OldApplicantNationality = reader["OldApplicantNationality"].ToString();
                }
                catch (Exception ee)
                {

                }


                try
                {
                    pp.assignment_upload = reader["assignment_upload"].ToString();
                }
                catch (Exception ee)
                {

                }


                try
                {
                    pp.Assignee_upload = reader["Assignee_upload"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.deed_Assignment_upload = reader["deed_Assignment_upload"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.Power_of_Attorney_upload = reader["Power_of_Attorney_upload"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.Registration_of_Mark_upload = reader["Registration_of_Mark_upload"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.Registrar_direction = reader["Registrar_direction"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.advertisements_complying = reader["advertisements_complying"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.publication = reader["publication"].ToString();
                }
                catch (Exception ee)
                {

                }


                try
                {
                    pp.name_certificate = reader["name_certificate"].ToString();
                }
                catch (Exception ee)
                {

                }
               
               
               
                pp2.Add(pp);

            }
            reader.Close();
            connection.Close();
            return pp2;
        }


        public List<Recordal_Detail2> get_RecordalDetail2(String ValidationID)
        {
            List<Recordal_Detail2> pp2 = new List<Recordal_Detail2>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM Recordal3 WHERE ID='" + ValidationID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            while (reader.Read())
            {
                Recordal_Detail2 pp = new Recordal_Detail2();
                try
                {
                    pp.Renewal_DueDate = reader["Renewal_DueDate"].ToString();
                }
                catch (Exception ee)
                {

                }
                try
                {
                    pp.Renewal_Type = reader["Renewal_Type"].ToString();
                }
                catch (Exception ee)
                {

                }


                try
                {
                    pp.power_of_attorney = reader["power_of_attorney"].ToString();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    pp.Certificate_Of_Registration = reader["Certificate_Of_Registration"].ToString();
                }
                catch (Exception ee)
                {

                }

                pp2.Add(pp);

            }
            reader.Close();
            connection.Close();
            return pp2;
        }

        public XObjs.G_Renewal_info getG_Renewal_infoByPwalletID(string pwallet)
        {
            XObjs.G_Renewal_info _info = new XObjs.G_Renewal_info();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_renewal_info WHERE log_staff='" + pwallet + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _info.xid = reader["xID"].ToString();
                _info.prev_renewal_date = reader["prev_renewal_date"].ToString();
                _info.renewal_type = reader["renewal_type"].ToString();
                _info.log_staff = reader["log_staff"].ToString();
                _info.reg_date = reader["reg_date"].ToString();
                _info.visible = reader["visible"].ToString();
            }
            reader.Close();
            connection.Close();
            return _info;
        }

        public XObjs.G_Tm_info getG_Tm_infoByPwalletID(string log_staff)
        {
            XObjs.G_Tm_info _info = new XObjs.G_Tm_info();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_tm_info WHERE log_staff='" + log_staff + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _info.xid = reader["xID"].ToString();
                _info.reg_number = reader["reg_number"].ToString();
                _info.xtype = reader["xtype"].ToString();
                _info.tm_title = reader["tm_title"].ToString();
                _info.tm_class = reader["tm_class"].ToString();
                _info.tm_desc = reader["tm_desc"].ToString();
                _info.logo_descID = reader["logo_descID"].ToString();
                _info.disclaimer = reader["disclaimer"].ToString();
                _info.logo_pic = reader["logo_pic"].ToString();
                _info.auth_doc = reader["auth_doc"].ToString();
                _info.sup_doc1 = reader["sup_doc1"].ToString();
                _info.app_letter_doc = reader["app_letter_doc"].ToString();
                _info.log_staff = reader["log_staff"].ToString();
                _info.reg_date = reader["reg_date"].ToString();
                _info.visible = reader["visible"].ToString();
            }
            reader.Close();
            connection.Close();
            return _info;
        }

        public XObjs.Gen_Agent_info getGenAgentByPwalletID(string pwallet)
        {
            XObjs.Gen_Agent_info _info = new XObjs.Gen_Agent_info();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_agent_info WHERE log_staff='" + pwallet + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _info.xid = reader["xid"].ToString();
                _info.xname = reader["xname"].ToString();
                _info.code = reader["code"].ToString();
                _info.xpassword = reader["xpassword"].ToString();
                _info.nationality = reader["nationality"].ToString();
                _info.country = reader["country"].ToString();
                _info.state = reader["state"].ToString();
                _info.address = reader["address"].ToString();
                _info.telephone = reader["telephone"].ToString();
                _info.email = reader["email"].ToString();
                _info.log_staff = reader["log_staff"].ToString();
                _info.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return _info;
        }

        public List<XObjs.Hwallet> getHwalletByFee_detailsID(string fee_detailsID)
        {
            List<XObjs.Hwallet> list = new List<XObjs.Hwallet>();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT * FROM hwallet WHERE fee_detailsID='" + fee_detailsID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Hwallet item = new XObjs.Hwallet
                {
                    xid = reader["xid"].ToString(),
                    transID = reader["transID"].ToString(),
                    fee_detailsID = reader["fee_detailsID"].ToString(),
                    used_status = reader["used_status"].ToString(),
                    xreg_date = reader["xreg_date"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public XObjs.Hwallet getHwalletByID(string xid)
        {
            XObjs.Hwallet hwallet = new XObjs.Hwallet();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT * FROM hwallet WHERE xid='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                hwallet.xid = reader["xid"].ToString();
                hwallet.transID = reader["transID"].ToString();
                hwallet.fee_detailsID = reader["fee_detailsID"].ToString();
                hwallet.used_status = reader["used_status"].ToString();
                hwallet.xreg_date = reader["xreg_date"].ToString();
            }
            reader.Close();
            connection.Close();
            return hwallet;
        }

        public XObjs.XMember getMemberByID(string xid)
        {
            XObjs.XMember member = new XObjs.XMember();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT * FROM xmember WHERE xid='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                member.xid = reader["xid"].ToString();
                member.xname = reader["xname"].ToString();
                member.cname = reader["cname"].ToString();
                member.xpassword = reader["xpassword"].ToString();
                member.nationality = reader["nationality"].ToString();
                member.addressID = reader["addressID"].ToString();
                member.sys_ID = reader["sys_ID"].ToString();
                member.xreg_date = reader["xreg_date"].ToString();
                member.xvisible = reader["xvisible"].ToString();
                member.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return member;
        }

        public string getMemberTypeByID(string id)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT xmembertype from pwallet where xid='" + id + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["xmembertype"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public int getPaidFee_detail_ItemsCntByCat(string memberID, string cat, string xpaystatus)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("select count(hwallet.xid) as cnt from fee_list  INNER JOIN fee_details ON fee_details.fee_listID=fee_list.xid  INNER JOIN twallet ON  twallet.xid=fee_details.twalletID  INNER JOIN hwallet ON hwallet.fee_detailsID=fee_details.xid where fee_list.xcategory='" + cat + "' AND twallet.xmemberID='" + memberID + "' AND twallet.xpay_status='" + xpaystatus + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }

        public int updateHwallet2(string xid, string used_status)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("UPDATE hwallet SET used_status='" + used_status + "'   WHERE xid='" + xid + "'  ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }


     


        public int getPaidFee_detailCntByCat(string memberID, string cat, string xpaystatus)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("select count(fee_details.xid) AS cnt from fee_list INNER JOIN fee_details ON fee_details.fee_listID=fee_list.xid INNER JOIN twallet ON  twallet.xid=fee_details.twalletID where fee_list.xcategory='" + cat + "' AND twallet.xmemberID='" + memberID + "' AND twallet.xpay_status='" + xpaystatus + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }


        public int getCountMacInfo(string Reg_No)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select count(reg_number) AS cnt from mark_info  where reg_number='" + Reg_No + "'  ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }

        public XObjs.Pwallet getPwalletByID(string xid)
        {
            XObjs.Pwallet pwallet = new XObjs.Pwallet();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE xid='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                pwallet.xid = reader["xid"].ToString();
                pwallet.xmembertype = reader["xmembertype"].ToString();
                pwallet.xmemberID = reader["xmemberID"].ToString();
                pwallet.xemail = reader["xemail"].ToString();
                pwallet.xmobile = reader["xmobile"].ToString();
                pwallet.xpass = reader["xpass"].ToString();
                pwallet.reg_date = reader["reg_date"].ToString();

                pwallet.data_status = reader["data_status"].ToString();

                pwallet.status = reader["status"].ToString();
            }
            reader.Close();
            connection.Close();
            return pwallet;
        }

        public XObjs.Pwallet getPwalletByID2(string xid)
        {
            XObjs.Pwallet pwallet = new XObjs.Pwallet();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE id='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
              

                pwallet.data_status = reader["data_status"].ToString();

                pwallet.status = reader["status"].ToString();
            }
            reader.Close();
            connection.Close();
            return pwallet;
        }


        public XObjs.Pwallet getPwalletByOnlineId(string xid)
        {
            XObjs.Pwallet pwallet = new XObjs.Pwallet();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE validationid='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {


                pwallet.data_status = reader["data_status"].ToString();

                pwallet.status = reader["status"].ToString();
            }
            reader.Close();
            connection.Close();
            return pwallet;
        }

        public XObjs.Pwallet getPwalletByMemberID(string xmemberID)
        {
            XObjs.Pwallet pwallet = new XObjs.Pwallet();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE xmemberID='" + xmemberID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                pwallet.xid = reader["xid"].ToString();
                pwallet.xmembertype = reader["xmembertype"].ToString();
                pwallet.xmemberID = reader["xmemberID"].ToString();
                pwallet.xemail = reader["xemail"].ToString();
                pwallet.xmobile = reader["xmobile"].ToString();
                pwallet.xpass = reader["xpass"].ToString();
                pwallet.reg_date = reader["reg_date"].ToString();
            }
            reader.Close();
            connection.Close();
            return pwallet;
        }

        public XObjs.Pwallet getPwalletByMobile(string xmobile)
        {
            XObjs.Pwallet pwallet = new XObjs.Pwallet();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE xmobile='" + xmobile + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                pwallet.xid = reader["xid"].ToString();
                pwallet.xmembertype = reader["xmembertype"].ToString();
                pwallet.xmemberID = reader["xmemberID"].ToString();
                pwallet.xemail = reader["xemail"].ToString();
                pwallet.xmobile = reader["xmobile"].ToString();
                pwallet.xpass = reader["xpass"].ToString();
                pwallet.reg_date = reader["reg_date"].ToString();
            }
            reader.Close();
            connection.Close();
            return pwallet;
        }

        public XObjs.Scard getRandomScard()
        {
            XObjs.Scard scard = new XObjs.Scard();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM scard ORDER BY NEWID()   ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                scard.xid = reader["xid"].ToString();
                scard.xnum = reader["xnum"].ToString();
                scard.xvalid = reader["xvalid"].ToString();
                scard.xlogstaff = reader["xlogstaff"].ToString();
                scard.xvalid = reader["xvalid"].ToString();
                scard.xreg_date = reader["xreg_date"].ToString();
                scard.xsync = reader["xsync"].ToString();
                scard.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            connection.Close();
            return scard;
        }

        public string getStateIDByName(string name)
        {
            string str = "";
            try
            {
                SqlConnection connection = new SqlConnection(this.ConnectXhome());
                SqlCommand command = new SqlCommand("SELECT ID FROM state WHERE name='" + name + "' ", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    str = reader["ID"].ToString();
                }
                reader.Close();
                connection.Close();
            }
            catch (FormatException)
            {
            }
            finally
            {
                if (str == "")
                {
                    str = "1";
                }
            }
            return str;
        }

        public string getStateName(string ID)
        {
            string str = "";
            try
            {
                SqlConnection connection = new SqlConnection(this.ConnectXhome());
                SqlCommand command = new SqlCommand("SELECT name FROM state WHERE ID='" + Convert.ToInt64(ID) + "' ", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    str = reader["name"].ToString();
                }
                reader.Close();
                connection.Close();
            }
            catch (FormatException)
            {
            }
            finally
            {
                if (str == "")
                {
                    str = "N/A";
                }
            }
            string str2 = str.Substring(0, 1).ToUpper();
            string str3 = str.Substring(1, str.Length - 1).ToLower();
            return (str2 + str3);
        }

        public XObjs.Trademark_item getTrademark_itemByMemberID(string hwalletID)
        {
            XObjs.Trademark_item _item = new XObjs.Trademark_item();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("select hwallet.*,fee_details.*,fee_list.* from hwallet LEFT OUTER JOIN fee_details ON hwallet.fee_detailsID=fee_details.xid LEFT OUTER JOIN fee_list ON fee_details.fee_listID=fee_list.xid where hwallet.xid='" + hwalletID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                _item.transID = reader["transID"].ToString();
                _item.item_code = reader["item_code"].ToString();
                _item.amt = reader["init_amt"].ToString();
                _item.xgt = "xpay";
            }
            reader.Close();
            connection.Close();
            return _item;
        }

        public List<XObjs.Twallet> getTwalletByMemberID(string xmemberID, string transID)
        {
            List<XObjs.Twallet> list = new List<XObjs.Twallet>();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT * from twallet where xmemberID='" + xmemberID + "' AND transID='" + transID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Twallet item = new XObjs.Twallet
                {
                    xid = reader["xid"].ToString(),
                    transID = reader["transID"].ToString(),
                    xmemberID = reader["xmemberID"].ToString(),
                    xpay_status = reader["xpay_status"].ToString(),
                    xgt = reader["xgt"].ToString(),
                    ref_no = reader["ref_no"].ToString(),
                    xbankerID = reader["xbankerID"].ToString(),
                    xreg_date = reader["xreg_date"].ToString(),
                    xsync = reader["xsync"].ToString(),
                    xvisible = reader["xvisible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Twallet> getTwalletByMemberID2(string transID, string transID2)
        {
            List<XObjs.Twallet> list = new List<XObjs.Twallet>();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT hwallet.xid,twallet.transID ,twallet.xmemberID ,twallet.xpay_status ,twallet.xgt ,twallet.ref_no,twallet.xbankerID,twallet.xreg_date,fee_details.tot_amt  from twallet inner join fee_details on fee_details.twalletID=twallet.XID inner join hwallet on hwallet.transID =twallet.transID   where  hwallet.xid='" + transID + "' and (fee_details.fee_listID='" + transID2 + "' or fee_details.fee_listID='10066'  ) and xpay_status='1'  ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Twallet item = new XObjs.Twallet
                {
                    xid = reader["xid"].ToString(),
                    transID = reader["transID"].ToString(),
                    xmemberID = reader["xmemberID"].ToString(),
                    xpay_status = reader["xpay_status"].ToString(),
                    xgt = reader["xgt"].ToString(),
                    ref_no = reader["ref_no"].ToString(),
                    xbankerID = reader["xbankerID"].ToString(),
                    xreg_date = reader["xreg_date"].ToString(),
                    tot_amt = reader["tot_amt"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

       


        public List<XObjs.Twallet> getBranchCollectPayment(string transID)
        {
            List<XObjs.Twallet> list = new List<XObjs.Twallet>();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("select id, TransactionID,totalamount,TransactionDate,AgentCode,ReferenceId from branchcollecttransactions     where TransactionID='" + transID + "'   ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Twallet item = new XObjs.Twallet
                {
                    xid = reader["id"].ToString(),
                    transID = reader["TransactionID"].ToString(),
                   

                    xgt = reader["AgentCode"].ToString(),
                    ref_no = reader["ReferenceId"].ToString(),

                    xreg_date = reader["TransactionDate"].ToString(),
                    tot_amt = reader["totalamount"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Twallet> getValidatedTwalletByMemberID(string xmemberID, string transID)
        {
            List<XObjs.Twallet> list = new List<XObjs.Twallet>();
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT * from twallet where xmemberID='" + xmemberID + "'  AND transID='" + transID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Twallet item = new XObjs.Twallet
                {
                    xid = reader["xid"].ToString(),
                    transID = reader["transID"].ToString(),
                    xmemberID = reader["xmemberID"].ToString(),
                    xpay_status = reader["xpay_status"].ToString(),
                    xgt = reader["xgt"].ToString(),
                    ref_no = reader["ref_no"].ToString(),
                    xbankerID = reader["xbankerID"].ToString(),
                    xreg_date = reader["xreg_date"].ToString(),
                    xsync = reader["xsync"].ToString(),
                    xvisible = reader["xvisible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<Classes.XObjs.Registration> getAllRegistrations()
        {
            List<Classes.XObjs.Registration> x_lt = new List<XObjs.Registration>();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM registrations  ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Classes.XObjs.Registration x = new XObjs.Registration();
                x.xid = reader["xid"].ToString();
                x.AccrediationType = reader["AccrediationType"].ToString();
                x.Sys_ID = reader["Sys_ID"].ToString();
                x.Firstname = reader["Firstname"].ToString();
                x.Surname = reader["Surname"].ToString();
                x.Email = reader["Email"].ToString();
                x.xpassword = reader["xpassword"].ToString();
                x.DateOfBrith = reader["DateOfBrith"].ToString();
                x.IncorporatedDate = reader["IncorporatedDate"].ToString();
                x.Nationality = reader["Nationality"].ToString();
                x.PhoneNumber = reader["PhoneNumber"].ToString();
                x.CompanyName = reader["CompanyName"].ToString();
                x.CompanyAddress = reader["CompanyAddress"].ToString();
                x.ContactPerson = reader["ContactPerson"].ToString();
                x.ContactPersonPhone = reader["ContactPersonPhone"].ToString();
                x.CompanyWebsite = reader["CompanyWebsite"].ToString();
                x.Certificate = reader["Certificate"].ToString();
                x.Introduction = reader["Introduction"].ToString();
                x.Principal = reader["Principal"].ToString();
                x.logo = reader["logo"].ToString();
                x.xreg_date = reader["xreg_date"].ToString();
                x.xstatus = reader["xstatus"].ToString();
                x.xvisible = reader["xvisible"].ToString();
                x.xsync = reader["xsync"].ToString();
                x_lt.Add(x);
            }
            reader.Close();
            connection.Close();
            return x_lt;
        }
        public Classes.XObjs.Registration getRegistrationBySubagentRegistrationID(string RegistrationID)
        {
            Classes.XObjs.Registration x = new XObjs.Registration();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM registrations WHERE (xid='" + RegistrationID + "')  ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                x.xid = reader["xid"].ToString();
                x.AccrediationType = reader["AccrediationType"].ToString();
                x.Sys_ID = reader["Sys_ID"].ToString();
                x.Firstname = DecodeChar(reader["Firstname"].ToString());
                x.Surname = DecodeChar(reader["Surname"].ToString());
                x.Email = DecodeChar(reader["Email"].ToString());
                x.xpassword = DecodeChar(reader["xpassword"].ToString());
                x.DateOfBrith = reader["DateOfBrith"].ToString();
                x.IncorporatedDate = reader["IncorporatedDate"].ToString();
                x.Nationality = reader["Nationality"].ToString();
                x.PhoneNumber = reader["PhoneNumber"].ToString();
                x.CompanyName = DecodeChar(reader["CompanyName"].ToString());
                x.CompanyAddress = DecodeChar(reader["CompanyAddress"].ToString());
                x.ContactPerson = DecodeChar(reader["ContactPerson"].ToString());
                x.ContactPersonPhone = reader["ContactPersonPhone"].ToString();
                x.CompanyWebsite = DecodeChar(reader["CompanyWebsite"].ToString());
                x.Certificate = reader["Certificate"].ToString();
                x.Introduction = reader["Introduction"].ToString();
                x.Principal = reader["Principal"].ToString();
                x.logo = reader["logo"].ToString();
                x.xreg_date = reader["xreg_date"].ToString();
                x.xstatus = reader["xstatus"].ToString();
                x.xvisible = reader["xvisible"].ToString();
                x.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return x;
        }
        public List<Classes.XObjs.Subagent> getAllSubAgents()
        {
            List<Classes.XObjs.Subagent> x_lt = new List<Classes.XObjs.Subagent>();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM subagents", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Classes.XObjs.Subagent x = new XObjs.Subagent();
                x.xid = reader["xid"].ToString();
                x.RegistrationID = reader["RegistrationID"].ToString();
                x.Surname = reader["Surname"].ToString();
                x.Firstname = reader["Firstname"].ToString();
                x.Email = reader["Email"].ToString();
                x.xpassword = reader["xpassword"].ToString();
                x.Telephone = reader["Telephone"].ToString();
                x.AssignID = reader["AssignID"].ToString();
                x.Sys_ID = reader["Sys_ID"].ToString();
                x.Address = reader["Address"].ToString();
                x.AgentPassport = reader["AgentPassport"].ToString();
                x.xreg_date = reader["xreg_date"].ToString();
                x.xstatus = reader["xstatus"].ToString();
                x.xvisible = reader["xvisible"].ToString();
                x.xsync = reader["xsync"].ToString();
                x_lt.Add(x);
            }
            reader.Close();
            connection.Close();
            return x_lt;
        }
        public Classes.XObjs.Registration getRegistrationByPhoneNumber(string PhoneNumber)
        {
            Classes.XObjs.Registration x = new XObjs.Registration();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM registrations WHERE PhoneNumber='" + PhoneNumber + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                x.xid = reader["xid"].ToString();
                x.AccrediationType = reader["AccrediationType"].ToString();
                x.Sys_ID = reader["Sys_ID"].ToString();
                x.Firstname = DecodeChar(reader["Firstname"].ToString());
                x.Surname = DecodeChar(reader["Surname"].ToString());
                x.Email = DecodeChar(reader["Email"].ToString());
                x.xpassword = DecodeChar(reader["xpassword"].ToString());
                x.DateOfBrith = reader["DateOfBrith"].ToString();
                x.IncorporatedDate = reader["IncorporatedDate"].ToString();
                x.Nationality = reader["Nationality"].ToString();
                x.PhoneNumber = reader["PhoneNumber"].ToString();
                x.CompanyName = DecodeChar(reader["CompanyName"].ToString());
                x.CompanyAddress = DecodeChar(reader["CompanyAddress"].ToString());
                x.ContactPerson = DecodeChar(reader["ContactPerson"].ToString());
                x.ContactPersonPhone = reader["ContactPersonPhone"].ToString();
                x.CompanyWebsite = DecodeChar(reader["CompanyWebsite"].ToString());
                x.Certificate = reader["Certificate"].ToString();
                x.Introduction = reader["Introduction"].ToString();
                x.Principal = reader["Principal"].ToString();
                x.logo = reader["logo"].ToString();
                x.xreg_date = reader["xreg_date"].ToString();
                x.xstatus = reader["xstatus"].ToString();
                x.xvisible = reader["xvisible"].ToString();
                x.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return x;
        }
        public Classes.XObjs.Subagent getSubAgentByPhoneNumber(string PhoneNumber)
        {
            Classes.XObjs.Subagent x = new XObjs.Subagent();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM subagents WHERE Telephone='" + PhoneNumber + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                x.xid = reader["xid"].ToString();
                x.RegistrationID = reader["RegistrationID"].ToString();
                x.Surname = DecodeChar(reader["Surname"].ToString());
                x.Firstname = DecodeChar(reader["Firstname"].ToString());
                x.Email = DecodeChar(reader["Email"].ToString());
                x.xpassword = DecodeChar(reader["xpassword"].ToString());
                x.Telephone = reader["Telephone"].ToString();
                x.DateOfBrith = reader["DateOfBrith"].ToString();
                x.AssignID = reader["AssignID"].ToString();
                x.Sys_ID = reader["Sys_ID"].ToString();
                x.Address = DecodeChar(reader["Address"].ToString());
                x.AgentPassport = reader["AgentPassport"].ToString();
                x.xreg_date = reader["xreg_date"].ToString();
                x.xstatus = reader["xstatus"].ToString();
                x.xvisible = reader["xvisible"].ToString();
                x.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return x;
        }
        public XObjs.Registration getRegistrationByLogin(string email, string xpass)
        {
            XObjs.Registration x = new XObjs.Registration();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM registrations WHERE Email='" + email + "'  AND xpassword='" + xpass + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                x.xid = reader["xid"].ToString();
                x.AccrediationType = reader["AccrediationType"].ToString();
                x.Sys_ID = reader["Sys_ID"].ToString();
                x.Firstname = DecodeChar(reader["Firstname"].ToString());
                x.Surname = DecodeChar(reader["Surname"].ToString());
                x.Email = DecodeChar(reader["Email"].ToString());
                x.xpassword = DecodeChar(reader["xpassword"].ToString());
                x.DateOfBrith = reader["DateOfBrith"].ToString();
                x.IncorporatedDate = reader["IncorporatedDate"].ToString();
                x.Nationality = reader["Nationality"].ToString();
                x.PhoneNumber = reader["PhoneNumber"].ToString();
                x.CompanyName = DecodeChar(reader["CompanyName"].ToString());
                x.CompanyAddress = DecodeChar(reader["CompanyAddress"].ToString());
                x.ContactPerson = DecodeChar(reader["ContactPerson"].ToString());
                x.ContactPersonPhone = reader["ContactPersonPhone"].ToString();
                x.CompanyWebsite = DecodeChar(reader["CompanyWebsite"].ToString());
                x.Certificate = reader["Certificate"].ToString();
                x.Introduction = reader["Introduction"].ToString();
                x.Principal = reader["Principal"].ToString();
                x.logo = reader["logo"].ToString();
                x.xreg_date = reader["xreg_date"].ToString();
                x.xstatus = reader["xstatus"].ToString();
                x.xvisible = reader["xvisible"].ToString();
                x.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return x;
        }
        public XObjs.Registration getRegistrationBySysID(string email, string sys_id)
        {
            XObjs.Registration x = new XObjs.Registration();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM registrations WHERE Email='" + email + "'  AND Sys_ID='" + sys_id + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                x.xid = reader["xid"].ToString();
                x.AccrediationType = reader["AccrediationType"].ToString();
                x.Sys_ID = reader["Sys_ID"].ToString();
                x.Firstname = DecodeChar(reader["Firstname"].ToString());
                x.Surname = DecodeChar(reader["Surname"].ToString());
                x.Email = DecodeChar(reader["Email"].ToString());
                x.xpassword = DecodeChar(reader["xpassword"].ToString());
                x.DateOfBrith = reader["DateOfBrith"].ToString();
                x.IncorporatedDate = reader["IncorporatedDate"].ToString();
                x.Nationality = reader["Nationality"].ToString();
                x.PhoneNumber = reader["PhoneNumber"].ToString();
                x.CompanyName = DecodeChar(reader["CompanyName"].ToString());
                x.CompanyAddress = DecodeChar(reader["CompanyAddress"].ToString());
                x.ContactPerson = DecodeChar(reader["ContactPerson"].ToString());
                x.ContactPersonPhone = reader["ContactPersonPhone"].ToString();
                x.CompanyWebsite = DecodeChar(reader["CompanyWebsite"].ToString());
                x.Certificate = reader["Certificate"].ToString();
                x.Introduction = reader["Introduction"].ToString();
                x.Principal = reader["Principal"].ToString();
                x.logo = reader["logo"].ToString();
                x.xreg_date = reader["xreg_date"].ToString();
                x.xstatus = reader["xstatus"].ToString();
                x.xvisible = reader["xvisible"].ToString();
                x.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return x;
        }
        public XObjs.Registration getRegistrationByID(string xid)
        {
            XObjs.Registration x = new XObjs.Registration();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM registrations WHERE xid='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                x.xid = reader["xid"].ToString();
                x.AccrediationType = reader["AccrediationType"].ToString();
                x.Sys_ID = reader["Sys_ID"].ToString();
                x.Firstname = DecodeChar(reader["Firstname"].ToString());
                x.Surname = DecodeChar(reader["Surname"].ToString());
                x.Email = DecodeChar(reader["Email"].ToString());
                x.xpassword = DecodeChar(reader["xpassword"].ToString());
                x.DateOfBrith = reader["DateOfBrith"].ToString();
                x.IncorporatedDate = reader["IncorporatedDate"].ToString();
                x.Nationality = reader["Nationality"].ToString();
                x.PhoneNumber = reader["PhoneNumber"].ToString();
                x.CompanyName = DecodeChar(reader["CompanyName"].ToString());
                x.CompanyAddress = DecodeChar(reader["CompanyAddress"].ToString());
                x.ContactPerson = DecodeChar(reader["ContactPerson"].ToString());
                x.ContactPersonPhone = reader["ContactPersonPhone"].ToString();
                x.CompanyWebsite = DecodeChar(reader["CompanyWebsite"].ToString());
                x.Certificate = reader["Certificate"].ToString();
                x.Introduction = reader["Introduction"].ToString();
                x.Principal = reader["Principal"].ToString();
                x.logo = reader["logo"].ToString();
                x.xreg_date = reader["xreg_date"].ToString();
                x.xstatus = reader["xstatus"].ToString();
                x.xvisible = reader["xvisible"].ToString();
                x.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return x;
        }

        public XObjs.Registration getRegistrationByID2(string xid)
        {
            XObjs.Registration x = new XObjs.Registration();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM registrations WHERE Sys_ID='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                x.xid = reader["xid"].ToString();
                x.AccrediationType = reader["AccrediationType"].ToString();
                x.Sys_ID = reader["Sys_ID"].ToString();
                x.Firstname = DecodeChar(reader["Firstname"].ToString());
                x.Surname = DecodeChar(reader["Surname"].ToString());
                x.Email = DecodeChar(reader["Email"].ToString());
                x.xpassword = DecodeChar(reader["xpassword"].ToString());
                x.DateOfBrith = reader["DateOfBrith"].ToString();
                x.IncorporatedDate = reader["IncorporatedDate"].ToString();
                x.Nationality = reader["Nationality"].ToString();
                x.PhoneNumber = reader["PhoneNumber"].ToString();
                x.CompanyName = DecodeChar(reader["CompanyName"].ToString());
                x.CompanyAddress = DecodeChar(reader["CompanyAddress"].ToString());
                x.ContactPerson = DecodeChar(reader["ContactPerson"].ToString());
                x.ContactPersonPhone = reader["ContactPersonPhone"].ToString();
                x.CompanyWebsite = DecodeChar(reader["CompanyWebsite"].ToString());
                x.Certificate = reader["Certificate"].ToString();
                x.Introduction = reader["Introduction"].ToString();
                x.Principal = reader["Principal"].ToString();
                x.logo = reader["logo"].ToString();
                x.xreg_date = reader["xreg_date"].ToString();
                x.xstatus = reader["xstatus"].ToString();
                x.xvisible = reader["xvisible"].ToString();
                x.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return x;
        }
        public XObjs.Registration getRegistration()
        {
            XObjs.Registration x = new XObjs.Registration();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM registrations ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                x.xid = reader["xid"].ToString();
                x.AccrediationType = reader["AccrediationType"].ToString();
                x.Sys_ID = reader["Sys_ID"].ToString();
                x.Firstname = reader["Firstname"].ToString();
                x.Surname = reader["Surname"].ToString();
                x.Email = reader["Email"].ToString();
                x.xpassword = reader["xpassword"].ToString();
                x.DateOfBrith = reader["DateOfBrith"].ToString();
                x.IncorporatedDate = reader["IncorporatedDate"].ToString();
                x.Nationality = reader["Nationality"].ToString();
                x.PhoneNumber = reader["PhoneNumber"].ToString();
                x.CompanyName = reader["CompanyName"].ToString();
                x.CompanyAddress = reader["CompanyAddress"].ToString();
                x.ContactPerson = reader["ContactPerson"].ToString();
                x.ContactPersonPhone = reader["ContactPersonPhone"].ToString();
                x.CompanyWebsite = reader["CompanyWebsite"].ToString();
                x.Certificate = reader["Certificate"].ToString();
                x.Introduction = reader["Introduction"].ToString();
                x.Principal = reader["Principal"].ToString();
                x.logo = reader["logo"].ToString();
                x.xreg_date = reader["xreg_date"].ToString();
                x.xstatus = reader["xstatus"].ToString();
                x.xvisible = reader["xvisible"].ToString();
                x.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return x;
        }
        public XObjs.Subagent getSubAgentBySysID(string email, string sys_id)
        {
            XObjs.Subagent x = new XObjs.Subagent();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM subagents WHERE Email='" + email + "'   AND Sys_ID='" + sys_id + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                x.xid = reader["xid"].ToString();
                x.RegistrationID = reader["RegistrationID"].ToString();
                x.Surname = DecodeChar(reader["Surname"].ToString());
                x.Firstname = DecodeChar(reader["Firstname"].ToString());
                x.Email = DecodeChar(reader["Email"].ToString());
                x.xpassword = DecodeChar(reader["xpassword"].ToString());
                x.Telephone = reader["Telephone"].ToString();
                x.DateOfBrith = reader["DateOfBrith"].ToString();
                x.AssignID = reader["AssignID"].ToString();
                x.Sys_ID = reader["Sys_ID"].ToString();
                x.Address = DecodeChar(reader["Address"].ToString());
                x.AgentPassport = reader["AgentPassport"].ToString();
                x.xreg_date = reader["xreg_date"].ToString();
                x.xstatus = reader["xstatus"].ToString();
                x.xvisible = reader["xvisible"].ToString();
                x.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return x;
        }
        public XObjs.Subagent getSubAgentByLogin(string email, string xpass)
        {
            XObjs.Subagent x = new XObjs.Subagent();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM subagents WHERE Email='" + email + "'  AND xpassword='" + xpass + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                x.xid = reader["xid"].ToString();
                x.RegistrationID = reader["RegistrationID"].ToString();
                x.Surname = DecodeChar(reader["Surname"].ToString());
                x.Firstname = DecodeChar(reader["Firstname"].ToString());
                x.Email = DecodeChar(reader["Email"].ToString());
                x.xpassword = DecodeChar(reader["xpassword"].ToString());
                x.Telephone = reader["Telephone"].ToString();
                x.DateOfBrith = reader["DateOfBrith"].ToString();
                x.AssignID = reader["AssignID"].ToString();
                x.Sys_ID = reader["Sys_ID"].ToString();
                x.Address = DecodeChar(reader["Address"].ToString());
                x.AgentPassport = reader["AgentPassport"].ToString();
                x.xreg_date = reader["xreg_date"].ToString();
                x.xstatus = reader["xstatus"].ToString();
                x.xvisible = reader["xvisible"].ToString();
                x.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return x;
        }
        public XObjs.Subagent getSubAgentByID(string xid)
        {
            XObjs.Subagent x = new XObjs.Subagent();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM subagents WHERE xid='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                x.xid = reader["xid"].ToString();
                x.RegistrationID = reader["RegistrationID"].ToString();
                x.Surname = DecodeChar(reader["Surname"].ToString());
                x.Firstname = DecodeChar(reader["Firstname"].ToString());
                x.Email = DecodeChar(reader["Email"].ToString());
                x.xpassword = DecodeChar(reader["xpassword"].ToString());
                x.Telephone = reader["Telephone"].ToString();
                x.DateOfBrith = reader["DateOfBrith"].ToString();
                x.AssignID = reader["AssignID"].ToString();
                x.Sys_ID = reader["Sys_ID"].ToString();
                x.Address = DecodeChar(reader["Address"].ToString());
                x.AgentPassport = reader["AgentPassport"].ToString();
                x.xreg_date = reader["xreg_date"].ToString();
                x.xstatus = reader["xstatus"].ToString();
                x.xvisible = reader["xvisible"].ToString();
                x.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return x;
        }
        public XObjs.Subagent getSubAgent()
        {
            XObjs.Subagent x = new XObjs.Subagent();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM subagents", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                x.xid = reader["xid"].ToString();
                x.RegistrationID = reader["RegistrationID"].ToString();
                x.Surname = DecodeChar(reader["Surname"].ToString());
                x.Firstname = DecodeChar(reader["Firstname"].ToString());
                x.Email = DecodeChar(reader["Email"].ToString());
                x.xpassword = DecodeChar(reader["xpassword"].ToString());
                x.Telephone = reader["Telephone"].ToString();
                x.DateOfBrith = reader["DateOfBrith"].ToString();
                x.AssignID = reader["AssignID"].ToString();
                x.Sys_ID = reader["Sys_ID"].ToString();
                x.Address = DecodeChar(reader["Address"].ToString());
                x.AgentPassport = reader["AgentPassport"].ToString();
                x.xreg_date = reader["xreg_date"].ToString();
                x.xstatus = reader["xstatus"].ToString();
                x.xvisible = reader["xvisible"].ToString();
                x.xsync = reader["xsync"].ToString();
            }
            reader.Close();
            connection.Close();
            return x;
        }
    }
}