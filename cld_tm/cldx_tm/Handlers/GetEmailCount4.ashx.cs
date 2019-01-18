using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cld.Classes;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetEmailCount4
    /// </summary>
    public class GetEmailCount4 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var pp = context.Request["vid"];
            var pp3 = context.Request["vid2"];
            var pp4 = context.Request["vid3"];
            String dd = "";
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Registration pp2 = new Registration();
            //  pp2.updateEmail(pp);
            System.Collections.Generic.List<String> kk = pp2.getEmailCount4(pp, pp3);




            // XObjs.Registration kk = pp2.getRegistrationBySubagentRegistrationID(pp);



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