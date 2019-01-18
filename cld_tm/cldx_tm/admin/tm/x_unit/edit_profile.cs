namespace cld.admin.tm.x_unit
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class edit_profile : Page
    {
        public string adminID = "";
        protected HtmlForm form1;

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
        }
    }
}

