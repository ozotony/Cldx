namespace cld.admin.tm.registrar_unit
{
    using admin ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using Classes;

    public class tm_profile : Page
    {
        public string adminID = "";
        protected HtmlForm form1;
        //public List<zues.MarkInfo> lt_mi_d = new List<zues.MarkInfo>();
        //public List<zues.MarkInfo> lt_mi_i = new List<zues.MarkInfo>();
        //public List<zues.MarkInfo> lt_mi_n = new List<zues.MarkInfo>();
        public int lt_mi_d = 0;
        public int lt_mi_d2 = 0;
        public Int64 lt_mi_d3 = 0;
        public int lt_mi_i = 0;
        public int lt_mi_n = 0;
        public zues z = new zues();



        protected void Page_Load(object sender, EventArgs e)
        {

    


            if (Request.Form["adminx"] != null)
            {
                String vvv = Request.Form["adminx"];

                Session["pwalletID"] = vvv;

            }
            if (Session["pwalletID"] != null)
            {
                if (Session["pwalletID"].ToString() != "")
                {
                    adminID = Session["pwalletID"].ToString();
                }
                else
                {
                    base.Response.Redirect("../lo.aspx");
                }
            }
            else
            {
                base.Response.Redirect("../lo.aspx");
            }
            lt_mi_n = z.getCriRegisteredMarkInfoRSCnt("8", "Certified");
            lt_mi_d = z.getCriRegisteredMarkInfoRSCnt("8", "Deferred");
            lt_mi_d2 = z.getCriRegisteredMarkInfoRSCnt2("8", "Manual");
            lt_mi_d3 = z.getMarkInfoRSCnt("10", "Migrated");
            lt_mi_i = z.getCriRegisteredMarkInfoRSCnt("8", "Registered");
        }
    }
}

