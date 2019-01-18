using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cld.Classes;
namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetOutbox_Email
    /// </summary>
    public class GetOutbox_Email : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            
            //  var pp = context.Request["vid"];
            Registration zz = new Registration();
            System.Collections.Generic.List<Email4> kk = zz.getOutboxEmails();
            ser.MaxJsonLength = Int32.MaxValue;

            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(kk));
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