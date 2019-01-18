namespace cld.admin.tm
{
    using admin ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using cld.Classes;

    public class preview_cert_data : UserControl
    {
        public string admin = "";
        public int back;
        public string criteria = "";
        public string criteria_type = "";
        public string dateFrom = "";
        public string dateFromArr = "";
        public string dateTo = "";
        public string dateToArr = "";
        protected DropDownList ddl_Status;
        public Int64 dis;
        protected DropDownList DropDownList1;
        public string enrolleeRS = "";
        public string enrolleeRS1 = "";
        public Int64 eu;
        public int export;
        public string kw = "";
        public string lga_id = "";
        public Int64 limit;
        public List<zues.MarkInfo> lt_mi = new List<zues.MarkInfo>();
        public Int64 nume;
        public string r_sectorRS = "";
        public string row_enrolleeRS;
        public string select_search = "";
        public int selectLga;
        protected DropDownList selectSearchCriteria;
        public string selectzone = "";
        public string sh = "";
        public int totsearch;
        public string touch;
        public string x_enrolleeRS;
        public string xRS = "";
        public zues z = new zues();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pwalletID"] != null)
            {
                if (Session["pwalletID"].ToString() != "")
                {
                    this.admin = Session["pwalletID"].ToString();
                }
                else
                {
                    base.Response.Redirect("./xcontrol.aspx");
                }
            }
            else
            {
                base.Response.Redirect("./xcontrol.aspx");
            }
            this.lt_mi = this.z.getCriCertifyMarkInfoRS("7", "Certified");
            if (base.Request.QueryString["sh"] != null)
            {
                this.sh = base.Request.QueryString["sh"].ToString();
            }
            bool isPostBack = base.IsPostBack;
        }
    }
}

