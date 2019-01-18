using cld.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for UpdateApplicant5
    /// </summary>
    public class UpdateApplicant5 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];

            Recordal_Data dd = ser.Deserialize<Recordal_Data>(pp);

            string vfile1 = "";
            string vfile2 = "";
            string vfile3 = "";
            string vfile4 = "";
            string vfile5 = "";
            string vfile6 = "";
            string vfile7 = "";
            string vfile8 = "";


            if (context.Request.Files.Count > 0)
            {
                var files = new List<string>();

                foreach (string file in context.Request.Files)
                {
                    if (file == "FileUpload")
                    {

                        var postedFile = context.Request.Files[file];
                        var vfile = postedFile.FileName.Replace("\"", string.Empty).Replace("'", string.Empty);
                        vfile = Stp(vfile);
                        string FileName = context.Server.MapPath("~/admin/ag_docz/" + vfile);
                        string serverpath = context.Server.MapPath("~/");
                        string ssp = Generate15UniqueDigits();

                        String xpath = doUploadPic(ssp, vfile, serverpath + "admin/tm/Picz/", postedFile);

                        xpath = xpath.Replace(serverpath + "admin/tm/", "");

                        vfile1 = xpath;




                    }

                    if (file == "FileUpload2")
                    {

                        var postedFile = context.Request.Files[file];
                        var vfile = postedFile.FileName.Replace("\"", string.Empty).Replace("'", string.Empty);
                        vfile = Stp(vfile);
                        string FileName = context.Server.MapPath("~/admin/ag_docz/" + vfile);
                        //   dd.cac_file = "/images/" + vfile;
                        string serverpath = context.Server.MapPath("~/");
                        string ssp = Generate15UniqueDigits();

                        String xpath = doUploadPic(ssp, vfile, serverpath + "admin/tm/Picz/", postedFile);

                        xpath = xpath.Replace(serverpath + "admin/tm/", "");

                        vfile2 = xpath;

                    }

                    if (file == "FileUpload3")
                    {

                        var postedFile = context.Request.Files[file];
                        var vfile = postedFile.FileName.Replace("\"", string.Empty).Replace("'", string.Empty);
                        vfile = Stp(vfile);
                        string FileName = context.Server.MapPath("~/admin/ag_docz/" + vfile);
                        //   dd.cac_file = "/images/" + vfile;
                        string serverpath = context.Server.MapPath("~/");
                        string ssp = Generate15UniqueDigits();

                        String xpath = doUploadPic(ssp, vfile, serverpath + "admin/tm/Picz/", postedFile);

                        xpath = xpath.Replace(serverpath + "admin/tm/", "");

                        vfile3 = xpath;





                    }

              

                  

                 


                   


                }


            }

                 cld.Classes.zues ff = new cld.Classes.zues();
                 string xk = ff.InsertRecordal5(dd.vv, dd.vv2, dd.vv4, dd.vv3, dd.vv6, dd.vv5, dd.vv16, dd.vv7, dd.vv8, vfile4, vfile5, vfile6, vfile7, vfile8, dd.vv9, dd.vv10, dd.vv11, dd.vv12, vfile1, vfile2, vfile3, dd.vv17);

                 Recordal_Result xk2 = ff.InsertRecordal6(dd.vv13, dd.vv14, dd.vv15, xk,dd.vv18);

                 context.Response.ContentType = "application/json";
                 context.Response.Write(ser.Serialize(xk2));
              //  string xk = ff.InsertRecordal4(dd.vv, dd.vv2, dd.vv3, dd.vv4, dd.vv5, "", "", dd.vv7);

            
        }

        public string Stp(string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (!char.IsWhiteSpace(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }


        static object locker = new object();
        static string Generate15UniqueDigits()
        {
            lock (locker)
            {
                Thread.Sleep(100);
                return DateTime.Now.ToString("yyyyMMddHHmmssf");
            }
        }

        public string doUploadPic(string ID, string newfilename, string path, HttpPostedFile fu)
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}