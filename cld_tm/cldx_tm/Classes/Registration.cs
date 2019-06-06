using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Brettle.Web.NeatUpload;
using System.IO;
using System.Web;
using System.Threading;
using System.Collections.Generic;
using static cld.Classes.tm;

namespace cld.Classes
{
    
    public class Registration
    {
        public string EncodeChar(string x)
        {
            string y = "";

            if ((x != null) && (x != ""))
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
        public string FormatDate(string x)
        {
            string y = x;
            if ((x != null) || (x != ""))
            {
                x = x.Trim();
                if (x.Contains("/"))
                {
                    string[] arr_side = x.Split('/');
                    for (int i = 0; i < arr_side.Length; i++)
                    {
                        if (arr_side[i].Length == 1) { arr_side[i] = arr_side[i].ToString().PadLeft(2, '0'); }
                    }
                    y = arr_side[2] + "-" + arr_side[1] + "-" + arr_side[0];
                }
                else if (x.Contains("-"))
                {
                    string[] arr_dash = x.Split('-');
                    for (int i = 0; i < arr_dash.Length; i++)
                    {
                        if (arr_dash[i].Length == 1) { arr_dash[i] = arr_dash[i].ToString().PadLeft(2, '0'); }
                    }
                    y = arr_dash[2] + "-" + arr_dash[1] + "-" + arr_dash[0];
                }
                else
                {
                    y = DateTime.Now.ToString("yyyy-MM-dd");
                }
            }
            return y;
        }

        public int addGenericTx(string serverpath, XObjs.G_Pwallet c_pwall, XObjs.G_App_info g_app_info, XObjs.G_Applicant_info g_applicant_info, XObjs.G_Tm_info g_tm_info, XObjs.Gen_Agent_info g_agent_info,
            XObjs.G_Ass_info g_ass_info, XObjs.G_Merger_info g_merger_info, XObjs.G_Cert_info g_cert_info, XObjs.G_Change_info g_change_info, XObjs.G_Renewal_info g_renewal_info,
            XObjs.G_Prelim_search_info g_prelim_search_info,XObjs.G_Other_items_info g_other_items_info, InputFile fu_logo_pic, InputFile fu_sup_doc, InputFile fu_app_doc, InputFile fu_merger_doc, 
            InputFile fu_ass_doc, InputFile fu_pub_doc, InputFile fu_cert_doc
            )
        {

            //try
            //{
                SqlConnection connection; SqlCommand command;
                int xID = 0; int pID = 0;
                int g_app_infoID = 0; int g_applicant_infoID = 0; int g_agent_infoID = 0; int g_ass_infoID = 0; int g_merger_infoID = 0;
                int g_cert_infoID = 0; int g_change_infoID = 0; int g_renewal_infoID = 0; int g_prelim_search_infoID = 0; int g_other_items_infoID = 0;
                int g_applicant_info_updateID = 0; int h = 0;
                string xlogo_pic = ""; string xsup_doc = ""; string xapp_doc = ""; string xmerger_doc = ""; string xass_doc = ""; string xpub_doc = ""; string xcert_doc = ""; 
                string doc_path = "";
                string connectionString = Connect();
                c_pwall.reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd"); //c_pwall.xtime = c_pwall.log_officer + ": " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                c_pwall.visible = "1";  c_pwall.stage = "5";
         //   c_pwall.status = "1";
            c_pwall.status = "2";
           // c_pwall.data_status = "Fresh";
            c_pwall.data_status = "New";

            if ((c_pwall.validationID != null) && (c_pwall.validationID != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO g_pwallet (twalletID,validationID,applicantID,log_officer,amt,stage,status,data_status,reg_date,visible  ) ";
                            command.CommandText += " VALUES ( ";
                            command.CommandText += " '" + c_pwall.twalletID + "','" + c_pwall.validationID + "','" + c_pwall.applicantID + "','" + c_pwall.log_officer + "', ";
                            command.CommandText += " '" + c_pwall.amt + "','" + c_pwall.stage + "','" + c_pwall.status + "','" + c_pwall.data_status + "','" + c_pwall.reg_date + "','" + c_pwall.visible + "' ";
                            command.CommandText += " ) ";
                            command.CommandText += " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            pID = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
                if (Convert.ToInt32(pID) > 0)
                {
                    g_app_info.log_staff = pID.ToString(); g_applicant_info.log_staff = pID.ToString(); g_tm_info.log_staff = pID.ToString(); g_agent_info.log_staff = pID.ToString();
                    g_ass_info.log_staff = pID.ToString(); g_merger_info.log_staff = pID.ToString(); g_cert_info.log_staff = pID.ToString(); g_change_info.log_staff = pID.ToString();
                    g_renewal_info.log_staff = pID.ToString(); g_prelim_search_info.log_staff = pID.ToString(); g_other_items_info.log_staff = pID.ToString();
                }
                //////////////////////////////////////////////////////////////////////////////////
                if ((g_applicant_info.xname != null) && (g_applicant_info.xname != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO g_applicant_info (xname,address,xemail,xmobile,nationality,trading_as,log_staff,visible) ";
                            command.CommandText += " VALUES ( ";
                            command.CommandText += " '" + g_applicant_info.xname + "','" + g_applicant_info.address + "','" + g_applicant_info.xemail + "','" + g_applicant_info.xmobile + "', ";
                            command.CommandText += " '" + g_applicant_info.nationality + "','" + g_applicant_info.trading_as + "','" + g_applicant_info.log_staff + "','" + c_pwall.visible + "' ";
                            command.CommandText += " ) ";
                            command.CommandText += " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            g_applicant_infoID = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////
                if ((g_tm_info.tm_title != null) && (g_tm_info.tm_title != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO g_tm_info (reg_number,xtype,tm_title,tm_class,tm_desc,logo_descID,disclaimer,logo_pic,auth_doc,sup_doc1,app_letter_doc,log_staff,reg_date,visible ) ";
                            command.CommandText += " VALUES ( ";
                            command.CommandText += " '" + g_tm_info.reg_number + "','" + g_tm_info.xtype + "','" + g_tm_info.tm_title + "','" + g_tm_info.tm_class + "','" + g_tm_info.tm_desc + "', ";
                            command.CommandText += " '" + g_tm_info.logo_descID + "','" + g_tm_info.disclaimer + "','" + g_tm_info.logo_pic + "','" + g_tm_info.auth_doc + "','" + g_tm_info.sup_doc1 + "', ";
                            command.CommandText += " '" + g_tm_info.app_letter_doc + "','" + g_tm_info.log_staff + "','" + c_pwall.reg_date + "','" + c_pwall.visible + "' ";
                            command.CommandText += " ) ";
                            command.CommandText += " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            xID = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                    doc_path = serverpath + "admin/tm/gf/docz/" + xID + "/"; string reg_number = "";
                    if (g_tm_info.xtype == "LOCAL") { reg_number = "NG/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID; }
                    else { reg_number = "F/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID; }
                    //////////////////////////////////////////////////////////////////////////////////
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "UPDATE g_tm_info SET reg_number='" + reg_number + "'  WHERE xID='" + xID + "'  ";
                            command.Connection.Open();
                            g_applicant_info_updateID = command.ExecuteNonQuery();
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////
                if ((g_app_info.item_code != null) && (g_app_info.item_code != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO g_app_info (rtm_number,application_no,item_code,filing_date,reg_no,log_staff,reg_date,visible ) ";
                            command.CommandText += " VALUES ( ";
                            command.CommandText += " '" + g_app_info.rtm_number + "','" + g_app_info.application_no + "','" + g_app_info.item_code + "','" + g_app_info.filing_date + "', ";
                            command.CommandText += " '" + g_app_info.reg_no + "','" + g_app_info.log_staff + "','" + c_pwall.reg_date + "','" + c_pwall.visible + "'  ";
                            command.CommandText += " ) ";
                            command.CommandText += " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            g_app_infoID = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                    string reg_no = string.Concat(new object[] { "TM/GF/", g_app_info.item_code, "/", DateTime.Now.ToString("yyyy"), "/", xID });
                    //////////////////////////////////////////////////////////////////////////////////
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "UPDATE g_app_info SET reg_no='" + reg_no + "'  WHERE ID='" + g_app_infoID + "'  ";
                            command.Connection.Open();
                            g_applicant_info_updateID = command.ExecuteNonQuery();
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////
                if ((g_agent_info.code != null) && (g_agent_info.code != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO g_agent_info (code,xname,xpassword,nationality,country,state,address,telephone,email,log_staff,xsync )";
                            command.CommandText += " VALUES ( ";
                            command.CommandText += " '" + g_agent_info.code + "','" + g_agent_info.xname + "','" + g_agent_info.xpassword + "','" + g_agent_info.nationality + "', ";
                            command.CommandText += " '" + g_agent_info.country + "','" + g_agent_info.state + "','" + g_agent_info.address + "','" + g_agent_info.telephone + "','" + g_agent_info.email + "', ";
                            command.CommandText += " '" + g_agent_info.log_staff + "','" + g_agent_info.xsync + "' ";
                            command.CommandText += " ) ";
                            command.CommandText += " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            g_agent_infoID = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////
                if ((g_ass_info.assignee_name != null) && (g_ass_info.assignee_name != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO g_ass_info (date_of_assignment,assignee_name,assignee_address,assignee_nationality,assignor_name,assignor_address,assignor_nationality,ass_doc,log_staff,xvisible ) ";
                            command.CommandText += " VALUES ( ";
                            command.CommandText += " '" + g_ass_info.date_of_assignment + "','" + g_ass_info.assignee_name + "','" + g_ass_info.assignee_address + "','" + g_ass_info.assignee_nationality + "', ";
                            command.CommandText += " '" + g_ass_info.assignor_name + "','" + g_ass_info.assignor_address + "','" + g_ass_info.assignor_nationality + "','" + g_ass_info.ass_doc + "', ";
                            command.CommandText += " '" + g_ass_info.log_staff + "','" + c_pwall.visible + "' ";
                            command.CommandText += " ) ";
                            command.CommandText += " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            g_ass_infoID = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////
                if ((g_cert_info.pub_details != null) && (g_cert_info.pub_details != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO g_cert_info (pub_date,pub_details,cert_doc,pub_doc,log_staff,reg_date,xvisible) ";
                            command.CommandText += " VALUES ( ";
                            command.CommandText += " '" + g_cert_info.pub_date + "','" + g_cert_info.pub_details + "','" + g_cert_info.cert_doc + "','" + g_cert_info.pub_doc + "', ";
                            command.CommandText += " '" + g_cert_info.log_staff + "','" + c_pwall.reg_date + "','" + c_pwall.visible + "' ";
                            command.CommandText += " ) ";
                            command.CommandText += " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            g_cert_infoID = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////
                if ((g_change_info.old_name != null) && (g_change_info.old_name != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO g_change_info (old_name,old_address,new_name,new_address,log_staff,reg_date,visible ) ";
                            command.CommandText += " VALUES ( ";
                            command.CommandText += " '" + g_change_info.old_name + "','" + g_change_info.old_address + "','" + g_change_info.new_name + "','" + g_change_info.new_address + "', ";
                            command.CommandText += " '" + g_change_info.log_staff + "','" + c_pwall.reg_date + "','" + c_pwall.visible + "' ";
                            command.CommandText += " ) ";
                            command.CommandText += " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            g_change_infoID = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////
                if ((g_merger_info.original_name != null) && (g_merger_info.original_name != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO g_merger_info (original_name,original_address,merging_name,merging_address,merged_coy_name,merger_date,merger_doc,log_staff,visible) ";
                            command.CommandText += " VALUES ( ";
                            command.CommandText += " '" + g_merger_info.original_name + "','" + g_merger_info.original_address + "','" + g_merger_info.merging_name + "','" + g_merger_info.merging_address + "', ";
                            command.CommandText += " '" + g_merger_info.merged_coy_name + "','" + g_merger_info.merger_date + "','" + g_merger_info.merger_doc + "','" + g_merger_info.log_staff + "','" + c_pwall.visible + "' ";
                            command.CommandText += " ) ";
                            command.CommandText += " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            g_merger_infoID = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////
                if ((g_other_items_info.req_details != null) && (g_other_items_info.req_details != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO g_other_items_info (req_details,reg_date,log_staff,visible) ";
                            command.CommandText += " VALUES ( ";
                            command.CommandText += " '" + g_other_items_info.req_details + "','" + c_pwall.reg_date + "','" + g_other_items_info.log_staff + "','" + c_pwall.visible + "' ";
                            command.CommandText += " ) ";
                            command.CommandText += " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            g_other_items_infoID = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////
                if ((g_prelim_search_info.xtitle != null) && (g_prelim_search_info.xtitle != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO g_prelim_search_info (xtitle,xclass,xclass_desc,reg_date,log_staff,visible)";
                            command.CommandText += " VALUES ( ";
                            command.CommandText += " '" + g_prelim_search_info.xtitle + "','" + g_prelim_search_info.xclass + "',";
                            command.CommandText += " '" + g_prelim_search_info.xclass_desc + "','" + c_pwall.reg_date + "','" + g_prelim_search_info.log_staff + "','" + c_pwall.visible + "' ";
                            command.CommandText += " ) ";
                            command.CommandText += " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            g_prelim_search_infoID = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////
                if ((g_renewal_info.prev_renewal_date != null) && (g_renewal_info.prev_renewal_date != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO g_renewal_info (prev_renewal_date,renewal_type,reg_date,log_staff,visible) ";
                            command.CommandText += " VALUES ( ";
                            command.CommandText += " '" + g_renewal_info.prev_renewal_date + "','" + g_renewal_info.renewal_type + "', ";
                            command.CommandText += " '" + c_pwall.reg_date + "','" + g_renewal_info.log_staff + "','" + c_pwall.visible + "' ";
                            command.CommandText += " ) ";
                            command.CommandText += " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            g_renewal_infoID = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
                if (!doc_path.EndsWith("/")) { doc_path = doc_path + "/"; }

                if (!Directory.Exists(doc_path + "/")) { Directory.CreateDirectory(doc_path + "/"); }
                if (fu_logo_pic.HasFile)
                {
                    xlogo_pic = Path.Combine(doc_path, fu_logo_pic.FileName.Replace(" ", "_"));
                    fu_logo_pic.MoveTo(xlogo_pic, MoveToOptions.Overwrite);
                    xlogo_pic = xlogo_pic.Replace(serverpath + "admin/tm/gf/", "");
                }
                if (fu_app_doc.HasFile)
                {
                    xapp_doc = Path.Combine(doc_path, fu_app_doc.FileName.Replace(" ", "_"));
                    fu_app_doc.MoveTo(xapp_doc, MoveToOptions.Overwrite);
                    xapp_doc = xapp_doc.Replace(serverpath + "admin/tm/gf/", "");
                }
                if (fu_sup_doc.HasFile)
                {
                    xsup_doc = Path.Combine(doc_path, fu_sup_doc.FileName.Replace(" ", "_"));
                    fu_sup_doc.MoveTo(xsup_doc, MoveToOptions.Overwrite);
                    xsup_doc = xsup_doc.Replace(serverpath + "admin/tm/gf/", "");
                }

                if (fu_merger_doc.HasFile)
                {
                    xmerger_doc = Path.Combine(doc_path, fu_merger_doc.FileName.Replace(" ", "_"));
                    fu_merger_doc.MoveTo(xmerger_doc, MoveToOptions.Overwrite);
                    xmerger_doc = xmerger_doc.Replace(serverpath + "admin/tm/gf/", "");
                }
                if (fu_ass_doc.HasFile)
                {
                    xass_doc = Path.Combine(doc_path, fu_ass_doc.FileName.Replace(" ", "_"));
                    fu_ass_doc.MoveTo(xass_doc, MoveToOptions.Overwrite);
                    xass_doc = xass_doc.Replace(serverpath + "admin/tm/gf/", "");
                }
                if (fu_pub_doc.HasFile)
                {
                    xpub_doc = Path.Combine(doc_path, fu_pub_doc.FileName.Replace(" ", "_"));
                    fu_pub_doc.MoveTo(xpub_doc, MoveToOptions.Overwrite);
                    xpub_doc = xpub_doc.Replace(serverpath + "admin/tm/gf/", "");
                }
                if (fu_cert_doc.HasFile)
                {
                    xcert_doc = Path.Combine(doc_path, fu_cert_doc.FileName.Replace(" ", "_"));
                    fu_cert_doc.MoveTo(xcert_doc, MoveToOptions.Overwrite);
                    xcert_doc = xcert_doc.Replace(serverpath + "admin/tm/gf/", "");
                }

                //////////////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////////////
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE g_tm_info SET logo_pic='" + xlogo_pic + "',sup_doc1='" + xsup_doc + "',app_letter_doc='" + xapp_doc + "' WHERE log_staff='" + pID + "'  ";
                        command.Connection.Open();
                        h += Convert.ToInt32(command.ExecuteNonQuery());
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////
                if (g_cert_infoID > 0)
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "UPDATE g_cert_info SET cert_doc='" + xcert_doc + "',pub_doc='" + xpub_doc + "'WHERE xID='" + g_cert_infoID + "' ";
                            command.Connection.Open();
                            h += Convert.ToInt32(command.ExecuteNonQuery());
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////
                if (g_merger_infoID > 0)
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "UPDATE g_merger_info SET merger_doc='" + xmerger_doc + "' WHERE ID='" + g_merger_infoID + "'  ";
                            command.Connection.Open();
                            h += Convert.ToInt32(command.ExecuteNonQuery());
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////
                if (g_ass_infoID > 0)
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "UPDATE g_ass_info SET ass_doc='" + xass_doc + "' WHERE xID='" + g_ass_infoID + "'  ";
                            command.Connection.Open();
                            h += Convert.ToInt32(command.ExecuteNonQuery());
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////           
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE g_ass_info SET ass_doc='" + xass_doc + "' WHERE xID='" + g_ass_infoID + "'  ";
                        command.Connection.Open();
                        h += Convert.ToInt32(command.ExecuteNonQuery());
                    }
                }

                return xID;
           // }
            //catch (Exception ee)
            //{
            //    XWriters pp = new XWriters();
            //    string message = c_pwall.validationID + " " + DateTime.Now;

            //    string vpath =System.Web.HttpContext.Current.Server.MapPath("~/")+"TradeMarkLog/Generic/" + c_pwall.validationID + ".txt";

            //    pp.WriteToFile(message, vpath);

                
            //    return 0;


           // }
        }
       
        public int addG_App_info(XObjs.G_App_info x)
        {
            string connectionString = this.Connect();
            int num = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO g_app_info (rtm_number,application_no,item_code,filing_date,reg_no,log_staff,reg_date,visible) ";
            command.CommandText = command.CommandText + "VALUES (@rtm_number,@application_no,@item_code,@filing_date,@reg_no,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@rtm_number", SqlDbType.NVarChar);
            command.Parameters.Add("@application_no", SqlDbType.NVarChar);
            command.Parameters.Add("@item_code", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@filing_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_no", SqlDbType.NVarChar);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@rtm_number"].Value = x.rtm_number;
            command.Parameters["@application_no"].Value = x.application_no;
            command.Parameters["@item_code"].Value = x.item_code;
            command.Parameters["@filing_date"].Value = x.filing_date;
            command.Parameters["@reg_no"].Value = x.reg_no;
            command.Parameters["@log_staff"].Value = x.log_staff;
            command.Parameters["@reg_date"].Value = x.reg_date;
            command.Parameters["@visible"].Value = x.visible;
            num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }
        public int addG_Tm_info(XObjs.G_Tm_info x)
        {
            string connectionString = this.Connect();
            int num = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO g_tm_info (reg_number,xtype,tm_title,tm_class,tm_desc,logo_descID,disclaimer,logo_pic,auth_doc,sup_doc1,app_letter_doc,log_staff,reg_date,visible )";
            command.CommandText = command.CommandText + "VALUES (@reg_number,@xtype,@tm_title,@tm_class,@tm_desc,@logo_descID,@disclaimer,@logo_pic,@auth_doc,@sup_doc1,@app_letter_doc,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@reg_number", SqlDbType.NVarChar);
            command.Parameters.Add("@xtype", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@tm_title", SqlDbType.NVarChar);
            command.Parameters.Add("@tm_class", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@tm_desc", SqlDbType.Text);
            command.Parameters.Add("@logo_descID", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@disclaimer", SqlDbType.Text);
            command.Parameters.Add("@logo_pic", SqlDbType.Text);
            command.Parameters.Add("@auth_doc", SqlDbType.Text);
            command.Parameters.Add("@sup_doc1", SqlDbType.Text);
            command.Parameters.Add("@app_letter_doc", SqlDbType.Text);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@reg_number"].Value = x.reg_number;
            command.Parameters["@xtype"].Value = x.xtype;
            command.Parameters["@tm_title"].Value = x.tm_title;
            command.Parameters["@tm_class"].Value = x.tm_class;
            command.Parameters["@tm_desc"].Value = x.tm_desc;
            command.Parameters["@logo_descID"].Value = x.logo_descID;
            command.Parameters["@disclaimer"].Value = x.disclaimer;
            command.Parameters["@logo_pic"].Value = x.logo_pic;
            command.Parameters["@auth_doc"].Value = x.auth_doc;
            command.Parameters["@sup_doc1"].Value = x.sup_doc1;
            command.Parameters["@app_letter_doc"].Value = x.app_letter_doc;
            command.Parameters["@log_staff"].Value = x.log_staff;
            command.Parameters["@reg_date"].Value = x.reg_date;
            command.Parameters["@visible"].Value = x.visible;
            num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }
        public int addGen_Agent_info(XObjs.Gen_Agent_info x)
        {
            string connectionString = this.Connect();
            int num = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO g_agent_info (code,xname,xpassword,nationality,country,state,address,telephone,email,log_staff,xsync )";
            command.CommandText = command.CommandText + "VALUES (@code,@xname,@xpassword,@nationality,@country,@state,@address,@telephone,@email,@log_staff,@xsync) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@code", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@xpassword", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@country", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@state", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@address", SqlDbType.Text);
            command.Parameters.Add("@telephone", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@email", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@xsync", SqlDbType.NVarChar, 10);
            command.Parameters["@code"].Value = x.code;
            command.Parameters["@xname"].Value = x.xname;
            command.Parameters["@xpassword"].Value = x.xpassword;
            command.Parameters["@nationality"].Value = x.nationality;
            command.Parameters["@country"].Value = x.country;
            command.Parameters["@state"].Value = x.state;
            command.Parameters["@address"].Value = x.address;
            command.Parameters["@telephone"].Value = x.telephone;
            command.Parameters["@email"].Value = x.email;
            command.Parameters["@log_staff"].Value = x.log_staff;
            command.Parameters["@xsync"].Value = x.xsync;
            num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }
        public int addG_Applicant_info(XObjs.G_Applicant_info x)
        {
            string connectionString = this.Connect();
            int num = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO g_applicant_info (xname,address,xemail,xmobile,nationality,trading_as,log_staff,visible) ";
            command.CommandText = command.CommandText + "VALUES (@xname,@address,@xemail,@xmobile,@nationality,@trading_as,@log_staff,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@xname", SqlDbType.NVarChar);
            command.Parameters.Add("@address", SqlDbType.Text);
            command.Parameters.Add("@xemail", SqlDbType.NVarChar);
            command.Parameters.Add("@xmobile", SqlDbType.NVarChar);
            command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@trading_as", SqlDbType.Text);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 10);
            command.Parameters["@xname"].Value = x.xname;
            command.Parameters["@address"].Value = x.address;
            command.Parameters["@xemail"].Value = x.xemail;
            command.Parameters["@xmobile"].Value = x.xmobile;
            command.Parameters["@nationality"].Value = x.nationality;
            command.Parameters["@trading_as"].Value = x.trading_as;
            command.Parameters["@log_staff"].Value = x.log_staff;
            command.Parameters["@visible"].Value = x.visible;
            num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }
        public int addG_Ass_info(XObjs.G_Ass_info x)
        {
            string connectionString = this.Connect();
            int num = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO g_ass_info (date_of_assignment,assignee_name,assignee_address,assignee_nationality,assignor_name,assignor_address,assignor_nationality,ass_doc,log_staff,xvisible )";
            command.CommandText = command.CommandText + "VALUES (@date_of_assignment,@assignee_name,@assignee_address,@assignee_nationality,@assignor_name,@assignor_address,@assignor_nationality,@ass_doc,@log_staff,@xvisible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@date_of_assignment", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@assignee_name", SqlDbType.NVarChar);
            command.Parameters.Add("@assignee_address", SqlDbType.Text);
            command.Parameters.Add("@assignee_nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@assignor_name", SqlDbType.NVarChar);
            command.Parameters.Add("@assignor_address", SqlDbType.Text);
            command.Parameters.Add("@assignor_nationality", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@ass_doc", SqlDbType.Text);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@xvisible", SqlDbType.NVarChar, 10);
            command.Parameters["@date_of_assignment"].Value = x.date_of_assignment;
            command.Parameters["@assignee_name"].Value = x.assignee_name;
            command.Parameters["@assignee_address"].Value = x.assignee_address;
            command.Parameters["@assignee_nationality"].Value = x.assignee_nationality;
            command.Parameters["@assignor_name"].Value = x.assignor_name;
            command.Parameters["@assignor_address"].Value = x.assignor_address;
            command.Parameters["@assignor_nationality"].Value = x.assignor_nationality;
            command.Parameters["@ass_doc"].Value = x.ass_doc;
            command.Parameters["@log_staff"].Value = x.log_staff;
            command.Parameters["@xvisible"].Value = x.xvisible;
            num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }
        public int addG_Cert_info(XObjs.G_Cert_info x)
        {
            string connectionString = this.Connect();
            int num = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO g_cert_info (pub_date,pub_details,cert_doc,pub_doc,log_staff,reg_date,xvisible) ";
            command.CommandText = command.CommandText + "VALUES (@pub_date,@pub_details,@cert_doc,@pub_doc,@log_staff,@reg_date,@xvisible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@pub_date", SqlDbType.NVarChar);
            command.Parameters.Add("@pub_details", SqlDbType.Text);
            command.Parameters.Add("@cert_doc", SqlDbType.Text);
            command.Parameters.Add("@pub_doc", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@xvisible", SqlDbType.NVarChar, 1);
            command.Parameters["@pub_date"].Value = x.pub_date;
            command.Parameters["@pub_details"].Value = x.pub_details;
            command.Parameters["@cert_doc"].Value = x.cert_doc;
            command.Parameters["@pub_doc"].Value = x.pub_doc;
            command.Parameters["@log_staff"].Value = x.log_staff;
            command.Parameters["@reg_date"].Value = x.reg_date;
            command.Parameters["@xvisible"].Value = x.xvisible;
            num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }
        public int addG_Change_info(XObjs.G_Change_info x)
        {
            string connectionString = this.Connect();
            int num = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO g_change_info (old_name,old_address,new_name,new_address,log_staff,reg_date,visible )";
            command.CommandText = command.CommandText + "VALUES (@old_name,@old_address,@new_name,@new_address,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@old_name", SqlDbType.NVarChar);
            command.Parameters.Add("@old_address", SqlDbType.Text);
            command.Parameters.Add("@new_name", SqlDbType.NVarChar);
            command.Parameters.Add("@new_address", SqlDbType.Text);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@old_name"].Value = x.old_name;
            command.Parameters["@old_address"].Value = x.old_address;
            command.Parameters["@new_name"].Value = x.new_name;
            command.Parameters["@new_address"].Value = x.new_address;
            command.Parameters["@log_staff"].Value = x.log_staff;
            command.Parameters["@reg_date"].Value = x.reg_date;
            command.Parameters["@visible"].Value = x.visible;
            num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }
        public int addG_Merger_info(XObjs.G_Merger_info x)
        {
            string connectionString = this.Connect();
            int num = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO g_merger_info (original_name,original_address,merging_name,merging_address,merged_coy_name,merger_date,merger_doc,log_staff,visible) ";
            command.CommandText = command.CommandText + "VALUES (@original_name,@original_address,@merging_name,@merging_address,@merged_coy_name,@merger_date,@merger_doc,@log_staff,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@original_name", SqlDbType.NVarChar);
            command.Parameters.Add("@original_address", SqlDbType.Text);
            command.Parameters.Add("@merging_name", SqlDbType.NVarChar);
            command.Parameters.Add("@merging_address", SqlDbType.Text);
            command.Parameters.Add("@merged_coy_name", SqlDbType.NVarChar);
            command.Parameters.Add("@merger_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@merger_doc", SqlDbType.Text);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 10);
            command.Parameters["@original_name"].Value = x.original_name;
            command.Parameters["@original_address"].Value = x.original_address;
            command.Parameters["@merging_name"].Value = x.merging_name;
            command.Parameters["@merging_address"].Value = x.merging_address;
            command.Parameters["@merged_coy_name"].Value = x.merged_coy_name;
            command.Parameters["@merger_date"].Value = x.merger_date;
            command.Parameters["@merger_doc"].Value = x.merger_doc;
            command.Parameters["@log_staff"].Value = x.log_staff;
            command.Parameters["@visible"].Value = x.visible;
            num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }
        public int addG_Other_items_info(XObjs.G_Other_items_info x)
        {
            string connectionString = this.Connect();
            int num = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO g_other_items_info (req_details,reg_date,log_staff,visible) ";
            command.CommandText = command.CommandText + "VALUES (@req_details,@reg_date,@log_staff,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@req_details", SqlDbType.Text);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@req_details"].Value = x.req_details;
            command.Parameters["@log_staff"].Value = x.log_staff;
            command.Parameters["@reg_date"].Value = x.reg_date;
            command.Parameters["@visible"].Value = x.visible;
            num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }
        public int addG_Prelim_search_info(XObjs.G_Prelim_search_info x)
        {
            string connectionString = this.Connect();
            int num = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO g_prelim_search_info (xtitle,xclass,xclass_desc,reg_date,log_staff,visible) ";
            command.CommandText = command.CommandText + "VALUES (@xtitle,@xclass,@xclass_desc,@reg_date,@log_staff,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@xtitle", SqlDbType.NVarChar);
            command.Parameters.Add("@xclass", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@xclass_desc", SqlDbType.Text);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@xtitle"].Value = x.xtitle;
            command.Parameters["@xclass"].Value = x.xclass;
            command.Parameters["@xclass_desc"].Value = x.xclass_desc;
            command.Parameters["@log_staff"].Value = x.log_staff;
            command.Parameters["@reg_date"].Value = x.reg_date;
            command.Parameters["@visible"].Value = x.visible;
            num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }
        public int addG_Renewal_info(XObjs.G_Renewal_info x)
        {
            string connectionString = this.Connect();
            int num = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO g_renewal_info (prev_renewal_date,renewal_type,reg_date,log_staff,visible) ";
            command.CommandText = command.CommandText + "VALUES (@prev_renewal_date,@renewal_type,@reg_date,@log_staff,@visible) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@prev_renewal_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@renewal_type", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
            command.Parameters["@prev_renewal_date"].Value = x.prev_renewal_date;
            command.Parameters["@renewal_type"].Value = x.renewal_type;
            command.Parameters["@log_staff"].Value = x.log_staff;
            command.Parameters["@reg_date"].Value = x.reg_date;
            command.Parameters["@visible"].Value = x.visible;
            num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }

        public int addxtest(string xx)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("INSERT INTO xtest (xdesc) VALUES ('" + xx  + "') ", connection);
            connection.Open();
            int num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }

        public int addHwallet(XObjs.Hwallet x)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("INSERT INTO hwallet (transID,fee_detailsID,used_status,xreg_date,used_date,product_title) VALUES ('" + x.transID + "','" + x.fee_detailsID + "','" + x.used_status + "','" + x.xreg_date + "','" + x.used_date + "','" + x.product_title + "') SELECT SCOPE_IDENTITY()", connection);
            connection.Open();
            int num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }

        public int addImpXpayAgent(XObjs.G_Agent_info x)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("INSERT INTO G_Agent_info (addressID,sys_ID,xname,cname,xpassword,nationality,xreg_date,xvisible,xsync) VALUES ('" + x.addressID + "','" + x.sys_ID + "','" + x.xname + "','" + x.cname + "','" + x.xpassword + "','" + x.nationality + "','" + x.xreg_date + "','" + x.xvisible + "','" + x.xsync + "') SELECT SCOPE_IDENTITY()", connection);
            connection.Open();
            int num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }

        public int addPwallet(XObjs.Pwallet x)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("INSERT INTO pwallet (xemail,xmobile,xmemberID,xmembertype,xpass,reg_date) VALUES ('" + x.xemail + "','" + x.xmobile + "','" + x.xmemberID + "','" + x.xmembertype + "','" + x.xpass + "','" + x.reg_date + "') SELECT SCOPE_IDENTITY()", connection);
            connection.Open();
            int num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }

        public int addTwallet(XObjs.Twallet x)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("INSERT INTO twallet (transID,xmemberID,xpay_status,xgt,ref_no,xbankerID,xreg_date,xvisible,xsync) VALUES ('" + x.transID + "','" + x.xmemberID + "','" + x.xpay_status + "','" + x.xgt + "','" + x.ref_no + "','" + x.xbankerID + "','" + x.xreg_date + "','" + x.xvisible + "','" + x.xsync + "') SELECT SCOPE_IDENTITY()", connection);
            connection.Open();
            int num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }

        public int addXpayAddress(XObjs.Address x)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("INSERT INTO address (countryID,stateID,lgaID,city,street,zip,telephone1,telephone2,email1,email2,log_staff,reg_date,visible,xsync) VALUES ('" + x.countryID + "','" + x.stateID + "','" + x.lgaID + "','" + x.city + "','" + x.street + "','" + x.zip + "','" + x.telephone1 + "','" + x.telephone2 + "','" + x.email1 + "','" + x.email2 + "','" + x.log_staff + "','" + x.reg_date + "','" + x.visible + "','" + x.xsync + "') SELECT SCOPE_IDENTITY()", connection);
            connection.Open();
            int num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }

        public int addXpayAgent(XObjs.G_Agent_info x)
        {
            string str = "0";
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("INSERT INTO G_Agent_info (addressID,sys_ID,xname,cname,xpassword,nationality,xreg_date,xvisible,xsync) VALUES ('" + x.addressID + "','" + x.sys_ID + "','" + x.xname + "','" + x.cname + "','" + x.xpassword + "','" + x.nationality + "','" + x.xreg_date + "','" + x.xvisible + "','" + x.xsync + "') SELECT SCOPE_IDENTITY()", connection);
            connection.Open();
            int num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            if (num > 0)
            {
                str = "CLD/RA/" + num.ToString().PadLeft(5, '0');
                this.updateXpayAgent(num.ToString(), str);
            }
            return num;
        }

        public int addXpayBanker(XObjs.XBanker x)
        {
            string str = "0";
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("INSERT INTO xbanker (bankname,xposition,addressID,sys_ID,xname,xpassword,nationality,xreg_date,xvisible,xsync) VALUES ('" + x.bankname + "','" + x.xposition + "','" + x.addressID + "','" + x.sys_ID + "','" + x.xname + "','" + x.xpassword + "','" + x.nationality + "','" + x.xreg_date + "','" + x.xvisible + "','" + x.xsync + "') SELECT SCOPE_IDENTITY()", connection);
            connection.Open();
            int num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            if (num > 0)
            {
                str = "CLD/RB/" + num.ToString().PadLeft(5, '0');
                this.updateXpayBanker(num.ToString(), str);
            }
            return num;
        }

        public int addXpayMember(XObjs.XMember x)
        {
            string str = "0";
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("INSERT INTO xmember (addressID,sys_ID,xname,cname,xpassword,nationality,xreg_date,xvisible,xsync) VALUES ('" + x.addressID + "','" + x.sys_ID + "','" + x.xname + "','" + x.cname + "','" + x.xpassword + "','" + x.nationality + "','" + x.xreg_date + "','" + x.xvisible + "','" + x.xsync + "') SELECT SCOPE_IDENTITY()", connection);
            connection.Open();
            int num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            if (num > 0)
            {
                str = "CLD/RC/" + num.ToString().PadLeft(5, '0');
                this.updateXpayMember(num.ToString(), str);
            }
            return num;
        }

        public int addRegistration(XObjs.Registration x)
        {
            string command_text = "";
            string connectionString = this.ConnectXhome();
            SqlConnection connection = new SqlConnection(connectionString);
            command_text += "INSERT INTO registrations ( ";
            command_text += " AccrediationType,Sys_ID,Firstname,Surname,Email,xpassword,DateOfBrith, ";
            command_text += " IncorporatedDate,Nationality,PhoneNumber,CompanyName,CompanyAddress,ContactPerson,ContactPersonPhone, ";
            command_text += " CompanyWebsite,Certificate,Introduction,Principal,xreg_date,xstatus,xvisible, ";
            command_text += " xsync,logo";
            command_text += " ) ";

            command_text += " VALUES (" ;
            command_text += " '" + x.AccrediationType + "','" + x.Sys_ID + "','" + x.Firstname + "','" + x.Surname + "','" + x.Email + "','" + x.xpassword + "','" + x.DateOfBrith + "', ";
            command_text += "'" + x.IncorporatedDate + "','" + x.Nationality + "','" + x.PhoneNumber + "','" + x.CompanyName + "','" + x.CompanyAddress + "','" + x.ContactPerson + "','" + x.ContactPersonPhone + "', ";
            command_text += "'" + x.CompanyWebsite + "','" + x.Certificate + "','" + x.Introduction + "','" + x.Principal + "','" + x.xreg_date + "','" + x.xstatus + "','" + x.xvisible + "', ";
            command_text += " '" + x.xsync + "','" + x.logo + "' ";          
            command_text += " ) SELECT SCOPE_IDENTITY() ";

            SqlCommand command = new SqlCommand(command_text, connection);
            connection.Open();
            int succ = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return succ;
        }
        public int updateRegistration(XObjs.Registration x)
        {
            string command_text = "";
            command_text += "UPDATE registrations SET Firstname='" + EncodeChar(x.Firstname) + "',Surname='" + EncodeChar(x.Surname) + "' ,Email='" + EncodeChar(x.Email) + "', ";
            command_text += " xpassword='" + EncodeChar(x.xpassword) + "',DateOfBrith='" + FormatDate(x.DateOfBrith) + "' ,IncorporatedDate='" + FormatDate(x.IncorporatedDate) + "',PhoneNumber='" + x.PhoneNumber + "', Sys_ID='" + x.Sys_ID + "', ";
            command_text += " CompanyName='" + EncodeChar(x.CompanyName) + "',CompanyAddress='" + EncodeChar(x.CompanyAddress) + "' ,ContactPerson='" + EncodeChar(x.ContactPerson) + "',ContactPersonPhone='" + x.ContactPersonPhone + "',  ";
            command_text += " CompanyWebsite='" + EncodeChar(x.CompanyWebsite) + "', xreg_date='" + x.xreg_date + "'  ";
            command_text += " WHERE xid='" + x.xid + "'";

            string connectionString = this.ConnectXhome();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(command_text, connection);
            connection.Open();
            int succ = command.ExecuteNonQuery();
            connection.Close();
            return succ;
        }

        public int updateSubAgent(XObjs.Subagent x)
        {
            string command_text = "";
            command_text += "UPDATE subagents SET Firstname='" + EncodeChar(x.Firstname) + "',Surname='" + EncodeChar(x.Surname) + "' ,Email='" + EncodeChar(x.Email) + "', ";
            command_text += " xpassword='" + EncodeChar(x.xpassword) + "',DateOfBrith='" + FormatDate(x.DateOfBrith) + "' ,Sys_ID='" + x.Sys_ID + "',Telephone='" + x.Telephone + "', xreg_date='" + x.xreg_date + "' ";
            command_text += " WHERE xid='" + x.xid + "'";

            string connectionString = this.ConnectXhome();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(command_text, connection);
            connection.Open();
            int succ = command.ExecuteNonQuery();
            connection.Close();
            return succ;
        }

        public string Connect()
        {
            return ConfigurationManager.ConnectionStrings["cldConnectionString"].ConnectionString;
        }

        public string ConnectXpay()
        {
            return ConfigurationManager.ConnectionStrings["xpayConnectionString"].ConnectionString;
        }
        public string ConnectXhome()
        {
            return ConfigurationManager.ConnectionStrings["homeConnectionString"].ConnectionString;
        } 

        public int deleteFee_detailsByID(string xid)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("DELETE FROM Fee_details  WHERE xid='" + xid + "'  ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int deleteHwallet(string xid)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("DELETE FROM hwallet  WHERE xid='" + xid + "'  ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_G_Pwallet(XObjs.G_Pwallet x)
        {
            
            SqlConnection connection = new SqlConnection(this.Connect());
            string str3 = "UPDATE g_app_info SET reg_date='" + x.reg_date + "'  WHERE ID='" + x.xid + "' ";
            SqlCommand command = new SqlCommand(str3, connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_App_info(XObjs.G_App_info x)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            string str3 = "UPDATE g_app_info SET rtm_number='" + x.rtm_number + "',application_no='" + x.application_no + "',item_code='" + x.item_code + "',filing_date='" + x.filing_date + "', ";
            SqlCommand command = new SqlCommand((str3 + " reg_no='" + x.reg_no + "',log_staff='" + x.log_staff + "',reg_date='" + x.reg_date + "',visible='" + x.visible + "' ") + "WHERE ID='" + x.id + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_Applicant_info(XObjs.G_Applicant_info x)
        {
            //SqlConnection connection = new SqlConnection(this.Connect());
            //string str3 = "UPDATE g_applicant_info SET xname='" + x.xname + "',address='" + x.address + "',xemail='" + x.xemail + "',xmobile='" + x.xmobile + "', ";
            //SqlCommand command = new SqlCommand((str3 + " nationality='" + x.nationality + "',trading_as='" + x.trading_as + "',log_staff='" + x.log_staff + "',visible='" + x.visible + "' ") + "WHERE ID='" + x.id + "' ", connection);
            //connection.Open();
            //int num = command.ExecuteNonQuery();
            //connection.Close();

            SqlConnection connection = new SqlConnection(this.Connect());
            string str3 = "UPDATE g_applicant_info SET xname=@xname,address=@address,xemail=@xemail,xmobile=@xmobile,";
            str3 = str3 + "nationality=@nationality, trading_as=@trading_as,log_staff=@log_staff, visible=@visible  WHERE ID=@id ";
            SqlCommand command = new SqlCommand(str3, connection);
            connection.Open();
            command.Parameters.Add("@xname", SqlDbType.VarChar);
            command.Parameters.Add("@address", SqlDbType.VarChar);
            command.Parameters.Add("@xemail", SqlDbType.VarChar);
            command.Parameters.Add("@xmobile", SqlDbType.VarChar);
            command.Parameters.Add("@nationality", SqlDbType.VarChar);
            command.Parameters.Add("@trading_as", SqlDbType.VarChar);
            command.Parameters.Add("@log_staff", SqlDbType.VarChar);
            command.Parameters.Add("@visible", SqlDbType.VarChar);
            command.Parameters.Add("@id", SqlDbType.VarChar);

            command.Parameters["@xname"].Value = x.xname;
            command.Parameters["@address"].Value = x.address;
            command.Parameters["@xemail"].Value = x.xemail;
            command.Parameters["@xmobile"].Value = x.xmobile;
            command.Parameters["@nationality"].Value = x.nationality;
            command.Parameters["@trading_as"].Value = x.trading_as;
            command.Parameters["@log_staff"].Value = x.log_staff;
            command.Parameters["@visible"].Value = x.visible;
            command.Parameters["@id"].Value = x.id;

            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_G_Ass_info(XObjs.G_Ass_info x)
        {
            //SqlConnection connection = new SqlConnection(this.Connect());
            //string str3 = "UPDATE g_ass_info SET date_of_assignment='" + x.date_of_assignment + "',assignee_name='" + x.assignee_name + "',assignee_address='" + x.assignee_address + "',assignee_nationality='" + x.assignee_nationality + "',  ";
            //string str4 = str3 + "assignor_name='" + x.assignor_name + "',assignor_address='" + x.assignor_address + "',assignor_nationality='" + x.assignor_nationality + "',ass_doc='" + x.ass_doc + "',  ";
            //SqlCommand command = new SqlCommand((str4 + " log_staff='" + x.log_staff + "',xvisible='" + x.xvisible + "' ") + "WHERE xID='" + x.xid + "' ", connection);
            //connection.Open();
            //int num = command.ExecuteNonQuery();
            //connection.Close();

            SqlConnection connection = new SqlConnection(this.Connect());
            string str3 = "UPDATE g_ass_info SET date_of_assignment=@date_of_assignment,assignee_name=@assignee_name, assignee_address=@assignee_address,assignee_nationality=@assignee_nationality,";
            string str4 = str3 + "assignor_name=@assignor_name, assignor_address=@assignor_address,assignor_nationality=@assignor_nationality,ass_doc=@ass_doc, ";

            str4 = str4 + " log_staff=@log_staff, xvisible=@xvisible WHERE xID=@xid  "; 
            SqlCommand command = new SqlCommand(str4, connection);
           
            connection.Open();
            command.Parameters.Add("@date_of_assignment", SqlDbType.VarChar);
            command.Parameters.Add("@assignee_name", SqlDbType.VarChar);
            command.Parameters.Add("@assignee_address", SqlDbType.VarChar);
            command.Parameters.Add("@assignee_nationality", SqlDbType.VarChar);
            command.Parameters.Add("@assignor_name", SqlDbType.VarChar);
            command.Parameters.Add("@assignor_address", SqlDbType.VarChar);
            command.Parameters.Add("@assignor_nationality", SqlDbType.VarChar);
            command.Parameters.Add("@ass_doc", SqlDbType.VarChar);
            command.Parameters.Add("@log_staff", SqlDbType.VarChar);
            command.Parameters.Add("@xvisible", SqlDbType.VarChar);
            command.Parameters.Add("@xid", SqlDbType.VarChar);

            command.Parameters["@date_of_assignment"].Value = x.date_of_assignment;
            command.Parameters["@assignee_name"].Value = x.assignee_name;
            command.Parameters["@assignee_address"].Value = x.assignee_address;
            command.Parameters["@assignee_nationality"].Value = x.assignee_nationality;
            command.Parameters["@assignor_name"].Value = x.assignor_name;
            command.Parameters["@assignor_address"].Value = x.assignor_address;
            command.Parameters["@assignor_nationality"].Value = x.assignor_nationality;
            command.Parameters["@ass_doc"].Value = x.ass_doc;
            command.Parameters["@log_staff"].Value = x.log_staff;
            command.Parameters["@xvisible"].Value = x.xvisible;
            command.Parameters["@xid"].Value = x.xid;

           
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_G_Cert_info(XObjs.G_Cert_info x)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            string str3 = "UPDATE g_cert_info SET pub_date='" + x.pub_date + "',pub_details='" + x.pub_details + "',cert_doc='" + x.cert_doc + "',pub_doc='" + x.pub_doc + "',  ";
            SqlCommand command = new SqlCommand((str3 + " log_staff='" + x.log_staff + "',reg_date='" + x.reg_date + "',xvisible='" + x.xvisible + "' ") + "WHERE xID='" + x.xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_G_Change_info(XObjs.G_Change_info x)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            string str3 = "UPDATE g_change_info SET old_name='" + x.old_name + "',old_address='" + x.old_address + "',new_name='" + x.new_name + "',new_address='" + x.new_address + "', ";
            SqlCommand command = new SqlCommand((str3 + " log_staff='" + x.log_staff + "',reg_date='" + x.reg_date + "',visible='" + x.visible + "' ") + "WHERE xID='" + x.xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_G_Merger_info(XObjs.G_Merger_info x)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            string str3 = "UPDATE g_merger_info SET original_name='" + x.original_name + "',original_address='" + x.original_address + "',merging_name='" + x.merging_name + "',merging_address='" + x.merging_address + "', ";
            SqlCommand command = new SqlCommand((str3 + " merged_coy_name='" + x.merged_coy_name + "',merger_date='" + x.merger_date + "',merger_doc='" + x.merger_doc + "',log_staff='" + x.log_staff + "',visible='" + x.visible + "' ") + "WHERE ID='" + x.xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_G_Other_items_info(XObjs.G_Other_items_info x)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand(("UPDATE g_other_items_info SET req_details='" + x.req_details + "',log_staff='" + x.log_staff + "',reg_date='" + x.reg_date + "',visible='" + x.visible + "' ") + "WHERE xID='" + x.xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_G_Prelim_search_info(XObjs.G_Prelim_search_info x)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            string str3 = "UPDATE g_prelim_search_info SET xtitle='" + x.xtitle + "',xclass='" + x.xclass + "',xclass_desc='" + x.xclass_desc + "', ";
            SqlCommand command = new SqlCommand((str3 + " log_staff='" + x.log_staff + "',reg_date='" + x.reg_date + "',visible='" + x.visible + "' ") + "WHERE xID='" + x.xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_G_Renewal_info(XObjs.G_Renewal_info x)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            string str3 = "UPDATE g_renewal_info SET prev_renewal_date='" + x.prev_renewal_date + "',renewal_type='" + x.renewal_type + "',log_staff='" + x.log_staff + "', ";
            SqlCommand command = new SqlCommand((str3 + " reg_date='" + x.reg_date + "',visible='" + x.visible + "' ") + "WHERE xID='" + x.xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_Gen_Agent_info(XObjs.Gen_Agent_info x)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            string str3 = "UPDATE g_agent_info SET code='" + x.code + "',xname='" + x.xname + "',xpassword='" + x.xpassword + "',nationality='" + x.nationality + "',  ";
            string str4 = str3 + "country='" + x.country + "',state='" + x.state + "',address='" + x.address + "',telephone='" + x.telephone + "',  ";
            SqlCommand command = new SqlCommand((str4 + " email='" + x.email + "',log_staff='" + x.log_staff + "',xsync='" + x.xsync + "' ") + "WHERE xid='" + x.xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int update_Tm_info(XObjs.G_Tm_info x)
        {
            //SqlConnection connection = new SqlConnection(this.Connect());
            //string str3 = "UPDATE g_tm_info SET reg_number='" + x.reg_number + "',xtype='" + x.xtype + "',tm_title='" + x.tm_title + "',tm_class='" + x.tm_class + "', ";
            //string str4 = str3 + " tm_desc='" + x.tm_desc + "',logo_descID='" + x.logo_descID + "',disclaimer='" + x.disclaimer + "',logo_pic='" + x.logo_pic + "', ";
            //string str5 = str4 + " auth_doc='" + x.auth_doc + "',sup_doc1='" + x.sup_doc1 + "',app_letter_doc='" + x.app_letter_doc + "',log_staff='" + x.log_staff + "', ";
            //SqlCommand command = new SqlCommand((str5 + " reg_date='" + x.reg_date + "',visible='" + x.visible + "' ") + "WHERE xID='" + x.xid + "' ", connection);

            SqlConnection connection = new SqlConnection(this.Connect());
            string str3 = "UPDATE g_tm_info SET reg_number=@reg_number, xtype=@xtype,tm_title=@tm_title,tm_class=@tm_class,";
            string str4 = str3 + " tm_desc=@tm_desc,logo_descID=@logo_descID ,disclaimer=@disclaimer ,logo_pic=@logo_pic ,";
            string str5 = str4 + " auth_doc=@auth_doc,sup_doc1=@sup_doc1,app_letter_doc=@app_letter_doc,log_staff=@log_staff, ";
            str5 = str5 + " reg_date=@reg_date,visible=@visible WHERE xID=@xid ";

            connection.Open();
            SqlCommand command = new SqlCommand(str5, connection);
            command.Parameters.Add("@reg_number", SqlDbType.VarChar);
            command.Parameters.Add("@xtype", SqlDbType.VarChar);
            command.Parameters.Add("@tm_title", SqlDbType.VarChar);
            command.Parameters.Add("@tm_class", SqlDbType.VarChar);
            command.Parameters.Add("@tm_desc", SqlDbType.VarChar);
            command.Parameters.Add("@logo_descID", SqlDbType.VarChar);
            command.Parameters.Add("@disclaimer", SqlDbType.VarChar);
            command.Parameters.Add("@logo_pic", SqlDbType.VarChar);
            command.Parameters.Add("@auth_doc", SqlDbType.VarChar);
            command.Parameters.Add("@sup_doc1", SqlDbType.VarChar);
            command.Parameters.Add("@app_letter_doc", SqlDbType.VarChar);
            command.Parameters.Add("@log_staff", SqlDbType.VarChar);
            command.Parameters.Add("@reg_date", SqlDbType.VarChar);
            command.Parameters.Add("@visible", SqlDbType.VarChar);
            command.Parameters.Add("@xid", SqlDbType.VarChar);

            command.Parameters["@reg_number"].Value = x.reg_number;
            command.Parameters["@xtype"].Value = x.xtype;
            command.Parameters["@tm_title"].Value = x.tm_title;
            command.Parameters["@tm_class"].Value = x.tm_class;
            command.Parameters["@tm_desc"].Value = x.tm_desc;
            command.Parameters["@logo_descID"].Value = x.logo_descID;
            command.Parameters["@disclaimer"].Value = x.disclaimer;
            command.Parameters["@logo_pic"].Value = x.logo_pic;
            command.Parameters["@auth_doc"].Value = x.auth_doc;
            command.Parameters["@sup_doc1"].Value = x.sup_doc1;
            command.Parameters["@app_letter_doc"].Value = x.app_letter_doc;
            command.Parameters["@log_staff"].Value = x.log_staff;
            command.Parameters["@reg_date"].Value = x.reg_date;
            command.Parameters["@visible"].Value = x.visible;
            command.Parameters["@xid"].Value = x.xid;

            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }
        public int updateAddressProfile(string xid, string xemail, string xmobile)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("UPDATE address SET email1='" + xemail + "',telephone1='" + xmobile + "'  WHERE ID='" + xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int updateFee_detailsQty(string xid, string xqty, string tot_amt)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("UPDATE Fee_details SET xqty='" + xqty + "',tot_amt='" + tot_amt + "' WHERE xid='" + xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int updateGAppInfoReg(string xid, string reg_no)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("UPDATE g_app_info SET reg_no='" + reg_no + "'  WHERE ID='" + xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public string updateGTmReg(string xID, string typ)
        {
            string str = "0";
            string str2 = "";
            if (typ == "LOCAL")
            {
                str2 = "NG/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID;
            }
            else
            {
                str2 = "F/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID;
            }
            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE g_tm_info SET reg_number=@reg_number WHERE xID=@xID ";
            connection.Open();
            command.Parameters.Add("@xID", SqlDbType.BigInt);
            command.Parameters.Add("@reg_number", SqlDbType.NVarChar, 50);
            command.Parameters["@xID"].Value = Convert.ToInt64(xID);
            command.Parameters["@reg_number"].Value = str2;
            str = command.ExecuteNonQuery().ToString();
            connection.Close();
            return str;
        }

        static object locker = new object();
        static string Generate15UniqueDigits()
        {
            lock (locker)
            {
                Thread.Sleep(100);
                String sp = "M" + DateTime.Now.ToString("yyyyMMddHHmmssf");
                return sp ;
            }
        }
        public int addGeneric2Tx(string serverpath, XObjs.G_Pwallet c_pwall, XObjs.G_App_info g_app_info, XObjs.G_Applicant_info g_applicant_info, XObjs.G_Tm_info g_tm_info, XObjs.Gen_Agent_info g_agent_info,
           XObjs.G_Ass_info g_ass_info, XObjs.G_Merger_info g_merger_info, XObjs.G_Cert_info g_cert_info, XObjs.G_Change_info g_change_info, XObjs.G_Renewal_info g_renewal_info,
           XObjs.G_Prelim_search_info g_prelim_search_info, XObjs.G_Other_items_info g_other_items_info, HttpPostedFile fu_logo_pic, HttpPostedFile fu_sup_doc, HttpPostedFile fu_app_doc, HttpPostedFile fu_merger_doc,
           HttpPostedFile fu_ass_doc, HttpPostedFile fu_pub_doc, HttpPostedFile fu_cert_doc
           )
        {

            //try
            //{
            SqlConnection connection; SqlCommand command;
            int xID = 0; int pID = 0;
            int g_app_infoID = 0; int g_applicant_infoID = 0; int g_agent_infoID = 0; int g_ass_infoID = 0; int g_merger_infoID = 0;
            int g_cert_infoID = 0; int g_change_infoID = 0; int g_renewal_infoID = 0; int g_prelim_search_infoID = 0; int g_other_items_infoID = 0;
            int g_applicant_info_updateID = 0; int h = 0;
            string xlogo_pic = ""; string xsup_doc = ""; string xapp_doc = ""; string xmerger_doc = ""; string xass_doc = ""; string xpub_doc = ""; string xcert_doc = "";

            string doc_path = "";


            string connectionString = Connect();
            c_pwall.reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd"); //c_pwall.xtime = c_pwall.log_officer + ": " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            c_pwall.visible = "1"; c_pwall.status = "10"; c_pwall.stage = "5"; c_pwall.data_status = "New";
            c_pwall.validationID = Generate15UniqueDigits();

            if ((c_pwall.validationID != null) && (c_pwall.validationID != ""))
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                       
                        command.CommandText = "INSERT INTO g_pwallet (twalletID,validationID,applicantID,log_officer,amt,stage,status,data_status,reg_date,visible  ) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " '" + c_pwall.twalletID + "','" + c_pwall.validationID + "','" + c_pwall.applicantID + "','" + c_pwall.log_officer + "', ";
                        command.CommandText += " '" + c_pwall.amt + "','" + c_pwall.stage + "','" + c_pwall.status + "','" + c_pwall.data_status + "','" + c_pwall.reg_date + "','" + c_pwall.visible + "' ";
                        command.CommandText += " ) ";

                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();
                        pID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            if (Convert.ToInt32(pID) > 0)
            {
                g_app_info.log_staff = pID.ToString(); g_applicant_info.log_staff = pID.ToString(); g_tm_info.log_staff = pID.ToString(); g_agent_info.log_staff = pID.ToString();
                g_ass_info.log_staff = pID.ToString(); g_merger_info.log_staff = pID.ToString(); g_cert_info.log_staff = pID.ToString(); g_change_info.log_staff = pID.ToString();
                g_renewal_info.log_staff = pID.ToString(); g_prelim_search_info.log_staff = pID.ToString(); g_other_items_info.log_staff = pID.ToString();
            }
            //////////////////////////////////////////////////////////////////////////////////
            if ((g_applicant_info.xname != null) && (g_applicant_info.xname != ""))
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        //command.CommandText = "INSERT INTO g_applicant_info (xname,address,xemail,xmobile,nationality,trading_as,log_staff,visible) ";
                        //command.CommandText += " VALUES ( ";
                        //command.CommandText += " '" + g_applicant_info.xname + "','" + g_applicant_info.address + "','" + g_applicant_info.xemail + "','" + g_applicant_info.xmobile + "', ";
                        //command.CommandText += " '" + g_applicant_info.nationality + "','" + g_applicant_info.trading_as + "','" + g_applicant_info.log_staff + "','" + c_pwall.visible + "' ";
                        //command.CommandText += " ) ";
                        command.CommandText = "INSERT INTO g_applicant_info (xname,address,xemail,xmobile,nationality,trading_as,log_staff,visible) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " @xname,@address ,@xemail ,@xmobile, ";
                        command.CommandText += "@nationality,@trading_as,@log_staff ,@visible";
                        command.CommandText += " ) ";

                        command.Parameters.Add("@xname", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@address", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@xemail", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@xmobile", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@trading_as", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@visible", SqlDbType.NVarChar, 50);

                        command.Parameters["@xname"].Value = g_applicant_info.xname;

                        command.Parameters["@address"].Value = g_applicant_info.address;

                        command.Parameters["@xemail"].Value = g_applicant_info.xemail;

                        command.Parameters["@xmobile"].Value = g_applicant_info.xmobile;

                        command.Parameters["@nationality"].Value = g_applicant_info.nationality;

                        command.Parameters["@trading_as"].Value = g_applicant_info.trading_as;

                        command.Parameters["@log_staff"].Value = g_applicant_info.log_staff;

                        command.Parameters["@visible"].Value = c_pwall.visible;



                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();

                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }
                        g_applicant_infoID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////
            if ((g_tm_info.tm_title != null) && (g_tm_info.tm_title != ""))
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        //command.CommandText = "INSERT INTO g_tm_info (reg_number,xtype,tm_title,tm_class,tm_desc,logo_descID,disclaimer,logo_pic,auth_doc,sup_doc1,app_letter_doc,log_staff,reg_date,visible ) ";
                        //command.CommandText += " VALUES ( ";
                        //command.CommandText += " '" + g_tm_info.reg_number + "','" + g_tm_info.xtype + "','" + g_tm_info.tm_title + "','" + g_tm_info.tm_class + "','" + g_tm_info.tm_desc + "', ";
                        //command.CommandText += " '" + g_tm_info.logo_descID + "','" + g_tm_info.disclaimer + "','" + g_tm_info.logo_pic + "','" + g_tm_info.auth_doc + "','" + g_tm_info.sup_doc1 + "', ";
                        //command.CommandText += " '" + g_tm_info.app_letter_doc + "','" + g_tm_info.log_staff + "','" + c_pwall.reg_date + "','" + c_pwall.visible + "' ";
                        //command.CommandText += " ) ";

                        command.CommandText = "INSERT INTO g_tm_info (reg_number,xtype,tm_title,tm_class,tm_desc,logo_descID,disclaimer,logo_pic,auth_doc,sup_doc1,app_letter_doc,log_staff,reg_date,visible ) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += "@reg_number ,@xtype,@tm_title ,@tm_class,@tm_desc, ";
                        command.CommandText += "@logo_descID ,@disclaimer ,@logo_pic ,@auth_doc ,@sup_doc1 , ";
                        command.CommandText += "@app_letter_doc,@log_staff ,@reg_date,@visible ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";

                        command.Parameters.Add("@reg_number", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@xtype", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@tm_title", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@tm_class", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@tm_desc", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@logo_descID", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@disclaimer", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@logo_pic", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@auth_doc", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@sup_doc1", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@app_letter_doc", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@visible", SqlDbType.NVarChar, 50);

                        command.Parameters["@reg_number"].Value = g_tm_info.reg_number;
                        command.Parameters["@xtype"].Value = g_tm_info.xtype;
                        command.Parameters["@tm_title"].Value = g_tm_info.tm_title;
                        command.Parameters["@tm_class"].Value = g_tm_info.tm_class;
                        command.Parameters["@tm_desc"].Value = g_tm_info.tm_desc;
                        command.Parameters["@logo_descID"].Value = g_tm_info.logo_descID;
                        command.Parameters["@disclaimer"].Value = g_tm_info.disclaimer;
                        command.Parameters["@logo_pic"].Value = g_tm_info.logo_pic;
                        command.Parameters["@auth_doc"].Value = g_tm_info.auth_doc;
                        command.Parameters["@sup_doc1"].Value = g_tm_info.sup_doc1;
                        command.Parameters["@app_letter_doc"].Value = g_tm_info.app_letter_doc;
                        command.Parameters["@log_staff"].Value = g_tm_info.log_staff;
                        command.Parameters["@reg_date"].Value = c_pwall.reg_date;
                        command.Parameters["@visible"].Value = c_pwall.visible;
                        command.Connection.Open();
                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }
                        xID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                doc_path = serverpath + "admin/tm/gf/docz/" + xID + "/";

            //   doc_path = serverpath + "admin/tm/gf/docz/"; 
                
                string reg_number = "";
                if (g_tm_info.xtype == "LOCAL") { reg_number = "NG/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID; }
                else { reg_number = "F/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID; }
                //////////////////////////////////////////////////////////////////////////////////
                using (connection = new SqlConnection(connectionString))
                {
                    //using (command = connection.CreateCommand())
                    //{
                    //    command.CommandText = "UPDATE g_tm_info SET reg_number='" + reg_number + "'  WHERE xID='" + xID + "'  ";
                    //    command.Connection.Open();
                    //    g_applicant_info_updateID = command.ExecuteNonQuery();
                    //}
                }
            }
            //////////////////////////////////////////////////////////////////////////////////
            if ((g_app_info.item_code != null) && (g_app_info.item_code != ""))
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO g_app_info (rtm_number,application_no,item_code,filing_date,reg_no,log_staff,reg_date,visible ) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " '" + g_app_info.rtm_number + "','" + g_app_info.application_no + "','" + g_app_info.item_code + "','" + g_app_info.filing_date + "', ";
                        command.CommandText += " '" + g_app_info.reg_no + "','" + g_app_info.log_staff + "','" + c_pwall.reg_date + "','" + c_pwall.visible + "'  ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();
                        g_app_infoID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                string reg_no = string.Concat(new object[] { "TM/GF/", g_app_info.item_code, "/", DateTime.Now.ToString("yyyy"), "/", xID });
                //////////////////////////////////////////////////////////////////////////////////
                //using (connection = new SqlConnection(connectionString))
                //{
                //    using (command = connection.CreateCommand())
                //    {
                //        command.CommandText = "UPDATE g_app_info SET reg_no='" + reg_no + "'  WHERE ID='" + g_app_infoID + "'  ";
                //        command.Connection.Open();
                //        g_applicant_info_updateID = command.ExecuteNonQuery();
                //    }
                //}
            }
            //////////////////////////////////////////////////////////////////////////////////
            if ((g_agent_info.code != null) && (g_agent_info.code != ""))
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO g_agent_info (code,xname,xpassword,nationality,country,state,address,telephone,email,log_staff,xsync )";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " '" + g_agent_info.code + "','" + g_agent_info.xname + "','" + g_agent_info.xpassword + "','" + g_agent_info.nationality + "', ";
                        command.CommandText += " '" + g_agent_info.country + "','" + g_agent_info.state + "','" + g_agent_info.address + "','" + g_agent_info.telephone + "','" + g_agent_info.email + "', ";
                        command.CommandText += " '" + g_agent_info.log_staff + "','" + g_agent_info.xsync + "' ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();
                        g_agent_infoID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////
            if ((g_ass_info.assignee_name != null) && (g_ass_info.assignee_name != ""))
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO g_ass_info (date_of_assignment,assignee_name,assignee_address,assignee_nationality,assignor_name,assignor_address,assignor_nationality,ass_doc,log_staff,xvisible ) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " '" + g_ass_info.date_of_assignment + "','" + g_ass_info.assignee_name + "','" + g_ass_info.assignee_address + "','" + g_ass_info.assignee_nationality + "', ";
                        command.CommandText += " '" + g_ass_info.assignor_name + "','" + g_ass_info.assignor_address + "','" + g_ass_info.assignor_nationality + "','" + g_ass_info.ass_doc + "', ";
                        command.CommandText += " '" + g_ass_info.log_staff + "','" + c_pwall.visible + "' ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();
                        g_ass_infoID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////
            if ((g_cert_info.pub_details != null) && (g_cert_info.pub_details != ""))
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        //command.CommandText = "INSERT INTO g_cert_info (pub_date,pub_details,cert_doc,pub_doc,log_staff,reg_date,xvisible) ";
                        //command.CommandText += " VALUES ( ";
                        //command.CommandText += " '" + g_cert_info.pub_date + "','" + g_cert_info.pub_details + "','" + g_cert_info.cert_doc + "','" + g_cert_info.pub_doc + "', ";
                        //command.CommandText += " '" + g_cert_info.log_staff + "','" + c_pwall.reg_date + "','" + c_pwall.visible + "' ";
                        //command.CommandText += " ) ";

                        command.CommandText = "INSERT INTO g_cert_info (pub_date,pub_details,cert_doc,pub_doc,log_staff,reg_date,xvisible) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += "@pub_date ,@pub_details ,@cert_doc ,@pub_doc, ";
                        command.CommandText += " @log_staff ,@reg_date,@visible ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";

                        command.Parameters.Add("@pub_date", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@pub_details", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@cert_doc", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@pub_doc", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@visible", SqlDbType.NVarChar, 50);

                        command.Parameters["@pub_date"].Value = g_cert_info.pub_date;
                        command.Parameters["@pub_details"].Value = g_cert_info.pub_details;
                        command.Parameters["@cert_doc"].Value = g_cert_info.cert_doc;
                        command.Parameters["@pub_doc"].Value = g_cert_info.pub_doc;
                        command.Parameters["@log_staff"].Value = g_cert_info.log_staff;
                        command.Parameters["@reg_date"].Value = c_pwall.reg_date;
                        command.Parameters["@visible"].Value = c_pwall.visible;
                        command.Connection.Open();
                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }
                        g_cert_infoID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////
            if ((g_change_info.old_name != null) && (g_change_info.old_name != ""))
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO g_change_info (old_name,old_address,new_name,new_address,log_staff,reg_date,visible ) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " '" + g_change_info.old_name + "','" + g_change_info.old_address + "','" + g_change_info.new_name + "','" + g_change_info.new_address + "', ";
                        command.CommandText += " '" + g_change_info.log_staff + "','" + c_pwall.reg_date + "','" + c_pwall.visible + "' ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();
                        g_change_infoID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////
            if ((g_merger_info.original_name != null) && (g_merger_info.original_name != ""))
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO g_merger_info (original_name,original_address,merging_name,merging_address,merged_coy_name,merger_date,merger_doc,log_staff,visible) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " '" + g_merger_info.original_name + "','" + g_merger_info.original_address + "','" + g_merger_info.merging_name + "','" + g_merger_info.merging_address + "', ";
                        command.CommandText += " '" + g_merger_info.merged_coy_name + "','" + g_merger_info.merger_date + "','" + g_merger_info.merger_doc + "','" + g_merger_info.log_staff + "','" + c_pwall.visible + "' ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();
                        g_merger_infoID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////
            if ((g_other_items_info.req_details != null) && (g_other_items_info.req_details != ""))
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO g_other_items_info (req_details,reg_date,log_staff,visible) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " '" + g_other_items_info.req_details + "','" + c_pwall.reg_date + "','" + g_other_items_info.log_staff + "','" + c_pwall.visible + "' ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();
                        g_other_items_infoID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////
            if ((g_prelim_search_info.xtitle != null) && (g_prelim_search_info.xtitle != ""))
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO g_prelim_search_info (xtitle,xclass,xclass_desc,reg_date,log_staff,visible)";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " '" + g_prelim_search_info.xtitle + "','" + g_prelim_search_info.xclass + "',";
                        command.CommandText += " '" + g_prelim_search_info.xclass_desc + "','" + c_pwall.reg_date + "','" + g_prelim_search_info.log_staff + "','" + c_pwall.visible + "' ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();
                        g_prelim_search_infoID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////
            if ((g_renewal_info.prev_renewal_date != null) && (g_renewal_info.prev_renewal_date != ""))
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO g_renewal_info (prev_renewal_date,renewal_type,reg_date,log_staff,visible) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += " '" + g_renewal_info.prev_renewal_date + "','" + g_renewal_info.renewal_type + "', ";
                        command.CommandText += " '" + c_pwall.reg_date + "','" + g_renewal_info.log_staff + "','" + c_pwall.visible + "' ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();
                        g_renewal_infoID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            if (!doc_path.EndsWith("/")) { doc_path = doc_path + "/"; }

            if (!Directory.Exists(doc_path + "/")) { Directory.CreateDirectory(doc_path + "/"); }
            if (fu_logo_pic != null) //fu_logo_pic.HasFile)
            {
                xlogo_pic = Path.Combine(doc_path, fu_logo_pic.FileName.Replace(" ", "_"));
                fu_logo_pic.SaveAs(xlogo_pic);
                // fu_logo_pic.MoveTo(xlogo_pic, MoveToOptions.Overwrite);
                xlogo_pic = xlogo_pic.Replace(serverpath + "admin/tm/gf/", "");
            }
            if (fu_app_doc != null)
            {
                xapp_doc = Path.Combine(doc_path, fu_app_doc.FileName.Replace(" ", "_"));
                fu_app_doc.SaveAs(xapp_doc);
                xapp_doc = xapp_doc.Replace(serverpath + "admin/tm/gf/", "");
            }
            if (fu_sup_doc != null)
            {
                xsup_doc = Path.Combine(doc_path, fu_sup_doc.FileName.Replace(" ", "_"));
                fu_sup_doc.SaveAs(xsup_doc);
                xsup_doc = xsup_doc.Replace(serverpath + "admin/tm/gf/", "");
            }

            if (fu_merger_doc != null)
            {
                xmerger_doc = Path.Combine(doc_path, fu_merger_doc.FileName.Replace(" ", "_"));
                fu_merger_doc.SaveAs(xmerger_doc);
                xmerger_doc = xmerger_doc.Replace(serverpath + "admin/tm/gf/", "");
            }
            if (fu_ass_doc != null)
            {
                xass_doc = Path.Combine(doc_path, fu_ass_doc.FileName.Replace(" ", "_"));
                fu_ass_doc.SaveAs(xass_doc);
                xass_doc = xass_doc.Replace(serverpath + "admin/tm/gf/", "");
            }
            if (fu_pub_doc != null)
            {
                xpub_doc = Path.Combine(doc_path, fu_pub_doc.FileName.Replace(" ", "_"));
                fu_pub_doc.SaveAs(xpub_doc);
                xpub_doc = xpub_doc.Replace(serverpath + "admin/tm/gf/", "");
            }
            if (fu_cert_doc != null)
            {
                xcert_doc = Path.Combine(doc_path, fu_cert_doc.FileName.Replace(" ", "_"));
                fu_cert_doc.SaveAs(xcert_doc);
                xcert_doc = xcert_doc.Replace(serverpath + "admin/tm/gf/", "");
            }

            //////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////
            using (connection = new SqlConnection(connectionString))
            {
                using (command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE g_tm_info SET logo_pic='" + xlogo_pic + "',sup_doc1='" + xsup_doc + "',app_letter_doc='" + xapp_doc + "' WHERE log_staff='" + pID + "'  ";
                    command.Connection.Open();
                    h += Convert.ToInt32(command.ExecuteNonQuery());
                }
            }
            //////////////////////////////////////////////////////////////////////////////////
            if (g_cert_infoID > 0)
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE g_cert_info SET cert_doc='" + xcert_doc + "',pub_doc='" + xpub_doc + "'WHERE xID='" + g_cert_infoID + "' ";
                        command.Connection.Open();
                        h += Convert.ToInt32(command.ExecuteNonQuery());
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////
            if (g_merger_infoID > 0)
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE g_merger_info SET merger_doc='" + xmerger_doc + "' WHERE ID='" + g_merger_infoID + "'  ";
                        command.Connection.Open();
                        h += Convert.ToInt32(command.ExecuteNonQuery());
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////
            if (g_ass_infoID > 0)
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE g_ass_info SET ass_doc='" + xass_doc + "' WHERE xID='" + g_ass_infoID + "'  ";
                        command.Connection.Open();
                        h += Convert.ToInt32(command.ExecuteNonQuery());
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////           
            using (connection = new SqlConnection(connectionString))
            {
                using (command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE g_ass_info SET ass_doc='" + xass_doc + "' WHERE xID='" + g_ass_infoID + "'  ";
                    command.Connection.Open();
                    h += Convert.ToInt32(command.ExecuteNonQuery());
                }
            }

            return xID;
            // }
            //catch (Exception ee)
            //{
            //    XWriters pp = new XWriters();
            //    string message = c_pwall.validationID + " " + DateTime.Now;

            //    string vpath =System.Web.HttpContext.Current.Server.MapPath("~/")+"TradeMarkLog/Generic/" + c_pwall.validationID + ".txt";

            //    pp.WriteToFile(message, vpath);


            //    return 0;


            // }
        }

        public string addTrademarkTx(Cld_Generic dd,HttpPostedFile logo_pic, HttpPostedFile auth_doc, HttpPostedFile sup_doc1, HttpPostedFile sup_doc2, string serverpath)
        {
            
         
            Retriever ret = new Retriever();
            string xID =null; int pID = 0;
            string xauth_doc = ""; string xsup_doc1 = ""; string xsup_doc2 = ""; string xpath = "";
            string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string xtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            string xvisible = "1"; string xsync = "0";

            SqlConnection connection; SqlCommand command;
            string connectionString = Connect();
            //c_pwall.reg_date = reg_date;
            //c_pwall.xtime = c_pwall.log_officer + ": " + xtime;
            //c_pwall.visible = xvisible; c_pwall.status = "1"; c_pwall.stage = "5"; c_pwall.data_status = "Fresh";
            //c_pwall.acc_p = "0"; c_pwall.rtm = "0"; 
            int app_addyID = 0; 
            
            int rep_addyID = 0;
            int cert_infoID = 0;



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

                        command.Parameters["@validationID"].Value = Generate15UniqueDigits(); 
                        command.Parameters["@applicantID"].Value =dd.Agent_Code ;
                        command.Parameters["@log_officer"].Value = "0";
                        command.Parameters["@amt"].Value ="0";
                        command.Parameters["@stage"].Value = "5";
                        command.Parameters["@status"].Value = "10";
                        command.Parameters["@data_status"].Value = "New";
                        command.Parameters["@reg_date"].Value = dd.Application_Date;
                        command.Parameters["@visible"].Value = xvisible;
                        command.Parameters["@xtime"].Value = xtime;
                        command.Parameters["@rtm"].Value = dd.Rtm_No;
                        command.Parameters["@acc_p"].Value = "";

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
                 //   c_app.log_staff = pID.ToString(); c_mark.log_staff = pID.ToString(); c_aos.log_staff = pID.ToString(); c_rep.log_staff = pID.ToString(); c_rep_addy.log_staff = pID.ToString(); c_app_addy.log_staff = pID.ToString();
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

                        command.Parameters["@countryID"].Value = dd.Nationality ;
                        command.Parameters["@stateID"].Value = "";
                        command.Parameters["@city"].Value = "";
                        command.Parameters["@street"].Value =dd.Applicant_Address ;
                        command.Parameters["@telephone1"].Value =dd.Applicant_Phone ;
                        command.Parameters["@email1"].Value = dd.Applicant_Email;
                        command.Parameters["@log_staff"].Value =pID.ToString() ;
                        command.Parameters["@reg_date"].Value = dd.Application_Date;
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
                        command.CommandText = "INSERT INTO address_service (countryID,stateID,city,street,telephone1,email1,log_staff,reg_date,visible,xtime) ";
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


                        command.Parameters["@countryID"].Value = dd.Agent_Rep_Nationality;
                        command.Parameters["@stateID"].Value = dd.Agent_State;
                        command.Parameters["@city"].Value = "";
                        command.Parameters["@street"].Value = dd.rep_address;
                        command.Parameters["@telephone1"].Value = dd.Rep_telephone;
                        command.Parameters["@email1"].Value = dd.Rep_email;
                        command.Parameters["@log_staff"].Value = pID.ToString(); ;
                        command.Parameters["@reg_date"].Value = dd.Application_Date;
                        command.Parameters["@visible"].Value = xvisible;
                        command.Parameters["@xtime"].Value = xtime;

                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }

                     int    rep_addyID2 = Convert.ToInt32(command.ExecuteScalar());
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

                       
                        command.Parameters["@countryID"].Value =dd.Agent_Rep_Nationality;
                        command.Parameters["@stateID"].Value =dd.Agent_State ;
                        command.Parameters["@city"].Value ="";
                        command.Parameters["@street"].Value =dd.rep_address ;
                        command.Parameters["@telephone1"].Value =dd.Rep_telephone;
                        command.Parameters["@email1"].Value =dd.Rep_email ;
                        command.Parameters["@log_staff"].Value = pID.ToString(); ;
                        command.Parameters["@reg_date"].Value = dd.Application_Date;
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

                        command.Parameters["@xname"].Value =dd.Applicant_name ;
                        command.Parameters["@nationality"].Value =dd.Nationality ;
                        command.Parameters["@addressID"].Value = app_addyID;
                        command.Parameters["@log_staff"].Value = pID.ToString(); ;
                        command.Parameters["@reg_date"].Value = dd.Application_Date;
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

                        command.Parameters["@agent_code"].Value =dd.Agent_Code ;
                        command.Parameters["@xname"].Value =dd.Rep_Xname ;
                        command.Parameters["@nationality"].Value = dd.Agent_Rep_Nationality;
                        command.Parameters["@addressID"].Value = rep_addyID;
                        command.Parameters["@log_staff"].Value = pID.ToString(); ;
                        command.Parameters["@reg_date"].Value = dd.Application_Date;
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
                            //command.CommandText = "INSERT INTO g_cert_info (pub_date,pub_details,cert_doc,pub_doc,log_staff,reg_date,xvisible) ";
                            //command.CommandText += " VALUES ( ";
                            //command.CommandText += " '" + g_cert_info.pub_date + "','" + g_cert_info.pub_details + "','" + g_cert_info.cert_doc + "','" + g_cert_info.pub_doc + "', ";
                            //command.CommandText += " '" + g_cert_info.log_staff + "','" + c_pwall.reg_date + "','" + c_pwall.visible + "' ";
                            //command.CommandText += " ) ";

                            command.CommandText = "INSERT INTO cert_info (pub_date,pub_details,cert_doc,pub_doc,log_staff,reg_date,xvisible) ";
                            command.CommandText += " VALUES ( ";
                            command.CommandText += "@pub_date ,@pub_details ,@cert_doc ,@pub_doc, ";
                            command.CommandText += " @log_staff ,@reg_date,@visible ";
                            command.CommandText += " ) ";
                            command.CommandText += " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            command.Parameters.Add("@pub_date", SqlDbType.NVarChar, 50);
                            command.Parameters.Add("@pub_details", SqlDbType.NVarChar, 50);
                            command.Parameters.Add("@cert_doc", SqlDbType.NVarChar, 50);
                            command.Parameters.Add("@pub_doc", SqlDbType.NVarChar, 50);
                            command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
                            command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
                            command.Parameters.Add("@visible", SqlDbType.NVarChar, 50);

                            command.Parameters["@pub_date"].Value = dd.Cert_publicationdate;// g_cert_info.pub_date;
                            command.Parameters["@pub_details"].Value = dd.cert_details;// g_cert_info.pub_details;
                            command.Parameters["@cert_doc"].Value = "";
                            command.Parameters["@pub_doc"].Value = "";
                            command.Parameters["@log_staff"].Value = pID.ToString(); ;
                            command.Parameters["@reg_date"].Value = dd.Application_Date;
                            command.Parameters["@visible"].Value = xvisible;
                            
                            foreach (SqlParameter Parameter in command.Parameters)
                            {
                                if (Parameter.Value == null)
                                {
                                    Parameter.Value = DBNull.Value;
                                }
                            }
                            cert_infoID = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
               
       
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

                        command.Parameters["@reg_number"].Value = dd.Application_No;
                        command.Parameters["@tm_typeID"].Value =dd.Trademark_Type;
                        command.Parameters["@logo_descriptionID"].Value = dd.Logo_Desc; // c_mark.logo_descriptionID;
                        command.Parameters["@product_title"].Value = dd.Title_Of_Trademark;// c_mark.product_title;
                        command.Parameters["@nice_class"].Value = dd.Trademark_Class;// c_mark.nice_class;
                        command.Parameters["@nice_class_desc"].Value = dd.Goods_Desc; //  dd.Trademark_Class;// c_mark.nice_class_desc;
                        command.Parameters["@national_classID"].Value = dd.Trademark_Class;// c_mark.national_classID;
                        command.Parameters["@disclaimer"].Value = dd.Txt_Discalimer;// c_mark.disclaimer;
                        command.Parameters["@log_staff"].Value = pID.ToString();// c_mark.log_staff;
                        command.Parameters["@reg_date"].Value = dd.Application_Date; ;
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
                //string reg_number = "";
                //if (c_mark.tm_typeID == "1")
                //{
                //    reg_number = "NG/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID;
                //}
                //else
                //{
                //    reg_number = "F/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID;
                //}
                //using (connection = new SqlConnection(connectionString))
                //{
                //    using (command = connection.CreateCommand())
                //    {
                //        // command.CommandTimeout = 300;
                //        command.CommandText = "UPDATE mark_info SET reg_number='" + reg_number + "'  WHERE xID='" + xID + "' ";
                //        command.Connection.Open();
                //        int rm = Convert.ToInt32(command.ExecuteNonQuery());
                //        command.Connection.Close();
                //    }
                //}
                try { 
                if (logo_pic != null) { xpath = doUploadPic(xID, xID + ".jpg", serverpath + "admin/tm/Picz/", logo_pic); }
                    }

                catch (Exception ee)
                {

                }
                try { 
                if (auth_doc != null) { xauth_doc = doUploadDoc(xID, serverpath + "admin/tm/docz/", auth_doc); }

                    }
                catch (Exception ee)
                {

                }
                try
                {
                    if (sup_doc1 != null) { xsup_doc1 = doUploadDoc(xID, serverpath + "admin/tm/docz/", sup_doc1); }
                }

                catch (Exception ee)
                {

                }
                try
                {
                    if (sup_doc2 != null) { xsup_doc2 = doUploadDoc(xID, serverpath + "admin/tm/docz/", sup_doc2); }

                }
                catch (Exception ee)
                {

                }
                try
                {
                    xpath = xpath.Replace(serverpath + "admin/tm/", "");
                }
                catch (Exception ee)
                {

                }
                try
                {
                    xsup_doc2 = xsup_doc2.Replace(serverpath + "admin/tm/", "");
                }
                catch (Exception ee)
                {

                }
                try
                {
                    xsup_doc1 = xsup_doc1.Replace(serverpath + "admin/tm/", "");
                }
                catch (Exception ee)
                {

                }
                try
                {
                    xauth_doc = xauth_doc.Replace(serverpath + "admin/tm/", "");
                }
                catch (Exception ee)
                {

                }

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

                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        //  command.CommandTimeout = 300;
                        command.CommandText = "UPDATE cert_info  SET pub_doc=@logo_pic  WHERE log_staff=@log_staff  ";

                        command.Connection.Open();
                        command.Parameters.Add("@logo_pic", SqlDbType.Text);
                        command.Parameters.Add("@log_staff", SqlDbType.NChar, 50);

                        command.Parameters["@logo_pic"].Value = xsup_doc2;

                        command.Parameters["@log_staff"].Value = pID.ToString();
                        int h = Convert.ToInt32(command.ExecuteNonQuery());
                        command.Connection.Close();
                    }
                }
                if (command.Connection.State == ConnectionState.Open) { command.Connection.Close(); }
            }
            catch (Exception exception)
            {
                //xID = "0";
                //XWriters pp = new XWriters();

                //string message = c_pwall.validationID + " " + DateTime.Now;

                //string vpath = System.Web.HttpContext.Current.Server.MapPath("~/") + "TradeMarkLog/NonGeneric/" + dd. c_pwall.validationID + ".txt";

                //pp.WriteToFile(message, vpath);
                //exception.ToString(); xID = "0";
                //   command.Connection.Close();
            }
            finally
            {

                //  xID = "0";
                // command.Connection.Close(); 
            }
            return xID;
        }

        public string addTrademarkTx2(Cld_Generic dd, HttpPostedFile logo_pic, HttpPostedFile auth_doc, HttpPostedFile sup_doc1, HttpPostedFile sup_doc2, string serverpath)
        {


            Retriever ret = new Retriever();
            string xID = null; int pID = 0;
            string xauth_doc = ""; string xsup_doc1 = ""; string xsup_doc2 = ""; string xpath = "";
            string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string xtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            string xvisible = "1"; string xsync = "0";

            dd.Application_Date = reg_date;
            string vnumber = dd.Validationid;
            string[] words = vnumber.Split('-');

            

            SqlConnection connection; SqlCommand command;
            string connectionString = Connect();
            //c_pwall.reg_date = reg_date;
            //c_pwall.xtime = c_pwall.log_officer + ": " + xtime;
            //c_pwall.visible = xvisible; c_pwall.status = "1"; c_pwall.stage = "5"; c_pwall.data_status = "Fresh";
            //c_pwall.acc_p = "0"; c_pwall.rtm = "0"; 
            int app_addyID = 0;

            int rep_addyID = 0;
            int cert_infoID = 0;



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

                        command.Parameters["@validationID"].Value = dd.Validationid;
                        command.Parameters["@applicantID"].Value = dd.Agent_Code;
                        command.Parameters["@log_officer"].Value = "0";
                        command.Parameters["@amt"].Value = "0";
                        command.Parameters["@stage"].Value = "5";
                        command.Parameters["@status"].Value = "1";
                        command.Parameters["@data_status"].Value = "Fresh";
                        command.Parameters["@reg_date"].Value = reg_date;
                        command.Parameters["@visible"].Value = xvisible;
                        command.Parameters["@xtime"].Value = xtime;
                        command.Parameters["@rtm"].Value = dd.Rtm_No;
                        command.Parameters["@acc_p"].Value = "";

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
                    //   c_app.log_staff = pID.ToString(); c_mark.log_staff = pID.ToString(); c_aos.log_staff = pID.ToString(); c_rep.log_staff = pID.ToString(); c_rep_addy.log_staff = pID.ToString(); c_app_addy.log_staff = pID.ToString();
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

                        command.Parameters["@countryID"].Value = dd.Nationality;
                        command.Parameters["@stateID"].Value = "";
                        command.Parameters["@city"].Value = "";
                        command.Parameters["@street"].Value = dd.Applicant_Address;
                        command.Parameters["@telephone1"].Value = dd.Applicant_Phone;
                        command.Parameters["@email1"].Value = dd.Applicant_Email;
                        command.Parameters["@log_staff"].Value = pID.ToString();
                        command.Parameters["@reg_date"].Value = dd.Application_Date;
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
                        command.CommandText = "INSERT INTO address_service (countryID,stateID,city,street,telephone1,email1,log_staff,reg_date,visible,xtime) ";
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


                        command.Parameters["@countryID"].Value = dd.Agent_Rep_Nationality;
                        command.Parameters["@stateID"].Value = dd.Agent_State;
                        command.Parameters["@city"].Value = "";
                        command.Parameters["@street"].Value = dd.rep_address;
                        command.Parameters["@telephone1"].Value = dd.Rep_telephone;
                        command.Parameters["@email1"].Value = dd.Rep_email;
                        command.Parameters["@log_staff"].Value = pID.ToString(); ;
                        command.Parameters["@reg_date"].Value = dd.Application_Date;
                        command.Parameters["@visible"].Value = xvisible;
                        command.Parameters["@xtime"].Value = xtime;

                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }

                        int rep_addyID2 = Convert.ToInt32(command.ExecuteScalar());
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


                       // command.Parameters["@countryID"].Value = dd.Agent_Rep_Nationality;
                        command.Parameters["@countryID"].Value = "160";
                        command.Parameters["@stateID"].Value = dd.Agent_State;
                        command.Parameters["@city"].Value = "";
                        command.Parameters["@street"].Value = dd.rep_address;
                        command.Parameters["@telephone1"].Value = dd.Rep_telephone;
                        command.Parameters["@email1"].Value = dd.Rep_email;
                        command.Parameters["@log_staff"].Value = pID.ToString(); ;
                        command.Parameters["@reg_date"].Value = dd.Application_Date;
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

                        command.Parameters["@xname"].Value = dd.Applicant_name;
                        command.Parameters["@nationality"].Value = dd.Nationality;
                        command.Parameters["@addressID"].Value = app_addyID;
                        command.Parameters["@log_staff"].Value = pID.ToString(); ;
                        command.Parameters["@reg_date"].Value = dd.Application_Date;
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

                        command.Parameters["@agent_code"].Value = dd.Agent_Code;
                        command.Parameters["@xname"].Value = dd.Rep_Xname;
                        command.Parameters["@nationality"].Value = "160";
                        command.Parameters["@addressID"].Value = rep_addyID;
                        command.Parameters["@log_staff"].Value = pID.ToString(); ;
                        command.Parameters["@reg_date"].Value = dd.Application_Date;
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
                        //command.CommandText = "INSERT INTO g_cert_info (pub_date,pub_details,cert_doc,pub_doc,log_staff,reg_date,xvisible) ";
                        //command.CommandText += " VALUES ( ";
                        //command.CommandText += " '" + g_cert_info.pub_date + "','" + g_cert_info.pub_details + "','" + g_cert_info.cert_doc + "','" + g_cert_info.pub_doc + "', ";
                        //command.CommandText += " '" + g_cert_info.log_staff + "','" + c_pwall.reg_date + "','" + c_pwall.visible + "' ";
                        //command.CommandText += " ) ";

                        command.CommandText = "INSERT INTO cert_info (pub_date,pub_details,cert_doc,pub_doc,log_staff,reg_date,xvisible) ";
                        command.CommandText += " VALUES ( ";
                        command.CommandText += "@pub_date ,@pub_details ,@cert_doc ,@pub_doc, ";
                        command.CommandText += " @log_staff ,@reg_date,@visible ";
                        command.CommandText += " ) ";
                        command.CommandText += " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();
                        command.Parameters.Add("@pub_date", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@pub_details", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@cert_doc", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@pub_doc", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
                        command.Parameters.Add("@visible", SqlDbType.NVarChar, 50);

                        command.Parameters["@pub_date"].Value = dd.Cert_publicationdate;// g_cert_info.pub_date;
                        command.Parameters["@pub_details"].Value = dd.cert_details;// g_cert_info.pub_details;
                        command.Parameters["@cert_doc"].Value = "";
                        command.Parameters["@pub_doc"].Value = "";
                        command.Parameters["@log_staff"].Value = pID.ToString(); ;
                        command.Parameters["@reg_date"].Value = dd.Application_Date;
                        command.Parameters["@visible"].Value = xvisible;

                        foreach (SqlParameter Parameter in command.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }
                        cert_infoID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }


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

                        command.Parameters["@reg_number"].Value = dd.Application_No;
                        command.Parameters["@tm_typeID"].Value = dd.Trademark_Type;
                        command.Parameters["@logo_descriptionID"].Value = dd.Logo_Desc; // c_mark.logo_descriptionID;
                        command.Parameters["@product_title"].Value = dd.Title_Of_Trademark;// c_mark.product_title;
                        command.Parameters["@nice_class"].Value = dd.Trademark_Class;// c_mark.nice_class;
                        command.Parameters["@nice_class_desc"].Value = dd.Goods_Desc; //  dd.Trademark_Class;// c_mark.nice_class_desc;
                        command.Parameters["@national_classID"].Value = dd.Trademark_Class;// c_mark.national_classID;
                        command.Parameters["@disclaimer"].Value = dd.Txt_Discalimer;// c_mark.disclaimer;
                        command.Parameters["@log_staff"].Value = pID.ToString();// c_mark.log_staff;
                        command.Parameters["@reg_date"].Value = dd.Application_Date; ;
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
                if (dd.Trademark_Type == "1")
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

                Registration tt2 = new Registration();
               


            //    updateHwallet(words[2], "Used", reg_date, dd.Title_Of_Trademark);


                //string reg_number = "";
                //if (c_mark.tm_typeID == "1")
                //{
                //    reg_number = "NG/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID;
                //}
                //else
                //{
                //    reg_number = "F/TM/O/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID;
                //}
                //using (connection = new SqlConnection(connectionString))
                //{
                //    using (command = connection.CreateCommand())
                //    {
                //        // command.CommandTimeout = 300;
                //        command.CommandText = "UPDATE mark_info SET reg_number='" + reg_number + "'  WHERE xID='" + xID + "' ";
                //        command.Connection.Open();
                //        int rm = Convert.ToInt32(command.ExecuteNonQuery());
                //        command.Connection.Close();
                //    }
                //}
                try
                {
                    if (logo_pic != null) {
                       
                        xpath = doUploadPic(xID, xID + ".jpg", serverpath + "admin/tm/Picz/", logo_pic);
                       
                      

                    }

                   
                }

                catch (Exception ee)
                {

                }
                try
                {
                    if (auth_doc != null) { xauth_doc = doUploadDoc(xID, serverpath + "admin/tm/docz/", auth_doc); }

                }
                catch (Exception ee)
                {

                }
                try
                {
                    if (sup_doc1 != null) { xsup_doc1 = doUploadDoc(xID, serverpath + "admin/tm/docz/", sup_doc1); }
                }

                catch (Exception ee)
                {

                }
                try
                {
                    if (sup_doc2 != null) { xsup_doc2 = doUploadDoc(xID, serverpath + "admin/tm/docz/", sup_doc2); }

                }
                catch (Exception ee)
                {

                }
                try
                {
                    xpath = xpath.Replace(serverpath + "admin/tm/", "");
                }
                catch (Exception ee)
                {

                }
                try
                {
                    xsup_doc2 = xsup_doc2.Replace(serverpath + "admin/tm/", "");
                }
                catch (Exception ee)
                {

                }
                try
                {
                    xsup_doc1 = xsup_doc1.Replace(serverpath + "admin/tm/", "");
                }
                catch (Exception ee)
                {

                }
                try
                {
                    xauth_doc = xauth_doc.Replace(serverpath + "admin/tm/", "");
                }
                catch (Exception ee)
                {

                }

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

                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        //  command.CommandTimeout = 300;
                        command.CommandText = "UPDATE cert_info  SET pub_doc=@logo_pic  WHERE log_staff=@log_staff  ";

                        command.Connection.Open();
                        command.Parameters.Add("@logo_pic", SqlDbType.Text);
                        command.Parameters.Add("@log_staff", SqlDbType.NChar, 50);

                        command.Parameters["@logo_pic"].Value = xsup_doc2;

                        command.Parameters["@log_staff"].Value = pID.ToString();
                        int h = Convert.ToInt32(command.ExecuteNonQuery());
                        command.Connection.Close();
                    }
                }
                if (command.Connection.State == ConnectionState.Open) { command.Connection.Close(); }
            }
            catch (Exception exception )
            {

                var pp = exception.Message;
                //xID = "0";
                //XWriters pp = new XWriters();

                //string message = c_pwall.validationID + " " + DateTime.Now;

                //string vpath = System.Web.HttpContext.Current.Server.MapPath("~/") + "TradeMarkLog/NonGeneric/" + dd. c_pwall.validationID + ".txt";

                //pp.WriteToFile(message, vpath);
                //exception.ToString(); xID = "0";
                //   command.Connection.Close();
            }
            finally
            {

                //  xID = "0";
                // command.Connection.Close(); 
            }
            return xID;
        }

        public string UploadTrademarkTx(string vlogstaff, HttpPostedFile logo_pic, HttpPostedFile auth_doc, HttpPostedFile sup_doc1, HttpPostedFile sup_doc2, string serverpath)
        {


            Retriever ret = new Retriever();
            string xID = null; int pID = 0;
            string xauth_doc = ""; string xsup_doc1 = ""; string xsup_doc2 = ""; string xpath = "";
            string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string xtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            string xvisible = "1"; string xsync = "0";

            SqlConnection connection; SqlCommand command;
            string connectionString = Connect();
            //c_pwall.reg_date = reg_date;
            //c_pwall.xtime = c_pwall.log_officer + ": " + xtime;
            //c_pwall.visible = xvisible; c_pwall.status = "1"; c_pwall.stage = "5"; c_pwall.data_status = "Fresh";
            //c_pwall.acc_p = "0"; c_pwall.rtm = "0"; 
            int app_addyID = 0;

            int rep_addyID = 0;
            int cert_infoID = 0;



            try
            {
                
                try
                {
                    if (logo_pic != null) { xpath = doUploadPic(vlogstaff, vlogstaff + ".jpg", serverpath + "admin/tm/Picz/", logo_pic); }
                }

                catch (Exception ee)
                {
                    addxtest(ee.Message);
                }
                try
                {
                    if (auth_doc != null) { xauth_doc = doUploadDoc(vlogstaff, serverpath + "admin/tm/docz/", auth_doc); }

                }
                catch (Exception ee)
                {
                    addxtest(ee.Message);
                }
                try
                {
                    if (sup_doc1 != null) { xsup_doc1 = doUploadDoc(vlogstaff, serverpath + "admin/tm/docz/", sup_doc1); }
                }

                catch (Exception ee)
                {
                    addxtest(ee.Message);
                }
                try
                {
                    if (sup_doc2 != null) { xsup_doc2 = doUploadDoc(vlogstaff, serverpath + "admin/tm/docz/", sup_doc2); }

                }
                catch (Exception ee)
                {
                    addxtest(ee.Message);
                }
                try
                {
                    xpath = xpath.Replace(serverpath + "admin/tm/", "");
                }
                catch (Exception ee)
                {
                    addxtest(ee.Message);
                }
                try
                {
                    xsup_doc2 = xsup_doc2.Replace(serverpath + "admin/tm/", "");
                }
                catch (Exception ee)
                {
                    addxtest(ee.Message);
                }
                try
                {
                    xsup_doc1 = xsup_doc1.Replace(serverpath + "admin/tm/", "");
                }
                catch (Exception ee)
                {
                    addxtest(ee.Message);
                }
                try
                {
                    xauth_doc = xauth_doc.Replace(serverpath + "admin/tm/", "");
                }
                catch (Exception ee)
                {
                    addxtest(ee.Message);
                }

                if (logo_pic != null)
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            //  command.CommandTimeout = 300;
                            command.CommandText = "UPDATE mark_info SET logo_pic=@logo_pic WHERE log_staff=@log_staff  ";

                            command.Connection.Open();
                            command.Parameters.Add("@logo_pic", SqlDbType.Text);
                           
                            command.Parameters.Add("@log_staff", SqlDbType.NChar, 50);

                            command.Parameters["@logo_pic"].Value = xpath;
                            command.Parameters["@log_staff"].Value = vlogstaff;
                            int h = Convert.ToInt32(command.ExecuteNonQuery());
                            command.Connection.Close();
                        }
                    }
                    if (command.Connection.State == ConnectionState.Open) { command.Connection.Close(); }
                }

                if (auth_doc != null)
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            //  command.CommandTimeout = 300;
                            command.CommandText = "UPDATE mark_info SET auth_doc=@auth_doc WHERE log_staff=@log_staff  ";

                            command.Connection.Open();
                           
                            command.Parameters.Add("@auth_doc", SqlDbType.Text);
                           
                            command.Parameters.Add("@log_staff", SqlDbType.NChar, 50);

                          
                            command.Parameters["@auth_doc"].Value = xauth_doc;
                          
                            command.Parameters["@log_staff"].Value = vlogstaff;
                            int h = Convert.ToInt32(command.ExecuteNonQuery());
                            command.Connection.Close();
                        }
                    }




                    if (command.Connection.State == ConnectionState.Open) { command.Connection.Close(); }

                }


                if (sup_doc1 != null)
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            //  command.CommandTimeout = 300;
                            command.CommandText = "UPDATE mark_info SET sup_doc1=@sup_doc1 WHERE log_staff=@log_staff  ";

                            command.Connection.Open();
                           
                            command.Parameters.Add("@sup_doc1", SqlDbType.Text);
                          
                            command.Parameters.Add("@log_staff", SqlDbType.NChar, 50);

                            command.Parameters["@sup_doc1"].Value = xsup_doc1;
                          
                            command.Parameters["@log_staff"].Value = vlogstaff;
                            int h = Convert.ToInt32(command.ExecuteNonQuery());
                            command.Connection.Close();
                        }
                    }


                    if (command.Connection.State == ConnectionState.Open) { command.Connection.Close(); }

                }



                if (sup_doc2 != null)
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            //  command.CommandTimeout = 300;
                            command.CommandText = "UPDATE mark_info SET sup_doc2=@sup_doc2 WHERE log_staff=@log_staff  ";

                            command.Connection.Open();
                           
                            command.Parameters.Add("@sup_doc2", SqlDbType.Text);
                            command.Parameters.Add("@log_staff", SqlDbType.NChar, 50);

                          
                            command.Parameters["@sup_doc2"].Value = xsup_doc2;
                            command.Parameters["@log_staff"].Value = vlogstaff;
                            int h = Convert.ToInt32(command.ExecuteNonQuery());
                            command.Connection.Close();
                        }
                    }


                    if (command.Connection.State == ConnectionState.Open) { command.Connection.Close(); }

                }
            }
            catch (Exception exception)
            {
                addxtest(exception.Message);
                //xID = "0";
                //XWriters pp = new XWriters();

                //string message = c_pwall.validationID + " " + DateTime.Now;

                //string vpath = System.Web.HttpContext.Current.Server.MapPath("~/") + "TradeMarkLog/NonGeneric/" + dd. c_pwall.validationID + ".txt";

                //pp.WriteToFile(message, vpath);
                //exception.ToString(); xID = "0";
                //   command.Connection.Close();
            }
            finally
            {

                //  xID = "0";
                // command.Connection.Close(); 
            }

            
            return xID;
        }


        public int updateUploadDate(string xid)
        {
            DateTime dd = DateTime.Now;
            SqlConnection connection = new SqlConnection(this.Connect());
            Boolean bb = true;
            SqlCommand command = new SqlCommand("UPDATE mark_info    SET upload_date= '" + dd + "'   WHERE log_staff='" + xid + "'  ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }


        public List<Email4> getEmails()
        {

            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT Admin_Mail.id,Admin_Mail.Subject,Admin_Mail.Message,Admin_Mail.Date_Sent,pwallet.validationid,pwallet.data_status,Admin_Mail.Agent_Code,Admin_Mail.Status,mark_info.product_title,pt_id,mark_info.reg_number FROM Admin_Mail inner join mark_info on Admin_Mail.pt_id = mark_info.xid inner join  pwallet on mark_info.log_staff = pwallet.id order by Date_Sent desc  ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            List<Email4> dd = new List<Email4>();
            while (reader.Read())
            {
                Email4 x = new Email4();
                x.id = Convert.ToInt32(reader["id"]);
                x.Subject = reader["Subject"].ToString();
                x.Message = reader["Message"].ToString();
                try
                {
                    x.Sent_Date = (reader["Date_Sent"]).ToString();

                }

                catch (Exception ee)
                {

                }

                x.Agent_Code = reader["Agent_Code"].ToString();
                x.Status = Convert.ToBoolean(reader["Status"]);
                x.pt_id = reader["pt_id"].ToString();
                x.reg_number = reader["reg_number"].ToString();
                x.Data_Status = reader["data_status"].ToString();
                x.Title = reader["product_title"].ToString();
                x.Online_Id = reader["validationid"].ToString();
                dd.Add(x);

            }
            reader.Close();
            return dd;
        }

        public List<Stage> getStageByUserID2(string ID)
        {
            List<Stage> list = new List<Stage>();
            new Stage();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE ID= (select log_staff from mark_info where xid='" + ID + "') ", connection);
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
                    amt = reader["amt"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    data_status = reader["data_status"].ToString()
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<Stage> getStageByUserID3(string ID)
        {
            List<Stage> list = new List<Stage>();
            new Stage();
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE id='" + ID + "'  ", connection);
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
                    amt = reader["amt"].ToString(),
                    reg_date = reader["reg_date"].ToString(),
                    data_status = reader["data_status"].ToString()
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
            SqlConnection connection = new SqlConnection(Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM mark_info WHERE xid='" + ID + "' ", connection);
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
        public int getEmailCount2(string status, string data_status)
        {
            int succ = 0;
            SqlConnection connection = new SqlConnection(this.Connect());
            Boolean bb = false;
            SqlCommand command = new SqlCommand("select count(Admin_Mail.id) AS cnt from Admin_Mail inner join mark_info on Admin_Mail.pt_id = mark_info.xid inner join  pwallet on mark_info.log_staff = pwallet.id where  pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' and   Admin_Mail.Status ='" + bb + "'   ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                try
                {
                    succ = Convert.ToInt32(reader["cnt"]);
                }
                catch (Exception ex)
                {
                    succ = 0;
                }
            }
            reader.Close();
            return succ;
        }

      

        public List<String> getEmailCount4(string status, string data_status)
        {
            String succ = "";
            SqlConnection connection = new SqlConnection(this.Connect());
            Boolean bb = false;
            List<String> jj = new List<string>();
            SqlCommand command = new SqlCommand("select Admin_mail.Recordal_id AS cnt from Admin_Mail inner join mark_info on Admin_Mail.pt_id = mark_info.xid inner join  pwallet on mark_info.log_staff = pwallet.id where  pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "'  and   Admin_Mail.Status ='" + bb + "'   ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                try
                {
                    succ = Convert.ToString(reader["cnt"]);
                    jj.Add(succ);
                }
                catch (Exception ex)
                {
                    succ = "";
                }
            }
            reader.Close();
            return jj;
        }

        public Email4 getOutboxEmail2(string xid)
        {

            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT * FROM Agent_Mail WHERE id='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            List<Email4> dd = new List<Email4>();
            Email4 x = new Email4();
            while (reader.Read())
            {

                x.id = Convert.ToInt32(reader["id"]);
                x.Subject = reader["Subject"].ToString();
                x.Message = reader["Message"].ToString();
                try
                {
                    x.Sent_Date = (reader["Date_Sent"]).ToString();

                }

                catch (Exception ee)
                {

                }

                x.Agent_Code = reader["Agent_Code"].ToString();


                //  dd.Add(x);

            }
            reader.Close();
            //  updateEmail(xid);
            return x;
        }

        public List<Email4> getOutboxEmails()
        {

            SqlConnection connection = new SqlConnection(this.ConnectXhome());
            SqlCommand command = new SqlCommand("SELECT id,Subject,Message,Date_Sent,agent_code,pt_id   FROM Agent_Mail where subject in ('Recordal Information','Kiv Information','Verification KIV Information','Acceptance KIV Information') order by Date_Sent desc  ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            List<Email4> dd = new List<Email4>();
            while (reader.Read())
            {
                Email4 x = new Email4();
                x.id = Convert.ToInt32(reader["id"]);
                x.Subject = reader["Subject"].ToString();
                x.Message = reader["Message"].ToString();
                try
                {
                    x.Sent_Date = (reader["Date_Sent"]).ToString();

                }

                catch (Exception ee)
                {

                }
                x.Agent_Code = reader["agent_code"].ToString();
                String vpt_id = reader["pt_id"].ToString();

              //  List<PtInfo> dx = getPtInfoByPwalletID(vpt_id);

                List<Stage> dx2 = getStageByUserID3(vpt_id);

                tm xxd = new tm();
               cld.Classes.tm.MarkInfo ds = xxd.getMarkInfoClassByUserID(vpt_id);

                x.Title = ds.product_title;
                x.Online_Id = dx2[0].validationID;

                dd.Add(x);

            }
            reader.Close();
            return dd;
        }

      
        public String getEmailCount3(string status, string data_status)
        {
            int succ = 0;
            String succ2 = null;
            SqlConnection connection = new SqlConnection(this.Connect());
            Boolean bb = false;
            SqlCommand command = new SqlCommand("select count(Admin_Mail.id) AS cnt from Admin_Mail inner join mark_info on Admin_Mail.pt_id = mark_info.xid inner join  pwallet on mark_info.log_staff = pwallet.id  where  pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' and Admin_Mail.Status ='" + bb + "'   ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                try
                {
                    succ = Convert.ToInt32(reader["cnt"]);
                }
                catch (Exception ex)
                {
                    succ = 0;
                }
            }
            reader.Close();
            if (succ > 0)
            {

                succ2 = succ + " UNREAD NOTIFICATIONS";
            }

            else
            {
                succ2 = null;
            }

            return succ2;
        }
        public Email4 getEmail2(string xid)
        {

            SqlConnection connection = new SqlConnection(this.Connect());
            SqlCommand command = new SqlCommand("SELECT * FROM Admin_Mail WHERE id='" + xid + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            List<Email4> dd = new List<Email4>();
            Email4 x = new Email4();
            while (reader.Read())
            {

                x.id = Convert.ToInt32(reader["id"]);
                x.Subject = reader["Subject"].ToString();
                x.Message = reader["Message"].ToString();
                try
                {
                    x.Sent_Date = (reader["Date_Sent"]).ToString();

                }

                catch (Exception ee)
                {

                }

                x.Agent_Code = reader["Agent_Code"].ToString();

                x.pt_id = reader["pt_id"].ToString();
                x.reg_number = reader["reg_number"].ToString();
                x.Data_Status = getStageByUserID2(x.pt_id)[0].data_status;
                x.Status2 = getStageByUserID2(x.pt_id)[0].status;
                x.Online_Id = getStageByUserID2(x.pt_id)[0].validationID;
                //  dd.Add(x);

            }
            reader.Close();
            updateEmail(xid);
            return x;
        }

        public int updateEmail(string xid)
        {
            SqlConnection connection = new SqlConnection(this.Connect());
            Boolean bb = true;
            SqlCommand command = new SqlCommand("UPDATE Admin_Mail  SET Status= '" + bb + "'   WHERE id='" + xid + "'  ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public void AddAdminMail(string agent_code, String Subject, String Message, String reg_number, String pt_id, String dd2)
        {
            string str = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str2 = DateTime.Now.ToLongTimeString();
            string connectionString = Connect();
            string str4 = "0";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Admin_Mail (Message,Subject,Date_Sent,Agent_Code,Status,pt_id,reg_number,Recordal_id) VALUES (@Message,@Subject,@Date_Sent,@Agent_Code,@Status,@pt_id,@reg_number,@Recordal_id) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@Message", SqlDbType.NVarChar, 500);
            command.Parameters.Add("@Subject", SqlDbType.NVarChar, 500);
            command.Parameters.Add("@Date_Sent", SqlDbType.DateTime);
            command.Parameters.Add("@Agent_Code", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@pt_id", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@Recordal_id", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@reg_number", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@Status", SqlDbType.Bit);

            command.Parameters["@Message"].Value = Message;
            command.Parameters["@Subject"].Value = Subject;
            command.Parameters["@Date_Sent"].Value = DateTime.Now;
            command.Parameters["@Agent_Code"].Value = agent_code;
            command.Parameters["@pt_id"].Value = pt_id;
            command.Parameters["@Recordal_id"].Value = dd2;
            command.Parameters["@reg_number"].Value = reg_number;
            command.Parameters["@Status"].Value = 0;

            foreach (SqlParameter Parameter in command.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

            str4 = command.ExecuteScalar().ToString();
            connection.Close();

        }

        public string UpdateTrademarkTx(string  dd, string dd2, HttpPostedFile logo_pic, HttpPostedFile auth_doc, HttpPostedFile sup_doc1, HttpPostedFile sup_doc2, string serverpath)
        {
            tm vtm = new tm();
      cld.Classes.tm.MarkInfo xxk  = vtm.getMarkInfoClassByUserID2(dd);
      List<Agent_FileUpload> ts = new List<Agent_FileUpload>();
            Retriever ret = new Retriever();
            string xID = null; int pID = 0;
            string xauth_doc = ""; string xsup_doc1 = ""; string xsup_doc2 = ""; string xpath = "";
            string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string xtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            string xvisible = "1"; string xsync = "0";

            SqlConnection connection; SqlCommand command;
            string connectionString = Connect();
            //c_pwall.reg_date = reg_date;
            //c_pwall.xtime = c_pwall.log_officer + ": " + xtime;
            //c_pwall.visible = xvisible; c_pwall.status = "1"; c_pwall.stage = "5"; c_pwall.data_status = "Fresh";
            //c_pwall.acc_p = "0"; c_pwall.rtm = "0"; 
            int app_addyID = 0;

            int rep_addyID = 0;
            int cert_infoID = 0;



            try
            {
               

              
                xID = dd;
                try
                {
                    if (logo_pic != null) { xpath = doUploadPic(xID, xID + ".jpg", serverpath + "admin/tm/Picz/", logo_pic); }
                }

                catch (Exception ee)
                {

                }
                try
                {
                    if (auth_doc != null) { xauth_doc = doUploadDoc(xID, serverpath + "admin/tm/docz/", auth_doc); }

                }
                catch (Exception ee)
                {

                }
                try
                {
                    if (sup_doc1 != null) { xsup_doc1 = doUploadDoc(xID, serverpath + "admin/tm/docz/", sup_doc1); }
                }

                catch (Exception ee)
                {

                }
                try
                {
                    if (sup_doc2 != null) { xsup_doc2 = doUploadDoc(xID, serverpath + "admin/tm/docz/", sup_doc2); }

                }
                catch (Exception ee)
                {

                }
                try
                {
                    if (logo_pic != null)
                    {
                        xpath = xpath.Replace(serverpath + "admin/tm/", "");

                        Agent_FileUpload dd3 = new Agent_FileUpload();
                        dd3.new_file = xpath;
                        dd3.old_file = xxk.logo_pic;
                        ts.Add(dd3);

                    }
                    else
                    {
                        xpath = xxk.logo_pic;

                    }
                }
                catch (Exception ee)
                {

                }
                try
                {
                    if (sup_doc2 != null)
                    {
                        xsup_doc2 = xsup_doc2.Replace(serverpath + "admin/tm/", "");

                        Agent_FileUpload dd3 = new Agent_FileUpload();
                        dd3.new_file = xsup_doc2;
                        dd3.old_file = xxk.sup_doc2;
                        ts.Add(dd3);
                    }
                    else
                    {
                        xsup_doc2 = xxk.sup_doc2;
                    }
                }
                catch (Exception ee)
                {

                }
                try
                {
                    if (sup_doc1 != null)
                    {
                        xsup_doc1 = xsup_doc1.Replace(serverpath + "admin/tm/", "");

                        Agent_FileUpload dd3 = new Agent_FileUpload();
                        dd3.new_file = xsup_doc1;
                        dd3.old_file = xxk.sup_doc1;
                        ts.Add(dd3);
                    }
                    else
                    {
                        xsup_doc1 = xxk.sup_doc1;
                    }
                }
                catch (Exception ee)
                {

                }
                try
                {
                    if (auth_doc != null)
                    {
                        xauth_doc = xauth_doc.Replace(serverpath + "admin/tm/", "");

                        Agent_FileUpload dd3 = new Agent_FileUpload();
                        dd3.new_file = xauth_doc;
                        dd3.old_file = xxk.auth_doc;
                        ts.Add(dd3);
                    }
                    else
                    {
                        xauth_doc = xxk.auth_doc;
                    }
                }
                catch (Exception ee)
                {

                }

                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        //  command.CommandTimeout = 300;
                        command.CommandText = "UPDATE mark_info SET logo_pic=@logo_pic,auth_doc=@auth_doc,sup_doc1=@sup_doc1,sup_doc2=@sup_doc2 WHERE xid=@log_staff  ";

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
                        command.Parameters["@log_staff"].Value = dd;
                        int h = Convert.ToInt32(command.ExecuteNonQuery());
                        command.Connection.Close();
                    }
                }

           
                if (command.Connection.State == ConnectionState.Open) { command.Connection.Close(); }
            }
            catch (Exception exception)
            {
                //xID = "0";
                //XWriters pp = new XWriters();

                //string message = c_pwall.validationID + " " + DateTime.Now;

                //string vpath = System.Web.HttpContext.Current.Server.MapPath("~/") + "TradeMarkLog/NonGeneric/" + dd. c_pwall.validationID + ".txt";

                //pp.WriteToFile(message, vpath);
                //exception.ToString(); xID = "0";
                //   command.Connection.Close();
            }
            finally
            {

                //  xID = "0";
                // command.Connection.Close(); 
            }
            tm xtm = new tm();
            updateUploadDate(xxk.log_staff);
            String xsubject = "upload from Recordal  application  with number " + xxk.reg_number;
          //  DateTime xxs = DateTime.Now;
            List<tm.Stage> xxl = xtm.getStageByUserID(xxk.log_staff);

            DateTime xxs = DateTime.Now;
            foreach (Agent_FileUpload Agent_FileUpload in ts)
            {

                Agent_FileUpload.agent_code = xxl[0].applicantID;
                Agent_FileUpload.Date_Uploaded = xxs;

                Agent_FileUpload.Status = xxl[0].data_status;
                Agent_FileUpload.pt_id = xxl[0].validationID;

                AddAgentUpload_Log(Agent_FileUpload);

            }

            AddAdminMail(xxl[0].applicantID, "upload from Recordal  application ", xsubject, xxk.reg_number, xxk.xID,dd2);
            return xID;
        }

        public string UpdateTrademarkTx2(string dd, string dd2, HttpPostedFile logo_pic, HttpPostedFile auth_doc, HttpPostedFile sup_doc1, HttpPostedFile sup_doc2, string serverpath)
        {
            tm vtm = new tm();
            cld.Classes.tm.MarkInfo xxk = vtm.getMarkInfoClassByUserID2(dd);
            List<Agent_FileUpload> ts = new List<Agent_FileUpload>();
            Retriever ret = new Retriever();
            string xID = null; int pID = 0;
            string xauth_doc = ""; string xsup_doc1 = ""; string xsup_doc2 = ""; string xpath = "";
            string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string xtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            string xvisible = "1"; string xsync = "0";

            SqlConnection connection; SqlCommand command;
            string connectionString = Connect();
            //c_pwall.reg_date = reg_date;
            //c_pwall.xtime = c_pwall.log_officer + ": " + xtime;
            //c_pwall.visible = xvisible; c_pwall.status = "1"; c_pwall.stage = "5"; c_pwall.data_status = "Fresh";
            //c_pwall.acc_p = "0"; c_pwall.rtm = "0"; 
            int app_addyID = 0;

            int rep_addyID = 0;
            int cert_infoID = 0;



            try
            {



                xID = dd;
                try
                {
                    if (logo_pic != null) { xpath = doUploadPic(xID, xID + ".jpg", serverpath + "admin/tm/Picz/", logo_pic); }
                }

                catch (Exception ee)
                {

                }
                try
                {
                    if (auth_doc != null) { xauth_doc = doUploadDoc(xID, serverpath + "admin/tm/docz/", auth_doc); }

                }
                catch (Exception ee)
                {

                }
                try
                {
                    if (sup_doc1 != null) { xsup_doc1 = doUploadDoc(xID, serverpath + "admin/tm/docz/", sup_doc1); }
                }

                catch (Exception ee)
                {

                }
                try
                {
                    if (sup_doc2 != null) { xsup_doc2 = doUploadDoc(xID, serverpath + "admin/tm/docz/", sup_doc2); }

                }
                catch (Exception ee)
                {

                }
                try
                {
                    if (logo_pic != null)
                    {
                        xpath = xpath.Replace(serverpath + "admin/tm/", "");

                        Agent_FileUpload dd3 = new Agent_FileUpload();
                        dd3.new_file = xpath;
                        dd3.old_file = xxk.logo_pic;
                        ts.Add(dd3);

                    }
                    else
                    {
                        xpath = xxk.logo_pic;

                    }
                }
                catch (Exception ee)
                {

                }
                try
                {
                    if (sup_doc2 != null)
                    {
                        xsup_doc2 = xsup_doc2.Replace(serverpath + "admin/tm/", "");

                        Agent_FileUpload dd3 = new Agent_FileUpload();
                        dd3.new_file = xsup_doc2;
                        dd3.old_file = xxk.sup_doc2;
                        ts.Add(dd3);
                    }
                    else
                    {
                        xsup_doc2 = xxk.sup_doc2;
                    }
                }
                catch (Exception ee)
                {

                }
                try
                {
                    if (sup_doc1 != null)
                    {
                        xsup_doc1 = xsup_doc1.Replace(serverpath + "admin/tm/", "");

                        Agent_FileUpload dd3 = new Agent_FileUpload();
                        dd3.new_file = xsup_doc1;
                        dd3.old_file = xxk.sup_doc1;
                        ts.Add(dd3);
                    }
                    else
                    {
                        xsup_doc1 = xxk.sup_doc1;
                    }
                }
                catch (Exception ee)
                {

                }
                try
                {
                    if (auth_doc != null)
                    {
                        xauth_doc = xauth_doc.Replace(serverpath + "admin/tm/", "");

                        Agent_FileUpload dd3 = new Agent_FileUpload();
                        dd3.new_file = xauth_doc;
                        dd3.old_file = xxk.auth_doc;
                        ts.Add(dd3);
                    }
                    else
                    {
                        xauth_doc = xxk.auth_doc;
                    }
                }
                catch (Exception ee)
                {

                }

                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        //  command.CommandTimeout = 300;
                        command.CommandText = "UPDATE mark_info SET logo_pic=@logo_pic,auth_doc=@auth_doc,sup_doc1=@sup_doc1,sup_doc2=@sup_doc2 WHERE xid=@log_staff  ";

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
                        command.Parameters["@log_staff"].Value = dd;
                        int h = Convert.ToInt32(command.ExecuteNonQuery());
                        command.Connection.Close();
                    }
                }


                if (command.Connection.State == ConnectionState.Open) { command.Connection.Close(); }
            }
            catch (Exception exception)
            {
                //xID = "0";
                //XWriters pp = new XWriters();

                //string message = c_pwall.validationID + " " + DateTime.Now;

                //string vpath = System.Web.HttpContext.Current.Server.MapPath("~/") + "TradeMarkLog/NonGeneric/" + dd. c_pwall.validationID + ".txt";

                //pp.WriteToFile(message, vpath);
                //exception.ToString(); xID = "0";
                //   command.Connection.Close();
            }
            finally
            {

                //  xID = "0";
                // command.Connection.Close(); 
            }
            tm xtm = new tm();
            updateUploadDate(xxk.log_staff);
            String xsubject = "upload from Trademark  application  with number " + xxk.reg_number;
            //  DateTime xxs = DateTime.Now;
            List<tm.Stage> xxl = xtm.getStageByUserID(xxk.log_staff);

            DateTime xxs = DateTime.Now;
            foreach (Agent_FileUpload Agent_FileUpload in ts)
            {

                Agent_FileUpload.agent_code = xxl[0].applicantID;
                Agent_FileUpload.Date_Uploaded = xxs;

                Agent_FileUpload.Status = xxl[0].data_status;
                Agent_FileUpload.pt_id = xxl[0].validationID;

                AddAgentUpload_Log(Agent_FileUpload);

            }

            AddAdminMail(xxl[0].applicantID, "upload from Trademark  application ", xsubject, xxk.reg_number, xxk.xID, dd2);
            return xID;
        }

        public void AddAgentUpload_Log(Agent_FileUpload dd)
        {
            string str = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string str2 = DateTime.Now.ToLongTimeString();
            string connectionString = Connect();
            string str4 = "0";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Agent_FileUpload (agent_code,old_file,new_file,Date_Uploaded,Status,pt_id) VALUES (@agent_code,@old_file,@new_file,@Date_Uploaded,@Status,@pt_id) SELECT SCOPE_IDENTITY()";
            connection.Open();
            command.Parameters.Add("@agent_code", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@old_file", SqlDbType.NVarChar, 500);
            command.Parameters.Add("@new_file", SqlDbType.NVarChar, 500);
            command.Parameters.Add("@Date_Uploaded", SqlDbType.DateTime);
            command.Parameters.Add("@Status", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@pt_id", SqlDbType.NVarChar, 50);


            command.Parameters["@agent_code"].Value = dd.agent_code;
            command.Parameters["@old_file"].Value = dd.old_file;
            command.Parameters["@new_file"].Value = dd.new_file;
            command.Parameters["@Date_Uploaded"].Value = dd.Date_Uploaded;
            command.Parameters["@Status"].Value = dd.Status;
            command.Parameters["@pt_id"].Value = dd.pt_id;


            str4 = command.ExecuteScalar().ToString();
            connection.Close();

        }


        public string doUploadDoc(string ID, string path, HttpPostedFile fu)
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
        public string doUploadPic(string ID, string newfilename, string path,HttpPostedFile  fu)
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
            catch (Exception ee)
            {
               
               
                return "";
            }
        }

        public string doUploadUpDoc(string ID, string path, string oldpath, HttpPostedFile fu)
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

        public int updateHwallet(string xid, string used_status, string used_date, string product_title)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("UPDATE hwallet SET used_status='" + used_status + "',product_title='" + product_title + "',used_date='" + used_date + "'  WHERE xid='" + xid + "'  ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int updatePwalletProfile(string xid, string xemail, string xmobile, string xpass, string addressID)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("UPDATE pwallet SET xemail='" + xemail + "',xmobile='" + xmobile + "',xpass='" + xpass + "'  WHERE xid='" + xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return this.updateAddressProfile(addressID, xemail, xmobile);
        }

        public int updateTwallet(string transID, string xbankerID, string xmemberID)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("UPDATE twallet SET xbankerID='" + xbankerID + "',xpay_status='1'  WHERE transID='" + transID + "' AND xmemberID='" + xmemberID + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int updateUsedFee_details(string xid, string xused)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("UPDATE xmember SET xused='" + xused + "' WHERE xid='" + xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int updateXpayAgent(string xid, string sys_ID)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("UPDATE G_Agent_info SET sys_ID='" + sys_ID + "' WHERE xid='" + xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int updateXpayBanker(string xid, string sys_ID)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("UPDATE xbanker SET sys_ID='" + sys_ID + "' WHERE xid='" + xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }

        public int updateXpayMember(string xid, string sys_ID)
        {
            SqlConnection connection = new SqlConnection(this.ConnectXpay());
            SqlCommand command = new SqlCommand("UPDATE xmember SET sys_ID='" + sys_ID + "' WHERE xid='" + xid + "' ", connection);
            connection.Open();
            int num = command.ExecuteNonQuery();
            connection.Close();
            return num;
        }
    }
}