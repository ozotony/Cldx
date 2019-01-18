using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for LoginCheck
    /// </summary>
    public class LoginCheck : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string new_hash = "";


            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];

            Login dd = ser.Deserialize<Login>(pp);

            cld.Classes.zues ff = new cld.Classes.zues();

            String  vip = ff.CheckLogin(dd);
            //var session = HttpContext.Current.Session;

            context.Session["pwalletID"] = vip;

            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(vip));
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