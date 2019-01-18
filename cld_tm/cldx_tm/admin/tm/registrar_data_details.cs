namespace cld.admin.tm
{
    using admin;
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class registrar_data_details : UserControl
    {
        public string admin = "";
        public string admin_status = "9";
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public zues.MarkInfo c_mark = new zues.MarkInfo();
        public zues.Pwallet c_p = new zues.Pwallet();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
        protected TextBox comment;
        protected Label Label1;
        protected Label Label10;
        protected Label Label11;
        protected Label Label12;
        protected Label Label13;
        protected Label Label14;
        protected Label Label19;
        protected Label Label2;
        protected Label Label20;
        protected Label Label21;
        protected Label Label22;
        protected Label Label23;
        protected Label Label25;
        protected Label Label26;
        protected Label Label27;
        protected Label Label28;
        protected Label Label3;
        protected Label Label4;
        protected Label Label5;
        protected Label Label6;
        protected Label Label7;
        protected Label Label8;
   
        protected TextBox txt_rtm;
        public List<zues.TmOffice> lt_tm_office = new List<zues.TmOffice>();
        public zues.Adminz lt_x_admin_details = new zues.Adminz();
        public string pID;
        public string rbval_text = "";
        protected RadioButtonList rbValid;
        protected ListItem tt8;
        public string search_doc_succ1 = "";
        public string search_doc_succ2 = "";
        public string search_doc_succ3 = "";
        public string succ = "";
        public tm.SWallet swallet = new tm.SWallet();
        public tm.SWallet swallet2 = new tm.SWallet();
        public tm t = new tm();
        protected Button Verify;
        public string xcomments = "";
        public string xofficer;
        public zues z = new zues();

        protected void Page_Load(object sender, EventArgs e)
        {

           

            Verify.Visible = false;
          
            if (this.rbValid.SelectedValue == "Registered")
            {
                this.admin_status = "9";
               Verify.Visible = true;
            }
            else if (this.rbValid.SelectedValue == "Deferred")
            {
                this.admin_status = "8";
                Verify.Visible = true;
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
                this.swallet = this.t.getSwalletByID(this.pID);
                this.swallet2 = this.t.getSwalletByID2(this.pID);
                this.c_mark = this.z.getMarkInfoByUserID(this.pID);
                this.c_p = this.z.getPwalletDetailsByID(this.c_mark.log_staff);
                if (c_p.TransactionId == "")
                {
                    tt8.Enabled = false;

                }               
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
                        if ((this.swallet.search_str != "") && (this.swallet.search_str != null))
                        {
                            this.xcomments = this.xcomments + "<a href=view_searcho.aspx?x=" + this.pID + " target='_blank'>View</a>";
                        }
                        else
                        {
                            this.xcomments = this.xcomments + "NONE";
                        }
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
                        if ((this.swallet2.search_str != "") && (this.swallet2.search_str != null))
                        {
                            this.xcomments = this.xcomments + "<a href=view_searcho2.aspx?x=" + this.pID + " target='_blank'>View</a>";
                        }
                        else
                        {
                            this.xcomments = this.xcomments + "NONE";
                        }

                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";

                        this.xcomments = this.xcomments + "<tr>";
                        this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                        this.xcomments = this.xcomments + "&nbsp;";
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";
                    } //////////
                }
            }
            else
            {
                base.Response.Redirect("./registrar.aspx");
            }
        }

        protected void MycloseWindow(object sender, EventArgs e)
        {
            if (this.succ != "0")
            {
               // base.Response.Write("<script language=JavaScript>alert('Data updated successfully')</script>");
                base.Response.Redirect("./registrar.aspx");
            }
            else
            {
                Label8.Text = "Data not verified, Please try again later";
              //  base.Response.Write("<script language=JavaScript>alert('Data not verified, Please try again later')</script>");
            }
          //  Verify.Visible = true;
        }
        protected void rbValid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rbValid.SelectedValue == "Registered")
            {
               
              //  pup.ShowPopupWindow();


                this.rbval_text = "Registered";
                this.admin_status = "9";
               Verify.Visible = true;
            }
            else if (this.rbValid.SelectedValue == "Deferred")
            {
                this.rbval_text = "Deferred";
                this.admin_status = "8";
                Verify.Visible = true;
            }
        }

        protected void Verify_Click(object sender, EventArgs e)
        {
            if (this.rbval_text == "") { this.rbval_text = "Registered"; }
            this.succ = this.z.a_reg_tm_office(this.c_mark.log_staff, this.admin_status, this.rbValid.SelectedValue, this.comment.Text, this.search_doc_succ1, this.search_doc_succ2, this.search_doc_succ3, this.admin, txt_rtm.Text);
            //int vno = z.getMaxRtno();
            //string vno2 = (vno + 1).ToString().PadLeft(4, '0');
            //if (vno2 == "3004")
            //{
            //    vno2 = "3005";
            //}
            //z.updatepwalletID(this.c_mark.log_staff, vno2);
            //Label8.Text = "Rtm No " + vno2 + " Generated";
            //pup.ShowPopupWindow();


            string vnum = c_p.validationID;

            if (vnum.Trim().Substring(0, 1) == "M")
            {
                base.Response.Redirect("./registrar.aspx");

            }

            else
            {
                int vno = 0;
                lock (z)
                {
                    Thread.Sleep(5000);
                    vno = z.getMaxRtno();

                }
                string vno2 = (vno + 1).ToString().PadLeft(4, '0');
                if (vno2 == "3004")
                {
                    vno2 = "3005";
                }
                z.updatepwalletID(this.c_mark.log_staff, vno2);
              //  Label8.Text = "Rtm No " + vno2 + " Generated";
                string vmessage = "Rtm No " + vno2 + " Generated";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "showDialogue", "showDialogue('" + vmessage + "');", true);
               // pup.ShowPopupWindow();



            }


            
            //if (this.succ != "0")
            //{
            //    base.Response.Write("<script language=JavaScript>alert('Data updated successfully')</script>");
            //    base.Response.Redirect("./registrar.aspx");
            //}
            //else
            //{
            //    base.Response.Write("<script language=JavaScript>alert('Data not verified, Please try again later')</script>");
            //}
        }
    }
}

