using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm.x_unit
{
    using admin;
    using Classes;

    public partial class ipo_trans_status : System.Web.UI.Page
    {
        public string agt;
        public string trans_status = "";
        public int showt;
        public int status=0;
        public string admin = "";
        public tm t = new tm();
        public zues z = new zues();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["pwalletID"] != null)
            {
                if (this.Session["pwalletID"].ToString() != "")
                {
                    this.admin = this.Session["pwalletID"].ToString();
                    this.Session["xofficer"] = this.admin;
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
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            this.status = this.t.updateIpoApplicationReferenceStatus(this.trans_id.Text, agt_code.Text, "1");
            if (status == 1)
            {
                trans_status = "THE TRANSACTION ID:<strong>\"" + trans_id.Text + "\"</strong> HAS BEEN SUCCESSFULLY UPDATED!!";
            }
            else
            {
                trans_status = "THE TRANSACTION ID: <strong>\"" + trans_id.Text + "\"</strong> CANNOT BE UPDATED AT THIS TIME, PLEASE TRY AGAIN LATER!!";
            }
            this.showt = 1;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.showt = 0;
        }
    }
}