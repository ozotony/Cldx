namespace cld.admin.tm
{
    using admin;
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;

    public partial class acceptance_slip_index_card : System.Web.UI.Page
    {
        public string admin = "";
        public string admin_status = "33";
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public zues.MarkInfo c_mark = new zues.MarkInfo();
        public zues.Pwallet c_p = new zues.Pwallet();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
        public string cri = "";
        public List<zues.TmOffice> lt_tm_office = new List<zues.TmOffice>();
        public zues.Adminz lt_x_admin_details = new zues.Adminz();
        public string pID;
        public string rbval_text = "";
        public string search_doc_succ1 = "";
        public string search_doc_succ2 = "";
        public string search_doc_succ3 = "";
        public string succ = "";
        public tm.SWallet swallet = new tm.SWallet();
        public tm t = new tm();
        public string xcomments = "";
        public string xofficer;
        public string serverpath;
        public zues z = new zues();
        public List<string> acceptance_date = new List<string>();
       
        protected void btnViewSearchReport_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("./acceptance_slip.aspx?x=" + this.pID, false);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.serverpath = base.Server.MapPath("~/");
            if (base.Request.QueryString["cri"] != null)
            {
                this.cri = base.Request.QueryString["cri"].ToString();
            }
            if (base.Request.QueryString["x"] != null)
            {
                if (Session["pwalletID"] != null)
                {
                    if (Session["pwalletID"].ToString() != "")
                    {
                        this.admin = Session["pwalletID"].ToString();
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
                this.pID = base.Request.QueryString["x"].ToString();
                this.c_mark = this.z.getMarkInfoByUserID(this.pID);
                this.c_p = this.z.getPwalletDetailsByID(this.c_mark.log_staff);
                this.c_app = this.t.getApplicantByUserID(this.c_p.ID);
                this.c_app_addy = this.t.getAddressClassByID(this.c_app.addressID);

                if ((c_mark.xID!="")&&(c_mark.xID!=null))
                {
                    lt_tm_office = z.getTmOfficeDetailsByID(c_mark.log_staff);
                    foreach (zues.TmOffice t in lt_tm_office)
                    {
                        if ((t.data_status == "Accepted") && (t.admin_status == "5"))
                        {
                            acceptance_date.Add(t.reg_date);
                        }
                    }
                }

                if (c_mark.logo_pic != "")
                {
                    tm_img.ImageUrl = "./" + c_mark.logo_pic;

                    if (File.Exists(serverpath + "\\admin\\tm\\" + c_mark.logo_pic))
                    {
                        tm_img.Height = new Unit(120, UnitType.Pixel);
                        tm_img.Width = new Unit(120, UnitType.Pixel);
                        try
                        {
                            FileStream st = new FileStream(serverpath + "\\admin\\tm\\" + c_mark.logo_pic, FileMode.Open, FileAccess.Read);
                            System.Drawing.Image new_img = System.Drawing.Image.FromStream(st);
                            string ht = new_img.Height.ToString();
                            string wt = new_img.Width.ToString();
                            if ((ht != "") && (wt != "") && (ht != null) && (wt != null))
                            {

                                if (Convert.ToInt32(ht) > Convert.ToInt32(wt))
                                {
                                    tm_img.Height = new Unit(320, UnitType.Pixel);
                                    tm_img.Width = new Unit(240, UnitType.Pixel);
                                }
                                else
                                {
                                    tm_img.Height = new Unit(240, UnitType.Pixel);
                                    tm_img.Width = new Unit(320, UnitType.Pixel);
                                }
                            }
                            else
                            {
                                tm_img.Visible = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            tm_img.Visible = false;
                        }
                    }
                    else
                    {
                        tm_img.Visible = false;
                    }

                }

                xcomments = this.z.getTmAdminDetailsByID(admin).xname;
            }
            else
            {
                base.Response.Redirect("./acceptance_unit/profile.aspx");
            }
        }
     
    }
}