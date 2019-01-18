using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cld.Classes;
namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetData28
    /// </summary>
    public class GetData28 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            zues z2 = new zues();
          //  var pp =Convert.ToInt32( context.Request["page"]);
          //  var pp2 = Convert.ToInt32(context.Request["itemsPerPage"]);
            System.Collections.Generic.List<XObjs.Office_view> kk = z2.getNew_MarkInfoRSX222("5", "Accepted", 1, 1);
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