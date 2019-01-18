using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for ApplicationOfficer
    /// </summary>
    public class ApplicationOfficer : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            zues ret = new zues();
            //  var pp = (context.Request["vid"]);

            //  var pp2 = (context.Request["vid2"]);

            var pp = context.Request["vv"];
            JavaScriptSerializer ser = new JavaScriptSerializer();
            SelectDate dd = ser.Deserialize<SelectDate>(pp);
          
            ser.MaxJsonLength = Int32.MaxValue;


            List<ApplicationOfficer2> lt_gen_isw = ret.ApplicationOff(dd.startdate, dd.enddate);

            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(lt_gen_isw));
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