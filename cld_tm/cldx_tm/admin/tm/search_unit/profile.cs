namespace cld.admin.tm.search_unit
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using Classes;
    public class profile : Page
    {
        public string adminID = "";
        protected HtmlForm form1;
        public Int64 lt_mi_t = 0;
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
          //  lt_mi_t = this.z.getMarkInfoRSCnt("2", "Valid") + this.z.getMarkInfoRSCnt("2", "Re-conduct search");

 lt_mi_t =Convert.ToInt32( this.z.getMarkInfoRSCnt("2", "Valid") ) + Convert.ToInt32( this.z.getMarkInfoRSCnt("2", "Re-conduct search"));
            lt_mi_g = z.getGwalletRSCnt("2", "");
        }
    }
}

