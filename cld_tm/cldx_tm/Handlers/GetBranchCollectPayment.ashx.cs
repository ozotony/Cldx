using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetBranchCollectPayment
    /// </summary>
    public class GetBranchCollectPayment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];

         //   string[] words = pp.Split('-');



            Retriever rr = new Retriever();
            List<XObjs.Twallet> xxj = rr.getBranchCollectPayment(pp);
            //  Agent_Info vip = ff.getAgentInfo(pp);
            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(xxj));
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