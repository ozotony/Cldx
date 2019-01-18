namespace cld.admin.tm.acceptance_unit
{
    using admin ;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using cld.Classes;

    public class aed : Page
    {
        public string adminID = "";
        protected Button btnAll;
        protected Button btnSearch;
        protected HtmlForm form1;
        public string fromdate = "";
        public string g_new = "0";
        public string g_rejected = "0";
        public string g_total = "0";
        public string g_treated = "0";
        public string g_utotal = "0";
        protected DropDownList selectFromDay;
        protected DropDownList selectFromMonth;
        protected DropDownList selectFromYear;
        protected DropDownList selectToDay;
        protected DropDownList selectToMonth;
        protected DropDownList selectToYear;
        public string todate = "";
        public string xfromsel_month = "";
        public zues z = new zues();

        protected void btnAll_Click(object sender, EventArgs e)
        {
            this.Session["f"] = "";
            this.Session["t"] = "";
            base.Response.Redirect("./aed.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.Session["f"] = "";
            this.Session["t"] = "";
            this.Session["f"] = this.selectFromYear.SelectedValue + "-" + this.selectFromMonth.SelectedValue + "-" + this.selectFromDay.SelectedValue;
            this.Session["t"] = this.selectToYear.SelectedValue + "-" + this.selectToMonth.SelectedValue + "-" + this.selectToDay.SelectedValue;
            base.Response.Redirect("./aed.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["f"] != null)
            {
                this.fromdate = this.Session["f"].ToString();
            }
            if (this.Session["t"] != null)
            {
                this.todate = this.Session["t"].ToString();
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
            if ((this.fromdate != "") && (this.todate != ""))
            {
                // this.g_total = this.z.getTotalEntriesByDate("", this.fromdate, this.todate);
                this.g_total = Convert.ToString(this.z.getCriRegisteredMarkInfoRSCnt33("", "Total", this.fromdate, this.todate) );
                //  this.g_utotal = this.z.getTotalEntriesByDate("4", this.fromdate, this.todate);
                //  this.g_new = this.z.getTotalEntryCountStageByDate("4", "Registrable", this.fromdate, this.todate);
                this.g_new = Convert.ToString(this.z.getCriRegisteredMarkInfoRSCnt33("4", "Registrable", this.fromdate, this.todate) + this.z.getCriRegisteredMarkInfoRSCnt33("4", "Non-registrable", this.fromdate, this.todate));
                //this.g_treated = this.z.getTotalEntryCountStageByDate("4", "", this.fromdate, this.todate);
                this.g_treated =Convert.ToString( this.z.getCriRegisteredMarkInfoRSCnt33("4", "Accepted", this.fromdate, this.todate));

                
               // this.g_rejected = this.z.getTotalEntryCountByStage("4", "Refused");
                this.g_rejected = Convert.ToString(this.z.getCriRegisteredMarkInfoRSCnt33("4", "Withdraw", this.fromdate, this.todate));

                this.g_utotal = Convert.ToString(Convert.ToInt32(this.g_treated) + Convert.ToInt32(this.g_new) + Convert.ToInt32(this.g_rejected));
            }
            else
            {
               // this.g_total = this.z.getTotalEntries("");
                this.g_total = Convert.ToString(this.z.getCriRegisteredMarkInfoRSCnt34("", "Total", "", ""));
               // this.g_utotal = this.z.getTotalEntries("4");
              //  this.g_new = this.z.getTotalEntryCountByStage("4", "Registrable");
                this.g_new = Convert.ToString(this.z.getCriRegisteredMarkInfoRSCnt34("4", "Registrable", "", "") + this.z.getCriRegisteredMarkInfoRSCnt34("4", "Non-registrable", "", ""));
              //  this.g_treated = this.z.getTotalEntryCountByStage("4", "");
                this.g_treated = Convert.ToString(this.z.getCriRegisteredMarkInfoRSCnt34("4", "Accepted", "", ""));
              //  this.g_rejected = this.z.getTotalEntryCountByStage("4", "Refused");
                this.g_rejected = Convert.ToString(this.z.getCriRegisteredMarkInfoRSCnt34("4", "Withdraw", "", ""));
                this.g_utotal = Convert.ToString(Convert.ToInt32(this.g_treated) + Convert.ToInt32(this.g_new) + Convert.ToInt32(this.g_rejected));
            }
            for (int i = 0x7d0; i <= 0x7e4; i++)
            {
                this.selectFromYear.Items.Add(i.ToString());
                this.selectToYear.Items.Add(i.ToString());
            }
            for (int j = 1; j <= 12; j++)
            {
                this.selectFromMonth.Items.Add(string.Format("{0:d2}", j));
                this.selectToMonth.Items.Add(string.Format("{0:d2}", j));
            }
            for (int k = 1; k <= 0x1f; k++)
            {
                this.selectFromDay.Items.Add(string.Format("{0:d2}", k));
                this.selectToDay.Items.Add(string.Format("{0:d2}", k));
            }
        }
    }
}

