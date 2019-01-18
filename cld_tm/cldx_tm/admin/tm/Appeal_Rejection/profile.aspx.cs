using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm.Appeal_Rejection
{
    using admin;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using cld.Classes;
    public partial class profile : System.Web.UI.Page
    {
        public string adminID = "";
       
        public Int64 lt_mi = 0;
        public Int64 lt_mi2 = 0;
        public Int64 lt_g = 0;
        public Int64 lt_gs2 = 0;

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
            lt_mi = this.z.getRefuseAppealCnt();
            lt_gs2 = z.getRefuseAppealCnt2();
            // lt_mi2 = this.z.getMarkInfoRSCnt2("1", "Recordal");
            lt_mi2 = this.z.getMarkInfoRSCnt10("1", "Recordal");

            lt_g = z.getGwalletRSCnt("1", "Fresh");
        }
    }
}