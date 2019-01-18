using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.Classes;

namespace cld.admin.tm
{
    public partial class preview_x2 : System.Web.UI.Page
    {
        public string admin = "";
        public int back;
        public string criteria = "";
        public string criteria_type = "";
        public string d = "";
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
        public string x = "";
        public string x_enrolleeRS;
        public string xRS = "";
        public string xtitle = "";
        public zues z = new zues();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString["x"] != null)
            {
                this.x = base.Request.QueryString["x"].ToString();
            }
            if (base.Request.QueryString["d"] != null)
            {
                this.d = base.Request.QueryString["d"].ToString();
            }
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
           // this.lt_mi = this.z.getMarkInfoXRS(this.x, this.d);
          //  greport.DataSource = this.lt_mi;
          //  greport.DataBind();

            this.xtitle = this.d.ToUpper();
            bool isPostBack = base.IsPostBack;
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            this.lt_mi = this.z.getMarkInfoXRS(this.x, this.d);
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("reg_number", typeof(string)),
                        new DataColumn("product_title", typeof(string)),
                        new DataColumn("tm_typeID",typeof(string)) ,
            new DataColumn("xid",typeof(string)),
             new DataColumn("reg_date",typeof(string)),
             new DataColumn("Status",typeof(string))});

            foreach (var dd in this.lt_mi)
            {
                string vstatus = "";
                vstatus = z.getTmOfficeByMID(dd.log_staff);
                if (vstatus != "")
                {



                 }
                else
                {
                    vstatus = "None";
                }
                dt.Rows.Add(dd.reg_number, dd.product_title, dd.tm_typeID, dd.xID, dd.reg_date,vstatus);
              

            }

            greport.DataSource = dt;
            greport.DataBind();
        }
    }
}