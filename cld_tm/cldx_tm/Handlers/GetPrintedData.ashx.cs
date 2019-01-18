using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cld.Classes;
namespace cld.Handlers


{
    /// <summary>
    /// Summary description for GetPrintedData
    /// </summary>
    public class GetPrintedData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            zues z2 = new zues();

            var ppp = (context.Request["vid3"]);

            GetNewData dd3 = ser.Deserialize<GetNewData>(ppp);



            //   var pp3 = (context.Request["vid2"]).ToString();
            int pp2 = Convert.ToInt32(dd3.pageno);
            // string  pp3 = words[1];
            string pp3 = dd3.criteria;

            string pp4 = dd3.valueentered;


            // string pp3 = "";

            // System.Collections.Generic.List<XObjs.Office_view> kk = z2.getNew_MarkInfoRSX222b("8", "Certified", 1, 1);
            GetReport dd = new GetReport();


                dd = z2.getNew_MarkInfoRSX222bbx55(dd3.status, dd3.datastatus, pp2, 100, pp3, pp4);
           

          


            //  dd = z2.getNew_MarkInfoRSX222bbx4("8", "Certified", pp2, 100, pp3, pp4);

            // System.Collections.Generic.List<XObjs.Office_view> kk = z2.getNew_MarkInfoRSX9("8", "Certified", 1, 1);
            ser.MaxJsonLength = Int32.MaxValue;

            context.Response.ContentType = "application/json";


            //    int lt_mi_n = z2.getCriRegisteredMarkInfoRSCnt("8", "Certified");
            //dd.data = kk;
            //dd.count = lt_mi_n;

            //  context.Response.Write(ser.Serialize(kk));
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