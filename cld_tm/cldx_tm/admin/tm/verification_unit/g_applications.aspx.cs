namespace cld.admin.tm.verification_unit
{
    using cld.admin;
    using cld.Classes;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public partial class g_applications : Page
    {
        public string admin = "0";
        public int back;
        public string criteria = "";
        public string criteria_type = "";
        public string dateFrom = "";
        public string dateFromArr = "";
        public string dateTo = "";
        public string dateToArr = "";
        public long dis;
        public string enrolleeRS = "";
        public string enrolleeRS1 = "";
        public long eu;
        public int export;
        public List<XObjs.Fee_list> fee_list = new List<XObjs.Fee_list>();
        public XObjs.G_Pwallet g_pwallet = new XObjs.G_Pwallet();
        public string kw = "";
        public string lga_id = "";
        public long limit;
        public List<XObjs.G_App_info> lt_m = new List<XObjs.G_App_info>();
        public List<zues.MarkInfo> lt_mi = new List<zues.MarkInfo>();
        public int max;
        public string r_sectorRS = "";
        public Retriever ret = new Retriever();
        public string row_enrolleeRS;
        public string select_search = "";
        public int selectLga;
        public string selectzone = "";
        public string sh = "";
        public SortedList<int, string> slt_checked = new SortedList<int, string>();
        public string touch;
        public long x_cnt;
        public string x_data_status = "";
        public string x_enrolleeRS;
        public string x_status = "";
        public string xRS = "";
        public zues z = new zues();
        public List<XrowCount> pz = new List<XrowCount>();

        protected void btnReloadPage_Click(object sender, EventArgs e)
        {
          //  base.Response.Redirect("./g_applications.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //List<string> source = new List<string>();
            //string kword = this.kword.Value.Replace("'", "");
            //this.dateFrom = this.z.formatSearchDate(this.datepickerFrom.Value);
            //this.dateTo = this.z.formatSearchDate(this.datepickerTo.Value);
            //if ((this.dateTo == "") || (this.dateTo == null))
            //{
            //    this.dateTo = DateTime.Today.Date.ToString("yyyy-MM-dd");
            //}
            //foreach (string str2 in kword.Split(new char[] { ' ' }))
            //{
            //    if (str2 != "")
            //    {
            //        source.Add(str2);
            //    }
            //}
            //if (this.selectSearchCriteria.SelectedValue == "product_title")
            //{
            //    this.lt_m = this.z.getNewGAdminSearchAppInfoRS(this.x_status, this.x_data_status, this.selectSearchCriteria.SelectedValue, kword, this.dateFrom, this.dateTo);
            //    if (this.lt_m.Count<XObjs.G_App_info>() > 0)
            //    {
            //        foreach (XObjs.G_App_info _info in this.lt_m)
            //        {
            //            _info.xname = this.z.getG_ApplicantByLogstaff(_info.log_staff)[0].xname;
            //            _info.oai_no = this.z.getG_ValidationIDByApp_infoID(_info.id);
            //            _info.xstat = "None";
            //            _info.xstat = this.z.getG_PwalletStatusByID(_info.log_staff);
            //            foreach (XObjs.Fee_list _list in this.fee_list)
            //            {
            //                if (_list.item_code == _info.item_code)
            //                {
            //                    _info.req_type = _list.item;
            //                }
            //            }
            //        }
            //        this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
            //        this.Session["lt_m"] = this.lt_m;
            //        this.gvX.DataSource = this.lt_m;
            //        this.gvX.DataBind();
            //        this.criteria = string.Concat(new object[] { this.lt_mi.Count<zues.MarkInfo>(), " result(s) found for search criteria (", this.kword.Value, ")!!" });
            //    }
            //    else
            //    {
            //        this.criteria = "No result found for search criteria (" + this.kword.Value + ")!!";
            //    }
            //}
            //else if (source.Count<string>() == 1)
            //{
            //    this.lt_m = this.z.getNewGAdminSearchAppInfoRS(this.x_status, this.x_data_status, this.selectSearchCriteria.SelectedValue, kword, this.dateFrom, this.dateTo);
            //    if (this.lt_m.Count<XObjs.G_App_info>() > 0)
            //    {
            //        foreach (XObjs.G_App_info _info2 in this.lt_m)
            //        {
            //            _info2.xname = this.z.getG_ApplicantByLogstaff(_info2.log_staff)[0].xname;
            //            _info2.oai_no = this.z.getG_ValidationIDByApp_infoID(_info2.id);
            //            _info2.xstat = "None";
            //            _info2.xstat = this.z.getG_PwalletStatusByID(_info2.log_staff);
            //            foreach (XObjs.Fee_list _list2 in this.fee_list)
            //            {
            //                if (_list2.item_code == _info2.item_code)
            //                {
            //                    _info2.req_type = _list2.item;
            //                }
            //            }
            //        }
            //        this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
            //        this.Session["lt_m"] = this.lt_m;
            //        this.gvX.DataSource = this.lt_m;
            //        this.gvX.DataBind();
            //        this.criteria = string.Concat(new object[] { this.lt_m.Count<XObjs.G_App_info>(), " result(s) found for search criteria (", this.kword.Value, ")!!" });
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
            this.gvX.PageIndex = e.NewPageIndex;
            if (this.Session["lt_m"] != null)
            {
                this.lt_m.Clear();
                this.lt_m = (List<XObjs.G_App_info>)this.Session["lt_m"];
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
                base.Response.Redirect("g_application_details.aspx?x=" + str);
            }
        }

        protected void b_click(object sender, EventArgs e)
        {
            // this is for Get data from Database on button (paging button) click
            string pageNo = ((Button)sender).CommandArgument;
            PopulateData(Convert.ToInt32(pageNo), 100);
        }
        private void AddpagingButton()
        {
            // this method for generate custom button for Custom paging in Gridview
            int totalRecord = 0;
            int noofRecord = 0;
            totalRecord = ViewState["TotalRecord"] != null ? (int)ViewState["TotalRecord"] : 0;
            noofRecord = ViewState["NoOfRecord"] != null ? (int)ViewState["NoOfRecord"] : 0;
            int pages = 0;
            if (totalRecord > 0 && noofRecord > 0)
            {
                // Count no of pages 
                pages = (totalRecord / noofRecord) + ((totalRecord % noofRecord) > 0 ? 1 : 0);
                for (int i = 0; i < pages; i++)
                {
                    Button b = new Button();
                    b.Text = (i + 1).ToString();
                    b.CommandArgument = (i + 1).ToString();
                    b.ID = "Button_" + (i + 1).ToString();
                    b.Click += new EventHandler(this.b_click);
                    Panel1.Controls.Add(b);
                }
            }

        }

        //private Int32 GetTotalCount()
        //{

        //    zues z = new zues();
        //    return this.z.getGAppInfoRSX(this.x_status, this.x_data_status, pageNo.ToString(), noOfRecord.ToString()).Count();
        //    return Convert.ToInt32(z.getCriRegisteredMarkInfoRSCnt(this.stage, this.data_status));

        //}
        private void PopulateData(int pageNo, int noOfRecord)
        {

            pz = z.getNew_RowCount11(this.x_status, this.x_data_status);
            String vcount = Convert.ToString(pz.Count);
            String vstart = Convert.ToString(((pageNo - 1) * noOfRecord) + 1);
            String vend = Convert.ToString(pageNo * noOfRecord);
            XrowCount aa = (from c in pz where c.RowRanks == vstart select c).FirstOrDefault();
            XrowCount ab = (from c in pz where c.RowRanks == vend select c).FirstOrDefault();
            if (aa != null && ab != null)
            {
                pageNo = Convert.ToInt32(aa.Tblld);
                noOfRecord = Convert.ToInt32(ab.Tblld);

            }

            if (aa != null && (!(ab != null)))
            {
                pageNo = Convert.ToInt32(aa.Tblld);
                XrowCount ab2 = (from c in pz where c.RowRanks == vcount select c).FirstOrDefault();
                noOfRecord = Convert.ToInt32(ab2.Tblld);

            }

            // this.lt_m = this.z.getNew_AcceptanceManageRSX(pageNo, noOfRecord, GetTotalCount());
            // this.lt_m = this.z.getNew_AcceptanceManageRSX(pageNo, noOfRecord, GetTotalCount());

            this.lt_m = this.z.getGAppInfoRSX(this.x_status, this.x_data_status, pageNo.ToString(), noOfRecord.ToString());

            foreach (XObjs.G_App_info _info in this.lt_m)
            {
                _info.xname = this.z.getG_ApplicantByLogstaff(_info.log_staff)[0].xname;
                _info.oai_no = this.z.getG_ValidationIDByApp_infoID(_info.id);
                _info.xstat = "None";
                _info.xstat = this.z.getG_PwalletStatusByID(_info.log_staff);
                foreach (XObjs.Fee_list _list in this.fee_list)
                {
                    if (_list.item_code == _info.item_code)
                    {
                        _info.req_type = _list.item;
                    }
                }
            }

            //   this.lt_m = this.z.getNew_MarkInfoRtmRSX(this.stage, this.data_status, pageNo, noOfRecord);



            // this.Session["x_cnt"] = (z.getNew_RowCount()).Count;// GetTotalCount();
            this.x_cnt = this.lt_m.Count();
            this.Session["lt_m"] = this.lt_m;
            this.gvX.DataSource = this.lt_m;
            this.gvX.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.PopulateOffice(this.admin);
            //if ((this.Session["pwalletID"] != null) && (this.Session["pwalletID"].ToString() != ""))
            //{
            //    this.admin = this.Session["pwalletID"].ToString();
            //    this.PopulateOffice(this.admin);
            //}
            //else
            //{
            //    base.Response.Redirect("../xcontrol.aspx");
            //}
            //this.fee_list = this.ret.getFee_listByCat("tm");
            //if (!base.IsPostBack)
            //{
            //    this.max = Convert.ToInt32(ConfigurationManager.AppSettings["v_unit_limit"]);
            //    this.gvX.PageSize = 100;
            //    this.Session["lt_m"] = null;
            //    this.Session["x_cnt"] = null;
            //  //  this.lt_m = this.z.getGAppInfoRSX(this.x_status, this.x_data_status, "0", this.max.ToString());

            //    int kk = z.getNew_RowCount11(this.x_status, this.x_data_status).Count();
            //    //  this.lt_m = this.z.getNew_MarkInfoRtmRSX(this.stage, this.data_status, 0, this.max);


            //    this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
            //    this.Session["lt_m"] = this.lt_m;
            //    PopulateData(1, 100);

            //    ViewState["TotalRecord"] = (z.getNew_RowCount11(this.x_status, this.x_data_status)).Count;// GetTotalCount();
            //    ViewState["NoOfRecord"] = 100;
            //    //foreach (XObjs.G_App_info _info in this.lt_m)
            //    //{
            //    //    _info.xname = this.z.getG_ApplicantByLogstaff(_info.log_staff)[0].xname;
            //    //    _info.oai_no = this.z.getG_ValidationIDByApp_infoID(_info.id);
            //    //    _info.xstat = "None";
            //    //    _info.xstat = this.z.getG_PwalletStatusByID(_info.log_staff);
            //    //    foreach (XObjs.Fee_list _list in this.fee_list)
            //    //    {
            //    //        if (_list.item_code == _info.item_code)
            //    //        {
            //    //            _info.req_type = _list.item;
            //    //        }
            //    //    }
            //    //}
            //    //this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
            //    //this.Session["lt_m"] = this.lt_m;
            //    //this.gvX.DataSource = this.lt_m;
            //    //this.gvX.DataBind();
            //}
            //else if (this.Session["x_cnt"] != null)
            //{
            //    this.x_cnt = Convert.ToInt32(this.Session["x_cnt"]);
            //}

            //AddpagingButton();
        }

        public void PopulateOffice(string admin)
        {
            string str = this.z.getRoleNameByID(this.z.getAdminDetails(admin).xroleID).Trim();
            if ((str != null) && (str != ""))
            {
                if (str == "Verification")
                {
                    this.x_status = "1";
                    this.x_data_status = "Fresh";
                }
                if (str == "Search")
                {
                    this.x_status = "2";
                    this.x_data_status = "New";
                }
                if (str == "Opposition")
                {
                    this.x_status = "3";
                    this.x_data_status = "New";
                }
                if (str == "Certificate")
                {
                    this.x_status = "4";
                    this.x_data_status = "New";
                }
                if (str == "Acceptance")
                {
                    this.x_status = "5";
                    this.x_data_status = "New";
                }
            }
        }
    }
}