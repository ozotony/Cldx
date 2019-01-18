using System;
using cld.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetApplicantName3
    /// </summary>
    public class GetApplicantName3 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string new_hash = "";


            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];



            cld.Classes.zues ff = new cld.Classes.zues();

             Applicant  vip = ff.getApplicantName(pp);
          //  String vip = ff.getApplicantName2(pp);
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