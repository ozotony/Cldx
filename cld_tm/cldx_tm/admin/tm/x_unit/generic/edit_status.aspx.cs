using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm.x_unit.generic
{
    public partial class edit_status : System.Web.UI.Page
    {
        public string adminID = "";
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
                    base.Response.Redirect("../../lo.aspx");
                }
            }
            else
            {
                base.Response.Redirect("../../lo.aspx");
            }
        }
    }
}