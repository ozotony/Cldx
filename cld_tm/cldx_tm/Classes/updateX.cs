namespace cld.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI.WebControls;

    public class updateX
    {
        public string a_address_service(string xstate, string xcity, string street, string xzip, string xtelephone, string xemail, string validationID, string agentID, string amt, string stage)
        {
            string connectionString = this.Connect();
            DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str2 = "";
            string str3 = this.getPwalletID(validationID);
            if (this.addAddress_Service("", xstate, "0", xcity, street, xzip, xtelephone, "", xemail, "", str3) > 0)
            {
                return Convert.ToInt32(this.e_pwallet(validationID, agentID, amt, stage, "")).ToString();
            }
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("DELETE FROM address_service WHERE xID='" + str2 + "' ", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return "0";
        }

        public string a_applicant(string name, string type, string tax_id_type, string tax_id_number, string individual_id_number, string nationality, string residence, string xstate, string xcity, string street, string xzip, string xtelephone, string xemail, string agentID, string amt, string validationID, string stage)
        {
            string connectionString = this.Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str3 = "";
            int num = this.addAddress(residence, xstate, "0", xcity, street, xzip, xtelephone, "", xemail, "", validationID);
            if (num <= 0)
            {
                return str3;
            }
            str3 = Convert.ToInt32(this.e_pwallet(validationID, agentID, amt, stage, "")).ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(string.Concat(new object[] { "UPDATE address SET log_staff='", str3, "' WHERE ID='", num, "' " }), connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            if (str3 != "0")
            {
                SqlConnection connection2 = new SqlConnection(connectionString);
                connection2.Open();
                SqlCommand command2 = new SqlCommand("sp_a_applicant", connection2)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command2.Parameters.Add(new SqlParameter("@name", name));
                command2.Parameters.Add(new SqlParameter("@type", type));
                command2.Parameters.Add(new SqlParameter("@tax_id_type", tax_id_type));
                command2.Parameters.Add(new SqlParameter("@tax_id_number", tax_id_number));
                command2.Parameters.Add(new SqlParameter("@individual_id_number", individual_id_number));
                command2.Parameters.Add(new SqlParameter("@nationality", nationality));
                command2.Parameters.Add(new SqlParameter("@addressID", num.ToString()));
                command2.Parameters.Add(new SqlParameter("@log_staff", str3));
                command2.Parameters.Add(new SqlParameter("@reg_date", str2));
                command2.Parameters.Add(new SqlParameter("@visible", "1"));
                SqlParameter parameter = command2.Parameters.Add("@ReturnVal", SqlDbType.Int);
                parameter.Direction = ParameterDirection.ReturnValue;
                command2.ExecuteNonQuery();
                str3 = parameter.Value.ToString();
                connection2.Close();
                return str3;
            }
            SqlConnection connection3 = new SqlConnection(connectionString);
            SqlCommand command4 = new SqlCommand("DELETE FROM address WHERE xID='" + num + "' ", connection3);
            connection3.Open();
            command4.ExecuteNonQuery();
            connection3.Close();
            SqlConnection connection4 = new SqlConnection(connectionString);
            SqlCommand command5 = new SqlCommand("DELETE FROM applicant WHERE xID='" + str3 + "' ", connection4);
            connection4.Open();
            command5.ExecuteNonQuery();
            connection4.Close();
            return "0";
        }

        public string a_markInfo(string tm_type, string logo_description, string title_of_product, string nice_class, string nice_class_desc, string national_class, string sign_type, string vienna_class, string disclaimer, string logo_pic, string auth_doc, string sup_doc1, string sup_doc2, string validationID, string agentID, string amt, string stage)
        {
            string connectionString = this.Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str3 = "";
            string str4 = "";
            string str5 = this.getMarkPwalletID(validationID, agentID, amt, stage, "");
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
            if (this.e_MarkInfoRegNumber(str4, str5) != 0)
            {
                if (this.e_pwallet(validationID, agentID, amt, stage, "").ToString() == "0")
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

        public string a_representative(string xcode, string xname, string individual_id_type, string individual_id_number, string nationality, string residence, string xstate, string xcity, string street, string xzip, string xtelephone, string xemail, string validationID, string agentID, string amt, string stage)
        {
            string connectionString = this.Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str3 = "";
            string str4 = this.getPwalletID(validationID);
            int num = this.addAddress(residence, xstate, "0", xcity, street, xzip, xtelephone, "", xemail, "", str4);
            if (num > 0)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("sp_a_representative", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@xname", xname));
                command.Parameters.Add(new SqlParameter("@agent_code", xcode));
                command.Parameters.Add(new SqlParameter("@individual_id_type", individual_id_type));
                command.Parameters.Add(new SqlParameter("@individual_id_number", individual_id_number));
                command.Parameters.Add(new SqlParameter("@nationality", nationality));
                command.Parameters.Add(new SqlParameter("@addressID", num.ToString()));
                command.Parameters.Add(new SqlParameter("@log_staff", str4));
                command.Parameters.Add(new SqlParameter("@reg_date", str2));
                command.Parameters.Add(new SqlParameter("@visible", "1"));
                SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                parameter.Direction = ParameterDirection.ReturnValue;
                command.ExecuteNonQuery();
                str3 = parameter.Value.ToString();
                connection.Close();
            }
            if (str3 != "0")
            {
                str3 = Convert.ToInt32(this.e_pwallet(validationID, agentID, amt, stage, "Fresh")).ToString();
                Convert.ToInt32(this.e_PwalletStatus(str4, "1", "Fresh")).ToString();
                return str3;
            }
            SqlConnection connection2 = new SqlConnection(connectionString);
            SqlCommand command3 = new SqlCommand("DELETE FROM address WHERE xID='" + num + "' ", connection2);
            connection2.Open();
            command3.ExecuteNonQuery();
            connection2.Close();
            SqlConnection connection3 = new SqlConnection(connectionString);
            SqlCommand command4 = new SqlCommand("DELETE FROM representative WHERE xID='" + str3 + "' ", connection3);
            connection3.Open();
            command4.ExecuteNonQuery();
            connection3.Close();
            return "0";
        }

        public int addAddress(string countryID, string stateID, string lgaID, string city, string street, string zip, string telephone1, string telephone2, string email1, string email2, string log_staff)
        {
            string connectionString = this.Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_a_address", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@countryID", countryID));
            command.Parameters.Add(new SqlParameter("@stateID", stateID));
            command.Parameters.Add(new SqlParameter("@lgaID", lgaID));
            command.Parameters.Add(new SqlParameter("@city", city));
            command.Parameters.Add(new SqlParameter("@street", street));
            command.Parameters.Add(new SqlParameter("@zip", zip));
            command.Parameters.Add(new SqlParameter("@telephone1", telephone1));
            command.Parameters.Add(new SqlParameter("@telephone2", telephone2));
            command.Parameters.Add(new SqlParameter("@email1", email1));
            command.Parameters.Add(new SqlParameter("@email2", email2));
            command.Parameters.Add(new SqlParameter("@log_staff", log_staff));
            command.Parameters.Add(new SqlParameter("@reg_date", str2));
            command.Parameters.Add(new SqlParameter("@visible", "1"));
            SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            int num = (int)parameter.Value;
            connection.Close();
            return num;
        }

        public int addAddress_Service(string countryID, string stateID, string lgaID, string city, string street, string zip, string telephone1, string telephone2, string email1, string email2, string log_staff)
        {
            string connectionString = this.Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_a_address_service", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@countryID", countryID));
            command.Parameters.Add(new SqlParameter("@stateID", stateID));
            command.Parameters.Add(new SqlParameter("@lgaID", lgaID));
            command.Parameters.Add(new SqlParameter("@city", city));
            command.Parameters.Add(new SqlParameter("@street", street));
            command.Parameters.Add(new SqlParameter("@zip", zip));
            command.Parameters.Add(new SqlParameter("@telephone1", telephone1));
            command.Parameters.Add(new SqlParameter("@telephone2", telephone2));
            command.Parameters.Add(new SqlParameter("@email1", email1));
            command.Parameters.Add(new SqlParameter("@email2", email2));
            command.Parameters.Add(new SqlParameter("@log_staff", log_staff));
            command.Parameters.Add(new SqlParameter("@reg_date", str2));
            command.Parameters.Add(new SqlParameter("@visible", "1"));
            SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            int num = (int)parameter.Value;
            connection.Close();
            return num;
        }

        public int checkValidation(string id)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public void cleanseTmByValidation(string vid)
        {
            string id = "0";
            string connectionString = this.Connect();
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
                SqlCommand command2 = new SqlCommand("DELETE from pwallet where ID='" + id + "'", connection2);
                connection2.Open();
                command2.ExecuteNonQuery();
                connection2.Close();
                this.flushApplicant(id);
                this.flushMark_info(id);
                this.flushAddress_service(id);
                this.flushRepresentative(id);
            }
        }

        public string Connect()
        {
            return ConfigurationManager.ConnectionStrings["cldConnectionString"].ConnectionString;
        }

        public int deleteMarkInfo(string xID)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("DELETE from mark_info where xID='" + xID + "'", connection);
            connection.Open();
            num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public string doUploadDoc(string ID, string path, FileUpload fu)
        {
            string str = "";
            string str2 = Path.GetFileName(fu.FileName).Replace(" ", "_");
            str = str = path + ID + "/" + str2;
            try
            {
                if (!Directory.Exists(path + ID + "/"))
                {
                    Directory.CreateDirectory(path + ID + "/");
                }
                else
                {
                    File.Exists(str);
                }
                fu.SaveAs(str);
            }
            catch (Exception exception)
            {
                str = "The file could not be uploaded. The following error occured: " + exception.Message;
            }
            return str;
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
            catch (Exception exception)
            {
                return ("The file could not be uploaded. The following error occured: " + exception.Message);
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
            catch (Exception exception)
            {
                return ("The file could not be uploaded. The following error occured: " + exception.Message);
            }
        }

        public string doUploadUpDoc(string ID, string path, string oldpath, FileUpload fu)
        {
            string filename = "";
            string str2 = Path.GetFileName(fu.FileName).Replace(" ", "_");
            filename = filename = path + ID + "/" + str2;
            try
            {
                if (File.Exists(oldpath))
                {
                    File.Delete(oldpath);
                }
                if (!Directory.Exists(path + ID + "/"))
                {
                    Directory.CreateDirectory(path + ID + "/");
                }
                fu.SaveAs(filename);
            }
            catch (Exception exception)
            {
                filename = "The file could not be uploaded. The following error occured: " + exception.Message;
            }
            return filename;
        }

        public int e_MarkInfoDocz(string logo_pic, string auth_doc, string sup_doc1, string sup_doc2, string mark_infoID)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
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
            SqlConnection connection = new SqlConnection(this.Connect());
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
            string connectionString = this.Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            int num = 0;
            this.checkValidation(validationID);
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
            string connectionString = this.Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            int num = 0;
            if (this.checkValidation(validationID) > 0)
            {
                string str3 = this.getPwalletID(validationID);
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
            SqlConnection connection = new SqlConnection(this.Connect());
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
            SqlConnection connection = new SqlConnection(this.Connect());
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
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("DELETE from address where ID='" + id + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void flushAddress_service(string id)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("DELETE from address_service where log_staff='" + id + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void flushApplicant(string id)
        {
            string str = "";
            string connectionString = this.Connect();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT addressID from applicant where log_staff='" + id + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["addressID"].ToString();
            }
            reader.Close();
            this.flushAddress(str);
            SqlConnection connection2 = new SqlConnection(connectionString);
            SqlCommand command2 = new SqlCommand("DELETE from applicant where log_staff='" + id + "'", connection2);
            connection2.Open();
            command2.ExecuteNonQuery();
            connection2.Close();
        }

        public void flushMark_info(string id)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("DELETE from mark_info where log_staff='" + id + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void flushRepresentative(string id)
        {
            string str = "";
            string connectionString = this.Connect();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT addressID from representative where log_staff='" + id + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["addressID"].ToString();
            }
            reader.Close();
            this.flushAddress(str);
            SqlConnection connection2 = new SqlConnection(connectionString);
            SqlCommand command2 = new SqlCommand("DELETE from representative where log_staff='" + id + "'", connection2);
            connection2.Open();
            command2.ExecuteNonQuery();
            connection2.Close();
        }

        public List<Address> getAddressByID(string ID)
        {
            List<Address> list = new List<Address>();
            new Address();
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public List<Address> getAddressByLog_staffID(string validationID)
        {
            List<Address> list = new List<Address>();
            new Address();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM address WHERE log_staff='" + validationID + "' ", connection);
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

        public List<AddressService> getAddressServiceByID(string ID)
        {
            List<AddressService> list = new List<AddressService>();
            new AddressService();
            SqlConnection connection = new SqlConnection(this.Connect());
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
            SqlConnection connection = new SqlConnection(this.Connect());
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
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public List<Address> getAOSByRefID(string ID)
        {
            List<Address> list = new List<Address>();
            new Address();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select * from address_service where log_staff IN (select ID from pwallet where validationID='" + ID + "' ) ", connection);
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

        public List<Applicant> getApplicantByRefID(string ID)
        {
            List<Applicant> list = new List<Applicant>();
            new Applicant();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select * from applicant where log_staff IN (select ID from pwallet where validationID='" + ID + "' ) ", connection);
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

        public List<Applicant> getApplicantByUserID(string ID)
        {
            List<Applicant> list = new List<Applicant>();
            new Applicant();
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public List<Applicant> getApplicantByvalidationID(string validationID)
        {
            List<Applicant> list = new List<Applicant>();
            new Applicant();
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public string getCheckStatusDetails(string validationID, string agentID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public string getClientNumber()
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
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
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public string getCountryName(string ID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
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
            string str = "";
            List<Address> list = new List<Address>();
            new Address();
            SqlConnection connection = new SqlConnection(this.Connect());
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
            string str2 = str;
            return (str2 + list[0].street + "," + list[0].city + "," + this.getStateName(list[0].stateID));
        }

        public List<NClass> getJNationalClasses()
        {
            List<NClass> list = new List<NClass>();
            new NClass();
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public List<Lga> getLga()
        {
            List<Lga> list = new List<Lga>();
            new Lga();
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public string getLogoDescriptionName(string id)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public List<MarkInfo> getMarkByRefID(string ID)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select * from mark_info where log_staff IN (select ID from pwallet where validationID='" + ID + "' ) ", connection);
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

        public List<MarkInfo> getMarkInfoByID(string ID)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM mark_info WHERE xID='" + ID + "' ", connection);
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

        public List<MarkInfo> getMarkInfoByUserID(string ID)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public string getMarkPwalletID(string validationID, string agentID, string amt, string stage, string data_status)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
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
                str = this.e_markpwallet(validationID, agentID, amt, stage, data_status).ToString();
            }
            return str;
        }

        public string getNationalClassDesc(string id)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public string getPwalletID(string validationID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public List<Representative> getRepByUserID(string ID)
        {
            List<Representative> list = new List<Representative>();
            new Representative();
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public List<Representative> getRepresentativeByRefID(string ID)
        {
            List<Representative> list = new List<Representative>();
            new Representative();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select * from representative where log_staff IN (select ID from pwallet where validationID='" + ID + "'  ) ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Representative item = new Representative
                {
                    ID = reader["ID"].ToString(),
                    xname = reader["xname"].ToString(),
                    agent_code = reader["agent_code"].ToString(),
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

        public List<Stage> getStageByUserID(string ID)
        {
            List<Stage> list = new List<Stage>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE ID='" + ID + "' ", connection);
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

        public List<Stage> getStageByUserIDAcc(string validationID, string agentID)
        {
            List<Stage> list = new List<Stage>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE validationID='" + validationID + "'  AND applicantID='" + agentID + "'", connection);
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

        public List<State> getState(string countryID)
        {
            List<State> list = new List<State>();
            new State();
            SqlConnection connection = new SqlConnection(this.Connect());
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
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT name FROM state WHERE ID='" + ID + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["name"].ToString();
            }
            reader.Close();
            return str;
        }

        public string getTmTypeName(string id)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public int UpdateAddress(string residence, string xstate, string street, string xzip, string xtelephone, string xemail, string addressID)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE address SET countryID=@countryID,stateID=@stateID,street=@street,zip=@zip,telephone1=@telephone1,email1=@email1 WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@countryID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@stateID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@street", SqlDbType.Text);
            command.Parameters.Add("@zip", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@telephone1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@email1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters["@countryID"].Value = residence;
            command.Parameters["@stateID"].Value = xstate;
            command.Parameters["@street"].Value = street;
            command.Parameters["@zip"].Value = xzip;
            command.Parameters["@telephone1"].Value = xtelephone;
            command.Parameters["@email1"].Value = xemail;
            command.Parameters["@ID"].Value = addressID;
            int num = command.ExecuteNonQuery();
            connection.Close();
            if (num > 0)
            {
                num = Convert.ToInt32(addressID);
            }
            return num;
        }

        public int UpdateAddressService(string residence, string xstate, string xcity, string street, string xzip, string xtelephone, string xemail, string addressID)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE address_service SET countryID=@countryID,stateID=@stateID,city=@city,street=@street,zip=@zip,telephone1=@telephone1,email1=@email1 WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@countryID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@stateID", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@city", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@street", SqlDbType.Text);
            command.Parameters.Add("@zip", SqlDbType.NVarChar, 10);
            command.Parameters.Add("@telephone1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@email1", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters["@countryID"].Value = residence;
            command.Parameters["@stateID"].Value = xstate;
            command.Parameters["@city"].Value = xcity;
            command.Parameters["@street"].Value = street;
            command.Parameters["@zip"].Value = xzip;
            command.Parameters["@telephone1"].Value = xtelephone;
            command.Parameters["@email1"].Value = xemail;
            command.Parameters["@ID"].Value = addressID;
            int num = command.ExecuteNonQuery();
            connection.Close();
            if (num > 0)
            {
                num = Convert.ToInt32(addressID);
            }
            return num;
        }

        public int UpdateApplicant(string name, string type, string tax_id_type, string tax_id_number, string individual_id_number, string nationality, string residence, string xstate, string street, string xzip, string xtelephone, string xemail, string ID, string addressID)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE applicant SET xname=@xname,xtype=@xtype,tax_id_type=@tax_id_type,tax_id_number=@tax_id_number,individual_id_number=@individual_id_number,nationality=@nationality WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@xtype", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@tax_id_type", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@tax_id_number", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@individual_id_number", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters["@xname"].Value = name;
            command.Parameters["@xtype"].Value = type;
            command.Parameters["@tax_id_type"].Value = tax_id_type;
            command.Parameters["@tax_id_number"].Value = tax_id_number;
            command.Parameters["@individual_id_number"].Value = individual_id_number;
            command.Parameters["@nationality"].Value = nationality;
            command.Parameters["@ID"].Value = ID;
            int num = command.ExecuteNonQuery();
            connection.Close();
            if (num > 0)
            {
                num = this.UpdateAddress(residence, xstate, street, xzip, xtelephone, xemail, addressID);
            }
            return num;
        }

        public int UpdateMark(string tm_type, string logo_description, string title_of_product, string nice_class, string nice_class_desc, string national_class, string sign_type, string vienna_class, string disclaimer, string ID)
        {
            string connectionString = this.Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE mark_info SET reg_number=@reg_number,tm_typeID=@tm_typeID,product_title=@product_title,logo_descriptionID=@logo_descriptionID,nice_class=@nice_class,nice_class_desc=@nice_class_desc,national_classID=@national_classID,sign_type=@sign_type,vienna_class=@vienna_class,disclaimer=@disclaimer WHERE xID=@xID ";
            connection.Open();
            if (tm_type == "1")
            {
                str2 = "NG/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + ID;
            }
            else
            {
                str2 = "F/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + ID;
            }
            command.Parameters.Add("@reg_number", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@tm_typeID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@product_title", SqlDbType.NVarChar);
            command.Parameters.Add("@logo_descriptionID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@nice_class", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@nice_class_desc", SqlDbType.Text);
            command.Parameters.Add("@national_classID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@sign_type", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@vienna_class", SqlDbType.NVarChar);
            command.Parameters.Add("@disclaimer", SqlDbType.Text);
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters["@reg_number"].Value = str2;
            command.Parameters["@tm_typeID"].Value = tm_type;
            command.Parameters["@product_title"].Value = title_of_product;
            command.Parameters["@logo_descriptionID"].Value = logo_description;
            command.Parameters["@nice_class"].Value = nice_class;
            command.Parameters["@nice_class_desc"].Value = nice_class_desc;
            command.Parameters["@national_classID"].Value = national_class;
            command.Parameters["@sign_type"].Value = sign_type;
            command.Parameters["@vienna_class"].Value = vienna_class;
            command.Parameters["@disclaimer"].Value = disclaimer;
            command.Parameters["@xID"].Value = ID;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int UpdateMarkAuth(string auth_doc, string ID)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public int UpdateMarkDocz(string logo_pic, string auth_doc, string sup_doc1, string sup_doc2, string ID)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE mark_info SET logo_pic=@logo_pic,auth_doc=@auth_doc,sup_doc1=@sup_doc1,sup_doc2=@sup_doc2 WHERE xID=@xID ";
            connection.Open();
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
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public int UpdateMarkSupDoc1(string sup_doc1, string ID)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
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
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public int UpdateRepresentative(string agent_code, string name, string individual_id_type, string individual_id_number, string nationality, string residence, string xstate, string street, string xzip, string xtelephone, string xemail, string ID, string addressID)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE representative SET xname=@xname,agent_code=@agent_code,individual_id_type=@individual_id_type,individual_id_number=@individual_id_number,nationality=@nationality WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@agent_code", SqlDbType.NVarChar);
            command.Parameters.Add("@individual_id_type", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@individual_id_number", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters["@xname"].Value = name;
            command.Parameters["@agent_code"].Value = agent_code;
            command.Parameters["@individual_id_type"].Value = individual_id_type;
            command.Parameters["@individual_id_number"].Value = individual_id_number;
            command.Parameters["@nationality"].Value = nationality;
            command.Parameters["@ID"].Value = ID;
            int num = command.ExecuteNonQuery();
            connection.Close();
            if (num > 0)
            {
                num = this.UpdateAddress(residence, xstate, street, xzip, xtelephone, xemail, addressID);
            }
            return num;
        }

        public string ValidationIDByPwalletID(string ID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
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

        public class Address
        {
            public string city;
            public string countryID;
            public string email1;
            public string email2;
            public string ID;
            public string lgaID;
            public string log_staff;
            public string reg_date;
            public string stateID;
            public string street;
            public string telephone1;
            public string telephone2;
            public string visible;
            public string zip;
        }

        public class AddressService
        {
            public string city;
            public string countryID;
            public string email1;
            public string email2;
            public string ID;
            public string lgaID;
            public string log_staff;
            public string reg_date;
            public string stateID;
            public string street;
            public string telephone1;
            public string telephone2;
            public string visible;
            public string zip;
        }

        public class Applicant
        {
            public string addressID;
            public string ID;
            public string individual_id_number;
            public string log_staff;
            public string nationality;
            public string reg_date;
            public string tax_id_number;
            public string tax_id_type;
            public string visible;
            public string xname;
            public string xtype;
        }

        public class Country
        {
            public string code;
            public string ID;
            public string name;
        }

        public class Lga
        {
            public string ID;
            public string name;
            public string stateID;
        }

        public class MarkInfo
        {
            public string auth_doc;
            public string disclaimer;
            public string log_staff;
            public string logo_descriptionID;
            public string logo_pic;
            public string national_classID;
            public string nice_class;
            public string nice_class_desc;
            public string product_title;
            public string reg_date;
            public string reg_number;
            public string sign_type;
            public string sup_doc1;
            public string sup_doc2;
            public string tm_typeID;
            public string vienna_class;
            public string xID;
            public string xvisible;
        }

        public class NClass
        {
            public string xdescription;
            public string xID;
            public string xtype;
        }

        public class Representative
        {
            public string addressID;
            public string agent_code;
            public string ID;
            public string individual_id_number;
            public string individual_id_type;
            public string log_staff;
            public string nationality;
            public string reg_date;
            public string visible;
            public string xname;
        }

        public class Stage
        {
            public string amt;
            public string applicantID;
            public string data_status;
            public string ID;
            public string reg_date;
            public string stage;
            public string status;
            public string validationID;
        }

        public class State
        {
            public string countryID;
            public string ID;
            public string name;
        }
    }
}

