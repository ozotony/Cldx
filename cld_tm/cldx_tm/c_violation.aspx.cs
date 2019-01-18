using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld
{
    public partial class c_violation : System.Web.UI.Page
    {
        public string serverpath = "";
        public string validationID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.serverpath = base.Server.MapPath("~/");
            if (this.Session["vid"] != null)
            {
                this.validationID = this.Session["vid"].ToString();
            }
        }

        protected void Agreed_Click(object sender, EventArgs e)
        {
            this.Agreed.Visible = false;
            this.Session["vid"] = null;
            this.Session["amt"] = null;
            this.Session["aid"] = null;
            this.Session["gt"] = null;
            this.Session["pc"] = null;
            this.Session["agentemail"] = null;
            this.Session["cname"] = null;
            this.Session["agentpnumber"] = null;
            this.Session["applicantname"] = null;
            this.Session["pwalletID"] = null;
            this.Session["log_staffID"] = null;
            this.Session["xapplication"] = null;
            this.Session["xref"] = "0";
            this.Session["xref"] = null;
            base.Response.Redirect("./XPay/login.aspx");
        }
    }
}