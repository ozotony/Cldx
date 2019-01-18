namespace cld.admin.tm
{
    using admin ;
    using Classes ;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class view_searcho : Page
    {
        public string admin = "";
        public int export;
        protected HtmlForm form1;
        public List<string> fulltext = new List<string>();
        public int kword_cnt;
        public string lga_id = "";
        public string log_officer = "";
        public List<List<zues.MarkInfo>> lt_lt_mi = new List<List<zues.MarkInfo>>();
        public List<zues.MarkInfo> lt_mi = new List<zues.MarkInfo>();
        public List<string> lt_searchcri = new List<string>();
        public List<int> lt_tot = new List<int>();
        public string markID;
        public List<string> new_search_text = new List<string>();
        public StringBuilder sbFulltext = new StringBuilder();
        public string searchcri = "";
        public string searchstr = "";
        public tm.SWallet swallet = new tm.SWallet();
        public tm t = new tm();
        public int totsearch;
        protected HiddenField xlof_officer;
        protected HiddenField xmarkID;
        public string xresults = "";
        protected HiddenField xsearchcri;
        protected HiddenField xsearchstr;
        public zues z = new zues();

        public string calcPercentile(decimal tot, decimal val)
        {
            decimal num = 0M;
            num = (val / tot) * 100M;
            return num.ToString("#.##");
        }

        public string convertMarkList2Html(List<zues.MarkInfo> xm, string xquery, int tot, int val, string final)
        {
            string str = "";
            str = str + "<tr >" + "<td class=\"\" align=\"center\" colspan=\"8\">";
            if (final != "100")
            {
                object obj2 = str;
                str = string.Concat(new object[] { obj2, "<strong>", xm.Count, "</strong> RECORDS FOUND FOR SEARCH QUERY <strong>\"", xquery.ToUpper(), " \" </strong>=><em> PERCENTILE=<strong>", this.calcPercentile(tot, val), "</strong></em>%</td>" });
            }
            else
            {
                object obj3 = str;
                str = string.Concat(new object[] { obj3, "<strong>", xm.Count, "</strong> RECORDS FOUND FOR SEARCH QUERY <strong>\"", xquery.ToUpper(), " \" </strong> </td>" });
            }
            str = ((((((str + "</tr>") + "<tr>" + "<td width=\"5%\" class=\"tdcolheader\">S/N</td>") + "<td width=\"20%\" class=\"tdcolheader\">REGISTRATION NUMBER </td>" + " <td width=\"30%\" class=\"tdcolheader\"> TRADEMARK </td>") + "<td width=\"15%\" class=\"tdcolheader\">APPLICANT NAME</td>" + "<td width=\"15%\" class=\"tdcolheader\">CLASS</td>") + "<td width=\"10%\" class=\"tdcolheader\">FILING DATE</td>" + "<td width=\"5%\" class=\"tdcolheader\" colspan=\"2\"> &nbsp;</td>") + "</tr>" + "<tr>") + "<td class=\"\" align=\"center\" colspan=\"8\">" + "<table class=\"xtreme\" width=\"100%\">";
            int num = 1;
            for (int i = 0; i < xm.Count; i++)
            {
                object obj4 = str + "<tr>";
                str = (((((string.Concat(new object[] { obj4, "<td width=\"5%\" align=\"center\" class=\"xstyle\">", num, "</td>" }) + "<td width=\"20%\" align=\"center\" class=\"xstyle\">" + xm[i].reg_number.ToString() + "</td>") + "<td width=\"30%\" align=\"center\" class=\"xstyle\">" + xm[i].product_title.ToString() + "</td>") + "<td width=\"15%\" align=\"center\" class=\"xstyle\">" + this.z.getApplicant(xm[i].log_staff).ToUpper() + "</td>") + "<td width=\"15%\" align=\"center\" class=\"xstyle\">" + xm[i].national_classID + "</td>") + "<td width=\"10%\" align=\"center\" class=\"xstyle\">" + xm[i].reg_date.ToString() + " </td>") + " <td width=\"5%\" align=\"center\" class=\"xstyle\">";
                if (xm[i].logo_pic != "")
                {
                    str = str + "<a href=" + xm[i].logo_pic + " target=\"_blank\">View</a>";
                }
                else
                {
                    str = str + "<a href=\"#\">NA</a>";
                }
                str = str + "</td>" + "</tr>";
                num++;
            }
            return ((str + "</table>") + "</td>" + "</tr>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ViewState["PreviousPage"] = base.Request.UrlReferrer;
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
            if (base.Request.QueryString["x"] != null)
            {
                this.xmarkID.Value = base.Request.QueryString["x"].ToString();
                this.xlof_officer.Value = this.admin;
            }
            this.swallet = this.t.getSwalletByID(this.xmarkID.Value);
            ///////
            if (swallet.mark_infoID != null)
            {
                string item = this.swallet.search_str.Replace("'", "");
                string selectSearchClass =swallet.xclass;
                foreach (string str2 in item.Split(new char[] { ' ' }))
                {
                    if (str2 != "")
                    {
                        List<zues.MarkInfo> list = new List<zues.MarkInfo>();
                        int count = 0;
                        list = this.z.getSearchMarkInfoRS(str2, null, selectSearchClass);
                        if (list.Count > 0)
                        {
                            for (int k = 0; k < list.Count; k++)
                            {
                                if (!this.lt_searchcri.Contains(list[k].xID))
                                {
                                    this.lt_searchcri.Add(list[k].xID);
                                }
                            }
                            this.fulltext.Add(str2);
                            count = list.Count;
                            this.lt_tot.Add(count);
                            this.totsearch += this.lt_tot[this.lt_tot.Count - 1];
                            this.lt_lt_mi.Add(list);
                        }
                    }
                }
                foreach (string str3 in this.fulltext)
                {
                    string str4 = str3 + " ";
                    this.new_search_text.Add(str4);
                    this.sbFulltext.Append(str4);
                }
                this.kword_cnt = this.fulltext.Count;
               
                this.fulltext.Add(item);
                this.searchstr = this.sbFulltext.ToString().Trim();
                for (int i = 0; i < this.lt_searchcri.Count; i++)
                {
                    if (i != (this.lt_searchcri.Count - 1))
                    {
                        this.searchcri = this.searchcri + this.lt_searchcri[i] + ",";
                    }
                    else
                    {
                        this.searchcri = this.searchcri + this.lt_searchcri[i];
                    }
                }
                this.xsearchcri.Value = this.searchcri;
                this.xsearchstr.Value = this.searchstr;
                string final = "";
                for (int j = 0; j < this.lt_lt_mi.Count; j++)
                {
                    if (j != (this.lt_lt_mi.Count - 1))
                    {
                        this.xresults = this.xresults + this.convertMarkList2Html(this.lt_lt_mi[j], this.fulltext[j], this.totsearch, this.lt_tot[j], "");
                    }
                    else
                    {
                        final = "100";
                        this.xresults = this.xresults + this.convertMarkList2Html(this.lt_lt_mi[j], this.fulltext[j], this.totsearch, this.lt_tot[j], final);
                    }
                }
                if (this.xresults == "")
                {
                    this.xresults = this.xresults + "<tr >";
                    this.xresults = this.xresults + "<td class=\"\" align=\"center\" colspan=\"8\">";
                    this.xresults = this.xresults + "<strong>NO</strong> RECORD WAS FOUND FOR SEARCH QUERY <strong>\"" + item.ToUpper() + " \" </strong> </td>";
                    this.xresults = this.xresults + "</td>";
                    this.xresults = this.xresults + "</tr>";
                }
            }
        }

        protected void btnPrevBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(this.ViewState["PreviousPage"].ToString());
        }
        /////
    }
}

