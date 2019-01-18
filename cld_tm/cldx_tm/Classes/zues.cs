using cld.model;
using Odyssey;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;

using System.Linq;

using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace cld.Classes
{
 
   

    public class zues
    {
        public string a_contact_form(Contact_form cf)
        {
            string str = "";
           
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO contact_form (pwalletID,response_deadline,xofficerID,xmsg,sent_status,reg_date,xvisible) VALUES (@pwalletID,@response_deadline,@xofficerID,@xmsg,@sent_status,@reg_date,@xvisible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@pwalletID", SqlDbType.VarChar, 50);
            command.Parameters.Add("@response_deadline", SqlDbType.VarChar, 50);
            command.Parameters.Add("@xofficerID", SqlDbType.VarChar);
            command.Parameters.Add("@xmsg", SqlDbType.Text);
            command.Parameters.Add("@sent_status", SqlDbType.VarChar, 1);
            command.Parameters.Add("@reg_date", SqlDbType.VarChar, 50);
            command.Parameters.Add("@xvisible", SqlDbType.VarChar, 1);
            command.Parameters["@pwalletID"].Value = cf.pwalletID;
            command.Parameters["@response_deadline"].Value = cf.response_deadline;
            command.Parameters["@xofficerID"].Value = cf.xofficerID;
            command.Parameters["@xmsg"].Value = cf.xmsg;
            command.Parameters["@sent_status"].Value = cf.sent_status;
            command.Parameters["@reg_date"].Value = cf.reg_date;
            command.Parameters["@xvisible"].Value = cf.xvisible;
            str = command.ExecuteScalar().ToString();
            connection.Close();
            return str;
        }

        public Recordal_Result InsertRecordal(string old_applicant, string new_applicant, string logstaff,string vamount,string vtransid, string description)
        {
            Retriever ret2 = new Retriever();
            XObjs.Pwallet pw = ret2.getPwalletByID2(logstaff);
            
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Recordal (OLD_APPLICANTNAME,NEW_APPLICANTNAME,RECORDAL_REQUEST_DATE,RECORDAL_APPROVE_DATE,LOG_STAFF,STATUS,AMOUNT,TRANSACTIONID,RECORDAL_TYPE,data_status,data_status2,Description) VALUES (@OLD_APPLICANTNAME,@NEW_APPLICANTNAME,@RECORDAL_REQUEST_DATE,@RECORDAL_APPROVE_DATE,@LOG_STAFF,@STATUS,@AMOUNT,@TRANSACTIONID,@RECORDAL_TYPE,@data_status,@data_status2,@Description) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@OLD_APPLICANTNAME", SqlDbType.VarChar, 50);
            command.Parameters.Add("@NEW_APPLICANTNAME", SqlDbType.VarChar, 50);
            command.Parameters.Add("@RECORDAL_REQUEST_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@RECORDAL_APPROVE_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@LOG_STAFF", SqlDbType.VarChar, 50);
            command.Parameters.Add("@STATUS", SqlDbType.VarChar, 50);
            command.Parameters.Add("@AMOUNT", SqlDbType.VarChar, 50);
            command.Parameters.Add("@TRANSACTIONID", SqlDbType.VarChar, 50);
            command.Parameters.Add("@RECORDAL_TYPE", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status2", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Description", SqlDbType.VarChar, 500);
            
            command.Parameters["@OLD_APPLICANTNAME"].Value = old_applicant;
            command.Parameters["@Description"].Value = description;
            command.Parameters["@NEW_APPLICANTNAME"].Value = new_applicant;
            command.Parameters["@RECORDAL_REQUEST_DATE"].Value = DateTime.Now;
            command.Parameters["@LOG_STAFF"].Value = logstaff;
            command.Parameters["@STATUS"].Value = "Pending";
            command.Parameters["@AMOUNT"].Value = vamount;
            command.Parameters["@TRANSACTIONID"].Value = vtransid;
            command.Parameters["@RECORDAL_TYPE"].Value = "Change_Name";

            command.Parameters["@data_status"].Value = pw.data_status;
            command.Parameters["@data_status2"].Value = pw.status;
            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            str = command.ExecuteScalar().ToString();
            connection.Close();
            update_RecordalStatus3(str, "1", "Recordal");
          //  g_pwalletStatus(logstaff, "1", "Recordal");
        string vf =    getG_PwalletTransID(logstaff);

        Recordal_Result ks = new Recordal_Result();
        ks.Recordal_Id = str;
        ks.TransactionId = vf;
        return ks;
        }

        public Recordal_Result InsertRecordalB(string old_applicant, string new_applicant, string logstaff, string vamount, string vtransid, string description, string new_applicant3, string old_applicant3,string vfile1, string vfile2, string vfile3)
        {
            Retriever ret2 = new Retriever();
            XObjs.Pwallet pw = ret2.getPwalletByID2(logstaff);

            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Recordal (OLD_APPLICANTNAME,NEW_APPLICANTNAME,RECORDAL_REQUEST_DATE,RECORDAL_APPROVE_DATE,LOG_STAFF,STATUS,AMOUNT,TRANSACTIONID,RECORDAL_TYPE,data_status,data_status2,Description,OLD_APPLICANTADDRESS,NEW_APPLICANTADDRESS,UPLOADPATH,UPLOADPATH2,UPLOADPATH3) VALUES (@OLD_APPLICANTNAME,@NEW_APPLICANTNAME,@RECORDAL_REQUEST_DATE,@RECORDAL_APPROVE_DATE,@LOG_STAFF,@STATUS,@AMOUNT,@TRANSACTIONID,@RECORDAL_TYPE,@data_status,@data_status2,@Description,@OLD_APPLICANTADDRESS,@NEW_APPLICANTADDRESS,@UPLOADPATH,@UPLOADPATH2,@UPLOADPATH3) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@OLD_APPLICANTNAME", SqlDbType.VarChar, 50);
            command.Parameters.Add("@NEW_APPLICANTNAME", SqlDbType.VarChar, 50);
            command.Parameters.Add("@OLD_APPLICANTADDRESS", SqlDbType.VarChar, 50);
            command.Parameters.Add("@NEW_APPLICANTADDRESS", SqlDbType.VarChar, 50);
            command.Parameters.Add("@RECORDAL_REQUEST_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@RECORDAL_APPROVE_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@LOG_STAFF", SqlDbType.VarChar, 50);
            command.Parameters.Add("@STATUS", SqlDbType.VarChar, 50);
            command.Parameters.Add("@AMOUNT", SqlDbType.VarChar, 50);
            command.Parameters.Add("@TRANSACTIONID", SqlDbType.VarChar, 50);
            command.Parameters.Add("@RECORDAL_TYPE", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status2", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Description", SqlDbType.VarChar, 500);
            command.Parameters.Add("@UPLOADPATH", SqlDbType.VarChar, 500);
            command.Parameters.Add("@UPLOADPATH2", SqlDbType.VarChar, 500);
            command.Parameters.Add("@UPLOADPATH3", SqlDbType.VarChar, 500);

            command.Parameters["@OLD_APPLICANTNAME"].Value = old_applicant;
            command.Parameters["@Description"].Value = description;
            command.Parameters["@NEW_APPLICANTNAME"].Value = new_applicant;
            command.Parameters["@OLD_APPLICANTADDRESS"].Value = old_applicant3;
            command.Parameters["@NEW_APPLICANTADDRESS"].Value = new_applicant3;
            command.Parameters["@RECORDAL_REQUEST_DATE"].Value = DateTime.Now;
            command.Parameters["@LOG_STAFF"].Value = logstaff;
            command.Parameters["@STATUS"].Value = "Pending";
            command.Parameters["@AMOUNT"].Value = vamount;
            command.Parameters["@TRANSACTIONID"].Value = vtransid;
            command.Parameters["@RECORDAL_TYPE"].Value = "registered_user";

            command.Parameters["@data_status"].Value = pw.data_status;
            command.Parameters["@data_status2"].Value = pw.status;
            command.Parameters["@UPLOADPATH"].Value =vfile1;
            command.Parameters["@UPLOADPATH2"].Value = vfile2;
            command.Parameters["@UPLOADPATH3"].Value = vfile3;
            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            str = command.ExecuteScalar().ToString();
            connection.Close();
            update_RecordalStatus3(str, "1", "Recordal");
            //  g_pwalletStatus(logstaff, "1", "Recordal");
            string vf = getG_PwalletTransID(logstaff);

            Recordal_Result ks = new Recordal_Result();
            ks.Recordal_Id = str;
            ks.TransactionId = vf;
            return ks;
        }

        public Recordal_Result InsertRecordal2(string old_applicant, string new_applicant, string logstaff, string vamount, string vtransid, string description)
        {
            string str = "";
            Retriever ret2 = new Retriever();
            XObjs.Pwallet pw = ret2.getPwalletByID2(logstaff);
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Recordal (OLD_APPLICANTADDRESS,NEW_APPLICANTADDRESS,RECORDAL_REQUEST_DATE,RECORDAL_APPROVE_DATE,LOG_STAFF,STATUS,AMOUNT,TRANSACTIONID,RECORDAL_TYPE,data_status,data_status2,Description) VALUES (@OLD_APPLICANTNAME,@NEW_APPLICANTNAME,@RECORDAL_REQUEST_DATE,@RECORDAL_APPROVE_DATE,@LOG_STAFF,@STATUS,@AMOUNT,@TRANSACTIONID,@RECORDAL_TYPE,@data_status,@data_status2,@Description) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@OLD_APPLICANTNAME", SqlDbType.VarChar, 500);
            command.Parameters.Add("@NEW_APPLICANTNAME", SqlDbType.VarChar, 500);
            command.Parameters.Add("@Description", SqlDbType.VarChar, 500);

            
            command.Parameters.Add("@RECORDAL_REQUEST_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@RECORDAL_APPROVE_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@LOG_STAFF", SqlDbType.VarChar, 50);
            command.Parameters.Add("@STATUS", SqlDbType.VarChar, 50);
            command.Parameters.Add("@AMOUNT", SqlDbType.VarChar, 50);
            command.Parameters.Add("@TRANSACTIONID", SqlDbType.VarChar, 50);
            command.Parameters.Add("@RECORDAL_TYPE", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status2", SqlDbType.VarChar, 50);

            command.Parameters["@Description"].Value = description;
            command.Parameters["@OLD_APPLICANTNAME"].Value = old_applicant;
            command.Parameters["@NEW_APPLICANTNAME"].Value = new_applicant;
            command.Parameters["@RECORDAL_REQUEST_DATE"].Value = DateTime.Now;
            command.Parameters["@LOG_STAFF"].Value = logstaff;
            command.Parameters["@STATUS"].Value = "Pending";
            command.Parameters["@AMOUNT"].Value = vamount;
            command.Parameters["@TRANSACTIONID"].Value = vtransid;
            command.Parameters["@RECORDAL_TYPE"].Value = "Change_Address";
            command.Parameters["@data_status"].Value = pw.data_status;
            command.Parameters["@data_status2"].Value = pw.status;

            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            str = command.ExecuteScalar().ToString();
            connection.Close();
            update_RecordalStatus3(str, "1", "Recordal");
          //  g_pwalletStatus(logstaff, "1", "Recordal");
            string vf = getG_PwalletTransID(logstaff);
            Recordal_Result ks = new Recordal_Result();
            ks.Recordal_Id = str;
            ks.TransactionId = vf;
            return ks;
        }

        public string  PendingAppeal(string docid, string regid, string comment, string agentid, string filepath)
        {
            string str = "";
            Retriever ret2 = new Retriever();
           // XObjs.Pwallet pw = ret2.getPwalletByID2(logstaff);
            SqlConnection connection = new SqlConnection(this.Connect());

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO AppealRejection (DocumentId,RegId,Comment,agentid,DateUploaded,FilePath,Status) VALUES (@DocumentId,@RegId,@Comment,@agentid,@DateUploaded,@FilePath,@Status) SELECT SCOPE_IDENTITY()";
            connection.Open();

            //connection.Open();
            command.Parameters.Add("@DocumentId", SqlDbType.VarChar, 50);
            command.Parameters.Add("@RegId", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Comment", SqlDbType.VarChar, 500);
            command.Parameters.Add("@agentid", SqlDbType.VarChar, 50);


            command.Parameters.Add("@DateUploaded", SqlDbType.VarChar, 50);

            command.Parameters.Add("@FilePath", SqlDbType.VarChar, 100);

            command.Parameters.Add("@Status", SqlDbType.VarChar, 50);

            command.Parameters["@DocumentId"].Value = docid;

            command.Parameters["@RegId"].Value = regid;

            command.Parameters["@Comment"].Value = comment;

            command.Parameters["@agentid"].Value = agentid;

            command.Parameters["@DateUploaded"].Value = DateTime.Now.ToString();

            command.Parameters["@FilePath"].Value = filepath;

            command.Parameters["@Status"].Value = "Pending";


            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

                str = command.ExecuteScalar().ToString();
          
            connection.Close();


            /*command.Parameters.Add("@OLD_AGENTNAME", SqlDbType.VarChar, 50);
            command.Parameters.Add("@NEW_AGENTNAME", SqlDbType.VarChar, 50);
            command.Parameters.Add("@RECORDAL_REQUEST_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@RECORDAL_APPROVE_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@LOG_STAFF", SqlDbType.VarChar, 50);
            command.Parameters.Add("@STATUS", SqlDbType.VarChar, 50);
            command.Parameters.Add("@AMOUNT", SqlDbType.VarChar, 50);
            command.Parameters.Add("@TRANSACTIONID", SqlDbType.VarChar, 50);
            command.Parameters.Add("@RECORDAL_TYPE", SqlDbType.VarChar, 50);
            command.Parameters.Add("@OLD_AGENTCODE", SqlDbType.VarChar, 50);
            command.Parameters.Add("@NEW_AGENTCODE", SqlDbType.VarChar, 50);
            command.Parameters.Add("@OLD_AGENTEMAIL", SqlDbType.VarChar, 50);
            command.Parameters.Add("@NEW_AGENTEMAIL", SqlDbType.VarChar, 50);

            command.Parameters.Add("@OLDAGENT_ADDRESS", SqlDbType.VarChar, 50);

            command.Parameters.Add("@NEWAGENT_ADDRESS", SqlDbType.VarChar, 50);

            command.Parameters.Add("OLD_AGENTPHONE", SqlDbType.VarChar, 50);

            command.Parameters.Add("NEW_AGENTPHONE", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status2", SqlDbType.VarChar, 50);

            command.Parameters["@OLD_AGENTNAME"].Value = old_agent_name;
            command.Parameters["@NEW_AGENTNAME"].Value = new_agent_name;
            command.Parameters["@RECORDAL_REQUEST_DATE"].Value = DateTime.Now;
            command.Parameters["@LOG_STAFF"].Value = logstaff;
            command.Parameters["@STATUS"].Value = "Pending";
            command.Parameters["@AMOUNT"].Value = vamount;
            command.Parameters["@TRANSACTIONID"].Value = vtransid;
            command.Parameters["@RECORDAL_TYPE"].Value = "Change_Agent";

            command.Parameters["@OLD_AGENTCODE"].Value = old_agentcode;
            command.Parameters["@NEW_AGENTCODE"].Value = new_agentcode;
            command.Parameters["@OLD_AGENTEMAIL"].Value = old_email;
            command.Parameters["@NEW_AGENTEMAIL"].Value = new_email;
            command.Parameters["@OLD_AGENTPHONE"].Value = old_agentmobile;
            command.Parameters["@NEW_AGENTPHONE"].Value = new_agentmobile;

            command.Parameters["@OLDAGENT_ADDRESS"].Value = old_agentaddress;
            command.Parameters["@NEWAGENT_ADDRESS"].Value = new_agentaddress;
            command.Parameters["@data_status"].Value = pw.data_status;
            command.Parameters["@data_status2"].Value = pw.status;


            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }*/
            
            return str;
        }

        public Recordal_Result InsertRecordal3(string old_agent_name, string new_agent_name, string logstaff, string vamount, string vtransid, string old_agentcode, string new_agentcode, string old_agentaddress, string new_agentaddress, string old_agentmobile, string new_agentmobile, string old_email, string new_email, string UPLOADPATH)
        {
            string str = "";
            Retriever ret2 = new Retriever();
            XObjs.Pwallet pw = ret2.getPwalletByID2(logstaff);
            SqlConnection connection = new SqlConnection(this.Connect());

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Recordal (OLD_AGENTNAME,NEW_AGENTNAME,RECORDAL_REQUEST_DATE,RECORDAL_APPROVE_DATE,LOG_STAFF,STATUS,AMOUNT,TRANSACTIONID,RECORDAL_TYPE,OLD_AGENTCODE,NEW_AGENTCODE,OLD_AGENTEMAIL,NEW_AGENTEMAIL,OLD_AGENTPHONE,NEW_AGENTPHONE,OLDAGENT_ADDRESS,NEWAGENT_ADDRESS,data_status,data_status2,UPLOADPATH) VALUES (@OLD_AGENTNAME,@NEW_AGENTNAME,'" + DateTime.Now + "','" + DateTime.Now + "','" + logstaff + "','pending','" + vamount + "','" + vtransid + "','Change_Agent','" + old_agentcode + "','" + new_agentcode + "','" + old_email + "','" + new_email + "','" + old_agentmobile + "','" + new_agentmobile + "',@OLDAGENT_ADDRESS,@NEWAGENT_ADDRESS,'" + pw.data_status + "','" + pw.status + "' ,'" +UPLOADPATH + "') SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@OLD_AGENTNAME", SqlDbType.VarChar, 50);
            command.Parameters.Add("@NEW_AGENTNAME", SqlDbType.VarChar, 50);
          //  command.Parameters.Add("@RECORDAL_REQUEST_DATE", SqlDbType.DateTime);
           // command.Parameters.Add("@RECORDAL_APPROVE_DATE", SqlDbType.DateTime);
           // command.Parameters.Add("@LOG_STAFF", SqlDbType.VarChar, 50);
           // command.Parameters.Add("@STATUS", SqlDbType.VarChar, 50);
          //  command.Parameters.Add("@AMOUNT", SqlDbType.VarChar, 50);
           // command.Parameters.Add("@TRANSACTIONID", SqlDbType.VarChar, 50);
           // command.Parameters.Add("@RECORDAL_TYPE", SqlDbType.VarChar, 50);
           // command.Parameters.Add("@OLD_AGENTCODE", SqlDbType.VarChar, 50);
           // command.Parameters.Add("@NEW_AGENTCODE", SqlDbType.VarChar, 50);
          //  command.Parameters.Add("@OLD_AGENTEMAIL", SqlDbType.VarChar, 50);
           // command.Parameters.Add("@NEW_AGENTEMAIL", SqlDbType.VarChar, 50);

            command.Parameters.Add("@OLDAGENT_ADDRESS", SqlDbType.VarChar, 50);

            command.Parameters.Add("@NEWAGENT_ADDRESS", SqlDbType.VarChar, 50);

         //   command.Parameters.Add("OLD_AGENTPHONE", SqlDbType.VarChar, 50);

          //  command.Parameters.Add("NEW_AGENTPHONE", SqlDbType.VarChar, 50);
          //  command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
           // command.Parameters.Add("@data_status2", SqlDbType.VarChar, 50);

            command.Parameters["@OLD_AGENTNAME"].Value = old_agent_name;
            command.Parameters["@NEW_AGENTNAME"].Value = new_agent_name;
           // command.Parameters["@RECORDAL_REQUEST_DATE"].Value = DateTime.Now;
          //  command.Parameters["@LOG_STAFF"].Value = logstaff;
           // command.Parameters["@STATUS"].Value = "Pending";
           // command.Parameters["@AMOUNT"].Value = vamount;
           // command.Parameters["@TRANSACTIONID"].Value = vtransid;
           // command.Parameters["@RECORDAL_TYPE"].Value = "Change_Agent";

         //   command.Parameters["@OLD_AGENTCODE"].Value = old_agentcode;
          //  command.Parameters["@NEW_AGENTCODE"].Value = new_agentcode;
         //   command.Parameters["@OLD_AGENTEMAIL"].Value = old_email;
         //   command.Parameters["@NEW_AGENTEMAIL"].Value = new_email;
         //   command.Parameters["@OLD_AGENTPHONE"].Value = old_agentmobile;
          //  command.Parameters["@NEW_AGENTPHONE"].Value = new_agentmobile;

           command.Parameters["@OLDAGENT_ADDRESS"].Value = old_agentaddress;
           command.Parameters["@NEWAGENT_ADDRESS"].Value = new_agentaddress;
           // command.Parameters["@data_status"].Value = pw.data_status;
           // command.Parameters["@data_status2"].Value = pw.status;


            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            str = command.ExecuteScalar().ToString();
            connection.Close();
          //  g_pwalletStatus(logstaff, "1", "Recordal");
            update_RecordalStatus3(str, "1", "Recordal");
            string vf = getG_PwalletTransID(logstaff);
            Recordal_Result ks = new Recordal_Result();
            ks.Recordal_Id = str;
            ks.TransactionId = vf;
            return ks;
        }

        public Recordal_Result InsertRecordal4(string old_applicant, string new_applicant, string logstaff, string vamount, string vtransid, string old_logopath, string new_logopath, string logodesc,string Description)
        {
            Retriever ret2 = new Retriever();
            XObjs.Pwallet pw = ret2.getPwalletByID2(logstaff);
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Recordal (OLD_PRODUCT_TITLE,NEW_PRODUCT_TITLE,RECORDAL_REQUEST_DATE,RECORDAL_APPROVE_DATE,LOG_STAFF,STATUS,AMOUNT,TRANSACTIONID,RECORDAL_TYPE,OLD_PRODUCT_LOGO,NEW_PRODUCT_LOGO,LOGO_DESC,data_status,data_status2,Description) VALUES (@OLD_APPLICANTNAME,@NEW_APPLICANTNAME,@RECORDAL_REQUEST_DATE,@RECORDAL_APPROVE_DATE,@LOG_STAFF,@STATUS,@AMOUNT,@TRANSACTIONID,@RECORDAL_TYPE,@OLD_PRODUCT_LOGO,@NEW_PRODUCT_LOGO,@LOGO_DESC,@data_status,@data_status2,@Description) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@OLD_APPLICANTNAME", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Description", SqlDbType.VarChar, 500);
           
            command.Parameters.Add("@NEW_APPLICANTNAME", SqlDbType.VarChar, 50);
            command.Parameters.Add("@RECORDAL_REQUEST_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@RECORDAL_APPROVE_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@LOG_STAFF", SqlDbType.VarChar, 50);
            command.Parameters.Add("@STATUS", SqlDbType.VarChar, 50);
            command.Parameters.Add("@AMOUNT", SqlDbType.VarChar, 50);
            command.Parameters.Add("@TRANSACTIONID", SqlDbType.VarChar, 50);
            command.Parameters.Add("@RECORDAL_TYPE", SqlDbType.VarChar, 50);
            command.Parameters.Add("@OLD_PRODUCT_LOGO", SqlDbType.VarChar, 50);
            command.Parameters.Add("@NEW_PRODUCT_LOGO", SqlDbType.VarChar, 50);
            command.Parameters.Add("@LOGO_DESC", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status2", SqlDbType.VarChar, 50);
            
            command.Parameters["@OLD_APPLICANTNAME"].Value = old_applicant;
            command.Parameters["@Description"].Value = Description;

            
            command.Parameters["@NEW_APPLICANTNAME"].Value = new_applicant;
            command.Parameters["@RECORDAL_REQUEST_DATE"].Value = DateTime.Now;
            command.Parameters["@LOG_STAFF"].Value = logstaff;
            command.Parameters["@STATUS"].Value = "Pending";
            command.Parameters["@AMOUNT"].Value = vamount;
            command.Parameters["@TRANSACTIONID"].Value = vtransid;
            command.Parameters["@RECORDAL_TYPE"].Value = "Change_Rectification";
            command.Parameters["@OLD_PRODUCT_LOGO"].Value = old_logopath;

            command.Parameters["@NEW_PRODUCT_LOGO"].Value = new_logopath;
            command.Parameters["@LOGO_DESC"].Value = logodesc;
            command.Parameters["@data_status"].Value = pw.data_status;
            command.Parameters["@data_status2"].Value = pw.status;
            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            str = command.ExecuteScalar().ToString();
            connection.Close();
            update_RecordalStatus3(str, "1", "Recordal");
         //   g_pwalletStatus(logstaff, "1", "Recordal");
            string vf = getG_PwalletTransID(logstaff);

            Recordal_Result ks = new Recordal_Result();
            ks.Recordal_Id = str;
            ks.TransactionId = vf;
            return ks;
        }

        public Recordal_Result InsertRecordal6(string logstaff, string vamount, string vtransid, string Detail_Id,string Description)
        {
            Retriever ret2 = new Retriever();
            XObjs.Pwallet pw = ret2.getPwalletByID2(logstaff);
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Recordal (RECORDAL_REQUEST_DATE,LOG_STAFF,STATUS,AMOUNT,TRANSACTIONID,RECORDAL_TYPE,Detail_Id,data_status,data_status2,Description) VALUES (@RECORDAL_REQUEST_DATE,@LOG_STAFF,@STATUS,@AMOUNT,@TRANSACTIONID,@RECORDAL_TYPE,@Detail_Id,@data_status,@data_status2,@Description) SELECT SCOPE_IDENTITY()";
            connection.Open();
           
            command.Parameters.Add("@RECORDAL_REQUEST_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@RECORDAL_APPROVE_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@LOG_STAFF", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Description", SqlDbType.VarChar, 500);
            
            command.Parameters.Add("@STATUS", SqlDbType.VarChar, 50);
            command.Parameters.Add("@AMOUNT", SqlDbType.VarChar, 50);
            command.Parameters.Add("@TRANSACTIONID", SqlDbType.VarChar, 50);
            command.Parameters.Add("@RECORDAL_TYPE", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Detail_Id", SqlDbType.VarChar, 50);

            command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status2", SqlDbType.VarChar, 50);
            
            command.Parameters["@RECORDAL_REQUEST_DATE"].Value = DateTime.Now;
            command.Parameters["@LOG_STAFF"].Value = logstaff;

            command.Parameters["@Description"].Value = Description;

            
            command.Parameters["@STATUS"].Value = "Pending";
            command.Parameters["@AMOUNT"].Value = vamount;
            command.Parameters["@TRANSACTIONID"].Value = vtransid;
            command.Parameters["@RECORDAL_TYPE"].Value = "Change_Assignment";

            command.Parameters["@Detail_Id"].Value = Detail_Id;

            command.Parameters["@data_status"].Value = pw.data_status;
            command.Parameters["@data_status2"].Value = pw.status;
          
            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            str = command.ExecuteScalar().ToString();
            connection.Close();
            update_RecordalStatus3(str, "1", "Recordal");
          //  g_pwalletStatus(logstaff, "1", "Recordal");
            string vf = getG_PwalletTransID(logstaff);

            Recordal_Result ks = new Recordal_Result();
            ks.Recordal_Id = str;
            ks.TransactionId = vf;
            return ks;
        }

        public Recordal_Result InsertRecordal8(string logstaff, string vamount, string vtransid, string Detail_Id,string Description)
        {
            Retriever ret2 = new Retriever();
            XObjs.Pwallet pw = ret2.getPwalletByID2(logstaff);
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Recordal (RECORDAL_REQUEST_DATE,LOG_STAFF,STATUS,AMOUNT,TRANSACTIONID,RECORDAL_TYPE,Detail_Id,data_status,data_status2,Description) VALUES (@RECORDAL_REQUEST_DATE,@LOG_STAFF,@STATUS,@AMOUNT,@TRANSACTIONID,@RECORDAL_TYPE,@Detail_Id,@data_status,@data_status2,@Description) SELECT SCOPE_IDENTITY()";
            connection.Open();

            command.Parameters.Add("@RECORDAL_REQUEST_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@RECORDAL_APPROVE_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@LOG_STAFF", SqlDbType.VarChar, 50);

            command.Parameters.Add("@Description", SqlDbType.VarChar, 500);

            
            command.Parameters.Add("@STATUS", SqlDbType.VarChar, 50);
            command.Parameters.Add("@AMOUNT", SqlDbType.VarChar, 50);
            command.Parameters.Add("@TRANSACTIONID", SqlDbType.VarChar, 50);
            command.Parameters.Add("@RECORDAL_TYPE", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Detail_Id", SqlDbType.VarChar, 50);

            command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status2", SqlDbType.VarChar, 50);

            command.Parameters["@RECORDAL_REQUEST_DATE"].Value = DateTime.Now;
            command.Parameters["@LOG_STAFF"].Value = logstaff;
            command.Parameters["@Description"].Value = Description;
            command.Parameters["@STATUS"].Value = "Pending";
            command.Parameters["@AMOUNT"].Value = vamount;
            command.Parameters["@TRANSACTIONID"].Value = vtransid;
            command.Parameters["@RECORDAL_TYPE"].Value = "Change_Renewal";

            command.Parameters["@Detail_Id"].Value = Detail_Id;

            command.Parameters["@data_status"].Value = pw.data_status;
            command.Parameters["@data_status2"].Value = pw.status;

            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            str = command.ExecuteScalar().ToString();
            connection.Close();
            update_RecordalStatus3(str, "1", "Recordal");
            //  g_pwalletStatus(logstaff, "1", "Recordal");
            string vf = getG_PwalletTransID(logstaff);

            Recordal_Result ks = new Recordal_Result();
            ks.Recordal_Id = str;
            ks.TransactionId = vf;
            return ks;
        }

        public Recordal_Result InsertRecordal7(string logstaff, string vamount, string vtransid, string Detail_Id, string Description)
        {
            Retriever ret2 = new Retriever();
            XObjs.Pwallet pw = ret2.getPwalletByID2(logstaff);
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Recordal (RECORDAL_REQUEST_DATE,LOG_STAFF,STATUS,AMOUNT,TRANSACTIONID,RECORDAL_TYPE,Detail_Id,data_status,data_status2,Description) VALUES (@RECORDAL_REQUEST_DATE,@LOG_STAFF,@STATUS,@AMOUNT,@TRANSACTIONID,@RECORDAL_TYPE,@Detail_Id,@data_status,@data_status2,@Description) SELECT SCOPE_IDENTITY()";
            connection.Open();

            command.Parameters.Add("@RECORDAL_REQUEST_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@RECORDAL_APPROVE_DATE", SqlDbType.DateTime);
            command.Parameters.Add("@LOG_STAFF", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Description", SqlDbType.VarChar, 500);
            
            command.Parameters.Add("@STATUS", SqlDbType.VarChar, 50);
            command.Parameters.Add("@AMOUNT", SqlDbType.VarChar, 50);
            command.Parameters.Add("@TRANSACTIONID", SqlDbType.VarChar, 50);
            command.Parameters.Add("@RECORDAL_TYPE", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Detail_Id", SqlDbType.VarChar, 50);

            command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status2", SqlDbType.VarChar, 50);

            command.Parameters["@RECORDAL_REQUEST_DATE"].Value = DateTime.Now;
            command.Parameters["@LOG_STAFF"].Value = logstaff;
            command.Parameters["@Description"].Value = Description;
            
            command.Parameters["@STATUS"].Value = "Pending";
            command.Parameters["@AMOUNT"].Value = vamount;
            command.Parameters["@TRANSACTIONID"].Value = vtransid;
            command.Parameters["@RECORDAL_TYPE"].Value = "Change_Assignment2";

            command.Parameters["@Detail_Id"].Value = Detail_Id;

            command.Parameters["@data_status"].Value = pw.data_status;
            command.Parameters["@data_status2"].Value = pw.status;

            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            str = command.ExecuteScalar().ToString();
            connection.Close();
            update_RecordalStatus3(str, "1", "Recordal");
            //  g_pwalletStatus(logstaff, "1", "Recordal");
            string vf = getG_PwalletTransID(logstaff);

            Recordal_Result ks = new Recordal_Result();
            ks.Recordal_Id = str;
            ks.TransactionId = vf;
            return ks;
        }

        public string InsertRecordal5(string oldApplicantName, string newApplicantName, string newApplicantAddress, string oldApplicantAddress, string newApplicantNationality, string OldApplicantNationality, string newApplicantDescription, string status, string status2, string assignment_upload, string Assignee_upload, string deed_Assignment_upload, string Power_of_Attorney_upload, string Registration_of_Mark_upload, string Assignment_Date, string Day, string Month, string Year, string Registrar_direction, string advertisements_complying, string publication, string name_certificate)
        {
            string str = "";
            Retriever px = new Retriever();
          //  string ssp = px.getCountryId(newApplicantNationality);
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Recordal2 (oldApplicantName,newApplicantName,newApplicantAddress,oldApplicantAddress,newApplicantNationality,OldApplicantNationality,newApplicantDescription,status,status2,assignment_upload,Assignee_upload,deed_Assignment_upload,Power_of_Attorney_upload,Registration_of_Mark_upload,Assignment_Date,Day,Month,Year,Registrar_direction,advertisements_complying,publication,name_certificate) VALUES (@oldApplicantName,@newApplicantName,@newApplicantAddress,@oldApplicantAddress,@newApplicantNationality,@OldApplicantNationality,@newApplicantDescription,@status,@status2,@assignment_upload,@Assignee_upload,@deed_Assignment_upload,@Power_of_Attorney_upload,@Registration_of_Mark_upload,@Assignment_Date,@Day,@Month,@Year,@Registrar_direction,@advertisements_complying,@publication,@name_certificate) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@oldApplicantName", SqlDbType.VarChar, 50);
            command.Parameters.Add("@newApplicantName", SqlDbType.VarChar, 50);
            command.Parameters.Add("@newApplicantAddress", SqlDbType.VarChar, 200);
            command.Parameters.Add("@oldApplicantAddress", SqlDbType.VarChar, 200);
            command.Parameters.Add("@newApplicantNationality", SqlDbType.VarChar, 50);
            command.Parameters.Add("@OldApplicantNationality", SqlDbType.VarChar, 50);
            command.Parameters.Add("@newApplicantDescription", SqlDbType.VarChar, 50);
            command.Parameters.Add("@status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@status2", SqlDbType.VarChar, 50);
            command.Parameters.Add("@assignment_upload", SqlDbType.VarChar, 500);
            command.Parameters.Add("@Assignee_upload", SqlDbType.VarChar, 500);
            command.Parameters.Add("@deed_Assignment_upload", SqlDbType.VarChar, 500);
            command.Parameters.Add("@Power_of_Attorney_upload", SqlDbType.VarChar, 500);
            command.Parameters.Add("@Registration_of_Mark_upload", SqlDbType.VarChar, 500);

            command.Parameters.Add("@name_certificate", SqlDbType.VarChar, 500);
         
          
            command.Parameters.Add("@Assignment_Date", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Day", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Month", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Year", SqlDbType.VarChar, 50);

            command.Parameters.Add("@Registrar_direction", SqlDbType.VarChar, 500);

            command.Parameters.Add("@advertisements_complying", SqlDbType.VarChar, 500);

            command.Parameters.Add("@publication", SqlDbType.VarChar, 500);

         //   command.Parameters.Add("@advertisements_upload", SqlDbType.VarChar, 50);

            command.Parameters["@name_certificate"].Value = name_certificate;

            command.Parameters["@oldApplicantName"].Value = oldApplicantName;
            command.Parameters["@newApplicantName"].Value = newApplicantName;
            command.Parameters["@newApplicantAddress"].Value = newApplicantAddress;
            command.Parameters["@oldApplicantAddress"].Value = oldApplicantAddress;
            command.Parameters["@newApplicantDescription"].Value = newApplicantDescription;
            command.Parameters["@status"].Value = status;
            command.Parameters["@status2"].Value = status2;
            command.Parameters["@assignment_upload"].Value = assignment_upload;
            command.Parameters["@Assignee_upload"].Value = Assignee_upload;
            command.Parameters["@deed_Assignment_upload"].Value = deed_Assignment_upload;

            command.Parameters["@OldApplicantNationality"].Value = OldApplicantNationality;
            command.Parameters["@newApplicantNationality"].Value = newApplicantNationality;

            command.Parameters["@Power_of_Attorney_upload"].Value = Power_of_Attorney_upload;
            command.Parameters["@Registration_of_Mark_upload"].Value = Registration_of_Mark_upload;

            command.Parameters["@Assignment_Date"].Value = Assignment_Date;

            command.Parameters["@Day"].Value = Day;

            command.Parameters["@Month"].Value = Month;
            command.Parameters["@Year"].Value = Year;
            command.Parameters["@Registrar_direction"].Value = Registrar_direction;

            command.Parameters["@advertisements_complying"].Value = advertisements_complying;

            command.Parameters["@publication"].Value = publication;

         //   command.Parameters["@advertisements_upload"].Value = advertisements_upload;

            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            str = command.ExecuteScalar().ToString();
            connection.Close();
           // g_pwalletStatus(logstaff, "1", "Recordal");
           // string vf = getG_PwalletTransID(logstaff);
            return str;
        }

        public string InsertRecordal55(string ApplicantName, string ApplicantAddress, string Product_title, string reg_date, string renewal_date, string renewal_type, string Certificate_Of_Registration, string power_of_attorney)
        {
            string str = "";
            Retriever px = new Retriever();
            //  string ssp = px.getCountryId(newApplicantNationality);
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Recordal3 (Renewal_DueDate,Renewal_Type,power_of_attorney,Certificate_Of_Registration,Applicant_name,Applicant_Address,Reg_Date) VALUES (@Renewal_DueDate,@Renewal_Type,@power_of_attorney,@Certificate_Of_Registration,@Applicant_name,@Applicant_Address,@Reg_Date) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@Renewal_DueDate", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Renewal_Type", SqlDbType.VarChar, 50);
            command.Parameters.Add("@power_of_attorney", SqlDbType.VarChar, 500);
            command.Parameters.Add("@Certificate_Of_Registration", SqlDbType.VarChar, 500);
            command.Parameters.Add("@Applicant_name", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Applicant_Address", SqlDbType.VarChar, 200);
            command.Parameters.Add("@Reg_Date", SqlDbType.VarChar, 50);
            

            //   command.Parameters.Add("@advertisements_upload", SqlDbType.VarChar, 50);

            command.Parameters["@Renewal_DueDate"].Value = renewal_date;

            command.Parameters["@Renewal_Type"].Value = renewal_type;
            command.Parameters["@power_of_attorney"].Value = power_of_attorney;
            command.Parameters["@Certificate_Of_Registration"].Value = Certificate_Of_Registration;
            command.Parameters["@Applicant_name"].Value = ApplicantName;
            command.Parameters["@Applicant_Address"].Value = ApplicantAddress;
            command.Parameters["@Reg_Date"].Value = reg_date;
          

            //   command.Parameters["@advertisements_upload"].Value = advertisements_upload;

            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }
            str = command.ExecuteScalar().ToString();
            connection.Close();
            // g_pwalletStatus(logstaff, "1", "Recordal");
            // string vf = getG_PwalletTransID(logstaff);
            return str;
        }


        public string ConnectXpay()
        {
            return ConfigurationManager.ConnectionStrings["xpayConnectionString"].ConnectionString;
        }


        public string a_g_tm_office(string pwalletID, string admin_status, string data_status, string xcomment, string xdoc1, string xdoc2, string xdoc3, string xofficer)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
             SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO g_tm_office (pwalletID,admin_status,data_status,xcomment,xdoc1,xdoc2,xdoc3,xofficer,reg_date,xvisible) VALUES (@pwalletID,@admin_status,@data_status,@xcomment,@xdoc1,@xdoc2,@xdoc3,@xofficer,@reg_date,@xvisible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            string str3 = DateTime.Now.ToString("yyyy-MM-dd");
            xdoc1 = xdoc1.Replace(" ", "_");
            xdoc2 = xdoc2.Replace(" ", "_");
            xdoc3 = xdoc3.Replace(" ", "_");
            command.Parameters.Add("@pwalletID", SqlDbType.VarChar, 50);
            command.Parameters.Add("@admin_status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@xcomment", SqlDbType.Text);
            command.Parameters.Add("@xdoc1", SqlDbType.Text);
            command.Parameters.Add("@xdoc2", SqlDbType.Text);
            command.Parameters.Add("@xdoc3", SqlDbType.Text);
            command.Parameters.Add("@xofficer", SqlDbType.VarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.VarChar, 50);
            command.Parameters.Add("@xvisible", SqlDbType.VarChar, 10);
            command.Parameters["@pwalletID"].Value = pwalletID;
            command.Parameters["@admin_status"].Value = admin_status;
            command.Parameters["@data_status"].Value = data_status;
            command.Parameters["@xcomment"].Value = xcomment;
            command.Parameters["@xdoc1"].Value = xdoc1;
            command.Parameters["@xdoc2"].Value = xdoc2;
            command.Parameters["@xdoc3"].Value = xdoc3;
            command.Parameters["@xofficer"].Value = xofficer;
            command.Parameters["@reg_date"].Value = str3;
            command.Parameters["@xvisible"].Value = "1";
            str = command.ExecuteScalar().ToString();
            connection.Close();
            if (str == "0")
            {
                return "0";
            }
            if (!(Convert.ToInt32(this.e_G_PwalletStatus(pwalletID, admin_status, data_status)).ToString() != "0"))
            {
                str = "0";
            }
            return str;
        }

        public void sendemail3(string vemail, string name, string comment, string Filenumber)
        {
            try
            {
                int port = 0x24b;


                MailMessage mail = new MailMessage();
                mail.From =
           new MailAddress("paymentsupport@einaosolutions.com", "noreply@iponigeria.com");
                // new MailAddress("tradeservices@fsdhgroup.com");
                mail.Priority = MailPriority.High;

                mail.To.Add(
    new MailAddress(vemail));

                //    new MailAddress("ozotony@yahoo.com"));



                //mail.CC.Add(new MailAddress("Anthony.Ozoagu@firstcitygroup.com"));

                mail.Subject = "Application Acceptance Status";

                mail.IsBodyHtml = true;
               // String ss2 = "Dear " + px2.xname + ",<br/> <br/>" + " This is to inform you that your request for Recordal update on the Trademark record with RTM number" + px3.rtm + " and File number  " + cmark.reg_number + " has been effected.<br/> <br/> Please pick up the Recordal Certificate at the Registry.  <br/> <br/>  <br/>Regards. <br/> <br/>  <br/> ";
                String ss2 = "Dear " + name + " , <br/> Your Application with File Number  " + Filenumber + "has been moved to Kiv folder in acceptance unit .Check below for last comment from officer handling it <br/>.<em>" + comment + "</em> . <br/> <br/>  <br/>Regards. <br/> <br/>  <br/> ";
                //  ss2 = ss2 + "To gain access to your account, you would need to click here <a href=\"http://88.150.164.30/IpoTest2/#/Register/" + vid + " \">click</a>   to validate your account and also make payment. " + "<br/><br/><br/>";
                ss2 = ss2 + "Please do not reply this mail. <br/> <br/> Live 24/7 Support: +234 (0)9038979681. <br/> Email: info@iponigeria.com or go online to use our live feedback form. <br/> <br/> <br/>";







                ss2 = ss2 + "<b> Disclaimer: </b>This e-mail and any attachments are confidential; it must not be read, copied, disclosed or used by any person other than the above named addressees. Unauthorized use, disclosure or copying is strictly prohibited and may be unlawful. Iponigeria.com disclaims any liability for any action taken in reliance on the content of this e-mail. The comments or statements expressed in this e-mail could be personal opinions and are not necessarily  those of iponigeria.com. If you have received this email in error or think you may have done so, you may not peruse, use, disseminate, distribute or copy this message. Please notify the sender immediately and delete the original e-mail from your system.";










                //ss2 = ss2 + "Please keep your password safe and do not share your log in details with anyone. You may change your password at your convenience. In the event that you cannot remember your password, kindly follow the instructions provided for password recovery."  + "<br/>";
                //ss2 = ss2 + "Please do not reply this mail" +  "<br/><br/>";
                //ss2 = ss2 + "Email: info@iponigeria.com or go online to use our live feedback form .<br/><br/>";

                String ss = "<html> <head> </head> <body>" + ss2 + "</body> </html>";

                //  mail.Body = ss;

                mail.Body = ss;

                SmtpClient client = new SmtpClient("88.150.164.30");
                //  SmtpClient client = new SmtpClient("192.168.0.12");

                client.Port = port;

                   client.Credentials = new System.Net.NetworkCredential("paymentsupport@einaosolutions.com", "Zues.4102.Hector");

              //  client.Credentials = new System.Net.NetworkCredential("noreply@iponigeria.com", "Einao2015@@$");



                //   new System.Net.NetworkCredential("ebusiness@firstcitygroup.com", "welcome@123");
                //   new System.Net.NetworkCredential(q60.smtp_user, q60.smtp_password);







                client.Send(mail);

            }
            catch (Exception ee)
            {
                var kk = ee.Message;

            }



        }
        public void sendemail4(string vemail, string name, string comment,string Filenumber)
        {
            try
            {
                int port = 587;


                MailMessage mail = new MailMessage();
                mail.From =
           new MailAddress("einaosoln@gmail.com", "noreply@EinaoSolutions.com");
                // new MailAddress("tradeservices@fsdhgroup.com");
                mail.Priority = MailPriority.High;

                mail.To.Add(
    new MailAddress(vemail));

                //    new MailAddress("ozotony@yahoo.com"));



                //mail.CC.Add(new MailAddress("Anthony.Ozoagu@firstcitygroup.com"));

                mail.Subject = "Application Acceptance Status";

                mail.IsBodyHtml = true;
                String ss2 = "Dear " + name +  " , <br/> Your Application with File Number  " + Filenumber + " has been moved to Kiv folder in Acceptance Unit . Check below for last comment from officer handling it <br/>.<em>"+ comment+ "</em> . <br/> <br/>  <br/>Regards. <br/> <br/>  <br/> ";
                ss2 = ss2 + "Please do not reply this mail. <br/> <br/> Live 24/7 Support: +234 (0)9038979681. <br/> Email: info@iponigeria.com or go online to use our live feedback form. <br/> <br/> <br/>";







                ss2 = ss2 + "<b> Disclaimer: </b>This e-mail and any attachments are confidential; it must not be read, copied, disclosed or used by any person other than the above named addressees. Unauthorized use, disclosure or copying is strictly prohibited and may be unlawful. Iponigeria.com disclaims any liability for any action taken in reliance on the content of this e-mail. The comments or statements expressed in this e-mail could be personal opinions and are not necessarily  those of iponigeria.com. If you have received this email in error or think you may have done so, you may not peruse, use, disseminate, distribute or copy this message. Please notify the sender immediately and delete the original e-mail from your system.";

                String ss = "<html> <head> </head> <body>" + ss2 + "</body> </html>";

                //  mail.Body = ss;

                mail.Body = ss;

                SmtpClient client = new SmtpClient("smtp.gmail.com");
                //  SmtpClient client = new SmtpClient("192.168.0.12");

                client.Port = port;

                client.EnableSsl = true;

                client.UseDefaultCredentials = false;

                //    client.Credentials = new System.Net.NetworkCredential("paymentsupport@einaosolutions.com", "Zues.4102.Hector");

                client.Credentials = new System.Net.NetworkCredential("einaosoln@gmail.com", "Einao2017");



                //   new System.Net.NetworkCredential("ebusiness@firstcitygroup.com", "welcome@123");
                //   new System.Net.NetworkCredential(q60.smtp_user, q60.smtp_password);







                client.Send(mail);

            }
            catch (Exception ee)
            {


            }



        }

        public int a_mul_tm_office(string pwalletID, string admin_status, string data_status, string xcomment, string xdoc1, string xdoc2, string xdoc3, string xofficer)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO tm_office (pwalletID,admin_status,data_status,xcomment,xdoc1,xdoc2,xdoc3,xofficer,reg_date,xvisible) VALUES (@pwalletID,@admin_status,@data_status,@xcomment,@xdoc1,@xdoc2,@xdoc3,@xofficer,@reg_date,@xvisible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            string str2 = DateTime.Now.ToString("yyyy-MM-dd");
            xdoc1 = xdoc1.Replace(" ", "_");
            xdoc2 = xdoc2.Replace(" ", "_");
            xdoc3 = xdoc3.Replace(" ", "_");
            command.Parameters.Add("@pwalletID", SqlDbType.VarChar, 50);
            command.Parameters.Add("@admin_status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@xcomment", SqlDbType.Text);
            command.Parameters.Add("@xdoc1", SqlDbType.Text);
            command.Parameters.Add("@xdoc2", SqlDbType.Text);
            command.Parameters.Add("@xdoc3", SqlDbType.Text);
            command.Parameters.Add("@xofficer", SqlDbType.VarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.VarChar, 50);
            command.Parameters.Add("@xvisible", SqlDbType.VarChar, 10);
            command.Parameters["@pwalletID"].Value = pwalletID;
            command.Parameters["@admin_status"].Value = admin_status;
            command.Parameters["@data_status"].Value = data_status;
            command.Parameters["@xcomment"].Value = xcomment;
            command.Parameters["@xdoc1"].Value = xdoc1;
            command.Parameters["@xdoc2"].Value = xdoc2;
            command.Parameters["@xdoc3"].Value = xdoc3;
            command.Parameters["@xofficer"].Value = xofficer;
            command.Parameters["@reg_date"].Value = str2;
            command.Parameters["@xvisible"].Value = "1";
            num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            if (num == 0)
            {
                return 0;
            }
            if (!(Convert.ToInt32(this.e_PwalletStatus(pwalletID, admin_status, data_status)).ToString() != "0"))
            {
                num = 0;
            }
            return num;
        }

        public string a_reg_tm_office(string pwalletID, string admin_status, string data_status, string xcomment, string xdoc1, string xdoc2, string xdoc3, string xofficer, string rtm)
        {
            string connectionString = this.Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str3 = "";
            xdoc1 = xdoc1.Replace(" ", "_");
            xdoc2 = xdoc2.Replace(" ", "_");
            xdoc3 = xdoc3.Replace(" ", "_");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_a_tm_office", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@pwalletID", pwalletID));
            command.Parameters.Add(new SqlParameter("@admin_status", admin_status));
            command.Parameters.Add(new SqlParameter("@data_status", data_status));
            command.Parameters.Add(new SqlParameter("@xcomment", xcomment));
            command.Parameters.Add(new SqlParameter("@xdoc1", xdoc1));
            command.Parameters.Add(new SqlParameter("@xdoc2", xdoc2));
            command.Parameters.Add(new SqlParameter("@xdoc3", xdoc3));
            command.Parameters.Add(new SqlParameter("@xofficer", xofficer));
            command.Parameters.Add(new SqlParameter("@reg_date", str2));
            command.Parameters.Add(new SqlParameter("@xvisible", "1"));
            SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            str3 = parameter.Value.ToString();
            connection.Close();
            if (str3 == "0")
            {
                return "0";
            }
            if (!(Convert.ToInt32(this.e_PwalletRtmStatus(pwalletID, admin_status, data_status, rtm)).ToString() != "0"))
            {
                str3 = "0";
            }
            return str3;
        }

        public string a_regadmin(string xname, string xrole, string xemail, string telephone1, string telephone2, string xsection, string pwalletID, string pass)
        {
            string connectionString = this.Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str3 = "";
            new Random();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_a_TmRegAdmin", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@xname", xname));
            command.Parameters.Add(new SqlParameter("@xroleID", xrole));
            command.Parameters.Add(new SqlParameter("@xemail", xemail));
            command.Parameters.Add(new SqlParameter("@xpass", pass));
            command.Parameters.Add(new SqlParameter("@xtelephone1", telephone1));
            command.Parameters.Add(new SqlParameter("@xtelephone2", telephone2));
            command.Parameters.Add(new SqlParameter("@xsection", xsection));
            command.Parameters.Add(new SqlParameter("@xlog_officer", pwalletID));
            command.Parameters.Add(new SqlParameter("@xreg_date", str2));
            command.Parameters.Add(new SqlParameter("@xvisible", "1"));
            SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            str3 = parameter.Value.ToString();
            connection.Close();
            return str3;
        }

        public void sendemail(cld.Classes.tm.Representative px2, cld.Classes.tm.Stage px3, cld.Classes.tm.MarkInfo cmark, cld.Classes.tm.Address crep)
        {
            try
            {
                int port = 0x24b;


                MailMessage mail = new MailMessage();
                mail.From =
           new MailAddress("noreply@iponigeria.com", "noreply@iponigeria.com");
                // new MailAddress("tradeservices@fsdhgroup.com");
                mail.Priority = MailPriority.High;

                mail.To.Add(
    new MailAddress(crep.email1));

                //    new MailAddress("ozotony@yahoo.com"));



                //mail.CC.Add(new MailAddress("Anthony.Ozoagu@firstcitygroup.com"));

                mail.Subject = "Request for Recordal Update";

                mail.IsBodyHtml = true;
                String ss2 = "Dear " + px2.xname + ",<br/> <br/>" + " This is to inform you that your request for Recordal update on the Trademark record with RTM number" + px3.rtm + " and File number  " + cmark.reg_number + " has been effected.<br/> <br/> Please pick up the Recordal Certificate at the Registry.  <br/> <br/>  <br/>Regards. <br/> <br/>  <br/> ";

                //  ss2 = ss2 + "To gain access to your account, you would need to click here <a href=\"http://88.150.164.30/IpoTest2/#/Register/" + vid + " \">click</a>   to validate your account and also make payment. " + "<br/><br/><br/>";
                ss2 = ss2 + "Please do not reply this mail. <br/> <br/> Live 24/7 Support: +234 (0)9038979681. <br/> Email: info@iponigeria.com or go online to use our live feedback form. <br/> <br/> <br/>";







                ss2 = ss2 + "<b> Disclaimer: </b>This e-mail and any attachments are confidential; it must not be read, copied, disclosed or used by any person other than the above named addressees. Unauthorized use, disclosure or copying is strictly prohibited and may be unlawful. Iponigeria.com disclaims any liability for any action taken in reliance on the content of this e-mail. The comments or statements expressed in this e-mail could be personal opinions and are not necessarily  those of iponigeria.com. If you have received this email in error or think you may have done so, you may not peruse, use, disseminate, distribute or copy this message. Please notify the sender immediately and delete the original e-mail from your system.";










                //ss2 = ss2 + "Please keep your password safe and do not share your log in details with anyone. You may change your password at your convenience. In the event that you cannot remember your password, kindly follow the instructions provided for password recovery."  + "<br/>";
                //ss2 = ss2 + "Please do not reply this mail" +  "<br/><br/>";
                //ss2 = ss2 + "Email: info@iponigeria.com or go online to use our live feedback form .<br/><br/>";

                String ss = "<html> <head> </head> <body>" + ss2 + "</body> </html>";

                //  mail.Body = ss;

                mail.Body = ss;

                SmtpClient client = new SmtpClient("88.150.164.30");
                //  SmtpClient client = new SmtpClient("192.168.0.12");

                client.Port = port;

                //    client.Credentials = new System.Net.NetworkCredential("paymentsupport@einaosolutions.com", "Zues.4102.Hector");

                client.Credentials = new System.Net.NetworkCredential("noreply@iponigeria.com", "Einao2015@@$");



                //   new System.Net.NetworkCredential("ebusiness@firstcitygroup.com", "welcome@123");
                //   new System.Net.NetworkCredential(q60.smtp_user, q60.smtp_password);







                client.Send(mail);

            }
            catch (Exception ee)
            {


            }



        }

      

        public void sendemail2(string Representativename, cld.Classes.zues.MarkInfo cmark, string emailaddress, string vcomment, string newstatus, string newdatastatus, string oldstatus, string olddatastatus, string transid)
        {

            var vapplicant = getApplicant(cmark.log_staff);

            TmOffice toffice = getLastTmOfficeByID(cmark.log_staff);
            string oldstatus2 = "";
            string olddatastatus2 = "";

            if (toffice != null)
            {
                oldstatus2 = getCurrentStage2(toffice);
                olddatastatus2 = toffice.data_status.ToUpper();
            }

            try
            {
                // int port = 0x24b;

                int port = 587;


                MailMessage mail = new MailMessage();
                mail.From =
            //new MailAddress("Einaosolution2016@gmail.com", "noreply@iponigeria.com");
            new MailAddress("einaosolution2016@gmail.com", "noreply@iponigeria.com");
                // new MailAddress("tradeservices@fsdhgroup.com");
                mail.Priority = MailPriority.High;

                mail.To.Add(
    new MailAddress(emailaddress));

                //             mail.To.Add(
                //new MailAddress("anthony.ozoagu@gmail.com"));

                //    new MailAddress("ozotony@yahoo.com"));



                //mail.CC.Add(new MailAddress("Anthony.Ozoagu@firstcitygroup.com"));

                mail.Subject = "APPLICATION STATUS UPDATE";

                mail.IsBodyHtml = true;
                String ss2 = "Dear " + Representativename + ",<br/> <br/> <br/> <br/>" + "<b> APPLICATION STATUS UPDATE </b>  <br/> <br/>  <b> Product name </b> " + cmark.product_title + "<br/> <br/> <b> Applicant name </b> " + vapplicant + "  <br/> <br/> <b> Application ID  </b>  " + transid + " <br/> <br/> <b> File number </b>  " + cmark.reg_number + "  <br/> <br/> <b> Class </b>  " + cmark.national_classID + " <br/> <br/> <b>  Former office status </b> " + oldstatus + " <br/> <br/> <b> New office status </b> " + oldstatus2 + " <br/> <br/> <b>  Old status </b>  " + olddatastatus + " <br/> <br/> <b>  New status </b> " + olddatastatus2 + " <br/> <br/> <b>  Officer’s last comment </b> " + vcomment + " <br/> <br/>     <br/> ";

                //  ss2 = ss2 + "To gain access to your account, you would need to click here <a href=\"http://88.150.164.30/IpoTest2/#/Register/" + vid + " \">click</a>   to validate your account and also make payment. " + "<br/><br/><br/>";
                ss2 = ss2 + "Please do not reply this mail. <br/> <br/> Live 24/7 Support: +234 (0)9038979681. <br/> Email: info@iponigeria.com or go online to use our live feedback form. <br/> <br/> <br/>";







                ss2 = ss2 + " Please do not reply this mail. <br/> Live 24/7 Support: +234 (0) 9038979681. <br/>  Email: info@iponigeria.com or go online to use our live feedback form. <br/>  <br/>  <br/>  <b> Disclaimer: </b>This e-mail and any attachments are confidential; it must not be read, copied, disclosed or used by any person other than the above named addressees. Unauthorized use, disclosure or copying is strictly prohibited and may be unlawful. Iponigeria.com disclaims any liability for any action taken in reliance on the content of this e-mail. The comments or statements expressed in this e-mail could be personal opinions and are not necessarily  those of iponigeria.com. If you have received this email in error or think you may have done so, you may not peruse, use, disseminate, distribute or copy this message. Please notify the sender immediately and delete the original e-mail from your system.";










                //ss2 = ss2 + "Please keep your password safe and do not share your log in details with anyone. You may change your password at your convenience. In the event that you cannot remember your password, kindly follow the instructions provided for password recovery."  + "<br/>";
                //ss2 = ss2 + "Please do not reply this mail" +  "<br/><br/>";
                //ss2 = ss2 + "Email: info@iponigeria.com or go online to use our live feedback form .<br/><br/>";

                String ss = "<html> <head> </head> <body>" + ss2 + "</body> </html>";

                //  mail.Body = ss;

                mail.Body = ss;

                //SmtpClient client = new SmtpClient("88.150.164.30");


                //client.Port = port;



                //client.Credentials = new System.Net.NetworkCredential("noreply@iponigeria.com", "Einao2015@@$");


                SmtpClient client = new SmtpClient("smtp.gmail.com");


                client.Port = port;

                client.EnableSsl = true;

                client.UseDefaultCredentials = false;

                client.Credentials = new System.Net.NetworkCredential("einaosolution2016@gmail.com", "Einao2015");

                //  client.Credentials = new System.Net.NetworkCredential("Einaosolution2016@gmail.com", "Einao2015");












                client.Send(mail);

            }
            catch (Exception ee)
            {


            }



        }

        public void sendemail12(string Representativename, string emailaddress)
        {

           

          

            try
            {
               //  int port = 0x24b;

                int port = 587;


                MailMessage mail = new MailMessage();
                mail.From =
          //new MailAddress("Einaosolution2016@gmail.com", "noreply@iponigeria.com");
           new MailAddress("einaosolution2016@gmail.com", "noreply@iponigeria.com");
        //  new MailAddress("paymentsupport@einaosolutions.com", "noreply@iponigeria.com");
                // new MailAddress("tradeservices@fsdhgroup.com");
                mail.Priority = MailPriority.High;

                mail.To.Add(
    new MailAddress(emailaddress));

                //             mail.To.Add(
                //new MailAddress("anthony.ozoagu@gmail.com"));

                //    new MailAddress("ozotony@yahoo.com"));



                //mail.CC.Add(new MailAddress("Anthony.Ozoagu@firstcitygroup.com"));

                mail.Subject = "User Creation";

                mail.IsBodyHtml = true;
                String ss2 = "Dear " + Representativename + ",<br/> <br/> <br/> <br/>" + " You have been  Created Successfully on this platform . Default password is Password2012  <br/> <br/> <br/> <br/>  ";

                //  ss2 = ss2 + "To gain access to your account, you would need to click here <a href=\"http://88.150.164.30/IpoTest2/#/Register/" + vid + " \">click</a>   to validate your account and also make payment. " + "<br/><br/><br/>";
                ss2 = ss2 + "Please do not reply this mail. <br/> <br/> Live 24/7 Support: +234 (0)9038979681. <br/> Email: info@iponigeria.com or go online to use our live feedback form. <br/> <br/> <br/>";







                ss2 = ss2 + " Please do not reply this mail. <br/> Live 24/7 Support: +234 (0) 9038979681. <br/>  Email: info@iponigeria.com or go online to use our live feedback form. <br/>  <br/>  <br/>  <b> Disclaimer: </b>This e-mail and any attachments are confidential; it must not be read, copied, disclosed or used by any person other than the above named addressees. Unauthorized use, disclosure or copying is strictly prohibited and may be unlawful. Iponigeria.com disclaims any liability for any action taken in reliance on the content of this e-mail. The comments or statements expressed in this e-mail could be personal opinions and are not necessarily  those of iponigeria.com. If you have received this email in error or think you may have done so, you may not peruse, use, disseminate, distribute or copy this message. Please notify the sender immediately and delete the original e-mail from your system.";










                //ss2 = ss2 + "Please keep your password safe and do not share your log in details with anyone. You may change your password at your convenience. In the event that you cannot remember your password, kindly follow the instructions provided for password recovery."  + "<br/>";
                //ss2 = ss2 + "Please do not reply this mail" +  "<br/><br/>";
                //ss2 = ss2 + "Email: info@iponigeria.com or go online to use our live feedback form .<br/><br/>";

                String ss = "<html> <head> </head> <body>" + ss2 + "</body> </html>";

                //  mail.Body = ss;

                mail.Body = ss;

                //SmtpClient client = new SmtpClient("88.150.164.30");


                //client.Port = port;



                //client.Credentials = new System.Net.NetworkCredential("noreply@iponigeria.com", "Einao2015@@$");


                   SmtpClient client = new SmtpClient("smtp.gmail.com");
              //  SmtpClient client = new SmtpClient("88.150.164.30");


                client.Port = port;

                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.UseDefaultCredentials = false;

                  client.Credentials = new System.Net.NetworkCredential("einaosolution2016@gmail.com", "Einao2015");
              //  client.Credentials = new System.Net.NetworkCredential("paymentsupport@einaosolutions.com", "Zues.4102.Hector");

                //  client.Credentials = new System.Net.NetworkCredential("Einaosolution2016@gmail.com", "Einao2015");












                client.Send(mail);

            }
            catch (Exception ee)
            {


            }



        }

        public string  getCurrentStage2(TmOffice lt_pwx)
        {
            string status = "";
            if (lt_pwx.admin_status == "1")
            {
                status = "Verification";
               
            }

            if (lt_pwx.admin_status == "14")
            {
                status = "Verification";

            }
            if (lt_pwx.admin_status == "2")
            {
                status = "Search";
               
            }
            if (lt_pwx.admin_status == "22")
            {
                status = "Search 2";
             
            }
            if (lt_pwx.admin_status == "3")
            {
                if (lt_pwx.data_status == "Search Conducted") {  status = "Search 2"; }
                else if (lt_pwx.data_status == "Re-examine") { status = "Examiners"; }
            }
            if (lt_pwx.admin_status == "33")
            {
                status = "Examiners";
               
            }
            if (lt_pwx.admin_status == "4")
            {
                status = "Acceptance";
               
            }
            if (lt_pwx.admin_status == "5")
            {
                if (lt_pwx.data_status == "Accepted") {  status = "Publication"; }
                else if (lt_pwx.data_status == "Deferred") {  status = "Publication"; }
            }
            if (lt_pwx.admin_status == "6")
            {
                status = "Opposition";
               
            }
            if (lt_pwx.admin_status == "7")
            {
                if (lt_pwx.data_status == "Not Opposed") { status = "Certification"; }
                else if (lt_pwx.data_status == "Deferred") {  status = "Certification"; }
            }
            if (lt_pwx.admin_status == "8")
            {
                status = "Registrars";
               
            }
            if (lt_pwx.admin_status == "9")
            {
                status = "Registrars";
              
            }

          

            return status;

        }

        public string a_tm_office(string pwalletID, string admin_status, string data_status, string xcomment, string xdoc1, string xdoc2, string xdoc3, string xofficer)
        {
            string connectionString = this.Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str3 = "";
            xdoc1 = xdoc1.Replace(" ", "_");
            xdoc2 = xdoc2.Replace(" ", "_");
            xdoc3 = xdoc3.Replace(" ", "_");
         




            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_a_tm_office", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@pwalletID", pwalletID));
            command.Parameters.Add(new SqlParameter("@admin_status", admin_status));
            command.Parameters.Add(new SqlParameter("@data_status", data_status));
            command.Parameters.Add(new SqlParameter("@xcomment", xcomment));
            command.Parameters.Add(new SqlParameter("@xdoc1", xdoc1));
            command.Parameters.Add(new SqlParameter("@xdoc2", xdoc2));
            command.Parameters.Add(new SqlParameter("@xdoc3", xdoc3));
            command.Parameters.Add(new SqlParameter("@xofficer", xofficer));
            command.Parameters.Add(new SqlParameter("@reg_date", str2));
            command.Parameters.Add(new SqlParameter("@xvisible", "1"));
            SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            str3 = parameter.Value.ToString();
            connection.Close();
            if (str3 == "0")
            {
                return "0";
            }
            if (!(Convert.ToInt32(this.e_PwalletStatus(pwalletID, admin_status, data_status)).ToString() != "0"))
            {
                str3 = "0";
            }
           // MarkInfo markinfo = getMarkInfoByUserID(pwalletID);

          //  string repname = getAgentInfo(pwalletID).Agent_Name;
           // string repemail = getAgentInfo(pwalletID).Email;
           // sendemail2(repname, markinfo, repemail, xcomment, admin_status, data_status);
            return str3;
        }

        public string a_tm_office3(string pwalletID, string admin_status, string data_status, string xcomment, string xdoc1, string xdoc2, string xdoc3, string xofficer)
        {
            string connectionString = this.Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str3 = "";
            xdoc1 = xdoc1.Replace(" ", "_");
            xdoc2 = xdoc2.Replace(" ", "_");
            xdoc3 = xdoc3.Replace(" ", "_");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_a_tm_office", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@pwalletID", pwalletID));
            command.Parameters.Add(new SqlParameter("@admin_status", admin_status));
            command.Parameters.Add(new SqlParameter("@data_status", data_status));
            command.Parameters.Add(new SqlParameter("@xcomment", xcomment));
            command.Parameters.Add(new SqlParameter("@xdoc1", xdoc1));
            command.Parameters.Add(new SqlParameter("@xdoc2", xdoc2));
            command.Parameters.Add(new SqlParameter("@xdoc3", xdoc3));
            command.Parameters.Add(new SqlParameter("@xofficer", xofficer));
            command.Parameters.Add(new SqlParameter("@reg_date", str2));
            command.Parameters.Add(new SqlParameter("@xvisible", "1"));
            SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            str3 = parameter.Value.ToString();
            connection.Close();
            if (str3 == "0")
            {
                return "0";
            }
            //if (!(Convert.ToInt32(this.e_PwalletStatus(pwalletID, admin_status, data_status)).ToString() != "0"))
            //{
            //    str3 = "0";
            //}
            return str3;
        }

        public string a_tm_office2(string pwalletID, string admin_status, string data_status, string xcomment, string xdoc1, string xdoc2, string xdoc3, string xofficer)
        {
            string connectionString = this.Connect();
            string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str3 = "";
            xdoc1 = xdoc1.Replace(" ", "_");
            xdoc2 = xdoc2.Replace(" ", "_");
            xdoc3 = xdoc3.Replace(" ", "_");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_a_tm_office", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@pwalletID", pwalletID));
            command.Parameters.Add(new SqlParameter("@admin_status", admin_status));
            command.Parameters.Add(new SqlParameter("@data_status", data_status));
            command.Parameters.Add(new SqlParameter("@xcomment", xcomment));
            command.Parameters.Add(new SqlParameter("@xdoc1", xdoc1));
            command.Parameters.Add(new SqlParameter("@xdoc2", xdoc2));
            command.Parameters.Add(new SqlParameter("@xdoc3", xdoc3));
            command.Parameters.Add(new SqlParameter("@xofficer", xofficer));
            command.Parameters.Add(new SqlParameter("@reg_date", str2));
            command.Parameters.Add(new SqlParameter("@xvisible", "1"));
            SqlParameter parameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            str3 = parameter.Value.ToString();
            connection.Close();
            if (str3 == "0")
            {
                return "0";
            }
            //if (!(Convert.ToInt32(this.e_PwalletStatus(pwalletID, admin_status, data_status)).ToString() != "0"))
            //{
            //    str3 = "0";
            //}
            return str3;
        }

        public string a_tm_printed_office(string pwalletID, string admin_status, string data_status, string xcomment, string xdoc1, string xdoc2, string xdoc3, string xofficer)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO tm_printed_office (pwalletID,admin_status,data_status,xcomment,xdoc1,xdoc2,xdoc3,xofficer,reg_date,xvisible) VALUES (@pwalletID,@admin_status,@data_status,@xcomment,@xdoc1,@xdoc2,@xdoc3,@xofficer,@reg_date,@xvisible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            string str3 = DateTime.Now.ToString("yyyy-MM-dd");
            xdoc1 = xdoc1.Replace(" ", "_");
            xdoc2 = xdoc2.Replace(" ", "_");
            xdoc3 = xdoc3.Replace(" ", "_");
            command.Parameters.Add("@pwalletID", SqlDbType.VarChar, 50);
            command.Parameters.Add("@admin_status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
            command.Parameters.Add("@xcomment", SqlDbType.Text);
            command.Parameters.Add("@xdoc1", SqlDbType.Text);
            command.Parameters.Add("@xdoc2", SqlDbType.Text);
            command.Parameters.Add("@xdoc3", SqlDbType.Text);
            command.Parameters.Add("@xofficer", SqlDbType.VarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.VarChar, 50);
            command.Parameters.Add("@xvisible", SqlDbType.VarChar, 10);
            command.Parameters["@pwalletID"].Value = pwalletID;
            command.Parameters["@admin_status"].Value = admin_status;
            command.Parameters["@data_status"].Value = data_status;
            command.Parameters["@xcomment"].Value = xcomment;
            command.Parameters["@xdoc1"].Value = xdoc1;
            command.Parameters["@xdoc2"].Value = xdoc2;
            command.Parameters["@xdoc3"].Value = xdoc3;
            command.Parameters["@xofficer"].Value = xofficer;
            command.Parameters["@reg_date"].Value = str3;
            command.Parameters["@xvisible"].Value = "1";
            str = command.ExecuteScalar().ToString();
            connection.Close();
            if (str == "0")
            {
                return "0";
            }
            return str;
        }

        public string a_xadminz(string uname, string xpass, string serverpath)
        {
            List<Adminz> list = new List<Adminz>();
            string xmlString = "Xavier";
            int dwKeySize = 0x400;
            string path = serverpath + @"\Handlers\bf.kez";
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path, true);
                xmlString = reader.ReadToEnd();
                reader.Close();
                if (xmlString != null)
                {
                    string oldValue = xmlString.Substring(0, xmlString.IndexOf("</BitStrength>") + 14);
                    xmlString = xmlString.Replace(oldValue, "");
                }
            }
            Odyssey.Odyssey odyssey = new Odyssey.Odyssey();
            this.Connect();
            string str4 = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select xID,xemail,xpass from xadminz_tm where xvisible='1' ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader2 = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader2.Read())
            {
                Adminz item = new Adminz
                {
                    xID = reader2["xID"].ToString(),
                    xemail = reader2["xemail"].ToString(),
                    xpass = reader2["xpass"].ToString()
                };
                list.Add(item);
            }
            reader2.Close();
            string str5 = "";
            string str6 = "";
            for (int i = 0; i < list.Count; i++)
            {
                str6 = odyssey.DecryptString(list[i].xemail, dwKeySize, xmlString);
                str5 = odyssey.DecryptString(list[i].xpass, dwKeySize, xmlString);
                if ((uname == str6) && (xpass == str5))
                {
                    str4 = list[i].xID.ToString();
                }
            }
          //  connection.Close();
            return str4;
        }


        public int a_xadminz2(string uname, string serverpath)
        {
            List<Adminz> list = new List<Adminz>();
            string xmlString = "Xavier";
            int dwKeySize = 0x400;
            string path = serverpath + @"\Handlers\bf.kez";
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path, true);
                xmlString = reader.ReadToEnd();
                reader.Close();
                if (xmlString != null)
                {
                    string oldValue = xmlString.Substring(0, xmlString.IndexOf("</BitStrength>") + 14);
                    xmlString = xmlString.Replace(oldValue, "");
                }
            }
            Odyssey.Odyssey odyssey = new Odyssey.Odyssey();
            this.Connect();
            int  str4 = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select xID,xemail,xpass from xadminz_tm where xvisible='1' ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader2 = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader2.Read())
            {
                Adminz item = new Adminz
                {
                    xID = reader2["xID"].ToString(),
                    xemail = reader2["xemail"].ToString(),
                    xpass = reader2["xpass"].ToString()
                };
                list.Add(item);
            }
            reader2.Close();
            string str5 = "";
            string str6 = "";
            for (int i = 0; i < list.Count; i++)
            {
                str6 = odyssey.DecryptString(list[i].xemail, dwKeySize, xmlString);
                str5 = odyssey.DecryptString(list[i].xpass, dwKeySize, xmlString);
                if ((uname == str6) )
                {
                    str4 = 1;
                }
            }
            //  connection.Close();
            return str4;
        }

        public string addAdminLog(string adminID, string ip_addy, string remote_host, string remote_user, string server_name, string server_url)
        {
            string str = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str2 = DateTime.Now.ToLongTimeString();
            string connectionString = this.Connect();
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


        public int updateHwallet(string xid, string used_status, string used_date, string product_title)
        {
            string connectionString = this.Connect2();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("UPDATE hwallet SET used_status='" + used_status + "',product_title='" + product_title + "',used_date='" + used_date + "'  WHERE xid='" + xid + "'  ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }


        public int AppealRejection2(int xid,string approveby ,string dateApproved,string status)
        {
            string connectionString = this.Connect();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("UPDATE AppealRejection  SET Status='" + status + "',ApproveBy='" + approveby + "',DateApproved='" + dateApproved + "'  WHERE Id='" + xid + "'  ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public string Connect()
        {
            return ConfigurationManager.ConnectionStrings["cldConnectionString"].ConnectionString;
        }

        public string ConnectXhome()
        {
            return ConfigurationManager.ConnectionStrings["homeConnectionString"].ConnectionString;
        }
          public string Connect2()
        {
            return ConfigurationManager.ConnectionStrings["xpayConnectionString"].ConnectionString;
        }

       
        public int e_Contact_formStatus(string xID, string sent_status)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE contact_form SET sent_status=@sent_status WHERE xID=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 1);
            command.Parameters["@xID"].Value = Convert.ToInt64(xID);
            command.Parameters["@sent_status"].Value = sent_status;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int g_pwalletStatus(string xID, string sent_status, string sent_status2)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE pwallet SET status=@sent_status,data_status=@sent_status2 WHERE ID=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 50);
            command.Parameters["@xID"].Value = Convert.ToInt64(xID);
            command.Parameters["@sent_status"].Value = sent_status;
            command.Parameters["@sent_status2"].Value = sent_status2;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }


        public int g_pwalletStatus2(string xID, string sent_status, string sent_status2)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE pwallet SET status=@sent_status,data_status=@sent_status2 WHERE validationid=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 50);
            command.Parameters["@xID"].Value = xID;
            command.Parameters["@sent_status"].Value = sent_status;
            command.Parameters["@sent_status2"].Value = sent_status2;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int g_pwalletStatus3(string xID, string sent_status, string sent_status2)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE g_pwallet SET status=@sent_status,data_status=@sent_status2 WHERE validationid=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 50);
            command.Parameters["@xID"].Value = xID;
            command.Parameters["@sent_status"].Value = sent_status;
            command.Parameters["@sent_status2"].Value = sent_status2;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public String  getApplicantName(Int32 status)
        {
           String  num = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select NEW_APPLICANTNAME  AS cnt from Recordal  WHERE  ID=@logstaff  ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            command.Parameters.Add("@logstaff", SqlDbType.Int);
            command.Parameters["@logstaff"].Value = status;
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToString(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }


        public ChangeAplicant_Name getApplicantName2(Int32 status)
        {
            String num = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            ChangeAplicant_Name xx = new ChangeAplicant_Name();
            SqlCommand command = new SqlCommand("select NEW_APPLICANTNAME  AS cnt,OLD_APPLICANTNAME,log_staff   from Recordal  WHERE  ID=@logstaff  ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            command.Parameters.Add("@logstaff", SqlDbType.Int);
            command.Parameters["@logstaff"].Value = status;
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                xx.new_applicantname = Convert.ToString(reader["cnt"]);
                xx.old_applicantname = Convert.ToString(reader["OLD_APPLICANTNAME"]);
                xx.log_staff = Convert.ToString(reader["log_staff"]);
               // num = Convert.ToString(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return xx;
        }

        public ChangeAplicant_Name getAddress2(Int32 status)
        {
            String num = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            ChangeAplicant_Name xx = new ChangeAplicant_Name();
            SqlCommand command = new SqlCommand("select NEW_APPLICANTADDRESS  AS cnt,OLD_APPLICANTADDRESS,log_staff   from Recordal  WHERE  ID=@logstaff  ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            command.Parameters.Add("@logstaff", SqlDbType.Int);
            command.Parameters["@logstaff"].Value = status;
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                xx.new_applicantname = Convert.ToString(reader["cnt"]);
                xx.old_applicantname = Convert.ToString(reader["OLD_APPLICANTADDRESS"]);
                xx.log_staff = Convert.ToString(reader["log_staff"]);
                // num = Convert.ToString(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return xx;
        }


        public String  getRecordalStatus(Int32  status)
        {
            String num = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            ChangeAplicant_Name xx = new ChangeAplicant_Name();
            String Vstatus = "";
            SqlCommand command = new SqlCommand("select Status   AS cnt  from Recordal  WHERE  ID=@logstaff  ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            command.Parameters.Add("@logstaff", SqlDbType.Int);
            command.Parameters["@logstaff"].Value = status;
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Vstatus = Convert.ToString(reader["cnt"]);
              
                // num = Convert.ToString(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return Vstatus;
        }

        public int update_recordal(string xID, string old_applicant, string new_applicant,string log_staff)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Recordal SET NEW_APPLICANTNAME=@sent_status,OLD_APPLICANTNAME=@sent_status2 WHERE ID=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 500);
            command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 500);
            command.Parameters["@xID"].Value = Convert.ToInt64(xID);
            command.Parameters["@sent_status"].Value = new_applicant;
            command.Parameters["@sent_status2"].Value = old_applicant;
            int num = command.ExecuteNonQuery();
            connection.Close();

            String vstatus = getRecordalStatus(Convert.ToInt32(xID));
            if (vstatus == "Approved")
            {
                update_Applicant3(log_staff, new_applicant);
              //  update_Applicant3Status(log_staff, new_applicant);

            }

            else
            {
                update_Applicant3(log_staff, old_applicant);
            }

           
            return num;
        }

        public int update_recordal2(string xID, string old_applicant, string new_applicant, string log_staff)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Recordal SET NEW_APPLICANTADDRESS=@sent_status,OLD_APPLICANTADDRESS=@sent_status2 WHERE ID=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 500);
            command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 500);
            command.Parameters["@xID"].Value = Convert.ToInt64(xID);
            command.Parameters["@sent_status"].Value = new_applicant;
            command.Parameters["@sent_status2"].Value = old_applicant;
            int num = command.ExecuteNonQuery();
            connection.Close();
            String vstatus = getRecordalStatus(Convert.ToInt32(xID));
            if (vstatus == "Approved")
            {
                update_Applicant3Status(log_staff, new_applicant);

            }

            else
            {
                update_Applicant3Status(log_staff, old_applicant);
            }
           // String AddressId = getApplicantAddressId(log_staff);
           // update_Applicant3(log_staff, new_applicant);
            return num;
        }


        public int update_Applicant3(string xID,  string new_applicant)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE applicant SET xname=@sent_status WHERE log_staff=@xID ";
            connection.Open();
           
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 500);
          
            command.Parameters.Add("@xID", SqlDbType.NVarChar, 50);
         
            command.Parameters["@sent_status"].Value = new_applicant;
            command.Parameters["@xID"].Value = xID;
           
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public String getApplicantAddress(Int32 status)
        {
            String num = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select NEW_APPLICANTADDRESS  AS cnt from Recordal  WHERE  ID=@logstaff  ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            command.Parameters.Add("@logstaff", SqlDbType.Int);
            command.Parameters["@logstaff"].Value = status;
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToString(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }

        public int update_RecordalStatus(string xID, string sent_status,string xcomment,string rec_id)
        {
            Retriever ret = new Retriever();
            Int32 vint = getMaxId(xID);

            vint = Convert.ToInt32(rec_id);
            int num = 0;
            List<Recordal> xk = ret.getG_PwalletByID3(vint);

          
            if (xk[0].RECORDAL_TYPE == "Change_Name")
            {
                String vff = getApplicantName(vint);
                SqlConnection connection = new SqlConnection(this.Connect());
                SqlCommand command = connection.CreateCommand();
                DateTime vv = DateTime.Now;
                command.CommandText = "UPDATE Recordal SET RECORDAL_APPROVE_DATE=@sent_status,XOFFICER=@sent_status2,status=@status,Xcomment=@Xcomment WHERE ID=@xID ";
                connection.Open();
                command.Parameters.Add("@xID", SqlDbType.Int);
                command.Parameters.Add("@sent_status", SqlDbType.DateTime);
                command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@status", SqlDbType.NVarChar, 50);

                command.Parameters.Add("@Xcomment", SqlDbType.NVarChar, 500);

                command.Parameters["@xID"].Value = vint;
                command.Parameters["@sent_status"].Value = vv;
                command.Parameters["@sent_status2"].Value = sent_status;
                command.Parameters["@status"].Value = "Approved";
                command.Parameters["@Xcomment"].Value = xcomment;

                num = command.ExecuteNonQuery();
                connection.Close();
                update_Applicant2Status(xID, vff);

                e_PwalletStatus(xID, xk[0].data_status2, xk[0].data_status);
               

              //  e_PwalletStatus(xID, xk[0].data_status2, xk[0].data_status);
                return num;

            }

            if (xk[0].RECORDAL_TYPE == "registered_user")
            {
                String vff = getApplicantName(vint);
                String vff2 = getApplicantAddress(vint);
                SqlConnection connection = new SqlConnection(this.Connect());
                SqlCommand command = connection.CreateCommand();
                DateTime vv = DateTime.Now;
                command.CommandText = "UPDATE Recordal SET RECORDAL_APPROVE_DATE=@sent_status,XOFFICER=@sent_status2,status=@status,Xcomment=@Xcomment WHERE ID=@xID ";
                connection.Open();
                command.Parameters.Add("@xID", SqlDbType.Int);
                command.Parameters.Add("@sent_status", SqlDbType.DateTime);
                command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@status", SqlDbType.NVarChar, 50);

                command.Parameters.Add("@Xcomment", SqlDbType.NVarChar, 500);

                command.Parameters["@xID"].Value = vint;
                command.Parameters["@sent_status"].Value = vv;
                command.Parameters["@sent_status2"].Value = sent_status;
                command.Parameters["@status"].Value = "Approved";
                command.Parameters["@Xcomment"].Value = xcomment;

                num = command.ExecuteNonQuery();
                connection.Close();
                update_Applicant2Status(xID, vff);
                update_Applicant3Status(xID, vff2);

                e_PwalletStatus(xID, xk[0].data_status2, xk[0].data_status);


                //  e_PwalletStatus(xID, xk[0].data_status2, xk[0].data_status);
                return num;

            }
            else if (xk[0].RECORDAL_TYPE == "Change_Agent")
            {

                SqlConnection connection = new SqlConnection(this.Connect());
                SqlCommand command = connection.CreateCommand();
                DateTime vv = DateTime.Now;
                command.CommandText = "UPDATE Recordal SET RECORDAL_APPROVE_DATE=@sent_status,XOFFICER=@sent_status2,status=@status,Xcomment=@Xcomment WHERE ID=@xID ";
                connection.Open();
                command.Parameters.Add("@xID", SqlDbType.Int);
                command.Parameters.Add("@sent_status", SqlDbType.DateTime);
                command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@status", SqlDbType.NVarChar, 50);

                command.Parameters.Add("@Xcomment", SqlDbType.NVarChar, 500);

                command.Parameters["@xID"].Value = vint;
                command.Parameters["@sent_status"].Value = vv;
                command.Parameters["@sent_status2"].Value = sent_status;
                command.Parameters["@status"].Value = "Approved";
                command.Parameters["@Xcomment"].Value = xcomment;

                num = command.ExecuteNonQuery();
                connection.Close();
                update_Representative(xID, xk[0]);
                e_PwalletStatus(xID, xk[0].data_status2, xk[0].data_status);
                return num;
            }

            else if (xk[0].RECORDAL_TYPE == "Change_Address")
            {

                String vff = getApplicantAddress(vint);
                SqlConnection connection = new SqlConnection(this.Connect());
                SqlCommand command = connection.CreateCommand();
                DateTime vv = DateTime.Now;
                command.CommandText = "UPDATE Recordal SET RECORDAL_APPROVE_DATE=@sent_status,XOFFICER=@sent_status2,status=@status ,Xcomment=@Xcomment WHERE ID=@xID ";
                connection.Open();
                command.Parameters.Add("@xID", SqlDbType.Int);
                command.Parameters.Add("@sent_status", SqlDbType.DateTime);
                command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@status", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@Xcomment", SqlDbType.NVarChar, 500);
                command.Parameters["@xID"].Value = vint;
                command.Parameters["@sent_status"].Value = vv;
                command.Parameters["@sent_status2"].Value = sent_status;
                command.Parameters["@status"].Value = "Approved";
                command.Parameters["@Xcomment"].Value = xcomment;

                num = command.ExecuteNonQuery();
                connection.Close();
                update_Applicant3Status(xID, vff);
                e_PwalletStatus(xID, xk[0].data_status2, xk[0].data_status);
                // e_PwalletStatus(xID, xk[0].data_status2, xk[0].data_status);
                return num;

            }

            else if (xk[0].RECORDAL_TYPE == "Change_Rectification")
            {

                String vff = getApplicantAddress(vint);
                SqlConnection connection = new SqlConnection(this.Connect());
                SqlCommand command = connection.CreateCommand();
                DateTime vv = DateTime.Now;
                command.CommandText = "UPDATE Recordal SET RECORDAL_APPROVE_DATE=@sent_status,XOFFICER=@sent_status2,status=@status ,Xcomment=@Xcomment WHERE ID=@xID ";
                connection.Open();
                command.Parameters.Add("@xID", SqlDbType.Int);
                command.Parameters.Add("@sent_status", SqlDbType.DateTime);
                command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@status", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@Xcomment", SqlDbType.NVarChar, 500);
                command.Parameters["@xID"].Value = vint;
                command.Parameters["@sent_status"].Value = vv;
                command.Parameters["@sent_status2"].Value = sent_status;
                command.Parameters["@status"].Value = "Approved";
                command.Parameters["@Xcomment"].Value = xcomment;

                num = command.ExecuteNonQuery();
                connection.Close();

                //if (xk[0].LOGO_DESC=="1" || xk[0].LOGO_DESC=="3") {


                    update_Applicant4Status(xID, xk[0].NEW_PRODUCT_TITLE, xk[0].NEW_PRODUCT_LOGO, xk[0].LOGO_DESC);
                e_PwalletStatus(xID, xk[0].data_status2, xk[0].data_status);

                //}

                //else {

                //    update_Applicant5Status(xID, xk[0].NEW_PRODUCT_TITLE);

                //}



                //  update_Applicant3Status(xID, vff);
                return num;

            }


            else if (xk[0].RECORDAL_TYPE == "Change_Assignment")
            {
                  List<Recordal_Detail> xp = new List<Recordal_Detail>();
            xp = ret.get_RecordalDetail(xk[0].Detail_Id);

                String vff = getApplicantAddress(vint);
                SqlConnection connection = new SqlConnection(this.Connect());
                SqlCommand command = connection.CreateCommand();
                DateTime vv = DateTime.Now;
                command.CommandText = "UPDATE Recordal SET RECORDAL_APPROVE_DATE=@sent_status,XOFFICER=@sent_status2,status=@status ,Xcomment=@Xcomment WHERE ID=@xID ";
                connection.Open();
                command.Parameters.Add("@xID", SqlDbType.Int);
                command.Parameters.Add("@sent_status", SqlDbType.DateTime);
                command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@status", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@Xcomment", SqlDbType.NVarChar, 500);
                command.Parameters["@xID"].Value = vint;
                command.Parameters["@sent_status"].Value = vv;
                command.Parameters["@sent_status2"].Value = sent_status;
                command.Parameters["@status"].Value = "Approved";
                command.Parameters["@Xcomment"].Value = xcomment;

                num = command.ExecuteNonQuery();
                connection.Close();
                update_Applicant2bStatus(xID, xp[0].newApplicantName, xp[0].newApplicantNationality);
                update_Applicant3bStatus(xID, xp[0].newApplicantAddress, xp[0].newApplicantNationality);
                e_PwalletStatus(xID, xk[0].data_status2, xk[0].data_status);
                return num;

            }


            else if (xk[0].RECORDAL_TYPE == "Change_Assignment2")
            {
                List<Recordal_Detail> xp = new List<Recordal_Detail>();
                xp = ret.get_RecordalDetail(xk[0].Detail_Id);

                String vff = getApplicantAddress(vint);
                SqlConnection connection = new SqlConnection(this.Connect());
                SqlCommand command = connection.CreateCommand();
                DateTime vv = DateTime.Now;
                command.CommandText = "UPDATE Recordal SET RECORDAL_APPROVE_DATE=@sent_status,XOFFICER=@sent_status2,status=@status ,Xcomment=@Xcomment WHERE ID=@xID ";
                connection.Open();
                command.Parameters.Add("@xID", SqlDbType.Int);
                command.Parameters.Add("@sent_status", SqlDbType.DateTime);
                command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@status", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@Xcomment", SqlDbType.NVarChar, 500);
                command.Parameters["@xID"].Value = vint;
                command.Parameters["@sent_status"].Value = vv;
                command.Parameters["@sent_status2"].Value = sent_status;
                command.Parameters["@status"].Value = "Approved";
                command.Parameters["@Xcomment"].Value = xcomment;

                num = command.ExecuteNonQuery();
                connection.Close();
                update_Applicant2bStatus(xID, xp[0].newApplicantName, xp[0].newApplicantNationality);
                update_Applicant3bStatus(xID, xp[0].newApplicantAddress, xp[0].newApplicantNationality);
                e_PwalletStatus(xID, xk[0].data_status2, xk[0].data_status);
                return num;

            }


            else if (xk[0].RECORDAL_TYPE == "Change_Renewal")
            {
                List<Recordal_Detail> xp = new List<Recordal_Detail>();
                xp = ret.get_RecordalDetail(xk[0].Detail_Id);

                String vff = getApplicantAddress(vint);
                SqlConnection connection = new SqlConnection(this.Connect());
                SqlCommand command = connection.CreateCommand();
                DateTime vv = DateTime.Now;
                command.CommandText = "UPDATE Recordal SET RECORDAL_APPROVE_DATE=@sent_status,XOFFICER=@sent_status2,status=@status ,Xcomment=@Xcomment WHERE ID=@xID ";
                connection.Open();
                command.Parameters.Add("@xID", SqlDbType.Int);
                command.Parameters.Add("@sent_status", SqlDbType.DateTime);
                command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@status", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@Xcomment", SqlDbType.NVarChar, 500);
                command.Parameters["@xID"].Value = vint;
                command.Parameters["@sent_status"].Value = vv;
                command.Parameters["@sent_status2"].Value = sent_status;
                command.Parameters["@status"].Value = "Approved";
                command.Parameters["@Xcomment"].Value = xcomment;

                num = command.ExecuteNonQuery();
                connection.Close();
                // update_Applicant2bStatus(xID, xp[0].newApplicantName, xp[0].newApplicantNationality);
                // update_Applicant3bStatus(xID, xp[0].newApplicantAddress, xp[0].newApplicantNationality);
                e_PwalletStatus(xID, xk[0].data_status2, xk[0].data_status);
                return num;

            }

            return num;
        }
        public int update_Representative(string xID, Recordal vf)
        {
            tm.Representative c_rep = new tm.Representative();
            tm t = new tm();
            c_rep = t.getRepClassByUserID(xID);
            char[] carArr = { ',' };
            String[] c_repArr = vf.NEWAGENT_ADDRESS.Split(carArr);
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            DateTime vv = DateTime.Now;
            command.CommandText = "UPDATE representative SET xname=@sent_status, agent_code=@sent_status2 WHERE log_staff=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 500);
            command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 50);

            command.Parameters["@sent_status2"].Value = vf.NEW_AGENTCODE;
            command.Parameters["@xID"].Value = xID;
            command.Parameters["@sent_status"].Value = vf.NEW_AGENTNAME;
            int num = command.ExecuteNonQuery();
            if ((num != 0) && (c_rep.addressID != "") && (c_rep.addressID != "0"))
            {
                SqlCommand command2 = connection.CreateCommand();
                command2.CommandText = "UPDATE address SET street=@sent_status, telephone1=@telephone, email1=@email WHERE ID=@xID ";

                command2.Parameters.Add("@xID", SqlDbType.NVarChar, 50);
                command2.Parameters.Add("@sent_status", SqlDbType.NVarChar, 50);
                command2.Parameters.Add("@telephone", SqlDbType.NVarChar, 50);
                command2.Parameters.Add("@email", SqlDbType.NVarChar, 50);


                command2.Parameters["@xID"].Value = c_rep.addressID;
                command2.Parameters["@sent_status"].Value = vf.NEWAGENT_ADDRESS;
                command2.Parameters["@telephone"].Value = vf.NEW_AGENTPHONE;
                command2.Parameters["@email"].Value = vf.NEW_AGENTEMAIL;
                num = command2.ExecuteNonQuery();
            }


            SqlCommand command3 = connection.CreateCommand();
            command3.CommandText = "UPDATE pwallet  SET applicantID=@sent_status  WHERE ID=@xID ";

            command3.Parameters.Add("@xID", SqlDbType.NVarChar, 50);
            command3.Parameters.Add("@sent_status", SqlDbType.NVarChar, 50);
            


            command3.Parameters["@xID"].Value = xID;
            command3.Parameters["@sent_status"].Value = vf.NEW_AGENTCODE;
           
            num = command3.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_Applicant2Status(string xID, string sent_status)
        {
           // Int32 vint = getMaxId(xID);
           
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            DateTime vv = DateTime.Now;
            command.CommandText = "UPDATE applicant SET xname=@sent_status WHERE log_staff=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 50);
           

            command.Parameters["@xID"].Value = xID;
            command.Parameters["@sent_status"].Value = sent_status;
           

            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_Applicant2bStatus(string xID, string sent_status, string sent_status2)
        {
            Int32 vint = getMaxId(xID);
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            DateTime vv = DateTime.Now;
            command.CommandText = "UPDATE applicant SET xname=@sent_status,nationality=@nationality WHERE log_staff=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);



            command.Parameters["@xID"].Value = xID;
            command.Parameters["@sent_status"].Value = sent_status;
            command.Parameters["@nationality"].Value = sent_status2;



            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_Applicant3Status(string xID, string sent_status)
        {
           // Int32 vint = getMaxId(xID);
            String AddressId = getApplicantAddressId(xID);
            Int64 AddressId2 = Convert.ToInt64(AddressId);
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            DateTime vv = DateTime.Now;

            command.CommandText = "UPDATE address  SET street=@sent_status WHERE ID=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 500);


            command.Parameters["@xID"].Value = AddressId2;
            command.Parameters["@sent_status"].Value = sent_status;


            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_Applicant3bStatus(string xID, string sent_status, string sent_status2)
        {
            Int32 vint = getMaxId(xID);
            String AddressId = getApplicantAddressId(xID);
            Int64 AddressId2 = Convert.ToInt64(AddressId);
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            DateTime vv = DateTime.Now;

            command.CommandText = "UPDATE address  SET street=@sent_status,CountryID=@CountryID  WHERE ID=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 500);
            command.Parameters.Add("@CountryID", SqlDbType.NVarChar, 500);


            command.Parameters["@xID"].Value = AddressId2;
            command.Parameters["@sent_status"].Value = sent_status;

            command.Parameters["@CountryID"].Value = sent_status2;


            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_Applicant4Status(string xID, string sent_status, string sent_status2, string sent_status3)
        {
            //Int32 vint = getMaxId(xID);
            //String AddressId = getApplicantAddressId(xID);
            //Int64 AddressId2 = Convert.ToInt64(AddressId);
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            DateTime vv = DateTime.Now;

            command.CommandText = "UPDATE mark_info   SET product_title=@sent_status,logo_pic =@sent_status2,logo_descriptionID=@sent_status3  WHERE log_staff=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.NVarChar, 500);
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 500);

            command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 500);

            command.Parameters.Add("@sent_status3", SqlDbType.NVarChar, 500);



            command.Parameters["@xID"].Value = xID;
            command.Parameters["@sent_status"].Value = sent_status;
            command.Parameters["@sent_status2"].Value = sent_status2;
            command.Parameters["@sent_status3"].Value = sent_status3;


            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_Applicant5Status(string xID, string sent_status)
        {
            //Int32 vint = getMaxId(xID);
            //String AddressId = getApplicantAddressId(xID);
            //Int64 AddressId2 = Convert.ToInt64(AddressId);
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            DateTime vv = DateTime.Now;

            command.CommandText = "UPDATE mark_info   SET product_title=@sent_status  WHERE log_staff=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.NVarChar, 500);
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 500);


            command.Parameters["@xID"].Value = xID;
            command.Parameters["@sent_status"].Value = sent_status;
        


            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }


        public Int32 getMaxId(string status)
        {
            Int32 num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select Max(ID)  AS cnt from Recordal  WHERE  LOG_STAFF=@logstaff  ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            command.Parameters.Add("@logstaff", SqlDbType.NVarChar, 50);
            command.Parameters["@logstaff"].Value = status;
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }


        public int update_RecordalStatus3(string xID, string sent_status, string sent_status2)
        {
            //Int32 vint = getMaxId(xID);
            //String AddressId = getApplicantAddressId(xID);
            //Int64 AddressId2 = Convert.ToInt64(AddressId);
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            DateTime vv = DateTime.Now;

            command.CommandText = "UPDATE Recordal   SET data_status3=@sent_status,data_status4 =@sent_status2  WHERE id=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.NVarChar, 500);
            command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 500);

            command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 500);


            command.Parameters["@xID"].Value = xID;
            command.Parameters["@sent_status"].Value = sent_status;
            command.Parameters["@sent_status2"].Value = sent_status2;


            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }
        public int e_G_PwalletStatus(string xID, string status, string data_status)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE g_pwallet SET status=@status,data_status=@data_status WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@status", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@data_status", SqlDbType.NVarChar, 50);
            command.Parameters["@ID"].Value = Convert.ToInt64(xID);
            command.Parameters["@status"].Value = status;
            command.Parameters["@data_status"].Value = data_status;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int e_PwalletAccPrintStatus(string xID, string acc_p)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE pwallet SET acc_p=@acc_p WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@acc_p", SqlDbType.NVarChar, 50);
            command.Parameters["@ID"].Value = Convert.ToInt64(xID);
            command.Parameters["@acc_p"].Value = acc_p;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int e_PwalletRtmStatus(string xID, string status, string data_status, string rtm)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE pwallet SET status=@status,data_status=@data_status,rtm=@rtm WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@status", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@data_status", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@rtm", SqlDbType.NVarChar, 50);
            command.Parameters["@ID"].Value = Convert.ToInt64(xID);
            command.Parameters["@status"].Value = status;
            command.Parameters["@data_status"].Value = data_status;
            command.Parameters["@rtm"].Value = rtm;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int e_PwalletStatus(string xID, string status, string data_status)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE pwallet SET status=@status,data_status=@data_status WHERE ID=@ID ";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@status", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@data_status", SqlDbType.NVarChar, 50);
            command.Parameters["@ID"].Value = Convert.ToInt64(xID);
            command.Parameters["@status"].Value = status;
            command.Parameters["@data_status"].Value = data_status;
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }


        public List<ApplicationOfficer2> ApplicationOff(string startdate, string enddate)
        {
            string str = "";
            int sn = 1;
            
            SqlConnection connection = new SqlConnection(this.Connect());
            string format = "yyyy-MM-dd";
            var kk = Convert.ToDateTime(startdate).Date.ToString(format);
            var kk2 = Convert.ToDateTime(enddate).Date.ToString(format);
            SqlCommand command = new SqlCommand("select tm_office.data_status,tm_office.reg_date,validationid,pwalletid ,xname  from tm_office inner JOIN xadminz_tm ON xadminz_tm.xID=tm_office.xofficer inner JOIN pwallet on pwallet.id =tm_office.pwalletID where  tm_office.reg_date BETWEEN  '" + kk + "' AND '" + kk2 + "'   ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            List<ApplicationOfficer2> xk = new List<ApplicationOfficer2>();
            while (reader.Read())
            {
                ApplicationOfficer2 pp = new ApplicationOfficer2();
                pp.data_status = reader["data_status"].ToString();
                pp.sn = sn;
                pp.reg_date = reader["reg_date"].ToString();
             
                pp.Validationid = reader["validationid"].ToString();

                pp.pwalletid = reader["pwalletid"].ToString();
                pp.xname = reader["xname"].ToString();
               
                sn++;

                xk.Add(pp);
            }
            reader.Close();
            connection.Close();
            return xk;
        }


        public int e_regadmin(string xname, string xpass, string xrole, string xemail, string telephone1, string telephone2, string xsection, string pwalletID, string xID, string visible)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE xadminz_tm SET xname=@xname,xpass=@xpass,xroleID=@xroleID,xemail=@xemail,xtelephone1=@xtelephone1,xtelephone2=@xtelephone2,xsection=@xsection,xlog_officer=@pwalletID,xvisible=@xvisible WHERE xID=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@xpass", SqlDbType.Text);
            command.Parameters.Add("@xroleID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@xemail", SqlDbType.Text);
            command.Parameters.Add("@xtelephone1", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@xtelephone2", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@xsection", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@pwalletID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@xvisible", SqlDbType.NVarChar, 1);
            command.Parameters["@xID"].Value = xID;
            command.Parameters["@xname"].Value = xname;
            command.Parameters["@xpass"].Value = xpass;
            command.Parameters["@xroleID"].Value = xrole;
            command.Parameters["@xemail"].Value = xemail;
            command.Parameters["@xtelephone1"].Value = telephone1;
            command.Parameters["@xtelephone2"].Value = telephone2;
            command.Parameters["@xsection"].Value = xsection;
            command.Parameters["@pwalletID"].Value = pwalletID;
            command.Parameters["@xvisible"].Value = visible;
            int num = command.ExecuteNonQuery();
            connection.Close();
            if (num > 0)
            {
                num = Convert.ToInt32(xID);
            }
            return num;
        }

        public string e_xadminz(string xID, string xpass)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE xadminz_tm SET xpass=@xpass WHERE xID=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters.Add("@xpass", SqlDbType.Text);
            command.Parameters["@xID"].Value = Convert.ToInt64(xID);
            command.Parameters["@xpass"].Value = xpass;
            string str = command.ExecuteNonQuery().ToString();
            connection.Close();
            return str;
        }

        public string formatDate(string date)
        {
            if ((date == "") || (date == null))
            {
                date = DateTime.Today.Date.ToString("MM/dd/yyyy");
            }
            string str = "";
            string str2 = date.Substring(0, 2);
            string str3 = date.Substring(3, 2);
            str = date.Substring(6, 4);
            return (str + "-" + str2 + "-" + str3);
        }

        public string formatSearchDate(string date)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            if (date != "")
            {
                str = "";
              //  str2 = date.Substring(0, 2);
                str2 = date.Substring(0, 4);
              //  str3 = date.Substring(3, 2);
                str3 = date.Substring(5, 2);
               // str = date.Substring(6, 4);
                str = date.Substring(8, 2);
                str4 = str + "-" + str2 + "-" + str3;
            }
            return str4;
        }

        public string formatSearchDate2(string date)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            if (date != "")
            {
                str = "";
            
                str2 = date.Substring(0, 4);
              
                str3 = date.Substring(5, 2);
              
                str = date.Substring(8, 2);
                str4 = str + "-" + str2 + "-" + str3;
            }
            return str4;
        }

        public List<MarkInfo> getAcceptanceAdminSearchMarkInfoRS(string status, string criteria, List<string> fulltext, string dateFrom, string dateTo)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            string cmdText = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            if (criteria == "product_title")
            {
                num = fulltext.Count - 1;
                str2 = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22' AND CAST(pwallet.status AS INT)>=5 AND ";
                for (int i = 0; i < fulltext.Count; i++)
                {
                    if (fulltext.Count == 1)
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else if (num == i)
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) OR";
                    }
                }
                str4 = "AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "' ORDER BY xID ASC";
                cmdText = str2 + str3 + str4;
            }
            else if (criteria == "app_number")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22' AND CAST(pwallet.status AS INT)>=5  AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
               CommandTimeout = 0
            };
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
            connection.Close();
            return list;
        }

        public long getAcceptanceMarkInfoRSCnt(string status)
        {
            long num = 0L;
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID WHERE pwallet.status<>'33' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND pwallet.data_status<>'New' AND CAST(pwallet.status AS INT) >=5  ", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt64(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }


        public int  getUserCount2(string status)
        {
        int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select Count(*) AS cnt from xadminz_tm   WHERE xemail='" + status + "' " , connection)
            {
                CommandTimeout = 0
            };
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


        public List<MarkInfo> getAcceptanceMarkInfoRSX(string status, string start, string limit)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number,mark_info.product_title,mark_info.tm_typeID,mark_info.reg_date,mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank' from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE   pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22' AND CAST(pwallet.status AS INT)>=5  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                MarkInfo item = new MarkInfo
                {
                    xID = reader["xID"].ToString(),
                    reg_number = reader["reg_number"].ToString(),
                    tm_typeID = reader["tm_typeID"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public string GetAddressTags(string select_search)
        {
            return "";
        }

        public Adminz getAdminDetails(string ID)
        {
            Adminz adminz = new Adminz();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * from xadminz_tm where xID='" + ID + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                adminz.xID = reader["xID"].ToString();
                adminz.xroleID = reader["xroleID"].ToString();
                adminz.xname = reader["xname"].ToString();
                adminz.xemail = reader["xemail"].ToString();
                adminz.xpass = reader["xpass"].ToString();
                adminz.xtelephone1 = reader["xtelephone1"].ToString();
                adminz.xtelephone2 = reader["xtelephone2"].ToString();
                adminz.xsection = reader["xsection"].ToString();
                adminz.xlog_officer = reader["xlog_officer"].ToString();
                adminz.xreg_date = reader["xreg_date"].ToString();
                adminz.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            connection.Close();
            return adminz;
        }

        public List<AuditReport> getLogReport()
        {
            
            List<AuditReport> audit = new List<AuditReport>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT  activity_lg.id, pwallet.validationID, xadminz_tm.xname, activity_lg.userID, activity_lg.act_date, activity_lg.DocumentId, activity_lg.Operation, activity_lg.module, activity_lg.status, activity_lg.old_title, activity_lg.new_title, activity_lg.old_class, activity_lg.new_class, activity_lg.old_applicantname, activity_lg.new_applicantname FROM  activity_lg INNER JOIN pwallet ON pwallet.ID = activity_lg.DocumentId INNER JOIN xadminz_tm ON xadminz_tm.xID = activity_lg.userID ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                AuditReport auditreport = new AuditReport();
                auditreport.transactionid = reader["validationID"].ToString();
                auditreport.username = reader["xname"].ToString();
                auditreport.logdate = reader["act_date"].ToString();
                auditreport.operation = reader["Operation"].ToString();
                auditreport.module = reader["module"].ToString();
                auditreport.newapplicantname = reader["new_applicantname"].ToString();
                auditreport.oldapplicantname = reader["old_applicantname"].ToString();
                auditreport.oldclass = reader["old_class"].ToString();
                auditreport.newclass = reader["new_class"].ToString();
                auditreport.newtitle = reader["new_title"].ToString();
                auditreport.oldtitle = reader["old_title"].ToString();
                audit.Add(auditreport);
               
            }
            reader.Close();
            connection.Close();
            return audit;
        }

        public List<MarkInfo> getAdminSearchMarkInfoRS(string status, string data_status, string criteria, List<string> fulltext, string dateFrom, string dateTo)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            string cmdText = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            if (criteria == "product_title")
            {
                num = fulltext.Count - 1;
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    str2 = "select mark_info.*,pwallet.rtm from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused'))  AND ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    str2 = "select mark_info.*,pwallet.rtm from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid'))  AND ";
                }
                else
                {
                    str2 = "select mark_info.*,pwallet.rtm from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' AND ";
                }
                for (int i = 0; i < fulltext.Count; i++)
                {
                    if (fulltext.Count == 1)
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else if (num == i)
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) OR";
                    }
                }
                str4 = "AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC";
                cmdText = str2 + str3 + str4;
            }
            else if (criteria == "reg_number")
            {
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    cmdText = "select mark_info.*,pwallet.rtm from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused')) AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    cmdText = "select mark_info.*,pwallet.rtm from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid')) AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else
                {
                    cmdText = "select mark_info.*,pwallet.rtm from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
            }
            else if (criteria == "app_number")
            {
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    cmdText = "select mark_info.*,pwallet.rtm from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused')) AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    cmdText = "select mark_info.*,pwallet.rtm from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid')) AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else
                {
                    cmdText = "select mark_info.*,pwallet.rtm from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandTimeout = 0
            };
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
                    xvisible = reader["xvisible"].ToString(),
                    rtm = reader["rtm"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public string getApplicant(string log_staff)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT xname from applicant where log_staff='" + log_staff + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["xname"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }


        public List<Payments> getPayment()
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect2());
            SqlCommand command = new SqlCommand("select twallet.transID ,applicant.xname,fee_list.xdesc  from twallet  INNER JOIN fee_details ON  twallet.xid=fee_details.twalletID INNER JOIN fee_list ON fee_details.fee_listID=fee_list.xid INNER JOIN applicant ON  twallet.applicantID=applicant.xid where twallet.xpay_status='1'  and fee_list.xcategory='tm'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            List<Payments> xk = new List<Payments>();
            while (reader.Read())
            {
                Payments pp = new Payments();
                pp.transID = reader["transID"].ToString();
                pp.xname = reader["xname"].ToString();
                pp.xdesc = reader["xdesc"].ToString(); 

                xk.Add(pp);
            }
            reader.Close();
            connection.Close();
            return xk;
        }



    



        public List<MarkInfo> getBatchPublishMarkInfoRS(string stage, string data_status, string batch_no)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status >'" + stage + "' AND ( pwallet.applicantID <> 'CLD/SA/22') AND ( pwallet.visible ='" + batch_no + "') ORDER BY CAST(national_classID AS INT), xID ASC ", connection);
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getBatchPublishMarkInfoRSAA(string stage, string data_status, string batch_no)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select  mark_info.reg_number, mark_info.logo_pic,mark_info.product_title,mark_info.national_classID ,mark_info.nice_class ,mark_info.nice_class_desc ,mark_info.reg_date,applicant.xname,representative.xname as repname,representative.agent_code   from mark_info INNER JOIN pwallet ON mark_info.log_staff=pwallet.ID  INNER JOIN applicant ON applicant.log_staff=pwallet.ID  INNER JOIN representative ON representative.log_staff=pwallet.ID WHERE pwallet.status >'" + stage + "' AND ( pwallet.applicantID <> 'CLD/SA/22') AND ( pwallet.visible ='" + batch_no + "') ORDER BY CAST(national_classID AS INT), xID ASC ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
               
                    MarkInfo item = new MarkInfo
                    {

                        reg_number = reader["reg_number"].ToString(),


                        national_classID = reader["national_classID"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        nice_class = reader["nice_class"].ToString(),
                        nice_class_desc = reader["nice_class_desc"].ToString(),

                        logo_pic = reader["logo_pic"].ToString(),
                       
                        reg_date = reader["reg_date"].ToString(),
                        appname = reader["xname"].ToString(),
                        repname = reader["repname"].ToString(),
                        agentcode = reader["agent_code"].ToString()
                    };
                    list.Add(item);

               
            }
            reader.Close();
            connection.Close();
            return list;
        }




        public List<MarkInfo> getCriAccpetanceMarkInfoRS(string stage, string data_status)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (data_status == "Refused")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Refused')  ORDER BY xID ASC";
            }
            else if (data_status == "Registrable")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Registrable')  ORDER BY xID ASC";
            }
            else if (data_status == "Non-registrable")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Non-registrable')  ORDER BY xID ASC";
            }
            else if (data_status == "XRegistrable")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND (( pwallet.data_status = 'Registrable') OR ( pwallet.data_status = 'Non-registrable'))  ORDER BY xID ASC";
            }
            else if (data_status == "Accepted")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status >'" + stage + "' AND pwallet.data_status='" + data_status + "' ORDER BY xID ASC";
            }
            SqlCommand command = new SqlCommand(cmdText, connection);
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getCriCertifyMarkInfoRS(string stage, string data_status)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (data_status == "Not Opposed")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Not Opposed') AND (pwallet.stage='5') ORDER BY xID ASC";
            }
            else if (data_status == "Deferred")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Deferred')  AND  (pwallet.stage='5') ORDER BY xID ASC";
            }
            else if (data_status == "Certified")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status >'" + stage + "' AND pwallet.data_status='" + data_status + "' AND  pwallet.stage='5' ORDER BY xID ASC";
            }
            SqlCommand command = new SqlCommand(cmdText, connection);
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getCriMarkInfoRS(string stage, string data_status)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (data_status != "Re-conduct search")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status <> 'Re-conduct search')  ORDER BY xID ASC";
            }
            else
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = '" + data_status + "')  ORDER BY xID ASC";
            }
            SqlCommand command = new SqlCommand(cmdText, connection);
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getCriOppesedMarkInfoRS(string stage, string data_status)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (data_status == "Opposed")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Opposed') AND  (pwallet.status <>22) AND (pwallet.status <>33)  AND ( pwallet.applicantID <> 'CLD/SA/22')  ORDER BY xID ASC";
            }
            else if (data_status == "Published")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Published') AND  (pwallet.status <>22) AND (pwallet.status <>33)  AND ( pwallet.applicantID <> 'CLD/SA/22')  ORDER BY xID ASC";
            }
            else if (data_status == "")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status > '" + stage + "'   ORDER BY xID ASC";
            }
            SqlCommand command = new SqlCommand(cmdText, connection);
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getCriPublishMarkInfoRS(string stage, string data_status)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (data_status == "Accepted")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE (pwallet.status='" + stage + "') AND (pwallet.status <>22) AND (pwallet.status <>33) AND ( pwallet.data_status = 'Accepted') AND ( pwallet.applicantID <> 'CLD/SA/22')  ORDER BY CAST(national_classID AS INT), xID ASC";
            }
            else if (data_status == "Deferred")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE (pwallet.status='" + stage + "') AND (pwallet.status <>22) AND (pwallet.status <>33) AND ( pwallet.data_status = 'Deferred') AND ( pwallet.applicantID <> 'CLD/SA/22') ORDER BY CAST(national_classID AS INT), xID ASC";
            }
            else if (data_status == "Published")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE (pwallet.status >='" + stage + "') AND (pwallet.status <>22) AND (pwallet.status <>33) AND ( pwallet.applicantID <> 'CLD/SA/22') AND ( pwallet.visible ='1') ORDER BY CAST(national_classID AS INT), xID ASC ";
            }
            SqlCommand command = new SqlCommand(cmdText, connection);
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getCriRegisteredMarkInfoRS(string stage, string data_status)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (data_status == "Certified")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Certified')  ORDER BY xID ASC";
            }
            else if (data_status == "Deferred")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Deferred')  ORDER BY xID ASC";
            }
            else if (data_status == "Registered")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status >'" + stage + "' AND pwallet.data_status='" + data_status + "' ORDER BY xID ASC";
            }
            SqlCommand command = new SqlCommand(cmdText, connection);
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
            connection.Close();
            return list;
        }

        public int getCriRegisteredMarkInfoRSCnt(string stage, string data_status)
        {
            int cnt = 0;
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (data_status == "Certified")
            {
               // cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Certified') " ;

                cmdText = "select count(*)  cnt from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status = '" + stage + "' AND pwallet.data_status = 'Certified' ";

            }

            if (data_status == "Not Opposed")
            {
                // cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Certified') " ;

                cmdText = "select count(*)  cnt from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status = '" + stage + "' AND pwallet.data_status = 'Not Opposed' ";

            }

            if (data_status == "Published")
            {
                // cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Certified') " ;

                cmdText = "select count(*)  cnt from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status = '" + stage + "' AND pwallet.data_status = 'Published' ";

            }
            else if (data_status == "Deferred")
            {
                cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Deferred') ";
            }
            else if (data_status == "Registered")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status >'" + stage + "' AND pwallet.data_status='" + data_status + "' ";
            }

            else if (data_status == "Accepted")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE  pwallet.status<>'33' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND pwallet.data_status<>'New' AND CAST(pwallet.status AS INT)>=5 ";
            }

            
            SqlCommand command = new SqlCommand(cmdText, connection);

          
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                cnt = Convert.ToInt32(reader["cnt"]);                
                
            }
            reader.Close();
            connection.Close();
            return cnt;
        }

        public int getCriRegisteredMarkInfoRSCnt2(string stage, string data_status)
        {
            int cnt = 0;
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());

           // cmdText = "select count (*) cnt from g_app_info   LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff   LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID LEFT OUTER JOIN g_applicant_info on  g_pwallet.id=g_applicant_info.log_staff  WHERE  g_pwallet.data_status ='Migrated' and g_pwallet.status='7'  ";

            cmdText = "select count (*) cnt from g_app_info   LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff   LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID LEFT OUTER JOIN g_applicant_info on  g_pwallet.id=g_applicant_info.log_staff  WHERE  g_pwallet.data_status ='" + data_status + "'  and g_pwallet.status= '" + stage + "'   ";
            
            SqlCommand command = new SqlCommand(cmdText, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                cnt = Convert.ToInt32(reader["cnt"]);

            }
            reader.Close();
            connection.Close();
            return cnt;
        }


        public int getCriRegisteredMarkInfoRSCnt3(string stage, string data_status,string valueentered2,string valueentered3)
        {
            int cnt = 0;
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (data_status == "Certified")
            {
                // cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Certified') " ;

                cmdText = "select count(*)  cnt from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status = '" + stage + "' AND pwallet.data_status = 'Certified' ";

            }

            if (data_status == "Not Opposed")
            {
                // cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Certified') " ;

                cmdText = "select count(*)  cnt from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status = '" + stage + "' AND pwallet.data_status = 'Not Opposed' ";

            }

            if (data_status == "Published")
            {
                // cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Certified') " ;

                cmdText = "select count(*)  cnt from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status = '" + stage + "' AND pwallet.data_status = 'Published' ";

            }
            else if (data_status == "Deferred")
            {
                cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Deferred') ";
            }
            else if (data_status == "Registered")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status >'" + stage + "' AND pwallet.data_status='" + data_status + "' ";
            }

            else if (data_status == "Accepted")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_office  ON tm_office.pwalletID = pwallet.ID  WHERE  pwallet.status<>'33' AND tm_office.data_status ='Accepted' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND pwallet.data_status<>'New' AND CAST(pwallet.status AS INT)>=5 AND tm_office.reg_date BETWEEN( '" + valueentered2 + "' ) AND ('" + valueentered3 + "' ) ";
            }


            SqlCommand command = new SqlCommand(cmdText, connection);


            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                cnt = Convert.ToInt32(reader["cnt"]);

            }
            reader.Close();
            connection.Close();
            return cnt;
        }



        public int getCurrentBatch()
        {
           
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
          //  string cmdText = "select top 1 (pwallet.visible) as 'cur_batch' from pwallet WHERE (pwallet.status >'5') AND ( pwallet.applicantID <> 'CLD/SA/22') GROUP BY pwallet.visible ORDER BY pwallet.visible DESC";
            string cmdText = "select top 1 (pwallet.visible) as 'cur_batch' from pwallet WHERE (pwallet.status >'5') AND ( pwallet.applicantID <> 'CLD/SA/22') GROUP BY pwallet.visible ORDER BY CAST(pwallet.visible AS INT) DESC";
            SqlCommand command = new SqlCommand(cmdText, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["cur_batch"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }

        public int getCurrentBatch2(int  id )
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            string cmdText = "select top 1 (pwallet.visible) as 'cur_batch' from pwallet WHERE pwallet.ID='" + id + "'  and  (pwallet.status >='5') AND ( pwallet.applicantID <> 'CLD/SA/22') GROUP BY pwallet.visible ORDER BY pwallet.visible DESC";
            SqlCommand command = new SqlCommand(cmdText, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["cur_batch"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }

        //public int getCurrentBatch()
        //{
        //    int num = 0;
        //    SqlConnection connection = new SqlConnection(this.Connect());
        //    string cmdText = "select top 1 (pwallet.visible) as 'cur_batch' from pwallet WHERE (pwallet.status >'5') AND ( pwallet.applicantID <> 'CLD/SA/22') and pwallet.visible!=6 GROUP BY pwallet.visible ORDER BY pwallet.visible DESC";
        //    SqlCommand command = new SqlCommand(cmdText, connection);
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        //    while (reader.Read())
        //    {
        //        num = Convert.ToInt32(reader["cur_batch"]);
        //    }
        //    reader.Close();
        //    connection.Close();
        //    return num;
        //}

        public int getCurrentBatchCnt(int batch_no)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select count (pwallet.visible) as 'cur_batch' from pwallet WHERE (pwallet.status >'5') AND ( pwallet.applicantID <> 'CLD/SA/22') AND ( pwallet.visible ='" + batch_no + "')", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["cur_batch"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }

        public List<TmOffice> getCurrentTmOfficeDetailsByID(string pwalletID, string admin_status, string data_status)
        {
            List<TmOffice> list = new List<TmOffice>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT top 1 * FROM tm_office where pwalletID='" + pwalletID + "' AND admin_status='" + admin_status + "' AND data_status='" + data_status + "' ORDER BY ID ASC", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                TmOffice item = new TmOffice
                {
                    ID = reader["ID"].ToString(),
                    pwalletID = reader["pwalletID"].ToString(),
                    admin_status = reader["admin_status"].ToString(),
                    data_status = reader["data_status"].ToString(),
                    xcomment = reader["xcomment"].ToString(),
                    xdoc1 = reader["xdoc1"].ToString(),
                    xdoc2 = reader["xdoc2"].ToString(),
                    xdoc3 = reader["xdoc3"].ToString(),
                    xofficer = reader["xofficer"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    xvisible = reader["xvisible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.G_Applicant_info> getG_ApplicantByLogstaff(string log_staff)
        {
            List<XObjs.G_Applicant_info> list = new List<XObjs.G_Applicant_info>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select * from g_applicant_info LEFT OUTER JOIN g_pwallet ON g_applicant_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5' AND g_applicant_info.log_staff='" + log_staff + "' ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.G_Applicant_info item = new XObjs.G_Applicant_info
                {
                    id = reader["id"].ToString(),
                    xname = reader["xname"].ToString(),
                    address = reader["address"].ToString(),
                    xemail = reader["xemail"].ToString(),
                    xmobile = reader["xmobile"].ToString(),
                    nationality = reader["nationality"].ToString(),
                    trading_as = reader["trading_as"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.G_Applicant_info> getG_ApplicantByName(string xname)
        {
            List<XObjs.G_Applicant_info> list = new List<XObjs.G_Applicant_info>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select * from g_applicant_info LEFT OUTER JOIN g_pwallet ON g_applicant_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5' AND g_applicant_info.xname='" + xname + "' ", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.G_Applicant_info item = new XObjs.G_Applicant_info
                {
                    id = reader["id"].ToString(),
                    xname = reader["xname"].ToString(),
                    address = reader["address"].ToString(),
                    xemail = reader["xemail"].ToString(),
                    xmobile = reader["xmobile"].ToString(),
                    nationality = reader["nationality"].ToString(),
                    trading_as = reader["trading_as"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public string getG_PwalletStatusByID(string id)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT data_status from g_pwallet where ID='" + id + "'", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["data_status"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public string getG_PwalletTransID(string id)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT validationID from pwallet where ID='" + id + "'", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["validationID"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public List<XObjs.G_Tm_info> getG_Tm_infoByName(string xname)
        {
            List<XObjs.G_Tm_info> list = new List<XObjs.G_Tm_info>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select * from g_tm_info LEFT OUTER JOIN g_pwallet ON g_tm_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5' AND g_tm_info.tm_title LIKE '%" + xname + "%' ", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.G_Tm_info item = new XObjs.G_Tm_info
                {
                    xid = reader["xID"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public string getG_TmOfficeByPID(string pwalletID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT data_status from g_tm_office where pwalletID='" + pwalletID + "'", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["data_status"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public List<G_TmOffice> getG_TmOfficeDetailsByID(string ID)
        {
            List<G_TmOffice> list = new List<G_TmOffice>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM g_tm_office WHERE pwalletID='" + ID + "' ", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                G_TmOffice item = new G_TmOffice
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
            connection.Close();
            return list;
        }

        public string getG_ValidationIDByApp_infoID(string ID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select validationID from g_pwallet where ID IN ( select log_staff from g_app_info where ID='" + ID + "' ) ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["validationID"].ToString();
            }
            reader.Close();
            
            connection.Close();
            return str;
        }

        public List<XObjs.G_App_info> getGAdminSearchAppInfoRS(string status, string data_status, string criteria, string kword, string dateFrom, string dateTo)
        {
            List<XObjs.G_App_info> list = new List<XObjs.G_App_info>();
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (criteria == "applicant_name")
            {
                List<XObjs.G_Applicant_info> list2 = this.getG_ApplicantByName(kword);
                if (list2.Count > 0)
                {
                    cmdText = "select * from g_app_info LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5' AND g_app_info.log_staff='" + list2[0].log_staff + "' ";
                }
                else
                {
                    cmdText = "select * from g_app_info LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5' AND g_app_info.log_staff='vcx' ";
                }
            }
            else if (criteria == "reg_no")
            {
                cmdText = "select * from g_app_info LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5' AND g_app_info.reg_no='" + kword + "' ";
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.G_App_info item = new XObjs.G_App_info
                {
                    id = reader["id"].ToString(),
                    rtm_number = reader["rtm_number"].ToString(),
                    application_no = reader["application_no"].ToString(),
                    item_code = reader["item_code"].ToString(),
                    filing_date = reader["filing_date"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }


        public List<XrowCount> getNew_RowCount10(string status, string data_status)
        {
            List<XrowCount> list = new List<XrowCount>();


            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //  SqlCommand command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.ID 'ID',applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY pwallet.ID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE   pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22'  AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' order by ID DESC " }), connection)

            SqlCommand command = new SqlCommand(string.Concat(new object[] { "select ROW_NUMBER() OVER (ORDER BY g_app_info.ID) AS 'RowRank', g_app_info.log_staff AS  'tblID' from g_app_info  LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff   LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID       WHERE g_pwallet.stage='5' AND  g_pwallet.status='", status, "' AND g_pwallet.data_status='", data_status, "'   " }), connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XrowCount item = new XrowCount
                {
                    RowRanks = reader["RowRank"].ToString(),
                    Tblld = reader["tblID"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;

        }

        public List<XrowCount> getNew_RowCount11(string status, string data_status)
        {
            List<XrowCount> list = new List<XrowCount>();


            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //  SqlCommand command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.ID 'ID',applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY pwallet.ID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE   pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22'  AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' order by ID DESC " }), connection)

            SqlCommand command = new SqlCommand(string.Concat(new object[] { "select ROW_NUMBER() OVER (ORDER BY g_app_info.ID) AS 'RowRank', g_tm_info.xid AS  'tblID' from g_app_info  LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff   LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID       WHERE g_pwallet.stage='5' AND    g_tm_info.xid !='' AND  g_pwallet.status='", status, "' AND g_pwallet.data_status='", data_status, "'   " }), connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XrowCount item = new XrowCount
                {
                    RowRanks = reader["RowRank"].ToString(),
                    Tblld = reader["tblID"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;

        }

        public XObjs.Fee_list getFee_listByID2(string xid)
        {
            XObjs.Fee_list _list = new XObjs.Fee_list();
            
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("SELECT * FROM fee_list WHERE item_code='" + xid + "' ", connection);
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
        
        public List<XObjs.G_App_info> getGAppInfoRSX(string status, string data_status, string start, string limit)
        {
            List<XObjs.G_App_info> list = new List<XObjs.G_App_info>();
            SqlConnection connection = new SqlConnection(this.Connect());
            string str = "WITH RSTbl AS ( select g_tm_info.tm_title 'tm_title',g_tm_info.tm_class 'xclass', g_pwallet.log_officer,g_tm_info.reg_number,g_app_info.ID,g_app_info.rtm_number,g_app_info.application_no,g_app_info.item_code,g_app_info.filing_date,g_app_info.reg_no, ";
            string str2 = str + " g_app_info.reg_date,g_app_info.log_staff,g_app_info.visible, ROW_NUMBER() OVER (ORDER BY g_app_info.reg_date) AS 'RowRank' from g_app_info " + " LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff ";
            string str3 = str2 + " LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE (g_pwallet.stage='5' AND g_pwallet.status='" + status + "' AND g_pwallet.data_status='" + data_status + "' ) ";
            //SqlCommand command = new SqlCommand(str3 + " ) SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection)
            //{
            //    CommandTimeout = 300
            //};


            SqlCommand command = new SqlCommand(string.Concat(new object[] { "Select * from (select g_tm_info.xID 'xID', g_tm_info.tm_title 'tm_title',g_tm_info.tm_class 'xclass', g_pwallet.log_officer,g_tm_info.reg_number,g_app_info.ID,g_app_info.rtm_number,g_app_info.application_no,g_app_info.item_code ,g_app_info.filing_date,g_app_info.reg_no,g_app_info.reg_date,g_app_info.log_staff,g_app_info.visible from g_app_info " + " LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff  LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE (g_pwallet.stage='5' AND g_pwallet.status= '" + status + "' AND g_pwallet.data_status='" + data_status + "'   ) )as Tab WHERE Tab.XID BETWEEN '", start, "' AND '", limit, "' order BY XID ASC " }), connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.G_App_info item = new XObjs.G_App_info
                {
                    id = reader["id"].ToString(),
                    xclass = reader["xclass"].ToString(),
                    tm_title = reader["tm_title"].ToString(),
                    rtm_number = reader["rtm_number"].ToString(),
                    application_no = reader["application_no"].ToString(),
                    item_code = reader["log_officer"].ToString(),
                    filing_date = reader["filing_date"].ToString(),
                    reg_no = reader["reg_number"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }


        public List<XObjs.G_App_info> getGAppInfoRSX2(string status, string data_status, string start, string limit)
        {
            List<XObjs.G_App_info> list = new List<XObjs.G_App_info>();
            SqlConnection connection = new SqlConnection(this.Connect());
            string str = "WITH RSTbl AS ( select g_tm_info.tm_title 'tm_title',g_tm_info.tm_class 'xclass', g_pwallet.log_officer,g_tm_info.reg_number,g_app_info.ID,g_app_info.rtm_number,g_app_info.application_no,g_app_info.item_code,g_app_info.filing_date,g_app_info.reg_no, ";
            string str2 = str + " g_app_info.reg_date,g_app_info.log_staff,g_app_info.visible, ROW_NUMBER() OVER (ORDER BY g_app_info.reg_date) AS 'RowRank' from g_app_info " + " LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff ";
            string str3 = str2 + " LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE (g_pwallet.stage='5' AND g_pwallet.status='" + status + "' AND g_pwallet.data_status='" + data_status + "' ) ";
            //SqlCommand command = new SqlCommand(str3 + " ) SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection)
            //{
            //    CommandTimeout = 300
            //};


            SqlCommand command = new SqlCommand(string.Concat(new object[] { "select g_tm_info.xID 'xID', g_tm_info.tm_title 'tm_title',g_tm_info.tm_class 'xclass', g_pwallet.log_officer,g_pwallet.validationID,g_tm_info.reg_number,g_applicant_info.xname ,g_app_info.ID,g_app_info.rtm_number,g_app_info.application_no,g_app_info.item_code ,g_app_info.filing_date,g_app_info.reg_no,g_app_info.reg_date,g_app_info.log_staff,g_app_info.visible from g_app_info " + " LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff  LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID left outer join g_applicant_info on g_applicant_info.log_staff =g_pwallet.ID  WHERE (g_pwallet.stage='5' AND g_pwallet.status= '" + status + "' AND g_pwallet.data_status='" + data_status + "'    )  order by  g_tm_info.xID ASC  " }), connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string ssp = "";
            int sn = 0;
            string vdesc = "";
            
            while (reader.Read())
            {
                ssp = getG_PwalletStatusByID(reader["log_staff"].ToString());

                if (ssp == "")
                {

                    ssp = "None";
                }

                sn = sn + 1;

                try {
                    vdesc = getFee_listByID2(reader["item_code"].ToString()).item;

                }

                catch (Exception ee)
                {

                }


                XObjs.G_App_info item = new XObjs.G_App_info
                {
                   
                    id = reader["id"].ToString(),
                    xclass = reader["xclass"].ToString(),
                    tm_title = reader["tm_title"].ToString(),
                    rtm_number = reader["rtm_number"].ToString(),
                    application_no = reader["application_no"].ToString(),
                    item_code = reader["log_officer"].ToString(),
                    filing_date = reader["filing_date"].ToString(),
                    reg_no = reader["reg_number"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString(),
                    xstat=ssp,
                    Sn=Convert.ToString(sn),
                    req_type = vdesc,
                    oai_no = reader["validationID"].ToString(),
                    xname = reader["xname"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.G_App_info> getGAppInfoRSX12(string status, string data_status, string start, string limit)
        {
            List<XObjs.G_App_info> list = new List<XObjs.G_App_info>();
            SqlConnection connection = new SqlConnection(this.Connect());
            string str = "WITH RSTbl AS ( select g_tm_info.tm_title 'tm_title',g_tm_info.tm_class 'xclass', g_pwallet.log_officer,g_tm_info.reg_number,g_app_info.ID,g_app_info.rtm_number,g_app_info.application_no,g_app_info.item_code,g_app_info.filing_date,g_app_info.reg_no, ";
            string str2 = str + " g_app_info.reg_date,g_app_info.log_staff,g_app_info.visible, ROW_NUMBER() OVER (ORDER BY g_app_info.reg_date) AS 'RowRank' from g_app_info " + " LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff ";
            string str3 = str2 + " LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE (g_pwallet.stage='5' AND g_pwallet.status='" + status + "' AND g_pwallet.data_status='" + data_status + "' ) ";
            //SqlCommand command = new SqlCommand(str3 + " ) SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection)
            //{
            //    CommandTimeout = 300
            //};


            SqlCommand command = new SqlCommand(string.Concat(new object[] { "select ''  as  description, g_tm_info.xID 'xID', g_tm_info.tm_title 'tm_title',g_tm_info.tm_class 'xclass', g_pwallet.log_officer,g_pwallet.applicantID,g_pwallet.validationID,g_tm_info.reg_number,g_applicant_info.xname ,g_app_info.ID,g_app_info.rtm_number,g_app_info.application_no,g_app_info.item_code ,g_app_info.filing_date,g_app_info.reg_no,g_app_info.reg_date,g_app_info.log_staff,g_app_info.visible from g_app_info " + " LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff  LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID left outer join g_applicant_info on g_applicant_info.log_staff =g_pwallet.ID  WHERE (g_pwallet.stage='5' AND g_pwallet.status= '" + status + "' AND g_pwallet.data_status='" + data_status + "'    )  order by  g_tm_info.xID ASC  " }), connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string ssp = "";
            int sn = 0;
            string vdesc = "";

            while (reader.Read())
            {
                ssp = getG_PwalletStatusByID(reader["log_staff"].ToString());

                if (ssp == "")
                {

                    ssp = "None";
                }

                sn = sn + 1;

                try
                {
                    vdesc = getFee_listByID2(reader["item_code"].ToString()).item;

                }

                catch (Exception ee)
                {

                }


                XObjs.G_App_info item = new XObjs.G_App_info
                {

                    id = reader["id"].ToString(),
                    xclass = reader["xclass"].ToString(),
                    tm_title = reader["tm_title"].ToString(),
                    description= reader["description"].ToString() ,

                    log_staff = reader["log_staff"].ToString(),

                    reg_no = reader["reg_number"].ToString(),
                 
                    reg_date = reader["reg_date"].ToString(),
                   
                    xstat = ssp,
                    Sn = Convert.ToString(sn),
                    req_type = vdesc,
                    oai_no = reader["validationID"].ToString(),
                    xname = reader["xname"].ToString(),
                    Agent_Code = reader["applicantID"].ToString() 
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.G_App_info> getGAppInfoRSX13(string status)
        {
            List<XObjs.G_App_info> list = new List<XObjs.G_App_info>();
            SqlConnection connection = new SqlConnection(this.Connect());
          
            //SqlCommand command = new SqlCommand(str3 + " ) SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection)
            //{
            //    CommandTimeout = 300
            //};


            SqlCommand command = new SqlCommand(string.Concat(new object[] { "select g_pwallet.applicantID, g_tm_info.xID 'xID', g_tm_info.tm_title 'tm_title',g_tm_info.tm_class 'xclass', g_pwallet.log_officer,g_pwallet.validationID,g_tm_info.reg_number,g_applicant_info.xname ,g_app_info.ID,g_app_info.rtm_number,g_app_info.application_no,g_app_info.item_code ,g_app_info.filing_date,g_app_info.reg_no,g_app_info.reg_date,g_app_info.log_staff,g_app_info.visible from g_app_info " + " LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff  LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID left outer join g_applicant_info on g_applicant_info.log_staff =g_pwallet.ID  WHERE (g_pwallet.stage='5' AND g_tm_info.reg_number= '" + status + "'     )   " }), connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string ssp = "";
            int sn = 0;
            string vdesc = "";

            while (reader.Read())
            {
                ssp = getG_PwalletStatusByID(reader["log_staff"].ToString());

                if (ssp == "")
                {

                    ssp = "None";
                }

                sn = sn + 1;

                try
                {
                    vdesc = getFee_listByID2(reader["item_code"].ToString()).item;

                }

                catch (Exception ee)
                {

                }


                XObjs.G_App_info item = new XObjs.G_App_info
                {

                    id = reader["id"].ToString(),
                    xclass = reader["xclass"].ToString(),
                    tm_title = reader["tm_title"].ToString(),


                    log_staff = reader["log_staff"].ToString(),

                    reg_no = reader["reg_number"].ToString(),

                    reg_date = reader["reg_date"].ToString(),

                    xstat = ssp,
                    Sn = Convert.ToString(sn),
                    req_type = vdesc,
                    oai_no = reader["validationID"].ToString(),
                    xname = reader["xname"].ToString(),
                    application_no = reader["applicantID"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.G_App_info> getGAppInfoRSX14(string status)
        {
            List<XObjs.G_App_info> list = new List<XObjs.G_App_info>();
            SqlConnection connection = new SqlConnection(this.Connect());

            //SqlCommand command = new SqlCommand(str3 + " ) SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection)
            //{
            //    CommandTimeout = 300
            //};


            SqlCommand command = new SqlCommand(string.Concat(new object[] { "select g_pwallet.applicantID, g_tm_info.xID 'xID', g_tm_info.tm_title 'tm_title',g_tm_info.tm_class 'xclass', g_pwallet.log_officer,g_pwallet.validationID,g_tm_info.reg_number,g_applicant_info.xname ,g_app_info.ID,g_app_info.rtm_number,g_app_info.application_no,g_app_info.item_code ,g_app_info.filing_date,g_app_info.reg_no,g_app_info.reg_date,g_app_info.log_staff,g_app_info.visible from g_app_info " + " LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff  LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID left outer join g_applicant_info on g_applicant_info.log_staff =g_pwallet.ID  WHERE (g_pwallet.stage='5' AND g_pwallet.validationID= '" + status + "'     )   " }), connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string ssp = "";
            int sn = 0;
            string vdesc = "";

            while (reader.Read())
            {
                ssp = getG_PwalletStatusByID(reader["log_staff"].ToString());

                if (ssp == "")
                {

                    ssp = "None";
                }

                sn = sn + 1;

                try
                {
                    vdesc = getFee_listByID2(reader["item_code"].ToString()).item;

                }

                catch (Exception ee)
                {

                }


                XObjs.G_App_info item = new XObjs.G_App_info
                {

                    id = reader["id"].ToString(),
                    xclass = reader["xclass"].ToString(),
                    tm_title = reader["tm_title"].ToString(),


                    log_staff = reader["log_staff"].ToString(),

                    reg_no = reader["reg_number"].ToString(),

                    reg_date = reader["reg_date"].ToString(),

                    xstat = ssp,
                    Sn = Convert.ToString(sn),
                    req_type = vdesc,
                    oai_no = reader["validationID"].ToString(),
                    xname = reader["xname"].ToString(),
                    application_no = reader["applicantID"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }
        
        public long getGwalletRSCnt(string status, string data_status)
        {
            SqlCommand command;
            long num = 0L; string cmd = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            cmd += " WITH RSTbl AS (select Count(*) AS cnt from g_app_info LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff ";
            if (data_status != "")
            {
                cmd += " LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE (g_pwallet.stage='5' AND g_pwallet.status='" + status + "' AND g_pwallet.data_status='" + data_status + "' )  ";
            }
            else
            {
                cmd += " LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5' AND g_pwallet.status='" + status + "'   ";
            }
            cmd += " ) SELECT * FROM RSTbl  ";
           
            command = new SqlCommand(cmd, connection);            
            command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt64(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }

        // public long getGwalletRSCnt(string status, string data_status)
        //{
        //    SqlCommand command;
        //    long num = 0L;
        //    SqlConnection connection = new SqlConnection(this.Connect());
        //    if (data_status != "")
        //    {
        //        command = new SqlCommand("select Count(*) AS cnt from g_app_info LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5' AND g_pwallet.status='" + status + "' AND g_pwallet.data_status='" + data_status + "' ", connection);
        //    }
        //    else
        //    {
        //        command = new SqlCommand("select Count(*) AS cnt from g_app_info LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID LEFT OUTER JOIN g_applicant_info ON g_applicant_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5' AND g_pwallet.status='" + status + "' ", connection);
        //    }
        //    command.CommandTimeout = 300;
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        //    while (reader.Read())
        //    {
        //        num = Convert.ToInt64(reader["cnt"]);
        //    }
        //    reader.Close();
        //    return num;
        //}


        public List<MarkInfo> getIndexInfoRS(string stage, string data_status)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status >'" + stage + "' AND ( pwallet.applicantID <> 'CLD/SA/22')  ORDER BY CAST(national_classID AS INT), product_title ASC ", connection);
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getIndexInfoRS3(string stage, string data_status,string from2 ,string to2 )
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select   * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status >='" + stage + "' AND ( pwallet.applicantID <> 'CLD/SA/22')  and SUBSTRING(reg_number, LEN([reg_number]) -  CHARINDEX('T', REVERSE([reg_number])) +1  , LEN([reg_number]))  between  '" + from2 + "' and  '" + to2 + "' ORDER BY CAST(national_classID AS INT), product_title ASC ", connection);
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getIndexInfoRS3a(string stage, string data_status, string from2)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select   * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status >='" + stage + "' AND ( pwallet.applicantID <> 'CLD/SA/22')  and reg_number = '" + from2 + "'   ", connection);
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getIndexInfoRS2(string stage, string data_status,string xid)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE  mark_info.xID ='" + xid + "' AND ( pwallet.applicantID <> 'CLD/SA/22')  ", connection);
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getIndexInfoRSByAmount(string stage, string data_status, string from, string to)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            string str2 = ("WITH RSTbl AS (select mark_info.*, ROW_NUMBER() OVER " + " (ORDER BY CAST(mark_info.national_classID AS INT),mark_info.xID ASC) AS 'RowRank' " + " from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID ") + " WHERE (pwallet.status >'" + stage + "')  AND ( pwallet.applicantID <> 'CLD/SA/22') ) ";
            SqlCommand command = new SqlCommand(str2 + " SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + from + "' AND '" + to + "' ", connection);
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getIndexInfoRSByAmountAndBno(string stage, string data_status, string from, string to, string bno)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            str = "WITH RSTbl AS (select mark_info.*, ROW_NUMBER() OVER ";
            string str2 = str + " (ORDER BY CAST(mark_info.national_classID AS INT),mark_info.xID ASC) AS 'RowRank' " + " from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID ";
            string str3 = str2 + " WHERE (pwallet.status >'" + stage + "') AND (pwallet.visible ='" + bno + "') AND ( pwallet.applicantID <> 'CLD/SA/22') ) ";
          //  SqlCommand command = new SqlCommand((str3 + " SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + from + "' AND '" + to + "' ") + " ORDER BY product_title ASC ", connection);
            SqlCommand command = new SqlCommand((str3 + " SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + from + "' AND '" + to + "' ") + " ORDER BY CAST(national_classID AS INT) , product_title ASC  ", connection);
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getIndexInfoRSByAmountAndBno33(string stage, string data_status, string from, string to, string bno,string id )
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            str = "(select mark_info.* ";
            string str2 = str + "  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID ";
            string str3 = str2 + " WHERE pwallet.ID='" + id + "' and  (pwallet.status >='" + stage + "') AND (pwallet.visible ='" + bno + "') AND ( pwallet.applicantID <> 'CLD/SA/22') ) ";
            //  SqlCommand command = new SqlCommand((str3 + " SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + from + "' AND '" + to + "' ") + " ORDER BY product_title ASC ", connection);
            SqlCommand command = new SqlCommand(str3, connection);
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getIndexInfoRSByAmountAndBno2(string stage, string data_status, string from, string to, string bno)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
          //  str = "WITH RSTbl AS (select mark_info.*, ROW_NUMBER() OVER ";
          //  string str2 = str + " (ORDER BY CAST(mark_info.national_classID AS INT),mark_info.xID ASC) AS 'RowRank' " + " from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID ";
          //  string str3 = str2 + " WHERE (pwallet.status >'" + stage + "') AND (pwallet.visible ='" + bno + "') AND ( pwallet.applicantID <> 'CLD/SA/22') ) ";
            //  SqlCommand command = new SqlCommand((str3 + " SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + from + "' AND '" + to + "' ") + " ORDER BY product_title ASC ", connection);
            //    SqlCommand command = new SqlCommand((str3 + " SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + from + "' AND '" + to + "' ") + " ORDER BY CAST(national_classID AS INT) ASC ", connection);
            SqlCommand   command = new SqlCommand(string.Concat(new object[] { "SELECT* FROM (select mark_info.*,ROW_NUMBER() OVER(ORDER BY CAST(mark_info.national_classID AS INT),mark_info.xID ASC ) AS NUMBER from  mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID    WHERE WHERE (pwallet.status >'" + stage + "') AND (pwallet.visible ='" + bno + "') AND ( pwallet.applicantID <> 'CLD/SA/22') ) AS TBL  " }), connection);
            command.CommandTimeout = 0;

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
            connection.Close();
            return list;
        }

        public TmOffice getLastTmOfficeByID(string ID)
        {
            TmOffice office = new TmOffice();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT top 1 * from tm_office where pwalletID='" + ID + "' order by ID desc", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                office.ID = reader["ID"].ToString();
                office.admin_status = reader["admin_status"].ToString();
                office.data_status = reader["data_status"].ToString();
                office.pwalletID = reader["pwalletID"].ToString();
                office.reg_date = reader["reg_date"].ToString();
                office.xcomment = reader["xcomment"].ToString();
                office.xdoc1 = reader["xdoc1"].ToString();
                office.xdoc2 = reader["xdoc2"].ToString();
                office.xdoc3 = reader["xdoc3"].ToString();
                office.xofficer = reader["xofficer"].ToString();
                office.xtime = reader["xtime"].ToString();
                office.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            connection.Close();
            return office;
        }



        public TmOffice getLastTmOfficeByID2(string ID,string regdate)
        {
            TmOffice office = new TmOffice();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT top 1 * from tm_office where data_status='Recordal' and   pwalletID ='" + ID + "'  and reg_date ='" + regdate + "' order by ID desc", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                office.ID = reader["ID"].ToString();
                office.admin_status = reader["admin_status"].ToString();
                office.data_status = reader["data_status"].ToString();
                office.pwalletID = reader["pwalletID"].ToString();
                office.reg_date = reader["reg_date"].ToString();
                office.xcomment = reader["xcomment"].ToString();
                office.xdoc1 = reader["xdoc1"].ToString();
                office.xdoc2 = reader["xdoc2"].ToString();
                office.xdoc3 = reader["xdoc3"].ToString();
                office.xofficer = reader["xofficer"].ToString();
                office.xtime = reader["xtime"].ToString();
                office.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            connection.Close();
            return office;
        }

        public int updateTransID2(string xid, string Sys_ID2)
        {
            //int vcount = updateTransID2b(xid,  Sys_ID2);
            //if (vcount > 0 )
            //{
            //    throw new System.InvalidOperationException("Id Already Exist");
            //}
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("UPDATE pwallet  SET TransactionId='" + Sys_ID2 + "' WHERE validationID='" + xid + "'  ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int updateTransID2b(string xid, string Sys_ID2)
        {
            int  num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select Count(*) AS cnt from  pwallet  where  TransactionId='" + Sys_ID2 + "'  ", connection);
           // SqlCommand command = new SqlCommand("select Count(*) AS cnt from  pwallet  where  TransactionId='" + xid + "'  ", connection);
            connection.Open();
            SqlDataReader reader6 = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader6.Read())
            {
                num = Convert.ToInt32(reader6["cnt"]);
            }
            reader6.Close();
            //  connection.Close();

            return num;
        }

        public Applicant getApplicant2ByID(string ID)
        {
            Applicant office = new Applicant();
            SqlConnection connection = new SqlConnection(this.Connect2());
            SqlCommand command = new SqlCommand("select * from applicant  inner join twallet on applicant.xid =twallet.applicantID  where transID='" + ID + "' and xpay_status='1' ", connection)
            {
                //   CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                office.Applicant_Id = reader["xid"].ToString();
                office.Applicant_Name = reader["xname"].ToString();
                office.Applicant_Address = reader["address"].ToString();
                office.Applicant_Email = reader["xemail"].ToString();
                office.Applicant_Mobile = reader["xmobile"].ToString();
                office.TransId = reader["transID"].ToString();

            }
            reader.Close();
            connection.Close();
            return office;
        }


      

        public string  getAgentID(string ID)
        {
            Applicant office = new Applicant();
            SqlConnection connection = new SqlConnection(this.Connect2());
            SqlCommand command = new SqlCommand("select * from  twallet inner join hwallet on  twallet.transid =hwallet.transid   where hwallet.xid='" + ID + "' and xpay_status='1' ", connection)
            {
                //   CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var xmemberid = "";
            while (reader.Read())
            {
                xmemberid = reader["xmemberID"].ToString();
             

            }
            reader.Close();
            connection.Close();

            xmemberid = getAgentID2(xmemberid);
            return xmemberid;
        }


        public string  getAgentID2(string ID)
        {
            Applicant office = new Applicant();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("select * from  registrations  where xid='" + ID + "'  ", connection)
            {
                //   CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var Sys_ID = "";
            while (reader.Read())
            {
                Sys_ID = reader["Sys_ID"].ToString();


            }
            reader.Close();
            connection.Close();
            return Sys_ID;
        }

        public string getAgentID3(string ID)
        {
            Applicant office = new Applicant();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select * from  pwallet   where validationid='" + ID + "'  ", connection)
            {
                //   CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var Sys_ID = "";
            while (reader.Read())
            {
                Sys_ID = reader["applicantID"].ToString();


            }
            reader.Close();
            connection.Close();
            return Sys_ID;
        }
        public Applicant getApplicant3ByID(string ID, string ID2)
        {
            Applicant office = new Applicant();
            SqlConnection connection = new SqlConnection(this.Connect2());
            SqlCommand command = new SqlCommand("select applicant.xid,applicant.xname ,applicant.address,applicant.xemail ,applicant.xmobile ,hwallet.transID,hwallet.fee_detailsid,hwallet.xid as 'cnt' from applicant  inner join twallet on applicant.xid =twallet.applicantID inner join hwallet on hwallet.transID =twallet.transID  inner join fee_details on fee_details.twalletID=twallet.XID where twallet.transID='" + ID + "' and hwallet.xid='" + ID2 + "'  and xpay_status='1' and (fee_details.fee_listID='3' or fee_details.fee_listID='10064'  or fee_details.fee_listID='10062'  ) ", connection)
            {
             //   CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                office.Applicant_Id = reader["xid"].ToString();
                office.Applicant_Name = reader["xname"].ToString();
                office.Applicant_Address = reader["address"].ToString();
                office.Applicant_Email = reader["xemail"].ToString();
                office.Applicant_Mobile = reader["xmobile"].ToString();
                office.TransId = reader["transID"].ToString() +"-"+ reader["fee_detailsid"].ToString() + "-"+ reader["cnt"].ToString();
               
            }
            reader.Close();
            connection.Close();
            return office;
        }

        public Applicant getApplicant3bByID(string ID)
        {
            Applicant office = new Applicant();
            SqlConnection connection = new SqlConnection(this.Connect2());
            SqlCommand command = new SqlCommand("select * from applicant  inner join twallet on applicant.xid =twallet.applicantID inner join hwallet on hwallet.transID =twallet.transID  inner join fee_details on fee_details.twalletID=twallet.XID where twallet.transID='" + ID + "'  and xpay_status='1' and fee_details.fee_listID='3' ", connection)
            {
                  CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                office.Applicant_Id = reader["xid"].ToString();
                office.Applicant_Name = reader["xname"].ToString();
                office.Applicant_Address = reader["address"].ToString();
                office.Applicant_Email = reader["xemail"].ToString();
                office.Applicant_Mobile = reader["xmobile"].ToString();
                office.TransId = reader["transID"].ToString();

            }
            reader.Close();
            connection.Close();
            return office;
        }

        public string  getPaymentTransid(string ID)
        {
            if (ID =="")
            {

                return "";
            }
            Applicant office = new Applicant();
            SqlConnection connection = new SqlConnection(this.Connect2());
            SqlCommand command = new SqlCommand("select transid+'-'+fee_detailsID +'-' + CAST(xid  AS varchar(12)) as cnt from hwallet   where transID='" + ID + "'   ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            string vtransid = "";
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {

                vtransid = reader["cnt"].ToString();
                

            }
            reader.Close();
            connection.Close();

            if (vtransid =="")
            {

                return ID;
            }

            else
            {
                return vtransid;

            }
          
        }

        public Applicant getApplicant6ByID(string ID)
        {
            Applicant office = new Applicant();
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
          //  SqlCommand command = new SqlCommand("select * from applicant  inner join twallet on applicant.xid =twallet.applicantID  where transID='" + ID + "' and xpay_status='1' ", connection)

            SqlCommand command = new SqlCommand("select id, TransactionID,ApplicantName,ApplicantAddress,ApplicantEmail,ApplicantPhone from  branchcollecttransactions     where TransactionID='" + ID + "'   ", connection)
            {
                //   CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                office.Applicant_Id = reader["id"].ToString();
                office.Applicant_Name = reader["ApplicantName"].ToString();
                office.Applicant_Address = reader["ApplicantAddress"].ToString();
                office.Applicant_Email = reader["ApplicantEmail"].ToString();
                office.Applicant_Mobile = reader["ApplicantPhone"].ToString();
                office.TransId = reader["TransactionID"].ToString();

            }
            reader.Close();
            connection.Close();
            return office;
        }

        public String CheckLogin(Login pp)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
           
            string str = "0";
            string cmdText = "";
            string xadmin = "";


            cmdText = "SELECT count(*) as count FROM xadminz_tm  where CONVERT(VARCHAR, xemail)='" + pp.Email + "'  and CONVERT(VARCHAR, xpass) ='' ";
            
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["count"].ToString();
            }
            int vcount = Convert.ToInt32(str);
            if (vcount > 0  )
            {
                xadmin = CheckLogin2(pp.Email);
            }

            else
            {
                xadmin = CheckLogin3(pp);
            }
           
            reader.Close();
            connection.Close();
           
            return xadmin ;

        }

        public string CheckLogin2(string email)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT xID from xadminz_tm where CONVERT(VARCHAR, xemail)='" + email + "'  and CONVERT(VARCHAR, xpass) =''", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["xID"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public string CheckLogin3(Login cf)
        {
            string str = "";

            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO xadminz_tm (xroleID,xname,xemail,xpass) VALUES (@pwalletID,@response_deadline,@xofficerID,@xmsg) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@pwalletID", SqlDbType.VarChar, 50);
            command.Parameters.Add("@response_deadline", SqlDbType.VarChar, 50);
            command.Parameters.Add("@xofficerID", SqlDbType.VarChar);
            command.Parameters.Add("@xmsg", SqlDbType.VarChar);
          
           
            command.Parameters["@pwalletID"].Value = "1";
            command.Parameters["@response_deadline"].Value = cf.name;
            command.Parameters["@xofficerID"].Value = cf.Email;
            command.Parameters["@xmsg"].Value ="";
            
            str = command.ExecuteScalar().ToString();
            connection.Close();
            return str;
        }

        public int UpdateApplicant(Applicant pp)
        {
            SqlConnection connection = new SqlConnection(this.Connect2());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE applicant SET xname=@status,address=@data_status,xemail=@data_status2 ,xmobile=@data_status3 WHERE xid=@ID ";
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@status", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@data_status", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@data_status2", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@data_status3", SqlDbType.NVarChar, 50);
            command.Parameters["@ID"].Value = Convert.ToInt64(pp.Applicant_Id);
            command.Parameters["@status"].Value = pp.Applicant_Name;
            command.Parameters["@data_status"].Value = pp.Applicant_Address;
            command.Parameters["@data_status2"].Value = pp.Applicant_Email;
            command.Parameters["@data_status3"].Value = pp.Applicant_Mobile;

            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public string getLogoDescriptionNameByID(string id)
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
            connection.Close();
            return str;
        }

        public List<MarkInfo> getMarkInfoByDataStatusRS(string stage, string data_status)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select * from mark_info LEFT OUTER JOIN tm_office ON mark_info.log_staff=tm_office.pwalletID WHERE tm_office.admin_status='" + stage + "' AND tm_office.data_status='" + data_status + "' ORDER BY xID ASC", connection);
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
            connection.Close();
            return list;
        }

        public MarkInfo getMarkInfoByUserID(string ID)
        {
            MarkInfo info = new MarkInfo
            {
                xID = "",
                reg_number = "",
                tm_typeID = "",
                logo_descriptionID = "",
                national_classID = "",
                product_title = "",
                nice_class = "",
                nice_class_desc = "",
                sign_type = "",
                vienna_class = "",
                disclaimer = "",
                logo_pic = "",
                auth_doc = "",
                sup_doc1 = "",
                sup_doc2 = "",
                log_staff = "",
                reg_date = "",
                xvisible = ""
            };
            SqlConnection connection = new SqlConnection(this.Connect());
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
            connection.Close();
            return info;
        }


        public MarkInfo getMarkInfoByUserID2(string ID)
        {
            MarkInfo info = new MarkInfo
            {
                xID = "",
                reg_number = "",
                tm_typeID = "",
                logo_descriptionID = "",
                national_classID = "",
                product_title = "",
                nice_class = "",
                nice_class_desc = "",
                sign_type = "",
                vienna_class = "",
                disclaimer = "",
                logo_pic = "",
                auth_doc = "",
                sup_doc1 = "",
                sup_doc2 = "",
                log_staff = "",
                reg_date = "",
                xvisible = ""
            };
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM mark_infoAmendment WHERE xID='" + ID + "' ", connection);
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
            connection.Close();
            return info;
        }

        public List<MarkInfo> getMarkInfoRS(string status, string data_status)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = null;
            if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
            {
                command = new SqlCommand("select mark_info.*,pwallet.rtm from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused')) ORDER BY xID ASC", connection);
            }
            else
            {
                command = new SqlCommand("select mark_info.*,pwallet.rtm from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' ORDER BY xID ASC", connection);
            }
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
                    xvisible = reader["xvisible"].ToString(),
                    rtm = reader["rtm"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public long getMarkInfoRSCnt2(string status, string data_status)
        {
            long num = 0L;
            SqlConnection connection = new SqlConnection(this.Connect());

            SqlCommand command6 = new SqlCommand("select Count(*) AS cnt from g_tm_info LEFT OUTER JOIN g_pwallet ON g_tm_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5' AND g_pwallet.status='" + status + "' AND g_pwallet.data_status='" + data_status + "' ", connection)
            {
                //   CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader6 = command6.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader6.Read())
            {
                num = Convert.ToInt64(reader6["cnt"]);
            }
            reader6.Close();
            //  connection.Close();

            return num;
        }

        public long getRefuseAppealCnt()
        {
            long num = 0L;
            SqlConnection connection = new SqlConnection(this.Connect());
            
            SqlCommand command = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN AppealRejection  ON pwallet.ID=AppealRejection.DocumentId  WHERE AppealRejection.Status ='Pending'    ", connection)


            {
                //   CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt64(reader["cnt"]);
            }
            reader.Close();
            //  connection.Close();
            return num;
        }

        public long getRefuseAppealCnt2()
        {
            long num = 0L;
            SqlConnection connection = new SqlConnection(this.Connect());

            SqlCommand command = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN AppealRejection  ON pwallet.ID=AppealRejection.DocumentId  WHERE AppealRejection.Status !='Pending'    ", connection)


            {
                //   CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt64(reader["cnt"]);
            }
            reader.Close();
            //  connection.Close();
            return num;
        }


        public long getMarkInfoRSCnt(string status, string data_status)
        {
            long num = 0L;
            SqlConnection connection = new SqlConnection(this.Connect());
            if ((status == "4") && (data_status == "Refused"))
            {
                SqlCommand command = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "'  ", connection)

                
                 {
               //   CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    num = Convert.ToInt64(reader["cnt"]);
                }
                reader.Close();
              //  connection.Close();
                return num;
            }

            if ((status == "5") && (data_status == "amendment"))
            {
                SqlCommand command3 = new SqlCommand("select Count(*) AS cnt from mark_infoAmendment LEFT OUTER JOIN pwalletAmendment ON mark_infoAmendment.log_staff=pwalletAmendment.ID WHERE pwalletAmendment.stage='5' AND  pwalletAmendment.data_status='amendment' ", connection)
                {
                    //  CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader3 = command3.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader3.Read())
                {
                    num = Convert.ToInt64(reader3["cnt"]);
                }
                reader3.Close();
                //   connection.Close();
                return num;
            }

            if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            {
                SqlCommand command2 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable')) ", connection)
                {
                  // CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader2 = command2.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader2.Read())
                {
                    num = Convert.ToInt64(reader2["cnt"]);
                }
                reader2.Close();
            //    connection.Close();
                return num;
            }
            if ((status == "5") && (data_status == "acc_printed"))
            {
                SqlCommand command3 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND  pwallet.acc_p='1' ", connection)
                {
                 //  CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader3 = command3.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader3.Read())
                {
                    num = Convert.ToInt64(reader3["cnt"]);
                }
                reader3.Close();
             //   connection.Close();
                return num;
            }
            if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            {
                  SqlCommand command4 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Fresh') OR (pwallet.data_status='Invalid')) ", connection)
               // SqlCommand command4 = new SqlCommand("select Count(*) AS cnt from mark_info WITH (NOLOCK) LEFT OUTER JOIN pwallet WITH (NOLOCK) ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type WITH (NOLOCK) ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH (NOLOCK) ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' ", connection)
                {
                 //  CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader4 = command4.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader4.Read())
                {
                    num = Convert.ToInt64(reader4["cnt"]);
                }
                reader4.Close();
             //   connection.Close();
                return num;
            }
            if ((status == "8") && (data_status == "Registered"))
            {
                SqlCommand command5 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status>'" + status + "' AND pwallet.data_status='Registered' ", connection)
                {
                  //  CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader5 = command5.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader5.Read())
                {
                    num = Convert.ToInt64(reader5["cnt"]);
                }
                reader5.Close();
              //  connection.Close();
                return num;
            }
              SqlCommand command6 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' ", connection)
            
            {
             //   CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader6 = command6.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader6.Read())
            {
                num = Convert.ToInt64(reader6["cnt"]);
            }
            reader6.Close();
          //  connection.Close();

            return num;
        }

        public long getMarkInfoRSCnt10(string status, string data_status)
        {
            long num = 0L;
            SqlConnection connection = new SqlConnection(this.Connect());
            if ((status == "4") && (data_status == "Refused"))
            {
                SqlCommand command = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "'  ", connection)
                {
                    //   CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    num = Convert.ToInt64(reader["cnt"]);
                }
                reader.Close();
                //  connection.Close();
                return num;
            }
            if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            {
                SqlCommand command2 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable')) ", connection)
                {
                    // CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader2 = command2.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader2.Read())
                {
                    num = Convert.ToInt64(reader2["cnt"]);
                }
                reader2.Close();
                //    connection.Close();
                return num;
            }
            if ((status == "5") && (data_status == "acc_printed"))
            {
                SqlCommand command3 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND  pwallet.acc_p='1' ", connection)
                {
                    //  CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader3 = command3.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader3.Read())
                {
                    num = Convert.ToInt64(reader3["cnt"]);
                }
                reader3.Close();
                //   connection.Close();
                return num;
            }
            if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            {
                SqlCommand command4 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Fresh') OR (pwallet.data_status='Invalid')) ", connection)
                {
                    //  CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader4 = command4.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader4.Read())
                {
                    num = Convert.ToInt64(reader4["cnt"]);
                }
                reader4.Close();
                //   connection.Close();
                return num;
            }
            if ((status == "8") && (data_status == "Registered"))
            {
                SqlCommand command5 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status>'" + status + "' AND pwallet.data_status='Registered' ", connection)
                {
                    //  CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader5 = command5.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader5.Read())
                {
                    num = Convert.ToInt64(reader5["cnt"]);
                }
                reader5.Close();
                //  connection.Close();
                return num;
            }
            SqlCommand command6 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN Recordal  ON Recordal.log_staff=pwallet.ID WHERE pwallet.stage='5' AND Recordal.data_status3='" + status + "' AND Recordal.data_status4='" + data_status + "' ", connection)
            {
                //   CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader6 = command6.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader6.Read())
            {
                num = Convert.ToInt64(reader6["cnt"]);
            }
            reader6.Close();
            //  connection.Close();

            return num;
        }

        public long getMarkInfoRSCnt100(string status, string data_status, string status2)
        {
            long num = 0L;
            SqlConnection connection = new SqlConnection(this.Connect());
            if ((status == "4") && (data_status == "Refused"))
            {
                SqlCommand command = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "'  ", connection)
                {
                    //   CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    num = Convert.ToInt64(reader["cnt"]);
                }
                reader.Close();
                //  connection.Close();
                return num;
            }
            if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            {
                SqlCommand command2 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable')) ", connection)
                {
                    // CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader2 = command2.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader2.Read())
                {
                    num = Convert.ToInt64(reader2["cnt"]);
                }
                reader2.Close();
                //    connection.Close();
                return num;
            }
            if ((status == "5") && (data_status == "acc_printed"))
            {
                SqlCommand command3 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND  pwallet.acc_p='1' ", connection)
                {
                    //  CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader3 = command3.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader3.Read())
                {
                    num = Convert.ToInt64(reader3["cnt"]);
                }
                reader3.Close();
                //   connection.Close();
                return num;
            }
            if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            {
                SqlCommand command4 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Fresh') OR (pwallet.data_status='Invalid')) ", connection)
                {
                    //  CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader4 = command4.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader4.Read())
                {
                    num = Convert.ToInt64(reader4["cnt"]);
                }
                reader4.Close();
                //   connection.Close();
                return num;
            }
            if ((status == "8") && (data_status == "Registered"))
            {
                SqlCommand command5 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status>'" + status + "' AND pwallet.data_status='Registered' ", connection)
                {
                    //  CommandTimeout = 0
                };
                connection.Open();
                SqlDataReader reader5 = command5.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader5.Read())
                {
                    num = Convert.ToInt64(reader5["cnt"]);
                }
                reader5.Close();
                //  connection.Close();
                return num;
            }
            SqlCommand command6 = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN Recordal  ON Recordal.log_staff=pwallet.ID WHERE pwallet.stage='5' AND Recordal.data_status3='" + status + "' AND Recordal.data_status4='" + data_status + "'  AND Recordal.status='" + status2 + "' ", connection)
            {
                //   CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader6 = command6.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader6.Read())
            {
                num = Convert.ToInt64(reader6["cnt"]);
            }
            reader6.Close();
            //  connection.Close();

            return num;
        }
        public List<MarkInfo> getMarkInfoRSX(string status, string data_status, string start, string limit)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            if ((status == "4") && (data_status == "Refused"))
            {
                SqlCommand command = new SqlCommand("WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number,mark_info.product_title,mark_info.tm_typeID,mark_info.reg_date,mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank' from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID  WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MarkInfo item = new MarkInfo
                    {
                        xID = reader["xID"].ToString(),
                        reg_number = reader["reg_number"].ToString(),
                        tm_typeID = reader["tm_typeID"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        log_staff = reader["log_staff"].ToString(),
                        reg_date = reader["reg_date"].ToString()
                    };
                    list.Add(item);
                }
                reader.Close();
                connection.Close();
                return list;
            }
            if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            {
                SqlCommand command2 = new SqlCommand("WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number,mark_info.product_title,mark_info.tm_typeID,mark_info.reg_date,mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank' from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable')) )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection);
                connection.Open();
                SqlDataReader reader2 = command2.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader2.Read())
                {
                    MarkInfo info3 = new MarkInfo
                    {
                        xID = reader2["xID"].ToString(),
                        reg_number = reader2["reg_number"].ToString(),
                        tm_typeID = reader2["tm_typeID"].ToString(),
                        product_title = reader2["product_title"].ToString(),
                        log_staff = reader2["log_staff"].ToString(),
                        reg_date = reader2["reg_date"].ToString()
                    };
                    list.Add(info3);
                }
                reader2.Close();
                connection.Close();
                return list;
            }
            if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            {
                SqlCommand command3 = new SqlCommand("WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number,mark_info.product_title,mark_info.tm_typeID,mark_info.reg_date,mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank' from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Fresh') OR (pwallet.data_status='Invalid')) )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection);
                connection.Open();
                SqlDataReader reader3 = command3.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader3.Read())
                {
                    MarkInfo info5 = new MarkInfo
                    {
                        xID = reader3["xID"].ToString(),
                        reg_number = reader3["reg_number"].ToString(),
                        tm_typeID = reader3["tm_typeID"].ToString(),
                        product_title = reader3["product_title"].ToString(),
                        log_staff = reader3["log_staff"].ToString(),
                        reg_date = reader3["reg_date"].ToString()
                    };
                    list.Add(info5);
                }
                reader3.Close();
                return list;
            }
            if ((status == "8") && (data_status == "Registered"))
            {
                SqlCommand command4 = new SqlCommand("WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number,mark_info.product_title,mark_info.tm_typeID,mark_info.reg_date,mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank' from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status>'" + status + "' AND pwallet.data_status='Registered' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection);
                connection.Open();
                SqlDataReader reader4 = command4.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader4.Read())
                {
                    MarkInfo info7 = new MarkInfo
                    {
                        xID = reader4["xID"].ToString(),
                        reg_number = reader4["reg_number"].ToString(),
                        tm_typeID = reader4["tm_typeID"].ToString(),
                        product_title = reader4["product_title"].ToString(),
                        log_staff = reader4["log_staff"].ToString(),
                        reg_date = reader4["reg_date"].ToString()
                    };
                    list.Add(info7);
                }
                reader4.Close();
                return list;
            }
            SqlCommand command5 = new SqlCommand("WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number,mark_info.product_title,mark_info.tm_typeID,mark_info.reg_date,mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank' from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='" + data_status + "' ))) SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection);
            connection.Open();
            SqlDataReader reader5 = command5.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader5.Read())
            {
                MarkInfo info9 = new MarkInfo
                {
                    xID = reader5["xID"].ToString(),
                    reg_number = reader5["reg_number"].ToString(),
                    tm_typeID = reader5["tm_typeID"].ToString(),
                    product_title = reader5["product_title"].ToString(),
                    log_staff = reader5["log_staff"].ToString(),
                    reg_date = reader5["reg_date"].ToString()
                };
                list.Add(info9);
            }
            reader5.Close();
            connection.Close();
            return list;
        }

        public int updatepwalletID(string xid, string Sys_ID)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("UPDATE pwallet SET rtm='" + Sys_ID + "' WHERE ID='" + xid + "'  ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }
       
       public  int getMaxRtno()
        {
           
                int num = 0;
                SqlConnection connection = new SqlConnection(this.Connect());
                SqlCommand command = new SqlCommand("select  max(convert(int,rtm) ) as max_sysid from  pwallet where substring(validationID,1,1) !='M' ", connection);
                connection.Open();// command.CommandTimeout = 600;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    num = Convert.ToInt32(reader["max_sysid"]);
                }
                reader.Close();
            
            return num;
        }
        
        public List<MarkInfo> getMarkInfoRSXByRtm(string status, string data_status, string start, string limit)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            if ((status == "4") && (data_status == "Refused"))
            {
                SqlCommand command = new SqlCommand("WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number,mark_info.product_title,mark_info.tm_typeID,mark_info.reg_date,mark_info.log_staff, pwallet.rtm, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank' from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MarkInfo item = new MarkInfo
                    {
                        xID = reader["xID"].ToString(),
                        reg_number = reader["reg_number"].ToString(),
                        tm_typeID = reader["tm_typeID"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        log_staff = reader["log_staff"].ToString(),
                        reg_date = reader["reg_date"].ToString(),
                        rtm = reader["rtm"].ToString()
                    };
                    list.Add(item);
                }
                reader.Close();
                connection.Close();
                return list;
            }
            if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            {
                SqlCommand command2 = new SqlCommand("WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number,mark_info.product_title,mark_info.tm_typeID,mark_info.reg_date,mark_info.log_staff, pwallet.rtm, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank' from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable')) )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection);
                connection.Open();
                SqlDataReader reader2 = command2.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader2.Read())
                {
                    MarkInfo info3 = new MarkInfo
                    {
                        xID = reader2["xID"].ToString(),
                        reg_number = reader2["reg_number"].ToString(),
                        tm_typeID = reader2["tm_typeID"].ToString(),
                        product_title = reader2["product_title"].ToString(),
                        log_staff = reader2["log_staff"].ToString(),
                        reg_date = reader2["reg_date"].ToString(),
                        rtm = reader2["rtm"].ToString()
                    };
                    list.Add(info3);
                }
                reader2.Close();
                return list;
            }
            if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            {
                SqlCommand command3 = new SqlCommand("WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number,mark_info.product_title,mark_info.tm_typeID,mark_info.reg_date,mark_info.log_staff, pwallet.rtm, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank' from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Fresh') OR (pwallet.data_status='Invalid')) )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection);
                connection.Open();
                SqlDataReader reader3 = command3.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader3.Read())
                {
                    MarkInfo info5 = new MarkInfo
                    {
                        xID = reader3["xID"].ToString(),
                        reg_number = reader3["reg_number"].ToString(),
                        tm_typeID = reader3["tm_typeID"].ToString(),
                        product_title = reader3["product_title"].ToString(),
                        log_staff = reader3["log_staff"].ToString(),
                        reg_date = reader3["reg_date"].ToString(),
                        rtm = reader3["rtm"].ToString()
                    };
                    list.Add(info5);
                }
                reader3.Close();
                return list;
            }
            if ((status == "8") && (data_status == "Registered"))
            {
                SqlCommand command4 = new SqlCommand("WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number,mark_info.product_title,mark_info.tm_typeID,mark_info.reg_date,mark_info.log_staff, pwallet.rtm, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank' from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status>'" + status + "' AND pwallet.data_status='Registered' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection);
                connection.Open();
                SqlDataReader reader4 = command4.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader4.Read())
                {
                    MarkInfo info7 = new MarkInfo
                    {
                        xID = reader4["xID"].ToString(),
                        reg_number = reader4["reg_number"].ToString(),
                        tm_typeID = reader4["tm_typeID"].ToString(),
                        product_title = reader4["product_title"].ToString(),
                        log_staff = reader4["log_staff"].ToString(),
                        reg_date = reader4["reg_date"].ToString(),
                        rtm = reader4["rtm"].ToString()
                    };
                    list.Add(info7);
                }
                reader4.Close();
                return list;
            }
            SqlCommand command5 = new SqlCommand("WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number,mark_info.product_title,mark_info.tm_typeID,mark_info.reg_date,mark_info.log_staff, pwallet.rtm, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank' from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='" + data_status + "' ))) SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection);
            connection.Open();
            SqlDataReader reader5 = command5.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader5.Read())
            {
                MarkInfo info9 = new MarkInfo
                {
                    xID = reader5["xID"].ToString(),
                    reg_number = reader5["reg_number"].ToString(),
                    tm_typeID = reader5["tm_typeID"].ToString(),
                    product_title = reader5["product_title"].ToString(),
                    log_staff = reader5["log_staff"].ToString(),
                    reg_date = reader5["reg_date"].ToString(),
                    rtm = reader5["rtm"].ToString()
                };
                list.Add(info9);
            }
            reader5.Close();
            return list;
        }

        public List<MarkInfo> getMarkInfoSlipPlusRS(string stage)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT mark_info.*  FROM pwallet LEFT OUTER JOIN mark_info ON pwallet.ID=mark_info.log_staff WHERE pwallet.status >= '" + stage + "' AND mark_info.log_staff IN (Select ID  FROM pwallet) ORDER BY ID ASC", connection)
            {
               CommandTimeout = 0
            };
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getMarkInfoSlipRS(string stage, string status)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT mark_info.*  FROM mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID LEFT OUTER JOIN tm_office ON pwallet.ID=tm_office.pwalletID  WHERE tm_office.admin_status = '" + stage + "' AND tm_office.data_status='" + status + "' AND mark_info.log_staff IN (Select pwallet.ID  FROM pwallet) ORDER BY pwallet.ID DESC", connection)
            {
              CommandTimeout = 0
            };
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
            connection.Close();
            return list;
        }

        public List<MarkInfo> getMarkInfoXRS(string stage, string status)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT mark_info.*  FROM pwallet LEFT OUTER JOIN mark_info ON pwallet.ID=mark_info.log_staff LEFT OUTER JOIN tm_office ON tm_office.pwalletID=mark_info.log_staff WHERE pwallet.status = '" + stage + "'  AND tm_office.data_status='" + status + "' AND mark_info.log_staff IN (Select pwallet.ID  FROM pwallet) ORDER BY pwallet.ID DESC", connection)
            {
               CommandTimeout = 0
            };
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
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_AcceptanceManageRSX(int PageNo, int NoOfRecord, int TotalRecord)
        {
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();

          
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
          //  SqlCommand command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.ID 'ID',applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY pwallet.ID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE   pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22'  AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' order by ID DESC " }), connection)

          //  SqlCommand command = new SqlCommand(string.Concat(new object[] { "Select * from (select  pwallet.ID 'ID',applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY pwallet.ID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE   pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22'  AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5  ) as Tab WHERE Tab.RowRank BETWEEN '", ((PageNo - 1) * NoOfRecord) + 1, "' AND '", PageNo * NoOfRecord, "' order by ID DESC " }), connection)

            SqlCommand command = new SqlCommand(string.Concat(new object[] { "Select * from (select  pwallet.ID 'ID',applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE   pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22'  AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)=5  ) as Tab WHERE Tab.ID BETWEEN '", PageNo, "' AND '", NoOfRecord , "' order by ID DESC " }), connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

     
        public List<XrowCount> getNew_RowCount()
        {
            List<XrowCount> list = new List<XrowCount>();


            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //  SqlCommand command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.ID 'ID',applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY pwallet.ID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE   pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22'  AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' order by ID DESC " }), connection)

            SqlCommand command = new SqlCommand(string.Concat(new object[] { "select ROW_NUMBER() OVER (ORDER BY pwallet.ID) AS 'RowRank', pwallet.ID 'tblID'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID  WHERE  pwallet.status<>'33' AND pwallet.status<>'22'  AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5 " }), connection)
            {
              CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XrowCount item = new XrowCount
                {
                    RowRanks = reader["RowRank"].ToString(),
                    Tblld = reader["tblID"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XrowCount> getNew_RowCount2(string ss )
        {
            List<XrowCount> list = new List<XrowCount>();


            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //  SqlCommand command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.ID 'ID',applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY pwallet.ID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE   pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22'  AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' order by ID DESC " }), connection)

            SqlCommand command = new SqlCommand(string.Concat(new object[] { "select ROW_NUMBER() OVER (ORDER BY pwallet.ID) AS 'RowRank', pwallet.ID 'tblID'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID  WHERE   pwallet.stage='5'  AND  ( product_title like '%" + ss + "%' )  AND CAST(pwallet.status AS INT)=5  " }), connection)
            {
              CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XrowCount item = new XrowCount
                {
                    RowRanks = reader["RowRank"].ToString(),
                    Tblld = reader["tblID"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XrowCount> getNew_RowCount(string status, string data_status)
        {
            List<XrowCount> list = new List<XrowCount>();


            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //  SqlCommand command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.ID 'ID',applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY pwallet.ID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE   pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22'  AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' order by ID DESC " }), connection)

            //  SqlCommand command = new SqlCommand(string.Concat(new object[] { "select ROW_NUMBER() OVER (ORDER BY pwallet.ID) AS 'RowRank', pwallet.ID 'tblID'  from  pwallet  LEFT OUTER JOIN mark_info ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "'   " }), connection)
            SqlCommand command = new SqlCommand(string.Concat(new object[] { "select ROW_NUMBER() OVER (ORDER BY pwallet.rtm) AS 'RowRank', pwallet.RTM 'tblID'  from  pwallet  LEFT OUTER JOIN mark_info ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' and  pwallet.rtm!=''   order by pwallet.rtm  " }), connection)

            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XrowCount item = new XrowCount
                {
                    RowRanks = reader["RowRank"].ToString(),
                    Tblld = reader["tblID"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;

        }
    

        public List<XObjs.Office_view> getNew_AcceptanceMarkInfoRSX(string status, int start, int limit)
        {
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE   pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22'  AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection)
            {
              CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_AdminSearchMarkInfoRS(string status, string data_status, string criteria, List<string> fulltext, string dateFrom, string dateTo)
        {
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            string cmdText = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            if (criteria == "product_title")
            {
                num = fulltext.Count - 1;
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    str2 = "select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused'))  AND ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    str2 = "select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid'))  AND ";
                }
                else if ((status == "5") && (data_status == "Accepted"))
                {
                    str2 = "select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE   pwallet.stage='5'  AND pwallet.status<>'33' AND pwallet.status<>'22'  AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5  AND  ";
                }
                else
                {
                    str2 = "select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' AND ";
                }
                for (int i = 0; i < fulltext.Count; i++)
                {
                    if (fulltext.Count == 1)
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else if (num == i)
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) OR";
                    }
                }
                str4 = "AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC";
                cmdText = str2 + str3 + str4;
            }
            else if (criteria == "reg_number")
            {
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    cmdText = "select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused')) AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    cmdText = "select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid')) AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "5") && (data_status == "Accepted"))
                {
                    cmdText = "select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE   pwallet.stage='5'  AND pwallet.status<>'33' AND pwallet.status<>'22'  AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5 AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC";
                }
                else
                {
                    cmdText = "select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
            }
            else if (criteria == "app_number")
            {
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    cmdText = "select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused')) AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    cmdText = "select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid')) AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "5") && (data_status == "Accepted"))
                {
                    cmdText = "select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE   pwallet.stage='5'  AND pwallet.status<>'33' AND pwallet.status<>'22'  AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5 AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC";
                }
                else
                {
                    cmdText = "select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
              CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_CertifyMarkInfoRSX(string status, int start, int limit)
        {
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE   pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw'  AND CAST(pwallet.status AS INT)>='", status, "'  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoNoLimitRSX(string status, string data_status)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            if ((status == "4") && (data_status == "Refused"))
            {
                command = new SqlCommand("select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no',ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' ORDER BY mark_info.xID ", connection);
            }
            else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            {
                command = new SqlCommand("select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no',ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable')) ORDER BY mark_info.xID ", connection);
            }
            else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            {
                command = new SqlCommand("select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no',ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Fresh') OR (pwallet.data_status='Invalid')) ORDER BY mark_info.xID ", connection);
            }
            else if ((status == "8") && (data_status == "Registered"))
            {
                command = new SqlCommand("select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no',ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status>'" + status + "' AND pwallet.data_status='Registered' ORDER BY mark_info.xID ", connection);
            }
            else
            {
                command = new SqlCommand("select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no',ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "'  ORDER BY mark_info.xID ", connection);
            }
            command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            if ((status == "4") && (data_status == "Refused"))
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            }
            else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            }
            else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            }
            else if ((status == "8") && (data_status == "Registered"))
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            }
            else if ((status == "5") && (data_status == "acc_printed"))
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            }
            else
            {
                 command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'    ) SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "'  " }), connection);
              //  command = new SqlCommand(string.Concat(new object[] { "SELECT* FROM (select '' as description,ROW_NUMBER() OVER(ORDER BY pwallet.TransactionId desc ) AS NUMBER,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status, 'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status ='", status, "' AND pwallet.data_status = '", data_status, "'         ) AS TBL WHERE NUMBER BETWEEN((", start, " - 1) * ", limit, " + 1) AND(", start, " * ", limit, ")  " }), connection);
            }
           command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            while (reader.Read())
            {
                vcount = vcount + 1;
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                 //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString()
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1) {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {
                    
                }

                item.batches = pp2;
                list.Add(item);
                
                   
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX4(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{
            command = new SqlCommand(string.Concat(new object[] { "select g_tm_info.tm_title 'tm_title',g_tm_info.tm_class 'xclass',g_applicant_info.xname, g_pwallet.log_officer,g_pwallet.validationID ,g_pwallet.applicantID,ISNULL(g_pwallet.data_status,'None') 'xstat',g_pwallet.TransactionId,g_tm_info.reg_number,g_tm_info.xID,g_app_info.rtm_number,g_app_info.application_no,g_app_info.item_code,g_app_info.filing_date,g_app_info.reg_no, g_app_info.reg_date,g_app_info.log_staff,g_app_info.visible,g_applicant_info.xname from g_app_info   LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff   LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID LEFT OUTER JOIN g_applicant_info on  g_pwallet.id=g_applicant_info.log_staff  WHERE  g_pwallet.status ='", status, "' AND g_pwallet.data_status ='", data_status, "'     " }), connection);
            //  }
            // command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    rtm = reader["rtm_number"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["xclass"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                   // tm_type = reader["tm_type"].ToString(),
                    product_title = reader["tm_title"].ToString(),
                    oai_no = reader["validationID"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_date"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),

                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString()
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX2b(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{
            command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ( pwallet.data_status='", data_status, "'  or pwallet.data_status='Non-registrable' )   " }), connection);
            //  }
            // command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),
                    moveapp = reader["description"].ToString(),
                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString()
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }
        public List<XObjs.Office_view> getNew_MarkInfoRSX2(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{
          //  command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info WITH (NOLOCK) LEFT OUTER JOIN pwallet WITH (NOLOCK) ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type WITH (NOLOCK) ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH (NOLOCK) ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'   order  by mark_info.upload_date desc      " }), connection);

            command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info WITH (NOLOCK) LEFT OUTER JOIN pwallet WITH (NOLOCK) ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type WITH (NOLOCK) ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH (NOLOCK) ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'        " }), connection);

            //command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'         " }), connection);
            //  }
            command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    id= reader["ID"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),
                    moveapp= reader["description"].ToString(),
                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString()
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX2Appeal()
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{
            //  command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info WITH (NOLOCK) LEFT OUTER JOIN pwallet WITH (NOLOCK) ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type WITH (NOLOCK) ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH (NOLOCK) ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'   order  by mark_info.upload_date desc      " }), connection);

            command = new SqlCommand(string.Concat(new object[] { "select '' as  description,AppealRejection.id as id2 ,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info WITH (NOLOCK) LEFT OUTER JOIN pwallet WITH (NOLOCK) ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type WITH (NOLOCK) ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH (NOLOCK) ON applicant.log_staff=pwallet.ID  LEFT OUTER JOIN AppealRejection WITH (NOLOCK) ON AppealRejection.DocumentId=pwallet.ID   WHERE AppealRejection.Status='Pending'  " }), connection);

            //command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'         " }), connection);
            //  }
            command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    id = reader["ID"].ToString(),
                    id2 = reader["id2"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),
                    moveapp = reader["description"].ToString(),
                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString()
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX3Appeal()
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{
            //  command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info WITH (NOLOCK) LEFT OUTER JOIN pwallet WITH (NOLOCK) ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type WITH (NOLOCK) ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH (NOLOCK) ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'   order  by mark_info.upload_date desc      " }), connection);

            command = new SqlCommand(string.Concat(new object[] { "select '' as  description,AppealRejection.id as id2 ,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info WITH (NOLOCK) LEFT OUTER JOIN pwallet WITH (NOLOCK) ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type WITH (NOLOCK) ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH (NOLOCK) ON applicant.log_staff=pwallet.ID  LEFT OUTER JOIN AppealRejection WITH (NOLOCK) ON AppealRejection.DocumentId=pwallet.ID   WHERE AppealRejection.Status!='Pending'  " }), connection);

            //command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'         " }), connection);
            //  }
            command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    id = reader["ID"].ToString(),
                    id2 = reader["id2"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),
                    moveapp = reader["description"].ToString(),
                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString()
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX2bbb(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{
            //  command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info WITH (NOLOCK) LEFT OUTER JOIN pwallet WITH (NOLOCK) ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type WITH (NOLOCK) ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH (NOLOCK) ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'   order  by mark_info.upload_date desc      " }), connection);

            command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info WITH (NOLOCK) LEFT OUTER JOIN pwallet WITH (NOLOCK) ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type WITH (NOLOCK) ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH (NOLOCK) ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Fresh') OR (pwallet.data_status='Invalid'))         " }), connection);

            //command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'         " }), connection);
            //  }
            command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    id = reader["ID"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),
                    moveapp = reader["description"].ToString(),
                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString()
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }


                DateTime d1 = DateTime.Now;
                DateTime d2 = Convert.ToDateTime(item.reg_dt);

                TimeSpan t = d1 - d2;
                int NrOfDays =Convert.ToInt32(t.TotalDays);

                item.Duration = NrOfDays;

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }


        public List<XObjs.Office_view> getNew_MarkInfoRSX222b(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{
            //  command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info WITH (NOLOCK) LEFT OUTER JOIN pwallet WITH (NOLOCK) ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type WITH (NOLOCK) ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH (NOLOCK) ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'   order  by mark_info.upload_date desc      " }), connection);

            command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info WITH (NOLOCK) LEFT OUTER JOIN pwallet WITH (NOLOCK) ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type WITH (NOLOCK) ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH (NOLOCK) ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'  order by pwallet.TransactionId desc      " }), connection);

            //command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'         " }), connection);
            //  }
            command.CommandTimeout = 0;
            connection.Open();

           


            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    id = reader["ID"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),
                    moveapp = reader["description"].ToString(),
                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString(),
                    TransactionId2 = getPaymentTransid(reader["TransactionId"].ToString())
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public GetReport getNew_MarkInfoRSX222bbx4(string status, string data_status, int start, int limit,string criteria,string valueentered)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            GetReport px = new GetReport();
            px.data = list;
            px.count = 0;
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            if (criteria == "" || criteria == null)
            {

                command = new SqlCommand(string.Concat(new object[] { "SELECT* FROM (select '' as description,ROW_NUMBER() OVER(ORDER BY pwallet.TransactionId desc ) AS NUMBER,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.acc_p,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status, 'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status ='", status, "' AND pwallet.data_status = '", data_status, "'         ) AS TBL WHERE NUMBER BETWEEN((", start, " - 1) * ", limit, " + 1) AND(", start, " * ", limit, ")  " }), connection);
                command.CommandTimeout = 0;
                connection.Open();




                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                string pp2 = "";
                int vcount = 0;
                int vsn = 0;
                string voffice = "";
                while (reader.Read())
                {
                    vsn = vsn + 1;
                    vcount = vcount + 1;

                    XObjs.Office_view item = new XObjs.Office_view
                    {
                        xid = reader["xID"].ToString(),
                        id = reader["ID"].ToString(),
                        rtm = reader["rtm"].ToString(),
                        applicant_name = reader["xname"].ToString(),
                        xclass = reader["class"].ToString(),
                        reg_no = reader["reg_no"].ToString(),
                        tm_type = reader["tm_type"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        oai_no = reader["oai_no"].ToString(),
                        xstat = reader["xstat"].ToString(),
                        reg_dt = reader["reg_dt"].ToString(),
                        log_staff = reader["log_staff"].ToString(),
                        //   batches = reader["visible"].ToString(),
                        applicantID = reader["visible"].ToString(),
                        moveapp = reader["description"].ToString(),
                        acc_p= reader["acc_p"].ToString(),
                        //Office = reader["data_status"].ToString(),
                        // Sn = Convert.ToString(vsn),
                        Sn = reader["NUMBER"].ToString(),
                        TransactionId = reader["TransactionId"].ToString(),
                        TransactionId2 = getPaymentTransid(reader["TransactionId"].ToString())
                    };

                    try
                    {
                        int dw = Convert.ToInt32(reader["visible"]);
                        if (dw > 1)
                        {
                            pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                        }

                        else
                        {
                            pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                        }
                    }
                    catch (Exception ee)
                    {

                    }

                    item.batches = pp2;
                    list.Add(item);
                   

                }


                reader.Close();
                connection.Close();
                px.data = list;
                int lt_mi_n = getCriRegisteredMarkInfoRSCnt(status, data_status);
                px.count = lt_mi_n;
            }

          else   if (criteria == "OAI NUMBER")
            {
              // valueentered = "306124520393";
                command = new SqlCommand(string.Concat(new object[] { "SELECT* FROM (select '' as description,ROW_NUMBER() OVER(ORDER BY pwallet.TransactionId desc ) AS NUMBER,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,pwallet.acc_p,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status, 'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status ='", status, "' AND pwallet.data_status = '", data_status, "'  AND pwallet.validationID = '", valueentered, "'        ) AS TBL WHERE NUMBER BETWEEN((", start, " - 1) * ", limit, " + 1) AND(", start, " * ", limit, ")  " }), connection);
                command.CommandTimeout = 0;
                connection.Open();




                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                string pp2 = "";
                int vcount = 0;
                int vsn = 0;
                string voffice = "";
                while (reader.Read())
                {
                    vsn = vsn + 1;
                    vcount = vcount + 1;

                    XObjs.Office_view item = new XObjs.Office_view
                    {
                        xid = reader["xID"].ToString(),
                        id = reader["ID"].ToString(),
                        rtm = reader["rtm"].ToString(),
                        applicant_name = reader["xname"].ToString(),
                        xclass = reader["class"].ToString(),
                        reg_no = reader["reg_no"].ToString(),
                        tm_type = reader["tm_type"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        oai_no = reader["oai_no"].ToString(),
                        xstat = reader["xstat"].ToString(),
                        reg_dt = reader["reg_dt"].ToString(),
                        log_staff = reader["log_staff"].ToString(),
                        //   batches = reader["visible"].ToString(),
                        applicantID = reader["visible"].ToString(),
                        moveapp = reader["description"].ToString(),
                        acc_p = reader["acc_p"].ToString(),

                        TransactionId = reader["TransactionId"].ToString(),
                        TransactionId2 = getPaymentTransid(reader["TransactionId"].ToString())
                    };

                    try
                    {
                        int dw = Convert.ToInt32(reader["visible"]);
                        if (dw > 1)
                        {
                            pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                        }

                        else
                        {
                            pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                        }
                    }
                    catch (Exception ee)
                    {

                    }

                    item.batches = pp2;
                    list.Add(item);


                }
                reader.Close();
                connection.Close();
                px.data = list;
                px.count = list.Count();
            }

          else  if (criteria == "FILE NUMBER")
            {

                command = new SqlCommand(string.Concat(new object[] { "SELECT* FROM (select '' as description,ROW_NUMBER() OVER(ORDER BY pwallet.TransactionId desc ) AS NUMBER,  pwallet.rtm,pwallet.TransactionId,pwallet.acc_p,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status, 'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status ='", status, "' AND pwallet.data_status = '", data_status, "'  AND mark_info.reg_number = '", valueentered, "'        ) AS TBL WHERE NUMBER BETWEEN((", start, " - 1) * ", limit, " + 1) AND(", start, " * ", limit, ")  " }), connection);
                command.CommandTimeout = 0;
                connection.Open();




                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                string pp2 = "";
                int vcount = 0;
                int vsn = 0;
                string voffice = "";
                while (reader.Read())
                {
                    vsn = vsn + 1;
                    vcount = vcount + 1;

                    XObjs.Office_view item = new XObjs.Office_view
                    {
                        xid = reader["xID"].ToString(),
                        id = reader["ID"].ToString(),
                        rtm = reader["rtm"].ToString(),
                        applicant_name = reader["xname"].ToString(),
                        xclass = reader["class"].ToString(),
                        reg_no = reader["reg_no"].ToString(),
                        tm_type = reader["tm_type"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        oai_no = reader["oai_no"].ToString(),
                        xstat = reader["xstat"].ToString(),
                        reg_dt = reader["reg_dt"].ToString(),
                        log_staff = reader["log_staff"].ToString(),
                        //   batches = reader["visible"].ToString(),
                        applicantID = reader["visible"].ToString(),
                        acc_p = reader["acc_p"].ToString(),
                        moveapp = reader["description"].ToString(),
                        //Office = reader["data_status"].ToString(),
                        // Sn = Convert.ToString(vsn),
                        Sn = reader["NUMBER"].ToString(),
                        TransactionId = reader["TransactionId"].ToString(),
                        TransactionId2 = getPaymentTransid(reader["TransactionId"].ToString())
                    };

                    try
                    {
                        int dw = Convert.ToInt32(reader["visible"]);
                        if (dw > 1)
                        {
                            pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                        }

                        else
                        {
                            pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                        }
                    }
                    catch (Exception ee)
                    {

                    }

                    item.batches = pp2;
                    list.Add(item);


                }
                reader.Close();
                connection.Close();
                px.data = list;
                px.count = list.Count();
            }

          else  if (criteria == "PRODUCT TITLE")
            {

                command = new SqlCommand(string.Concat(new object[] { "SELECT* FROM (select '' as description,ROW_NUMBER() OVER(ORDER BY pwallet.TransactionId desc ) AS NUMBER,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.acc_p,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status, 'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status ='", status, "' AND pwallet.data_status = '", data_status, "'  AND mark_info.product_title LIKE '%", valueentered, "%'        ) AS TBL WHERE NUMBER BETWEEN((", start, " - 1) * ", limit, " + 1) AND(", start, " * ", limit, ")  " }), connection);
                command.CommandTimeout = 0;
                connection.Open();




                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                string pp2 = "";
                int vcount = 0;
                int vsn = 0;
                string voffice = "";
                while (reader.Read())
                {
                    vsn = vsn + 1;
                    vcount = vcount + 1;

                    XObjs.Office_view item = new XObjs.Office_view
                    {
                        xid = reader["xID"].ToString(),
                        id = reader["ID"].ToString(),
                        rtm = reader["rtm"].ToString(),
                        applicant_name = reader["xname"].ToString(),
                        xclass = reader["class"].ToString(),
                        reg_no = reader["reg_no"].ToString(),
                        tm_type = reader["tm_type"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        oai_no = reader["oai_no"].ToString(),
                        xstat = reader["xstat"].ToString(),
                        reg_dt = reader["reg_dt"].ToString(),
                        log_staff = reader["log_staff"].ToString(),
                        //   batches = reader["visible"].ToString(),
                        applicantID = reader["visible"].ToString(),
                        moveapp = reader["description"].ToString(),
                        acc_p = reader["acc_p"].ToString(),
                        //Office = reader["data_status"].ToString(),
                        // Sn = Convert.ToString(vsn),
                        Sn = reader["NUMBER"].ToString(),
                        TransactionId = reader["TransactionId"].ToString(),
                        TransactionId2 = getPaymentTransid(reader["TransactionId"].ToString())
                    };

                    try
                    {
                        int dw = Convert.ToInt32(reader["visible"]);
                        if (dw > 1)
                        {
                            pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                        }

                        else
                        {
                            pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                        }
                    }
                    catch (Exception ee)
                    {

                    }

                    item.batches = pp2;
                    list.Add(item);


                }
                reader.Close();
                connection.Close();
                px.data = list;
                px.count = list.Count();
            }

            else if (criteria == "APPLICANT NAME")
            {

                command = new SqlCommand(string.Concat(new object[] { "SELECT* FROM (select '' as description,ROW_NUMBER() OVER(ORDER BY pwallet.TransactionId desc ) AS NUMBER,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.acc_p,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status, 'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status ='", status, "' AND pwallet.data_status = '", data_status, "'  AND applicant.xname LIKE '%", valueentered, "%'        ) AS TBL WHERE NUMBER BETWEEN((", start, " - 1) * ", limit, " + 1) AND(", start, " * ", limit, ")  " }), connection);
                command.CommandTimeout = 0;
                connection.Open();




                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                string pp2 = "";
                int vcount = 0;
                int vsn = 0;
                string voffice = "";
                while (reader.Read())
                {
                    vsn = vsn + 1;
                    vcount = vcount + 1;

                    XObjs.Office_view item = new XObjs.Office_view
                    {
                        xid = reader["xID"].ToString(),
                        id = reader["ID"].ToString(),
                        rtm = reader["rtm"].ToString(),
                        applicant_name = reader["xname"].ToString(),
                        xclass = reader["class"].ToString(),
                        reg_no = reader["reg_no"].ToString(),
                        tm_type = reader["tm_type"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        oai_no = reader["oai_no"].ToString(),
                        xstat = reader["xstat"].ToString(),
                        reg_dt = reader["reg_dt"].ToString(),
                        log_staff = reader["log_staff"].ToString(),
                        //   batches = reader["visible"].ToString(),
                        applicantID = reader["visible"].ToString(),
                        acc_p = reader["acc_p"].ToString(),
                        moveapp = reader["description"].ToString(),
                        //Office = reader["data_status"].ToString(),
                        // Sn = Convert.ToString(vsn),
                        Sn = reader["NUMBER"].ToString(),
                        TransactionId = reader["TransactionId"].ToString(),
                        TransactionId2 = getPaymentTransid(reader["TransactionId"].ToString())
                    };

                    try
                    {
                        int dw = Convert.ToInt32(reader["visible"]);
                        if (dw > 1)
                        {
                            pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                        }

                        else
                        {
                            pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                        }
                    }
                    catch (Exception ee)
                    {

                    }

                    item.batches = pp2;
                    list.Add(item);


                }
                reader.Close();
                connection.Close();
                px.data = list;
                px.count = list.Count();
            }



            return px;
        }

        public GetReport getNew_MarkInfoRSX222bbx5(string status, string data_status, int start, int limit, string criteria, string valueentered, string valueentered2, string valueentered3)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            GetReport px = new GetReport();
            px.data = list;
            px.count = 0;
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            if (criteria == "" || criteria == null)
            {

                command = new SqlCommand(string.Concat(new object[] { "SELECT* FROM (select '' as description,ROW_NUMBER() OVER(ORDER BY pwallet.id desc ) AS NUMBER,  pwallet.rtm,pwallet.TransactionId,pwallet.acc_p,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status, 'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON   CAST(tm_type.xID AS nvarchar)  = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE  pwallet.status<>'33' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND pwallet.data_status<>'New' AND CAST(pwallet.status AS INT) >=5         ) AS TBL WHERE NUMBER BETWEEN((", start, " - 1) * ", limit, " + 1) AND(", start, " * ", limit, ")  " }), connection);

              //  command = new SqlCommand(string.Concat(new object[] { " select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat',pwallet.ID, mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info inner JOIN pwallet ON mark_info.log_staff=pwallet.ID   inner JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  inner JOIN applicant ON applicant.log_staff=pwallet.ID   where    pwallet.status<>'33' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5      " }), connection);

                command.CommandTimeout = 0;
                connection.Open();




                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                string pp2 = "";
                int vcount = 0;
                int vsn = 0;
                string voffice = "";
                while (reader.Read())
                {
                    vsn = vsn + 1;
                    vcount = vcount + 1;

                    XObjs.Office_view item = new XObjs.Office_view
                    {
                        xid = reader["xID"].ToString(),
                        id = reader["ID"].ToString(),
                        rtm = reader["rtm"].ToString(),
                        applicant_name = reader["xname"].ToString(),
                        xclass = reader["class"].ToString(),
                        reg_no = reader["reg_no"].ToString(),
                        tm_type = reader["tm_type"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        oai_no = reader["oai_no"].ToString(),
                        xstat = reader["xstat"].ToString(),
                        reg_dt = reader["reg_dt"].ToString(),
                        log_staff = reader["log_staff"].ToString(),
                        //   batches = reader["visible"].ToString(),
                        applicantID = reader["visible"].ToString(),
                        acc_p = reader["acc_p"].ToString(),
                        moveapp = reader["description"].ToString(),
                        //Office = reader["data_status"].ToString(),
                        // Sn = Convert.ToString(vsn),
                        Sn = reader["NUMBER"].ToString(),
                        TransactionId = reader["TransactionId"].ToString(),
                        TransactionId2 = getPaymentTransid(reader["TransactionId"].ToString())
                    };

                    try
                    {
                        int dw = Convert.ToInt32(reader["visible"]);
                        if (dw > 1)
                        {
                            pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                        }

                        else
                        {
                            pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                        }
                    }
                    catch (Exception ee)
                    {

                    }

                    item.batches = pp2;
                    list.Add(item);


                }


                reader.Close();
                connection.Close();
                px.data = list;
                int lt_mi_n = getCriRegisteredMarkInfoRSCnt(status, data_status);
                px.count = lt_mi_n;
            }

            else if (criteria == "OAI NUMBER")
            {
                // valueentered = "306124520393";
                command = new SqlCommand(string.Concat(new object[] { "SELECT* FROM (select '' as description,ROW_NUMBER() OVER(ORDER BY pwallet.TransactionId desc ) AS NUMBER,  pwallet.rtm,pwallet.acc_p,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status, 'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON CAST(tm_type.xID AS nvarchar)  = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE  pwallet.status<>'33' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5  AND pwallet.validationID = '", valueentered, "'        ) AS TBL WHERE NUMBER BETWEEN((", start, " - 1) * ", limit, " + 1) AND(", start, " * ", limit, ")  " }), connection);
                command.CommandTimeout = 0;
                connection.Open();




                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                string pp2 = "";
                int vcount = 0;
                int vsn = 0;
                string voffice = "";
                while (reader.Read())
                {
                    vsn = vsn + 1;
                    vcount = vcount + 1;

                    XObjs.Office_view item = new XObjs.Office_view
                    {
                        xid = reader["xID"].ToString(),
                        id = reader["ID"].ToString(),
                        rtm = reader["rtm"].ToString(),
                        applicant_name = reader["xname"].ToString(),
                        xclass = reader["class"].ToString(),
                        reg_no = reader["reg_no"].ToString(),
                        tm_type = reader["tm_type"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        oai_no = reader["oai_no"].ToString(),
                        xstat = reader["xstat"].ToString(),
                        reg_dt = reader["reg_dt"].ToString(),
                        log_staff = reader["log_staff"].ToString(),
                        //   batches = reader["visible"].ToString(),
                        applicantID = reader["visible"].ToString(),
                        moveapp = reader["description"].ToString(),
                        acc_p= reader["acc_p"].ToString(),

                        TransactionId = reader["TransactionId"].ToString(),
                        TransactionId2 = getPaymentTransid(reader["TransactionId"].ToString())
                    };

                    try
                    {
                        int dw = Convert.ToInt32(reader["visible"]);
                        if (dw > 1)
                        {
                            pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                        }

                        else
                        {
                            pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                        }
                    }
                    catch (Exception ee)
                    {

                    }

                    item.batches = pp2;
                    list.Add(item);


                }
                reader.Close();
                connection.Close();
                px.data = list;
                px.count = list.Count();
            }

            else if (criteria == "FILE NUMBER")
            {

                command = new SqlCommand(string.Concat(new object[] { "SELECT* FROM (select '' as description,ROW_NUMBER() OVER(ORDER BY pwallet.TransactionId desc ) AS NUMBER,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,pwallet.acc_p,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status, 'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON CAST(tm_type.xID AS nvarchar) = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.status<>'33' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5   AND mark_info.reg_number = '", valueentered, "'        ) AS TBL WHERE NUMBER BETWEEN((", start, " - 1) * ", limit, " + 1) AND(", start, " * ", limit, ")  " }), connection);
                command.CommandTimeout = 0;
                connection.Open();




                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                string pp2 = "";
                int vcount = 0;
                int vsn = 0;
                string voffice = "";
                while (reader.Read())
                {
                    vsn = vsn + 1;
                    vcount = vcount + 1;

                    XObjs.Office_view item = new XObjs.Office_view
                    {
                        xid = reader["xID"].ToString(),
                        id = reader["ID"].ToString(),
                        rtm = reader["rtm"].ToString(),
                        applicant_name = reader["xname"].ToString(),
                        xclass = reader["class"].ToString(),
                        reg_no = reader["reg_no"].ToString(),
                        tm_type = reader["tm_type"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        oai_no = reader["oai_no"].ToString(),
                        xstat = reader["xstat"].ToString(),
                        reg_dt = reader["reg_dt"].ToString(),
                        log_staff = reader["log_staff"].ToString(),
                        //   batches = reader["visible"].ToString(),
                        applicantID = reader["visible"].ToString(),
                        moveapp = reader["description"].ToString(),
                        acc_p = reader["acc_p"].ToString(),
                        //Office = reader["data_status"].ToString(),
                        // Sn = Convert.ToString(vsn),
                        Sn = reader["NUMBER"].ToString(),
                        TransactionId = reader["TransactionId"].ToString(),
                        TransactionId2 = getPaymentTransid(reader["TransactionId"].ToString())
                    };

                    try
                    {
                        int dw = Convert.ToInt32(reader["visible"]);
                        if (dw > 1)
                        {
                            pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                        }

                        else
                        {
                            pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                        }
                    }
                    catch (Exception ee)
                    {

                    }

                    item.batches = pp2;
                    list.Add(item);


                }
                reader.Close();
                connection.Close();
                px.data = list;
                px.count = list.Count();
            }

            else if (criteria == "PRODUCT TITLE")
            {

                command = new SqlCommand(string.Concat(new object[] { "SELECT* FROM (select '' as description,ROW_NUMBER() OVER(ORDER BY pwallet.TransactionId desc ) AS NUMBER,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.acc_p,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status, 'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON CAST(tm_type.xID AS nvarchar)  = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE  pwallet.status<>'33' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5  AND mark_info.product_title LIKE '%", valueentered, "%'        ) AS TBL WHERE NUMBER BETWEEN((", start, " - 1) * ", limit, " + 1) AND(", start, " * ", limit, ")  " }), connection);
                command.CommandTimeout = 0;
                connection.Open();




                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                string pp2 = "";
                int vcount = 0;
                int vsn = 0;
                string voffice = "";
                while (reader.Read())
                {
                    vsn = vsn + 1;
                    vcount = vcount + 1;

                    XObjs.Office_view item = new XObjs.Office_view
                    {
                        xid = reader["xID"].ToString(),
                        id = reader["ID"].ToString(),
                        rtm = reader["rtm"].ToString(),
                        applicant_name = reader["xname"].ToString(),
                        xclass = reader["class"].ToString(),
                        reg_no = reader["reg_no"].ToString(),
                        tm_type = reader["tm_type"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        oai_no = reader["oai_no"].ToString(),
                        xstat = reader["xstat"].ToString(),
                        reg_dt = reader["reg_dt"].ToString(),
                        log_staff = reader["log_staff"].ToString(),
                        //   batches = reader["visible"].ToString(),
                        applicantID = reader["visible"].ToString(),
                        moveapp = reader["description"].ToString(),
                        acc_p = reader["acc_p"].ToString(),
                        //Office = reader["data_status"].ToString(),
                        // Sn = Convert.ToString(vsn),
                        Sn = reader["NUMBER"].ToString(),
                        TransactionId = reader["TransactionId"].ToString(),
                        TransactionId2 = getPaymentTransid(reader["TransactionId"].ToString())
                    };

                    try
                    {
                        int dw = Convert.ToInt32(reader["visible"]);
                        if (dw > 1)
                        {
                            pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                        }

                        else
                        {
                            pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                        }
                    }
                    catch (Exception ee)
                    {

                    }

                    item.batches = pp2;
                    list.Add(item);


                }
                reader.Close();
                connection.Close();
                px.data = list;
                px.count = list.Count();
            }

            else if (criteria == "APPLICANT NAME")
            {

                command = new SqlCommand(string.Concat(new object[] { "SELECT* FROM (select '' as description,ROW_NUMBER() OVER(ORDER BY pwallet.TransactionId desc ) AS NUMBER,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',pwallet.acc_p,mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status, 'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.status<>'33' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5  AND applicant.xname LIKE '%", valueentered, "%'        ) AS TBL WHERE NUMBER BETWEEN((", start, " - 1) * ", limit, " + 1) AND(", start, " * ", limit, ")  " }), connection);
                command.CommandTimeout = 0;
                connection.Open();




                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                string pp2 = "";
                int vcount = 0;
                int vsn = 0;
                string voffice = "";
                while (reader.Read())
                {
                    vsn = vsn + 1;
                    vcount = vcount + 1;

                    XObjs.Office_view item = new XObjs.Office_view
                    {
                        xid = reader["xID"].ToString(),
                        id = reader["ID"].ToString(),
                        rtm = reader["rtm"].ToString(),
                        applicant_name = reader["xname"].ToString(),
                        xclass = reader["class"].ToString(),
                        reg_no = reader["reg_no"].ToString(),
                        tm_type = reader["tm_type"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        oai_no = reader["oai_no"].ToString(),
                        xstat = reader["xstat"].ToString(),
                        reg_dt = reader["reg_dt"].ToString(),
                        log_staff = reader["log_staff"].ToString(),
                        acc_p = reader["acc_p"].ToString(),
                        //   batches = reader["visible"].ToString(),
                        applicantID = reader["visible"].ToString(),
                        moveapp = reader["description"].ToString(),
                        //Office = reader["data_status"].ToString(),
                        // Sn = Convert.ToString(vsn),
                        Sn = reader["NUMBER"].ToString(),
                        TransactionId = reader["TransactionId"].ToString(),
                        TransactionId2 = getPaymentTransid(reader["TransactionId"].ToString())
                    };

                    try
                    {
                        int dw = Convert.ToInt32(reader["visible"]);
                        if (dw > 1)
                        {
                            pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                        }

                        else
                        {
                            pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                        }
                    }
                    catch (Exception ee)
                    {

                    }

                    item.batches = pp2;
                    list.Add(item);


                }
                reader.Close();
                connection.Close();
                px.data = list;
                px.count = list.Count();
            }

            else if (criteria == "BY ACCEPTANCE DATE")
            {

                command = new SqlCommand(string.Concat(new object[] { "SELECT* FROM (select '' as description,ROW_NUMBER() OVER(ORDER BY pwallet.TransactionId desc ) AS NUMBER,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',pwallet.acc_p,mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status, 'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID  LEFT OUTER JOIN tm_office WITH(NOLOCK) ON tm_office.pwalletID = pwallet.ID   WHERE pwallet.status<>'33' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5 and tm_office.data_status ='Accepted'  AND   tm_office.reg_date BETWEEN( '", valueentered2, "' ) AND ('", valueentered3, "' )        ) AS TBL WHERE NUMBER BETWEEN((", start, " - 1) * ", limit, " + 1) AND(", start, " * ", limit, ")  " }), connection);
                command.CommandTimeout = 0;
                connection.Open();




                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                string pp2 = "";
                int vcount = 0;
                int vsn = 0;
                string voffice = "";
                while (reader.Read())
                {
                    vsn = vsn + 1;
                    vcount = vcount + 1;

                    XObjs.Office_view item = new XObjs.Office_view
                    {
                        xid = reader["xID"].ToString(),
                        id = reader["ID"].ToString(),
                        rtm = reader["rtm"].ToString(),
                        applicant_name = reader["xname"].ToString(),
                        xclass = reader["class"].ToString(),
                        reg_no = reader["reg_no"].ToString(),
                        tm_type = reader["tm_type"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        oai_no = reader["oai_no"].ToString(),
                        xstat = reader["xstat"].ToString(),
                        reg_dt = reader["reg_dt"].ToString(),
                        log_staff = reader["log_staff"].ToString(),
                        acc_p = reader["acc_p"].ToString(),
                        //   batches = reader["visible"].ToString(),
                        applicantID = reader["visible"].ToString(),
                        moveapp = reader["description"].ToString(),
                        //Office = reader["data_status"].ToString(),
                        // Sn = Convert.ToString(vsn),
                        Sn = reader["NUMBER"].ToString(),
                        TransactionId = reader["TransactionId"].ToString(),
                        TransactionId2 = getPaymentTransid(reader["TransactionId"].ToString())
                    };

                    try
                    {
                        int dw = Convert.ToInt32(reader["visible"]);
                        if (dw > 1)
                        {
                            pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                        }

                        else
                        {
                            pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                        }
                    }
                    catch (Exception ee)
                    {

                    }

                    item.batches = pp2;
                    list.Add(item);


                }
                reader.Close();
                connection.Close();
                px.data = list;
               // px.count = list.Count();

                int lt_mi_n = getCriRegisteredMarkInfoRSCnt3(status, data_status, valueentered2, valueentered3);
                px.count = lt_mi_n;
            }



            return px;
        }

        public GetReport getNew_MarkInfoRSX222bbx55(string status, string data_status, int start, int limit, string criteria, string valueentered)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            GetReport px = new GetReport();
            px.data = list;
            px.count = 0;
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
           

                command = new SqlCommand(string.Concat(new object[] { "SELECT* FROM (select '' as description,ROW_NUMBER() OVER(ORDER BY pwallet.id desc ) AS NUMBER,  pwallet.rtm,pwallet.TransactionId,pwallet.acc_p,pwallet.visible,pwallet.applicantID,pwallet.ID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status, 'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON   CAST(tm_type.xID AS nvarchar)  = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE  pwallet.status<>'33' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND pwallet.data_status<>'New' AND pwallet.acc_p ='1'       ) AS TBL WHERE NUMBER BETWEEN((", start, " - 1) * ", limit, " + 1) AND(", start, " * ", limit, ")  " }), connection);

                //  command = new SqlCommand(string.Concat(new object[] { " select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat',pwallet.ID, mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info inner JOIN pwallet ON mark_info.log_staff=pwallet.ID   inner JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  inner JOIN applicant ON applicant.log_staff=pwallet.ID   where    pwallet.status<>'33' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5      " }), connection);

                command.CommandTimeout = 0;
                connection.Open();




                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                string pp2 = "";
                int vcount = 0;
                int vsn = 0;
                string voffice = "";
                while (reader.Read())
                {
                    vsn = vsn + 1;
                    vcount = vcount + 1;

                    XObjs.Office_view item = new XObjs.Office_view
                    {
                        xid = reader["xID"].ToString(),
                        id = reader["ID"].ToString(),
                        rtm = reader["rtm"].ToString(),
                        applicant_name = reader["xname"].ToString(),
                        xclass = reader["class"].ToString(),
                        reg_no = reader["reg_no"].ToString(),
                        tm_type = reader["tm_type"].ToString(),
                        product_title = reader["product_title"].ToString(),
                        oai_no = reader["oai_no"].ToString(),
                        xstat = reader["xstat"].ToString(),
                        reg_dt = reader["reg_dt"].ToString(),
                        log_staff = reader["log_staff"].ToString(),
                        //   batches = reader["visible"].ToString(),
                        applicantID = reader["visible"].ToString(),
                        acc_p = reader["acc_p"].ToString(),
                        moveapp = reader["description"].ToString(),
                        //Office = reader["data_status"].ToString(),
                        // Sn = Convert.ToString(vsn),
                        Sn = reader["NUMBER"].ToString(),
                        TransactionId = reader["TransactionId"].ToString(),
                        TransactionId2 = getPaymentTransid(reader["TransactionId"].ToString())
                    };

                    try
                    {
                        int dw = Convert.ToInt32(reader["visible"]);
                        if (dw > 1)
                        {
                            pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                        }

                        else
                        {
                            pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                        }
                    }
                    catch (Exception ee)
                    {

                    }

                    item.batches = pp2;
                    list.Add(item);


                }


                reader.Close();
                connection.Close();
                px.data = list;
                int lt_mi_n = getCriRegisteredMarkInfoRSCnt(status, data_status);
                px.count = lt_mi_n;
           

        



            return px;
        }



        public List<XObjs.Office_view> getNew_MarkInfoRSX2bb(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{
            command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwalletAmendment.rtm,pwalletAmendment.TransactionId,pwalletAmendment.visible,pwalletAmendment.applicantID,pwalletAmendment.ID,pwalletAmendment.AmendmentStatus, applicantAmendment.xname,mark_infoAmendment.national_classID 'class',mark_infoAmendment.xID,mark_infoAmendment.reg_number 'reg_no',mark_infoAmendment.product_title,tm_type.type 'tm_type',pwalletAmendment.validationID 'oai_no', ISNULL(pwalletAmendment.data_status,'None') 'xstat', mark_infoAmendment.reg_date 'reg_dt',mark_infoAmendment.log_staff  from mark_infoAmendment LEFT OUTER JOIN pwalletAmendment ON mark_infoAmendment.log_staff=pwalletAmendment.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_infoAmendment.tm_typeID  LEFT OUTER JOIN applicantAmendment ON applicantAmendment.log_staff=pwalletAmendment.ID   WHERE pwalletAmendment.stage='5' AND pwalletAmendment.status='", status, "' AND pwalletAmendment.data_status='", data_status, "'      " }), connection);
            //  }
            // command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    id = reader["ID"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),
                    moveapp = reader["description"].ToString(),
                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString(),
                    AmendmentStatus = reader["AmendmentStatus"].ToString()
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX22(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{
            command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat',pwallet.ID, mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "' order  by mark_info.upload_date desc        " }), connection);
            //  }
            // command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    id= reader["id"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),
                    moveapp = reader["description"].ToString(),
                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString(),
                    comments= getTmOfficeDetailsByOffice(reader["log_staff"].ToString(), "3", "Search Conducted").xcomment
            };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX22c(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{
            command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat',pwallet.ID, mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'       " }), connection);
            //  }
            // command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    id = reader["id"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),
                    moveapp = reader["description"].ToString(),
                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString(),
                   // comments = getTmOfficeDetailsByOffice(reader["log_staff"].ToString(), "3", "Search Conducted").xcomment
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX223(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{
            command = new SqlCommand(string.Concat(new object[] { "select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat',pwallet.ID, mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='7' AND pwallet.data_status='Not Opposed'      " }), connection);
            //  }
            // command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    id = reader["id"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),
                    moveapp = reader["description"].ToString(),
                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString(),
                  //  comments = getTmOfficeDetailsByOffice(reader["log_staff"].ToString(), "7", "Not Opposed").xcomment
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }


        public List<XObjs.Office_view> getNew_MarkInfoRSX222(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{
            command = new SqlCommand(string.Concat(new object[] { " select '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat',pwallet.ID, mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info inner JOIN pwallet ON mark_info.log_staff=pwallet.ID   inner JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  inner JOIN applicant ON applicant.log_staff=pwallet.ID   where    pwallet.status<>'33' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5      " }), connection);
            //  }
             command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    id = reader["id"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),
                    moveapp = reader["description"].ToString(),
                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString(),
             
                  //  comments = getTmOfficeDetailsByOffice(reader["log_staff"].ToString(), "5", "Accepted").xcomment
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX222a(string status, string data_status, int start, int limit,int itemsPerPage,int page)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            ba2xai_cldx_backupEntities1 db = new ba2xai_cldx_backupEntities1();

            ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 180;


            string sqlQuery = @" select top 100 '' as  description,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat',pwallet.ID, mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info inner JOIN pwallet ON CAST(mark_info.log_staff AS INT) =pwallet.ID   inner JOIN tm_type ON tm_type.xID=CAST(mark_info.tm_typeID AS INT)  inner JOIN applicant ON CAST(applicant.log_staff AS INT) =pwallet.ID   where    pwallet.status<>'33' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND CAST(pwallet.status AS INT)>=5   ";

           // var Results = db.Database.SqlQuery<Report2>(sqlQuery).AsQueryable();
            var Results = db.Database.SqlQuery<Report2>(sqlQuery).Skip(10 * (page - 1)).Take(10).ToList();

            

          //  var usersPaged = Results.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);

      

         
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";

            foreach (var kx in Results)
            
                {
                vsn = vsn + 1;
                vcount = vcount + 1;

                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = kx.xID,
                    id = kx.ID,
                    rtm =kx.rtm,
                    applicant_name = kx.xname,
                    xclass = kx.class2,
                    reg_no =kx.reg_no,
                    tm_type = kx.tm_type,
                    product_title = kx.product_title,
                    oai_no = kx.oai_no,
                    xstat = kx.xstat,
                    reg_dt = kx.reg_dt,
                    log_staff = kx.log_staff,
                    //   batches = reader["visible"].ToString(),
                    applicantID = kx.applicantID,
                    moveapp = kx.description,
                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = kx.TransactionId,

                    //  comments = getTmOfficeDetailsByOffice(reader["log_staff"].ToString(), "5", "Accepted").xcomment
                };

                try
                {
                    int dw = Convert.ToInt32(kx.visible);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(kx.visible) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(kx.visible)).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
           // reader.Close();
          //  connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSXX3(string status, string data_status, string pvalidation, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());

            //   command = new SqlCommand(string.Concat(new object[] { "select   pwallet.rtm,pwallet.ID,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>='", status, "' AND pwallet.data_status='", data_status, "'  and pwallet.validationID ='", pvalidation, "' order by pwallet.rtm DESC     " }), connection);
            command = new SqlCommand(string.Concat(new object[] { "select   pwallet.rtm,pwallet.ID,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,pwallet.applicantID,applicant.xname,address_service.street ,address_service.telephone1,address_service.email1,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    LEFT OUTER JOIN address_service ON address_service.log_staff=pwallet.ID   WHERE pwallet.stage='5'    and pwallet.validationID ='", pvalidation, "' order by pwallet.rtm DESC     " }), connection);

            //  }
            // command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

             //   XObjs.Registration pdd = getRegistrationBySubagentRegistrationID(reader["applicantID"].ToString());
                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    id = reader["ID"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["applicantID"].ToString(),

                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                  
                    TransactionId = reader["TransactionId"].ToString(),
                    Xaddress = reader["street"].ToString(),
                    Xemail = reader["email1"].ToString(),
                    Xmobile = reader["telephone1"].ToString()
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX9(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{

            command = new SqlCommand(string.Concat(new object[] { "select '' as description, Recordal.id,Recordal.RECORDAL_TYPE,Recordal.STATUS,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID  LEFT OUTER JOIN Recordal ON Recordal.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND Recordal.data_status3='", status, "' AND Recordal.data_status4='", data_status, "'  order  by mark_info.upload_date desc     " }), connection);
            //  }
            // command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                string  RECORDAL_TYPE3="";
                string status2 = "";


                if (reader["STATUS"].ToString() == "Approved")
                {
                    status2 = "Treated";

                }

                else {

                    status2 = "New";
                }

                 if (reader["RECORDAL_TYPE"].ToString() == "Change_Name")
                            {
                             RECORDAL_TYPE3=   "FORM 22";

                            }

                            else if (reader["RECORDAL_TYPE"].ToString() == "Change_Address")
                            {

                              RECORDAL_TYPE3= "FORM 19";
                            }

                            else if (reader["RECORDAL_TYPE"].ToString() == "Change_Rectification")
                            {

                               RECORDAL_TYPE3= "FORM 26";
                            }

                            else if (reader["RECORDAL_TYPE"].ToString() == "Change_Assignment")
                            {

                                RECORDAL_TYPE3= "FORM 16";
                            }

                            else if (reader["RECORDAL_TYPE"].ToString() == "Change_Assignment2")
                            {

                               RECORDAL_TYPE3="FORM 17";
                            }

                            else if (reader["RECORDAL_TYPE"].ToString() == "Change_Renewal")
                            {

                               RECORDAL_TYPE3= "FORM 12" ;
                            }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Agent")
                {

                    RECORDAL_TYPE3 = "Change_Agent";
                }

               

                else if (reader["RECORDAL_TYPE"].ToString() == "registered_user")
                {

                    RECORDAL_TYPE3 = "FORM 47";
                }
                XObjs.Office_view item = new XObjs.Office_view
                {

                    xid = reader["xID"].ToString(),
                    description= reader["description"].ToString() ,
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),

                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString(),
                    RecordalID = reader["id"].ToString(),
                    RECORDAL_TYPE = reader["RECORDAL_TYPE"].ToString(),
                    RECORDAL_TYPE2 = RECORDAL_TYPE3,
                    RECORDAL_STATUS=status2
                   
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX19(string status)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{

            command = new SqlCommand(string.Concat(new object[] { "select Recordal.id,Recordal.RECORDAL_TYPE,Recordal.STATUS,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID  LEFT OUTER JOIN Recordal ON Recordal.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.validationID='", status, "'    order by Recordal.id DESC     " }), connection);
            //  }
            // command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;



                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                string RECORDAL_TYPE3 = "";
                string status2 = "";


                if (reader["STATUS"].ToString() == "Approved")
                {
                    status2 = "Treated";

                }

                else
                {

                    status2 = "New";
                }

                if (reader["RECORDAL_TYPE"].ToString() == "Change_Name")
                {
                    RECORDAL_TYPE3 = "FORM 22";

                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Address")
                {

                    RECORDAL_TYPE3 = "FORM 19";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Rectification")
                {

                    RECORDAL_TYPE3 = "FORM 26";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Assignment")
                {

                    RECORDAL_TYPE3 = "FORM 16";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Assignment2")
                {

                    RECORDAL_TYPE3 = "FORM 17";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Renewal")
                {

                    RECORDAL_TYPE3 = "FORM 12";
                }
                XObjs.Office_view item = new XObjs.Office_view
                {

                    xid = reader["xID"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),

                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString(),
                    RecordalID = reader["id"].ToString(),
                    RECORDAL_TYPE = reader["RECORDAL_TYPE"].ToString(),
                    RECORDAL_TYPE2 = RECORDAL_TYPE3,
                    RECORDAL_STATUS = status2

                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX11(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
          
            command = new SqlCommand(string.Concat(new object[] { "select Recordal.id,Recordal.RECORDAL_TYPE ,Recordal.STATUS,Recordal.RECORDAL_APPROVE_DATE,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID  LEFT OUTER JOIN Recordal ON Recordal.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND Recordal.data_status3='", status, "' AND Recordal.data_status4='", data_status, "'   order by  Recordal.RECORDAL_APPROVE_DATE ASC ,Recordal.id DESC  " }), connection);
            //  }
            // command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                
                string RECORDAL_TYPE3 = "";
                string status2 = "";


                if (reader["STATUS"].ToString() == "Approved")
                {
                    status2 = "Treated";

                }

                else
                {

                    status2 = "New";
                }

                if (reader["RECORDAL_TYPE"].ToString() == "Change_Name")
                {
                    RECORDAL_TYPE3 = "FORM 22";

                }

                if (reader["RECORDAL_TYPE"].ToString() == "registered_user")
                {
                    RECORDAL_TYPE3 = "FORM 47";

                }

                

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Address")
                {

                    RECORDAL_TYPE3 = "FORM 19";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Rectification")
                {

                    RECORDAL_TYPE3 = "FORM 26";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Assignment")
                {

                    RECORDAL_TYPE3 = "FORM 16";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Assignment2")
                {

                    RECORDAL_TYPE3 = "FORM 17";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Renewal")
                {

                    RECORDAL_TYPE3 = "FORM 12";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Agent")
                {

                    RECORDAL_TYPE3 = "Change_Agent";
                }


               

                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),

                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString(),
                    RecordalID = reader["id"].ToString(),
                    RECORDAL_TYPE = reader["RECORDAL_TYPE"].ToString(),
                    RECORDAL_TYPE2 = RECORDAL_TYPE3,
                    RECORDAL_STATUS = status2
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }


        public List<XObjs.Office_view2> getNew_MarkInfoRSX11a(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view2> list = new List<XObjs.Office_view2>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());

            command = new SqlCommand(string.Concat(new object[] { "select Recordal.id,Recordal.RECORDAL_TYPE ,Recordal.STATUS,Recordal.RECORDAL_APPROVE_DATE,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID  LEFT OUTER JOIN Recordal ON Recordal.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND Recordal.data_status3='", status, "' AND Recordal.data_status4='", data_status, "' AND Recordal.status='Pending'  order by  Recordal.id   " }), connection);
            //  }
             command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;


                string RECORDAL_TYPE3 = "";
                string status2 = "";


                if (reader["STATUS"].ToString() == "Approved")
                {
                    status2 = "Treated";

                }

                else
                {

                    status2 = "New";
                }

                if (reader["RECORDAL_TYPE"].ToString() == "Change_Name")
                {
                    RECORDAL_TYPE3 = "FORM 22";

                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Address")
                {

                    RECORDAL_TYPE3 = "FORM 19";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Rectification")
                {

                    RECORDAL_TYPE3 = "FORM 26";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Assignment")
                {

                    RECORDAL_TYPE3 = "FORM 16";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Assignment2")
                {

                    RECORDAL_TYPE3 = "FORM 17";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Renewal")
                {

                    RECORDAL_TYPE3 = "FORM 12";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Agent")
                {

                    RECORDAL_TYPE3 = "Change_Agent";
                }
                XObjs.Office_view2 item = new XObjs.Office_view2
                {
                  
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                   File_no= reader["reg_no"].ToString(),
                    
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                  
                    reg_dt = reader["reg_dt"].ToString(),

                    RecordalID= reader["ID"].ToString(),
                  
                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    RECORDAL_TYPE = reader["RECORDAL_TYPE"].ToString(),
                    RECORDAL_TYPE2 = RECORDAL_TYPE3,
                    RECORDAL_STATUS = status2,
                    //  Approval_Date = reader["RECORDAL_APPROVE_DATE"].ToString()=="" ?   reader["RECORDAL_APPROVE_DATE"].ToString() : Convert.ToDateTime(reader["RECORDAL_APPROVE_DATE"].ToString()).Date.ToShortDateString()
                    Approval_Date = reader["RECORDAL_APPROVE_DATE"].ToString()
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

             //   item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view2> getNew_MarkInfoRSX11c(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view2> list = new List<XObjs.Office_view2>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());

            command = new SqlCommand(string.Concat(new object[] { "select Recordal.id,Recordal.RECORDAL_TYPE ,Recordal.STATUS,Recordal.RECORDAL_APPROVE_DATE,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID  LEFT OUTER JOIN Recordal ON Recordal.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND Recordal.data_status3='", status, "' AND Recordal.data_status4='", data_status, "' AND Recordal.status='Approved'   order by  RECORDAL_APPROVE_DATE DESC  " }), connection);
            //  }
            command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;


                string RECORDAL_TYPE3 = "";
                string status2 = "";


                if (reader["STATUS"].ToString() == "Approved")
                {
                    status2 = "Treated";

                }

                else
                {

                    status2 = "New";
                }

                if (reader["RECORDAL_TYPE"].ToString() == "Change_Name")
                {
                    RECORDAL_TYPE3 = "FORM 22";

                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Address")
                {

                    RECORDAL_TYPE3 = "FORM 19";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Rectification")
                {

                    RECORDAL_TYPE3 = "FORM 26";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Assignment")
                {

                    RECORDAL_TYPE3 = "FORM 16";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Assignment2")
                {

                    RECORDAL_TYPE3 = "FORM 17";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Renewal")
                {

                    RECORDAL_TYPE3 = "FORM 12";
                }

                else if (reader["RECORDAL_TYPE"].ToString() == "Change_Agent")
                {

                    RECORDAL_TYPE3 = "Change_Agent";
                }
                XObjs.Office_view2 item = new XObjs.Office_view2
                {

                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    File_no = reader["reg_no"].ToString(),

                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),

                    reg_dt = reader["reg_dt"].ToString(),

                    RecordalID = reader["ID"].ToString(),

                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    RECORDAL_TYPE = reader["RECORDAL_TYPE"].ToString(),
                    RECORDAL_TYPE2 = RECORDAL_TYPE3,
                    RECORDAL_STATUS = status2,
                    //  Approval_Date = reader["RECORDAL_APPROVE_DATE"].ToString()=="" ?   reader["RECORDAL_APPROVE_DATE"].ToString() : Convert.ToDateTime(reader["RECORDAL_APPROVE_DATE"].ToString()).Date.ToShortDateString()
                    Approval_Date = reader["RECORDAL_APPROVE_DATE"].ToString()
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                //   item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view2> getNew_MarkInfoRSX11b(string type, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view2> list = new List<XObjs.Office_view2>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());

            command = new SqlCommand(string.Concat(new object[] { "select Recordal.id,Recordal.RECORDAL_TYPE ,Recordal.STATUS,Recordal.RECORDAL_APPROVE_DATE,  pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID  LEFT OUTER JOIN Recordal ON Recordal.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND Recordal.RECORDAL_TYPE='", type, "'  order by  Recordal.RECORDAL_REQUEST_DATE ASC ,Recordal.id DESC  " }), connection);
            //  }
            // command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;


                string RECORDAL_TYPE3 = "Change of Agent";
                string status2 = "";


                if (reader["STATUS"].ToString() == "Approved")
                {
                    status2 = "Treated";

                }

                else
                {

                    status2 = "New";
                }



                XObjs.Office_view2 item = new XObjs.Office_view2
                {

                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    File_no = reader["reg_no"].ToString(),

                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),

                    reg_dt = reader["reg_dt"].ToString(),

                    RecordalID = reader["ID"].ToString(),

                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    RECORDAL_TYPE = reader["RECORDAL_TYPE"].ToString(),
                    RECORDAL_TYPE2 = RECORDAL_TYPE3,
                    RECORDAL_STATUS = status2
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                //   item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX5(string status)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());

            command = new SqlCommand(string.Concat(new object[] { "select   pwallet.rtm,pwallet.TransactionId,pwallet.visible,pwallet.applicantID,applicant.xname,address.street ,address.countryID,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID  LEFT OUTER JOIN address ON applicant.addressID=Address.ID    WHERE pwallet.stage='5' AND pwallet.ID='", status, "'       " }), connection);
            //  }
            // command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

               
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["visible"].ToString(),

                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn),
                    TransactionId = reader["TransactionId"].ToString(),
                    Street = reader["street"].ToString(),
                    CountryID = reader["countryID"].ToString()
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX3(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{
            command = new SqlCommand(string.Concat(new object[] { "select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "'  order by pwallet.rtm DESC     " }), connection);
            //  }
             command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["applicantID"].ToString(),

                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn)
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRSX333(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            //if ((status == "4") && (data_status == "Refused"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "8") && (data_status == "Registered"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else if ((status == "5") && (data_status == "acc_printed"))
            //{
            //    command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            //}
            //else
            //{
            command = new SqlCommand(string.Concat(new object[] { "select   pwallet.rtm,pwallet.visible,pwallet.applicantID,applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'  order by pwallet.rtm DESC     " }), connection);
            //  }
            command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            string pp2 = "";
            int vcount = 0;
            int vsn = 0;
            string voffice = "";
            while (reader.Read())
            {
                vsn = vsn + 1;
                vcount = vcount + 1;

                //if (getTmOfficeByMID(reader["log_staff"].ToString()) != "")
                //{
                //    voffice = (getTmOfficeByMID(reader["log_staff"].ToString()));
                //}
                //else
                //{
                //    voffice = "None";
                //}
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    //   batches = reader["visible"].ToString(),
                    applicantID = reader["applicantID"].ToString(),

                    //Office = reader["data_status"].ToString(),
                    Sn = Convert.ToString(vsn)
                };

                try
                {
                    int dw = Convert.ToInt32(reader["visible"]);
                    if (dw > 1)
                    {
                        pp2 = (Convert.ToInt32(reader["visible"]) - 1).ToString();

                    }

                    else
                    {
                        pp2 = (Convert.ToInt32(reader["visible"])).ToString();

                    }
                }
                catch (Exception ee)
                {

                }

                item.batches = pp2;
                list.Add(item);


            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_MarkInfoRtmRSX(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            if ((status == "4") && (data_status == "Refused"))
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select pwallet.rtm, applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' ORDER BY rtm ASC  " }), connection);
            }
            else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select pwallet.rtm, applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' ORDER BY rtm ASC  " }), connection);
            }
            else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select pwallet.rtm, applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' ORDER BY rtm ASC  " }), connection);
            }
            else if ((status == "8") && (data_status == "Registered"))
            {
                //  command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select pwallet.rtm, applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' ORDER BY rtm ASC  " }), connection);
                command = new SqlCommand(string.Concat(new object[] { "Select * from (select distinct  pwallet.ID, pwallet.rtm, applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' ) as Tab WHERE CONVERT(int, Tab.rtm) BETWEEN '", start, "' AND '", limit, "' order BY rtm ASC " }), connection);

            }
            else if ((status == "5") && (data_status == "acc_printed"))
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select pwallet.rtm, applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.acc_p='1' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            }
            else
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select pwallet.rtm, applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'  ) SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' ORDER BY rtm ASC  " }), connection);
            }
            command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    rtm = reader["rtm"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_PrintedMarkInfoNoLimitRSX(string status, string data_status)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            if ((status == "4") && (data_status == "Refused"))
            {
                command = new SqlCommand("select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no',ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' ORDER BY mark_info.xID ", connection);
            }
            else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            {
                command = new SqlCommand("select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no',ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable')) ORDER BY mark_info.xID ", connection);
            }
            else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            {
                command = new SqlCommand("select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no',ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Fresh') OR (pwallet.data_status='Invalid')) ORDER BY mark_info.xID ", connection);
            }
            else if ((status == "8") && (data_status == "Registered"))
            {
                command = new SqlCommand("select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no',ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status>'" + status + "' AND pwallet.data_status='Registered' ORDER BY mark_info.xID ", connection);
            }
            else
            {
                command = new SqlCommand("select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no',ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "'  ORDER BY mark_info.xID ", connection);
            }
            command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNew_PrintedMarkInfoRSX(string status, string data_status, int start, int limit)
        {
            SqlCommand command;
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            SqlConnection connection = new SqlConnection(this.Connect());
            if ((status == "4") && (data_status == "Refused"))
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "')SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            }
            else if ((status == "4") && ((data_status == "Registrable") || (data_status == "Non-registrable")))
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Registrable'))  )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            }
            else if ((status == "1") && ((data_status == "Fresh") || (data_status == "Invalid")))
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND (pwallet.data_status='Fresh' OR pwallet.data_status='Invalid') )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            }
            else if ((status == "8") && (data_status == "Registered"))
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID     WHERE pwallet.stage='5' AND pwallet.status>'", status, "' AND pwallet.data_status='", data_status, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            }
            else
            {
                command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank'  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE pwallet.stage='5' AND pwallet.status='", status, "' AND pwallet.data_status='", data_status, "'  ) SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
            }
           command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNewAdminSearchMarkInfoByRtmRS(string status, string data_status, string criteria, List<string> fulltext, string dateFrom, string dateTo)
        {
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            string cmdText = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            if (criteria == "product_title")
            {
                num = fulltext.Count - 1;
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused'))  AND ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid'))  AND ";
                }
                else if ((status == "5") && (data_status == "acc_printed"))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.acc_p='1'  AND ";
                }
                else
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ";
                }
                for (int i = 0; i < fulltext.Count; i++)
                {
                    if (fulltext.Count == 1)
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else if (num == i)
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) OR";
                    }
                }
                str4 = "AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY rtm ASC";
                cmdText = str2 + str3 + str4;
            }
            else if (criteria == "reg_number")
            {
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused')) AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY rtm ASC ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid')) AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY rtm ASC ";
                }
                else if ((status == "5") && (data_status == "acc_printed"))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.acc_p='1'  AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY rtm ASC ";
                }
                else
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY rtm ASC ";
                }
            }
            else if (criteria == "app_number")
            {
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused')) AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY rtm ASC ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid')) AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY rtm ASC ";
                }
                else if ((status == "5") && (data_status == "acc_printed"))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.acc_p='1'  AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY rtm ASC ";
                }
                else
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY rtm ASC ";
                }
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    rtm = reader["rtm"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNewAdminSearchMarkInfoRS(string status, string data_status, string criteria, List<string> fulltext, string dateFrom, string dateTo)

     
        {
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            string cmdText = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            if (criteria == "product_title")
            {
                num = fulltext.Count - 1;
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused'))  ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid'))   ";
                }
                else if ((status == "5") && (data_status == "acc_printed"))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.acc_p='1'   ";
                }
                else
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from pwallet LEFT OUTER JOIN mark_info ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE    pwallet.stage='5' AND CAST(pwallet.status AS INT)>='" + status + "' ";
                }
                for (int i = 0; i < fulltext.Count; i++)
                {
                    if (fulltext.Count == 1)
                    {
                        str3 = str3 + "AND  ( product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else if (num == i)
                    {
                        str3 = str3 + " AND (  product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else
                    {
                        str3 = str3 + " AND (  product_title like '%" + fulltext[i] + "%' ) OR";
                    }
                }
              //  str4 = "AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC";

                str4 = " ORDER BY xID ASC";

               // str4 = " ORDER BY xID ASC";
              
                cmdText = str2 + str3 + str4;

              //  cmdText = str2 + str4;
            }
            else if (criteria == "reg_number")
            {
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused')) AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid')) AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "5") && (data_status == "acc_printed"))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.acc_p='1'  AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
            }
            else if (criteria == "app_number")
            {
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused')) AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid')) AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "5") && (data_status == "acc_printed"))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.acc_p='1'  AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
              CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    rtm = reader["rtm"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<XObjs.Office_view> getNewAdminSearchMarkInfoRS222(string status, string data_status, string criteria, List<string> fulltext, string dateFrom, string dateTo)


        {
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            string cmdText = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int num = 0;
            int num2 = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            if (criteria == "product_title")
            {
                num = fulltext.Count - 1;
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused'))  ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid'))   ";
                }
                else if ((status == "5") && (data_status == "acc_printed"))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.acc_p='1'   ";
                }
                else
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,mark_info.logo_pic,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from pwallet LEFT OUTER JOIN mark_info ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE    pwallet.stage='5' AND CAST(pwallet.status AS INT)>='" + status + "' ";
                }
                for (int i = 0; i < fulltext.Count; i++)
                {
                    if (fulltext.Count == 1)
                    {
                        str3 = str3 + "AND  ( product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else if (num == i)
                    {
                        str3 = str3 + "  (  product_title like '%" + fulltext[i] + "%' ) ";
                    }

                    else if (num2 == i)
                    {
                        str3 = str3 + " AND (  product_title like '%" + fulltext[i] + "%' ) OR";
                    }
                    else
                    {
                        str3 = str3 + "  (  product_title like '%" + fulltext[i] + "%' ) OR";
                    }
                }
                //  str4 = "AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC";

                str4 = " ORDER BY xID ASC";

                // str4 = " ORDER BY xID ASC";

                cmdText = str2 + str3 + str4;

                //  cmdText = str2 + str4;
            }
            else if (criteria == "reg_number")
            {
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused')) AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid')) AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "5") && (data_status == "acc_printed"))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.acc_p='1'  AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
            }
            else if (criteria == "app_number")
            {
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused')) AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid')) AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "5") && (data_status == "acc_printed"))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.acc_p='1'  AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            int sno = 1;
            string acceptdate = "";
            while (reader.Read())
            {
                acceptdate = "";

                var lt_tm_office = getTmOfficeDetailsByID(reader["log_staff"].ToString());
                foreach (zues.TmOffice t2 in lt_tm_office)
                {
                   
                    if ((t2.data_status == "Accepted") && (t2.admin_status == "5"))
                    {
                        acceptdate = t2.reg_date;
                        // acceptance_date.Add(t.reg_date);
                    }
                }
                XObjs.Office_view item = new XObjs.Office_view
                {


               

                xid = reader["xID"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    Sn = Convert.ToString(sno  ) ,
                    logo_pic = reader["logo_pic"].ToString() ,
                    AcceptanceDate = acceptdate

                };
                list.Add(item);
                sno = sno + 1;
            }
            reader.Close();
            connection.Close();
            return list;
        }


        public List<XObjs.Office_view> getNewAdminSearchMarkInfoRS2(string status, string data_status, string criteria, List<string> fulltext, string dateFrom, string dateTo, int PageNo, int NoOfRecord)
        {
            List<XObjs.Office_view> list = new List<XObjs.Office_view>();
            new XObjs.Office_view();
            string cmdText = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            if (criteria == "product_title")
            {
                num = fulltext.Count - 1;
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused'))  ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid'))   ";
                }
                else if ((status == "5") && (data_status == "acc_printed"))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.acc_p='1'   ";
                }
                else
                {
                  //  str2 = "select   pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from pwallet LEFT OUTER JOIN mark_info ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE   pwallet.stage='5' AND pwallet.ID BETWEEN '",PageNo, "' AND '",NoOfRecord , "' ";

                    str2 = "Select * from (select  pwallet.ID 'ID',applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID    WHERE   pwallet.stage='5' AND pwallet.status='5'    ) as Tab WHERE Tab.ID BETWEEN " + PageNo + " AND" + NoOfRecord + "  order by ID DESC ";
                }
                for (int i = 0; i < fulltext.Count; i++)
                {
                    if (fulltext.Count == 1)
                    {
                        str3 = str3 + "AND  ( product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else if (num == i)
                    {
                        str3 = str3 + " AND (  product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else
                    {
                        str3 = str3 + " AND (  product_title like '%" + fulltext[i] + "%' ) OR";
                    }
                }
                str4 = "AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC";

                // str4 = " ORDER BY xID ASC";

                cmdText = str2 + str3 + str4;

                //  cmdText = str2 + str4;
            }
            else if (criteria == "reg_number")
            {
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused')) AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid')) AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "5") && (data_status == "acc_printed"))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.acc_p='1'  AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND mark_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
            }
            else if (criteria == "app_number")
            {
                if ((status == "4") && ((data_status == "Refused") || (data_status == "Non-registrable")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Non-registrable') OR (pwallet.data_status='Refused')) AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "1") && ((data_status == "Valid") || (data_status == "Invalid")))
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND ((pwallet.data_status='Valid') OR (pwallet.data_status='Invalid')) AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else if ((status == "5") && (data_status == "acc_printed"))
                {
                    str2 = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.acc_p='1'  AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
                else
                {
                    cmdText = "select pwallet.rtm,  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number 'reg_no',mark_info.product_title,tm_type.type 'tm_type',pwallet.validationID 'oai_no', ISNULL(pwallet.data_status,'None') 'xstat', mark_info.reg_date 'reg_dt',mark_info.log_staff  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID   LEFT OUTER JOIN tm_type ON tm_type.xID=mark_info.tm_typeID  LEFT OUTER JOIN applicant ON applicant.log_staff=pwallet.ID   WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
                }
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.Office_view item = new XObjs.Office_view
                {
                    xid = reader["xID"].ToString(),
                    applicant_name = reader["xname"].ToString(),
                    xclass = reader["class"].ToString(),
                    reg_no = reader["reg_no"].ToString(),
                    tm_type = reader["tm_type"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    oai_no = reader["oai_no"].ToString(),
                    xstat = reader["xstat"].ToString(),
                    reg_dt = reader["reg_dt"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    rtm = reader["rtm"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

      

        public List<XObjs.G_App_info> getNewGAdminSearchAppInfoRS(string status, string data_status, string criteria, string kword, string dateFrom, string dateTo)
        {
            List<XObjs.G_App_info> list = new List<XObjs.G_App_info>();
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (criteria == "applicant_name")
            {
                List<XObjs.G_Applicant_info> list2 = this.getG_ApplicantByName(kword);
                if (list2.Count > 0)
                {
                    cmdText = "select g_pwallet.log_officer,g_tm_info.tm_title 'tm_title',g_tm_info.tm_class 'xclass',g_tm_info.reg_number,g_app_info.ID,g_app_info.rtm_number,g_app_info.application_no,g_app_info.item_code,g_app_info.filing_date,g_app_info.reg_no,  g_app_info.reg_date,g_app_info.log_staff,g_app_info.visible from g_app_info LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff  LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5'  AND ";
                    for (int i = 0; i < list2.Count; i++)
                    {
                        if (i == 0)
                        {
                            cmdText = cmdText + " g_app_info.log_staff='" + list2[i].log_staff + "' ";
                        }
                        else
                        {
                            cmdText = cmdText + " OR g_app_info.log_staff='" + list2[i].log_staff + "' ";
                        }
                    }
                }
                else
                {
                    cmdText = "select g_pwallet.log_officer,g_tm_info.tm_title 'tm_title',g_tm_info.tm_class 'xclass',g_tm_info.reg_number,g_app_info.ID,g_app_info.rtm_number,g_app_info.application_no,g_app_info.item_code,g_app_info.filing_date,g_app_info.reg_no,  g_app_info.reg_date,g_app_info.log_staff,g_app_info.visible from g_app_info LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5' AND g_app_info.log_staff='vcx' ";
                }
            }
            else if (criteria == "app_number")
            {
                cmdText = "select g_pwallet.log_officer,g_tm_info.tm_title 'tm_title',g_tm_info.tm_class 'xclass',g_tm_info.reg_number,g_app_info.ID,g_app_info.rtm_number,g_app_info.application_no,g_app_info.item_code,g_app_info.filing_date,g_app_info.reg_no,  g_app_info.reg_date,g_app_info.log_staff,g_app_info.visible from g_app_info LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5' AND g_pwallet.validationID ='" + kword + "' ";
            }
            else if (criteria == "product_title")
            {
                List<XObjs.G_Tm_info> list3 = this.getG_Tm_infoByName(kword);
                if (list3.Count > 0)
                {
                    cmdText = "select g_pwallet.log_officer,g_tm_info.tm_title 'tm_title',g_tm_info.tm_class 'xclass',g_tm_info.reg_number,g_app_info.ID,g_app_info.rtm_number,g_app_info.application_no,g_app_info.item_code,g_app_info.filing_date,g_app_info.reg_no,  g_app_info.reg_date,g_app_info.log_staff,g_app_info.visible from g_app_info LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5'  AND ";
                    for (int j = 0; j < list3.Count; j++)
                    {
                        if (j == 0)
                        {
                            cmdText = cmdText + " g_app_info.log_staff='" + list3[j].log_staff + "' ";
                        }
                        else
                        {
                            cmdText = cmdText + " OR g_app_info.log_staff='" + list3[j].log_staff + "' ";
                        }
                    }
                }
                else
                {
                    cmdText = "select g_pwallet.log_officer,g_tm_info.tm_title 'tm_title',g_tm_info.tm_class 'xclass',g_tm_info.reg_number,g_app_info.ID,g_app_info.rtm_number,g_app_info.application_no,g_app_info.item_code,g_app_info.filing_date,g_app_info.reg_no,  g_app_info.reg_date,g_app_info.log_staff,g_app_info.visible from g_app_info LEFT OUTER JOIN g_tm_info ON g_app_info.log_staff=g_tm_info.log_staff LEFT OUTER JOIN g_pwallet ON g_app_info.log_staff=g_pwallet.ID WHERE g_pwallet.stage='5' AND g_app_info.log_staff='vcx' ";
                }
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                XObjs.G_App_info item = new XObjs.G_App_info
                {
                    id = reader["id"].ToString(),
                    xclass = reader["xclass"].ToString(),
                    tm_title = reader["tm_title"].ToString(),
                    rtm_number = reader["rtm_number"].ToString(),
                    application_no = reader["application_no"].ToString(),
                    item_code = reader["log_officer"].ToString(),
                    filing_date = reader["filing_date"].ToString(),
                    reg_no = reader["reg_number"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<Pwallet> getprintedPwalletIDs()
        {
            List<Pwallet> list = new List<Pwallet>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT ID from pwallet where data_status='acc_printed' ", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Pwallet item = new Pwallet
                {
                    ID = reader["ID"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public List<MarkInfo> getPublishAdminSearchMarkInfoRS(string status, string data_status, string criteria, List<string> fulltext, string dateFrom, string dateTo)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            string cmdText = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            if (criteria == "product_title")
            {
                num = fulltext.Count - 1;
                str2 = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22' AND CAST(pwallet.status AS INT)>=5 AND pwallet.data_status='" + data_status + "' AND ";
                for (int i = 0; i < fulltext.Count; i++)
                {
                    if (fulltext.Count == 1)
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else if (num == i)
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) ";
                    }
                    else
                    {
                        str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) OR";
                    }
                }
                str4 = "AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "' ORDER BY xID ASC";
                cmdText = str2 + str3 + str4;
            }
            else if (criteria == "app_number")
            {
                cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22' AND CAST(pwallet.status AS INT)>=5  AND pwallet.data_status='" + data_status + "' AND pwallet.validationID like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
               CommandTimeout = 0
            };
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
            connection.Close();
            return list;
        }

        public long getPublishMarkInfoRSCnt(string status, string data_status)
        {
            long num = 0L;
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select Count(*) AS cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22' AND CAST(pwallet.status AS INT)>=5 AND pwallet.data_status = '" + data_status + "' ", connection)
            {
              CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                num = Convert.ToInt64(reader["cnt"]);
            }
            reader.Close();
            connection.Close();
            return num;
        }

        public List<MarkInfo> getPublishMarkInfoRSX(string status, string data_status, string start, string limit)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("WITH RSTbl AS (select  applicant.xname,mark_info.national_classID 'class',mark_info.xID,mark_info.reg_number,mark_info.product_title,mark_info.tm_typeID,mark_info.reg_date,mark_info.log_staff, ROW_NUMBER() OVER (ORDER BY mark_info.xID) AS 'RowRank' from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status<>'33' AND pwallet.status<>'22' AND CAST(pwallet.status AS INT)>=5 AND pwallet.data_status='" + data_status + "') SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection)
            {
              CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                MarkInfo item = new MarkInfo
                {
                    xID = reader["xID"].ToString(),
                    reg_number = reader["reg_number"].ToString(),
                    tm_typeID = reader["tm_typeID"].ToString(),
                    product_title = reader["product_title"].ToString(),
                    log_staff = reader["log_staff"].ToString(),
                    reg_date = reader["reg_date"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public Pwallet getPwalletDetailsByID(string ID)
        {
            Pwallet pwallet = new Pwallet
            {
                ID = "",
                applicantID = "",
                validationID = "",
                stage = "",
                status = "",
                data_status = "",
                amt = "",
                reg_date = "",
                visible = "",
                rtm = "",
                acc_p = "",
                TransactionId =""
            };
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE ID='" + ID + "' ", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                pwallet.ID = reader["ID"].ToString();
                pwallet.applicantID = reader["applicantID"].ToString();
                pwallet.validationID = reader["validationID"].ToString();
                pwallet.stage = reader["stage"].ToString();
                pwallet.status = reader["status"].ToString();
                pwallet.data_status = reader["data_status"].ToString();
                pwallet.amt = reader["amt"].ToString();
                pwallet.reg_date = reader["reg_date"].ToString();
                pwallet.visible = reader["visible"].ToString();
                pwallet.rtm = reader["rtm"].ToString();
                pwallet.acc_p = reader["acc_p"].ToString();

                pwallet.TransactionId = reader["TransactionId"].ToString();

            }
            reader.Close();
            connection.Close();
            return pwallet;
        }

        public Pwallet getPwalletDetailsByID2(string ID)
        {
            Pwallet pwallet = new Pwallet
            {
                ID = "",
                applicantID = "",
                validationID = "",
                stage = "",
                status = "",
                data_status = "",
                amt = "",
                reg_date = "",
                visible = "",
                rtm = "",
                acc_p = ""
            };
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwalletAmendment WHERE ID='" + ID + "' ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                pwallet.ID = reader["ID"].ToString();
                pwallet.applicantID = reader["applicantID"].ToString();
                pwallet.validationID = reader["validationID"].ToString();
                pwallet.stage = reader["stage"].ToString();
                pwallet.status = reader["status"].ToString();
                pwallet.data_status = reader["data_status"].ToString();
                pwallet.amt = reader["amt"].ToString();
                pwallet.reg_date = reader["reg_date"].ToString();
                pwallet.visible = reader["visible"].ToString();
                pwallet.rtm = reader["rtm"].ToString();
                pwallet.acc_p = reader["acc_p"].ToString();

                pwallet.log_staff=Convert.ToInt64( reader["pwalletid"]);
            }
            reader.Close();
            connection.Close();
            return pwallet;
        }

        public string getPwalletIDByMID(string mark_infoID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT log_staff from mark_info where xID='" + mark_infoID + "'", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["log_staff"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public List<Pwallet> getPwalletListDetailsByID(string ID)
        {
            List<Pwallet> list = new List<Pwallet>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE ID='" + ID + "' ", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Pwallet item = new Pwallet
                {
                    ID = Convert.ToInt64(reader["ID"]).ToString(),
                    applicantID = reader["applicantID"].ToString(),
                    validationID = reader["validationID"].ToString(),
                    stage = reader["stage"].ToString(),
                    status = reader["status"].ToString(),
                    data_status = reader["data_status"].ToString(),
                    amt = reader["amt"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    acc_p = reader["acc_p"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }


        public Pwallet getPwalletListDetailsByID2(string ID)
        {
            List<Pwallet> list = new List<Pwallet>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE ID='" + ID + "' ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            Pwallet item2 = new Pwallet();
            while (reader.Read())
            {
                Pwallet item = new Pwallet
                {
                    ID = Convert.ToInt64(reader["ID"]).ToString(),
                    applicantID = reader["applicantID"].ToString(),
                    validationID = reader["validationID"].ToString(),
                    stage = reader["stage"].ToString(),
                    status = reader["status"].ToString(),
                    data_status = reader["data_status"].ToString(),
                    amt = reader["amt"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    visible = reader["visible"].ToString(),
                    rtm = reader["rtm"].ToString(),
                    acc_p = reader["acc_p"].ToString()
                };

                item2 = item;
              //  list.Add(item);
            }
            reader.Close();
            connection.Close();
            return item2;
        }

        public string getRoleByID(string id)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT xroleID from xadminz_tm where xID='" + id + "'", connection)
            {
              CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["xroleID"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }


        public Applicant  getApplicantName(string id)
        {
            string str = "";
            string address = "";
            string address2 = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT xname, addressID   from applicant where log_staff='" + id + "'", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["xname"].ToString();
                address = reader["addressID"].ToString();
            }
            reader.Close();
            connection.Close();

            address2 = getApplicantAddress(id);
          //  address2 = getApplicantAddress(address);

            Applicant pp = new Applicant();
            pp.Applicant_Name = str;

            pp.Applicant_Address = address2;
            return pp ;
        }


        public string  getApplicantName2(string id)
        {
            string str = "";
            string address = "";
            string address2 = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT xname, addressID   from applicant where log_staff='" + id + "'", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["xname"].ToString();
                address = reader["addressID"].ToString();
            }
            reader.Close();
            connection.Close();

            address2 = getApplicantAddress(id);

            Applicant pp = new Applicant();
            pp.Applicant_Name = str;

            pp.Applicant_Address = address2;
          //  return pp;
            return str;
        }

        public string getApplicantAddress(string id)
        {
            string str = "";
            String addressID = getApplicantAddressId(id);
            Int64 addressID2 = Convert.ToInt64(addressID);
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT street  from address where id='" + addressID2 + "'", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["street"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public Change_Rectify getApplicantRectify(string id)
        {
            string str = "";
            //String addressID = getApplicantAddressId(id);
            //Int64 addressID2 = Convert.ToInt64(addressID);
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT *   from mark_info  where log_staff='" + id + "'", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            Change_Rectify vf = new Change_Rectify();
            while (reader.Read())
            {
                vf.product_title = reader["product_title"].ToString();
                vf.logo_pic = reader["logo_pic"].ToString();
            }
            reader.Close();
            connection.Close();
            return vf;
        }


        public Agent_Info getAgentInfo(string id)
        {
            string str = "";
            String addressID = getApplicantAddressId(id);
            Int64 addressID2 = Convert.ToInt64(addressID);
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT agent_code,xname,addressID  from representative where log_staff='" + id + "' ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            Agent_Info xr = new Agent_Info();
            while (reader.Read())
            {
                xr.Agent_Code = reader["agent_code"].ToString();

                xr.Agent_Name = reader["xname"].ToString();

                String AddressId3 = reader["addressID"].ToString();
                Agent_Info pp2 = getAgentInfo2(AddressId3);
                xr.Address = pp2.Address;
                xr.Email = pp2.Email;
                xr.Mobile = pp2.Mobile;
            }
            reader.Close();
            connection.Close();
            return xr;
        }

        public string getAgentInfo3(string id)
        {
            string str = "empty";
            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT CompanyName  from registrations where Sys_ID='" + id + "' ", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            Agent_Info xr = new Agent_Info();
            while (reader.Read())
            {
                str = reader["CompanyName"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }
        public Agent_Info getAgentInfo2(string id)
        {
            string str = "";
          //  String addressID = getApplicantAddressId(id);
           // Int64 addressID2 = Convert.ToInt64(addressID);
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT street,telephone1,email1  from address where ID='" + id + "'", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            Agent_Info xr = new Agent_Info();
            while (reader.Read())
            {
                xr.Address = reader["street"].ToString();

                xr.Email = reader["email1"].ToString();
                xr.Mobile = reader["telephone1"].ToString();

              
            }
            reader.Close();
            connection.Close();
            return xr;
        }


        public string getApplicantAddressId(string id)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT addressID   from applicant  where log_staff='" + id + "'", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["addressID"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public string getRoleNameByID(string ID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT name FROM roles WHERE ID='" + ID + "' ", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["name"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public List<MarkInfo> getSearchMarkInfoRS(string kword, List<string> fulltext, string cri)
        {
            List<MarkInfo> list = new List<MarkInfo>();
            new MarkInfo();
            string cmdText = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int num = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            if (fulltext == null)
            {
                if (cri == "0")
                {
                    cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE (pwallet.status <>'22') AND (pwallet.status <>'33') AND (pwallet.status >='5') AND (product_title like '%" + kword + "%') ORDER BY xID ASC";
                }
                else
                {
                    cmdText = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE (pwallet.status <>'22') AND (pwallet.status <>'33') AND (pwallet.status >='5') AND (product_title like '%" + kword + "%') AND national_classID = '" + cri + "' ORDER BY xID ASC";
                }
            }
            else
            {
                num = fulltext.Count - 1;
                if (cri == "0")
                {
                    str2 = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE (pwallet.status <>'22') AND (pwallet.status <>'33') AND (pwallet.status >='5') AND ";
                }
                else
                {
                    str2 = "select * from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE (pwallet.status <>'22') AND (pwallet.status <>'33') AND (pwallet.status >='5') AND (national_classID = '" + cri + "') AND ";
                }
                str3 = str3 + "(";
                for (int i = 0; i < fulltext.Count; i++)
                {
                    if (num != i && num > i)
                    {

                        str3 = str3 + "product_title like '%" + fulltext[i] + "%' OR  ";


                    }

                    if (num == i )
                    {

                        str3 = str3 + "product_title like '%" + fulltext[i] + "%' )  ";


                    }



                    //if (fulltext.Count == 1)
                    //{
                    //    str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) ";
                    //}
                    //else if (num == i)
                    //{
                    //    str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) ";
                    //}
                    //else
                    //{
                    //    str3 = str3 + " ( product_title like '%" + fulltext[i] + "%' ) OR";
                    //}
                }
                str4 = " ORDER BY xID ASC";
                cmdText = str2 + str3 + str4;
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
               CommandTimeout = 0
            };
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
                    xvisible = reader["xvisible"].ToString(),
                    validationID = reader["validationID"].ToString(),
                    data_status = reader["data_status"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        public Adminz getTmAdminDetailsByID(string ID)
        {
            Adminz adminz = new Adminz
            {
                xID = "",
                xroleID = "",
                xname = "",
                xemail = "",
                xpass = "",
                xtelephone1 = "",
                xtelephone2 = "",
                xsection = "",
                xlog_officer = "",
                xreg_date = "",
                xvisible = ""
            };
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM xadminz_tm WHERE xID='" + ID + "' ", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                adminz.xID = reader["xID"].ToString();
                adminz.xroleID = reader["xroleID"].ToString();
                adminz.xname = reader["xname"].ToString();
                adminz.xemail = reader["xemail"].ToString();
                adminz.xpass = reader["xpass"].ToString();
                adminz.xtelephone1 = reader["xtelephone1"].ToString();
                adminz.xtelephone2 = reader["xtelephone2"].ToString();
                adminz.xsection = reader["xsection"].ToString();
                adminz.xlog_officer = reader["xlog_officer"].ToString();
                adminz.xreg_date = reader["xreg_date"].ToString();
                adminz.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            connection.Close();
            return adminz;
        }

        public TmOffice getTmOfficeByID(string ID)
        {
            TmOffice office = new TmOffice();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * from tm_office where ID='" + ID + "'", connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                office.ID = reader["ID"].ToString();
                office.admin_status = reader["admin_status"].ToString();
                office.data_status = reader["data_status"].ToString();
                office.pwalletID = reader["pwalletID"].ToString();
                office.reg_date = reader["reg_date"].ToString();
                office.xcomment = reader["xcomment"].ToString();
                office.xdoc1 = reader["xdoc1"].ToString();
                office.xdoc2 = reader["xdoc2"].ToString();
                office.xdoc3 = reader["xdoc3"].ToString();
                office.xofficer = reader["xofficer"].ToString();
                office.xtime = reader["xtime"].ToString();
                office.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            connection.Close();
            return office;
        }

        public string getTmOfficeByMID(string pwalletID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT data_status from tm_office where pwalletID='" + pwalletID + "'", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["data_status"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public List<TmOffice> getTmOfficeDetailsByID(string ID)
        {
            List<TmOffice> list = new List<TmOffice>();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM tm_office WHERE pwalletID='" + ID + "' order by reg_date ", connection)
            {
              CommandTimeout = 0
            };
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
            connection.Close();
            return list;
        }

        public TmOffice getTmOfficeDetailsByOffice(string ID, string status, string data_status)
        {
            TmOffice office = new TmOffice();
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM tm_office WHERE pwalletID='" + ID + "' AND  admin_status='" + status + "' AND  data_status='" + data_status + "' ORDER BY ID DESC ", connection)
            {
              CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                office.ID = reader["ID"].ToString();
                office.pwalletID = reader["pwalletID"].ToString();
                office.admin_status = reader["admin_status"].ToString();
                office.data_status = reader["data_status"].ToString();
                office.xcomment = reader["xcomment"].ToString();
                office.xdoc1 = reader["xdoc1"].ToString();
                office.xdoc2 = reader["xdoc2"].ToString();
                office.xdoc3 = reader["xdoc3"].ToString();
                office.xofficer = reader["xofficer"].ToString();
                office.reg_date = reader["reg_date"].ToString();
                office.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            connection.Close();
            return office;
        }

        public string getTmTypeByID(string id)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT type from tm_type where xID='" + id + "'", connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["type"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public Adminz getTopAdminDetails()
        {
            Adminz adminz = new Adminz();
            SqlConnection connection = new SqlConnection(this.Connect());
            string cmdText = "SELECT top 1 * from xadminz_tm";
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                adminz.xID = reader["xID"].ToString();
                adminz.xroleID = reader["xroleID"].ToString();
                adminz.xname = reader["xname"].ToString();
                adminz.xemail = reader["xemail"].ToString();
                adminz.xpass = reader["xpass"].ToString();
                adminz.xtelephone1 = reader["xtelephone1"].ToString();
                adminz.xtelephone2 = reader["xtelephone2"].ToString();
                adminz.xsection = reader["xsection"].ToString();
                adminz.xlog_officer = reader["xlog_officer"].ToString();
                adminz.xreg_date = reader["xreg_date"].ToString();
                adminz.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            connection.Close();
            return adminz;
        }

        public Adminz getTopAdminDetails2()
        {
            Adminz adminz = new Adminz();
            SqlConnection connection = new SqlConnection(this.Connect());
            string cmdText = "SELECT top 1 * from xadminz_tm where xroleid=14";
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                adminz.xID = reader["xID"].ToString();
                adminz.xroleID = reader["xroleID"].ToString();
                adminz.xname = reader["xname"].ToString();
                adminz.xemail = reader["xemail"].ToString();
                adminz.xpass = reader["xpass"].ToString();
                adminz.xtelephone1 = reader["xtelephone1"].ToString();
                adminz.xtelephone2 = reader["xtelephone2"].ToString();
                adminz.xsection = reader["xsection"].ToString();
                adminz.xlog_officer = reader["xlog_officer"].ToString();
                adminz.xreg_date = reader["xreg_date"].ToString();
                adminz.xvisible = reader["xvisible"].ToString();
            }
            reader.Close();
            connection.Close();
            return adminz;
        }

        public string getTotalEntries(string unit)
        {
            string str = "0";
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (unit != "")
            {
                cmdText = "SELECT count(*) as count FROM pwallet  where status='" + unit + "'";
            }
            else
            {
                cmdText = "SELECT count(*) as count FROM pwallet ";
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["count"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public string getTotalEntriesByDate(string unit, string xfrom, string xto)
        {
            string str = "0";
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (unit != "")
            {
                cmdText = "SELECT count(*) as count FROM pwallet  where (status='" + unit + "') AND (reg_date BETWEEN '" + xfrom + "' AND '" + xto + "') ";
            }
            else
            {
                cmdText = "SELECT count(*) as count FROM pwallet WHERE reg_date BETWEEN '" + xfrom + "' AND '" + xto + "' ";
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
              CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["count"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public string getTotalEntryCountByStage(string stage, string status)
        {
            string str = "0";
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (status == "")
            {
                cmdText = "SELECT count(*) as count FROM pwallet  where status > '" + stage + "' ";
            }
            else
            {
                cmdText = "SELECT count(*) as count FROM pwallet  where status='" + stage + "' AND data_status='" + status + "' ";
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
              CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["count"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public int getCriRegisteredMarkInfoRSCnt33(string stage, string data_status, string valueentered2, string valueentered3)
        {
            int cnt = 0;
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (data_status == "Certified")
            {
                // cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Certified') " ;

                cmdText = "select count(*)  cnt from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status = '" + stage + "' AND pwallet.data_status = 'Certified' ";

            }

            if (data_status == "Not Opposed")
            {
                // cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Certified') " ;

                cmdText = "select count(*)  cnt from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status = '" + stage + "' AND pwallet.data_status = 'Not Opposed' ";

            }

            if (data_status == "Published")
            {
                // cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Certified') " ;

                cmdText = "select count(*)  cnt from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status = '" + stage + "' AND pwallet.data_status = 'Published' ";

            }
            else if (data_status == "Deferred")
            {
                cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Deferred') ";
            }
            else if (data_status == "Registered")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status >'" + stage + "' AND pwallet.data_status='" + data_status + "' ";
            }

            else if (data_status == "Accepted")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_office  ON tm_office.pwalletID = pwallet.ID  WHERE  pwallet.status<>'33' AND tm_office.data_status ='Accepted' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND pwallet.data_status<>'New' AND CAST(pwallet.status AS INT)>=5 AND tm_office.reg_date BETWEEN( '" + valueentered2 + "' ) AND ('" + valueentered3 + "' ) ";
            }

            else if (data_status == "Registrable")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_office  ON tm_office.pwalletID = pwallet.ID  WHERE  pwallet.status<>'33' AND tm_office.data_status ='Registrable' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND pwallet.data_status<>'New' AND CAST(pwallet.status AS INT)>=4 AND tm_office.reg_date BETWEEN( '" + valueentered2 + "' ) AND ('" + valueentered3 + "' ) ";
            }

            else if (data_status == "Non-registrable")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_office  ON tm_office.pwalletID = pwallet.ID  WHERE  pwallet.status<>'33' AND tm_office.data_status ='Non-registrable' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND pwallet.data_status<>'New' AND CAST(pwallet.status AS INT)>=4 AND tm_office.reg_date BETWEEN( '" + valueentered2 + "' ) AND ('" + valueentered3 + "' ) ";
            }

            else if (data_status == "Withdraw")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_office  ON tm_office.pwalletID = pwallet.ID  WHERE  pwallet.status<>'33' AND tm_office.data_status ='Withdraw' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed'  AND pwallet.data_status<>'New' AND CAST(pwallet.status AS INT)>=5 AND tm_office.reg_date BETWEEN( '" + valueentered2 + "' ) AND ('" + valueentered3 + "' ) ";
            }

            else if (data_status == "Total")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_office  ON tm_office.pwalletID = pwallet.ID  WHERE     tm_office.reg_date BETWEEN( '" + valueentered2 + "' ) AND ('" + valueentered3 + "' ) ";
            }


            SqlCommand command = new SqlCommand(cmdText, connection);


            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                cnt = Convert.ToInt32(reader["cnt"]);

            }
            reader.Close();
            connection.Close();
            return cnt;
        }


        public int getCriRegisteredMarkInfoRSCnt34(string stage, string data_status, string valueentered2, string valueentered3)
        {
            int cnt = 0;
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (data_status == "Certified")
            {
                // cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Certified') " ;

                cmdText = "select count(*)  cnt from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status = '" + stage + "' AND pwallet.data_status = 'Certified' ";

            }

            if (data_status == "Not Opposed")
            {
                // cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Certified') " ;

                cmdText = "select count(*)  cnt from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status = '" + stage + "' AND pwallet.data_status = 'Not Opposed' ";

            }

            if (data_status == "Published")
            {
                // cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Certified') " ;

                cmdText = "select count(*)  cnt from mark_info WITH (NOLOCK)LEFT OUTER JOIN pwallet WITH(NOLOCK) ON mark_info.log_staff = pwallet.ID   LEFT OUTER JOIN tm_type WITH(NOLOCK) ON tm_type.xID = mark_info.tm_typeID  LEFT OUTER JOIN applicant WITH(NOLOCK) ON applicant.log_staff = pwallet.ID   WHERE pwallet.stage = '5' AND pwallet.status = '" + stage + "' AND pwallet.data_status = 'Published' ";

            }
            else if (data_status == "Deferred")
            {
                cmdText = "select count (*)  cnt from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' AND ( pwallet.data_status = 'Deferred') ";
            }
            else if (data_status == "Registered")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID WHERE pwallet.status >'" + stage + "' AND pwallet.data_status='" + data_status + "' ";
            }

            else if (data_status == "Accepted")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_office  ON tm_office.pwalletID = pwallet.ID  WHERE  pwallet.status<>'33' AND tm_office.data_status ='Accepted' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND pwallet.data_status<>'New' AND CAST(pwallet.status AS INT)>=4  ";
            }

            else if (data_status == "Registrable")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_office  ON tm_office.pwalletID = pwallet.ID  WHERE  pwallet.status<>'33' AND tm_office.data_status ='Registrable' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND pwallet.data_status<>'New' AND CAST(pwallet.status AS INT)>=4 ";
            }

            else if (data_status == "Non-registrable")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_office  ON tm_office.pwalletID = pwallet.ID  WHERE  pwallet.status<>'33' AND tm_office.data_status ='Non-registrable' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed' AND pwallet.data_status<>'Withdraw' AND pwallet.data_status<>'New' AND CAST(pwallet.status AS INT)>=4  ";
            }

            else if (data_status == "Withdraw")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_office  ON tm_office.pwalletID = pwallet.ID  WHERE  pwallet.status<>'33' AND tm_office.data_status ='Withdraw' AND pwallet.status<>'22' AND pwallet.data_status<>'kiv' AND pwallet.data_status<>'acc_printed'  AND pwallet.data_status<>'New' AND CAST(pwallet.status AS INT)>=4  ";
            }

            else if (data_status == "Total")
            {
                cmdText = "select count (*)  cnt  from mark_info LEFT OUTER JOIN pwallet ON mark_info.log_staff=pwallet.ID  LEFT OUTER JOIN tm_office  ON tm_office.pwalletID = pwallet.ID   ";
            }


            SqlCommand command = new SqlCommand(cmdText, connection);


            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                cnt = Convert.ToInt32(reader["cnt"]);

            }
            reader.Close();
            connection.Close();
            return cnt;
        }
        public string getTotalEntryCountStageByDate(string stage, string status, string xfrom, string xto)
        {
            string str = "0";
            string cmdText = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            if (status == "")
            {
                cmdText = "SELECT count(*) as count FROM pwallet  where (status >'" + stage + "')  AND (reg_date BETWEEN '" + xfrom + "' AND '" + xto + "' ) ";
            }
            else
            {
                cmdText = "SELECT count(*) as count FROM pwallet  where (status='" + stage + "') AND (data_status='" + status + "') AND (reg_date BETWEEN '" + xfrom + "' AND '" + xto + "' ) ";
            }
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
               CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["count"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public string getValidationIDFromMarkId(string ID)
        {
            string str = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("select validationID from pwallet where ID IN ( select log_staff from mark_info where xID='" + ID + "' ) ", connection)
            {
              CommandTimeout = 0
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                str = reader["validationID"].ToString();
            }
            reader.Close();
            connection.Close();
            return str;
        }

        public string updatePrintedPwallet(TmOffice t)
        {
            string connectionString = this.Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE pwallet SET data_status=@data_status,status=@status WHERE ID=@ID ";
            command.CommandTimeout = 0;
            connection.Open();
            command.Parameters.Add("@ID", SqlDbType.BigInt);
            command.Parameters.Add("@status", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@data_status", SqlDbType.NVarChar, 50);
            command.Parameters["@ID"].Value = Convert.ToInt64(t.pwalletID);
            command.Parameters["@status"].Value = t.admin_status;
            command.Parameters["@data_status"].Value = t.data_status;
            str2 = command.ExecuteNonQuery().ToString();
            connection.Close();
            return str2;
        }

        public class Adminz
        {
            public string xemail { get; set; }

            public string xID { get; set; }

            public string xlog_officer { get; set; }

            public string xname { get; set; }

            public string xpass { get; set; }

            public string xreg_date { get; set; }

            public string xroleID { get; set; }

            public string xsection { get; set; }

            public string xtelephone1 { get; set; }

            public string xtelephone2 { get; set; }

            public string xvisible { get; set; }
        }

        public class Contact_form
        {
            public string pwalletID { get; set; }

            public string reg_date { get; set; }

            public string response_deadline { get; set; }

            public string sent_status { get; set; }

            public string xID { get; set; }

            public string xmsg { get; set; }

            public string xofficerID { get; set; }

            public string xvisible { get; set; }
        }

        public class G_TmOffice
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

            public string rtm { get; set; }

            public string sign_type { get; set; }

            public string sup_doc1 { get; set; }

            public string sup_doc2 { get; set; }

            public string tm_typeID { get; set; }

            public string vienna_class { get; set; }

            public string xID { get; set; }

            public string xtime { get; set; }

            public string xvisible { get; set; }

            public string validationID { get; set; }

            public string data_status { get; set; }

            public string appname { get; set; }

            public string repname { get; set; }

            public string agentcode { get; set; }




        }

        public class Pwallet
        {
            public string acc_p { get; set; }

            public string amt { get; set; }

            public string applicantID { get; set; }

            public string data_status { get; set; }

            public string ID { get; set; }

            public string reg_date { get; set; }

            public long log_staff { get; set; }

            public string rtm { get; set; }

            public string stage { get; set; }

            public string status { get; set; }

            public string validationID { get; set; }

            public string visible { get; set; }

            public string xtime { get; set; }

            public string TransactionId { get; set; }
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
    }
}

