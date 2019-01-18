using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using cld.Classes;
using System.IO;
using System.Threading;
using System.Text;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for UpdateApplicant3
    /// </summary>
    public class UpdateApplicant3 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string new_hash = "";


            JavaScriptSerializer ser = new JavaScriptSerializer();
            //var pp = context.Request["vv"];
            //var pp2 = context.Request["vv2"];
            //var pp3 = context.Request["vv3"];
            //var pp4 = context.Request["vv4"];
            //var pp5 = context.Request["vv5"];
            //var pp6 = context.Request["vv6"];
            //var pp7 = context.Request["vv7"];
            //var pp8 = context.Request["vv8"];

            var pp = context.Request["vv"];
            string vfile1 = "";
            string vfile2 = "";
            string vfile3 = "";

            RegisteredUsers dd = ser.Deserialize<RegisteredUsers>(pp);


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
                        string serverpath = context.Server.MapPath("~/");
                        string ssp = Generate15UniqueDigits();

                        String xpath = doUploadPic(ssp, vfile, serverpath + "admin/tm/Picz/", postedFile);

                        xpath = xpath.Replace(serverpath + "admin/tm/", "");

                        vfile3 = xpath;




                    }

                }


            }

            cld.Classes.zues ff = new cld.Classes.zues();
           // Recordal_Result sp = ff.InsertRecordalB(pp, pp2, pp3, pp4, pp5, pp6,pp7,pp8);
            Recordal_Result sp = ff.InsertRecordalB(dd.vv, dd.vv2, dd.vv3, dd.vv4, dd.vv5, dd.vv6,dd.vv7, dd.vv8, vfile1, vfile2, vfile3);
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