﻿namespace cld.admin.tm.search_unit2
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using Classes;
    public class profile : Page
    {
        public string adminID = "";
        protected HtmlForm form1;
        public Int64 lt_mi_t = 0;
        public zues z = new zues();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Form["adminx"] != null)
            {
                String vvv = Request.Form["adminx"];

                Session["pwalletID"] = vvv;

            }
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
            lt_mi_t = this.z.getMarkInfoRSCnt("3", "Search Conducted") + this.z.getMarkInfoRSCnt("22", "Re-conduct search 1");
        }

    }
}

