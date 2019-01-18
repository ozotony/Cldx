namespace cld.admin.tm.verification_unit
{
    using admin ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using Classes;
    public class profile : Page
    {
        public string adminID = "";
        protected HtmlForm form1;
        public Int64 lt_mi = 0;
        public Int64 lt_mi2 = 0;
        public Int64 lt_g = 0;
        public Int64 lt_gs2 = 0;

        public zues z = new zues();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["adminx"] != null)
            {
             String   vvv =Request.Form["adminx"];

                Session["pwalletID"] = vvv;

            }
                if (this.Session["pwalletID"] != null)
            {
                if (this.Session["pwalletID"].ToString() != "")
                {
                    this.adminID = this.Session["pwalletID"].ToString();
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
            lt_mi = this.z.getMarkInfoRSCnt("1","Fresh");
            lt_gs2 = z.getMarkInfoRSCnt("14", "Kiv");
            // lt_mi2 = this.z.getMarkInfoRSCnt2("1", "Recordal");
            lt_mi2 = this.z.getMarkInfoRSCnt10("1", "Recordal");
            
            lt_g = z.getGwalletRSCnt("1", "Fresh");
        }
    }
}

