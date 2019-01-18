using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetApplicant2
    /// </summary>
    public class GetApplicant2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string new_hash = "";
         

            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];

            Applicant dd = ser.Deserialize<Applicant>(pp);

            cld.Classes.zues ff = new cld.Classes.zues();

            Int32 vip = ff.UpdateApplicant(dd);
            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(vip));
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