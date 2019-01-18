using cld.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace cld.admin.tm
{
    public partial class examiners : Page
    {
        public string admin = "6";
        public string admin_status = "4";
        public int back;
        public string cnt_msg = "";
        public string cri = "";
        public string criteria = "";
        public string criteria_type = "";
        public string data_status = "Search 2 Conducted";
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
        public int select_cnt;
        public string select_search = "";
        public int selectLga;
        public string selectzone = "";
        public string stage = "33";
        public int succ;
        public zues.TmOffice tm = new zues.TmOffice();
        public int totsearch;
        public string touch;
        public long x_cnt;
        public string x_enrolleeRS;
        public string xmsg = "";
        public string xRS = "";
        public zues z = new zues();
        protected TextBox comment;
        protected GridView gvX;
        protected Button UpdateBatch;

        protected void btnChangePin_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("../../cp.aspx?x=" + this.admin);
        }

        protected void btnLogOff_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("./lo.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("./examiners_unit/profile.aspx");
        }

        protected void btnReloadPage_Click(object sender, EventArgs e)
        {
            //this.lt_m.Clear();
            //this.x_cnt = 0L;
            //this.comment.Visible = false;
            //this.UpdateBatch.Visible = false;
            //this.max = Convert.ToInt32(ConfigurationManager.AppSettings["e_unit_limit"]);
            //this.gvX.PageSize = 100;
            //this.Session["lt_m"] = null;
            //this.Session["x_cnt"] = null;
            //this.lt_m = this.z.getNew_MarkInfoRSX(this.stage, this.data_status, 0, this.max);
            //foreach (XObjs.Office_view _view in this.lt_m)
            //{
            //    this.tm = this.z.getTmOfficeDetailsByOffice(_view.log_staff, "33", "Search 2 Conducted");
            //    _view.scmt = this.tm.xcomment;
            //}
            //this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
            //this.Session["lt_m"] = this.lt_m;
            //this.gvX.DataSource = this.lt_m;
            //this.gvX.DataBind();
            //this.criteria = string.Concat(new object[] { this.lt_m.Count<XObjs.Office_view>(), " result(s) found for search criteria (", this.kword.Value, ")!!" });
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

        protected void btnViewStats_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("./examiners_unit/eed.aspx");
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
                string str = e.CommandArgument.ToString();
                base.Response.Redirect("examination_data_detail.aspx?x=" + str + "&cri=" + this.Session["e_type"].ToString());
            }
            if (e.CommandName == "TmDeleteClick")
            {
                GridViewRow row = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                int rowIndex = row.RowIndex;
                RadioButtonList list = (RadioButtonList)this.gvX.Rows[rowIndex].Cells[11].FindControl("rbValid");
                CheckBox box = (CheckBox)this.gvX.Rows[rowIndex].Cells[12].FindControl("cbAddBatch");
                list.ClearSelection();
                box.Checked = false;
                if (this.select_cnt == 0)
                {
                    this.comment.Visible = false;
                    UpdateBatch.Visible = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["pwalletID"] != null) && (this.Session["pwalletID"].ToString() != ""))
            {
                this.admin = this.Session["pwalletID"].ToString();
                HiddenField1.Value = this.admin;
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
                this.stage = "33";
                this.data_status = "Search 2 Conducted";
            }
            else if (this.e_type == "r")
            {
                this.stage = "3";
                this.data_status = "Re-examine";
            }
            if (!base.IsPostBack)
            {
                //this.comment.Visible = false;
                //this.UpdateBatch.Visible = false;
                //this.max = Convert.ToInt32(ConfigurationManager.AppSettings["e_unit_limit"]);
                //this.gvX.PageSize = 100;
                //this.Session["lt_m"] = null;
                //this.Session["x_cnt"] = null;
                //this.lt_m = this.z.getNew_MarkInfoRSX(this.stage, this.data_status, 0, this.max);
                //foreach (XObjs.Office_view _view in this.lt_m)
                //{
                //    this.tm = this.z.getTmOfficeDetailsByOffice(_view.log_staff, "3", "Search Conducted");
                //    _view.scmt = this.tm.xcomment;
                //}
                //this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
                //this.Session["lt_m"] = this.lt_m;
                //this.gvX.DataSource = this.lt_m;
                //this.gvX.DataBind();
            }
            else if (this.Session["x_cnt"] != null)
            {
                this.x_cnt = Convert.ToInt32(this.Session["x_cnt"]);
            }
        }

        protected void rbValid_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.gvX.Rows)
            {
                CheckBox box = (CheckBox)row.FindControl("cbAddBatch");
                RadioButtonList list = (RadioButtonList)row.FindControl("rbValid");
                if (list.SelectedValue != "")
                {
                    box.Checked = true;
                    this.comment.Visible = true;
                    this.UpdateBatch.Visible = true;
                    this.select_cnt++;
                    this.cnt_msg = this.select_cnt + " Messages Selected";
                }
            }
        }

        protected void UpdateBatch_Click(object sender, EventArgs e)
        {
            this.xmsg = "";
            this.cnt_msg = "";
            if (this.comment.Text != "")
            {
                foreach (GridViewRow row in this.gvX.Rows)
                {
                    CheckBox box = (CheckBox)row.FindControl("cbAddBatch");
                    RadioButtonList list = (RadioButtonList)row.FindControl("rbValid");
                    if ((box != null) && box.Checked)
                    {
                        if (list.SelectedValue == "Registrable")
                        {
                            this.admin_status = "4";
                        }
                        else if (list.SelectedValue == "Non-registrable")
                        {
                            this.admin_status = "4";
                        }
                        else if (list.SelectedValue == "Re-conduct search 1")
                        {
                            this.admin_status = "22";
                        }
                        Label label = (Label)row.FindControl("lblLogStaff");
                        this.succ += this.z.a_mul_tm_office(label.Text, this.admin_status, list.SelectedValue, this.comment.Text, "", "", "", this.admin);
                    }
                }
                if (Convert.ToInt32(this.succ) > 0)
                {
                    this.xmsg = "Data updated successfully!!";
                }
                else
                {
                    this.xmsg = "Data not updated, Please try again later!!";
                }
                if (this.Session["e_type"] != null)
                {
                    if (this.Session["e_type"].ToString() == "n")
                    {
                        base.Response.Redirect("./examiners.aspx?x=n");
                    }
                    else
                    {
                        base.Response.Redirect("./examiners.aspx?x=r");
                    }
                }
                else
                {
                    base.Response.Redirect("./xcontrol.aspx");
                }
            }
            else
            {
                this.xmsg = "Please enter a comment in the Comment Box!!";
            }
        }
    }
}