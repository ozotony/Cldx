namespace cld.admin.tm.search_unit
{
    using admin ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using Classes;
    public class searchprofile : Page
    {
        public string adminID = "";
        protected HtmlForm form1;
        public Int64 lt_mi_n = 0;
        public Int64 lt_mi_r = 0;
        public zues z = new zues();

        protected void Page_Load(object sender, EventArgs e)
        {
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
            this.lt_mi_n = this.z.getMarkInfoRSCnt("2", "Valid");
            this.lt_mi_r = this.z.getMarkInfoRSCnt("2", "Re-conduct search");
        }
    }
}

