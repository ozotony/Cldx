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
    /// Summary description for Save_GenericApplication3
    /// </summary>
    public class Save_GenericApplication3 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string new_hash = "";
            //  string ccode = ConfigurationManager.AppSettings["ccode"]; string xcode = ConfigurationManager.AppSettings["xcode"];

            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];
            var pp2 = context.Request["vid"];



            HttpPostedFile fu_logo_pic = null;
            HttpPostedFile fu_sup_doc = null;
            HttpPostedFile fu_app_doc = null;
            HttpPostedFile fu_merger_doc = null;
            HttpPostedFile fu_ass_doc = null;
            HttpPostedFile fu_pub_doc = null;
            HttpPostedFile fu_cert_doc = null;


           

           



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
            

            vt = tt.UpdateTrademarkTx(pp,pp2,
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