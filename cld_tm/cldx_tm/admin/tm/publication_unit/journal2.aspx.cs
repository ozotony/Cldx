namespace cld.admin.tm.publication_unit
{
    using cld.admin;
    using cld.Classes;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public partial class journal2 : Page
    {
        public string admin = "";
        public string admin_status = "";
        public int cnt;
        public int current_batch_no;
        public int i;
        public List<tm.Address> lt_addy = new List<tm.Address>();
        public List<tm.AddressService> lt_addy_service = new List<tm.AddressService>();
        public List<tm.Applicant> lt_app = new List<tm.Applicant>();
        public List<zues.MarkInfo> lt_mi = new List<zues.MarkInfo>();
        public List<zues.Pwallet> lt_p = new List<zues.Pwallet>();
        public List<tm.Representative> lt_rep = new List<tm.Representative>();
        public List<tm.Address> lt_rep_addy = new List<tm.Address>();
        public List<tm.Stage> lt_stage = new List<tm.Stage>();
        public string mark_infoID;
        public string msg = "";
        public string pID;
        public string succ;
        public tm t = new tm();
        public Validator val = new Validator();
        public string xofficer;
        public zues z = new zues();

        protected void btnGetAll_Click(object sender, EventArgs e)
        {
            this.msg = "";
            this.cnt = 0;
            this.lt_mi.Clear();
            this.lt_mi = this.z.getIndexInfoRS("5", "Published");
            this.cnt = this.lt_mi.Count;
        }

        protected void btnGetByAmount_Click(object sender, EventArgs e)
        {
            this.msg = "";
            this.cnt = 0;
            this.lt_mi.Clear();
            if (this.txtFromAmount.Text == "")
            {
                this.txtFromAmount.Text = "0";
            }
            if ((this.txtFromAmount.Text != "") && (this.txtToAmount.Text != ""))
            {
                if ((this.val.IsInt32(this.txtFromAmount.Text) != 0) || (this.val.IsInt32(this.txtToAmount.Text) != 0))
                {
                    this.msg = "The <b>\"From\"</b>  OR <b>\"To\"</b> field(s) <b>CANNOT</b> be empty and must be <b>NUMERIC</b>!!!";
                }
                else if (Convert.ToInt32(this.txtFromAmount.Text) >= Convert.ToInt32(this.txtToAmount.Text))
                {
                    this.msg = "The <b>\"From\"</b> field <b>CANNOT</b> be more than or equal to the <b>\"To\"</b> field";
                }
                else
                {
                    try
                    {
                        this.lt_mi = this.z.getIndexInfoRSByAmountAndBno("5", "Published", this.txtFromAmount.Text, this.txtToAmount.Text, this.selectBatch.SelectedValue);
                        this.cnt = this.lt_mi.Count;
                        this.msg = "";
                    }
                    catch (Exception)
                    {
                        this.msg = "The <b>\"From\"</b>  OR <b>\"To\"</b> field(s) <b>CANNOT</b> be empty and must be <b>NUMERIC</b>!!!";
                    }
                }
            }
            else
            {
                this.msg = "The <b>\"From\"</b>  OR <b>\"To\"</b> field(s) <b>CANNOT</b> be empty and must be <b>NUMERIC</b>!!!";
            }
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("./index_cards.aspx");
        }

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
            if ((base.Request.QueryString["bno"] != null) && (base.Request.QueryString["bno"].ToString() != ""))
            {
                this.current_batch_no = Convert.ToInt32(base.Request.QueryString["bno"].ToString());
            }
            if (!base.IsPostBack)
            {
                this.current_batch_no = this.z.getCurrentBatch();
                this.PopulateBatch();
            }
        }

        protected void PopulateBatch()
        {
            for (int i = this.current_batch_no; i > 1; i--)
            {
                int num2 = i - 1;
                int num3 = this.z.getCurrentBatchCnt(i);
                ListItem item = new ListItem
                {
                    Text = string.Concat(new object[] { "Batch Number ", num2, " (Total Items=", num3, ") " }),
                    Value = i.ToString()
                };
                this.selectBatch.Items.Add(item);
            }
        }
    }
}

