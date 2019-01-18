using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using cld.Classes;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetRecordal
    /// </summary>
    public class GetRecordal : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var pp = context.Request["vid"];
            String dd = "";
            JavaScriptSerializer ser = new JavaScriptSerializer();

            Retriever  z2 = new Retriever();
            System.Collections.Generic.List<Recordal> kk = z2.getG_PwalletByID2(pp);
            //  Applicant kk = z2.getApplicant6ByID(pp);



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