using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Script.Serialization;
using static cld.Classes.tm;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for TestUpload
    /// </summary>
    public class TestUpload : IHttpHandler
    {
        Registration ppa = new Registration();
        HttpPostedFile fu_logo_pic = null;
        HttpPostedFile fu_sup_doc = null;
        HttpPostedFile fu_sup_doc2 = null;
        HttpPostedFile fu_auth_doc = null;
        
        public void ProcessRequest(HttpContext context)
        {

            JavaScriptSerializer ser = new JavaScriptSerializer();
           
            var pp2 = context.Request["logstaff"];

            Registration xxp = new Registration();
            List<MarkInfo> zz = xxp.getMarkInfoByUserID(pp2);
          //  var pp3 = context.Request["docttype"];

               ppa.addxtest(zz[0].log_staff);



            if (context.Request.Files.Count > 0)
            {
               // ppa.addxtest("upload exist");

                var files = new List<string>();



                // interate the files and save on the server
                foreach (string file in context.Request.Files)
                {
                    if (file == "logo_pic")
                    {
                        fu_logo_pic =  context.Request.Files[file];

                        
                   //     ppa.addxtest(fu_logo_pic.FileName);


                    }


                    if (file == "auth_doc")
                    {
                         fu_auth_doc = context.Request.Files[file];


                        //     ppa.addxtest(fu_logo_pic.FileName);


                    }

                    if (file == "sup_doc1")
                    {
                        fu_sup_doc = context.Request.Files[file];


                        //     ppa.addxtest(fu_logo_pic.FileName);


                    }


                    if (file == "sup_doc2")
                    {
                        fu_sup_doc2 = context.Request.Files[file];


                        //     ppa.addxtest(fu_logo_pic.FileName);


                    }

                    var ppx = "";
                    //  dd.File_path = "/Images/Patient/" + vfile;




                }
            }

            string serverpath = context.Server.MapPath("~/");
            Registration tt = new Registration();


         string    vt = tt.UploadTrademarkTx(zz[0].log_staff,
    fu_logo_pic, fu_auth_doc, fu_sup_doc, fu_sup_doc2, serverpath);


           


            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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