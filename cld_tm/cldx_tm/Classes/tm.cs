namespace cld.Classes
{
    using cld.Ipo;
    using model;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI.WebControls;

    public class tm
    {
        public GatewayService iposervice = new GatewayService();

        public string a_markInfo(string tm_type, string logo_description, string title_of_product, string nice_class, string nice_class_desc, string national_class, string sign_type, string vienna_class, string disclaimer, string logo_pic, string auth_doc, string sup_doc1, string sup_doc2, string validationID, string agentID, string amt, string stage)
        {
            string connectionString = Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str3 = "";
            string str4 = "";
            string str5 = getMarkPwalletID(validationID, agentID, amt, stage, "");
            if (tm_type == "1")
            {
                str4 = "NG/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/";
            }
            else
            {
                str4 = "F/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/";
            }
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_a_MarkInfo", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@reg_number", str4));
            command.Parameters.Add(new SqlParameter("@tm_typeID", tm_type));
            command.Parameters.Add(new SqlParameter("@logo_descriptionID", logo_description));
            command.Parameters.Add(new SqlParameter("@product_title", title_of_product));
            command.Parameters.Add(new SqlParameter("@nice_class", nice_class));
            command.Parameters.Add(new SqlParameter("@nice_class_desc", nice_class_desc));
            command.Parameters.Add(new SqlParameter("@national_classID", national_class));
            command.Parameters.Add(new SqlParameter("@sign_type", sign_type));
            command.Parameters.Add(new SqlParameter("@vienna_class", vienna_class));
            command.Parameters.Add(new SqlParameter("@disclaimer", disclaimer));
            command.Parameters.Add(new SqlParameter("@logo_pic", logo_pic));
            command.Parameters.Add(new SqlParameter("@auth_doc", auth_doc));
            command.Parameters.Add(new SqlParameter("@sup_doc1", sup_doc1));
            command.Parameters.Add(new SqlParameter("@sup_doc2", sup_doc2));
            command.Parameters.Add(new SqlParameter("@log_staff", str5));
            command.Parameters.Add(new SqlParameter("@reg_date", str2));
            command.Parameters.Add(new SqlParameter("@xvisible", "1"));
            SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            str3 = parameter.Value.ToString();
            connection.Close();
            if (!(str3 != "0"))
            {
                return str3;
            }
            str4 = str4 + str3;
            if (e_MarkInfoRegNumber(str4, str5) != 0)
            {
                if (e_pwallet(validationID, agentID, amt, stage, "").ToString() == "0")
                {
                    str3 = "0";
                }
                return str3;
            }
            SqlConnection connection2 = new SqlConnection(connectionString);
            SqlCommand command2 = new SqlCommand("DELETE FROM mark_info WHERE xID='" + str3 + "' ", connection2);
            connection2.Open();
            command2.ExecuteNonQuery();
            connection2.Close();
            return "0";
        }

        public string addAddress(Address c_app_addy, string log_officer)
        {
            string str = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str2 = log_officer + ": " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            string str3 = "1";
            if (c_app_addy.countryID == null)
            {
                c_app_addy.countryID = "";
            }
            if (c_app_addy.stateID == null)
            {
                c_app_addy.stateID = "";
            }
            if (c_app_addy.city == null)
            {
                c_app_addy.city = "";
            }
            if (c_app_addy.street == null)
            {
                c_app_addy.street = "";
            }
            if (c_app_addy.telephone1 == null)
            {
                c_app_addy.telephone1 = "";
            }
            if (c_app_addy.email1 == null)
            {
                c_app_addy.email1 = "";
            }
            string connectionString = Connect();
            string str5 = "0";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO address (countryID,stateID,city,street,telephone1,email1,log_staff,reg_date,visible,xtime) VALUES (@countryID,@stateID,@city,@street,@telephone1,@email1,@log_staff,@reg_date,@visible,@xtime) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@countryID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@stateID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@city", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@street", SqlDbType.Text);
            command.Parameters.Add("@telephone1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@email1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters.Add("@xtime", SqlDbType.NVarChar, 50);
            command.Parameters["@countryID"].Value = c_app_addy.countryID;
            command.Parameters["@stateID"].Value = c_app_addy.stateID;
            command.Parameters["@city"].Value = c_app_addy.city;
            command.Parameters["@street"].Value = c_app_addy.street;
            command.Parameters["@telephone1"].Value = c_app_addy.telephone1;
            command.Parameters["@email1"].Value = c_app_addy.email1;
            command.Parameters["@log_staff"].Value = c_app_addy.log_staff;
            command.Parameters["@reg_date"].Value = str;
            command.Parameters["@visible"].Value = str3;
            command.Parameters["@xtime"].Value = str2;
            str5 = command.ExecuteScalar().ToString();
            connection.Close();
            return str5;
        }

        public string addAos(AddressService c_aos, string log_officer)
        {
            if (c_aos.countryID == null)
            {
                c_aos.countryID = "";
            }
            if (c_aos.stateID == null)
            {
                c_aos.stateID = "";
            }
            if (c_aos.city == null)
            {
                c_aos.city = "";
            }
            if (c_aos.street == null)
            {
                c_aos.street = "";
            }
            if (c_aos.telephone1 == null)
            {
                c_aos.telephone1 = "";
            }
            if (c_aos.email1 == null)
            {
                c_aos.email1 = "";
            }
            string connectionString = Connect();
            string str2 = "0";
            string str3 = log_officer + ": " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO address_service (countryID,stateID,city,street,telephone1,email1,log_staff,reg_date,visible,xtime) VALUES (@countryID,@stateID,@city,@street,@telephone1,@email1,@log_staff,@reg_date,@visible,@xtime) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@countryID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@stateID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@city", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@street", SqlDbType.Text);
            command.Parameters.Add("@telephone1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@email1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters.Add("@xtime", SqlDbType.NVarChar, 50);
            command.Parameters["@countryID"].Value = c_aos.countryID;
            command.Parameters["@stateID"].Value = c_aos.stateID;
            command.Parameters["@city"].Value = c_aos.city;
            command.Parameters["@street"].Value = c_aos.street;
            command.Parameters["@telephone1"].Value = c_aos.telephone1;
            command.Parameters["@email1"].Value = c_aos.email1;
            command.Parameters["@log_staff"].Value = c_aos.log_staff;
            command.Parameters["@reg_date"].Value = c_aos.reg_date;
            command.Parameters["@visible"].Value = c_aos.visible;
            command.Parameters["@xtime"].Value = str3;
            str2 = command.ExecuteScalar().ToString();
            connection.Close();
            return str2;
        }

        public string addApplicant(Applicant c_app, Address c_app_addy, string log_officer)
        {
            string str = "0";
            string str2 = log_officer + ": " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            if (c_app.xname == null)
            {
                c_app.xname = "";
            }
            if (c_app.nationality == null)
            {
                c_app.nationality = "";
            }
            str = addAddress(c_app_addy, log_officer);
            string connectionString = Connect();
            string str4 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO applicant (xname,nationality,addressID,log_staff,reg_date,visible,xtime) VALUES (@xname,@nationality,@addressID,@log_staff,@reg_date,@visible,@xtime) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@addressID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters.Add("@xtime", SqlDbType.NVarChar, 50);
            command.Parameters["@xname"].Value = c_app.xname;
            command.Parameters["@nationality"].Value = c_app.nationality;
            command.Parameters["@addressID"].Value = str;
            command.Parameters["@log_staff"].Value = c_app.log_staff;
            command.Parameters["@reg_date"].Value = c_app.reg_date;
            command.Parameters["@visible"].Value = c_app.visible;
            command.Parameters["@xtime"].Value = str2;
            str4 = command.ExecuteScalar().ToString();
            connection.Close();
            return str4;
        }

        public string addCurrentAddress(Address c_app_addy, string pwalletID, string date)
        {
            string str = date;
            string str2 = "1";
            if (c_app_addy.countryID == null)
            {
                c_app_addy.countryID = "";
            }
            if (c_app_addy.stateID == null)
            {
                c_app_addy.stateID = "";
            }
            if (c_app_addy.city == null)
            {
                c_app_addy.city = "";
            }
            if (c_app_addy.street == null)
            {
                c_app_addy.street = "";
            }
            if (c_app_addy.telephone1 == null)
            {
                c_app_addy.telephone1 = "";
            }
            if (c_app_addy.email1 == null)
            {
                c_app_addy.email1 = "";
            }
            string connectionString = Connect();
            string str4 = "0";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO address (countryID,stateID,city,street,telephone1,email1,log_staff,reg_date,visible) VALUES (@countryID,@stateID,@city,@street,@telephone1,@email1,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@countryID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@stateID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@city", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@street", SqlDbType.Text);
            command.Parameters.Add("@telephone1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@email1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@countryID"].Value = c_app_addy.countryID;
            command.Parameters["@stateID"].Value = c_app_addy.stateID;
            command.Parameters["@city"].Value = c_app_addy.city;
            command.Parameters["@street"].Value = c_app_addy.street;
            command.Parameters["@telephone1"].Value = c_app_addy.telephone1;
            command.Parameters["@email1"].Value = c_app_addy.email1;
            command.Parameters["@log_staff"].Value = pwalletID;
            command.Parameters["@reg_date"].Value = str;
            command.Parameters["@visible"].Value = str2;
            str4 = command.ExecuteScalar().ToString();
            connection.Close();
            return str4;
        }

        public string addCurrentAos(AddressService c_aos, string pwalletID, string date)
        {
            string str = date;
            string str2 = "1";
            if (c_aos.countryID == null)
            {
                c_aos.countryID = "";
            }
            if (c_aos.stateID == null)
            {
                c_aos.stateID = "";
            }
            if (c_aos.city == null)
            {
                c_aos.city = "";
            }
            if (c_aos.street == null)
            {
                c_aos.street = "";
            }
            if (c_aos.telephone1 == null)
            {
                c_aos.telephone1 = "";
            }
            if (c_aos.email1 == null)
            {
                c_aos.email1 = "";
            }
            string connectionString = Connect();
            string str4 = "0";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO address_service (countryID,stateID,city,street,telephone1,email1,log_staff,reg_date,visible) VALUES (@countryID,@stateID,@city,@street,@telephone1,@email1,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@countryID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@stateID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@city", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@street", SqlDbType.Text);
            command.Parameters.Add("@telephone1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@email1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@countryID"].Value = c_aos.countryID;
            command.Parameters["@stateID"].Value = c_aos.stateID;
            command.Parameters["@city"].Value = c_aos.city;
            command.Parameters["@street"].Value = c_aos.street;
            command.Parameters["@telephone1"].Value = c_aos.telephone1;
            command.Parameters["@email1"].Value = c_aos.email1;
            command.Parameters["@log_staff"].Value = pwalletID;
            command.Parameters["@reg_date"].Value = str;
            command.Parameters["@visible"].Value = str2;
            str4 = command.ExecuteScalar().ToString();
            connection.Close();
            return str4;
        }

        public string addCurrentApplicant(Applicant c_app, Address c_app_addy, string pwalletID, string date)
        {
            string str = "0";
            string str2 = date;
            string str3 = "1";
            if (c_app.xname == null)
            {
                c_app.xname = "";
            }
            if (c_app.nationality == null)
            {
                c_app.nationality = "";
            }
            str = addCurrentAddress(c_app_addy, pwalletID, date);
            string connectionString = Connect();
            string str5 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO applicant (xname,nationality,addressID,log_staff,reg_date,visible) VALUES (@xname,@nationality,@addressID,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@addressID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@xname"].Value = c_app.xname;
            command.Parameters["@nationality"].Value = c_app.nationality;
            command.Parameters["@addressID"].Value = str;
            command.Parameters["@log_staff"].Value = pwalletID;
            command.Parameters["@reg_date"].Value = str2;
            command.Parameters["@visible"].Value = str3;
            str5 = command.ExecuteScalar().ToString();
            connection.Close();
            return str5;
        }

        public string addCurrentMark(MarkInfo c_mark, string pwalletID, string date)
        {
            string str = "";
            string str2 = date;
            string str3 = "1";
            if (c_mark.tm_typeID == null)
            {
                c_mark.tm_typeID = "";
            }
            if (c_mark.logo_descriptionID == null)
            {
                c_mark.logo_descriptionID = "";
            }
            if (c_mark.product_title == null)
            {
                c_mark.product_title = "";
            }
            if (c_mark.nice_class == null)
            {
                c_mark.nice_class = "";
            }
            if (c_mark.nice_class_desc == null)
            {
                c_mark.nice_class_desc = "";
            }
            if (c_mark.national_classID == null)
            {
                c_mark.national_classID = "";
            }
            if (c_mark.disclaimer == null)
            {
                c_mark.disclaimer = "";
            }
            string connectionString = Connect();
            string str5 = "0";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO mark_Info (reg_number,tm_typeID,logo_descriptionID,product_title,nice_class,nice_class_desc,national_classID,disclaimer,log_staff,reg_date,xvisible) VALUES (@reg_number,@tm_typeID,@logo_descriptionID,@product_title,@nice_class,@nice_class_desc,@national_classID,@disclaimer,@log_staff,@reg_date,@xvisible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@reg_number", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@tm_typeID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@logo_descriptionID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@product_title", SqlDbType.NVarChar);
            command.Parameters.Add("@nice_class", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@nice_class_desc", SqlDbType.NVarChar);
            command.Parameters.Add("@national_classID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@disclaimer", SqlDbType.NVarChar);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@xvisible", SqlDbType.NVarChar, 1);
            command.Parameters["@reg_number"].Value = str;
            command.Parameters["@tm_typeID"].Value = c_mark.tm_typeID;
            command.Parameters["@logo_descriptionID"].Value = c_mark.logo_descriptionID;
            command.Parameters["@product_title"].Value = c_mark.product_title;
            command.Parameters["@nice_class"].Value = c_mark.nice_class;
            command.Parameters["@nice_class_desc"].Value = c_mark.nice_class_desc;
            command.Parameters["@national_classID"].Value = c_mark.national_classID;
            command.Parameters["@disclaimer"].Value = c_mark.disclaimer;
            command.Parameters["@log_staff"].Value = pwalletID;
            command.Parameters["@reg_date"].Value = str2;
            command.Parameters["@xvisible"].Value = str3;
            str5 = command.ExecuteScalar().ToString();
            connection.Close();
            return str5;
        }

        public string addCurrentRepresentative(Representative c_rep, Address c_rep_addy, string pwalletID, string date)
        {
            string str = "0";
            string str2 = date;
            string str3 = "1";
            if (c_rep.agent_code == null)
            {
                c_rep.agent_code = "";
            }
            if (c_rep.xname == null)
            {
                c_rep.xname = "";
            }
            if (c_rep.nationality == null)
            {
                c_rep.nationality = "";
            }
            str = addCurrentAddress(c_rep_addy, pwalletID, date);
            string connectionString = Connect();
            string str5 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO representative (agent_code,xname,nationality,addressID,log_staff,reg_date,visible) VALUES (@agent_code,@xname,@nationality,@addressID,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@agent_code", SqlDbType.NVarChar);
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@addressID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@agent_code"].Value = c_rep.agent_code;
            command.Parameters["@xname"].Value = c_rep.xname;
            command.Parameters["@nationality"].Value = c_rep.nationality;
            command.Parameters["@addressID"].Value = str;
            command.Parameters["@log_staff"].Value = pwalletID;
            command.Parameters["@reg_date"].Value = str2;
            command.Parameters["@visible"].Value = str3;
            str5 = command.ExecuteScalar().ToString();
            connection.Close();
            return str5;
        }

        public string addCurrentTrademark(Applicant c_app, MarkInfo c_mark, AddressService c_aos, Representative c_rep, Address c_app_addy, Address c_rep_addy, string pwallet, string log_officer)
        {
            Stage stage = getStageClassByUserID(pwallet);
            string xID = "";
            string date = stage.reg_date;
            string year = stage.reg_date.Substring(0, 4);
            addCurrentApplicant(c_app, c_app_addy, pwallet, date);
            xID = addCurrentMark(c_mark, pwallet, date);
            updateCurrentMarkReg(xID, c_mark.tm_typeID, year);
            addCurrentAos(c_aos, pwallet, date);
            addCurrentRepresentative(c_rep, c_rep_addy, pwallet, date);
            updatePwalletStatus(pwallet, log_officer);
            return xID;
        }

        public string addExcelAddress(Address c_app_addy)
        {
            if (c_app_addy.countryID == null)
            {
                c_app_addy.countryID = "";
            }
            if (c_app_addy.stateID == null)
            {
                c_app_addy.stateID = "";
            }
            if (c_app_addy.city == null)
            {
                c_app_addy.city = "";
            }
            if (c_app_addy.street == null)
            {
                c_app_addy.street = "";
            }
            if (c_app_addy.telephone1 == null)
            {
                c_app_addy.telephone1 = "";
            }
            if (c_app_addy.email1 == null)
            {
                c_app_addy.email1 = "";
            }
            string connectionString = Connect();
            string str2 = "0";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO address (countryID,stateID,city,street,telephone1,email1,log_staff,reg_date,visible) VALUES (@countryID,@stateID,@city,@street,@telephone1,@email1,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@countryID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@stateID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@city", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@street", SqlDbType.Text);
            command.Parameters.Add("@telephone1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@email1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@countryID"].Value = c_app_addy.countryID;
            command.Parameters["@stateID"].Value = c_app_addy.stateID;
            command.Parameters["@city"].Value = c_app_addy.city;
            command.Parameters["@street"].Value = c_app_addy.street;
            command.Parameters["@telephone1"].Value = c_app_addy.telephone1;
            command.Parameters["@email1"].Value = c_app_addy.email1;
            command.Parameters["@log_staff"].Value = c_app_addy.log_staff;
            command.Parameters["@reg_date"].Value = c_app_addy.reg_date;
            command.Parameters["@visible"].Value = c_app_addy.visible;
            str2 = command.ExecuteScalar().ToString();
            connection.Close();
            return str2;
        }

        public string addExcelAos(AddressService c_aos)
        {
            if (c_aos.countryID == null)
            {
                c_aos.countryID = "";
            }
            if (c_aos.stateID == null)
            {
                c_aos.stateID = "";
            }
            if (c_aos.city == null)
            {
                c_aos.city = "";
            }
            if (c_aos.street == null)
            {
                c_aos.street = "";
            }
            if (c_aos.telephone1 == null)
            {
                c_aos.telephone1 = "";
            }
            if (c_aos.email1 == null)
            {
                c_aos.email1 = "";
            }
            string connectionString = Connect();
            string str2 = "0";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO address_service (countryID,stateID,city,street,telephone1,email1,log_staff,reg_date,visible) VALUES (@countryID,@stateID,@city,@street,@telephone1,@email1,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@countryID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@stateID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@city", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@street", SqlDbType.Text);
            command.Parameters.Add("@telephone1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@email1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@countryID"].Value = c_aos.countryID;
            command.Parameters["@stateID"].Value = c_aos.stateID;
            command.Parameters["@city"].Value = c_aos.city;
            command.Parameters["@street"].Value = c_aos.street;
            command.Parameters["@telephone1"].Value = c_aos.telephone1;
            command.Parameters["@email1"].Value = c_aos.email1;
            command.Parameters["@log_staff"].Value = c_aos.log_staff;
            command.Parameters["@reg_date"].Value = c_aos.reg_date;
            command.Parameters["@visible"].Value = c_aos.visible;
            str2 = command.ExecuteScalar().ToString();
            connection.Close();
            return str2;
        }

        public string addExcelApplicant(Applicant c_app, Address c_app_addy)
        {
            string str = "0";
            if (c_app.xname == null)
            {
                c_app.xname = "";
            }
            if (c_app.nationality == null)
            {
                c_app.nationality = "";
            }
            str = addExcelAddress(c_app_addy);
            string connectionString = Connect();
            string str3 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO applicant (xname,nationality,addressID,log_staff,reg_date,visible) VALUES (@xname,@nationality,@addressID,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@addressID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@xname"].Value = c_app.xname;
            command.Parameters["@nationality"].Value = c_app.nationality;
            command.Parameters["@addressID"].Value = str;
            command.Parameters["@log_staff"].Value = c_app.log_staff;
            command.Parameters["@reg_date"].Value = c_app.reg_date;
            command.Parameters["@visible"].Value = c_app.visible;
            str3 = command.ExecuteScalar().ToString();
            connection.Close();
            return str3;
        }

        public string addExcelMark(MarkInfo c_mark)
        {
            string str = "";
            if (c_mark.tm_typeID == null)
            {
                c_mark.tm_typeID = "";
            }
            if (c_mark.logo_descriptionID == null)
            {
                c_mark.logo_descriptionID = "";
            }
            if (c_mark.product_title == null)
            {
                c_mark.product_title = "";
            }
            if (c_mark.nice_class == null)
            {
                c_mark.nice_class = "";
            }
            if (c_mark.nice_class_desc == null)
            {
                c_mark.nice_class_desc = "";
            }
            if (c_mark.national_classID == null)
            {
                c_mark.national_classID = "";
            }
            if (c_mark.disclaimer == null)
            {
                c_mark.disclaimer = "";
            }
            string connectionString = Connect();
            string str3 = "0";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO mark_Info (reg_number,tm_typeID,logo_descriptionID,product_title,nice_class,nice_class_desc,national_classID,disclaimer,log_staff,reg_date,xvisible) VALUES (@reg_number,@tm_typeID,@logo_descriptionID,@product_title,@nice_class,@nice_class_desc,@national_classID,@disclaimer,@log_staff,@reg_date,@xvisible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@reg_number", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@tm_typeID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@logo_descriptionID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@product_title", SqlDbType.NVarChar);
            command.Parameters.Add("@nice_class", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@nice_class_desc", SqlDbType.NVarChar);
            command.Parameters.Add("@national_classID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@disclaimer", SqlDbType.NVarChar);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@xvisible", SqlDbType.NVarChar, 1);
            command.Parameters["@reg_number"].Value = str;
            command.Parameters["@tm_typeID"].Value = c_mark.tm_typeID;
            command.Parameters["@logo_descriptionID"].Value = c_mark.logo_descriptionID;
            command.Parameters["@product_title"].Value = c_mark.product_title;
            command.Parameters["@nice_class"].Value = c_mark.nice_class;
            command.Parameters["@nice_class_desc"].Value = c_mark.nice_class_desc;
            command.Parameters["@national_classID"].Value = c_mark.national_classID;
            command.Parameters["@disclaimer"].Value = c_mark.disclaimer;
            command.Parameters["@log_staff"].Value = c_mark.log_staff;
            command.Parameters["@reg_date"].Value = c_mark.reg_date;
            command.Parameters["@xvisible"].Value = c_mark.xvisible;
            str3 = command.ExecuteScalar().ToString();
            connection.Close();
            return str3;
        }

        public string addExcelPwallet(string serverpath, Stage c_pwallet)
        {
            string connectionString = Connect();
            string str2 = "0";
            string str3 = "0";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO pwallet (validationID,applicantID,log_officer,amt,stage,status,data_status,reg_date,visible,rtm,acc_p )  VALUES ( @validationID,@applicantID,@log_officer,@amt,@stage,@status,@data_status,@regdate,@visible,@rtm,@acc_p ) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@validationID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@applicantID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_officer", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@amt", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@stage", SqlDbType.NChar, 10);
            command.Parameters.Add("@status", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@data_status", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@regdate", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters.Add("@rtm", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@acc_p", SqlDbType.NVarChar, 50);
            command.Parameters["@validationID"].Value = c_pwallet.validationID;
            command.Parameters["@applicantID"].Value = c_pwallet.applicantID;
            command.Parameters["@log_officer"].Value = c_pwallet.log_officer;
            command.Parameters["@amt"].Value = c_pwallet.amt;
            command.Parameters["@stage"].Value = c_pwallet.stage;
            command.Parameters["@status"].Value = c_pwallet.status;
            command.Parameters["@data_status"].Value = c_pwallet.data_status;
            command.Parameters["@regdate"].Value = c_pwallet.reg_date;
            command.Parameters["@visible"].Value = c_pwallet.visible;
            command.Parameters["@rtm"].Value = str2;
            command.Parameters["@acc_p"].Value = str3;
            return command.ExecuteScalar().ToString();
        }

        public string addExcelRepresentative(Representative c_rep, Address c_rep_addy, string log_officer)
        {
            string str = "0";
            if (c_rep.agent_code == null)
            {
                c_rep.agent_code = "";
            }
            if (c_rep.xname == null)
            {
                c_rep.xname = "";
            }
            if (c_rep.nationality == null)
            {
                c_rep.nationality = "";
            }
            str = addAddress(c_rep_addy, log_officer);
            string connectionString = Connect();
            string str3 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO representative (agent_code,xname,nationality,addressID,log_staff,reg_date,visible) VALUES (@agent_code,@xname,@nationality,@addressID,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@agent_code", SqlDbType.NVarChar);
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@addressID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@agent_code"].Value = c_rep.agent_code;
            command.Parameters["@xname"].Value = c_rep.xname;
            command.Parameters["@nationality"].Value = c_rep.nationality;
            command.Parameters["@addressID"].Value = str;
            command.Parameters["@log_staff"].Value = c_rep.log_staff;
            command.Parameters["@reg_date"].Value = c_rep.reg_date;
            command.Parameters["@visible"].Value = c_rep.visible;
            str3 = command.ExecuteScalar().ToString();
            connection.Close();
            return str3;
        }

        public string addMark(MarkInfo c_mark, string log_officer)
        {
            string str = "";
            string str2 = log_officer + ": " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            if (c_mark.tm_typeID == null)
            {
                c_mark.tm_typeID = "";
            }
            if (c_mark.logo_descriptionID == null)
            {
                c_mark.logo_descriptionID = "";
            }
            if (c_mark.product_title == null)
            {
                c_mark.product_title = "";
            }
            if (c_mark.nice_class == null)
            {
                c_mark.nice_class = "";
            }
            if (c_mark.nice_class_desc == null)
            {
                c_mark.nice_class_desc = "";
            }
            if (c_mark.national_classID == null)
            {
                c_mark.national_classID = "";
            }
            if (c_mark.disclaimer == null)
            {
                c_mark.disclaimer = "";
            }
            string connectionString = Connect();
            string str4 = "0";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO mark_Info (reg_number,tm_typeID,logo_descriptionID,product_title,nice_class,nice_class_desc,national_classID,disclaimer,log_staff,reg_date,xvisible,xtime) VALUES (@reg_number,@tm_typeID,@logo_descriptionID,@product_title,@nice_class,@nice_class_desc,@national_classID,@disclaimer,@log_staff,@reg_date,@xvisible,@xtime) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@reg_number", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@tm_typeID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@logo_descriptionID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@product_title", SqlDbType.NVarChar);
            command.Parameters.Add("@nice_class", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@nice_class_desc", SqlDbType.NVarChar);
            command.Parameters.Add("@national_classID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@disclaimer", SqlDbType.NVarChar);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@xvisible", SqlDbType.NVarChar, 1);
            command.Parameters.Add("@xtime", SqlDbType.NVarChar, 50);
            command.Parameters["@reg_number"].Value = str;
            command.Parameters["@tm_typeID"].Value = c_mark.tm_typeID;
            command.Parameters["@logo_descriptionID"].Value = c_mark.logo_descriptionID;
            command.Parameters["@product_title"].Value = c_mark.product_title;
            command.Parameters["@nice_class"].Value = c_mark.nice_class;
            command.Parameters["@nice_class_desc"].Value = c_mark.nice_class_desc;
            command.Parameters["@national_classID"].Value = c_mark.national_classID;
            command.Parameters["@disclaimer"].Value = c_mark.disclaimer;
            command.Parameters["@log_staff"].Value = c_mark.log_staff;
            command.Parameters["@reg_date"].Value = c_mark.reg_date;
            command.Parameters["@xvisible"].Value = c_mark.xvisible;
            command.Parameters["@xtime"].Value = str2;
            str4 = command.ExecuteScalar().ToString();
            connection.Close();
            return str4;
        }

        public string addPwallet(string validationID, string agent_code, string amt, string log_officer)
        {
            string connectionString = Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str3 = log_officer + ": " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            string str4 = "1";
            string str5 = "1";
            string str6 = "5";
            string str7 = "Fresh";
            string str8 = "0";
            string str9 = "0";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO pwallet (validationID,applicantID,log_officer,amt,stage,status,data_status,reg_date,visible,xtime,rtm,acc_p )  VALUES ( @validationID,@applicantID,@log_officer,@amt,@stage,@status,@data_status,@regdate,@visible,@xtime,@rtm,@acc_p ) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@validationID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@applicantID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_officer", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@amt", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@stage", SqlDbType.NChar, 10);
            command.Parameters.Add("@status", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@data_status", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@regdate", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters.Add("@xtime", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@rtm", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@acc_p", SqlDbType.NVarChar, 50);
            command.Parameters["@validationID"].Value = validationID;
            command.Parameters["@applicantID"].Value = agent_code;
            command.Parameters["@log_officer"].Value = log_officer;
            command.Parameters["@amt"].Value = amt;
            command.Parameters["@stage"].Value = str6;
            command.Parameters["@status"].Value = str5;
            command.Parameters["@data_status"].Value = str7;
            command.Parameters["@regdate"].Value = str2;
            command.Parameters["@visible"].Value = str4;
            command.Parameters["@xtime"].Value = str3;
            command.Parameters["@rtm"].Value = str8;
            command.Parameters["@acc_p"].Value = str9;
            return command.ExecuteScalar().ToString();
        }

        public string addPwalletG(string serverpath, string twalletID, string validationID, string agent_code, string amt, string item_code)
        {
            string connectionString = Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str3 = "1";
            string str4 = "1";
            string str5 = "5";
            string str6 = "Fresh";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO g_pwallet (twalletID,validationID,applicantID,log_officer,amt,stage,status,data_status,reg_date,visible )  VALUES ( @twalletID,@validationID,@applicantID,@log_officer,@amt,@stage,@status,@data_status,@regdate,@visible ) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@twalletID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@validationID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@applicantID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_officer", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@amt", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@stage", SqlDbType.NChar, 10);
            command.Parameters.Add("@status", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@data_status", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@regdate", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@twalletID"].Value = twalletID;
            command.Parameters["@validationID"].Value = validationID;
            command.Parameters["@applicantID"].Value = agent_code;
            command.Parameters["@log_officer"].Value = item_code;
            command.Parameters["@amt"].Value = amt;
            command.Parameters["@stage"].Value = str5;
            command.Parameters["@status"].Value = str4;
            command.Parameters["@data_status"].Value = str6;
            command.Parameters["@regdate"].Value = str2;
            command.Parameters["@visible"].Value = str3;
            return command.ExecuteScalar().ToString();
        }

        public string addRepresentative(Representative c_rep, Address c_rep_addy, string log_officer)
        {
            string str = "0";
            string str2 = log_officer + ": " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            if (c_rep.agent_code == null)
            {
                c_rep.agent_code = "";
            }
            if (c_rep.xname == null)
            {
                c_rep.xname = "";
            }
            if (c_rep.nationality == null)
            {
                c_rep.nationality = "";
            }
            str = addAddress(c_rep_addy, log_officer);
            string connectionString = Connect();
            string str4 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO representative (agent_code,xname,nationality,addressID,log_staff,reg_date,visible,xtime) VALUES (@agent_code,@xname,@nationality,@addressID,@log_staff,@reg_date,@visible,@xtime) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@agent_code", SqlDbType.NVarChar);
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@addressID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters.Add("@xtime", SqlDbType.NVarChar, 50);
            command.Parameters["@agent_code"].Value = c_rep.agent_code;
            command.Parameters["@xname"].Value = c_rep.xname;
            command.Parameters["@nationality"].Value = c_rep.nationality;
            command.Parameters["@addressID"].Value = str;
            command.Parameters["@log_staff"].Value = c_rep.log_staff;
            command.Parameters["@reg_date"].Value = c_rep.reg_date;
            command.Parameters["@visible"].Value = c_rep.visible;
            command.Parameters["@xtime"].Value = str2;
            str4 = command.ExecuteScalar().ToString();
            connection.Close();
            return str4;
        }

        public int addReversal(TmOffice c_tm_office)
        {
            string connectionString = Connect();
            int num = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO tm_office (pwalletID,admin_status,data_status,xcomment,xdoc1,xdoc2,xdoc3,xofficer,reg_date,xvisible) VALUES ('" + c_tm_office.pwalletID + "','" + c_tm_office.admin_status + "','" + c_tm_office.data_status + "',@xcomment ,'" + c_tm_office.xdoc1 + "','" + c_tm_office.xdoc2 + "','" + c_tm_office.xdoc3 + "','" + c_tm_office.xofficer + "','" + c_tm_office.reg_date + "','" + c_tm_office.xvisible + "') SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@xcomment", SqlDbType.NVarChar, 500);
            command.Parameters["@xcomment"].Value = c_tm_office.xcomment;
            num = Convert.ToInt32(command.ExecuteScalar());
            if (num > 0)
            {
                SqlCommand command2 = connection.CreateCommand();
                command2.CommandText = "update pwallet set  status='" + c_tm_office.admin_status + "' ,data_status='" + c_tm_office.data_status + "' where ID='" + c_tm_office.pwalletID + "' ";
                num += command2.ExecuteNonQuery();
            }
            connection.Close();
            return num;
        }

        public string addSoloApplicant(Applicant c_app)
        {
            if (c_app.xname == null)
            {
                c_app.xname = "";
            }
            if (c_app.nationality == null)
            {
                c_app.nationality = "";
            }
            string connectionString = Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO applicant (xname,nationality,addressID,log_staff,reg_date,visible) VALUES (@xname,@nationality,@addressID,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@addressID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@xname"].Value = c_app.xname;
            command.Parameters["@nationality"].Value = c_app.nationality;
            command.Parameters["@addressID"].Value = c_app.addressID;
            command.Parameters["@log_staff"].Value = c_app.log_staff;
            command.Parameters["@reg_date"].Value = c_app.reg_date;
            command.Parameters["@visible"].Value = c_app.visible;
            str2 = command.ExecuteScalar().ToString();
            connection.Close();
            return str2;
        }

        public string addSoloRepresentative(Representative c_rep)
        {
            if (c_rep.agent_code == null)
            {
                c_rep.agent_code = "";
            }
            if (c_rep.xname == null)
            {
                c_rep.xname = "";
            }
            if (c_rep.nationality == null)
            {
                c_rep.nationality = "";
            }
            string connectionString = Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO representative (agent_code,xname,nationality,addressID,log_staff,reg_date,visible) VALUES (@agent_code,@xname,@nationality,@addressID,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@agent_code", SqlDbType.NVarChar);
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@addressID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@agent_code"].Value = c_rep.agent_code;
            command.Parameters["@xname"].Value = c_rep.xname;
            command.Parameters["@nationality"].Value = c_rep.nationality;
            command.Parameters["@addressID"].Value = c_rep.addressID;
            command.Parameters["@log_staff"].Value = c_rep.log_staff;
            command.Parameters["@reg_date"].Value = c_rep.reg_date;
            command.Parameters["@visible"].Value = c_rep.visible;
            str2 = command.ExecuteScalar().ToString();
            connection.Close();
            return str2;
        }

        public string addSwallet(SWallet s)
        {
            string connectionString = Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO search_wallet (mark_infoID,search_str,search_cri,xclass,log_officer,reg_date,visible) VALUES (@mark_infoID,@search_str,@search_cri,@xclass,@log_officer,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@mark_infoID", SqlDbType.NVarChar);
            command.Parameters.Add("@search_str", SqlDbType.Text);
            command.Parameters.Add("@search_cri", SqlDbType.Text);
            command.Parameters.Add("@xclass", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_officer", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@mark_infoID"].Value = s.mark_infoID;
            command.Parameters["@search_str"].Value = s.search_str;
            command.Parameters["@search_cri"].Value = s.search_cri;
            command.Parameters["@xclass"].Value = s.xclass;
            command.Parameters["@log_officer"].Value = s.log_officer;
            command.Parameters["@reg_date"].Value = s.reg_date;
            command.Parameters["@visible"].Value = s.visible;
            str2 = command.ExecuteScalar().ToString();
            connection.Close();
            return str2;
        }

        public string addSwallet2(SWallet s)
        {
            string connectionString = Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO search_wallet2 (mark_infoID,search_str,search_cri,xclass,log_officer,reg_date,visible) VALUES (@mark_infoID,@search_str,@search_cri,@xclass,@log_officer,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@mark_infoID", SqlDbType.NVarChar);
            command.Parameters.Add("@search_str", SqlDbType.Text);
            command.Parameters.Add("@search_cri", SqlDbType.Text);
            command.Parameters.Add("@xclass", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_officer", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@mark_infoID"].Value = s.mark_infoID;
            command.Parameters["@search_str"].Value = s.search_str;
            command.Parameters["@search_cri"].Value = s.search_cri;
            command.Parameters["@xclass"].Value = s.xclass;
            command.Parameters["@log_officer"].Value = s.log_officer;
            command.Parameters["@reg_date"].Value = s.reg_date;
            command.Parameters["@visible"].Value = s.visible;
            str2 = command.ExecuteScalar().ToString();
            connection.Close();
            return str2;
        }

        public string addTrademark(Applicant c_app, MarkInfo c_mark, AddressService c_aos, Representative c_rep, Address c_app_addy, Address c_rep_addy, string log_officer)
        {
            string xID = ""; 
            addApplicant(c_app, c_app_addy, log_officer);
            xID = addMark(c_mark, log_officer);
            updateMarkReg(xID, c_mark.tm_typeID);
            addAos(c_aos, log_officer);
            addRepresentative(c_rep, c_rep_addy, log_officer);
            updatePwalletStatus(c_app.log_staff, log_officer);
            return xID;
        }
      
        public string addTrademarkTx(Applicant c_app, MarkInfo c_mark, AddressService c_aos, Representative c_rep, Address c_app_addy, Address c_rep_addy, Stage c_pwall, SortedList<string, string> sl_docz,
        FileUpload logo_pic, FileUpload auth_doc, FileUpload sup_doc1, FileUpload sup_doc2, string serverpath)
        {

            if (c_pwall.validationID == "" || c_pwall.validationID==null)
            {
                throw new Exception("Test Exception");
            }
            Retriever ret = new Retriever();
            string xID = "0"; int pID = 0;
            string xauth_doc = ""; string xsup_doc1 = ""; string xsup_doc2 = ""; string xpath = "";
            string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string xtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            string xvisible = "1"; string xsync = "0";

            SqlConnection connection; SqlCommand command;
            string connectionString = Connect();
            c_pwall.reg_date =reg_date;
            c_pwall.xtime = c_pwall.log_officer + ": " + xtime;
            c_pwall.visible = xvisible; c_pwall.status = "1"; c_pwall.stage = "5"; c_pwall.data_status = "Fresh";
            c_pwall.acc_p = "0"; c_pwall.rtm = "0"; int app_addyID = 0; int rep_addyID = 0;


           
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                      //  command.CommandTimeout = 300;
                        command.CommandText = "INSERT INTO pwallet (validationID,applicantID,log_officer,amt,stage,status,data_status,reg_date,visible,xtime,rtm,acc_p  ) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += "@validationID,@applicantID,@log_officer,@amt,@stage,@status,@data_status,@reg_date,@visible,@xtime,@rtm,@acc_p   ";                        
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();                     

                        command.Parameters.Add("@validationID", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@applicantID", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@log_officer", SqlDbType.VarChar, 50);
                        command.Parameters.Add("@amt", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@stage", SqlDbType.NChar, 50);
                        command.Parameters.Add("@status", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@data_status", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
                        command.Parameters.Add("@xtime", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@rtm", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@acc_p", SqlDbType.NVarChar, 50);

                        command.Parameters["@validationID"].Value = c_pwall.validationID;
                        command.Parameters["@applicantID"].Value = c_pwall.applicantID;
                        command.Parameters["@log_officer"].Value = c_pwall.log_officer;
                        command.Parameters["@amt"].Value = c_pwall.amt;
                        command.Parameters["@stage"].Value = c_pwall.stage;
                        command.Parameters["@status"].Value = c_pwall.status;
                        command.Parameters["@data_status"].Value = c_pwall.data_status;
                        command.Parameters["@reg_date"].Value = reg_date;
                        command.Parameters["@visible"].Value = xvisible;
                        command.Parameters["@xtime"].Value = xtime;
                        command.Parameters["@rtm"].Value = c_pwall.rtm;
                        command.Parameters["@acc_p"].Value = c_pwall.acc_p;

                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }

                        pID = Convert.ToInt32(command.ExecuteScalar());
                        command.Connection.Close();
                    }
                }
                if (Convert.ToInt32(pID) > 0)
                {
                    c_app.log_staff = pID.ToString(); c_mark.log_staff = pID.ToString(); c_aos.log_staff = pID.ToString(); c_rep.log_staff = pID.ToString(); c_rep_addy.log_staff = pID.ToString(); c_app_addy.log_staff = pID.ToString();
                }

                using (connection = new SqlConnection(connectionString))
                {
                  
                    using (command = connection.CreateCommand())
                    {
                       // command.CommandTimeout = 300;
                        command.CommandText = "INSERT INTO address (countryID,stateID,city,street,telephone1,email1,log_staff,reg_date,visible,xtime) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " @countryID,@stateID,@city,@street,@telephone1,@email1,@log_staff,@reg_date,@visible,@xtime ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();

                        command.Parameters.Add("@countryID", SqlDbType.NVarChar, 10);
                        command.Parameters.Add("@stateID", SqlDbType.NVarChar, 10);
                        command.Parameters.Add("@city", SqlDbType.VarChar, 40);
                        command.Parameters.Add("@street", SqlDbType.Text);
                        command.Parameters.Add("@telephone1", SqlDbType.NChar, 40);
                        command.Parameters.Add("@email1", SqlDbType.NVarChar, 40);
                        command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 40);
                        command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 40);
                        command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
                        command.Parameters.Add("@xtime", SqlDbType.NVarChar, 50);

                        if (c_app_addy.city == "" || c_app_addy.city == null || c_app_addy.city == "0")
                        {
                            c_app_addy.city = "";
                        }
                        command.Parameters["@countryID"].Value = c_app_addy.countryID;
                        command.Parameters["@stateID"].Value = c_app_addy.stateID;
                        command.Parameters["@city"].Value = c_app_addy.city;
                        command.Parameters["@street"].Value = c_app_addy.street;
                        command.Parameters["@telephone1"].Value = c_app_addy.telephone1;
                        command.Parameters["@email1"].Value = c_app_addy.email1;
                        command.Parameters["@log_staff"].Value = c_app_addy.log_staff;
                        command.Parameters["@reg_date"].Value = reg_date;
                        command.Parameters["@visible"].Value = xvisible;
                        command.Parameters["@xtime"].Value = xtime;


                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }

                        app_addyID = Convert.ToInt32(command.ExecuteScalar());
                        command.Connection.Close();
                    }
                }
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                      //  command.CommandTimeout = 300;
                        command.CommandText = "INSERT INTO address (countryID,stateID,city,street,telephone1,email1,log_staff,reg_date,visible,xtime) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " @countryID,@stateID,@city,@street,@telephone1,@email1,@log_staff,@reg_date,@visible,@xtime ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();

                        command.Parameters.Add("@countryID", SqlDbType.NVarChar, 10);
                        command.Parameters.Add("@stateID", SqlDbType.NVarChar, 10);
                        command.Parameters.Add("@city", SqlDbType.VarChar, 40);
                        command.Parameters.Add("@street", SqlDbType.Text);
                        command.Parameters.Add("@telephone1", SqlDbType.NChar, 40);
                        command.Parameters.Add("@email1", SqlDbType.NVarChar, 40);
                        command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 40);
                        command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 40);
                        command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
                        command.Parameters.Add("@xtime", SqlDbType.NVarChar, 50);

                        if (c_rep_addy.city == "" || c_rep_addy.city == null)
                        {
                            c_rep_addy.city = "0";
                        }
                        command.Parameters["@countryID"].Value = c_rep_addy.countryID;
                        command.Parameters["@stateID"].Value = c_rep_addy.stateID;
                        command.Parameters["@city"].Value = c_rep_addy.city;
                        command.Parameters["@street"].Value = c_rep_addy.street;
                        command.Parameters["@telephone1"].Value = c_rep_addy.telephone1;
                        command.Parameters["@email1"].Value = c_rep_addy.email1;
                        command.Parameters["@log_staff"].Value = c_rep_addy.log_staff;
                        command.Parameters["@reg_date"].Value = reg_date;
                        command.Parameters["@visible"].Value = xvisible;
                        command.Parameters["@xtime"].Value = xtime;

                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }

                        rep_addyID = Convert.ToInt32(command.ExecuteScalar());
                        command.Connection.Close();
                    }
                }
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                      //  command.CommandTimeout = 300;
                        command.CommandText = "INSERT INTO applicant (xname,nationality,addressID,log_staff,reg_date,visible,xtime) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " @xname,@nationality,@addressID,@log_staff,@reg_date,@visible,@xtime ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();
                        command.Parameters.Add("@xname", SqlDbType.NVarChar);
                        command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@addressID", SqlDbType.VarChar, 50);
                        command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 20);
                        command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
                        command.Parameters.Add("@xtime", SqlDbType.NVarChar, 50);

                        command.Parameters["@xname"].Value = c_app.xname;
                        command.Parameters["@nationality"].Value = c_app.nationality;
                        command.Parameters["@addressID"].Value = app_addyID;
                        command.Parameters["@log_staff"].Value = c_app.log_staff;
                        command.Parameters["@reg_date"].Value = reg_date;
                        command.Parameters["@visible"].Value = xvisible;
                        command.Parameters["@xtime"].Value = xtime;
                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }
                        Convert.ToInt32(command.ExecuteScalar());
                        command.Connection.Close();
                    }
                }
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                     //   command.CommandTimeout = 300;                      
                        command.CommandText = "INSERT INTO representative (agent_code,xname,nationality,addressID,log_staff,reg_date,visible) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " @agent_code,@xname,@nationality,@addressID,@log_staff,@reg_date,@visible ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();
                        command.Parameters.Add("@agent_code", SqlDbType.NVarChar);
                        command.Parameters.Add("@xname", SqlDbType.NVarChar);
                        command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@addressID", SqlDbType.VarChar, 50);
                        command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);

                        command.Parameters["@agent_code"].Value = c_rep.agent_code;
                        command.Parameters["@xname"].Value = c_rep.xname;
                        command.Parameters["@nationality"].Value = c_rep.nationality;
                        command.Parameters["@addressID"].Value = rep_addyID;
                        command.Parameters["@log_staff"].Value = c_rep.log_staff;
                        command.Parameters["@reg_date"].Value = reg_date;
                        command.Parameters["@visible"].Value = xvisible;
                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }
                        Convert.ToInt32(command.ExecuteScalar());
                        command.Connection.Close();
                    }
                }
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO address_service (countryID,stateID,city,street,telephone1,email1,log_staff,reg_date,visible,xtime) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " @countryID,@stateID,@city,@street,@telephone1,@email1,@log_staff,@reg_date,@visible,@xtime ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();

                        command.Parameters.Add("@countryID", SqlDbType.NVarChar, 10);
                        command.Parameters.Add("@stateID", SqlDbType.NVarChar, 10);
                        command.Parameters.Add("@city", SqlDbType.NVarChar, 40);
                        command.Parameters.Add("@street", SqlDbType.Text);
                        command.Parameters.Add("@telephone1", SqlDbType.NChar, 40);
                        command.Parameters.Add("@email1", SqlDbType.NVarChar, 40);
                        command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 40);
                        command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 40);
                        command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
                        command.Parameters.Add("@xtime", SqlDbType.NVarChar, 50);


                        if (c_aos.city == "" || c_aos.city == null)
                        {
                            c_aos.city = "0";
                        }

                        command.Parameters["@countryID"].Value = c_aos.countryID;
                        command.Parameters["@stateID"].Value = c_aos.stateID;
                        command.Parameters["@city"].Value = c_aos.city;
                        command.Parameters["@street"].Value = c_aos.street;
                        command.Parameters["@telephone1"].Value = c_aos.telephone1;
                        command.Parameters["@email1"].Value = c_aos.email1;
                        command.Parameters["@log_staff"].Value = c_aos.log_staff;
                        command.Parameters["@reg_date"].Value = reg_date;
                        command.Parameters["@visible"].Value = xvisible;
                        command.Parameters["@xtime"].Value = xtime;
                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }

                        Convert.ToInt32(command.ExecuteScalar());
                        command.Connection.Close();
                    }
                }
                if (c_mark.disclaimer == null) { c_mark.disclaimer=""; }
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                      //  command.CommandTimeout = 300;
                        command.CommandText = "INSERT INTO mark_Info (reg_number,tm_typeID,logo_descriptionID,product_title,nice_class,nice_class_desc,national_classID,disclaimer,log_staff,reg_date,xvisible,xtime) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " @reg_number,@tm_typeID,@logo_descriptionID,@product_title,@nice_class,@nice_class_desc,@national_classID,@disclaimer,@log_staff,@reg_date,@xvisible,@xtime ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();

                        command.Parameters.Add("@reg_number", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@tm_typeID", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@logo_descriptionID", SqlDbType.VarChar, 50);
                        command.Parameters.Add("@product_title", SqlDbType.NVarChar);
                        command.Parameters.Add("@nice_class", SqlDbType.NChar, 50);
                        command.Parameters.Add("@nice_class_desc", SqlDbType.Text);
                        command.Parameters.Add("@national_classID", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@disclaimer", SqlDbType.Text);
                        command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@xvisible", SqlDbType.NVarChar, 1);
                        command.Parameters.Add("@xtime", SqlDbType.NVarChar, 50);

                        command.Parameters["@reg_number"].Value = "";
                        command.Parameters["@tm_typeID"].Value = c_mark.tm_typeID;
                        command.Parameters["@logo_descriptionID"].Value = c_mark.logo_descriptionID;
                        command.Parameters["@product_title"].Value = c_mark.product_title;
                        command.Parameters["@nice_class"].Value = c_mark.nice_class;
                        command.Parameters["@nice_class_desc"].Value = c_mark.nice_class_desc;
                        command.Parameters["@national_classID"].Value = c_mark.national_classID;
                        command.Parameters["@disclaimer"].Value = c_mark.disclaimer;
                        command.Parameters["@log_staff"].Value = c_mark.log_staff;
                        command.Parameters["@reg_date"].Value = reg_date;
                        command.Parameters["@xvisible"].Value = xvisible;
                        command.Parameters["@xtime"].Value = xtime;

                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }

                        xID = command.ExecuteScalar().ToString();
                        command.Connection.Close();
                    }
                }
                string reg_number = "";
                if (c_mark.tm_typeID == "1")
                {
                    reg_number = "NG/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID;
                }
                else
                {
                    reg_number = "F/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID;
                }
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                       // command.CommandTimeout = 300;
                        command.CommandText = "UPDATE mark_info SET reg_number='" + reg_number + "'  WHERE xID='" + xID + "' ";
                        command.Connection.Open();
                        int rm = Convert.ToInt32(command.ExecuteNonQuery());
                        command.Connection.Close();
                    }
                }
                if (logo_pic.HasFile) { xpath = doUploadPic(xID, xID + ".jpg", serverpath + "admin/tm/Picz/", logo_pic); }
                if (auth_doc.HasFile) { xauth_doc = doUploadDoc(xID, serverpath + "admin/tm/docz/", auth_doc); }
                if (sup_doc1.HasFile) { xsup_doc1 = doUploadDoc(xID, serverpath + "admin/tm/docz/", sup_doc1); }
                if (sup_doc2.HasFile) { xsup_doc2 = doUploadDoc(xID, serverpath + "admin/tm/docz/", sup_doc2); }
                xpath = xpath.Replace(serverpath + "admin/tm/", "");
                xsup_doc2 = xsup_doc2.Replace(serverpath + "admin/tm/", "");
                xsup_doc1 = xsup_doc1.Replace(serverpath + "admin/tm/", "");
                xauth_doc = xauth_doc.Replace(serverpath + "admin/tm/", "");

                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                      //  command.CommandTimeout = 300;
                        command.CommandText = "UPDATE mark_info SET logo_pic=@logo_pic,auth_doc=@auth_doc,sup_doc1=@sup_doc1,sup_doc2=@sup_doc2 WHERE log_staff=@log_staff  ";                      

                        command.Connection.Open();
                        command.Parameters.Add("@logo_pic", SqlDbType.Text);
                        command.Parameters.Add("@auth_doc", SqlDbType.Text);
                        command.Parameters.Add("@sup_doc1", SqlDbType.Text);
                        command.Parameters.Add("@sup_doc2", SqlDbType.Text);
                        command.Parameters.Add("@log_staff", SqlDbType.NChar, 50);

                        command.Parameters["@logo_pic"].Value = xpath;
                        command.Parameters["@auth_doc"].Value = xauth_doc;
                        command.Parameters["@sup_doc1"].Value = xsup_doc1;
                        command.Parameters["@sup_doc2"].Value = xsup_doc2;
                        command.Parameters["@log_staff"].Value = pID;
                        int h = Convert.ToInt32(command.ExecuteNonQuery());
                        command.Connection.Close();
                    }
                }
                if (command.Connection.State == ConnectionState.Open) { command.Connection.Close(); }
            }
            catch (Exception exception)
            {
                xID = "0";
                XWriters pp = new XWriters();
                
                string message = c_pwall.validationID + " " + DateTime.Now;

                string vpath = System.Web.HttpContext.Current.Server.MapPath("~/") + "TradeMarkLog/NonGeneric/" + c_pwall.validationID + ".txt";
              
                pp.WriteToFile(message, vpath);
                exception.ToString(); xID = "0";
                //   command.Connection.Close();
            }
            finally
            {
               
              //  xID = "0";
                // command.Connection.Close(); 
            }
            return xID;
        }

        public string activity_log(string userID, string Module,string Operation,string documentid,string status,string oldtitle ,string newtitle ,string oldapplicantname ,string newapplicantname ,string oldclass,string newclass)
        {
            //  ba2xai_cldx_backupEntities xp = new ba2xai_cldx_backupEntities();
          //  ba2xai_cldx_backupEntities1 app = new ba2xai_cldx_backupEntities1();
            //  activity_lg dd = new activity_lg();
            string str = "";
            string connectionString = Connect();
          //  SqlConnection connection = new SqlConnection(this.Connect());
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = connection.CreateCommand();
            DateTime currentDate2 = DateTime.UtcNow;
            TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("W. Central Africa Standard Time");
            currentDate2 = TimeZoneInfo.ConvertTimeFromUtc(currentDate2, pstZone);
          //  currentDate2 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentDate2, TimeZoneInfo.Local.Id, "GMT Standard Time");
          //  TimeSpan currentTime2 = currentDate2.TimeOfDay;

          

            cmd.CommandText = "INSERT INTO activity_lg (userID,act_date,module,DocumentId,Operation,status,old_title,new_title,old_class,new_class,old_applicantname,new_applicantname) VALUES (@userID,@act_date,@module,@DocumentId,@Operation,@status,@old_title,@new_title,@old_class,@new_class,@old_applicantname,@new_applicantname)";
            connection.Open();
            cmd.Parameters.Add("@userID", SqlDbType.VarChar, 200);
            cmd.Parameters.Add("@DocumentId", SqlDbType.VarChar, 200);
            cmd.Parameters.Add("@Operation", SqlDbType.VarChar, 200);
            cmd.Parameters.Add("@act_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@status", SqlDbType.VarChar, 200);
            cmd.Parameters.Add("@old_title", SqlDbType.VarChar, 400);
            cmd.Parameters.Add("@new_title", SqlDbType.VarChar, 400);
            cmd.Parameters.Add("@old_class", SqlDbType.VarChar, 200);
            cmd.Parameters.Add("@new_class", SqlDbType.VarChar, 200);
            cmd.Parameters.Add("@old_applicantname", SqlDbType.VarChar, 400);
            cmd.Parameters.Add("@new_applicantname", SqlDbType.VarChar, 400);
            //  cmd.Parameters.Add("@act_time", SqlDbType.Timestamp);
            cmd.Parameters.Add("@module", SqlDbType.Text);
            cmd.Parameters["@userID"].Value = userID;
            cmd.Parameters["@act_date"].Value = currentDate2;

            cmd.Parameters["@DocumentId"].Value = documentid;
            cmd.Parameters["@Operation"].Value = Operation;
            cmd.Parameters["@status"].Value = status;
            //  cmd.Parameters["@act_time"].Value = currentTime2;
            cmd.Parameters["@module"].Value = Module;
            cmd.Parameters["@old_title"].Value = oldtitle;
            cmd.Parameters["@new_title"].Value = newtitle;
            cmd.Parameters["@old_class"].Value = oldclass;
            cmd.Parameters["@new_class"].Value = newclass;

            cmd.Parameters["@old_applicantname"].Value = oldapplicantname;
            cmd.Parameters["@new_applicantname"].Value = newapplicantname;

            foreach (SqlParameter Parameter in cmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            try {
                str = cmd.ExecuteScalar().ToString();

            }

            catch(Exception ee)
            {

            }
            connection.Close();
            return str;
        }

        public int editTrademarkTx(Applicant c_app, MarkInfo c_mark, AddressService c_aos, Representative c_rep, Address c_app_addy, Address c_rep_addy, Stage c_pwall, SortedList<string, string> sl_docz,
     FileUpload logo_pic, FileUpload auth_doc, FileUpload sup_doc1, FileUpload sup_doc2, string serverpath, Boolean vfile)
        {
            int num = 0;
            string xauth_doc = ""; string xsup_doc1 = ""; string xsup_doc2 = ""; string xpath = "";
            SqlConnection connection; SqlCommand command;

            string connectionString = Connect();
            // c_pwall.reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
            c_pwall.reg_date = c_mark.reg_date;
            c_pwall.xtime = c_pwall.log_officer + ": " + c_pwall.reg_date + " " + DateTime.Now.ToString("00:00:00 PM");
            // c_pwall.visible = "1"; c_pwall.status = "1"; c_pwall.stage = "5"; c_pwall.data_status = "Fresh";
            //  c_pwall.acc_p = "0"; c_pwall.rtm = "0"; int app_addyID = 0; int rep_addyID = 0;
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    if (c_pwall.validationID == "" || c_pwall.validationID == null)
                    {
                        throw new Exception("Test Exception");
                    }
                    using (command = connection.CreateCommand())
                    {
                        // command.CommandTimeout = 300;

                        command.CommandText = "UPDATE pwallet SET applicantID='" + c_pwall.applicantID + "',reg_date='" + c_pwall.reg_date + "' ,rtm='" + c_pwall.rtm + "' WHERE ID='" + c_pwall.ID + "'  ";

                        command.Connection.Open();
                        num += command.ExecuteNonQuery();
                        command.Connection.Close();
                    }
                }
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        // command.CommandTimeout = 300;
                        command.CommandText = "UPDATE address SET countryID= '" + c_app_addy.countryID + "',stateID='" + c_app_addy.stateID + "',street=@street,zip='',telephone1='" + c_app_addy.telephone1 + "', ";
                        command.CommandText += " email1='" + c_app_addy.email1 + "',reg_date='" + c_app_addy.reg_date + "' WHERE ID='" + c_app_addy.ID + "'  ";
                        command.Parameters.Add("@street", SqlDbType.NChar, 400);

                        command.Parameters["@street"].Value = c_app_addy.street;

                        command.Connection.Open();
                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }
                        num += command.ExecuteNonQuery();
                        command.Connection.Close();
                    }
                }
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        // command.CommandTimeout = 300;
                        command.CommandText = "UPDATE address SET countryID= '" + c_rep_addy.countryID + "',stateID='" + c_rep_addy.stateID + "',street=@street,zip='',telephone1='" + c_rep_addy.telephone1 + "', ";
                        command.CommandText += " email1='" + c_rep_addy.email1 + "',reg_date='" + c_rep_addy.reg_date + "' WHERE ID='" + c_rep_addy.ID + "'  ";
                        command.Parameters.Add("@street", SqlDbType.NChar, 400);

                        command.Parameters["@street"].Value = c_rep_addy.street;
                        command.Connection.Open();

                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }
                        num += command.ExecuteNonQuery();
                        command.Connection.Close();
                    }
                }
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.Connection.Open();
                        //  command.CommandTimeout = 300;
                        //command.CommandText = "UPDATE applicant SET xname='" + c_app.xname + "',nationality='" + c_app.nationality + "',reg_date='" + c_app.reg_date + "' WHERE ID='" + c_app.ID + "'  ";
                        command.CommandText = "UPDATE applicant SET xname=@xname,nationality=@nationality ,reg_date=@reg_date  WHERE ID=@ID ";
                        command.Parameters.Add("@xname", SqlDbType.NChar, 200);
                        command.Parameters.Add("@nationality", SqlDbType.NChar, 50);
                        command.Parameters.Add("@reg_date", SqlDbType.NChar, 50);
                        command.Parameters.Add("@ID", SqlDbType.NChar, 50);
                       
                        command.Parameters["@xname"].Value = c_app.xname;
                        command.Parameters["@nationality"].Value = c_app.nationality;
                        command.Parameters["@reg_date"].Value = c_app.reg_date;
                        command.Parameters["@ID"].Value = c_app.ID;

                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }

                        num += command.ExecuteNonQuery();
                        command.Connection.Close();
                    }
                }

                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        //  command.CommandTimeout = 300;
                        command.CommandText = "UPDATE address_service SET countryID=@countryID,stateID=@stateID,street=@street,telephone1=@telephone1,email1=@email1,reg_date=@reg_date WHERE ID='" + c_aos.ID + "' ";

                        command.Parameters.Add("@countryID", SqlDbType.VarChar, 200);
                        command.Parameters.Add("@stateID", SqlDbType.VarChar, 200);
                        command.Parameters.Add("@street", SqlDbType.VarChar, 400);
                        command.Parameters.Add("@telephone1", SqlDbType.VarChar, 200);
                        command.Parameters.Add("@email1", SqlDbType.VarChar, 200);
                        command.Parameters.Add("@reg_date", SqlDbType.VarChar, 200);




                        command.Parameters["@countryID"].Value = c_aos.countryID;

                        command.Parameters["@stateID"].Value = c_aos.stateID;
                        command.Parameters["@street"].Value = c_aos.street;
                        command.Parameters["@telephone1"].Value = c_aos.telephone1;
                        command.Parameters["@email1"].Value = c_aos.email1;
                        command.Parameters["@reg_date"].Value = c_aos.reg_date;
                        command.Connection.Open();
                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }
                        num += command.ExecuteNonQuery();
                        command.Connection.Close();
                    }
                }
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        //  command.CommandTimeout = 300;
                        command.CommandText = "UPDATE representative SET agent_code=@agent_code,xname=@xname,nationality='" + c_rep.nationality + "',reg_date='" + c_rep.reg_date + "' WHERE ID='" + c_rep.ID + "'";
                        command.Parameters.Add("@agent_code", SqlDbType.VarChar, 200);
                        command.Parameters.Add("@xname", SqlDbType.VarChar, 200);

                       
                        command.Parameters["@agent_code"].Value = c_rep.agent_code;
                        command.Parameters["@xname"].Value = c_rep.xname;

                        command.Connection.Open();

                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }
                        num += command.ExecuteNonQuery();
                        command.Connection.Close();
                    }
                }

                using (connection = new SqlConnection(connectionString))
                {
                    string vreg = c_mark.reg_number;

                    int i = 0;
                    try
                    {
                        i = vreg.IndexOf('/');




                        //if (i > 0)
                        //{
                        //    String vsp = vreg.Substring(i);
                        //    string dd = vsp.ToString();

                        //    if (c_mark.tm_typeID == "1")
                        //    {

                        //        c_mark.reg_number = "NG" + vsp;
                        //    }

                        //    else
                        //    {

                        //        c_mark.reg_number = "F" + vsp;
                        //    }

                        //    string[] words = c_mark.reg_number.Split('/');
                        //    string sp = words[3];
                        //    DateTime vdate = Convert.ToDateTime(c_mark.reg_date);
                        //    string sp2 = words[0] + "/" + words[1] + "/" + words[2] + "/" + vdate.Year + "/" + words[4];

                        //    c_mark.reg_number = sp2;


                        //}


                    }
                    catch (Exception ee)
                    {


                    }

                    using (command = connection.CreateCommand())
                    {
                        // command.CommandTimeout = 300;
                        //command.CommandText = "UPDATE mark_info SET tm_typeID='" + c_mark.tm_typeID + "',product_title='" + c_mark.product_title + "',logo_descriptionID='" + c_mark.logo_descriptionID + "',reg_number='" + c_mark.reg_number + "',nice_class='" + c_mark.nice_class + "', ";
                        //command.CommandText += " nice_class_desc='" + c_mark.nice_class_desc.Replace("'","") + "',national_classID='" + c_mark.national_classID + "',disclaimer='" + c_mark.disclaimer + "',reg_date='" + c_mark.reg_date + "' WHERE xID='" + c_mark.xID + "' ";   
                        command.Connection.Open();
                        command.CommandText = "UPDATE mark_info SET tm_typeID=@tm_typeID,product_title=@product_title ,logo_descriptionID=@logo_descriptionID,reg_number=@reg_number ,nice_class=@nice_class , ";
                        command.CommandText += " nice_class_desc=@nice_class_desc,national_classID=@national_classID ,disclaimer=@disclaimer,reg_date=@reg_date  WHERE xID=@xID ";

                        command.Parameters.Add("@tm_typeID", SqlDbType.NVarChar);
                        command.Parameters.Add("@product_title", SqlDbType.NVarChar);
                        command.Parameters.Add("@logo_descriptionID", SqlDbType.NVarChar);
                        command.Parameters.Add("@reg_number", SqlDbType.NVarChar);
                        command.Parameters.Add("@nice_class", SqlDbType.NVarChar);
                        command.Parameters.Add("@nice_class_desc", SqlDbType.NVarChar);
                        command.Parameters.Add("@national_classID", SqlDbType.NVarChar);
                        command.Parameters.Add("@disclaimer", SqlDbType.NVarChar);
                        command.Parameters.Add("@reg_date", SqlDbType.NVarChar);
                        command.Parameters.Add("@xID", SqlDbType.NVarChar);

                        command.Parameters["@tm_typeID"].Value = c_mark.tm_typeID;
                        command.Parameters["@product_title"].Value = c_mark.product_title;
                        command.Parameters["@logo_descriptionID"].Value = c_mark.logo_descriptionID;
                        command.Parameters["@reg_number"].Value = c_mark.reg_number;
                        command.Parameters["@nice_class"].Value = c_mark.nice_class;
                        command.Parameters["@nice_class_desc"].Value = c_mark.nice_class_desc;
                        command.Parameters["@national_classID"].Value = c_mark.national_classID;
                        command.Parameters["@disclaimer"].Value = c_mark.disclaimer;
                        command.Parameters["@reg_date"].Value = c_mark.reg_date;
                        command.Parameters["@xID"].Value = c_mark.xID;
                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }

                        num += command.ExecuteNonQuery();
                        command.Connection.Close();
                    }
                }


                if (!(vfile))
                {
                    xpath = "";

                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            //  command.CommandTimeout = 300;
                            command.CommandText = "UPDATE mark_info SET logo_pic='" + xpath + "' WHERE log_staff='" + c_mark.log_staff + "'  ";
                            command.Connection.Open();
                            int h = Convert.ToInt32(command.ExecuteNonQuery());
                            command.Connection.Close();
                        }
                    }

                }
                if (logo_pic.HasFile)
                {
                    if ((c_mark.logo_pic != null) && (c_mark.logo_pic != ""))
                    {
                        if (File.Exists(serverpath + "admin/tm/" + c_mark.logo_pic))
                        {
                            File.Delete(serverpath + "admin/tm/" + c_mark.logo_pic);
                        }
                    }
                    if (vfile)
                    {
                        xpath = doUploadPic(c_mark.xID, c_mark.xID + ".jpg", serverpath + "admin/tm/Picz/", logo_pic);
                        xpath = xpath.Replace(serverpath + "admin/tm/", "");
                    }
                    else
                    {

                        xpath = "";
                    }

                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            // command.CommandTimeout = 300;
                            command.CommandText = "UPDATE mark_info SET logo_pic='" + xpath + "' WHERE log_staff='" + c_mark.log_staff + "'  ";
                            command.Connection.Open();
                            int h = Convert.ToInt32(command.ExecuteNonQuery());
                            command.Connection.Close();
                        }
                    }
                }
                if (auth_doc.HasFile)
                {
                    if ((c_mark.auth_doc != null) && (c_mark.auth_doc != ""))
                    {
                        if (File.Exists(serverpath + "admin/tm/" + c_mark.auth_doc))
                        {
                            File.Delete(serverpath + "admin/tm/" + c_mark.auth_doc);
                        }
                    }
                    xauth_doc = doUploadDoc(c_mark.xID, serverpath + "admin/tm/docz/", auth_doc);

                    xauth_doc = xauth_doc.Replace(serverpath + "admin/tm/", "");
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            // command.CommandTimeout = 300;
                            command.CommandText = "UPDATE mark_info SET auth_doc='" + xauth_doc + "' WHERE log_staff='" + c_mark.log_staff + "'  ";
                            command.Connection.Open();
                            int h = Convert.ToInt32(command.ExecuteNonQuery());
                            command.Connection.Close();
                        }
                    }
                }
                if (sup_doc1.HasFile)
                {
                    if ((c_mark.sup_doc1 != null) && (c_mark.sup_doc1 != ""))
                    {
                        if (File.Exists(serverpath + "admin/tm/" + c_mark.sup_doc1))
                        {
                            File.Delete(serverpath + "admin/tm/" + c_mark.sup_doc1);
                        }
                    }
                    xsup_doc1 = doUploadDoc(c_mark.xID, serverpath + "admin/tm/docz/", sup_doc1);

                    xsup_doc1 = xsup_doc1.Replace(serverpath + "admin/tm/", "");
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            // command.CommandTimeout = 300;
                            command.CommandText = "UPDATE mark_info SET sup_doc1='" + xsup_doc1 + "' WHERE log_staff='" + c_mark.log_staff + "'  ";
                            command.Connection.Open();
                            int h = Convert.ToInt32(command.ExecuteNonQuery());
                            command.Connection.Close();
                        }
                    }
                }
                if (sup_doc2.HasFile)
                {
                    if ((c_mark.sup_doc2 != null) && (c_mark.sup_doc2 != ""))
                    {
                        if (File.Exists(serverpath + "admin/tm/" + c_mark.sup_doc2))
                        {
                            File.Delete(serverpath + "admin/tm/" + c_mark.sup_doc2);
                        }
                    }
                    xsup_doc2 = doUploadDoc(c_mark.xID, serverpath + "admin/tm/docz/", sup_doc2);
                    xsup_doc2 = xsup_doc2.Replace(serverpath + "admin/tm/", "");
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            //  command.CommandTimeout = 300;
                            command.CommandText = "UPDATE mark_info SET sup_doc2='" + xsup_doc2 + "' WHERE log_staff='" + c_mark.log_staff + "'  ";
                            command.Connection.Open();
                            int h = Convert.ToInt32(command.ExecuteNonQuery());
                            command.Connection.Close();
                        }
                    }
                }


                if (command.Connection.State == ConnectionState.Open) { command.Connection.Close(); }
            }
            catch (Exception exception)
            {
                exception.ToString(); num = 0;
            }
            finally
            {

            }
            return num;
        }


        public long editTrademarkTx2(Applicant c_app, MarkInfo c_mark, AddressService c_aos, Representative c_rep, Address c_app_addy, Address c_rep_addy, Stage c_pwall, SortedList<string, string> sl_docz,
    FileUpload logo_pic, FileUpload auth_doc, FileUpload sup_doc1, FileUpload sup_doc2, string serverpath, Boolean vfile,string paymentref)
        {
            long num = 0;
            string xauth_doc = ""; string xsup_doc1 = ""; string xsup_doc2 = ""; string xpath = "";
            SqlConnection connection; SqlCommand command;

            string connectionString = Connect();
            // c_pwall.reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
            c_pwall.reg_date = c_mark.reg_date;
            c_pwall.xtime = c_pwall.log_officer + ": " + c_pwall.reg_date + " " + DateTime.Now.ToString("00:00:00 PM");

            ba2xai_cldx_backupEntities1 app = new ba2xai_cldx_backupEntities1();

            // c_pwall.visible = "1"; c_pwall.status = "1"; c_pwall.stage = "5"; c_pwall.data_status = "Fresh";
            //  c_pwall.acc_p = "0"; c_pwall.rtm = "0"; int app_addyID = 0; int rep_addyID = 0;
            try
            {
                pwalletAmendment pamend = new pwalletAmendment();
                pamend.AmendmentDate = DateTime.Now;
                pamend.AmendmentStatus = "Pending";
                pamend.amt = c_pwall.amt;
                pamend.applicantID = c_pwall.applicantID;
                pamend.data_status = "amendment";
                pamend.log_officer = c_pwall.log_officer;
                pamend.pwalletid = c_pwall.ID;

                pamend.reg_date = c_pwall.reg_date;

                pamend.rtm = c_pwall.rtm;

                pamend.stage = c_pwall.stage;

                pamend.status = "5";

                pamend.validationID = c_pwall.validationID;



                pamend.PaymentRef = paymentref;
                app.pwalletAmendments.Add(pamend);
                app.SaveChanges();



                //using (connection = new SqlConnection(connectionString))
                //{
                //    if (c_pwall.validationID == "" || c_pwall.validationID == null)
                //    {
                //        throw new Exception("Test Exception");
                //    }
                //    using (command = connection.CreateCommand())
                //    {
                //        // command.CommandTimeout = 300;

                //        command.CommandText = "UPDATE pwallet SET applicantID='" + c_pwall.applicantID + "',reg_date='" + c_pwall.reg_date + "' ,rtm='" + c_pwall.rtm + "' WHERE ID='" + c_pwall.ID + "'  ";

                //        command.Connection.Open();
                //        num += command.ExecuteNonQuery();
                //        command.Connection.Close();
                //    }
                //}

                addressAmendment xpaddress = new addressAmendment();
                xpaddress.city = c_app_addy.city;
                xpaddress.countryID = c_app_addy.countryID;
                xpaddress.email1 = c_app_addy.email1;
                xpaddress.email2 = c_app_addy.email2;
                xpaddress.lgaID = c_app_addy.lgaID;
                xpaddress.log_staff =Convert.ToString( pamend.ID);
                xpaddress.reg_date = c_app_addy.reg_date;
                xpaddress.stateID = c_app_addy.stateID;
                xpaddress.street = c_app_addy.street;
                xpaddress.telephone1 = c_app_addy.telephone1;
                xpaddress.telephone2 = c_app_addy.telephone2;
                xpaddress.zip = c_app_addy.zip;
                app.addressAmendments.Add(xpaddress);
                app.SaveChanges();
                //using (connection = new SqlConnection(connectionString))
                //{
                //    using (command = connection.CreateCommand())
                //    {
                //        // command.CommandTimeout = 300;
                //        command.CommandText = "UPDATE address SET countryID= '" + c_app_addy.countryID + "',stateID='" + c_app_addy.stateID + "',street='" + c_app_addy.street + "',zip='',telephone1='" + c_app_addy.telephone1 + "', ";
                //        command.CommandText += " email1='" + c_app_addy.email1 + "',reg_date='" + c_app_addy.reg_date + "' WHERE ID='" + c_app_addy.ID + "'  ";
                //        command.Connection.Open();
                //        num += command.ExecuteNonQuery();
                //        command.Connection.Close();
                //    }
                //}

                addressAmendment xpaddress2 = new addressAmendment();
                xpaddress2.city = c_rep_addy.city;
                xpaddress2.countryID = c_rep_addy.countryID;
                xpaddress2.email1 = c_rep_addy.email1;
                xpaddress2.email2 = c_rep_addy.email2;
                xpaddress2.lgaID = c_rep_addy.lgaID;
                xpaddress2.log_staff = Convert.ToString(pamend.ID);
                xpaddress2.reg_date = c_rep_addy.reg_date;
                xpaddress2.stateID = c_rep_addy.stateID;
                xpaddress2.street = c_rep_addy.street;
                xpaddress2.telephone1 = c_rep_addy.telephone1;
                xpaddress2.telephone2 = c_rep_addy.telephone2;
                xpaddress2.zip = c_rep_addy.zip;
                app.addressAmendments.Add(xpaddress2);
                app.SaveChanges();
                //using (connection = new SqlConnection(connectionString))
                //{
                //    using (command = connection.CreateCommand())
                //    {
                //        // command.CommandTimeout = 300;
                //        command.CommandText = "UPDATE address SET countryID= '" + c_rep_addy.countryID + "',stateID='" + c_rep_addy.stateID + "',street='" + c_rep_addy.street + "',zip='',telephone1='" + c_rep_addy.telephone1 + "', ";
                //        command.CommandText += " email1='" + c_rep_addy.email1 + "',reg_date='" + c_rep_addy.reg_date + "' WHERE ID='" + c_rep_addy.ID + "'  ";
                //        command.Connection.Open();
                //        num += command.ExecuteNonQuery();
                //        command.Connection.Close();
                //    }
                //}

                applicantAmendment appamendment = new applicantAmendment();

                appamendment.addressID =Convert.ToString( xpaddress.ID );

                appamendment.individual_id_number = c_app.individual_id_number;

                appamendment.log_staff = Convert.ToString(pamend.ID);

                appamendment.nationality = c_app.nationality;

                appamendment.reg_date = c_app.reg_date;

                appamendment.tax_id_number = c_app.tax_id_number;

                appamendment.tax_id_type = c_app.tax_id_type;

                appamendment.visible = c_app.visible;

                appamendment.xname = c_app.xname;

                appamendment.xtime = c_app.xtime;

                appamendment.xtype = c_app.xtype;

                app.applicantAmendments.Add(appamendment);
                app.SaveChanges();

                //using (connection = new SqlConnection(connectionString))
                //{
                //    using (command = connection.CreateCommand())
                //    {
                //        command.Connection.Open();
                //        //  command.CommandTimeout = 300;
                //        //command.CommandText = "UPDATE applicant SET xname='" + c_app.xname + "',nationality='" + c_app.nationality + "',reg_date='" + c_app.reg_date + "' WHERE ID='" + c_app.ID + "'  ";
                //        command.CommandText = "UPDATE applicant SET xname=@xname,nationality=@nationality ,reg_date=@reg_date  WHERE ID=@ID ";
                //        command.Parameters.Add("@xname", SqlDbType.NChar, 200);
                //        command.Parameters.Add("@nationality", SqlDbType.NChar, 50);
                //        command.Parameters.Add("@reg_date", SqlDbType.NChar, 50);
                //        command.Parameters.Add("@ID", SqlDbType.NChar, 50);

                //        command.Parameters["@xname"].Value = c_app.xname;
                //        command.Parameters["@nationality"].Value = c_app.nationality;
                //        command.Parameters["@reg_date"].Value = c_app.reg_date;
                //        command.Parameters["@ID"].Value = c_app.ID;
                //        num += command.ExecuteNonQuery();
                //        command.Connection.Close();
                //    }
                //}

                address_serviceAmendment xpservice = new address_serviceAmendment();
                xpservice.city = c_aos.city;
                xpservice.countryID = c_aos.countryID;
                xpservice.email1 = c_aos.email1;

                xpservice.email2 = c_aos.email2;

                xpservice.lgaID = c_aos.lgaID;

                xpservice.log_staff = Convert.ToString(pamend.ID);

                xpservice.reg_date = c_aos.reg_date;

                xpservice.stateID = c_aos.stateID;

                xpservice.street = c_aos.street;

                xpservice.telephone1 = c_aos.telephone1;

                xpservice.telephone2 = c_aos.telephone2;

                xpservice.visible = c_aos.visible;

                xpservice.xtime = c_aos.xtime;

                xpservice.zip = c_aos.zip;

                app.address_serviceAmendment.Add(xpservice);

                app.SaveChanges();


                //using (connection = new SqlConnection(connectionString))
                //{
                //    using (command = connection.CreateCommand())
                //    {
                //        //  command.CommandTimeout = 300;
                //        command.CommandText = "UPDATE address_service SET countryID='" + c_aos.countryID + "',stateID='" + c_aos.stateID + "',street='" + c_aos.street + "',telephone1='" + c_aos.telephone1 + "',email1='" + c_aos.email1 + "',reg_date='" + c_aos.reg_date + "' WHERE ID='" + c_aos.ID + "' ";

                //        command.Connection.Open();
                //        num += command.ExecuteNonQuery();
                //        command.Connection.Close();
                //    }
                //}

                representativeAmendment repamendment = new representativeAmendment();
                repamendment.addressID = Convert.ToString(xpaddress2.ID );

                repamendment.agent_code = c_rep.agent_code;

                repamendment.individual_id_number = c_rep.individual_id_number;

                repamendment.individual_id_type = c_rep.individual_id_type;

                repamendment.log_staff = Convert.ToString(pamend.ID);

                repamendment.nationality = c_rep.nationality;

                repamendment.reg_date = c_rep.reg_date;

                repamendment.visible = c_rep.visible;

                repamendment.xname = c_rep.xname;

                repamendment.xtime = c_rep.xtime;
                app.representativeAmendments.Add(repamendment);
                app.SaveChanges();

                //using (connection = new SqlConnection(connectionString))
                //{
                //    using (command = connection.CreateCommand())
                //    {
                //        //  command.CommandTimeout = 300;
                //        command.CommandText = "UPDATE representative SET agent_code='" + c_rep.agent_code + "',xname='" + c_rep.xname + "',nationality='" + c_rep.nationality + "',reg_date='" + c_rep.reg_date + "' WHERE ID='" + c_rep.ID + "'";

                //        command.Connection.Open();
                //        num += command.ExecuteNonQuery();
                //        command.Connection.Close();
                //    }
                //}
                mark_infoAmendment markamend = new mark_infoAmendment();

                markamend.disclaimer = c_mark.disclaimer;

                markamend.logo_descriptionID = c_mark.logo_descriptionID;

                markamend.logo_pic = c_mark.logo_pic;

                markamend.log_staff = Convert.ToString(pamend.ID);

                markamend.national_classID = c_mark.national_classID;

                markamend.nice_class = c_mark.nice_class;

                markamend.nice_class_desc = c_mark.nice_class_desc;

                markamend.product_title = c_mark.product_title;

                markamend.reg_date = c_mark.reg_date;

                markamend.reg_number = c_mark.reg_number;

                markamend.sign_type = c_mark.sign_type;

                markamend.sup_doc1 = c_mark.sup_doc1;

                markamend.sup_doc2 = c_mark.sup_doc2;

                markamend.tm_typeID = c_mark.tm_typeID;

                markamend.vienna_class = c_mark.vienna_class;

                markamend.xtime = c_mark.xtime;

                markamend.xvisible = c_mark.xvisible;

                

                using (connection = new SqlConnection(connectionString))
                {
                    string vreg = c_mark.reg_number;

                    int i = 0;
                    try
                    {
                        i = vreg.IndexOf('/');




                       


                    }
                    catch (Exception ee)
                    {


                    }

                    //using (command = connection.CreateCommand())
                    //{
                        
                    //    command.Connection.Open();
                    //    command.CommandText = "UPDATE mark_info SET tm_typeID=@tm_typeID,product_title=@product_title ,logo_descriptionID=@logo_descriptionID,reg_number=@reg_number ,nice_class=@nice_class , ";
                    //    command.CommandText += " nice_class_desc=@nice_class_desc,national_classID=@national_classID ,disclaimer=@disclaimer,reg_date=@reg_date  WHERE xID=@xID ";

                    //    command.Parameters.Add("@tm_typeID", SqlDbType.NVarChar);
                    //    command.Parameters.Add("@product_title", SqlDbType.NVarChar);
                    //    command.Parameters.Add("@logo_descriptionID", SqlDbType.NVarChar);
                    //    command.Parameters.Add("@reg_number", SqlDbType.NVarChar);
                    //    command.Parameters.Add("@nice_class", SqlDbType.NVarChar);
                    //    command.Parameters.Add("@nice_class_desc", SqlDbType.NVarChar);
                    //    command.Parameters.Add("@national_classID", SqlDbType.NVarChar);
                    //    command.Parameters.Add("@disclaimer", SqlDbType.NVarChar);
                    //    command.Parameters.Add("@reg_date", SqlDbType.NVarChar);
                    //    command.Parameters.Add("@xID", SqlDbType.NVarChar);

                    //    command.Parameters["@tm_typeID"].Value = c_mark.tm_typeID;
                    //    command.Parameters["@product_title"].Value = c_mark.product_title;
                    //    command.Parameters["@logo_descriptionID"].Value = c_mark.logo_descriptionID;
                    //    command.Parameters["@reg_number"].Value = c_mark.reg_number;
                    //    command.Parameters["@nice_class"].Value = c_mark.nice_class;
                    //    command.Parameters["@nice_class_desc"].Value = c_mark.nice_class_desc;
                    //    command.Parameters["@national_classID"].Value = c_mark.national_classID;
                    //    command.Parameters["@disclaimer"].Value = c_mark.disclaimer;
                    //    command.Parameters["@reg_date"].Value = c_mark.reg_date;
                    //    command.Parameters["@xID"].Value = c_mark.xID;
                    //    foreach (SqlParameter Parameter in command.Parameters)
                    //    {
                    //        if (Parameter.Value == null)
                    //        {
                    //            Parameter.Value = DBNull.Value;
                    //        }
                    //    }

                    //    num += command.ExecuteNonQuery();
                    //    command.Connection.Close();
                    //}
                }


                if (!(vfile))
                {
                    xpath = "";

                    markamend.logo_pic = xpath;

                    //using (connection = new SqlConnection(connectionString))
                    //{
                    //    using (command = connection.CreateCommand())
                    //    {
                    //        //  command.CommandTimeout = 300;
                    //        command.CommandText = "UPDATE mark_info SET logo_pic='" + xpath + "' WHERE log_staff='" + c_mark.log_staff + "'  ";
                    //        command.Connection.Open();
                    //        int h = Convert.ToInt32(command.ExecuteNonQuery());
                    //        command.Connection.Close();
                    //    }
                    //}

                }
                if (logo_pic.HasFile)
                {
                    if ((c_mark.logo_pic != null) && (c_mark.logo_pic != ""))
                    {
                        if (File.Exists(serverpath + "admin/tm/" + c_mark.logo_pic))
                        {
                            File.Delete(serverpath + "admin/tm/" + c_mark.logo_pic);
                        }
                    }
                    if (vfile)
                    {
                        xpath = doUploadPic(c_mark.xID, c_mark.xID + ".jpg", serverpath + "admin/tm/Picz/", logo_pic);
                        xpath = xpath.Replace(serverpath + "admin/tm/", "");
                    }
                    else
                    {

                        xpath = "";
                    }
                    markamend.logo_pic = xpath;
                    //using (connection = new SqlConnection(connectionString))
                    //{
                    //    using (command = connection.CreateCommand())
                    //    {
                    //        // command.CommandTimeout = 300;
                    //        command.CommandText = "UPDATE mark_info SET logo_pic='" + xpath + "' WHERE log_staff='" + c_mark.log_staff + "'  ";
                    //        command.Connection.Open();
                    //        int h = Convert.ToInt32(command.ExecuteNonQuery());
                    //        command.Connection.Close();
                    //    }
                    //}
                }
                if (auth_doc.HasFile)
                {
                    if ((c_mark.auth_doc != null) && (c_mark.auth_doc != ""))
                    {
                        if (File.Exists(serverpath + "admin/tm/" + c_mark.auth_doc))
                        {
                            File.Delete(serverpath + "admin/tm/" + c_mark.auth_doc);
                        }
                    }
                    xauth_doc = doUploadDoc(c_mark.xID, serverpath + "admin/tm/docz/", auth_doc);

                    xauth_doc = xauth_doc.Replace(serverpath + "admin/tm/", "");

                    markamend.auth_doc = xauth_doc;
                    //using (connection = new SqlConnection(connectionString))
                    //{
                    //    using (command = connection.CreateCommand())
                    //    {
                    //        // command.CommandTimeout = 300;
                    //        command.CommandText = "UPDATE mark_info SET auth_doc='" + xauth_doc + "' WHERE log_staff='" + c_mark.log_staff + "'  ";
                    //        command.Connection.Open();
                    //        int h = Convert.ToInt32(command.ExecuteNonQuery());
                    //        command.Connection.Close();
                    //    }
                    //}
                }
                if (sup_doc1.HasFile)
                {
                    if ((c_mark.sup_doc1 != null) && (c_mark.sup_doc1 != ""))
                    {
                        if (File.Exists(serverpath + "admin/tm/" + c_mark.sup_doc1))
                        {
                            File.Delete(serverpath + "admin/tm/" + c_mark.sup_doc1);
                        }
                    }
                    xsup_doc1 = doUploadDoc(c_mark.xID, serverpath + "admin/tm/docz/", sup_doc1);

                    xsup_doc1 = xsup_doc1.Replace(serverpath + "admin/tm/", "");

                    markamend.sup_doc1 = xsup_doc1;
                    //using (connection = new SqlConnection(connectionString))
                    //{
                    //    using (command = connection.CreateCommand())
                    //    {
                    //        // command.CommandTimeout = 300;
                    //        command.CommandText = "UPDATE mark_info SET sup_doc1='" + xsup_doc1 + "' WHERE log_staff='" + c_mark.log_staff + "'  ";
                    //        command.Connection.Open();
                    //        int h = Convert.ToInt32(command.ExecuteNonQuery());
                    //        command.Connection.Close();
                    //    }
                    //}
                }
                if (sup_doc2.HasFile)
                {
                    if ((c_mark.sup_doc2 != null) && (c_mark.sup_doc2 != ""))
                    {
                        if (File.Exists(serverpath + "admin/tm/" + c_mark.sup_doc2))
                        {
                            File.Delete(serverpath + "admin/tm/" + c_mark.sup_doc2);
                        }
                    }
                    xsup_doc2 = doUploadDoc(c_mark.xID, serverpath + "admin/tm/docz/", sup_doc2);
                    xsup_doc2 = xsup_doc2.Replace(serverpath + "admin/tm/", "");

                    markamend.sup_doc2 = xsup_doc2;
                    //using (connection = new SqlConnection(connectionString))
                    //{
                    //    using (command = connection.CreateCommand())
                    //    {
                    //        //  command.CommandTimeout = 300;
                    //        command.CommandText = "UPDATE mark_info SET sup_doc2='" + xsup_doc2 + "' WHERE log_staff='" + c_mark.log_staff + "'  ";
                    //        command.Connection.Open();
                    //        int h = Convert.ToInt32(command.ExecuteNonQuery());
                    //        command.Connection.Close();
                    //    }
                    //}
                }

                app.mark_infoAmendment.Add(markamend);
                app.SaveChanges();

                num += markamend.xID;

                //if (command.Connection.State == ConnectionState.Open) { command.Connection.Close(); }
            }
            catch (Exception exception)
            {
                exception.ToString(); num = 0;
            }
            finally
            {

            }
            return num;
        }


        public int addXTransaction(XTransaction x)
        {
            string connectionString = Connect();
            int num = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO xtransactions (transactionID,xcode,ptype,amt,status,adminID) VALUES (@transactionID,@xcode,@ptype,@amt,@status,@adminID) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@transactionID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@xcode", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@ptype", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@amt", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@status", SqlDbType.NVarChar, 1);
            command.Parameters.Add("@adminID", SqlDbType.NVarChar, 50);
            command.Parameters["@transactionID"].Value = x.transactionID;
            command.Parameters["@xcode"].Value = x.xcode;
            command.Parameters["@ptype"].Value = x.ptype;
            command.Parameters["@amt"].Value = x.amt;
            command.Parameters["@status"].Value = x.status;
            command.Parameters["@adminID"].Value = x.adminID;
            num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }

        public int checkValidation(string id)
        {
            SqlConnection connection = new SqlConnection(Connect());
            connection.Open();
            SqlCommand command = new SqlCommand("sp_s_IsValid", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@id", id));
            SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            int num = (int)parameter.Value;
            connection.Close();
            return num;
        }

        public int CheckXTransactionID(string transactionID)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT ID FROM xtransactions WHERE transactionID='" + transactionID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["ID"].ToString());
            }
            reader.Close();
            return num;
        }

        public int deletePwallet(string id)
        {
            int del_succ = 0;
            string connectionString = Connect();           
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command= new SqlCommand("DELETE from pwallet where ID='" + id + "'", connection);
                connection.Open();
              del_succ=  command.ExecuteNonQuery();
                connection.Close();
                return del_succ;
        }

        public int deleteGPwallet(string id)
        {
            int del_succ = 0;
            string connectionString = Connect();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("DELETE from g_pwallet where ID='" + id + "'", connection);
            connection.Open();
            del_succ = command.ExecuteNonQuery();
            connection.Close();
            return del_succ;
        }

        public void cleanseTmByValidation(string serverpath, string vid)
        {
            string id = "0";
            string connectionString = Connect();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT * from pwallet where validationID='" + vid + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                reader["stage"].ToString();
                id = reader["ID"].ToString();
            }
            reader.Close();
            if (id != "0")
            {
                SqlConnection connection2 = new SqlConnection(connectionString);
                SqlCommand command2 = new SqlCommand("DELETE from pwallet where validationID='" + vid + "'", connection2);
                connection2.Open();
                command2.ExecuteNonQuery();
                connection2.Close();
                flushApplicant(id);
                flushMark_info(serverpath, id);
                flushAddress_service(id);
                flushRepresentative(id);
                flushAddress(id);
            }
        }

        public string Connect()
        {
            return ConfigurationManager.ConnectionStrings["cldConnectionString"].ConnectionString;
        }

        public void doDeleteDir(string serverpath, long markID)
        {
            if (markID > 0L)
            {
                string path = serverpath + "admin/tm/docz/" + markID.ToString() + "/";
                string str2 = serverpath + "admin/tm/Picz/" + markID.ToString() + "/";
                try
                {
                    if (Directory.Exists(path))
                    {
                        foreach (string str3 in Directory.GetFiles(path))
                        {
                            File.Delete(str3);
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    if (Directory.Exists(str2))
                    {
                        foreach (string str4 in Directory.GetFiles(str2))
                        {
                            File.Delete(str4);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public void doDeleteExcelDir(string filepath)
        {
            try
            {
                if (Directory.Exists(filepath))
                {
                    foreach (string str in Directory.GetFiles(filepath))
                    {
                        File.Delete(str);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public string doUploadDoc(string ID, string path, FileUpload fu)
        {
            try
            {
                if (!Directory.Exists(path + ID + "/"))
                {
                    Directory.CreateDirectory(path + ID + "/");
                }
                string str = Path.GetFileName(fu.FileName).Replace(" ", "_");
                fu.SaveAs(path + ID + "/" + str);
                return (path + ID + "/" + str);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string doUploadDocNoLimit(string ID, string path, FileUpload fu)
        {
            try
            {
                if (!Directory.Exists(path + ID + "/"))
                {
                    Directory.CreateDirectory(path + ID + "/");
                }
                string str = Path.GetFileName(fu.FileName).Replace(" ", "_");
                fu.SaveAs(path + ID + "/" + str);
                return (path + ID + "/" + str);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string doUploadExcelDoc(string ID, string path, FileUpload fu)
        {
            string str = "";
            string destFileName = "";
            try
            {
                if (!Directory.Exists(path + ID + "/"))
                {
                    Directory.CreateDirectory(path + ID + "/");
                }
                string filename = Path.GetFileName(fu.FileName).Replace(" ", "_");
                string str4 = getExtension(filename);
                if (str4 == "xls")
                {
                    fu.SaveAs(path + ID + "/" + filename);
                    str = DateTime.Now.TimeOfDay.ToString().Replace(".", "_").Replace(":", "+").Substring(0, 8);
                    destFileName = path + ID + "/" + str + "." + str4;
                    File.Move(path + ID + "/" + filename, destFileName);
                    return destFileName;
                }
                return "bformat";
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string doUploadPic(string ID, string newfilename, string path, FileUpload fu)
        {
            try
            {
                if (!Directory.Exists(path + ID + "/"))
                {
                    Directory.CreateDirectory(path + ID + "/");
                }
                newfilename = newfilename.Replace(" ", "_");
                fu.SaveAs(path + ID + "/" + newfilename);
                return (path + ID + "/" + newfilename);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string doUploadUpDoc(string ID, string path, string oldpath, FileUpload fu)
        {
            if (ID != "")
            {
                string filename = "";
                string str2 = Path.GetFileName(fu.FileName).Replace(" ", "_");
                filename = filename = path + ID + "/" + str2;
                try
                {
                    if (!Directory.Exists(path + ID + "/"))
                    {
                        Directory.CreateDirectory(path + ID + "/");
                    }
                    else if (File.Exists(oldpath))
                    {
                        File.Delete(oldpath);
                    }
                    fu.SaveAs(filename);
                }
                catch (Exception)
                {
                }
            }
            return "";
        }

        public int e_MarkInfoDocz(string logo_pic, string auth_doc, string sup_doc1, string sup_doc2, string mark_infoID)
        {
            SqlConnection connection = new SqlConnection(Connect());
            connection.Open();
            SqlCommand command = new SqlCommand("sp_u_MarkInfoWithDocz", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@logo_pic", logo_pic));
            command.Parameters.Add(new SqlParameter("@auth_doc", auth_doc));
            command.Parameters.Add(new SqlParameter("@sup_doc1", sup_doc1));
            command.Parameters.Add(new SqlParameter("@sup_doc2", sup_doc2));
            command.Parameters.Add(new SqlParameter("@ID", mark_infoID));
            SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            int num = (int)parameter.Value;
            connection.Close();
            return num;
        }

        public int e_MarkInfoRegNumber(string reg_number, string pwalletID)
        {
            SqlConnection connection = new SqlConnection(Connect());
            connection.Open();
            SqlCommand command = new SqlCommand("sp_u_MarkInfoRegNumber", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@reg_number", reg_number));
            command.Parameters.Add(new SqlParameter("@ID", pwalletID));
            SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            int num = (int)parameter.Value;
            connection.Close();
            return num;
        }

        public int e_markpwallet(string validationID, string agentID, string amt, string stage, string data_status)
        {
            string connectionString = Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            int num = 0;
            checkValidation(validationID);
            string str3 = "1";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_a_pwallet", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@validationID", validationID));
            command.Parameters.Add(new SqlParameter("@applicantID", agentID));
            command.Parameters.Add(new SqlParameter("@amt", amt));
            command.Parameters.Add(new SqlParameter("@stage", stage));
            command.Parameters.Add(new SqlParameter("@data_status", data_status));
            command.Parameters.Add(new SqlParameter("@reg_date", str2));
            command.Parameters.Add(new SqlParameter("@visible", str3));
            SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            num = (int)parameter.Value;
            connection.Close();
            return num;
        }

        public int e_pwallet(string validationID, string agentID, string amt, string stage, string data_status)
        {
            string connectionString = Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            int num = 0;
            if (checkValidation(validationID) > 0)
            {
                string str3 = getPwalletID(validationID);
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("sp_u_PwalletStage", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@id", str3));
                command.Parameters.Add(new SqlParameter("@applicantID", agentID));
                command.Parameters.Add(new SqlParameter("@amt", amt));
                command.Parameters.Add(new SqlParameter("@stage", stage));
                command.Parameters.Add(new SqlParameter("@data_status", data_status));
                SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                parameter.Direction = ParameterDirection.ReturnValue;
                command.ExecuteNonQuery();
                num = (int)parameter.Value;
                connection.Close();
                return num;
            }
            string str4 = "1";
            SqlConnection connection2 = new SqlConnection(connectionString);
            connection2.Open();
            SqlCommand command3 = new SqlCommand("sp_a_pwallet", connection2)
            {
                CommandType = CommandType.StoredProcedure
            };
            command3.Parameters.Add(new SqlParameter("@validationID", validationID));
            command3.Parameters.Add(new SqlParameter("@applicantID", agentID));
            command3.Parameters.Add(new SqlParameter("@amt", amt));
            command3.Parameters.Add(new SqlParameter("@stage", stage));
            command3.Parameters.Add(new SqlParameter("@data_status", data_status));
            command3.Parameters.Add(new SqlParameter("@reg_date", str2));
            command3.Parameters.Add(new SqlParameter("@visible", str4));
            SqlParameter parameter2 = command3.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter2.Direction = ParameterDirection.ReturnValue;
            command3.ExecuteNonQuery();
            num = (int)parameter2.Value;
            connection2.Close();
            return num;
        }

        public int e_PwalletStatus(string xID, string status, string data_status)
        {
            SqlConnection connection = new SqlConnection(Connect());
            connection.Open();
            SqlCommand command = new SqlCommand("sp_u_PwalletStatus", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@ID", xID));
            command.Parameters.Add(new SqlParameter("@status", status));
            command.Parameters.Add(new SqlParameter("@data_status", data_status));
            SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            int num = (int)parameter.Value;
            connection.Close();
            if (num > 0)
            {
                num = Convert.ToInt32(xID);
            }
            return num;
        }

        public int e_xscard(string id)
        {
            SqlConnection connection = new SqlConnection(Connect());
            connection.Open();
            SqlCommand command = new SqlCommand("sp_u_XScardStatus", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@id", id));
            SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            int num = (int)parameter.Value;
            connection.Close();
            return num;
        }

        public void flushAddress(string id)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("DELETE from address where log_staff='" + id + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void flushAddress_service(string id)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("DELETE from address_service where log_staff='" + id + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void flushAddress_serviceByID(string id)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("DELETE from address_service where ID='" + id + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void flushAddressByID(string id)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("DELETE from address where ID='" + id + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void flushApplicant(string id)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("DELETE from applicant where log_staff='" + id + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void flushApplicantByID(string id)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("DELETE from applicant where ID='" + id + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void flushMark_info(string serverpath, string id)
        {
            long markID = 0L;
            string connectionString = Connect();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT xID from mark_info where log_staff='" + id + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                markID = Convert.ToInt64(reader["xID"]);
            }
            reader.Close();
            SqlConnection connection2 = new SqlConnection(connectionString);
            SqlCommand command2 = new SqlCommand("DELETE from mark_info where log_staff='" + id + "'", connection2);
            connection2.Open();
            command2.ExecuteNonQuery();
            connection2.Close();
            if (markID > 0L)
            {
                doDeleteDir(serverpath, markID);
            }
        }

        public void flushMark_infoByID(string serverpath, string id)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("DELETE from mark_info where xID='" + id + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            if (Convert.ToInt64(id) > 0L)
            {
                doDeleteDir(serverpath, Convert.ToInt64(id));
            }
        }

        public void flushPwalletByID(string id)
        {
            string connectionString = Connect();
            if ((id != "0") && (id != ""))
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("DELETE from pwallet where ID='" + id + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void flushRepresentative(string id)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("DELETE from representative where log_staff='" + id + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void flushRepresentativeByID(string id)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("DELETE from representative where ID='" + id + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public string formatExcelDate(string date)
        {
            if ((date == "0") || (date == null))
            {
                date = DateTime.Today.Date.ToString("yyyy-MM-dd");
            }
            return date;
        }

        public List<Address> getAddressByID(string ID)
        {
            List<Address> list = new List<Address>();
            new Address();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM address WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Address item = new Address
                {
                    ID = Convert.ToInt64(reader["ID"]).ToString(),
                    countryID = reader["countryID"].ToString(),
                    stateID = reader["stateID"].ToString(),
                    lgaID = reader["lgaID"].ToString(),
                    city = reader["city"].ToString(),
                    street = reader["street"].ToString(),
                    zip = reader["zip"].ToString(),
                    telephone1 = reader["telephone1"].ToString(),
                    telephone2 = reader["telephone2"].ToString(),
                    email1 = reader["email1"].ToString(),
                    email2 = reader["email2"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public Address getAddressByID2(string ID)
        {
            List<Address> list = new List<Address>();
            new Address();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM address WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            Address item2 = new Address();
            while (reader.Read())
            {
                Address item = new Address
                {
                    ID = Convert.ToInt64(reader["ID"]).ToString(),
                    countryID = reader["countryID"].ToString(),
                    stateID = reader["stateID"].ToString(),
                    lgaID = reader["lgaID"].ToString(),
                    city = reader["city"].ToString(),
                    street = reader["street"].ToString(),
                    zip = reader["zip"].ToString(),
                    telephone1 = reader["telephone1"].ToString(),
                    telephone2 = reader["telephone2"].ToString(),
                    email1 = reader["email1"].ToString(),
                    email2 = reader["email2"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                item2 = item;
              //  list.Add(item);
            }
            reader.Close();
            return item2;
        }

        public Address getAddressByLog_staffID(string pwalletID)
        {
            Address address = new Address();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM address WHERE log_staff='" + pwalletID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                address.ID = reader["ID"].ToString();
                address.countryID = reader["countryID"].ToString();
                address.stateID = reader["stateID"].ToString();
                address.lgaID = reader["lgaID"].ToString();
                address.city = reader["city"].ToString();
                address.street = reader["street"].ToString();
                address.zip = reader["zip"].ToString();
                address.telephone1 = reader["telephone1"].ToString();
                address.telephone2 = reader["telephone2"].ToString();
                address.email1 = reader["email1"].ToString();
                address.email2 = reader["email2"].ToString();
                address.zip = reader["zip"].ToString();
                address.log_staff = reader["log_staff"].ToString();
                address.reg_date = reader["reg_date"].ToString();
                address.visible = reader["visible"].ToString();
            }
            reader.Close();
            return address;
        }

        public Address getAddressClassByID(string ID)
        {
            Address address = new Address
            {
                ID = Convert.ToInt64("0").ToString(),
                countryID = "",
                stateID = "",
                lgaID = "",
                city = "",
                street = "",
                telephone1 = "",
                telephone2 = "",
                email1 = "",
                email2 = "",
                zip = "",
                log_staff = "",
                reg_date = "",
                visible = ""
            };
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM address WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                address.ID = Convert.ToInt64(reader["ID"]).ToString();
                address.countryID = reader["countryID"].ToString();
                address.stateID = reader["stateID"].ToString();
                address.lgaID = reader["lgaID"].ToString();
                address.city = reader["city"].ToString();
                address.street = reader["street"].ToString();
                address.zip = reader["zip"].ToString();
                address.telephone1 = reader["telephone1"].ToString();
                address.telephone2 = reader["telephone2"].ToString();
                address.email1 = reader["email1"].ToString();
                address.email2 = reader["email2"].ToString();
                address.zip = reader["zip"].ToString();
                address.log_staff = reader["log_staff"].ToString();
                address.reg_date = reader["reg_date"].ToString();
                address.visible = reader["visible"].ToString();
            }
            reader.Close();
            return address;
        }


        public Address getAddressClassByID2(string ID)
        {
            Address address = new Address
            {
                ID = Convert.ToInt64("0").ToString(),
                countryID = "",
                stateID = "",
                lgaID = "",
                city = "",
                street = "",
                telephone1 = "",
                telephone2 = "",
                email1 = "",
                email2 = "",
                zip = "",
                log_staff = "",
                reg_date = "",
                visible = ""
            };
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM addressAmendment WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                address.ID = Convert.ToInt64(reader["ID"]).ToString();
                address.countryID = reader["countryID"].ToString();
                address.stateID = reader["stateID"].ToString();
                address.lgaID = reader["lgaID"].ToString();
                address.city = reader["city"].ToString();
                address.street = reader["street"].ToString();
                address.zip = reader["zip"].ToString();
                address.telephone1 = reader["telephone1"].ToString();
                address.telephone2 = reader["telephone2"].ToString();
                address.email1 = reader["email1"].ToString();
                address.email2 = reader["email2"].ToString();
                address.zip = reader["zip"].ToString();
                address.log_staff = reader["log_staff"].ToString();
                address.reg_date = reader["reg_date"].ToString();
                address.visible = reader["visible"].ToString();
            }
            reader.Close();
            return address;
        }

        public List<Address> getAddressListByID(string ID)
        {
            List<Address> list = new List<Address>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM address WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Address item = new Address
                {
                    ID = reader["ID"].ToString(),
                    countryID = reader["countryID"].ToString(),
                    stateID = reader["stateID"].ToString(),
                    lgaID = reader["lgaID"].ToString(),
                    city = reader["city"].ToString(),
                    street = reader["street"].ToString(),
                    zip = reader["zip"].ToString(),
                    telephone1 = reader["telephone1"].ToString(),
                    telephone2 = reader["telephone2"].ToString(),
                    email1 = reader["email1"].ToString(),
                    email2 = reader["email2"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public Address getAddressListByID2(string ID)
        {
            List<Address> list = new List<Address>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM address WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            Address item2 = new Address();
            while (reader.Read())
            {
                Address item = new Address
                {
                    ID = reader["ID"].ToString(),
                    countryID = reader["countryID"].ToString(),
                    stateID = reader["stateID"].ToString(),
                    lgaID = reader["lgaID"].ToString(),
                    city = reader["city"].ToString(),
                    street = reader["street"].ToString(),
                    zip = reader["zip"].ToString(),
                    telephone1 = reader["telephone1"].ToString(),
                    telephone2 = reader["telephone2"].ToString(),
                    email1 = reader["email1"].ToString(),
                    email2 = reader["email2"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                item2 = item;
               // list.Add(item);
            }
            reader.Close();
            return item2;
        }

        public List<Address> getAddressListByValidationID(string log_staff)
        {
            List<Address> list = new List<Address>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM address WHERE log_staff='" + log_staff + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Address item = new Address
                {
                    ID = reader["ID"].ToString(),
                    countryID = reader["countryID"].ToString(),
                    stateID = reader["stateID"].ToString(),
                    lgaID = reader["lgaID"].ToString(),
                    city = reader["city"].ToString(),
                    street = reader["street"].ToString(),
                    zip = reader["zip"].ToString(),
                    telephone1 = reader["telephone1"].ToString(),
                    telephone2 = reader["telephone2"].ToString(),
                    email1 = reader["email1"].ToString(),
                    email2 = reader["email2"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public AddressService getAddressServiceByID(string ID)
        {
            AddressService service = new AddressService
            {
                ID = Convert.ToInt64("0").ToString(),
                countryID = "",
                stateID = "",
                lgaID = "",
                city = "",
                street = "",
                zip = "",
                telephone1 = "",
                telephone2 = "",
                email1 = "",
                email2 = "",
                log_staff = "",
                reg_date = "",
                visible = ""
            };
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM address_service WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                service.ID = Convert.ToInt64(reader["ID"]).ToString();
                service.countryID = reader["countryID"].ToString();
                service.stateID = reader["stateID"].ToString();
                service.lgaID = reader["lgaID"].ToString();
                service.city = reader["city"].ToString();
                service.street = reader["street"].ToString();
                service.zip = reader["zip"].ToString();
                service.telephone1 = reader["telephone1"].ToString();
                service.telephone2 = reader["telephone2"].ToString();
                service.email1 = reader["email1"].ToString();
                service.email2 = reader["email2"].ToString();
                service.zip = reader["zip"].ToString();
                service.log_staff = reader["log_staff"].ToString();
                service.reg_date = reader["reg_date"].ToString();
                service.visible = reader["visible"].ToString();
            }
            reader.Close();
            return service;
        }

        public AppealUpload getAppealRefusal(string ID)
        {
            AppealUpload service = new AppealUpload();
              SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM AppealRejection WHERE Id='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                service.id = Convert.ToInt32((reader["ID"]).ToString());
                service.DocumentId = reader["DocumentId"].ToString();
                service.RegId = reader["RegId"].ToString();
                service.Comment = reader["Comment"].ToString();
                service.agentid = reader["agentid"].ToString();
                service.DateUploaded = reader["DateUploaded"].ToString();
                service.FilePath = reader["FilePath"].ToString();
                service.Status = reader["Status"].ToString();
                service.ApproveBy = reader["ApproveBy"].ToString();
                service.DateApproved = reader["DateApproved"].ToString();
               
            }
            reader.Close();
            return service;
        }

        public AddressService getAddressServiceByID2(string ID)
        {
            AddressService service = new AddressService
            {
                ID = Convert.ToInt64("0").ToString(),
                countryID = "",
                stateID = "",
                lgaID = "",
                city = "",
                street = "",
                zip = "",
                telephone1 = "",
                telephone2 = "",
                email1 = "",
                email2 = "",
                log_staff = "",
                reg_date = "",
                visible = ""
            };
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM address_serviceAmendment WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                service.ID = Convert.ToInt64(reader["ID"]).ToString();
                service.countryID = reader["countryID"].ToString();
                service.stateID = reader["stateID"].ToString();
                service.lgaID = reader["lgaID"].ToString();
                service.city = reader["city"].ToString();
                service.street = reader["street"].ToString();
                service.zip = reader["zip"].ToString();
                service.telephone1 = reader["telephone1"].ToString();
                service.telephone2 = reader["telephone2"].ToString();
                service.email1 = reader["email1"].ToString();
                service.email2 = reader["email2"].ToString();
                service.zip = reader["zip"].ToString();
                service.log_staff = reader["log_staff"].ToString();
                service.reg_date = reader["reg_date"].ToString();
                service.visible = reader["visible"].ToString();
            }
            reader.Close();
            return service;
        }

        public List<AddressService> getAddressServiceListByID(string ID)
        {
            List<AddressService> list = new List<AddressService>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM address_service WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                AddressService item = new AddressService
                {
                    ID = Convert.ToInt64(reader["ID"]).ToString(),
                    countryID = reader["countryID"].ToString(),
                    stateID = reader["stateID"].ToString(),
                    lgaID = reader["lgaID"].ToString(),
                    city = reader["city"].ToString(),
                    street = reader["street"].ToString(),
                    zip = reader["zip"].ToString(),
                    telephone1 = reader["telephone1"].ToString(),
                    telephone2 = reader["telephone2"].ToString(),
                    email1 = reader["email1"].ToString(),
                    email2 = reader["email2"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool getAdminExtension(string filename)
        {
            string str = "";
            bool flag = false;
            int num = filename.LastIndexOf(".");
            str = filename.Substring(num + 1);
            if (((!(str == "pdf") && !(str == "jpg")) && (!(str == "jpeg") && !(str == "PDF"))) && (!(str == "JPG") && !(str == "JPEG")))
            {
                return flag;
            }
            return true;
        }

        public string getAgentEmail1ByID(string ID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT email1 FROM address WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["email1"].ToString();
            }
            reader.Close();
            return str;
        }

        public string getAgentTelephone1ByID(string ID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT telephone1 FROM address WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["telephone1"].ToString();
            }
            reader.Close();
            return str;
        }

        public List<Applicant> getApplicantByRefID(string ID)
        {
            List<Applicant> list = new List<Applicant>();
            new Applicant();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("select * from applicant where log_staff IN (select ID from pwallet where validationID='" + ID + "'') ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Applicant item = new Applicant
                {
                    ID = reader["ID"].ToString(),
                    xtype = reader["xtype"].ToString(),
                    xname = reader["xname"].ToString(),
                    tax_id_type = reader["tax_id_type"].ToString(),
                    tax_id_number = reader["tax_id_number"].ToString(),
                    individual_id_number = reader["individual_id_number"].ToString(),
                    nationality = reader["nationality"].ToString(),
                    addressID = reader["addressID"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public Applicant getApplicantByUserID(string ID)
        {
            Applicant applicant = new Applicant
            {
                ID = "",
                xtype = "",
                xname = "",
                tax_id_type = "",
                tax_id_number = "",
                individual_id_number = "",
                nationality = "",
                addressID = "",
                log_staff = "",
                reg_date = "",
                visible = ""
            };
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM applicant WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                applicant.ID = reader["ID"].ToString();
                applicant.xtype = reader["xtype"].ToString();
                applicant.xname = reader["xname"].ToString();
                applicant.tax_id_type = reader["tax_id_type"].ToString();
                applicant.tax_id_number = reader["tax_id_number"].ToString();
                applicant.individual_id_number = reader["individual_id_number"].ToString();
                applicant.nationality = reader["nationality"].ToString();
                applicant.addressID = reader["addressID"].ToString();
                applicant.log_staff = reader["log_staff"].ToString();
                applicant.reg_date = reader["reg_date"].ToString();
                applicant.visible = reader["visible"].ToString();
            }
            reader.Close();
            return applicant;
        }


        public Applicant getApplicantByUserID2(string ID)
        {
            Applicant applicant = new Applicant
            {
                ID = "",
                xtype = "",
                xname = "",
                tax_id_type = "",
                tax_id_number = "",
                individual_id_number = "",
                nationality = "",
                addressID = "",
                log_staff = "",
                reg_date = "",
                visible = ""
            };
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM applicantAmendment WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                applicant.ID = reader["ID"].ToString();
                applicant.xtype = reader["xtype"].ToString();
                applicant.xname = reader["xname"].ToString();
                applicant.tax_id_type = reader["tax_id_type"].ToString();
                applicant.tax_id_number = reader["tax_id_number"].ToString();
                applicant.individual_id_number = reader["individual_id_number"].ToString();
                applicant.nationality = reader["nationality"].ToString();
                applicant.addressID = reader["addressID"].ToString();
                applicant.log_staff = reader["log_staff"].ToString();
                applicant.reg_date = reader["reg_date"].ToString();
                applicant.visible = reader["visible"].ToString();
            }
            reader.Close();
            return applicant;
        }

        public List<Applicant> getApplicantByvalidationID(string validationID)
        {
            List<Applicant> list = new List<Applicant>();
            new Applicant();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM applicant WHERE log_staff='" + validationID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Applicant item = new Applicant
                {
                    ID = reader["ID"].ToString(),
                    xtype = reader["xtype"].ToString(),
                    xname = reader["xname"].ToString(),
                    tax_id_type = reader["tax_id_type"].ToString(),
                    tax_id_number = reader["tax_id_number"].ToString(),
                    individual_id_number = reader["individual_id_number"].ToString(),
                    nationality = reader["nationality"].ToString(),
                    addressID = reader["addressID"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public Applicant getApplicantClassByID(string pwalletID)
        {
            Applicant applicant = new Applicant();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM applicant WHERE log_staff='" + pwalletID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                applicant.ID = reader["ID"].ToString();
                applicant.xtype = reader["xtype"].ToString();
                applicant.xname = reader["xname"].ToString();
                applicant.tax_id_type = reader["tax_id_type"].ToString();
                applicant.tax_id_number = reader["tax_id_number"].ToString();
                applicant.individual_id_number = reader["individual_id_number"].ToString();
                applicant.nationality = reader["nationality"].ToString();
                applicant.addressID = reader["addressID"].ToString();
                applicant.log_staff = reader["log_staff"].ToString();
                applicant.reg_date = reader["reg_date"].ToString();
                applicant.visible = reader["visible"].ToString();
            }
            reader.Close();
            return applicant;
        }


        public Applicant getApplicantClassByID2(string pwalletID)
        {
            Applicant applicant = new Applicant();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM applicantAmendment WHERE log_staff='" + pwalletID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                applicant.ID = reader["ID"].ToString();
                applicant.xtype = reader["xtype"].ToString();
                applicant.xname = reader["xname"].ToString();
                applicant.tax_id_type = reader["tax_id_type"].ToString();
                applicant.tax_id_number = reader["tax_id_number"].ToString();
                applicant.individual_id_number = reader["individual_id_number"].ToString();
                applicant.nationality = reader["nationality"].ToString();
                applicant.addressID = reader["addressID"].ToString();
                applicant.log_staff = reader["log_staff"].ToString();
                applicant.reg_date = reader["reg_date"].ToString();
                applicant.visible = reader["visible"].ToString();
            }
            reader.Close();
            return applicant;
        }


        public Certificate getCertByID(string pwalletID)
        {
            Certificate applicant = new Certificate();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM cert_info WHERE log_staff='" + pwalletID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                applicant.Pub_Date = reader["pub_date"].ToString();
                applicant.Pub_Details= reader["pub_details"].ToString();
                applicant.Pub_Doc = reader["pub_doc"].ToString();
              
            }
            reader.Close();
            return applicant;
        }

        public List<Applicant> getApplicantListByUserID(string ID)
        {
            List<Applicant> list = new List<Applicant>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM applicant WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Applicant item = new Applicant
                {
                    ID = reader["ID"].ToString(),
                    xtype = reader["xtype"].ToString(),
                    xname = reader["xname"].ToString(),
                    tax_id_type = reader["tax_id_type"].ToString(),
                    tax_id_number = reader["tax_id_number"].ToString(),
                    individual_id_number = reader["individual_id_number"].ToString(),
                    nationality = reader["nationality"].ToString(),
                    addressID = reader["addressID"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }


        public Applicant getApplicantListByUserID2(string ID)
        {
            List<Applicant> list = new List<Applicant>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM applicant WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            Applicant item2 = new Applicant();
            while (reader.Read())
            {
                Applicant item = new Applicant
                {
                    ID = reader["ID"].ToString(),
                    xtype = reader["xtype"].ToString(),
                    xname = reader["xname"].ToString(),
                    tax_id_type = reader["tax_id_type"].ToString(),
                    tax_id_number = reader["tax_id_number"].ToString(),
                    individual_id_number = reader["individual_id_number"].ToString(),
                    nationality = reader["nationality"].ToString(),
                    addressID = reader["addressID"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                item2 = item;
              //  list.Add(item);
            }
            reader.Close();
            return item2;
        }

        public string getCheckStatusDetails(string validationID, string agentID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT ID FROM pwallet WHERE validationID='" + validationID + "'  AND applicantID='" + agentID + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = Convert.ToInt64(reader["ID"]).ToString();
            }
            reader.Close();
            return str;
        }


        public string getCheckStatusDetails2(string validationID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
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

        public string getCheckStatusDetails3(string validationID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT log_staff  FROM mark_info  WHERE xID='" + validationID + "'  ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = Convert.ToInt64(reader["log_staff"]).ToString();
            }
            reader.Close();
            return str;
        }


        public int getCheckTransactionID(string transactionID, string amt, string ptype, string xcode)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT ID FROM xtransactions WHERE transactionID='" + transactionID + "' AND amt='" + amt + "' AND ptype='" + ptype + "' AND xcode='" + xcode + "'  AND status='0' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["ID"].ToString());
            }
            reader.Close();
            return num;
        }

        public string getClientNumber()
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            string cmdText = "SELECT TOP 1 ID,pin FROM xscard where usedstatus='0'";
            SqlCommand command = new SqlCommand(cmdText, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["ID"].ToString() + "_" + reader["pin"].ToString();
            }
            reader.Close();
            return str;
        }

        public List<Country> getCountry()
        {
            List<Country> list = new List<Country>();
            new Country();
            SqlConnection connection = new SqlConnection(Connect());
            string cmdText = "SELECT * FROM country";
            SqlCommand command = new SqlCommand(cmdText, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Country item = new Country
                {
                    ID = Convert.ToInt64(reader["ID"]).ToString(),
                    name = reader["name"].ToString(),
                    code = reader["code"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public string getCountryIDByCode(string code)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT ID FROM country WHERE code='" + code + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["ID"].ToString();
            }
            reader.Close();
            return str;
        }

        public string getCountryIDByName(string name)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT ID FROM country WHERE name='" + name + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["ID"].ToString();
            }
            reader.Close();
            return str;
        }

        public string getCountryName(string ID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT name FROM country WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["name"].ToString();
            }
            reader.Close();
            return str;
        }

        public string getExtension(string filename)
        {
            int num = filename.LastIndexOf(".");
            return filename.Substring(num + 1);
        }

        public string getFormattedAddressByID(string ID)
        {
            Address address = new Address();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM address WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                address.ID = reader["ID"].ToString();
                address.countryID = reader["countryID"].ToString();
                address.stateID = reader["stateID"].ToString();
                address.lgaID = reader["lgaID"].ToString();
                address.city = reader["city"].ToString();
                address.street = reader["street"].ToString();
                address.zip = reader["zip"].ToString();
                address.telephone1 = reader["telephone1"].ToString();
                address.telephone2 = reader["telephone2"].ToString();
                address.email1 = reader["email1"].ToString();
                address.email2 = reader["email2"].ToString();
                address.log_staff = reader["log_staff"].ToString();
                address.reg_date = reader["reg_date"].ToString();
                address.visible = reader["visible"].ToString();
            }
            reader.Close();
            if (((address.stateID != null) || (address.stateID != "0")) || (address.stateID != ""))
            {
                if (address.countryID != "160")
                {
                    return (address.street + "," + getCountryName(address.countryID));
                }
                return (address.street + "," + getStateName(address.stateID) + "," + getCountryName(address.countryID));
            }
            return (address.street + "," + getCountryName(address.countryID));
        }

        public List<Stage> getG_StageByUserIDAcc(string validationID, string agentID)
        {
            List<Stage> list = new List<Stage>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_pwallet WHERE validationID='" + validationID + "'  AND applicantID='" + agentID + "'  AND data_status <>'' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Stage item = new Stage
                {
                    ID = reader["ID"].ToString(),
                    applicantID = reader["applicantID"].ToString(),
                    validationID = reader["validationID"].ToString(),
                    stage = reader["stage"].ToString(),
                    status = reader["status"].ToString(),
                    data_status = reader["data_status"].ToString(),
                    amt = reader["amt"].ToString(),
                    reg_date = reader["reg_date"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<Stage> getG_StageByValidationID(string validationID)
        {
            List<Stage> list = new List<Stage>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_pwallet WHERE validationID='" + validationID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Stage item = new Stage
                {
                    ID = reader["ID"].ToString(),
                    applicantID = reader["applicantID"].ToString(),
                    validationID = reader["validationID"].ToString(),
                    stage = reader["stage"].ToString(),
                    status = reader["status"].ToString(),
                    data_status = reader["data_status"].ToString(),
                    amt = reader["amt"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    log_officer = reader["log_officer"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<NClass> getJNationalClasses()
        {
            List<NClass> list = new List<NClass>();
            new NClass();
            SqlConnection connection = new SqlConnection(Connect());
            string cmdText = "SELECT xID,type,description FROM national_classes";
            SqlCommand command = new SqlCommand(cmdText, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                NClass item = new NClass
                {
                    xID = Convert.ToInt64(reader["xID"]).ToString(),
                    xtype = reader["type"].ToString(),
                    xdescription = reader["description"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public int getLastRtm()
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT rtm from pwallet ORDER by ID DESC ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["rtm"]);
            }
            reader.Close();
            return num;
        }

        public List<Lga> getLga()
        {
            List<Lga> list = new List<Lga>();
            new Lga();
            SqlConnection connection = new SqlConnection(Connect());
            string cmdText = "SELECT * FROM lga";
            SqlCommand command = new SqlCommand(cmdText, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Lga item = new Lga
                {
                    ID = Convert.ToInt64(reader["ID"]).ToString(),
                    name = reader["name"].ToString(),
                    stateID = reader["stateID"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public string getLogoDescriptionID(string name)
        {
            if (name == "NAME AND DEVICE")
            {
                name = "WORD AND DEVICE";
            }
            if ((name == "MARK NAME") || (name == "MARK ONLY"))
            {
                name = "WORD MARK";
            }
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT xID from logo_description where type='" + name + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["xID"].ToString();
            }
            reader.Close();
            return str;
        }

        public string getLogoDescriptionName(string id)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT type from logo_description where xID='" + id + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["type"].ToString();
            }
            reader.Close();
            return str;
        }

        public List<MarkInfo> getMarkInfoByUserID(string ID)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM mark_info WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                MarkInfo item = new MarkInfo
                {
                    xID = reader["xID"].ToString(),
                    reg_number = reader["reg_number"].ToString(),
                    tm_typeID = reader["tm_typeID"].ToString(),
                    logo_descriptionID = reader["logo_descriptionID"].ToString(),
                    national_classID = reader["national_classID"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    nice_class = reader["nice_class"].ToString(),
                    nice_class_desc = reader["nice_class_desc"].ToString(),
                    sign_type = reader["sign_type"].ToString(),
                    vienna_class = reader["vienna_class"].ToString(),
                    disclaimer = reader["disclaimer"].ToString(),
                    logo_pic = reader["logo_pic"].ToString(),
                    auth_doc = reader["auth_doc"].ToString(),
                    sup_doc1 = reader["sup_doc1"].ToString(),
                    sup_doc2 = reader["sup_doc2"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    xvisible = reader["xvisible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public MarkInfo getMarkInfoClassByUserID(string ID)
        {
            MarkInfo info = new MarkInfo();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM mark_info WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                info.xID = reader["xID"].ToString();
                info.reg_number = reader["reg_number"].ToString();
                info.tm_typeID = reader["tm_typeID"].ToString();
                info.logo_descriptionID = reader["logo_descriptionID"].ToString();
                info.national_classID = reader["national_classID"].ToString();
                info.product_title = reader["product_title"].ToString();
                info.nice_class = reader["nice_class"].ToString();
                info.nice_class_desc = reader["nice_class_desc"].ToString();
                info.sign_type = reader["sign_type"].ToString();
                info.vienna_class = reader["vienna_class"].ToString();
                info.disclaimer = reader["disclaimer"].ToString();
                info.logo_pic = reader["logo_pic"].ToString();
                info.auth_doc = reader["auth_doc"].ToString();
                info.sup_doc1 = reader["sup_doc1"].ToString();
                info.sup_doc2 = reader["sup_doc2"].ToString();
                info.log_staff = reader["log_staff"].ToString();
                info.reg_date = reader["reg_date"].ToString();
                info.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            return info;
        }

        public MarkInfo getMarkInfoClassByUserID3(string ID)
        {
            MarkInfo info = new MarkInfo();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM mark_infoAmendment WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                info.xID = reader["xID"].ToString();
                info.reg_number = reader["reg_number"].ToString();
                info.tm_typeID = reader["tm_typeID"].ToString();
                info.logo_descriptionID = reader["logo_descriptionID"].ToString();
                info.national_classID = reader["national_classID"].ToString();
                info.product_title = reader["product_title"].ToString();
                info.nice_class = reader["nice_class"].ToString();
                info.nice_class_desc = reader["nice_class_desc"].ToString();
                info.sign_type = reader["sign_type"].ToString();
                info.vienna_class = reader["vienna_class"].ToString();
                info.disclaimer = reader["disclaimer"].ToString();
                info.logo_pic = reader["logo_pic"].ToString();
                info.auth_doc = reader["auth_doc"].ToString();
                info.sup_doc1 = reader["sup_doc1"].ToString();
                info.sup_doc2 = reader["sup_doc2"].ToString();
                info.log_staff = reader["log_staff"].ToString();
                info.reg_date = reader["reg_date"].ToString();
                info.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            return info;
        }

        public MarkInfo getMarkInfoClassByUserID2(string ID)
        {
            MarkInfo info = new MarkInfo();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM mark_info WHERE xID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                info.xID = reader["xID"].ToString();
                info.reg_number = reader["reg_number"].ToString();
                info.tm_typeID = reader["tm_typeID"].ToString();
                info.logo_descriptionID = reader["logo_descriptionID"].ToString();
                info.national_classID = reader["national_classID"].ToString();
                info.product_title = reader["product_title"].ToString();
                info.nice_class = reader["nice_class"].ToString();
                info.nice_class_desc = reader["nice_class_desc"].ToString();
                info.sign_type = reader["sign_type"].ToString();
                info.vienna_class = reader["vienna_class"].ToString();
                info.disclaimer = reader["disclaimer"].ToString();
                info.logo_pic = reader["logo_pic"].ToString();
                info.auth_doc = reader["auth_doc"].ToString();
                info.sup_doc1 = reader["sup_doc1"].ToString();
                info.sup_doc2 = reader["sup_doc2"].ToString();
                info.log_staff = reader["log_staff"].ToString();
                info.reg_date = reader["reg_date"].ToString();
                info.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            return info;
        }

        public string getMarkPwalletID(string validationID, string agentID, string amt, string stage, string data_status)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT ID FROM pwallet WHERE validationID='" + validationID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = Convert.ToInt64(reader["ID"]).ToString();
            }
            reader.Close();
            if (str == "")
            {
                str = e_markpwallet(validationID, agentID, amt, stage, data_status).ToString();
            }
            return str;
        }

        public string getNationalClassDesc(string id)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT description from national_classes where xID='" + id + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["description"].ToString();
            }
            reader.Close();
            return str;
        }

        public string getNationalClassDesc2(string id)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT description from national_classes where type='" + id + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["description"].ToString();
            }
            reader.Close();
            return str;
        }

        public Stage getNewStatusIDByValidationID(string validationID, string log_officer)
        {
            Stage stage = new Stage();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE validationID='" + validationID + "' AND log_officer='" + log_officer + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                stage.status = reader["status"].ToString();
                stage.stage = reader["stage"].ToString();
                stage.applicantID = reader["applicantID"].ToString();
            }
            reader.Close();
            return stage;
        }

        public string getPwalletID(string validationID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT ID FROM pwallet WHERE validationID='" + validationID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = Convert.ToInt64(reader["ID"]).ToString();
            }
            reader.Close();
            return str;
        }

        public Representative getRepByUserID(string ID)
        {
            Representative representative = new Representative
            {
                ID = "",
                agent_code = "",
                xname = "",
                individual_id_type = "",
                individual_id_number = "",
                nationality = "",
                addressID = "",
                log_staff = "",
                reg_date = "",
                visible = ""
            };
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM representative WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                representative.ID = reader["ID"].ToString();
                representative.agent_code = reader["agent_code"].ToString();
                representative.xname = reader["xname"].ToString();
                representative.individual_id_type = reader["individual_id_type"].ToString();
                representative.individual_id_number = reader["individual_id_number"].ToString();
                representative.nationality = reader["nationality"].ToString();
                representative.addressID = reader["addressID"].ToString();
                representative.log_staff = reader["log_staff"].ToString();
                representative.reg_date = reader["reg_date"].ToString();
                representative.visible = reader["visible"].ToString();
            }
            reader.Close();
            return representative;
        }

        public Representative getRepByUserID2(string ID)
        {
            Representative representative = new Representative
            {
                ID = "",
                agent_code = "",
                xname = "",
                individual_id_type = "",
                individual_id_number = "",
                nationality = "",
                addressID = "",
                log_staff = "",
                reg_date = "",
                visible = ""
            };
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM representativeAmendment WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                representative.ID = reader["ID"].ToString();
                representative.agent_code = reader["agent_code"].ToString();
                representative.xname = reader["xname"].ToString();
                representative.individual_id_type = reader["individual_id_type"].ToString();
                representative.individual_id_number = reader["individual_id_number"].ToString();
                representative.nationality = reader["nationality"].ToString();
                representative.addressID = reader["addressID"].ToString();
                representative.log_staff = reader["log_staff"].ToString();
                representative.reg_date = reader["reg_date"].ToString();
                representative.visible = reader["visible"].ToString();
            }
            reader.Close();
            return representative;
        }

        public Representative getRepClassByUserID(string ID)
        {
            Representative representative = new Representative();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM representative WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                representative.ID = reader["ID"].ToString();
                representative.agent_code = reader["agent_code"].ToString();
                representative.xname = reader["xname"].ToString();
                representative.individual_id_type = reader["individual_id_type"].ToString();
                representative.individual_id_number = reader["individual_id_number"].ToString();
                representative.nationality = reader["nationality"].ToString();
                representative.addressID = reader["addressID"].ToString();
                representative.log_staff = reader["log_staff"].ToString();
                representative.reg_date = reader["reg_date"].ToString();
                representative.visible = reader["visible"].ToString();
            }
            reader.Close();
            return representative;
        }

        public Representative getRepClassByUserID2(string ID)
        {
            Representative representative = new Representative();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM representativeAmendment WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                representative.ID = reader["ID"].ToString();
                representative.agent_code = reader["agent_code"].ToString();
                representative.xname = reader["xname"].ToString();
                representative.individual_id_type = reader["individual_id_type"].ToString();
                representative.individual_id_number = reader["individual_id_number"].ToString();
                representative.nationality = reader["nationality"].ToString();
                representative.addressID = reader["addressID"].ToString();
                representative.log_staff = reader["log_staff"].ToString();
                representative.reg_date = reader["reg_date"].ToString();
                representative.visible = reader["visible"].ToString();
            }
            reader.Close();
            return representative;
        }

        public List<Representative> getRepListByUserID(string ID)
        {
            List<Representative> list = new List<Representative>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM representative WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Representative item = new Representative
                {
                    ID = reader["ID"].ToString(),
                    agent_code = reader["agent_code"].ToString(),
                    xname = reader["xname"].ToString(),
                    individual_id_type = reader["individual_id_type"].ToString(),
                    individual_id_number = reader["individual_id_number"].ToString(),
                    nationality = reader["nationality"].ToString(),
                    addressID = reader["addressID"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public Representative getRepListByUserID2(string ID)
        {
            List<Representative> list = new List<Representative>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM representative WHERE log_staff='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            Representative item2 = new Representative();
            while (reader.Read())
            {
                Representative item = new Representative
                {
                    ID = reader["ID"].ToString(),
                    agent_code = reader["agent_code"].ToString(),
                    xname = reader["xname"].ToString(),
                    individual_id_type = reader["individual_id_type"].ToString(),
                    individual_id_number = reader["individual_id_number"].ToString(),
                    nationality = reader["nationality"].ToString(),
                    addressID = reader["addressID"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                item2 = item;
                //list.Add(item);
            }
            reader.Close();
            return item2;
        }

        public Stage getStageBy_G_ValidationID(string validationID)
        {
            Stage stage = new Stage();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_pwallet WHERE validationID='" + validationID + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                stage.ID = reader["ID"].ToString();
                stage.status = reader["status"].ToString();
                stage.stage = reader["stage"].ToString();
                stage.applicantID = reader["applicantID"].ToString();
            }
            reader.Close();
            return stage;
        }

        public List<Stage> getStageByClientIDAcc(string validationID)
        {
            List<Stage> list = new List<Stage>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE validationID='" + validationID + "'  AND data_status <>'' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Stage stage = new Stage();               
                stage.ID = reader["ID"].ToString();
                stage.applicantID = reader["applicantID"].ToString();
                stage.validationID = reader["validationID"].ToString();
                stage.log_officer = reader["log_officer"].ToString();
                stage.amt = reader["amt"].ToString();
                stage.stage = reader["stage"].ToString();
                stage.status = reader["status"].ToString();
                stage.data_status = reader["data_status"].ToString();
                stage.reg_date = reader["reg_date"].ToString();
                stage.visible = reader["visible"].ToString();
                stage.xtime = reader["xtime"].ToString();
                stage.rtm = reader["rtm"].ToString();
                stage.acc_p = reader["acc_p"].ToString();
                list.Add(stage);
            }
            reader.Close();
            return list;
        }

        public List<Stage> getStageByUserID(string ID)
        {
            List<Stage> list = new List<Stage>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Stage stage = new Stage();
                stage.ID = reader["ID"].ToString();
                stage.applicantID = reader["applicantID"].ToString();
                stage.validationID = reader["validationID"].ToString();
                stage.log_officer = reader["log_officer"].ToString();
                stage.amt = reader["amt"].ToString();
                stage.stage = reader["stage"].ToString();
                stage.status = reader["status"].ToString();
                stage.data_status = reader["data_status"].ToString();
                stage.reg_date = reader["reg_date"].ToString();
                stage.visible = reader["visible"].ToString();
                stage.xtime = reader["xtime"].ToString();
                stage.rtm = reader["rtm"].ToString();
                stage.acc_p = reader["acc_p"].ToString();
                list.Add(stage);
            }
            reader.Close();
            return list;
        }

        public List<Stage> getStageByUserIDAcc(string validationID, string agentID)
        {
            List<Stage> list = new List<Stage>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE validationID='" + validationID + "'  AND applicantID='" + agentID + "'  AND data_status <>'' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Stage stage = new Stage();
                stage.ID = reader["ID"].ToString();
                stage.applicantID = reader["applicantID"].ToString();
                stage.validationID = reader["validationID"].ToString();
                stage.log_officer = reader["log_officer"].ToString();
                stage.amt = reader["amt"].ToString();
                stage.stage = reader["stage"].ToString();
                stage.status = reader["status"].ToString();
                stage.data_status = reader["data_status"].ToString();
                stage.reg_date = reader["reg_date"].ToString();
                stage.visible = reader["visible"].ToString();
                stage.xtime = reader["xtime"].ToString();
                stage.rtm = reader["rtm"].ToString();
                stage.acc_p = reader["acc_p"].ToString();
                list.Add(stage);
            }
            reader.Close();
            return list;
        }

        public List<Stage> getStageByValidationID(string validationID)
        {
            List<Stage> list = new List<Stage>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE validationID='" + validationID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Stage stage = new Stage();
                stage.ID = reader["ID"].ToString();
                stage.applicantID = reader["applicantID"].ToString();
                stage.validationID = reader["validationID"].ToString();
                stage.log_officer = reader["log_officer"].ToString();
                stage.amt = reader["amt"].ToString();
                stage.stage = reader["stage"].ToString();
                stage.status = reader["status"].ToString();
                stage.data_status = reader["data_status"].ToString();
                stage.reg_date = reader["reg_date"].ToString();
                stage.visible = reader["visible"].ToString();
                stage.xtime = reader["xtime"].ToString();
                stage.rtm = reader["rtm"].ToString();
                stage.acc_p = reader["acc_p"].ToString();
                list.Add(stage);
            }
            reader.Close();
            return list;
        }

        public Stage getStageClassByUserID(string ID)
        {
            Stage stage = new Stage();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                stage.ID = reader["ID"].ToString();
                stage.applicantID = reader["applicantID"].ToString();
                stage.validationID = reader["validationID"].ToString();
                stage.log_officer = reader["log_officer"].ToString();
                stage.amt = reader["amt"].ToString();
                stage.stage = reader["stage"].ToString();
                stage.status = reader["status"].ToString();
                stage.data_status = reader["data_status"].ToString();               
                stage.reg_date = reader["reg_date"].ToString();
                stage.visible = reader["visible"].ToString();
                stage.xtime = reader["xtime"].ToString();
                stage.rtm = reader["rtm"].ToString();
                stage.acc_p = reader["acc_p"].ToString();
            }
            reader.Close();
            return stage;
        }

        public Stage getStageClassByUserID2(string ID)
        {
            Stage stage = new Stage();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwalletAmendment WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                stage.ID = reader["ID"].ToString();
                stage.applicantID = reader["applicantID"].ToString();
                stage.validationID = reader["validationID"].ToString();
                stage.log_officer = reader["log_officer"].ToString();
                stage.amt = reader["amt"].ToString();
                stage.stage = reader["stage"].ToString();
                stage.status = reader["status"].ToString();
                stage.data_status = reader["data_status"].ToString();
                stage.reg_date = reader["reg_date"].ToString();
                stage.visible = reader["visible"].ToString();
                stage.xtime = reader["xtime"].ToString();
                stage.rtm = reader["rtm"].ToString();
                stage.acc_p = reader["acc_p"].ToString();
            }
            reader.Close();
            return stage;
        }

        public int getStageIDBy_G_ValidationID(string validationID)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT ID FROM g_pwallet WHERE validationID='" + validationID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["ID"]);
            }
            reader.Close();
            return num;
        }

        public int getStageIDByvalidationID(string validationID)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT ID FROM pwallet WHERE validationID='" + validationID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["ID"]);
            }
            reader.Close();
            return num;
        }

        public List<State> getState(string countryID)
        {
            List<State> list = new List<State>();
            new State();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM state WHERE countryID='" + countryID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                State item = new State
                {
                    ID = Convert.ToInt64(reader["ID"]).ToString(),
                    name = reader["name"].ToString(),
                    countryID = reader["countryID"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public string getStateName(string ID)
        {
            string str = "";
            try
            {
                SqlConnection connection = new SqlConnection(Connect());
                SqlCommand command = new SqlCommand("SELECT name FROM state WHERE ID='" + Convert.ToInt64(ID) + "' ", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    str = reader["name"].ToString();
                }
                reader.Close();
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
            return str;
        }

        public Stage getStatusIDByvalidationID(string validationID)
        {
            Stage stage = new Stage();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE validationID='" + validationID + "'", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                stage.ID = reader["ID"].ToString();
                stage.status = reader["status"].ToString();
                stage.stage = reader["stage"].ToString();
                stage.applicantID = reader["applicantID"].ToString();
                stage.reg_date = reader["reg_date"].ToString();
            }
            reader.Close();
            return stage;
        }

        public SWallet getSwalletByID(string ID)
        {
            SWallet wallet = new SWallet();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM search_wallet WHERE mark_infoID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                wallet.ID = Convert.ToInt64(reader["ID"]).ToString();
                wallet.mark_infoID = reader["mark_infoID"].ToString();
                wallet.search_cri = reader["search_cri"].ToString();
                wallet.search_str = reader["search_str"].ToString();
                wallet.xclass = reader["xclass"].ToString();
                wallet.log_officer = reader["log_officer"].ToString();
                wallet.reg_date = reader["reg_date"].ToString();
                wallet.visible = reader["visible"].ToString();
            }
            reader.Close();
            return wallet;
        }

        public SWallet getSwalletByID2(string ID)
        {
            SWallet wallet = new SWallet();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM search_wallet2 WHERE mark_infoID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                wallet.ID = Convert.ToInt64(reader["ID"]).ToString();
                wallet.mark_infoID = reader["mark_infoID"].ToString();
                wallet.search_cri = reader["search_cri"].ToString();
                wallet.search_str = reader["search_str"].ToString();
                wallet.xclass = reader["xclass"].ToString();
                wallet.log_officer = reader["log_officer"].ToString();
                wallet.reg_date = reader["reg_date"].ToString();
                wallet.visible = reader["visible"].ToString();
            }
            reader.Close();
            return wallet;
        }

        public List<TmOffice> getTmOfficeDetailsByID(string ID)
        {
            List<TmOffice> list = new List<TmOffice>();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM tm_office WHERE pwalletID='" + ID + "' order by ID desc ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                TmOffice item = new TmOffice
                {
                    ID = "",
                    pwalletID = "",
                    admin_status = "",
                    data_status = "",
                    xcomment = "",
                    xdoc1 = "",
                    xdoc2 = "",
                    xdoc3 = "",
                    xofficer = "",
                    reg_date = "",
                    xvisible = ""
                };
                item.ID = reader["ID"].ToString();
                item.pwalletID = reader["pwalletID"].ToString();
                item.admin_status = reader["admin_status"].ToString();
                item.data_status = reader["data_status"].ToString();
                item.xcomment = reader["xcomment"].ToString();
                item.xdoc1 = reader["xdoc1"].ToString();
                item.xdoc2 = reader["xdoc2"].ToString();
                item.xdoc3 = reader["xdoc3"].ToString();
                item.xofficer = reader["xofficer"].ToString();
                item.reg_date = reader["reg_date"].ToString();
                item.xvisible = reader["xvisible"].ToString();
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public string getTmTypeID(string type)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT xID from tm_type where type='" + type + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["xID"].ToString();
            }
            reader.Close();
            return str;
        }

        public string getTmTypeName(string id)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT type from tm_type where xID='" + id + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["type"].ToString();
            }
            reader.Close();
            return str;
        }

        public int UpdateAddress(Address c_addy)
        {
            if (c_addy.countryID == null)
            {
                c_addy.countryID = "";
            }
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE address SET countryID=@countryID, stateID=@stateID, city=@city, street=@street,";
            command.CommandText = command.CommandText + " telephone1=@telephone1, email1=@email1, log_staff=@log_staff, reg_date=@reg_date,visible=@visible WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@countryID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@stateID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@city", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@street", SqlDbType.Text);
            command.Parameters.Add("@telephone1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@email1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@ID"].Value = c_addy.ID;
            command.Parameters["@countryID"].Value = c_addy.countryID;
            command.Parameters["@stateID"].Value = c_addy.stateID;
            command.Parameters["@city"].Value = c_addy.city;
            command.Parameters["@street"].Value = c_addy.street;
            command.Parameters["@telephone1"].Value = c_addy.telephone1;
            command.Parameters["@email1"].Value = c_addy.email1;
            command.Parameters["@log_staff"].Value = c_addy.log_staff;
            command.Parameters["@reg_date"].Value = c_addy.reg_date;
            command.Parameters["@visible"].Value = c_addy.visible;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int UpdateAos(AddressService c_aos)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE address_service SET countryID=@countryID, stateID=@stateID, city=@city, street=@street,";
            command.CommandText = command.CommandText + " telephone1=@telephone1, email1=@email1, log_staff=@log_staff, reg_date=@reg_date,visible=@visible WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@countryID", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@stateID", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@city", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@street", SqlDbType.Text);
            command.Parameters.Add("@telephone1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@email1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@ID"].Value = c_aos.ID;
            command.Parameters["@countryID"].Value = "";
            command.Parameters["@stateID"].Value = c_aos.stateID;
            command.Parameters["@city"].Value = c_aos.city;
            command.Parameters["@street"].Value = c_aos.street;
            command.Parameters["@telephone1"].Value = c_aos.telephone1;
            command.Parameters["@email1"].Value = c_aos.email1;
            command.Parameters["@log_staff"].Value = c_aos.log_staff;
            command.Parameters["@reg_date"].Value = c_aos.reg_date;
            command.Parameters["@visible"].Value = c_aos.visible;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int UpdateApplicant(Applicant x)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE applicant SET xname=@xname, nationality=@nationality WHERE ID=@ID";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
            command.Parameters["@ID"].Value = x.ID;
            command.Parameters["@xname"].Value = x.xname;
            command.Parameters["@nationality"].Value = x.nationality;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int UpdateBatch(int batch_no, string admin)
        {
            string str = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = string.Concat(new object[] { "update pwallet set visible='", batch_no, "',log_officer='", admin, "',xtime='", str, "' where (pwallet.status >'5' AND pwallet.visible='1' AND pwallet.applicantID <> 'CLD/SA/22') " });
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public string updateCurrentMarkReg(string xID, string typ, string year)
        {
            string str = "0";
            string str2 = "";
            if (typ == "1")
            {
                str2 = "NG/TM/O/" + year + "/" + xID;
            }
            else
            {
                str2 = "F/TM/O/" + year + "/" + xID;
            }
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE mark_info SET reg_number=@reg_number WHERE xID=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters.Add("@reg_number", SqlDbType.NVarChar, 50);
            command.Parameters["@xID"].Value = Convert.ToInt64(xID);
            command.Parameters["@reg_number"].Value = str2;
            str = command.ExecuteNonQuery().ToString();
            connection.Close();
            return str;
        }

        public string updateG_TmDocz(string app_letter_doc, string logo_pic, string sup_doc1, string pwalletID)
        {
            string connectionString = Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE g_tm_info SET app_letter_doc=@app_letter_doc,logo_pic=@logo_pic,sup_doc1=@sup_doc1 WHERE xID=@pwalletID ";
            connection.Open();
            command.Parameters.Add("@app_letter_doc", SqlDbType.Text);
            command.Parameters.Add("@logo_pic", SqlDbType.Text);
            command.Parameters.Add("@sup_doc1", SqlDbType.Text);
            command.Parameters.Add("@pwalletID", SqlDbType.NVarChar);
            command.Parameters["@app_letter_doc"].Value = app_letter_doc;
            command.Parameters["@logo_pic"].Value = logo_pic;
            command.Parameters["@sup_doc1"].Value = sup_doc1;
            command.Parameters["@pwalletID"].Value = pwalletID;
            str2 = command.ExecuteNonQuery().ToString();
            connection.Close();
            return str2;
        }

        public int UpdateG_TmOfficeDocz(string xdoc1, string xdoc2, string xdoc3, string ID)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE g_tm_office SET xdoc1=@xdoc1,xdoc2=@xdoc2,xdoc3=@xdoc3 WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@xdoc1", SqlDbType.Text);
            command.Parameters.Add("@xdoc2", SqlDbType.Text);
            command.Parameters.Add("@xdoc3", SqlDbType.Text);
            command.Parameters["@xdoc1"].Value = xdoc1;
            command.Parameters["@xdoc2"].Value = xdoc2;
            command.Parameters["@xdoc3"].Value = xdoc3;
            command.Parameters["@ID"].Value = ID;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public string updateGeneral_G_TmDocz(string docname1, string docname2, string tabletype, string pwalletID)
        {
            string connectionString = Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "";
            if (tabletype == "cert")
            {
                command.CommandText = "UPDATE g_cert_info SET cert_doc=@docname1,pub_doc=@docname2 WHERE xID=@pwalletID ";
            }
            else if (tabletype == "merger")
            {
                command.CommandText = "UPDATE g_merger_info SET merger_doc=@docname1 WHERE ID=@pwalletID ";
            }
            else if (tabletype == "ass")
            {
                command.CommandText = "UPDATE g_ass_info SET ass_doc=@docname1 WHERE xID=@pwalletID ";
            }
            connection.Open();
            command.Parameters.Add("@docname1", SqlDbType.Text);
            command.Parameters.Add("@pwalletID", SqlDbType.NVarChar);
            if (tabletype == "cert")
            {
                command.Parameters.Add("@docname2", SqlDbType.Text);
            }
            command.Parameters["@docname1"].Value = docname1;
            command.Parameters["@pwalletID"].Value = pwalletID;
            if (tabletype == "cert")
            {
                command.Parameters["@docname2"].Value = docname2;
            }
            str2 = command.ExecuteNonQuery().ToString();
            connection.Close();
            return str2;
        }

        public string updateGPwalletStage(string pwalletID, string stage)
        {
            string connectionString = Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE g_pwallet SET stage=@stage WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@stage", SqlDbType.NVarChar, 50);
            command.Parameters["@ID"].Value = Convert.ToInt64(pwalletID);
            command.Parameters["@stage"].Value = stage;
            str2 = command.ExecuteNonQuery().ToString();
            connection.Close();
            return str2;
        }

        public int updateIpoApplicationReferenceStatus(string transID, string gt, string stat)
        {
            try
            {
                return Convert.ToInt32(iposervice.UpdateTransaction(transID, gt, stat));
            }
            catch (FormatException)
            {
                return 0;
            }
        }

        public int UpdateMark(MarkInfo c_mark)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE mark_info SET tm_typeID=@tm_typeID, logo_descriptionID=@logo_descriptionID, product_title=@product_title,";
            command.CommandText = command.CommandText + " national_classID=@national_classID, disclaimer=@disclaimer,nice_class=@nice_class, nice_class_desc=@nice_class_desc WHERE xID=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters.Add("@tm_typeID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@logo_descriptionID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@product_title", SqlDbType.NVarChar);
            command.Parameters.Add("@national_classID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@disclaimer", SqlDbType.NVarChar);
            command.Parameters.Add("@nice_class", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@nice_class_desc", SqlDbType.Text);
            command.Parameters["@xID"].Value = c_mark.xID;
            command.Parameters["@tm_typeID"].Value = c_mark.tm_typeID;
            command.Parameters["@logo_descriptionID"].Value = c_mark.logo_descriptionID;
            command.Parameters["@product_title"].Value = c_mark.product_title;
            command.Parameters["@national_classID"].Value = c_mark.national_classID;
            command.Parameters["@disclaimer"].Value = c_mark.disclaimer;
            command.Parameters["@nice_class"].Value = c_mark.nice_class;
            command.Parameters["@nice_class_desc"].Value = c_mark.nice_class_desc;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int UpdateMarkAuth(string auth_doc, string ID)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE mark_info SET auth_doc=@auth_doc WHERE xID=@xID ";
            connection.Open();
            command.Parameters.Add("@auth_doc", SqlDbType.Text);
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters["@auth_doc"].Value = auth_doc;
            command.Parameters["@xID"].Value = ID;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public string updateMarkDocz(string logo_pic, string auth_doc, string sup_doc1, string sup_doc2, string pwalletID)
        {
            string connectionString = Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE mark_info SET logo_pic=@logo_pic,auth_doc=@auth_doc,sup_doc1=@sup_doc1,sup_doc2=@sup_doc2 WHERE log_staff=@log_staff ";
            connection.Open();
            command.Parameters.Add("@logo_pic", SqlDbType.Text);
            command.Parameters.Add("@auth_doc", SqlDbType.Text);
            command.Parameters.Add("@sup_doc1", SqlDbType.Text);
            command.Parameters.Add("@sup_doc2", SqlDbType.Text);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters["@logo_pic"].Value = logo_pic;
            command.Parameters["@auth_doc"].Value = auth_doc;
            command.Parameters["@sup_doc1"].Value = sup_doc1;
            command.Parameters["@sup_doc2"].Value = sup_doc2;
            command.Parameters["@log_staff"].Value = pwalletID;
            str2 = command.ExecuteNonQuery().ToString();
            connection.Close();
            return str2;
        }

        public int UpdateMarkDocz(string logo_pic, string auth_doc, string sup_doc1, string sup_doc2, string ID)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE mark_info SET logo_pic=@logo_pic,auth_doc=@auth_doc,sup_doc1=@sup_doc1,sup_doc2=@sup_doc2 WHERE xID=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters.Add("@logo_pic", SqlDbType.Text);
            command.Parameters.Add("@auth_doc", SqlDbType.Text);
            command.Parameters.Add("@sup_doc1", SqlDbType.Text);
            command.Parameters.Add("@sup_doc2", SqlDbType.Text);
            command.Parameters["@logo_pic"].Value = logo_pic;
            command.Parameters["@auth_doc"].Value = auth_doc;
            command.Parameters["@sup_doc1"].Value = sup_doc1;
            command.Parameters["@sup_doc2"].Value = sup_doc2;
            command.Parameters["@xID"].Value = ID;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int UpdateMarkLogo(string logo_pic, string ID)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE mark_info SET logo_pic=@logo_pic WHERE xID=@xID ";
            connection.Open();
            command.Parameters.Add("@logo_pic", SqlDbType.Text);
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters["@logo_pic"].Value = logo_pic;
            command.Parameters["@xID"].Value = ID;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public string updateMarkReg(string xID, string typ)
        {
            string str = "0";
            string str2 = "";
            if (typ == "1")
            {
                str2 = "NG/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID;
            }
            else
            {
                str2 = "F/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID;
            }
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE mark_info SET reg_number=@reg_number WHERE xID=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters.Add("@reg_number", SqlDbType.NVarChar, 50);
            command.Parameters["@xID"].Value = Convert.ToInt64(xID);
            command.Parameters["@reg_number"].Value = str2;
            str = command.ExecuteNonQuery().ToString();
            connection.Close();
            return str;
        }

        public int UpdateMarkSupDoc1(string sup_doc1, string ID)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE mark_info SET sup_doc1=@sup_doc1 WHERE xID=@xID ";
            connection.Open();
            command.Parameters.Add("@sup_doc1", SqlDbType.Text);
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters["@sup_doc1"].Value = sup_doc1;
            command.Parameters["@xID"].Value = ID;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int UpdateMarkSupDoc2(string sup_doc2, string ID)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE mark_info SET sup_doc2=@sup_doc2 WHERE xID=@xID ";
            connection.Open();
            command.Parameters.Add("@sup_doc2", SqlDbType.Text);
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters["@sup_doc2"].Value = sup_doc2;
            command.Parameters["@xID"].Value = ID;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public string updateOldDateMarkReg(string xID, string typ, string yr)
        {
            string str = "0";
            string str2 = "";
            if (typ == "1")
            {
                str2 = "NG/TM/O/" + yr + "/" + xID;
            }
            else
            {
                str2 = "F/TM/O/" + yr + "/" + xID;
            }
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE mark_info SET reg_number=@reg_number WHERE xID=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters.Add("@reg_number", SqlDbType.NVarChar, 50);
            command.Parameters["@xID"].Value = Convert.ToInt64(xID);
            command.Parameters["@reg_number"].Value = str2;
            str = command.ExecuteNonQuery().ToString();
            connection.Close();
            return str;
        }

        public string updatePwalletPrinted(string pwalletID, string log_officer)
        {
            string connectionString = Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE pwallet SET acc_p=@acc_p,log_officer=@log_officer WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@log_officer", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@acc_p", SqlDbType.NVarChar, 50);
            command.Parameters["@ID"].Value = Convert.ToInt64(pwalletID);
            command.Parameters["@log_officer"].Value = log_officer;
            str2 = command.ExecuteNonQuery().ToString();
            connection.Close();
            return str2;
        }

        public string updatePwalletRtm(string pwalletID, string log_officer)
        {
            string connectionString = Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE pwallet SET rtm=@rtm,log_officer=@log_officer WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@log_officer", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@rmt", SqlDbType.NVarChar, 50);
            command.Parameters["@ID"].Value = Convert.ToInt64(pwalletID);
            command.Parameters["@log_officer"].Value = log_officer;
            str2 = command.ExecuteNonQuery().ToString();
            connection.Close();
            return str2;
        }

        public string updatePwalletStage(string pwalletID, string log_officer, string stage)
        {
            string connectionString = Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE pwallet SET stage=@stage,log_officer=@log_officer WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@stage", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_officer", SqlDbType.NVarChar, 50);
            command.Parameters["@ID"].Value = Convert.ToInt64(pwalletID);
            command.Parameters["@stage"].Value = stage;
            command.Parameters["@log_officer"].Value = log_officer;
            str2 = command.ExecuteNonQuery().ToString();
            connection.Close();
            return str2;
        }

        public string updatePwalletStatus(string pwalletID, string log_officer)
        {
            string connectionString = Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE pwallet SET stage=5,log_officer=@log_officer WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@log_officer", SqlDbType.NVarChar, 50);
            command.Parameters["@ID"].Value = Convert.ToInt64(pwalletID);
            command.Parameters["@log_officer"].Value = log_officer;
            str2 = command.ExecuteNonQuery().ToString();
            connection.Close();
            return str2;
        }

        public int UpdateRep(Representative c_rep)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE representative SET agent_code=@agent_code, xname=@xname, nationality=@nationality, reg_date=@reg_date  WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@agent_code", SqlDbType.NVarChar);
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters["@ID"].Value = c_rep.ID;
            command.Parameters["@agent_code"].Value = c_rep.agent_code;
            command.Parameters["@xname"].Value = c_rep.xname;
            command.Parameters["@nationality"].Value = c_rep.nationality;
            command.Parameters["@reg_date"].Value = c_rep.reg_date;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int UpdateTmOfficeDoc(string xdoc1, string xdoc2, string xdoc3, string ID)
        {
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE tm_office SET xdoc1=@xdoc1,xdoc2=@xdoc2,xdoc3=@xdoc3 WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@xdoc1", SqlDbType.Text);
            command.Parameters.Add("@xdoc2", SqlDbType.Text);
            command.Parameters.Add("@xdoc3", SqlDbType.Text);
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters["@xdoc1"].Value = xdoc1;
            command.Parameters["@xdoc2"].Value = xdoc2;
            command.Parameters["@xdoc3"].Value = xdoc3;
            command.Parameters["@ID"].Value = ID;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int updateTransaction(string id)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("UPDATE xtransactions set status=1 where ID='" + id + "'", connection);
            connection.Open();
            num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public string ValidationIDByG_PwalletID(string ID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT validationID FROM g_pwallet WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["validationID"].ToString();
            }
            reader.Close();
            return str;
        }

        public string ValidationIDByPwalletID(string ID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT validationID FROM pwallet WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["validationID"].ToString();
            }
            reader.Close();
            return str;
        }

        public class Certificate
        {
            public string Pub_Date { get; set; }

            public string Pub_Details { get; set; }

            public string Pub_Doc { get; set; }

          
        }

        public class Address
        {
            public string city { get; set; }

            public string countryID { get; set; }

            public string email1 { get; set; }

            public string email2 { get; set; }

            public string ID { get; set; }

            public string lgaID { get; set; }

            public string log_staff { get; set; }

            public string reg_date { get; set; }

            public string stateID { get; set; }

            public string street { get; set; }

            public string telephone1 { get; set; }

            public string telephone2 { get; set; }

            public string visible { get; set; }

            public string xtime { get; set; }

            public string zip { get; set; }
        }

        public class AddressService
        {
            public string city { get; set; }

            public string countryID { get; set; }

            public string email1 { get; set; }

            public string email2 { get; set; }

            public string ID { get; set; }

            public string lgaID { get; set; }

            public string log_staff { get; set; }

            public string reg_date { get; set; }

            public string stateID { get; set; }

            public string street { get; set; }

            public string telephone1 { get; set; }

            public string telephone2 { get; set; }

            public string visible { get; set; }

            public string xtime { get; set; }

            public string zip { get; set; }
        }

        public class Applicant
        {
            public string addressID { get; set; }

            public string ID { get; set; }

            public string individual_id_number { get; set; }

            public string log_staff { get; set; }

            public string nationality { get; set; }

            public string reg_date { get; set; }

            public string tax_id_number { get; set; }

            public string tax_id_type { get; set; }

            public string visible { get; set; }

            public string xname { get; set; }

            public string xtime { get; set; }

            public string xtype { get; set; }
        }

        public class Country
        {
            public string code { get; set; }

            public string ID { get; set; }

            public string name { get; set; }
        }

        public class Lga
        {
            public string ID { get; set; }

            public string name { get; set; }

            public string stateID { get; set; }
        }

        public class MarkInfo
        {
            public string auth_doc { get; set; }

            public string disclaimer { get; set; }

            public string log_staff { get; set; }

            public string logo_descriptionID { get; set; }

            public string logo_pic { get; set; }

            public string national_classID { get; set; }

            public string nice_class { get; set; }

            public string nice_class_desc { get; set; }

            public string product_title { get; set; }

            public string reg_date { get; set; }

            public string reg_number { get; set; }

            public string sign_type { get; set; }

            public string sup_doc1 { get; set; }

            public string sup_doc2 { get; set; }

            public string tm_typeID { get; set; }

            public string vienna_class { get; set; }

            public string xID { get; set; }

            public string xtime { get; set; }

            public string xvisible { get; set; }
        }

        public class NClass
        {
            public string xdescription { get; set; }

            public string xID { get; set; }

            public string xtype { get; set; }
        }

        public class Representative
        {
            public string addressID { get; set; }

            public string agent_code { get; set; }

            public string ID { get; set; }

            public string individual_id_number { get; set; }

            public string individual_id_type { get; set; }

            public string log_staff { get; set; }

            public string nationality { get; set; }

            public string reg_date { get; set; }

            public string visible { get; set; }

            public string xname { get; set; }

            public string xtime { get; set; }
        }

        public class Stage
        {
            public string acc_p { get; set; }

            public string amt { get; set; }

            public string applicantID { get; set; }

            public string data_status { get; set; }

            public string ID { get; set; }

            public string log_officer { get; set; }

            public string reg_date { get; set; }

            public string rtm { get; set; }

            public string stage { get; set; }

            public string status { get; set; }

            public string validationID { get; set; }

            public string visible { get; set; }

            public string xtime { get; set; }
        }

        public class State
        {
            public string countryID { get; set; }

            public string ID { get; set; }

            public string name { get; set; }
        }

        public class SWallet
        {
            public string ID { get; set; }

            public string log_officer { get; set; }

            public string mark_infoID { get; set; }

            public string reg_date { get; set; }

            public string search_cri { get; set; }

            public string search_str { get; set; }

            public string visible { get; set; }

            public string xclass { get; set; }
        }

        public class TmOffice
        {
            public string admin_status { get; set; }

            public string data_status { get; set; }

            public string ID { get; set; }

            public string pwalletID { get; set; }

            public string reg_date { get; set; }

            public string xcomment { get; set; }

            public string xdoc1 { get; set; }

            public string xdoc2 { get; set; }

            public string xdoc3 { get; set; }

            public string xofficer { get; set; }

            public string xtime { get; set; }

            public string xvisible { get; set; }
        }

        public class XTransaction
        {
            public string adminID { get; set; }

            public string amt { get; set; }

            public string ID { get; set; }

            public string ptype { get; set; }

            public string status { get; set; }

            public string transactionID { get; set; }

            public string xcode { get; set; }
        }
    }
}

