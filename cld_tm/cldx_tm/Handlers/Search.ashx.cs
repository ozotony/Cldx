using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for Search
    /// </summary>
    public class Search : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];
            List<XObjs.Office_view> lt_m = new List<XObjs.Office_view>();
            SearchDb dd = ser.Deserialize<SearchDb>(pp);

            zues z = new zues();

         
          //  var pp2 = context.Request["vv2"];

            List<string> fulltext = new List<string>();
            string str = dd.Productitle.Replace("'", "");
            foreach (string str2 in str.Split(new char[] { ' ' }))
            {
                if (str2 != "")
                {
                    fulltext.Add(str2);
                }
            }

          lt_m = z.getNewAdminSearchMarkInfoRS222("2", "Valid", "product_title", fulltext, "", "");

            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(lt_m));
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