using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetAGentInfo
    /// </summary>
    public class GetAGentInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string new_hash = "";


            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];



            cld.Classes.zues ff = new cld.Classes.zues();

           Agent_Info  vip = ff.getAgentInfo(pp);
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