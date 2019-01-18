using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cld.Classes;
namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetData21
    /// </summary>
    public class GetData21 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            zues z2 = new zues();

            System.Collections.Generic.List<XObjs.Office_view> kk = z2.getNew_MarkInfoRSX2("3", "Search Conducted", 1, 1);
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