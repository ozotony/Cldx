using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetClassById
    /// </summary>
    public class GetClassById : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string new_hash = "";


            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];



            cld.Classes.zues ff = new cld.Classes.zues();

            String vip = ff.getClassById(pp);
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