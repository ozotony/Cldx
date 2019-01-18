using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetData24
    /// </summary>
    public class GetData24 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            zues z2 = new zues();

            System.Collections.Generic.List<XObjs.Office_view> kk = z2.getNew_MarkInfoRSX22("33", "Search 2 Conducted", 1, 1);
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