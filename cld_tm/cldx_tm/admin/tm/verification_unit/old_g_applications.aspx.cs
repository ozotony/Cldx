using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.Classes;

namespace cld.admin.tm.verification_unit
{
    public partial class old_g_applications : System.Web.UI.Page
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
        public List<Classes.XObjs.G_App_info> lt_mi = new List<Classes.XObjs.G_App_info>();
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

        public string x_status="";
        public string x_data_status = "";

        public zues z = new zues();
        public List<string> pages = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pwalletID"] != null)
            {
                if (Session["pwalletID"].ToString() != "")
                { this.admin = Session["pwalletID"].ToString(); PopulateOffice(admin); }
                else
                { base.Response.Redirect("./xcontrol.aspx"); }
            }
            else
            { base.Response.Redirect("./xcontrol.aspx"); }
            
            //Eu is the current page, Limit is the page limit and nume is the total RS count
            this.limit = 40; this.nume = this.z.getGwalletRSCnt(x_status, x_data_status); Int64 pg = nume / limit;
            for (Int64 i = 1; i <= pg; i++)
            {
                string url = "<a href=\"#\" onclick=\"doPostResults(\'" + i + "\');\">" + i + "</a>";
                pages.Add(url);
            }
            if (Request.Params["eu"] != null)
            { this.eu = Convert.ToInt64(Request.Params["eu"].ToString()) - 1; }
            else { this.eu = 0; }
            this.dis = this.eu * limit + 1; limit = eu * limit + limit;
           
            this.lt_mi = this.z.getGAppInfoRSX(x_status, x_data_status, dis.ToString(), limit.ToString());
        }

        public void PopulateOffice(string admin)
        {
            string office =z.getRoleNameByID(z.getAdminDetails(admin).xroleID);
            office = office.Trim();
            if ((office != null) && (office != ""))
            {
                if (office == "Verification") { x_status = "1"; x_data_status = "Fresh"; }
                if (office == "Search") { x_status = "2"; x_data_status = "New"; }
                if (office == "Opposition") { x_status = "3"; x_data_status = "New"; }
                if (office == "Certificate ") { x_status = "4"; x_data_status = "New"; }
                if (office == "Acceptance") { x_status = "5"; x_data_status = "New"; }
            }
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

            if (selectSearchCriteria.SelectedValue == "applicant_name")
            {
                lt_mi = z.getGAdminSearchAppInfoRS(x_status, x_data_status, selectSearchCriteria.SelectedValue, item, dateFrom, dateTo);
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
                    lt_mi = z.getGAdminSearchAppInfoRS(x_status, x_data_status, selectSearchCriteria.SelectedValue, item, dateFrom, dateTo);

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
                    criteria = "The Registration number cannot be more one (1) !!";
                }
            }
        }

        protected void btnReloadPage_Click(object sender, EventArgs e)
        {
            this.lt_mi = this.z.getGAppInfoRSX(x_status, x_data_status, dis.ToString(), limit.ToString());
        }

    }
}