using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for UpdateApplicantAddress
    /// </summary>
    public class UpdateApplicantAddress : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string new_hash = "";


            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];
            var pp2 = context.Request["vv2"];
            var pp3 = context.Request["vv3"];
            var pp4 = context.Request["vv4"];

            // var pp = "1134";

            cld.Classes.zues ff = new cld.Classes.zues();

            Int32 vip = ff.update_recordal2(pp, pp2, pp3, pp4);
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