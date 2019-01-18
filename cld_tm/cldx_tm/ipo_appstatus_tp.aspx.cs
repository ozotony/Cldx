using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.Classes;
using cld.admin;
using System.Configuration;

namespace cld
{
    public partial class ipo_appstatus_tp : System.Web.UI.Page
    {  

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
            if (ddl_itemcode.SelectedValue.ToUpper() == "T002")
            { Response.Redirect("ipo_appstatus.aspx"); }
            else
            { Response.Redirect("gf/g_ipo_appstatus.aspx"); }
            }
        }

        protected void btnDashBoard_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
        }

    }
}