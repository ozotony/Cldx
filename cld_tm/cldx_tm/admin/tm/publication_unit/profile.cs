namespace cld.admin.tm.publication_unit
{
    using cld.admin;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using Classes;

    public class profile : Page
    {
        public string adminID = "";
        public int current_batch_no;
        protected HtmlForm form1;
        public List<zues.MarkInfo> lt_mi = new List<zues.MarkInfo>();
        public List<zues.MarkInfo> lt_mi_d = new List<zues.MarkInfo>();
        public List<zues.MarkInfo> lt_mi_p = new List<zues.MarkInfo>();
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
            this.lt_mi = this.z.getMarkInfoRS("5", "Accepted");
            this.lt_mi_p = this.z.getCriPublishMarkInfoRS("6", "Published");
            this.lt_mi_d = this.z.getMarkInfoRS("5", "Deferred");
            this.current_batch_no = this.z.getCurrentBatch() - 1;
        }
    }
}

