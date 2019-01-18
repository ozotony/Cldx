using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for GetCard
    /// </summary>
    public class GetCard : IHttpHandler
    {
        List<Cards> cards = new List<Cards>();

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();

                zues z = new zues();
                tm t = new tm();
                context.Response.ContentType = "application/json";
                var pp2 = context.Request["vv"];
                var pp3 = context.Request["vv2"];
                 string[] words = pp2.Split('/');
                 string[] words2 = pp3.Split('/');
                List<zues.MarkInfo> lt_mi = new List<zues.MarkInfo>();

                string vfirst = words[1] + "/" + words[2] + "/" + words[3] + "/" + words[4];
                string vsecond = words2[1] + "/" + words2[2] + "/" + words2[3] + "/" + words2[4];

                lt_mi = z.getIndexInfoRS3("5", "Published", vfirst, vsecond);

                foreach (var pp in lt_mi)
                {
                    try
                    {
                        Cards xk = new Cards();
                        xk.MarkInfo = pp;

                        xk.Pwallet = z.getPwalletListDetailsByID2(xk.MarkInfo.log_staff);

                        xk.Applicant = t.getApplicantListByUserID2(xk.MarkInfo.log_staff);

                        xk.lt_addy = t.getAddressListByID2(xk.MarkInfo.log_staff);

                        xk.Representative = t.getRepListByUserID2(xk.MarkInfo.log_staff);

                        xk.lt_rep_addy = t.getAddressByID2(xk.MarkInfo.log_staff);
                        var lt_tm_office = z.getTmOfficeDetailsByID(xk.MarkInfo.log_staff);
                        foreach (zues.TmOffice t2 in lt_tm_office)
                        {
                            if ((t2.data_status == "Accepted") && (t2.admin_status == "5"))
                            {
                                xk.AcceptanceDate = t2.reg_date;
                                // acceptance_date.Add(t.reg_date);
                            }
                        }

                        cards.Add(xk);

                    }

                    catch( Exception ee)
                    {

                        var dsp = ee.Message;
                    }

                }

                string xxp = "";
                ser.MaxJsonLength = Int32.MaxValue;
               
                context.Response.Write(ser.Serialize(cards));

            }

            catch(Exception ee)
            {
                var dss = ee.Message;
            }
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