using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm
{
    public partial class Generic_registrar_data_detailsC : System.Web.UI.Page
    {
        public string pwalletID = "0";
        public string admin = "";
        public cld.Classes.tm t = new cld.Classes.tm();
        public string admin_status = "8";
        public string vid = null;
        public string status = "0";
        public string xcomments = "";
        public string xrecordal = "";
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

        public cld.Classes.tm.AddressService c_aos = new cld.Classes.tm.AddressService();
        public cld.Classes.tm.Applicant c_app = new cld.Classes.tm.Applicant();
        public cld.Classes.tm.Address c_app_addy = new cld.Classes.tm.Address();
        public cld.Classes.tm.MarkInfo c_mark = new cld.Classes.tm.MarkInfo();
        public cld.Classes.tm.Representative c_rep = new cld.Classes.tm.Representative();
        public cld.Classes.tm.Address c_rep_addy = new cld.Classes.tm.Address();
        public cld.Classes.tm.Stage c_stage = new cld.Classes.tm.Stage();
        public cld.Classes.XObjs.Pwallet pwallet = new cld.Classes.XObjs.Pwallet();
        public string succ = "";
        public List<zues.TmOffice> lt_tm_office = new List<zues.TmOffice>();
        public zues.Adminz lt_x_admin_details = new zues.Adminz();
        public List<Classes.XObjs.Fee_list> fee_list = new List<Classes.XObjs.Fee_list>();
        public Classes.Retriever ret = new Classes.Retriever();
        public Odyssey.Odyssey ody = new Odyssey.Odyssey();
        // public tm t = new tm();
        public string rbval_text = "";
        public String spwallet = "";
        // protected RadioButtonList rbValid;
        protected int cert_show = 0; protected int merger_show = 0; protected int ass_show = 0; protected int change_show = 0;
        protected int prelim_show = 0; protected int renewal_show = 0; protected int others_show = 0;

        protected int app_succ = 0; protected int applicant_succ = 0; protected int tm_info_succ = 0;
        protected int x_succ = 0; protected string serverpath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            vupdate();
            Verify.Visible = false;
            if (this.rbValid.SelectedValue == "Certified")
            {
                this.admin_status = "8";
                Verify.Visible = true;
            }

            if (this.rbValid.SelectedValue == "Opposed")
            {
                this.admin_status = "12";
                Verify.Visible = true;
            }

           
        }

        protected void rbValid_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.rbValid.SelectedValue == "Certified")
            {
                this.rbval_text = "Migrated";
                this.admin_status = "8";
                Verify.Visible = true;
            }
        }

        protected void Verify_Click(object sender, EventArgs e)
        {
            // vupdate();
            //if (this.rbval_text == "") { this.rbval_text = "Registered"; }

            //  this.succ = this.z.a_g_tm_office(g_pwallet.xid, this.admin_status, this.rbValid.SelectedValue, this.comment.Text, "", "", "", this.admin);
            this.succ = this.z.a_tm_office(spwallet, this.admin_status, this.rbValid.SelectedValue, this.comment.Text, "", "", "", this.admin);
            if (this.succ != "0")
            {
                base.Response.Write("<script language=JavaScript>alert('Data updated successfully')</script>");
                base.Response.Redirect("./registrar2.aspx");
            }
            else
            {
                base.Response.Write("<script language=JavaScript>alert('Data not verified, Please try again later')</script>");
            }
        }
        public void vupdate()
        {

            if ((this.Session["pwalletID"] != null) && (this.Session["pwalletID"].ToString() != ""))
            {


                admin = Convert.ToString(Session["pwalletID"]);
            }


            if ((this.Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"] != null) &&
                    (this.Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"] != "")
                )
            {
                vid = Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"];

                spwallet = ret.getCheckStatusDetails(vid);
                this.c_mark = this.t.getMarkInfoClassByUserID(spwallet);
                this.c_rep = this.t.getRepClassByUserID(spwallet);
                this.c_stage = this.t.getStageClassByUserID(spwallet);
                this.c_app = this.t.getApplicantClassByID(spwallet);






                if ((c_app.addressID != null) && (c_app.addressID != "") && (c_app.addressID != "0"))
                {
                    this.c_app_addy = this.t.getAddressClassByID(this.c_app.addressID);



                }
                if ((c_rep.addressID != null) && (c_rep.addressID != "") && (c_rep.addressID != "0"))
                {
                    this.c_rep_addy = this.t.getAddressClassByID(this.c_rep.addressID);
                }


                //  g_pwallet = ret.getG_PwalletByValidationID(vid);
                if ((vid != null))
                {
                    //g_tm_info = ret.getG_Tm_infoByPwalletID(g_pwallet.xid);

                    //g_app_info = ret.getG_App_infoByPwalletID(g_pwallet.xid);

                    //g_applicant_info = ret.getG_Applicant_infoByPwalletID(g_pwallet.xid);
                    //g_agent_info = ret.getGenAgentByPwalletID(g_pwallet.xid);
                    //g_ass_info = ret.getG_Ass_infoByPwalletID(g_pwallet.xid);
                    //g_cert_info = ret.getG_Cert_infoByPwalletID(g_pwallet.xid);
                    //g_change_info = ret.getG_Change_infoByPwalletID(g_pwallet.xid);
                    //g_merger_info = ret.getG_Merger_infoByPwalletID(g_pwallet.xid);
                    //g_renewal_info = ret.getG_Renewal_infoByPwalletID(g_pwallet.xid);
                    //g_prelim_search_info = ret.getG_Prelim_search_infoByPwalletID(g_pwallet.xid);
                    //g_other_items_info = ret.getG_Other_items_infoByPwalletID(g_pwallet.xid);


                    //  this.lt_tm_office = this.z.getG_TmOfficeDetailsByID(g_pwallet.xid);
                    this.lt_tm_office = this.z.getTmOfficeDetailsByID(spwallet);
                    //  List<Recordal> vd = ret.getG_PwalletByID2(g_pwallet.xid);
                    zues zz2 = new zues();
                    //  Int32 vint2 = zz2.getMaxId(spwallet);
                    //  int num = 0;
                    //List<Recordal> vd = ret.getG_PwalletByID3(vint2);
                    //foreach (var ddp in vd)
                    //{

                    //    if (ddp.RECORDAL_TYPE == "Change_Name")
                    //    {
                    //        gen_nameHis(ddp);

                    //    }

                    //    else if (ddp.RECORDAL_TYPE == "Change_Address")
                    //    {

                    //        gen_nameAddress(ddp);
                    //    }


                    //}
                    for (int i = 0; i < this.lt_tm_office.Count; i++)
                    {
                        this.xcomments = this.xcomments + "<tr>";
                        this.xcomments = this.xcomments + "<td align=\"center\" colspan=\"2\">";
                        this.xcomments = this.xcomments + "<strong>" + this.lt_tm_office[i].xcomment.ToUpper() + "</strong><br />";
                        this.lt_x_admin_details = this.z.getTmAdminDetailsByID(this.lt_tm_office[i].xofficer);
                        string xcomments = this.xcomments;
                        this.xcomments = xcomments + "COMMENT BY: <strong>" + this.lt_x_admin_details.xname.ToUpper() + "( " + this.z.getRoleNameByID(this.lt_x_admin_details.xroleID).ToUpper() + " UNIT)</strong><br />   Date: <strong>" + this.lt_tm_office[i].reg_date.ToUpper() + "</strong>";
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";
                        if (lt_tm_office[i].xdoc1 != "")
                        {
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td colspan=\"2\" align=\"center\">";
                            this.xcomments = this.xcomments + "View Document 1: <a href=" + lt_tm_office[i].xdoc1 + " target='_blank'>View</a>";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                        }

                        if (lt_tm_office[i].xdoc2 != "")
                        {
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td colspan=\"2\" align=\"center\">";
                            this.xcomments = this.xcomments + "View Document 2: <a href=" + lt_tm_office[i].xdoc2 + " target='_blank'>View</a>";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                        }

                        if (lt_tm_office[i].xdoc3 != "")
                        {
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td colspan=\"2\" align=\"center\">";
                            this.xcomments = this.xcomments + "View Document 3: <a href=" + lt_tm_office[i].xdoc3 + " target='_blank'>View</a>";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                        }
                        this.xcomments = this.xcomments + "<tr>";
                        this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                        this.xcomments = this.xcomments + "&nbsp;";
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";
                        if (this.lt_tm_office[i].admin_status == "3")
                        {
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                            this.xcomments = this.xcomments + "--- SUPPORTING SEARCH DOCUMENTS ---";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td align=\"right\">";
                            this.xcomments = this.xcomments + "Attached Document:";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "<td>";
                            //if ((this.swallet.search_str != "") && (this.swallet.search_str != null))
                            //{
                            //    this.xcomments = this.xcomments + "<a href=view_searcho.aspx?x=" + this.pID + " target='_blank'>View</a>";
                            //}
                            //else
                            //{
                            //    this.xcomments = this.xcomments + "NONE";
                            //}
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                            this.xcomments = this.xcomments + "&nbsp;";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                        }

                        //////////
                        if (this.lt_tm_office[i].admin_status == "33")
                        {
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                            this.xcomments = this.xcomments + "--- SUPPORTING SEARCH 2 DOCUMENTS ---";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td align=\"right\">";
                            this.xcomments = this.xcomments + "Attached Document:";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "<td>";
                            //if ((this.swallet2.search_str != "") && (this.swallet2.search_str != null))
                            //{
                            //    this.xcomments = this.xcomments + "<a href=view_searcho2.aspx?x=" + this.pID + " target='_blank'>View</a>";
                            //}
                            //else
                            //{
                            //    this.xcomments = this.xcomments + "NONE";
                            //}

                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";

                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                            this.xcomments = this.xcomments + "&nbsp;";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                        } //////////
                    }

                    //if (g_tm_info.logo_pic != "")
                    //{
                    //    tm_img.ImageUrl = "../admin/tm/gf/" + g_tm_info.logo_pic;

                    //    if (File.Exists(serverpath + "\\admin\\tm\\gf\\" + g_tm_info.logo_pic))
                    //    {
                    //        tm_img.Height = new Unit(120, UnitType.Pixel);
                    //        tm_img.Width = new Unit(120, UnitType.Pixel);
                    //        try
                    //        {
                    //            FileStream st = new FileStream(serverpath + "\\admin\\tm\\gf\\" + g_tm_info.logo_pic, FileMode.Open, FileAccess.Read);
                    //            System.Drawing.Image new_img = System.Drawing.Image.FromStream(st);
                    //            string ht = new_img.Height.ToString();
                    //            string wt = new_img.Width.ToString();
                    //            if ((ht != "") && (wt != "") && (ht != null) && (wt != null))
                    //            {

                    //                if (Convert.ToInt32(ht) > Convert.ToInt32(wt))
                    //                {
                    //                    tm_img.Height = new Unit(320, UnitType.Pixel);
                    //                    tm_img.Width = new Unit(240, UnitType.Pixel);
                    //                }
                    //                else
                    //                {
                    //                    tm_img.Height = new Unit(240, UnitType.Pixel);
                    //                    tm_img.Width = new Unit(320, UnitType.Pixel);
                    //                }
                    //            }
                    //            else
                    //            {
                    //                // tm_img.Height = new Unit(120, UnitType.Pixel);
                    //                // tm_img.Width = new Unit(120, UnitType.Pixel);
                    //                tm_img.Visible = false;
                    //            }
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            tm_img.Visible = false;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        // tm_img.Height = new Unit(120, UnitType.Pixel);
                    //        // tm_img.Width = new Unit(120, UnitType.Pixel);
                    //        tm_img.Visible = false;
                    //    }
                    //}

                    //foreach (Classes.XObjs.Fee_list item in fee_list)
                    //{
                    //    if (item.item_code == g_pwallet.log_officer)
                    //    {
                    //        lbl_type.Text = item.item.ToUpper();
                    //    }
                    //}

                    //ShowSection(g_pwallet.log_officer);
                }

            }
        }
    }
}