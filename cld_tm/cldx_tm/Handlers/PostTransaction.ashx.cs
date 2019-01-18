using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for PostTransaction
    /// </summary>
    public class PostTransaction : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp =( context.Request["vid"]);

           //   List<String>dd = ser.Deserialize<List<String>>(pp);

          AppTransaction[] dd = ser.Deserialize<AppTransaction[]>(pp);

            int vlength = dd.Length;
            zues bb = new zues();
            for (int i = 0; i < dd.Length; i++)
            {
                if (dd[i].Status== "Examiner")
                {
                    bb.g_pwalletStatus2(dd[i].online_id, "33", "Search 2 Conducted");

                }

                if (dd[i].Status == "Search")
                {
                    bb.g_pwalletStatus2(dd[i].online_id, "2", "Valid");

                }

                if (dd[i].Status == "Published")
                {
                    bb.g_pwalletStatus2(dd[i].online_id, "7", "Not Opposed");

                }

                if (dd[i].Status == "Acceptance")
                {
                    bb.g_pwalletStatus2(dd[i].online_id, "11", "Accepted");
                    bb.update_RecordalStatus3(dd[i].Recordid, "11", "Accepted");


                }

                if (dd[i].Status == "Certificate")
                {
                    bb.g_pwalletStatus2(dd[i].online_id, "13", "Certified");

                    bb.update_RecordalStatus3(dd[i].Recordid, "13", "Certified");

                }
                //  String ds2 = dd[i].online_id;
            }

                //string online = dd[0].online_id;





            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(dd));
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