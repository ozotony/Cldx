using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cld.Classes;
using System.Web.Script.Serialization;
namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetEmailCount
    /// </summary>
    public class GetEmailCount : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var pp = context.Request["vid"];
            var pp3 = context.Request["vid2"];
            String dd = "";
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Registration pp2 = new Registration();
            //  pp2.updateEmail(pp);
            Int32 kk = pp2.getEmailCount2(pp, pp3);




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