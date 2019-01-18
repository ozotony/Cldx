using System;
using cld.Classes;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for PostTransaction2
    /// </summary>
    public class PostTransaction2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = (context.Request["vid"]);

            //   List<String>dd = ser.Deserialize<List<String>>(pp);

            AppTransaction[] dd = ser.Deserialize<AppTransaction[]>(pp);

            int vlength = dd.Length;
            zues bb = new zues();
            for (int i = 0; i < dd.Length; i++)
            {
                if (dd[i].Status == "Search")
                {
                    bb.g_pwalletStatus3(dd[i].online_id, "2", "New");

                }

                if (dd[i].Status == "Acceptance")
                {
                    bb.g_pwalletStatus3(dd[i].online_id, "5", "New");

                }

                if (dd[i].Status == "Certificate")
                {
                    bb.g_pwalletStatus3(dd[i].online_id, "4", "New");

                }


                if (dd[i].Status == "Opposition")
                {
                    bb.g_pwalletStatus3(dd[i].online_id, "3", "New");

                }

                if (dd[i].Status == "PrintedCertificate")
                {
                  //  bb.g_pwalletStatus(dd[i].online_id, "12", "PrintedCertificate");

           bb.a_tm_office(dd[i].online_id, "12", "PrintedCertificate", "", "", "", "", dd[i].adminid);

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