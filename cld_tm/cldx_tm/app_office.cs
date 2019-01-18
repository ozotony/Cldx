namespace cld
{
    using Classes ;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class app_office : Page
    {
        public string admin = "";
        protected HtmlForm form1;
        public string progress_msg = "";
        protected Button Save;
        public tm t = new tm();
        protected TextBox xagt;
        protected TextBox xamt;
        public string xapplication = "";
        protected DropDownList xptype;
        protected TextBox xtransaction;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["pwalletID"] != null)
            {
                if (this.Session["pwalletID"].ToString() != "")
                {
                    this.admin = this.Session["pwalletID"].ToString();
                    this.Session["xofficer"] = this.admin;
                }
                else
                {
                    base.Response.Redirect("./admin/tm/xcontrol.aspx");
                }
            }
            else
            {
                base.Response.Redirect("./admin/tm/xcontrol.aspx");
            }
            this.Session["vid"] = null;
            this.Session["amt"] = null;
            this.Session["aid"] = null;
            this.Session["g"] = null;
            this.Session["pc"] = null;
            base.Server.MapPath("~/");
            if (this.Session["xapplication"] != null)
            {
                this.xapplication = this.Session["xapplication"].ToString();
                if (this.xapplication != "")
                {
                    base.Response.Redirect("./violationx.aspx");
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            int num = 0;
            int num2 = 0;
            if (this.xtransaction.Text == "")
            {
                num2++;
            }
            if (this.xamt.Text == "")
            {
                num2++;
            }
            if (this.xagt.Text == "")
            {
                num2++;
            }
            if (num2 == 0)
            {
                num = this.t.getCheckTransactionID(this.xtransaction.Text, this.xamt.Text, this.xptype.SelectedValue, this.xagt.Text);
                if (num > 0)
                {
                    this.Session["transID"] = num;
                    this.Session["vid"] = this.xtransaction.Text;
                    this.Session["amt"] = this.xamt.Text;
                    this.Session["aid"] = this.xagt.Text;
                    this.Session["gt"] = this.xptype.SelectedValue;
                    base.Response.Redirect("./trademarkx.aspx");
                }
                else
                {
                    this.progress_msg = "PLEASE CROSS CHECK THE DETAILS ABOVE AND TRY AGAIN !!";
                }
            }
            else
            {
                this.progress_msg = "PLEASE FILL IN ALL THE DETAILS ABOVE!!";
            }
        }
    }
}

