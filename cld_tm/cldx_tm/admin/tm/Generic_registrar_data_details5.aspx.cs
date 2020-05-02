using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm
{
    public partial class Generic_registrar_data_details5 : System.Web.UI.Page
    {
        public string pwalletID = "0";
        public string admin = "";
        public cld.Classes.tm t = new cld.Classes.tm();
        public string admin_status = "9";
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
        public List<Recordal_Detail> pp4 = new List<Recordal_Detail>();
        public List<Recordal_Detail> pp3 = new List<Recordal_Detail>();
        // public tm t = new tm();
        public string rbval_text = "";
        public String spwallet = "";

        public string vid2 = "";
        public List<Recordal> vd = new List<Recordal>();
        // protected RadioButtonList rbValid;
        protected int cert_show = 0; protected int merger_show = 0; protected int ass_show = 0; protected int change_show = 0;
        protected int prelim_show = 0; protected int renewal_show = 0; protected int others_show = 0;

        protected int app_succ = 0; protected int applicant_succ = 0; protected int tm_info_succ = 0;
        protected int x_succ = 0; protected string serverpath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            vupdate();

            xname.Value = c_rep.agent_code;
            Verify.Visible = false;
            if (this.rbValid.SelectedValue == "Accepted")
            {
                this.admin_status = "11";
                Verify.Visible = true;
            }

            if (this.rbValid.SelectedValue == "Opposed")
            {
                this.admin_status = "12";
                Verify.Visible = true;
            }

            if (this.rbValid.SelectedValue == "Certified")
            {
                this.admin_status = "13";
                Verify.Visible = true;
            }

            if (this.rbValid.SelectedValue == "Kiv")
            {
                this.admin_status = "14";
                Verify.Visible = true;
            }

        }


        protected void rbValid_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.rbValid.SelectedValue == "Accepted")
            {
                this.rbval_text = "Accepted";
                this.admin_status = "11";
                Verify.Visible = true;
            }
            else if (this.rbValid.SelectedValue == "Opposed")
            {
                this.rbval_text = "Opposed";
                this.admin_status = "12";
                Verify.Visible = true;
            }

            else if (this.rbValid.SelectedValue == "Certified")
            {
                this.rbval_text = "Certified";
                this.admin_status = "13";
                Verify.Visible = true;
            }

            else if (this.rbValid.SelectedValue == "Ping")
            {

                this.rbval_text = "Ping";
              //  this.admin_status = "20";
              //  Verify.Visible = true;
            }

            else if (this.rbValid.SelectedValue == "Kiv")
            {

                this.rbval_text = "Kiv";
                 this.admin_status = "14";
                  Verify.Visible = true;
            }
        }


        protected void Verify_Click(object sender, EventArgs e)
        {
           // vupdate();
            //if (this.rbval_text == "") { this.rbval_text = "Registered"; }
           
          //  this.succ = this.z.a_g_tm_office(g_pwallet.xid, this.admin_status, this.rbValid.SelectedValue, this.comment.Text, "", "", "", this.admin);

            if (this.rbValid.SelectedValue == "Ping")
            {
                //Retriever ret2 = new Retriever();
                //ret2.addEmail(comment.Text, "Message From Recordal", c_rep.agent_code);
                //base.Response.Redirect("./g_Recordal.aspx");
            }

            else
            {
                if (Session["Recordal"] != null)
                {

                    vid2 = Session["Recordal"].ToString();
                }
                z.update_RecordalStatus3(vid2, this.admin_status, this.rbValid.SelectedValue);
                this.succ = this.z.a_tm_office2(spwallet, this.admin_status, this.rbValid.SelectedValue, this.comment.Text, "", "", "", this.admin);

               


                if (this.succ != "0")
                {

                    sendemail(c_rep, c_stage, c_mark, c_rep_addy);
                    base.Response.Write("<script language=JavaScript>alert('Data updated successfully')</script>");
                    base.Response.Redirect("./g_Recordal.aspx");
                }
                else
                {
                    base.Response.Write("<script language=JavaScript>alert('Data not verified, Please try again later')</script>");
                }

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

                vid2 = Request.QueryString["recordalid"];
                Session["Recordal"] = vid2;
                spwallet = ret.getCheckStatusDetails(vid);
                this.c_mark = this.t.getMarkInfoClassByUserID(spwallet);
                this.c_rep = this.t.getRepClassByUserID(spwallet);
                this.c_stage = this.t.getStageClassByUserID(spwallet);
               

                this.c_app = this.t.getApplicantClassByID(spwallet);

                xname2.Value = c_app.xname;

                xname3.Value = c_mark.reg_number;

                xname4.Value = c_stage.validationID;
                xname5.Value = c_mark.log_staff;

                xname6.Value = c_stage.applicantID;









                if ((c_app.addressID != null) && (c_app.addressID != "") && (c_app.addressID != "0"))
                {
                    this.c_app_addy = this.t.getAddressClassByID(this.c_app.addressID);



                }
                if ((c_rep.addressID != null) && (c_rep.addressID != "") && (c_rep.addressID != "0"))
                {
                    this.c_rep_addy = this.t.getAddressClassByID(this.c_rep.addressID);
                }


              //  g_pwallet = ret.getG_PwalletByValidationID(vid);
                if ((vid != null) )
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
                    Int32 vint2 = zz2.getMaxId(spwallet);
                    //  int num = 0;
                   // List<Recordal> vd = ret.getG_PwalletByID3(vint2);
                      vint2 =Convert.ToInt32(vid2);
                     vd = ret.getG_PwalletByID3(vint2);
                    pp3 = ret.get_RecordalDetail(vd[0].Detail_Id);
                    foreach (var ddp in vd)
                    {

                        if (ddp.RECORDAL_TYPE == "Change_Name")
                        {
                            gen_nameHis(ddp);

                        }

                        else if (ddp.RECORDAL_TYPE == "ReClassification")
                        {
                            gen_classHis(ddp);

                        }

                        else if (ddp.RECORDAL_TYPE == "Change_Address")
                        {

                            gen_nameAddress(ddp);
                        }

                        else if (ddp.RECORDAL_TYPE == "Change_Rectification")
                        {

                            gen_nameRectify(ddp);
                        }

                        else if (ddp.RECORDAL_TYPE == "Change_Assignment")
                        {
                            gen_Assignment(ddp);
                         //   pp4 = ret.get_RecordalDetail(vd[0].Detail_Id);
                            //  gen_nameRectify(ddp);
                        }

                        else if (ddp.RECORDAL_TYPE == "Change_Assignment2")
                        {
                            gen_Assignment2(ddp);
                        //    pp4 = ret.get_RecordalDetail(vd[0].Detail_Id);
                            //  gen_nameRectify(ddp);
                        }


                        else if (ddp.RECORDAL_TYPE == "registered_user")
                        {
                            // gen_Assignment2(ddp);
                            gen_registeredusers(ddp);
                            //    pp4 = ret.get_RecordalDetail(vd[0].Detail_Id);
                            //  gen_nameRectify(ddp);
                        }


                       


                        else if (ddp.RECORDAL_TYPE == "Change_Renewal")
                        {
                           // gen_Assignment2(ddp);
                            gen_Renewal(ddp);
                            //  gen_nameRectify(ddp);
                        }

                        if (ddp.RECORDAL_TYPE == "Change_Agent")
                        {
                           
                            gen_nameAgent(ddp);
                        }





                    }
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

        public void gen_nameHis(Recordal vd)
        {

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> RECORDAL TYPE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>FORM 22 </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> OLD APPLICANT NAME </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.OLD_APPLICANTNAME + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> NEW APPLICANT NAME </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.NEW_APPLICANTNAME + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> REQUEST DATE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.RECORDAL_REQUEST_DATE + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> AMOUNT </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + String.Format("{0:N}", vd.AMOUNT) + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> TRANSACTION ID </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.TRANSACTIONID + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";




            //  return this.xrecordal;

        }

        public void gen_classHis(Recordal vd)
        {

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> RECORDAL TYPE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>T019 </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> OLD CLASS </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.OLDCLASS + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> NEW CLASS </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.NEWCLASS + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> REQUEST DATE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.RECORDAL_REQUEST_DATE + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> AMOUNT </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + String.Format("{0:N}", vd.AMOUNT) + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> TRANSACTION ID </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.TRANSACTIONID + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";




            //  return this.xrecordal;

        }

        public void gen_nameAddress(Recordal vd)
        {
            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> RECORDAL TYPE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong> FORM 19 </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> OLD APPLICANT ADDRESS </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.OLD_APPLICANTADDRESS + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> NEW APPLICANT ADDRESS </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.NEW_APPLICANTADDRESS + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> REQUEST DATE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.RECORDAL_REQUEST_DATE + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> AMOUNT </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + String.Format("{0:N}", vd.AMOUNT) + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> TRANSACTION ID </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.TRANSACTIONID + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";






        }

        public void gen_registeredusers(Recordal vd)
        {
            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> RECORDAL TYPE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong> FORM 47 </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> OLD APPLICANT NAME </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.OLD_APPLICANTNAME + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> NEW  GRANTEE NAME </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.NEW_APPLICANTNAME + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> OLD APPLICANT ADDRESS </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.OLD_APPLICANTADDRESS + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> NEW GRANTEE  ADDRESS </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.NEW_APPLICANTADDRESS + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> DETAILS </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.description + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> AMOUNT </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + String.Format("{0:N}", vd.AMOUNT) + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> TRANSACTION ID </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.TRANSACTIONID + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";



            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> UPLOADS </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            if (vd.UPLOADPATH != null) {
            
                this.xrecordal = this.xrecordal + "<a href=" + "../tm/" + vd.UPLOADPATH + " target='_blank'>View</a> <br/>";

            }

            if (vd.UPLOADPATH2 != null)
            {

                this.xrecordal = this.xrecordal + "<a href=" + "../tm/" + vd.UPLOADPATH2 + " target='_blank'>View</a> <br/>";

            }

            if (vd.UPLOADPATH3 != null)
            {

                this.xrecordal = this.xrecordal + "<a href=" + "../tm/" + vd.UPLOADPATH3 + " target='_blank'>View</a> <br/>";

            }

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";






        }


        public void gen_nameRectify(Recordal vd)
        {
            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> RECORDAL TYPE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong> FORM 26 </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> OLD TRADEMARK TITLE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.OLD_PRODUCT_TITLE + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> NEW TRADEMARK TITLE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.NEW_PRODUCT_TITLE + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";

          
                this.xrecordal = this.xrecordal + "<tr>";
                this.xrecordal = this.xrecordal + "<td align=\"right\" >";
                this.xrecordal = this.xrecordal + "<strong> OLD TRADEMARK LOGO </strong>";

                this.xrecordal = this.xrecordal + "</td>";




                this.xrecordal = this.xrecordal + "<td align=\"left\" >";

                if (vd.OLD_PRODUCT_LOGO != "")
                {
                    this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + vd.OLD_PRODUCT_LOGO + " target='_blank'>View</a>+ ";

                }

                else
                {

                    this.xrecordal = this.xrecordal + " NONE ";
                }
              //  this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + vd.OLD_PRODUCT_LOGO + " target='_blank'>View</a>+ ";

                this.xrecordal = this.xrecordal + "</td>";
                this.xrecordal = this.xrecordal + "</tr>";


                this.xrecordal = this.xrecordal + "<tr>";
                this.xrecordal = this.xrecordal + "<td align=\"right\" >";
                this.xrecordal = this.xrecordal + "<strong> NEW TRADEMARK LOGO </strong>";

                this.xrecordal = this.xrecordal + "</td>";


                this.xrecordal = this.xrecordal + "<td align=\"left\" >";

                if (vd.NEW_PRODUCT_LOGO != "")
                {
                    this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + vd.NEW_PRODUCT_LOGO + " target='_blank'>View</a>+ ";
                }
                else
                {
                    this.xrecordal = this.xrecordal + " NONE";

                }

                this.xrecordal = this.xrecordal + "</td>";
                this.xrecordal = this.xrecordal + "</tr>";
          

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> REQUEST DATE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.RECORDAL_REQUEST_DATE + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> AMOUNT </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + String.Format("{0:N}", vd.AMOUNT) + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> TRANSACTION ID </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.TRANSACTIONID + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";






        }

     

        public void gen_Assignment(Recordal vd)
        {

            List<Recordal_Detail> xp = new List<Recordal_Detail>();
            xp = ret.get_RecordalDetail(vd.Detail_Id);

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> RECORDAL TYPE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong> FORM 16 </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> OLD APPLICANT NAME </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + xp[0].oldApplicantName  + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> NEW APPLICANT NAME </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + xp[0].newApplicantName + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";



            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> OLD APPLICANT ADDRESS </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + xp[0].oldApplicantAddress + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> NEW APPLICANT ADDRESS </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + xp[0].newApplicantAddress + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> OLD APPLICANT NATIONALITY </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + ret.getCountryName( xp[0].OldApplicantNationality) + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> NEW APPLICANT NATIONALITY </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + ret.getCountryName(xp[0].newApplicantNationality) + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> UPLOADED FILES </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            if (xp[0].assignment_upload != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].assignment_upload + " target='_blank'>View</a> <br/> ";
            }

            if (xp[0].Assignee_upload != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].Assignee_upload + " target='_blank'>View</a> <br/> ";
            }

            if (xp[0].deed_Assignment_upload != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].deed_Assignment_upload + " target='_blank'>View</a> <br/> ";
            }

            if (xp[0].Power_of_Attorney_upload != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].Power_of_Attorney_upload + " target='_blank'>View</a> <br/> ";
            }
            if (xp[0].Registration_of_Mark_upload != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].Registration_of_Mark_upload + " target='_blank'>View</a> <br/> ";
            }

            if (xp[0].Registrar_direction != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].Registrar_direction + " target='_blank'>View</a> <br/>";
            }

            if (xp[0].advertisements_complying != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].advertisements_complying + " target='_blank'>View</a> <br/> ";
            }

            if (xp[0].publication != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].publication + " target='_blank'>View</a> <br/> ";
            }

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";
          
          

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> REQUEST DATE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.RECORDAL_REQUEST_DATE + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> AMOUNT </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + String.Format("{0:N}", vd.AMOUNT) + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> TRANSACTION ID </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.TRANSACTIONID + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> ASSIGNMENT DATE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + pp3[0].assignment_date + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";






        }

        public void gen_Assignment2(Recordal vd)
        {

            List<Recordal_Detail> xp = new List<Recordal_Detail>();
            xp = ret.get_RecordalDetail(vd.Detail_Id);

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> RECORDAL TYPE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong> FORM 17 </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> OLD APPLICANT NAME </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + xp[0].oldApplicantName + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> NEW APPLICANT NAME </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + xp[0].newApplicantName + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";



            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> OLD APPLICANT ADDRESS </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + xp[0].oldApplicantAddress + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> NEW APPLICANT ADDRESS </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + xp[0].newApplicantAddress + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> OLD APPLICANT NATIONALITY </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + ret.getCountryName(xp[0].OldApplicantNationality) + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> NEW APPLICANT NATIONALITY </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + ret.getCountryName(xp[0].newApplicantNationality) + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> UPLOADED FILES </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            if (xp[0].assignment_upload != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].assignment_upload + " target='_blank'>View</a> <br/> ";
            }

            if (xp[0].Assignee_upload != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].Assignee_upload + " target='_blank'>View</a> <br/> ";
            }

            if (xp[0].deed_Assignment_upload != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].deed_Assignment_upload + " target='_blank'>View</a> <br/> ";
            }

            if (xp[0].Power_of_Attorney_upload != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].Power_of_Attorney_upload + " target='_blank'>View</a> <br/> ";
            }
            if (xp[0].Registration_of_Mark_upload != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].Registration_of_Mark_upload + " target='_blank'>View</a> <br/> ";
            }

            if (xp[0].Registrar_direction != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].Registrar_direction + " target='_blank'>View</a> <br/>";
            }

            if (xp[0].advertisements_complying != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].advertisements_complying + " target='_blank'>View</a> <br/> ";
            }

            if (xp[0].publication != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].publication + " target='_blank'>View</a> <br/> ";
            }

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";



            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> REQUEST DATE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.RECORDAL_REQUEST_DATE + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> AMOUNT </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + String.Format("{0:N}", vd.AMOUNT) + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> TRANSACTION ID </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.TRANSACTIONID + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> ASSIGNMENT DATE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + pp3[0].assignment_date + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";



        }

        public void sendemail(cld.Classes.tm.Representative px2, cld.Classes.tm.Stage px3, cld.Classes.tm.MarkInfo cmark, cld.Classes.tm.Address crep)
        {
            try
            {
                int port = 0x24b;


                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From =
           new MailAddress("noreply@iponigeria.com", "noreply@iponigeria.com");
                // new MailAddress("tradeservices@fsdhgroup.com");
                mail.Priority = System.Net.Mail.MailPriority.High;

                mail.To.Add(
    new MailAddress(crep.email1));

                //    new MailAddress("ozotony@yahoo.com"));



                //mail.CC.Add(new MailAddress("Anthony.Ozoagu@firstcitygroup.com"));

                mail.Subject = "Record Verification Notice";

                mail.IsBodyHtml = true;
                String ss2 = "Dear " + px2.xname + ",<br/> <br/>" + " We will like to inform you that your Trademark record with RTM number " + px3.rtm + "and File number " + cmark.reg_number + "has been verified.  <br/> <br/> A new online ID " + px3.validationID + " has been assigned to this record. <br/> You can now apply for certificates and other Recordal types online via your agent dashboard. <br/><br/> Regards. <br/> <br/>";

                //  ss2 = ss2 + "To gain access to your account, you would need to click here <a href=\"http://88.150.164.30/IpoTest2/#/Register/" + vid + " \">click</a>   to validate your account and also make payment. " + "<br/><br/><br/>";
                ss2 = ss2 + "Please do not reply this mail. <br/> <br/> Live 24/7 Support: +234 (0)9038979681. <br/> Email: info@iponigeria.com or go online to use our live feedback form. <br/> <br/> <br/>";







                ss2 = ss2 + "<b> Disclaimer: </b>This e-mail and any attachments are confidential; it must not be read, copied, disclosed or used by any person other than the above named addressees. Unauthorized use, disclosure or copying is strictly prohibited and may be unlawful. Iponigeria.com disclaims any liability for any action taken in reliance on the content of this e-mail. The comments or statements expressed in this e-mail could be personal opinions and are not necessarily  those of iponigeria.com. If you have received this email in error or think you may have done so, you may not peruse, use, disseminate, distribute or copy this message. Please notify the sender immediately and delete the original e-mail from your system.";










                //ss2 = ss2 + "Please keep your password safe and do not share your log in details with anyone. You may change your password at your convenience. In the event that you cannot remember your password, kindly follow the instructions provided for password recovery."  + "<br/>";
                //ss2 = ss2 + "Please do not reply this mail" +  "<br/><br/>";
                //ss2 = ss2 + "Email: info@iponigeria.com or go online to use our live feedback form .<br/><br/>";

                String ss = "<html> <head> </head> <body>" + ss2 + "</body> </html>";

                //  mail.Body = ss;

                mail.Body = ss;

                SmtpClient client = new SmtpClient("88.150.164.30");
                //  SmtpClient client = new SmtpClient("192.168.0.12");

                client.Port = port;

                //    client.Credentials = new System.Net.NetworkCredential("paymentsupport@einaosolutions.com", "Zues.4102.Hector");

                client.Credentials = new System.Net.NetworkCredential("noreply@iponigeria.com", "Einao2015@@$");



                //   new System.Net.NetworkCredential("ebusiness@firstcitygroup.com", "welcome@123");
                //   new System.Net.NetworkCredential(q60.smtp_user, q60.smtp_password);







                client.Send(mail);

            }
            catch (Exception ee)
            {


            }



        }


        public void gen_Renewal(Recordal vd)
        {

            List<Recordal_Detail2> xp = new List<Recordal_Detail2>();
            xp = ret.get_RecordalDetail2(vd.Detail_Id);

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> RECORDAL TYPE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong> FORM 12 </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> RENEWAL DUE DATE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + xp[0].Renewal_DueDate + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> RENEWAL TYPE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + xp[0].Renewal_Type + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";



          


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> UPLOADED FILES </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            if (xp[0].power_of_attorney != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].power_of_attorney + " target='_blank'>View</a> <br/> ";
            }

            if (xp[0].Certificate_Of_Registration != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + xp[0].Certificate_Of_Registration + " target='_blank'>View</a> <br/> ";
            }

           

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";



            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> REQUEST DATE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.RECORDAL_REQUEST_DATE + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> AMOUNT </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + String.Format("{0:N}", vd.AMOUNT) + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> TRANSACTION ID </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.TRANSACTIONID + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";






        }

        public void gen_nameAgent(Recordal vd)
        {
            this.xrecordal = this.xrecordal + "<tr>";

            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + "CHANGE OF AGENT";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + "<strong> OLD AGENT ADDRESS </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + vd.OLD_AGENTNAME;

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + vd.OLDAGENT_ADDRESS;

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "</tr>";
            this.xrecordal = this.xrecordal + "<tr>";


            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + "<strong> OLD AGENT CODE </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + "<strong> OLD AGENT PHONE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "</tr>";

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + vd.OLD_AGENTCODE;

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + vd.OLD_AGENTPHONE;

            this.xrecordal = this.xrecordal + "</td>";

            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";

            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + "<strong> OLD AGENT EMAIL </strong>";

            this.xrecordal = this.xrecordal + "</td>";

            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + vd.OLD_AGENTEMAIL;

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" colspan=\"2\">&nbsp;</td> ";
            this.xrecordal = this.xrecordal + "</tr>";

            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + "<strong> NEW AGENT NAME </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + "<strong> NEW AGENT ADDRESS </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";

            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + vd.NEW_AGENTNAME;

            this.xrecordal = this.xrecordal + "</td>";

            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + vd.NEWAGENT_ADDRESS;

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";
            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + "<strong> NEW AGENT CODE </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + "<strong> NEW AGENT PHONE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "</tr>";

            this.xrecordal = this.xrecordal + "<tr>";

            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + vd.NEW_AGENTCODE;

            this.xrecordal = this.xrecordal + "</td>";

            this.xrecordal = this.xrecordal + "<td style=\"text - align:center; \" >";
            this.xrecordal = this.xrecordal + vd.NEW_AGENTPHONE;

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + "<strong> NEW AGENT EMAIL </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + vd.NEW_AGENTEMAIL;

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            this.xrecordal = this.xrecordal + "<strong> UPLOADED FILE </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td style=\"text-align:center; \" >";
            if (vd.UPLOADPATH != "")
            {

                this.xrecordal = this.xrecordal + " <a href=" + "../tm/" + vd.UPLOADPATH + " target='_blank'>View</a> <br/> ";
            }

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";
            /**this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> AMOUNT </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + String.Format("{0:N}", vd.AMOUNT) + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> TRANSACTION ID </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.TRANSACTIONID + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";


            this.xrecordal = this.xrecordal + "<tr>";
            this.xrecordal = this.xrecordal + "<td align=\"right\" >";
            this.xrecordal = this.xrecordal + "<strong> DESCRIPTION </strong>";

            this.xrecordal = this.xrecordal + "</td>";


            this.xrecordal = this.xrecordal + "<td align=\"left\" >";
            this.xrecordal = this.xrecordal + "<strong>" + vd.description + " </strong>";

            this.xrecordal = this.xrecordal + "</td>";
            this.xrecordal = this.xrecordal + "</tr>";**/







        }
    }
}