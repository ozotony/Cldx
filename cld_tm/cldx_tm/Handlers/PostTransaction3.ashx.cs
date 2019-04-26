using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
namespace cld.Handlers
{
    /// <summary>
    /// Summary description for PostTransaction3
    /// </summary>
    public class PostTransaction3 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            zues z = new zues();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = (context.Request["vid"]);

            //   List<String>dd = ser.Deserialize<List<String>>(pp);

            AppTransaction[] dd = ser.Deserialize<AppTransaction[]>(pp);

            int vlength = dd.Length;
            zues bb = new zues();
            for (int i = 0; i < dd.Length; i++)
            {
                if (dd[i].Status == "Registrable")
                {
                   //  bb.g_pwalletStatus2(dd[i].online_id, "33", "Search 2 Conducted");
                  //  bb.g_pwalletStatus2(dd[i].online_id, "4", "Registrable");
                    z.a_mul_tm_office(dd[i].online_id, "4", "Registrable", dd[i].xcomment, "", "", "", dd[i].userid);

                }

                if (dd[i].Status == "Non-registrable")
                {
                    //  bb.g_pwalletStatus2(dd[i].online_id, "2", "Valid");
                  //  bb.g_pwalletStatus2(dd[i].online_id, "4", "Non-registrable");
                    z.a_mul_tm_office(dd[i].online_id, "4", "Non-registrable", dd[i].xcomment, "", "", "", dd[i].userid);

                }

                if (dd[i].Status == "Re-conduct search")
                {
                    //bb.g_pwalletStatus2(dd[i].online_id, "11", "Accepted");
                    //bb.update_RecordalStatus3(dd[i].Recordid, "11", "Accepted");
                   // bb.g_pwalletStatus2(dd[i].online_id, "22", "Re-conduct search 1");
                    z.a_mul_tm_office(dd[i].online_id, "2", "Re-conduct search", dd[i].xcomment, "", "", "", dd[i].userid);


                }

                if (dd[i].Status == "Re-examine")
                {
                    //bb.g_pwalletStatus2(dd[i].online_id, "11", "Accepted");
                    //bb.update_RecordalStatus3(dd[i].Recordid, "11", "Accepted");
                    // bb.g_pwalletStatus2(dd[i].online_id, "22", "Re-conduct search 1");
                    z.a_mul_tm_office(dd[i].online_id, "3", "Re-examine", dd[i].xcomment, "", "", "", dd[i].userid);


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