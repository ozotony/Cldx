using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for Paymenthandler
    /// </summary>
    public class Paymenthandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           
            JavaScriptSerializer ser = new JavaScriptSerializer();

            cld.Classes.zues ff = new cld.Classes.zues();

           

            List<Payments>  dd3 = ff.getPayment();
            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(dd3));
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