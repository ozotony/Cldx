using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetOnlineGeneric2
    /// </summary>
    public class GetOnlineGeneric2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];

            //  string[] words = pp.Split('-');



            zues rr = new zues();
            List<XObjs.G_App_info> xxj = rr.getGAppInfoRSX14(pp);
            //  Agent_Info vip = ff.getAgentInfo(pp);
            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(xxj));
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