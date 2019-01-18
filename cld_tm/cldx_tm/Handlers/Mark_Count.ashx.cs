using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for Mark_Count
    /// </summary>
    public class Mark_Count : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            Classes.Retriever ret = new Classes.Retriever();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];
            
           
            Int32 kk = ret.getCountMacInfo(pp);


            //  JavaScriptSerializer ser = new JavaScriptSerializer();
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