namespace cld.admin.tm.opposition_unit
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
        public Int64 lt_mi_n = 0;
        public Int64 lt_mi_n2 = 0;
        public Int64 lt_mi_o =0;
        public Int64 lt_mi_g = 0;
        public zues z = new zues();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["adminx"] != null)
            {
                String vvv = Request.Form["adminx"];

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
            this.lt_mi_o = this.z.getMarkInfoRSCnt("6","Opposed");;
           // this.lt_mi_n = this.z.getMarkInfoRSCnt("6","Published");
            this.lt_mi_n = this.z.getCriRegisteredMarkInfoRSCnt("6", "Published");
            this.lt_mi_n2 = this.z.getMarkInfoRSCnt10("12", "Opposed");
            lt_mi_g = z.getGwalletRSCnt("3", "");
        }
    }
}

