namespace cld.admin.tm
{
    using admin ;
    using Classes ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;

    public class acceptance_slip_data_details : UserControl
    {
        public string admin = "";
        public string admin_status;
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public zues.MarkInfo c_mark = new zues.MarkInfo();
        public zues.Pwallet c_p = new zues.Pwallet();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
        protected Label Label1;
        protected Label Label2;
        protected Label Label4;
        protected Label Label5;
        protected Button btnMarkPrinted;
        public zues.Adminz lt_tm_admin_details = new zues.Adminz();
        public List<zues.TmOffice> lt_tm_office = new List<zues.TmOffice>();
        public string pID;
        public string rbval_text = "";
        public string search_doc_succ1 = "";
        public string search_doc_succ2 = "";
        public string search_doc_succ3 = "";
        public string succ = "";
        public tm t = new tm();
        public string xofficer;
        public zues z = new zues();
        protected Image tm_img;

        protected Image imgWaterMark;
        protected string serverpath = "";
        protected bool mark_printed = false;

       protected Panel pp7;

       protected Panel dt;

       protected Panel dt2;

       protected Label Label6;

       protected Label Label3;

        

        

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            this.serverpath = base.Server.MapPath("~/");
            if (base.Request.QueryString["x"] != null)
            {

                if (!this.IsPostBack)
                {
                    
                    //string script = "document.getElementById('bgMark').style.background = \"url(\" + document.getElementById('"
                    //+ imgWaterMark.ClientID + "').src + \")  0 20  repeat \";";
                    //if (ScriptManager.GetCurrent(this.Page) == null)
                    //    Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "block", script, true);
                    //else
                    //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "block", script, true);
                   
                    string ID = "test";
                    if (base.Request.QueryString["x2"] != null)
                    {
                        //  imgWaterMark.ImageUrl = ResolveUrl("~") + string.Format("Handlers/WaterMarks.ashx?id={0}", ID);
                        Label6.Visible = true;
                        Label6.Text ="PLEASE NOTE THAT THIS IS NOT AN ORIGINAL ACCEPTANCE DOCUMENT, PRINT THIS COPY AND PRESENT IT TO THE REGISTRY TO COLLECT YOUR ORIGINAL ACCEPTANCE LETTER.<br/> CONTACT THE REGISTRY FOR MORE INFORMATION ON HOW TO COLLECT YOUR ORIGINAL COPY. WWW.IPONIGERIA.COM.";
                        Label3.Text = "PLEASE NOTE THAT THIS IS NOT AN ORIGINAL ACCEPTANCE DOCUMENT, PRINT THIS COPY AND PRESENT IT TO THE REGISTRY TO COLLECT YOUR ORIGINAL ACCEPTANCE LETTER.<br/> CONTACT THE REGISTRY FOR MORE INFORMATION ON HOW TO COLLECT YOUR ORIGINAL COPY. WWW.IPONIGERIA.COM.";
                       // pp7.BackImageUrl = ResolveUrl("~") + string.Format("~/Handlers/WaterMarks.ashx?id={0}", ID);

                        pp7.BackImageUrl =  string.Format("http://localhost:49703/Handlers/WaterMarks.ashx?id={0}", ID);
                        dt2.Visible = true;
                        Label3.Visible = true;

                    }
                    else
                    {
                        Label6.Visible = true;
                        Label6.Text = "Your Trademark has been accepted and will be published/advertised in accordance with the Trademarks Act";

                        dt.Visible = true;
                        Label3.Visible = false;

                    }

                    
                }

               




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
                  //  base.Response.Redirect("./xcontrol.aspx");
                }
                this.pID = base.Request.QueryString["x"].ToString();
                this.c_mark = this.z.getMarkInfoByUserID(this.pID);
                this.c_p = this.z.getPwalletDetailsByID(this.c_mark.log_staff);
                this.c_app = this.t.getApplicantByUserID(this.c_p.ID);
                this.c_aos = this.t.getAddressServiceByID(this.c_p.ID);
                this.c_rep = this.t.getRepByUserID(this.c_p.ID);
                if ((c_app.addressID != null) && (c_app.addressID != "") && (c_app.addressID != "0"))
                {
                    this.c_app_addy = this.t.getAddressClassByID(this.c_app.addressID);
                }
                if ((c_rep.addressID != null) && (c_rep.addressID != "") && (c_rep.addressID != "0"))
                {
                    this.c_rep_addy = this.t.getAddressClassByID(this.c_rep.addressID);
                }
                this.lt_tm_office = this.z.getTmOfficeDetailsByID(this.c_p.ID);
                try
                {
                    this.lt_tm_admin_details = this.z.getTmAdminDetailsByID(this.lt_tm_office[0].xofficer);
                }
                catch(Exception ee)
                {
                    this.lt_tm_admin_details = null;
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
                                   // tm_img.Height = new Unit(270, UnitType.Pixel);
                                    tm_img.Height = new Unit(200, UnitType.Pixel);
                                    tm_img.Width = new Unit(190, UnitType.Pixel);
                                }
                                else
                                {
                                    tm_img.Height = new Unit(100, UnitType.Pixel);
                                    tm_img.Width = new Unit(270, UnitType.Pixel);
                                }
                            }
                            else
                            {
                                // tm_img.Height = new Unit(120, UnitType.Pixel);
                                // tm_img.Width = new Unit(120, UnitType.Pixel);
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
                        // tm_img.Height = new Unit(120, UnitType.Pixel);
                        // tm_img.Width = new Unit(120, UnitType.Pixel);
                        tm_img.Visible = false;
                    }


                }
            }
            else
            {
                base.Response.Redirect("./acceptance_slip.aspx");
            }
        }

        protected void btnMarkPrinted_Click(object sender, EventArgs e)
        {
            //  this.succ = this.z.a_tm_office(this.c_mark.log_staff, "5", "acc_printed", "Acceptance Printed", "", "", "", this.admin);
            this.succ = z.e_PwalletAccPrintStatus(this.c_mark.log_staff, "1").ToString();
            if (Convert.ToInt32(succ) > 0)
            {
                mark_printed = true;
                btnMarkPrinted.Visible = false;
            }
            else
            {
                mark_printed = false;
                this.Visible = true;
            }


        }

    }
}

