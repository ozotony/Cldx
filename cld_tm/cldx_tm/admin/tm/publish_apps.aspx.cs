using cld.admin;
using cld.Classes;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm
{
    public partial class publish_apps : System.Web.UI.Page
    {
        public string admin = "";
        public int current_batch_no;
        public string batch_html;
        public int cur_unbatched_count = 0;

        public zues z = new zues();
        public Classes.tm t = new Classes.tm();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pwalletID"] != null)
            {
                if (Session["pwalletID"].ToString() != "")
                {
                    this.admin = Session["pwalletID"].ToString();
                }
                else
                {
                    base.Response.Redirect("../lo.aspx");
                }
            }
            else
            {
                base.Response.Redirect("../lo.aspx");
            }

            this.current_batch_no = this.z.getCurrentBatch();
            cur_unbatched_count = z.getCurrentBatchCnt(1);

            this.batch_html = this.batch_html + "<tr>";
            this.batch_html = this.batch_html + "<td align=\"left\" width=\"10%\">";
            this.batch_html = this.batch_html + "SN";
            this.batch_html = this.batch_html + "</td>";
            this.batch_html = this.batch_html + "<td align=\"left\" width=\"40%\">";
            this.batch_html = this.batch_html + "Batch";
            this.batch_html = this.batch_html + "</td>";
            this.batch_html = this.batch_html + "<td align=\"left\" width=\"50%\">";
            this.batch_html = this.batch_html + "Application Count";
            this.batch_html = this.batch_html + "</td>";
            this.batch_html = this.batch_html + "</tr>";
            batch_html = batch_html + "<tr>";
            batch_html = batch_html + "<td align=\"left\" width=\"100%\" colspan=\"3\">";
            batch_html = batch_html + "<hr/>";
            batch_html = batch_html + "</td>";
            batch_html = batch_html + "</tr>";
            List<string> b = new List<string>();

            int sn = 1;
            for (int i = current_batch_no; i > 1; i--)
            {
                string batch_row = "";
                int no = i - 1;
                int cur_i = i + 1;
                int batch_count = z.getCurrentBatchCnt(i);
                batch_row = batch_row + "<tr>";
                batch_row = batch_row + "<td align=\"left\" width=\"10%\">" + sn.ToString();
                batch_row = batch_row + "</td>";
                batch_row = batch_row + "<td align=\"left\" width=\"40%\">";
                batch_row = batch_row + "<strong>Batch Number : " + no + "</strong>";
                batch_row = batch_row + "</td>";
                batch_row = batch_row + "<td align=\"left\" width=\"50%\">";
                batch_row = batch_row + "<strong> " + batch_count + "</strong>";
                batch_row = batch_row + "</td>";
                batch_row = batch_row + "</tr>";
                batch_row = batch_row + "<tr>";
                batch_row = batch_row + "<td align=\"left\" width=\"100%\" colspan=\"3\">";
                batch_row = batch_row + "<hr/>";
                batch_row = batch_row + "</td>";
                batch_row = batch_row + "</tr>";
                b.Add(batch_row); sn++;
            }

            foreach (string bb in b)
            {
                batch_html += bb;
            }
            this.batch_html = this.batch_html + "<tr>";
            this.batch_html = this.batch_html + "<td align=\"left\" width=\"100%\" colspan=\"3\">";
            this.batch_html = this.batch_html + "&nbsp;";
            this.batch_html = this.batch_html + "</td>";
            this.batch_html = this.batch_html + "</tr>";

            btnAddToBatch.Text = "Add ("+cur_unbatched_count+") Records To Batch " +current_batch_no;
        }

        protected void btnAddToBatch_Click(object sender, EventArgs e)
        {
            //this.current_batch_no = this.z.getCurrentBatch();
            current_batch_no = current_batch_no + 1;
            int succ = t.UpdateBatch(current_batch_no, admin);
            if (succ > 0)
            { Response.Redirect("./publication_unit/profile.aspx");  }
            else
            {  Response.Redirect("./publication_unit/profile.aspx");  }
        }
    }
}