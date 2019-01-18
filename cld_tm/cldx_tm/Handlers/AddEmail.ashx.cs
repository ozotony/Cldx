using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for AddEmail
    /// </summary>
    public class AddEmail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var pp = context.Request["vid"];

            var pp2 = context.Request["vid2"];
            var pp4 = context.Request["vid3"];
            var pp5 = context.Request["vid4"];
            String dd = "";
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Retriever pp3 = new Retriever();
            String ss = pp3.addEmail(pp, pp4, pp2, pp5);

          




            // XObjs.Registration kk = pp2.getRegistrationBySubagentRegistrationID(pp);



            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(ss));
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