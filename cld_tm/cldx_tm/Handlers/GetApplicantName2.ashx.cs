using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetApplicantName2
    /// </summary>
    public class GetApplicantName2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string new_hash = "";


            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];

           // var pp = "1134";

            cld.Classes.zues ff = new cld.Classes.zues();
            Int32 pp2 = Convert.ToInt32(pp);

            ChangeAplicant_Name vip = ff.getApplicantName2(pp2);
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