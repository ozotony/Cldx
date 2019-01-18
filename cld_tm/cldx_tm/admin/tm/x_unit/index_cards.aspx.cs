namespace cld.admin.tm.x_unit
{
    using admin;
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;


    public partial class index_cards : System.Web.UI.Page
    {
        public string admin = "";
        public string admin_status = "";
        public int i;
        public List<tm.Address> lt_addy = new List<tm.Address>();
        public List<tm.AddressService> lt_addy_service = new List<tm.AddressService>();
        public List<tm.Applicant> lt_app = new List<tm.Applicant>();
        public List<zues.MarkInfo> lt_mi = new List<zues.MarkInfo>();
        public List<zues.Pwallet> lt_p = new List<zues.Pwallet>();
        public List<tm.Representative> lt_rep = new List<tm.Representative>();
        public List<tm.Address> lt_rep_addy = new List<tm.Address>();
        public List<tm.Stage> lt_stage = new List<tm.Stage>();
        public List<zues.TmOffice> lt_tm_office = new List<zues.TmOffice>();
        public string mark_infoID;
        public string pID;
        public string msg = "";
        public int cnt = 0;
        public string succ;
        public tm t = new tm();
        public string xofficer;
        public zues z = new zues();
        public Validator val = new Validator();
        public int current_batch_no = 0;
        public List<string> acceptance_date = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["pwalletID"] != null)
            {
                if (this.Session["pwalletID"].ToString() != "")
                {
                    this.admin = this.Session["pwalletID"].ToString();
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
            //if ((Request.QueryString["bno"] != null) && (Request.QueryString["bno"].ToString() != ""))
            //{
            //    current_batch_no = Convert.ToInt32(Request.QueryString["bno"].ToString());
            //} 
            this.current_batch_no = this.z.getCurrentBatch();
            PopulateBatch();

        }

        protected void PopulateBatch()
        {
            for (int i = current_batch_no; i > 1; i--)
            {
                int no = i - 1;
                int cur_i = i + 1;
                int batch_count = z.getCurrentBatchCnt(i);

                ListItem li = new ListItem();
                li.Text = "Batch Number " + no + " (Total Items=" + batch_count + ") ";
                li.Value = i.ToString();
                selectBatch.Items.Add(li);
            }
        }
        protected void btnGetAll_Click(object sender, EventArgs e)
        {
            msg = ""; cnt = 0; lt_mi.Clear();
            this.lt_mi = this.z.getIndexInfoRS("5", "Published");
            cnt = lt_mi.Count;
            if (cnt > 0)
            {
                foreach (zues.MarkInfo m in lt_mi)
                {
                    lt_tm_office = z.getTmOfficeDetailsByID(m.log_staff);
                    foreach (zues.TmOffice t in lt_tm_office)
                    {
                        if ((t.data_status == "Accepted") && (t.admin_status == "5"))
                        {
                            acceptance_date.Add(t.reg_date);
                        }
                    }
                }
            }
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            Response.Redirect("./index_cards.aspx");
        }

        protected void btnGetByAmount_Click(object sender, EventArgs e)
        {
            msg = ""; cnt = 0; lt_mi.Clear();
            if ((txtFromAmount.Text != "") && (txtToAmount.Text != ""))
            {
                if ((val.IsInt32(txtFromAmount.Text) == 0) && (val.IsInt32(txtToAmount.Text) == 0))
                {
                    if (Convert.ToInt32(txtFromAmount.Text) < (Convert.ToInt32(txtToAmount.Text)))
                    {
                        try
                        {
                            lt_mi = z.getIndexInfoRSByAmountAndBno("5", "Published", txtFromAmount.Text, txtToAmount.Text, selectBatch.SelectedValue);
                            cnt = lt_mi.Count;
                            if (cnt > 0)
                            {
                                foreach (zues.MarkInfo m in lt_mi)
                                {
                                    lt_tm_office = z.getTmOfficeDetailsByID(m.log_staff);
                                    foreach (zues.TmOffice t in lt_tm_office)
                                    {
                                        if ((t.data_status == "Accepted") && (t.admin_status == "5"))
                                        {
                                            acceptance_date.Add(t.reg_date);
                                        }
                                    }
                                }
                            }
                            msg = "";
                        }
                        catch (Exception ex)
                        {
                            msg = "The <b>\"From\"</b>  OR <b>\"To\"</b> field(s) <b>CANNOT</b> be empty and must be <b>NUMERIC</b>!!!";
                        }
                    }
                    else
                    {
                        msg = "The <b>\"From\"</b> field <b>CANNOT</b> be more than or equal to the <b>\"To\"</b> field";
                    }

                }
                else
                {
                    msg = "The <b>\"From\"</b>  OR <b>\"To\"</b> field(s) <b>CANNOT</b> be empty and must be <b>NUMERIC</b>!!!";
                }
            }
            else
            {
                msg = "The <b>\"From\"</b>  OR <b>\"To\"</b> field(s) <b>CANNOT</b> be empty and must be <b>NUMERIC</b>!!!";
            }
        }

    }
}