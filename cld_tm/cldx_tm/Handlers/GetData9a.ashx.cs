using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cld.Classes;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetData9a
    /// </summary>
    public class GetData9a : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            zues z2 = new zues();

            System.Collections.Generic.List<XObjs.Office_view2> kk = z2.getNew_MarkInfoRSX11a("13", "Certified", 1, 1);
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