using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for Publication
    /// </summary>
    public class Publication : IHttpHandler
    {
        public zues z = new zues();
        public int current_batch_no;
        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();

            current_batch_no = z.getCurrentBatch();
            List<Publications> dd2 = new List<Publications>();

            int sn = 1;
            for (int i = current_batch_no; i > 1; i--)
            {
                Publications dd = new Publications();
                dd.sn = Convert.ToString(sn);
                string batch_row = "";
                int no = i - 1;
                int cur_i = i + 1;


                int batch_count = z.getCurrentBatchCnt(i);
                dd.Batchno = Convert.ToString(no);
                dd.Batchcount = batch_count;

                dd2.Add(dd);

                sn = sn + 1;

            }

            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(dd2));
           
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