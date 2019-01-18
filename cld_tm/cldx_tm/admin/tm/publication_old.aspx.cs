using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.Classes;

namespace cld.admin.tm
{
    public partial class publication_old : System.Web.UI.Page
    {
        public string admin = "";
        public int back;
        public string criteria = "";
        public string criteria_type = "";
        public string dateFrom = "";
        public string dateFromArr = "";
        public string dateTo = "";
        public string dateToArr = "";
        public Int64 dis;
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
        public string selectzone = "";
        public string sh = "";
        public int totsearch;
        public string touch;
        public string x_enrolleeRS;
        public string xRS = "";
        public zues z = new zues();
        public List<string> pages = new List<string>(); 
        protected void Page_Load(object sender, EventArgs e)
        { //Eu is the current page, Limit is the page limit and nume is the total RS count
            this.limit = 40; this.nume = this.z.getMarkInfoRSCnt("5", "Accepted"); Int64 pg = nume / limit; if ((pg > 0) && (nume > pg * limit)) { pg = pg + 1; }
            for (Int64 i = 1; i <= pg; i++)
            {
                string url = "<a href=\"#\" onclick=\"doPostResults(\'" + i + "\');\">" + i + "</a>";
                pages.Add(url);
            }
            if (Request.Params["eu"] != null)
            { this.eu = Convert.ToInt64(Request.Params["eu"].ToString()) - 1; }
            else { this.eu = 0; }
            this.dis = this.eu * limit + 1; limit = eu * limit + limit;
            if (Session["pwalletID"] != null)
            {
                if (Session["pwalletID"].ToString() != "")
                { this.admin = Session["pwalletID"].ToString(); }
                else
                { base.Response.Redirect("./xcontrol.aspx"); }
            }
            else
            { base.Response.Redirect("./xcontrol.aspx"); }
            this.lt_mi = this.z.getMarkInfoRSX("5", "Accepted", dis.ToString(), limit.ToString());
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> fulltext = new List<string>();
            string item = kword.Value.Replace("'", "");
            dateFrom = z.formatSearchDate(datepickerFrom.Value);
            dateTo = z.formatSearchDate(datepickerTo.Value);
            if ((dateTo == "") || (dateTo == null))
            {
                dateTo = DateTime.Today.Date.ToString("yyyy-MM-dd");
            }
            foreach (string str2 in item.Split(new char[] { ' ' }))
            {
                if (str2 != "")
                {
                    fulltext.Add(str2);
                }
            }

            if (selectSearchCriteria.SelectedValue == "product_title")
            {
                lt_mi = z.getAdminSearchMarkInfoRS("5", "Accepted", selectSearchCriteria.SelectedValue, fulltext, dateFrom, dateTo);
                if (lt_mi.Count() > 0)
                {
                    criteria = lt_mi.Count() + " result(s) found for search criteria (" + kword.Value + ")!!";
                }
                else
                {
                    criteria = "No result found for search criteria (" + kword.Value + ")!!";
                }
            }
            else
            {
                if (fulltext.Count() == 1)
                {
                    if (lt_mi.Count() > 0)
                    {
                        lt_mi = z.getAdminSearchMarkInfoRS("5", "Accepted", selectSearchCriteria.SelectedValue, fulltext, dateFrom, dateTo);
                    }
                    else
                    {
                        criteria = "No result found for search criteria (" + kword.Value + ")!!";
                    }
                }
                else
                {
                    criteria = "The Application number cannot be more one (1) !!";
                }
            }
        }

        protected void btnReloadPage_Click(object sender, EventArgs e)
        {
            this.lt_mi = this.z.getMarkInfoRS("5", "Accepted");
        }
    }
}