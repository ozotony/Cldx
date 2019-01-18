using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetCld
    /// </summary>
    public class GetCld : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var pp = context.Request["vid"];
            var pp2 = context.Request["vid2"];
            String dd = "";
            JavaScriptSerializer ser = new JavaScriptSerializer();
            context.Response.ContentType = "application/json";
            zues z2 = new zues();

            int vcount = z2.updateTransID2b(pp2, pp);

            //  UserError ppp = new UserError();

            if (vcount > 0)
            {
                //  ppp.message = "Id Already Exist";
                context.Response.Write(ser.Serialize("Id Already Used"));
                return;
                //  throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Record Has been Migrated Before"));

                //  throw new System.InvalidOperationException(context.Response.Write(ser.Serialize("Id Already Exist")));
            }


         //   string[] words = pp.Split('-');
          //  var xxp = z2.getAgentID(words[2]);

          //  var xxp2 = z2.getAgentID3(pp2);

          
            
            
            
            //if (xxp != xxp2)
            //{

            //    context.Response.Write(ser.Serialize("This Payment  Id is not For This Transaction"));
            //    return;
            //}

            //if (pp2.Contains("-"))
            //{

            //     string[] words = pp2.Split('-');

            //    if (words[0] !=pp)
            //    {
            //        context.Response.Write(ser.Serialize("This Payment  Id is not For This Transaction"));
            //        return;
            //    }
            //}

            //if (pp2 != pp)
            //{
            //    context.Response.Write(ser.Serialize("This Payment  Id is not For This Transaction"));
            //    return;
            //}


            Int32 kk = z2.updateTransID2(pp2, pp);



          
            context.Response.Write(ser.Serialize("Record Updated Successfully"));
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