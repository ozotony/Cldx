using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using cld.Classes;

namespace cld.admin.tm
{
    public partial class acceptance_slip : Page
    {
        public string admin = "0";
        public int back;
        public string criteria = "";
        public string criteria_type = "";
        public string data_status = "Accepted";
        public string dateFrom = "";
        public string dateFromArr = "";
        public string dateTo = "";
        public string dateToArr = "";
        public long dis;
        public string enrolleeRS = "";
        public string enrolleeRS1 = "";
        public long eu;
        public int export;
        public string kw = "";
        public string lga_id = "";
        public long limit;
        public List<XObjs.Office_view> lt_m = new List<XObjs.Office_view>();
        public List<zues.MarkInfo> lt_mi = new List<zues.MarkInfo>();
        public List<XrowCount> pz = new List<XrowCount>();
        public int max;
        public string r_sectorRS = "";
        public string row_enrolleeRS;
        public string select_search = "";
        public int selectLga;
        public string selectzone = "";
        public string sh = "";
        public SortedList<int, string> slt_checked = new SortedList<int, string>();
        public string stage = "5";
        public string touch;
        public long x_cnt;
        public string x_enrolleeRS;
        public string xRS = "";
        public zues z = new zues();

        protected void btnReloadPage_Click(object sender, EventArgs e)
        {
           // base.Response.Redirect("acceptance_slip.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //List<string> fulltext = new List<string>();
            //string str = this.kword.Value.Replace("'", "");
            //this.dateFrom = this.z.formatSearchDate(this.datepickerFrom.Value);
            //this.dateTo = this.z.formatSearchDate(this.datepickerTo.Value);
            //if ((this.dateTo == "") || (this.dateTo == null))
            //{
            //    this.dateTo = DateTime.Today.Date.ToString("yyyy-MM-dd");
            //}
            //foreach (string str2 in str.Split(new char[] { ' ' }))
            //{
            //    if (str2 != "")
            //    {
            //        fulltext.Add(str2);
            //    }
            //}
            //if (this.selectSearchCriteria.SelectedValue == "product_title")
            //{
            //    string ssp = kword.Value;

            //    List<XObjs.Office_view> dd = new List<XObjs.Office_view>();
            //    this.lt_m = this.z.getNewAdminSearchMarkInfoRS(this.stage, this.data_status, this.selectSearchCriteria.SelectedValue, fulltext, this.dateFrom, this.dateTo);
            //    //PopulateData2(1, 10, fulltext);
            //    Panel1.Visible = false;


            //    if (this.dateFrom != "" && this.dateTo != "" && this.lt_m.Count<XObjs.Office_view>() > 0)
            //    {
            //        foreach (XObjs.Office_view pd in lt_m)
            //        {
            //            DateTime vdate = Convert.ToDateTime(pd.reg_dt);

            //            DateTime vdate2 = Convert.ToDateTime(this.datepickerFrom.Value);

            //            DateTime vdate3 = Convert.ToDateTime(this.datepickerTo.Value);

            //            if (vdate >= vdate2 && vdate <= vdate3)
            //            {

            //                dd.Add(pd);
            //            }


            //        }

            //        this.Session["x_cnt"] = this.x_cnt = dd.Count;
            //        this.Session["lt_m"] = dd;
            //        this.gvX.DataSource = dd;
            //        this.gvX.DataBind();
            //        this.criteria = string.Concat(new object[] { dd.Count<XObjs.Office_view>(), " result(s) found for search criteria (", this.kword.Value, ")!!" });
            //        Panel1.Visible = false;
            //    }

            //    //ViewState["TotalRecord"] = z.getNew_RowCount2(kword.Value).Count;// GetTotalCount();
            //    //ViewState["NoOfRecord"] = 10;

            //    //AddpagingButton();

            //    else
            //    {

            //        if (this.lt_m.Count<XObjs.Office_view>() > 0)
            //        {
            //            this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
            //            this.Session["lt_m"] = this.lt_m;
            //            this.gvX.DataSource = this.lt_m;
            //            this.gvX.DataBind();
            //            this.criteria = string.Concat(new object[] { this.lt_m.Count<XObjs.Office_view>(), " result(s) found for search criteria (", this.kword.Value, ")!!" });
            //        }
            //        else
            //        {
            //            this.criteria = "No result found for search criteria (" + this.kword.Value + ")!!";
            //        }

            //    }
            //}
            //else if (fulltext.Count<string>() == 1)
            //{
            //    this.lt_m = this.z.getNewAdminSearchMarkInfoRS(this.stage, this.data_status, this.selectSearchCriteria.SelectedValue, fulltext, this.dateFrom, this.dateTo);
            //    if (this.lt_m.Count<XObjs.Office_view>() > 0)
            //    {
            //        this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
            //        this.Session["lt_m"] = this.lt_m;
            //        this.gvX.DataSource = this.lt_m;
            //        this.gvX.DataBind();
            //        this.criteria = string.Concat(new object[] { this.lt_m.Count<XObjs.Office_view>(), " result(s) found for search criteria (", this.kword.Value, ")!!" });
            //    }
            //    else
            //    {
            //        this.criteria = "No result found for search criteria (" + this.kword.Value + ")!!";
            //    }
            //}
            //else
            //{
            //    this.criteria = "The Application number cannot be more one (1) !!";
            //}
        }

        protected void gvX_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //this.gvX.PageIndex = e.NewPageIndex;
            //if (this.Session["lt_m"] != null)
            //{
            //    this.lt_m.Clear();
            //    this.lt_m = (List<XObjs.Office_view>)this.Session["lt_m"];
            //}
            //this.gvX.DataSource = this.lt_m;
            //this.gvX.DataBind();
            //if (this.Session["x_cnt"] != null)
            //{
            //    this.x_cnt = Convert.ToInt32(this.Session["x_cnt"]);
            //}
        }

        protected void gvX_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "TmViewClick")
            //{
            //    GridViewRow namingContainer = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
            //    int rowIndex = namingContainer.RowIndex;
            //    string str = e.CommandArgument.ToString();
            //    base.Response.Redirect("acceptance_slip_audit_details.aspx?x=" + str);
            //}
            //if (e.CommandName == "TmIndexClick")
            //{
            //    GridViewRow row2 = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
            //    int num2 = row2.RowIndex;
            //    string str2 = e.CommandArgument.ToString();
            //    base.Response.Redirect("acceptance_slip_index_card.aspx?x=" + str2);
            //}
        }


        //private Int32 GetTotalCount()
        //{
        //    //zues z = new zues();
        //    //return Convert.ToInt32(z.getAcceptanceMarkInfoRSCnt("5"));

        //}

        //private Int32 GetTotalCount2()
        //{
        //    return z.getNew_RowCount2(kword.Value).Count();

        //}
        protected void b_click(object sender, EventArgs e)
        {
            // this is for Get data from Database on button (paging button) click
            //string pageNo = ((Button)sender).CommandArgument;
            //PopulateData(Convert.ToInt32(pageNo), 100);
        }
        private void AddpagingButton()
        {
            //// this method for generate custom button for Custom paging in Gridview
            //int totalRecord = 0;
            //int noofRecord = 0;
            //totalRecord = ViewState["TotalRecord"] != null ? (int)ViewState["TotalRecord"] : 0;
            //noofRecord = ViewState["NoOfRecord"] != null ? (int)ViewState["NoOfRecord"] : 0;
            //int pages = 0;
            //if (totalRecord > 0 && noofRecord > 0)
            //{
            //    // Count no of pages 
            //    pages = (totalRecord / noofRecord) + ((totalRecord % noofRecord) > 0 ? 1 : 0);
            //    for (int i = 0; i < pages; i++)
            //    {
            //        Button b = new Button();
            //        b.Text = (i + 1).ToString();
            //        b.CommandArgument = (i + 1).ToString();
            //        b.ID = "Button_" + (i + 1).ToString();
            //        b.Click += new EventHandler(this.b_click);
            //        Panel1.Controls.Add(b);
            //    }
            //}

        }

        private void PopulateData(int pageNo, int noOfRecord)
        {
            //pz = z.getNew_RowCount();
            //String vcount = Convert.ToString(pz.Count);
            //String vstart = Convert.ToString(((pageNo - 1) * noOfRecord) + 1);
            //String vend = Convert.ToString(pageNo * noOfRecord);
            //XrowCount aa = (from c in pz where c.RowRanks == vstart select c).FirstOrDefault();
            //XrowCount ab = (from c in pz where c.RowRanks == vend select c).FirstOrDefault();
            //if (aa != null && ab != null)
            //{
            //    pageNo = Convert.ToInt32(aa.Tblld);
            //    noOfRecord = Convert.ToInt32(ab.Tblld);

            //}

            //if (aa != null && (!(ab != null)))
            //{
            //    pageNo = Convert.ToInt32(aa.Tblld);
            //    XrowCount ab2 = (from c in pz where c.RowRanks == vcount select c).FirstOrDefault();
            //    noOfRecord = Convert.ToInt32(ab2.Tblld);

            //}

            //// this.lt_m = this.z.getNew_AcceptanceManageRSX(pageNo, noOfRecord, GetTotalCount());
            //this.lt_m = this.z.getNew_AcceptanceManageRSX(pageNo, noOfRecord, GetTotalCount());


            ////  this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
            //this.Session["x_cnt"] = (z.getNew_RowCount()).Count;// GetTotalCount();
            //this.x_cnt = GetTotalCount();
            //this.Session["lt_m"] = this.lt_m;
            //this.gvX.DataSource = this.lt_m;
            //this.gvX.DataBind();

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
            this.max = Convert.ToInt32(ConfigurationManager.AppSettings["a_a_unit_limit"]);
            if (!base.IsPostBack)
            {
                //this.gvX.PageSize = 100;
                //this.gvX.PagerSettings.PageButtonCount = 30;
                //this.Session["lt_m"] = null;
                //this.Session["x_cnt"] = null;

                //PopulateData(1, 100);

                //ViewState["TotalRecord"] = (z.getNew_RowCount()).Count;// GetTotalCount();
                //ViewState["NoOfRecord"] = 100;

                //this.lt_m = this.z.getNew_AcceptanceManageRSX(this.stage, 0, this.max);
                //this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
                //this.Session["lt_m"] = this.lt_m;
                //this.gvX.DataSource = this.lt_m;
                //this.gvX.DataBind();
            }


            else if (this.Session["x_cnt"] != null)
            {
                this.x_cnt = Convert.ToInt32(this.Session["x_cnt"]);
            }

           // AddpagingButton();
        }
    }
}