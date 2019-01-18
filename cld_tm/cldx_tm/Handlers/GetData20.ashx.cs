using System;
using cld.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetData20
    /// </summary>
    public class GetData20 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            zues z2 = new zues();

           // System.Collections.Generic.List<XObjs.Office_view> kk = z2.getNew_MarkInfoRSX2("1", "Fresh", 1, 1);

            System.Collections.Generic.List<XObjs.Office_view> kk = z2.getNew_MarkInfoRSX2bbb("1", "Fresh", 1, 1);

            
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