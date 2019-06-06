using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetGeneric
    /// </summary>
    public class GetGeneric : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            zues z2 = new zues();

         //   System.Collections.Generic.List<XObjs.G_App_info> kk = z2.getGAppInfoRSX12("1", "Fresh", "1", "1");

            System.Collections.Generic.List<XObjs.G_App_info> kk = z2.getGAppInfoRSX12("2", "New", "1", "1");
            ser.MaxJsonLength = Int32.MaxValue;

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