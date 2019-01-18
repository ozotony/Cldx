namespace cld.admin.tm.publication_unit
{
    using admin;
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;


    public partial class publish_batches : System.Web.UI.Page
    {
        public string admin = "";
        public int current_batch_no;
        public string batch_html;

        public zues z = new zues();

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
               // batch_row = sn.ToString();
                batch_row = batch_row + "</td>";
                batch_row = batch_row + "<td align=\"left\" width=\"40%\">";
                batch_row = batch_row + "<a href=\"Batch_pubview.aspx?bno=" + i + " \"><strong>Batch Number : " + no + "</strong></a>";
                batch_row = batch_row + "</td>";
                batch_row = batch_row + "<td align=\"left\" width=\"50%\">";
                batch_row = batch_row + "<a href=\"Batch_pubview.aspx?bno=" + i + " \"><strong> " + batch_count + "</strong></a>";
                batch_row = batch_row + "</td>";
                batch_row = batch_row + "</tr>";
                batch_row = batch_row + "<tr>";
                batch_row = batch_row + "<td align=\"left\" width=\"100%\" colspan=\"3\">";
                batch_row = batch_row + "<hr/>";
                batch_row = batch_row + "</td>";
                batch_row = batch_row + "</tr>";
                b.Add(batch_row); sn++;
               }

            foreach(string bb in b)
            {
                batch_html += bb;
            }
                this.batch_html = this.batch_html + "<tr>";
                this.batch_html = this.batch_html + "<td align=\"left\" width=\"100%\" colspan=\"3\">";
                this.batch_html = this.batch_html + "&nbsp;";
                this.batch_html = this.batch_html + "</td>";
                this.batch_html = this.batch_html + "</tr>";
           
        }
    }
}