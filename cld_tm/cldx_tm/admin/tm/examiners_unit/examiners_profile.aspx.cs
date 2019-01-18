using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.Classes;

namespace cld.admin.tm.examiners_unit
{
    public partial class examiners_profile : System.Web.UI.Page
    {
        public string adminID = "";
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
            this.lt_mi_n = this.z.getMarkInfoRSCnt("33", "Search 2 Conducted");
            this.lt_mi_r = this.z.getMarkInfoRSCnt("3", "Re-examine");
        }
    }
}