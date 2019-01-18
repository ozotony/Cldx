using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Transactions;
namespace cld.admin.tm.x_unit
{
    using cld.Classes;
    public partial class edit_apps3 : System.Web.UI.Page
    {
        public string adminID = "";
        public string address_text = "";
        public string agentpnumber;
        public string aid = "";
        public string amt = "";
        public string aos_address_text = "";
        public string aos_addressID = "1";
        public string aos_city_text = "";
        public string aos_email_text = "";
        public string aos_name_text = "";
        public string aos_state_row = "0";
        public string aos_state_text = "";
        public string aos_telephone_text = "";
        public string applicantname;
        public string auth_doc_path = "";
        public string auth_doc_text = "";
        public string auth_text = "";
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public tm.MarkInfo c_mark = new tm.MarkInfo();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
        public tm.Stage c_pwall = new tm.Stage();
        public string city_text = "";
        public string cname;
        public int succ;
        public int d_succ;
        public string disclaimer_text = "0";
        public string email_text = "";
        public string fee_detailsID = "";
        public string gt = "";
        public string hwalletID = "";
        public string log_staffID = "0";
        public string logo_desc_text = "";
        public string logo_pic_path = "";
        public string logo_pic_text = "";
        public List<tm.State> lt_aos_state;
        public List<tm.NClass> lt_nclass;
        public List<tm.State> lt_rep_state;
        public List<tm.State> lt_state;
        public string name_text = "";
        public string national_class_text = "";
        public int newState;
        public string nice_class_desc_text = "";
        public string pc = "";
        public string product_title;
        public string oldproduct_title;
        public string oldclass;
        public string oldname;
        public Registration reg = new Registration();
        protected string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
        public string rep_address_text = "";
        public string rep_city_text = "";
        public string rep_code_text = "";
        public string rep_email_text = "";
        public string rep_name_text = "";
        public string rep_residence_text = "";
        public string rep_state_row = "0";
        public string rep_state_text = "";
        public string rep_state_visible = "0";
        public string rep_telephone_text = "";
        public string residence_text = "";
        public string serverpath;
        public string show_image_section = "0";
        public string show_imageMsg = "";
        public int showItems;
        public string state_row = "0";
        public string state_text = "";
        public string state_visible = "0";
        public int status = 0;
        public string sup_doc1_path = "";
        public string sup_doc1_text = "";
        public string sup_doc2_path = "";
        public string sup_doc2_text = "";
        public tm t = new tm();
        public string telephone_text = "";
        public string title_of_product_text = "";
        public string tm_type_text = "";
        public string transID = "";
        public string vid = "";
        protected string visible = "1";
        public string xapplication = "";
        public string xcode_text = "";
        public string xdesc_national_class = "0";
        public string succ_msg = "";
        public string enable_RepSave = "0";
        public SortedList<string, string> sl_docz = new SortedList<string, string>();

        public int showsearch = 0;
        public string logo_text = "0";


        protected void Page_Load(object sender, EventArgs e)
        {

            if (logo_description.SelectedItem.Value != "2") { logo_pic_text = "1"; } else { logo_pic_text = "0"; }
            serverpath = base.Server.MapPath("~/");
            if (this.Session["pwalletID"] != null)
            {
                if (this.Session["pwalletID"].ToString() != "")
                {
                    this.adminID = this.Session["pwalletID"].ToString();
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

            serverpath = base.Server.MapPath("~/"); xdesc_national_class = "1";
            if (!IsPostBack)
            {
                Session["showsearch"] = null;
            }
            else
            {
                if ((Session["showsearch"] != null) && (Convert.ToInt32(Session["showsearch"]) > 0)) { showsearch = 1; }
                if (Session["c_mark"] != null)
                {
                    c_mark = (tm.MarkInfo)Session["c_mark"];
                }


            }
            if (logo_description.SelectedValue != "2") { logo_text = "1"; } else { logo_text = "0"; }

            Session["logo_description"] = logo_description.SelectedValue;
            if (base.IsPostBack)
            {

                national_class_desc.Text = t.getNationalClassDesc(national_class.SelectedValue);
            }
            else
            {

            }
        }

        protected void SearchApplicant_Click(object sender, EventArgs e)
        {
            if (txt_search.Text != "")
            {
                try
                {
                    succ_msg = "0";
                    string c_id = t.getPwalletID(txt_search.Text);
                    if (Convert.ToInt32(c_id) > 0)
                    {

                        c_pwall = t.getStageClassByUserID(c_id);
                        if (c_pwall.data_status == "Fresh" || c_pwall.data_status == "Valid" || c_pwall.data_status == "Re-conduct search" || c_pwall.data_status == "Search Conducted" || c_pwall.data_status == "Search 2 Conducted" || c_pwall.data_status == "Re-examine" || c_pwall.data_status == "Registrable")
                        {

                        }

                        else
                        {

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "showDialogue", "showDialogue('" + "Sorry You Cannot Edit Application At this Stage" + "');", true);
                            return;
                        }
                        if (Convert.ToInt32(c_pwall.ID) > 0)
                        {
                            Session["c_pwall"] = c_pwall;
                            c_app = t.getApplicantClassByID(c_id); Session["c_app"] = c_app;
                            c_mark = t.getMarkInfoClassByUserID(c_id); Session["c_mark"] = c_mark;
                            c_aos = t.getAddressServiceByID(c_id); Session["c_aos"] = c_aos;
                            c_rep = t.getRepClassByUserID(c_id); Session["c_rep"] = c_rep;
                            if (Convert.ToInt32(c_app.ID) > 0) { c_app_addy = t.getAddressClassByID(c_app.addressID); Session["c_app_addy"] = c_app_addy; }
                            if (Convert.ToInt32(c_rep.ID) > 0) { c_rep_addy = t.getAddressClassByID(c_rep.addressID); Session["c_rep_addy"] = c_rep_addy; }

                            xname.Text = c_app.xname;
                            xaddress.Text = c_app_addy.street;
                            xtelephone.Text = c_app_addy.telephone1;
                            xemail.Text = c_app_addy.email1;
                            try
                            {
                                nationality.SelectedIndex = Convert.ToInt32(c_app.nationality) - 1;
                            }
                            catch (Exception ee)
                            {

                            }
                            try
                            {
                                residence.SelectedIndex = Convert.ToInt32(c_app_addy.countryID) - 1;
                            }
                            catch (Exception ee)
                            {


                            }
                            try
                            {
                                xselectState.SelectedIndex = Convert.ToInt32(c_app_addy.stateID) - 1;
                            }
                            catch (Exception ee)
                            {


                            }

                            txt_rtm.Text = c_pwall.rtm;
                            curtime.Value = c_pwall.reg_date;
                            title_of_product.Text = c_mark.product_title;
                            nice_class_desc.Text = c_mark.nice_class_desc;
                            txt_discalimer.Text = c_mark.disclaimer;
                            TextBox1.Text = c_mark.reg_number;
                            tmType.SelectedIndex = Convert.ToInt32(c_mark.tm_typeID) - 1;
                            logo_description.SelectedIndex = Convert.ToInt32(c_mark.logo_descriptionID) - 1;
                            national_class.SelectedIndex = Convert.ToInt32(c_mark.national_classID) - 1;

                            aos_xaddress.Text = c_aos.street;
                            aos_xtelephone.Text = c_aos.telephone1;
                            aos_xemail.Text = c_aos.email1;
                            try
                            {
                                aos_xselectState.SelectedIndex = Convert.ToInt32(c_aos.stateID) - 1;
                            }
                            catch (Exception ee)
                            {

                            }

                            xcode.Text = c_rep.agent_code;
                            rep_xname.Text = c_rep.xname;
                            rep_address.Text = c_rep_addy.street;
                            rep_xtelephone.Text = c_rep_addy.telephone1;
                            rep_xemail.Text = c_rep_addy.email1;
                            try
                            {
                                rep_nationality.SelectedIndex = Convert.ToInt32(c_rep.nationality) - 1;
                            }
                            catch (Exception ee)
                            {

                            }
                            try
                            {
                                xselectRepState.SelectedIndex = Convert.ToInt32(c_rep_addy.stateID) - 1;
                            }
                            catch (Exception ee)
                            {


                            }

                            ///application
                            Session["showsearch"] = 1; showsearch = 1;
                            if (logo_description.SelectedItem.Value != "2") { logo_pic_text = "1"; } else { logo_pic_text = "0"; }
                        }

                    }
                }
                catch (Exception ee)
                {

                }
            }
        }

        protected void SaveAll_Click(object sender, EventArgs e)
        {
            string[] tx = null;
            TransactionOptions transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = new TimeSpan(0, 15, 0)
            };
            TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
            try
            {
                if (Session["c_pwall"] != null) { c_pwall = (tm.Stage)Session["c_pwall"]; }
                if (Session["c_app"] != null) { c_app = (tm.Applicant)Session["c_app"]; }
                if (Session["c_app_addy"] != null) { c_app_addy = (tm.Address)Session["c_app_addy"]; }
                if (Session["c_rep_addy"] != null) { c_rep_addy = (tm.Address)Session["c_rep_addy"]; }
                if (Session["c_mark"] != null) { c_mark = (tm.MarkInfo)Session["c_mark"]; }
                if (Session["c_aos"] != null) { c_aos = (tm.AddressService)Session["c_aos"]; }
                if (Session["c_rep"] != null) { c_rep = (tm.Representative)Session["c_rep"]; }
                tx = c_pwall.validationID.Trim().Split('-');
                if (tx.Length == 3)
                {
                    hwalletID = tx[2];
                }
                else
                {
                    hwalletID = "0";
                }
                c_pwall.rtm = txt_rtm.Text;
                if (txt_new_date.Text != "") { c_pwall.reg_date = txt_new_date.Text; }

                c_app.xname = xname.Text;
                c_app.nationality = nationality.Text;
                if (txt_new_date.Text != "") { c_app.reg_date = txt_new_date.Text; }
                c_app_addy.countryID = residence.Text;
                c_app_addy.stateID = xselectState.Text;
                c_app_addy.street = xaddress.Text;
                c_app_addy.telephone1 = xtelephone.Text;
                c_app_addy.email1 = xemail.Text;
                if (txt_new_date.Text != "") { c_app_addy.reg_date = txt_new_date.Text; }

                c_mark.tm_typeID = tmType.SelectedValue;
                c_mark.logo_descriptionID = logo_description.SelectedValue;

                c_mark.product_title = title_of_product.Text;
                c_mark.nice_class = national_class.SelectedValue;
                c_mark.nice_class_desc = nice_class_desc.Text;
                c_mark.national_classID = national_class.SelectedValue;
                c_mark.disclaimer = txt_discalimer.Text;
                c_mark.reg_number = TextBox1.Text;
                oldclass = c_mark.nice_class;

                oldproduct_title = c_mark.product_title;

                oldname = c_app.xname;


                if (txt_new_date.Text != "") { c_mark.reg_date = txt_new_date.Text; }

                c_aos.countryID = "160";
                c_aos.stateID = aos_xselectState.Text;
                c_aos.city = "";
                c_aos.street = aos_xaddress.Text;
                c_aos.telephone1 = aos_xtelephone.Text;
                c_aos.email1 = aos_xemail.Text;
                if (txt_new_date.Text != "") { c_aos.reg_date = txt_new_date.Text; }

                c_rep.agent_code = xcode.Text;
                c_rep.xname = rep_xname.Text;
                c_rep.nationality = rep_nationality.SelectedValue;
                c_rep.log_staff = "0";
                if (txt_new_date.Text != "") { c_rep.reg_date = txt_new_date.Text; }

                c_rep_addy.countryID = rep_residence.SelectedValue;
                c_rep_addy.stateID = xselectRepState.SelectedValue;
                c_rep_addy.city = "";
                c_rep_addy.street = rep_address.Text;
                c_rep_addy.telephone1 = rep_xtelephone.Text;
                c_rep_addy.email1 = rep_xemail.Text;
                if (txt_new_date.Text != "") { c_rep_addy.reg_date = txt_new_date.Text; }


                if (Session["hwalletID"] != null) { hwalletID = Session["hwalletID"].ToString(); }

                Boolean vfile = false;

                if (logo_description.SelectedItem.Value != "2") { vfile = true; } else { vfile = false; }
                succ = t.editTrademarkTx(c_app, c_mark, c_aos, c_rep, c_app_addy, c_rep_addy, c_pwall, sl_docz, logo_pic, auth_doc, sup_doc1, sup_doc2, Server.MapPath("~/"), vfile);
                if (Convert.ToInt32(succ) > 0)
                {
                    //ws_payx.payx ws_p = new ws_payx.payx();
                    //status = ws_p.UpdateHwallet(hwalletID, "Used", reg_date, title_of_product.Text);
                    //if (status >= 0)
                    //{
                    scope.Complete(); scope.Dispose();

                    t.activity_log(this.adminID, "Edit Application", "Update", c_app.log_staff, c_pwall.data_status, title_of_product.Text, oldproduct_title, oldname, xname.Text, oldclass, national_class.SelectedValue);
                    //}
                    //else
                    //{
                    //    scope.Dispose();
                    //    succ_msg = "Record Not Edited Successfully! Please try again";
                    //    showsearch = 0;
                    //}
                }
                else
                {
                    scope.Dispose();
                    succ_msg = "Record Not Edited Successfully! Please try again";
                    showsearch = 0;
                }
                /////
            }
            catch (Exception exception)
            {
                exception.ToString(); scope.Dispose();
                succ_msg = "Record Not Edited Successfully! Please try again";
                showsearch = 0;
            }
            finally
            {
                if (scope != null) { scope.Dispose(); }
            }
            succ_msg = "Record Edited Successfully!!!"; txt_search.Text = "";
            showsearch = 0;
        }
    }
}