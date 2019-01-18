using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetAuditReport
    /// </summary>
    public class GetAuditReport : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
            String dd = "";
            JavaScriptSerializer ser = new JavaScriptSerializer();
            zues pp3 = new zues();
            List<AuditReport>  ss = pp3.getLogReport();






            // XObjs.Registration kk = pp2.getRegistrationBySubagentRegistrationID(pp);


            ser.MaxJsonLength = Int32.MaxValue;
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