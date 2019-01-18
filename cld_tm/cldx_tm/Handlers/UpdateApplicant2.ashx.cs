using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for UpdateApplicant2
    /// </summary>
    public class UpdateApplicant2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string new_hash = "";


            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];
            var pp2 = context.Request["vv2"];
            var pp3 = context.Request["vv3"];
            var pp4 = context.Request["vv4"];
            var pp5 = context.Request["vv5"];

            var pp6 = context.Request["vv6"];



            cld.Classes.zues ff = new cld.Classes.zues();
            Recordal_Result sp = ff.InsertRecordal2(pp, pp2, pp3, pp4, pp5,pp6);
            // String vip = ff.getApplicantName(pp);
            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(sp));
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