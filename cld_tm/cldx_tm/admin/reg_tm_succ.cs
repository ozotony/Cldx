namespace cld.admin
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class reg_tm_succ : Page
    {
        protected Button btn_menu;
        protected HtmlForm form1;

        protected void btn_menu_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("./tm/x_unit/profile.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}

