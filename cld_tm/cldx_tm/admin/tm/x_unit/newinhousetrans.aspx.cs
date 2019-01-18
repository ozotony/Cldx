using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm.x_unit
{
    using Classes;
    public partial class newinhousetrans : System.Web.UI.Page
    {
        public string admin = "";
        public string progress_msg = "";
        public string apptypestat = "";
        public tm t = new tm();
        public string xapplication = "";

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
            this.Session["vid"] = null;
            this.Session["amt"] = null;
            this.Session["aid"] = null;
            this.Session["g"] = null;
            this.Session["pc"] = null;
            base.Server.MapPath("~/");
            if (this.Session["xapplication"] != null)
            {
                this.xapplication = this.Session["xapplication"].ToString();
                if (this.xapplication != "")
                {
                    base.Response.Redirect("../../../violationx.aspx");
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            int num = 0;
            int num2 = 0;
            tm.XTransaction xt = new tm.XTransaction();
                if (this.xtransaction.Text == "") { num2++; }
                if (this.xagt.Text == "")  {num2++;}
                if (this.xamt.Text == "") { num2++; }
                if (num2 == 0)
                {
                    num = this.t.CheckXTransactionID(this.xtransaction.Text);
                    if (num == 0)
                    {
                        xt.transactionID = xtransaction.Text;
                        xt.xcode = xagt.Text;
                        xt.ptype = xptype.SelectedValue;
                        xt.amt = xamt.Text;
                        xt.status = "0";
                        xt.adminID = admin;
                        int updattrans_stat = t.addXTransaction(xt);
                        if (updattrans_stat > 0)
                        {
                            string trans = this.xtransaction.Text;
                            this.xtransaction.Text="";
                            xamt.Text="";
                            this.xagt.Text = "";
                            xptype.SelectedIndex = 0;
                            this.progress_msg = "TRANSACTION WITH ID=\" " + trans + "\" ADDED SUCCESSFULLY !!";
                        }
                        else
                        {
                            this.progress_msg = "THE TRANSACTION COULD NOT BE UPDATED,PLEASE TRY AGAIN!!";
                        }
                    }
                    else
                    {
                        this.progress_msg = "PLEASE CROSS CHECK THE DETAILS ABOVE,THE TRANSACTION ID EXISTS IN THE SYSTEM!!";
                    }

                }
                else
                {
                    this.progress_msg = "PLEASE FILL IN ALL THE DETAILS ABOVE!!";
                }
        }

       
    }
}