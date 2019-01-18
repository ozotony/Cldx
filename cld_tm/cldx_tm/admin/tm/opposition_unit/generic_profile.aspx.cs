using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.Classes;

namespace cld.admin.tm.opposition_unit
{
    public partial class generic_profile : System.Web.UI.Page
    {
        public string adminID = "";
        public Int64 lt_mi_n = 0;
        public Int64 lt_mi_t = 0;
        public Int64 lt_mi_k = 0;
        public Int64 lt_mi_c = 0;
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

            lt_mi_n = z.getGwalletRSCnt("3", "New");
            lt_mi_t = z.getGwalletRSCnt("3", "Treated");
            lt_mi_k = z.getGwalletRSCnt("3", "Kiv");
            lt_mi_c = z.getGwalletRSCnt("3", "Contact");
        }
    }
}