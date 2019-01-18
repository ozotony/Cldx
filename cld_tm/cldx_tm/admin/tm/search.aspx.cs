using cld.admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace cld.admin.tm
{
    using cld.Classes;

    public partial class search : Page
    {
          public string admin = "";
        public int back;
        public string cri = "";
        public string criteria = "";
        public string criteria_type = "";
        public string data_status = "Valid";
        public string dateFrom = "";
        public string dateFromArr = "";
        public string dateTo = "";
        public string dateToArr = "";
        public long dis;
        public string e_type = "";
        public string enrolleeRS = "";
        public string enrolleeRS1 = "";
        public long eu;
        public int export;
        protected GridView gvX;
        public string kw = "";
        public string lga_id = "";
        public long limit;
        public List<XObjs.Office_view> lt_m = new List<XObjs.Office_view>();
        public List<zues.MarkInfo> lt_mi = new List<zues.MarkInfo>();
        public int max;
        public long nume;
        public string pager_visible = "";
        public List<string> pages = new List<string>();
        public string r_sectorRS = "";
        public string row_enrolleeRS;
        public string select_search = "";
        public int selectLga;
        public string selectzone = "";
        public string stage = "2";
        public int totsearch;
        public string touch;
        public long x_cnt;
        public string x_enrolleeRS;
        public string xRS = "";
        public zues z = new zues();

        protected void btnReloadPage_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("search.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> fulltext = new List<string>();
            string str = this.kword.Value.Replace("'", "");
            this.dateFrom = this.z.formatSearchDate(this.datepickerFrom.Value);
            this.dateTo = this.z.formatSearchDate(this.datepickerTo.Value);
            if ((this.dateTo == "") || (this.dateTo == null))
            {
                this.dateTo = DateTime.Today.Date.ToString("yyyy-MM-dd");
            }
            foreach (string str2 in str.Split(new char[] { ' ' }))
            {
                if (str2 != "")
                {
                    fulltext.Add(str2);
                }
            }
            if (this.selectSearchCriteria.SelectedValue == "product_title")
            {
                this.lt_m = this.z.getNewAdminSearchMarkInfoRS(this.stage, this.data_status, this.selectSearchCriteria.SelectedValue, fulltext, this.dateFrom, this.dateTo);
                if (this.lt_m.Count<XObjs.Office_view>() > 0)
                {
                    this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
                    this.Session["lt_m"] = this.lt_m;
                    this.gvX.DataSource = this.lt_m;
                    this.gvX.DataBind();
                    this.criteria = string.Concat(new object[] { this.lt_m.Count<XObjs.Office_view>(), " result(s) found for search criteria (", this.kword.Value, ")!!" });
                }
                else
                {
                    this.criteria = "No result found for search criteria (" + this.kword.Value + ")!!";
                }
            }
            else if (fulltext.Count<string>() == 1)
            {
                this.lt_m = this.z.getNewAdminSearchMarkInfoRS(this.stage, this.data_status, this.selectSearchCriteria.SelectedValue, fulltext, this.dateFrom, this.dateTo);
                if (this.lt_m.Count<XObjs.Office_view>() > 0)
                {
                    this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
                    this.Session["lt_m"] = this.lt_m;
                    this.gvX.DataSource = this.lt_m;
                    this.gvX.DataBind();
                    this.criteria = string.Concat(new object[] { this.lt_m.Count<XObjs.Office_view>(), " result(s) found for search criteria (", this.kword.Value, ")!!" });
                }
                else
                {
                    this.criteria = "No result found for search criteria (" + this.kword.Value + ")!!";
                }
            }
            else
            {
                this.criteria = "The Application number cannot be more one (1) !!";
            }
        }

        protected void gvX_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvX.PageIndex = e.NewPageIndex;
            if (this.Session["lt_m"] != null)
            {
                this.lt_m.Clear();
                this.lt_m = (List<XObjs.Office_view>)this.Session["lt_m"];
            }
            this.gvX.DataSource = this.lt_m;
            this.gvX.DataBind();
            if (this.Session["x_cnt"] != null)
            {
                this.x_cnt = Convert.ToInt32(this.Session["x_cnt"]);
            }
        }

        protected void gvX_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "TmViewClick")
            {
                GridViewRow namingContainer = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                int rowIndex = namingContainer.RowIndex;
                string str = e.CommandArgument.ToString();
                base.Response.Redirect("s_data_detail.aspx?x=" + str + "&cri=" + this.Session["e_type"].ToString());
            }
            if (e.CommandName == "TmRepClick")
            {
                GridViewRow row2 = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                int num2 = row2.RowIndex;
                string str2 = e.CommandArgument.ToString();
                base.Response.Redirect("s_data_details_report.aspx?x=" + str2 + "&cri=" + this.Session["e_type"].ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["pwalletID"] != null) && (this.Session["pwalletID"].ToString() != ""))
            {
                this.admin = this.Session["pwalletID"].ToString();
            }
            else
            {
                base.Response.Redirect("./xcontrol.aspx");
            }
            if ((base.Request.QueryString["x"] != null) && (base.Request.QueryString["x"].ToString() != ""))
            {
                this.e_type = base.Request.QueryString["x"].ToString();
                this.Session["e_type"] = this.e_type;
            }
            if (this.e_type == "n")
            {
                this.stage = "2";
                this.data_status = "Valid";
            }
            else if (this.e_type == "r")
            {
                this.stage = "2";
                this.data_status = "Re-conduct search";
            }
            if (!base.IsPostBack)
            {
                this.max = Convert.ToInt32(ConfigurationManager.AppSettings["s_unit_limit"]);
                this.gvX.PageSize = 100;
                this.Session["lt_m"] = null;
                this.Session["x_cnt"] = null;
                this.lt_m = this.z.getNew_MarkInfoRSX(this.stage, this.data_status, 0, this.max);
                this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
                this.Session["lt_m"] = this.lt_m;
                this.gvX.DataSource = this.lt_m;
                this.gvX.DataBind();
            }
            else if (this.Session["x_cnt"] != null)
            {
                this.x_cnt = Convert.ToInt32(this.Session["x_cnt"]);
            }
        }
    }
}