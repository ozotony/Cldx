using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetPayment
    /// </summary>
    public class GetPayment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var pp = context.Request["vid"];
            String dd = "";
            JavaScriptSerializer ser = new JavaScriptSerializer();

             string[] words = pp.Split('-');

            //if (pp.Contains("-"))
            //{
            //    context.Response.Write(ser.Serialize("Full Transaction  Id Search Not Allowed "));
            //    return;

            //}

            zues z2 = new zues();
              Applicant kk = z2.getApplicant3ByID(words[0], words[2]);

           // Applicant kk = z2.getApplicant3bByID(pp);
            var vresult = "";
            if (kk != null)
            {
                vresult = kk.Applicant_Name;

            }

            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize( kk));
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