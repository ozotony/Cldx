namespace cld
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public partial class xrefill : Page
    {
        public string agt = "";
        public string serverpath = "";
        public string validationID = "";

        protected void Agreed_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
        }

        protected void editApplication_Click(object sender, EventArgs e)
        {
            if (this.Session["agt"] != null)
            {
                this.agt = this.Session["agt"].ToString();
            }
            if (this.Session["vid"] != null)
            {
                this.validationID = this.Session["vid"].ToString();
            }
            if (((this.validationID != "") && (this.validationID != null)) && ((this.agt != "") && (this.agt != null)))
            {
                base.Response.Redirect("./tm_refill.aspx?XXX1234445=" + this.validationID + "&XXX94384238=" + this.agt);
            }
            else
            {
                base.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.serverpath = base.Server.MapPath("~/");
            if (this.Session["vid"] != null)
            {
                this.validationID = this.Session["vid"].ToString();
            }
            if (this.Session["agt"] != null)
            {
                this.agt = this.Session["agt"].ToString();
            }
        }
    }
}

