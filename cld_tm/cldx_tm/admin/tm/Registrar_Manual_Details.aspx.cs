using cld.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm
{
    public partial class Registrar_Manual_Details : System.Web.UI.Page
    {
        public string pwalletID = "0";
        public string admin = "";
        public string vid = null;
        public string status = "0";
        public zues z = new zues();
        public Classes.XObjs.G_Pwallet g_pwallet = new Classes.XObjs.G_Pwallet();
        public Classes.XObjs.G_App_info g_app_info = new Classes.XObjs.G_App_info();
        public Classes.XObjs.G_Applicant_info g_applicant_info = new Classes.XObjs.G_Applicant_info();
        public Classes.XObjs.Gen_Agent_info g_agent_info = new Classes.XObjs.Gen_Agent_info();
        public Classes.XObjs.G_Tm_info g_tm_info = new Classes.XObjs.G_Tm_info();
        public Classes.XObjs.G_Ass_info g_ass_info = new Classes.XObjs.G_Ass_info();
        public Classes.XObjs.G_Cert_info g_cert_info = new Classes.XObjs.G_Cert_info();
        public Classes.XObjs.G_Change_info g_change_info = new Classes.XObjs.G_Change_info();
        public Classes.XObjs.G_Merger_info g_merger_info = new Classes.XObjs.G_Merger_info();
        public Classes.XObjs.G_Renewal_info g_renewal_info = new Classes.XObjs.G_Renewal_info();
        public Classes.XObjs.G_Prelim_search_info g_prelim_search_info = new Classes.XObjs.G_Prelim_search_info();
        public Classes.XObjs.G_Other_items_info g_other_items_info = new Classes.XObjs.G_Other_items_info();
        public string succ = "";
        public List<Classes.XObjs.Fee_list> fee_list = new List<Classes.XObjs.Fee_list>();
        public Classes.Retriever ret = new Classes.Retriever();
        public Odyssey.Odyssey ody = new Odyssey.Odyssey();


        protected int cert_show = 0; protected int merger_show = 0; protected int ass_show = 0; protected int change_show = 0;
        protected int prelim_show = 0; protected int renewal_show = 0; protected int others_show = 0;

        protected int app_succ = 0; protected int applicant_succ = 0; protected int tm_info_succ = 0;
        protected int x_succ = 0; protected string serverpath = "";

        public void vupdate()
        {

            if ((this.Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"] != null) &&
                    (this.Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"] != "")
                )
            {
                vid = Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"];

                g_pwallet = ret.getG_PwalletByValidationID(vid);
                if ((g_pwallet.xid != null) && (g_pwallet.xid != ""))
                {
                    g_tm_info = ret.getG_Tm_infoByPwalletID(g_pwallet.xid);
                    g_app_info = ret.getG_App_infoByPwalletID(g_pwallet.xid);

                    g_applicant_info = ret.getG_Applicant_infoByPwalletID(g_pwallet.xid);
                    g_agent_info = ret.getGenAgentByPwalletID(g_pwallet.xid);
                    g_ass_info = ret.getG_Ass_infoByPwalletID(g_pwallet.xid);
                    g_cert_info = ret.getG_Cert_infoByPwalletID(g_pwallet.xid);
                    g_change_info = ret.getG_Change_infoByPwalletID(g_pwallet.xid);
                    g_merger_info = ret.getG_Merger_infoByPwalletID(g_pwallet.xid);
                    g_renewal_info = ret.getG_Renewal_infoByPwalletID(g_pwallet.xid);
                    g_prelim_search_info = ret.getG_Prelim_search_infoByPwalletID(g_pwallet.xid);
                    g_other_items_info = ret.getG_Other_items_infoByPwalletID(g_pwallet.xid);

                    if (g_tm_info.logo_pic != "")
                    {
                        tm_img.ImageUrl = "../admin/tm/gf/" + g_tm_info.logo_pic;

                        if (File.Exists(serverpath + "\\admin\\tm\\gf\\" + g_tm_info.logo_pic))
                        {
                            tm_img.Height = new Unit(120, UnitType.Pixel);
                            tm_img.Width = new Unit(120, UnitType.Pixel);
                            try
                            {
                                FileStream st = new FileStream(serverpath + "\\admin\\tm\\gf\\" + g_tm_info.logo_pic, FileMode.Open, FileAccess.Read);
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

                    foreach (Classes.XObjs.Fee_list item in fee_list)
                    {
                        if (item.item_code == g_pwallet.log_officer)
                        {
                            lbl_type.Text = item.item.ToUpper();
                        }
                    }

                    ShowSection(g_pwallet.log_officer);
                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.serverpath = base.Server.MapPath("~/");
            fee_list = ret.getFee_listByCat("tm");
            if (Session["pwalletID"].ToString() != "")
            {
                this.admin = Session["pwalletID"].ToString();
            }
            if (!Page.IsPostBack)
            {
                if ((this.Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"] != null) &&
                    (this.Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"] != "")
                )
                {
                    vid = Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"];

                    g_pwallet = ret.getG_PwalletByValidationID(vid);
                    if ((g_pwallet.xid != null) && (g_pwallet.xid != ""))
                    {
                        g_tm_info = ret.getG_Tm_infoByPwalletID(g_pwallet.xid);
                        g_app_info = ret.getG_App_infoByPwalletID(g_pwallet.xid);
                        
                        g_applicant_info = ret.getG_Applicant_infoByPwalletID(g_pwallet.xid);
                        g_agent_info = ret.getGenAgentByPwalletID(g_pwallet.xid);
                        g_ass_info = ret.getG_Ass_infoByPwalletID(g_pwallet.xid);
                        g_cert_info = ret.getG_Cert_infoByPwalletID(g_pwallet.xid);
                        g_change_info = ret.getG_Change_infoByPwalletID(g_pwallet.xid);
                        g_merger_info = ret.getG_Merger_infoByPwalletID(g_pwallet.xid);
                        g_renewal_info = ret.getG_Renewal_infoByPwalletID(g_pwallet.xid);
                        g_prelim_search_info = ret.getG_Prelim_search_infoByPwalletID(g_pwallet.xid);
                        g_other_items_info = ret.getG_Other_items_infoByPwalletID(g_pwallet.xid);

                        if (g_tm_info.logo_pic != "")
                        {
                            tm_img.ImageUrl = "../admin/tm/gf/" + g_tm_info.logo_pic;

                            if (File.Exists(serverpath + "\\admin\\tm\\gf\\" + g_tm_info.logo_pic))
                            {
                                tm_img.Height = new Unit(120, UnitType.Pixel);
                                tm_img.Width = new Unit(120, UnitType.Pixel);
                                try
                                {
                                    FileStream st = new FileStream(serverpath + "\\admin\\tm\\gf\\" + g_tm_info.logo_pic, FileMode.Open, FileAccess.Read);
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

                        foreach (Classes.XObjs.Fee_list item in fee_list)
                        {
                            if (item.item_code == g_pwallet.log_officer)
                            {
                                lbl_type.Text = item.item.ToUpper();
                            }
                        }

                        ShowSection(g_pwallet.log_officer);
                    }

                }
            }
            else
            {
                if (Session["pwalletID"] != null)
                {
                    pwalletID = Session["pwalletID"].ToString();
                }
            }

        }
        protected void itemSelected(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "")
            {

                Verify.Visible = true;
            }
            else
            {
                Verify.Visible = false;

            }

            vupdate();
        }
        protected void Verify_Click(object sender, EventArgs e)
        {
            this.succ = this.z.a_tm_office(g_app_info.log_staff, this.DropDownList1.SelectedItem.Text, this.DropDownList1.SelectedValue, "", "", "", "", this.admin);
            if (this.succ != "0")
            {
                base.Response.Write("<script language=JavaScript>alert('Data updated successfully')</script>");
                base.Response.Redirect("./Register_Manual.aspx");
            }
            else
            {
                base.Response.Write("<script language=JavaScript>alert('Data not verified, Please try again later')</script>");
            }
        }

        public void ShowSection(string item_code)
        {
            if (item_code == "T001") { prelim_show = 1; Session["item_code"] = item_code; }
            else if (item_code == "T003") { cert_show = 1; Session["item_code"] = item_code; }
            else if (item_code == "T008") { change_show = 1; Session["item_code"] = item_code; }
            else if (item_code == "T009") { renewal_show = 1; Session["item_code"] = item_code; }
            else if (item_code == "T014") { ass_show = 1; merger_show = 1; Session["item_code"] = item_code; }
            else if ((item_code != "T001") && (item_code != "T002") && (item_code != "T003") && (item_code != "T008") && (item_code != "T009") && (item_code != "T014"))
            { others_show = 1; Session["item_code"] = item_code; }
        }      
    }
}