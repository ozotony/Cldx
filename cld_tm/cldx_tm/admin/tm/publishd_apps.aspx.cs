using cld.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using cld.Classes;

namespace cld.admin.tm
{
    public partial class publishd_apps : Page
    {
        public string admin = "";
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
        public string kw = "";
        public string lga_id = "";
        public long limit;
        public List<zues.MarkInfo> lt_mi = new List<zues.MarkInfo>();
        public long nume;
        public List<string> pages = new List<string>();
        public string r_sectorRS = "";
        public string row_enrolleeRS;
        public string select_search = "";
        public int selectLga;
        public string selectzone = "";
        public string sh = "";
        public int totsearch;
        public string touch;
        public string x_enrolleeRS;
        public string xRS = "";
        public zues z = new zues();

        protected void btnReloadPage_Click(object sender, EventArgs e)
        {
            this.lt_mi = this.z.getMarkInfoRS("5", "Deferred");
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
                this.lt_mi = this.z.getAdminSearchMarkInfoRS("5", "Deferred", this.selectSearchCriteria.SelectedValue, fulltext, this.dateFrom, this.dateTo);
                if (this.lt_mi.Count<zues.MarkInfo>() > 0)
                {
                    this.criteria = string.Concat(new object[] { this.lt_mi.Count<zues.MarkInfo>(), " result(s) found for search criteria (", this.kword.Value, ")!!" });
                }
                else
                {
                    this.criteria = "No result found for search criteria (" + this.kword.Value + ")!!";
                }
            }
            else if (fulltext.Count<string>() == 1)
            {
                if (this.lt_mi.Count<zues.MarkInfo>() > 0)
                {
                    this.lt_mi = this.z.getAdminSearchMarkInfoRS("5", "Deferred", this.selectSearchCriteria.SelectedValue, fulltext, this.dateFrom, this.dateTo);
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.limit = 40L;
            this.nume = this.z.getMarkInfoRSCnt("5", "Deferred");
            long num = this.nume / this.limit;
            if ((num > 0L) && (this.nume > (num * this.limit)))
            {
                num += 1L;
            }
            for (long i = 1L; i <= num; i += 1L)
            {
                string item = string.Concat(new object[] { "<a href=\"#\" onclick=\"doPostResults('", i, "');\">", i, "</a>" });
                this.pages.Add(item);
            }
            if (base.Request.Params["eu"] != null)
            {
                this.eu = Convert.ToInt64(base.Request.Params["eu"].ToString()) - 1L;
            }
            else
            {
                this.eu = 0L;
            }
            this.dis = (this.eu * this.limit) + 1L;
            this.limit = (this.eu * this.limit) + this.limit;
            if (this.Session["pwalletID"] != null)
            {
                if (this.Session["pwalletID"].ToString() != "")
                {
                    this.admin = this.Session["pwalletID"].ToString();
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
            this.lt_mi = this.z.getMarkInfoRSX("5", "Deferred", this.dis.ToString(), this.limit.ToString());
        }
    }
}