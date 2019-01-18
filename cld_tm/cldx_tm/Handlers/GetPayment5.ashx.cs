﻿using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetPayment5
    /// </summary>
    public class GetPayment5 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];

            string[] words = pp.Split('-');

            Retriever rr = new Retriever();
            List<XObjs.Twallet> xxj = rr.getTwalletByMemberID2(words[2], "9");
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