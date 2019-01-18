using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace cld.gf
{
    public partial class xxreturn : System.Web.UI.Page
    {
        public string serverpath = "";
        public string validationID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
          serverpath = base.Server.MapPath("~/");
            if (Session["vid"] != null) { validationID = Session["vid"].ToString();   }
        }

        protected void Agreed_Click(object sender, EventArgs e)
        {
          Agreed.Visible = false;
          Session["vid"] = null;
          Session["amt"] = null;
          Session["aid"] = null;
          Session["gt"] = null;
          Session["pc"] = null;
          Session["agentemail"] = null;
          Session["cname"] = null;
          Session["agentpnumber"] = null;
          Session["applicantname"] = null;
          Session["pwalletID"] = null;
          Session["log_staffID"] = null;
          Session["xapplication"] = null;
          Session["xref"] = "0";
          Session["xref"] = null;
          Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
        }
    }
}