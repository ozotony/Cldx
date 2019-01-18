using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm.Recordal2
{
    public partial class Change_Name : System.Web.UI.Page
    {
        public string adminID = "";
       // protected HtmlForm form1;
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
                  //  base.Response.Redirect("../lo.aspx");
                }
            }
            else
            {
               // base.Response.Redirect("../lo.aspx");
            }
           
        }
    }
}