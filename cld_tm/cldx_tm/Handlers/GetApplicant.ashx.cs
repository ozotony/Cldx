using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetApplicant
    /// </summary>
    public class GetApplicant : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var pp = context.Request["vid"];
            String dd = "";
            JavaScriptSerializer ser = new JavaScriptSerializer();

            cld.Classes.zues ff = new cld.Classes.zues();
             
            string vtrans_id = pp;

      Applicant dd3 =ff.getApplicant2ByID(vtrans_id);
           







            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(dd3));
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