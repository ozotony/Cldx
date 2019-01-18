namespace cld.admin.tm.certification_unit
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
        public Int64 lt_mi_d = 0;
        public Int64 lt_mi_d2 = 0;
        public Int64 lt_mi_d3 = 0;
        public Int64 lt_mi_d4 = 0;
        public Int64 lt_mi_n = 0;
        public Int64 lt_mi_p = 0;
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
          //  this.lt_mi_n = this.z.getMarkInfoRSCnt("7","Not Opposed");
            this.lt_mi_n = this.z.getCriRegisteredMarkInfoRSCnt("7", "Not Opposed");
            this.lt_mi_d = this.z.getMarkInfoRSCnt("7","Deferred");
             this.lt_mi_d2 = this.z.getMarkInfoRSCnt("10","New");
             this.lt_mi_d3 = this.z.getMarkInfoRSCnt100("13", "Certified", "Pending");
            this.lt_mi_d4 = this.z.getMarkInfoRSCnt100("13", "Certified", "Approved");
            this.lt_mi_p = this.z.getMarkInfoRSCnt("7","Certified");
           
            this.lt_mi_g = z.getGwalletRSCnt("4", "");
        }
    }
}

