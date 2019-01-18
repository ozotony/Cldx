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
    /// Summary description for AppealRejection
    /// </summary>
    public class AppealRejection : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];
            string vfile1 = "";

            Encrypt2 dd = ser.Deserialize<Encrypt2>(pp);
            //var pp = context.Request["vv"];
            //var pp2 = context.Request["vv2"];
            //var pp3 = context.Request["vv3"];
            //var pp4 = context.Request["vv4"];
            //var pp5 = context.Request["vv5"];

            //var pp6 = context.Request["ff"];
            //var pp7 = context.Request["ff2"];
            //var pp8 = context.Request["ff3"];
            //var pp9 = context.Request["ff4"];
            //var pp10 = context.Request["ff5"];


            //var pp11 = context.Request["ff6"];
            //var pp12 = context.Request["ff7"];
            //var pp13 = context.Request["ff8"];


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

                }


            }

            cld.Classes.zues ff = new cld.Classes.zues();
            string  sp = ff.PendingAppeal(dd.vv, dd.vv4, dd.vv3, dd.vv2, vfile1);
            // String vip = ff.getApplicantName(pp);
            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(sp));
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