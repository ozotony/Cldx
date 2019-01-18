using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm
{
    public partial class g_Recordal5 : System.Web.UI.Page
    {
        public string admin = "0";
        public int back;
        public string criteria = "";
        public string criteria_type = "";
        public string data_status = "Certified";
        public string dateFrom = "";
        public string dateFromArr = "";
        public string dateTo = "";
        public string dateToArr = "";
        public long dis;
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
        public string r_sectorRS = "";
        public string row_enrolleeRS;
        public string select_search = "";
        public int selectLga;
        public string selectzone = "";
        public string sh = "";
        public SortedList<int, string> slt_checked = new SortedList<int, string>();
        public string stage = "8";
        public string touch;
        public long x_cnt;
        public string x_enrolleeRS;
        public string xRS = "";
        public zues z = new zues();

        protected void btnReloadPage_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("./registrar.aspx");
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
            if (e.CommandName == "TmViewClick")
            {
                GridViewRow namingContainer = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                int rowIndex = namingContainer.RowIndex;
                string str = e.CommandArgument.ToString();
                base.Response.Redirect("v_data_details.aspx?x=" + str);
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
            if (!base.IsPostBack)
            {
                //this.max = Convert.ToInt32(ConfigurationManager.AppSettings["r_unit_limit"]);
                //this.gvX.PageSize = 100;
                //this.Session["lt_m"] = null;
                //this.Session["x_cnt"] = null;
                //this.lt_m = this.z.getNew_MarkInfoRSX(this.stage, this.data_status, 0, this.max);
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
    }
}