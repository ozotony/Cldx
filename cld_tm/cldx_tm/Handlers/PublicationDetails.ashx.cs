using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for PublicationDetails
    /// </summary>
    public class PublicationDetails : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer ser2 = new JavaScriptSerializer();
            var pp = context.Request["vid"];
            zues z = new zues();
           

            Publication2 dd = ser2.Deserialize<Publication2>(pp);

            List<zues.MarkInfo> lt_mi = new List<zues.MarkInfo>();

            int kk = Convert.ToInt32(dd.batchno);
            kk = kk + 1;
            dd.batchno = Convert.ToString(kk);

           lt_mi = z.getBatchPublishMarkInfoRSAA("5", "Published", dd.batchno);

           string ss = "test";
            ser2.MaxJsonLength = Int32.MaxValue;
            context.Response.ContentType = "application/json";
            context.Response.Write(ser2.Serialize(lt_mi));
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