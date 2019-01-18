namespace cld.admin.tm.Recordal_unit
{
    using admin ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using cld.Classes;

    public class profile : Page
    {
        public string adminID = "";
        protected HtmlForm form1;
        public Int64 lt_mi_a = 0;
        public Int64 lt_mi_a2 = 0;
        public Int64 lt_mi_n = 0;
        public Int64 lt_mi_r = 0;
        public Int64 lt_mi_g = 0;
        public Int64 lt_mi_kiv = 0;
        public Int64 lt_mi_wd = 0;
        public Int64 lt_mi_prt = 0;

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
            //this.lt_mi_n = this.z.getMarkInfoRSCnt("4", "Registrable");
            //this.lt_mi_a = this.z.getAcceptanceMarkInfoRSCnt("5");
            //this.lt_mi_r = this.z.getMarkInfoRSCnt("4", "Refused");
            //this.lt_mi_kiv = this.z.getMarkInfoRSCnt("5", "kiv");
            //this.lt_mi_wd = this.z.getMarkInfoRSCnt("5", "Withdraw");
            //this.lt_mi_prt = this.z.getMarkInfoRSCnt("5", "acc_printed");
         
            //this.lt_mi_a2 = this.z.getMarkInfoRSCnt10("11", "Accepted");

            //lt_mi_g = z.getGwalletRSCnt("5", "");
        }
    }
}

