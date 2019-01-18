using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for Save_GenericApplication2
    /// </summary>
    public class Save_GenericApplication2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string new_hash = "";
            //  string ccode = ConfigurationManager.AppSettings["ccode"]; string xcode = ConfigurationManager.AppSettings["xcode"];

            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];

            Cld_Generic dd = ser.Deserialize<Cld_Generic>(pp);

            XObjs.G_Pwallet c_pwall = new XObjs.G_Pwallet();

            XObjs.G_App_info g_app_info = new XObjs.G_App_info();
            XObjs.G_Applicant_info g_applicant_info = new XObjs.G_Applicant_info();
            XObjs.G_Tm_info g_tm_info = new XObjs.G_Tm_info();
            XObjs.G_Ass_info g_ass_info = new XObjs.G_Ass_info();
            XObjs.G_Merger_info g_merger_info = new XObjs.G_Merger_info();
            XObjs.G_Cert_info g_cert_info = new XObjs.G_Cert_info();
            XObjs.G_Change_info g_change_info = new XObjs.G_Change_info();
            XObjs.G_Renewal_info g_renewal_info = new XObjs.G_Renewal_info();
            XObjs.G_Prelim_search_info g_prelim_search_info = new XObjs.G_Prelim_search_info();
            XObjs.G_Other_items_info g_other_items_info = new XObjs.G_Other_items_info();
            XObjs.Gen_Agent_info g_agent_info = new XObjs.Gen_Agent_info();

            HttpPostedFile fu_logo_pic = null;
            HttpPostedFile fu_sup_doc = null;
            HttpPostedFile fu_app_doc = null;
            HttpPostedFile fu_merger_doc = null;
            HttpPostedFile fu_ass_doc = null;
            HttpPostedFile fu_pub_doc = null;
            HttpPostedFile fu_cert_doc = null;


            c_pwall.twalletID = "0";
            c_pwall.validationID = "0"; // vid;
            c_pwall.applicantID = dd.Agent_Code;  //agt;
            c_pwall.log_officer = dd.Application_Type;// item_code;
            c_pwall.amt = dd.amount;// amt;


            g_app_info.filing_date = dd.Application_Date;
            g_app_info.application_no = dd.Application_No;
            g_app_info.rtm_number = dd.Rtm_No;
            g_app_info.item_code = dd.Application_Type;// item_code;
            g_app_info.log_staff = "0";
            g_app_info.reg_no = dd.Application_No;
            g_app_info.reg_date = dd.Application_Date;
            g_app_info.visible = "0";


            g_applicant_info.trading_as = dd.Trading_As;
            g_applicant_info.visible = "0";
            g_applicant_info.address = dd.Applicant_Address;
            g_applicant_info.xemail = dd.Applicant_Email;
            g_applicant_info.xmobile = dd.Applicant_Phone;
            g_applicant_info.xname = dd.Applicant_name;
            g_applicant_info.nationality = dd.Nationality;
            g_applicant_info.log_staff = "0";

           
            g_tm_info.disclaimer = dd.Txt_Discalimer;
            g_tm_info.tm_class = dd.Trademark_Class;
            g_tm_info.tm_desc = dd.Goods_Desc;
            g_tm_info.tm_title = dd.Title_Of_Trademark;
            g_tm_info.xtype = dd.Trademark_Type;
            g_tm_info.reg_number = dd.Application_No; ;
            g_tm_info.logo_descID = dd.Logo_Desc;

            g_tm_info.logo_pic = "";
            g_tm_info.auth_doc = "";
            g_tm_info.sup_doc1 = "";
            g_tm_info.app_letter_doc = "";
            g_tm_info.log_staff = "0";
            g_tm_info.reg_date = dd.Application_Date;
            g_tm_info.visible = "0";

            g_agent_info.code = dd.Agent_Code;  //agt;
            g_agent_info.xname = dd.Rep_Xname;
            g_agent_info.xpassword = "";
            g_agent_info.nationality = dd.Agent_Rep_Nationality;
            g_agent_info.country = dd.Agent_Nationality;
            g_agent_info.state = dd.Agent_State;
            g_agent_info.address = dd.rep_address;
            g_agent_info.telephone = dd.Rep_telephone;
            g_agent_info.email = dd.Rep_email;
            g_agent_info.log_staff = "0";
            g_agent_info.xsync = "0";


            g_cert_info.log_staff = "0";
            g_cert_info.reg_date = dd.Application_Date;
            g_cert_info.xvisible = "0";
            g_cert_info.pub_date = dd.Cert_publicationdate;
            g_cert_info.pub_details = dd.cert_details;
            g_cert_info.cert_doc = "";
            g_cert_info.pub_doc = "";




            if (context.Request.Files.Count > 0)
            {
                var files = new List<string>();



                // interate the files and save on the server
                foreach (string file in context.Request.Files)
                {
                    if (file == "FileUpload")
                    {

                        fu_logo_pic = context.Request.Files[file];
                        //  var vfile = postedFile.FileName.Replace("\"", string.Empty).Replace("'", string.Empty);
                        //   vfile = Stp(vfile);
                        //  string FileName = context.Server.MapPath("~/admin/ag_docz/" + vfile);
                        //   dd.cac_file = "/images/" + vfile;

                        //  dd.cac_file = "admin/ag_docz/" + vfile;

                        //  postedFile.SaveAs(FileName);



                    }

                    if (file == "FileUpload2")
                    {

                        fu_app_doc = context.Request.Files[file];


                    }

                    if (file == "FileUpload3")
                    {

                        fu_cert_doc = context.Request.Files[file];


                    }

                    if (file == "FileUpload4")
                    {

                        fu_pub_doc = context.Request.Files[file];


                    }
                    //  dd.File_path = "/Images/Patient/" + vfile;




                }
            }
            GetData gg = new GetData();
            string sp = "";

            string serverpath = context.Server.MapPath("~/");
            Registration tt = new Registration();
            TransactionOptions transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = new TimeSpan(0, 15, 0)
            };
            TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
            String vt = null;

           vt = tt.addTrademarkTx(dd,
   fu_logo_pic, fu_app_doc, fu_cert_doc, fu_pub_doc, serverpath);

           if (vt != null)
           {

               scope.Complete(); scope.Dispose();
           }

           else
           {
               scope.Dispose();
               throw new Exception("Test Exception");

           }
           


            //  string sp = gg.addAgent(dd);

            //   Ipong.Classes.Retriever kp = new Ipong.Classes.Retriever();



            //  sendemail(dd.Email, dd.CompName, sp);
            try
            {
                //  kp.updateRegistrationSysID4(sp, "PENDING");
            }
            catch (Exception ee)
            {

            }
            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(vt));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}