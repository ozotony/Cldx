using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace cld
{
    using Classes;
    public partial class trademark_refill : System.Web.UI.Page
    {
        public string adminID = "0";
        public string address_text = "";
        public string agentemail;
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
        public string city_text = "";
        public string cname;
        public string disclaimer_text = "0";
        public string email_text = "";
        public string enable_AosConfirm = "0";
        public string enable_AosSave = "1";
        public string enable_AppConfirm = "0";
        public string enable_AppSave = "1";
        public string enable_MarkConfirm = "0";
        public string enable_MarkSave = "1";
        public string enable_RepConfirm = "0";
        public string enable_RepSave = "1";
        public string enable_Save_Doc = "1";
        public string gt = "";
        public string log_staffID = "0";
        public string logo_desc_text = "";
        public string logo_pic_path = "";
        public string logo_pic_text = "";
        public string logo_text = "";
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
        public string pwalletID = "0";
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
        public string xapplication = "";
        public string xcode_text = "";
        public string xdesc_national_class = "0";
        protected string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
        protected string visible = "1";
        public List<tm.Stage> lt_pw = new List<tm.Stage>();
        public List<tm.Applicant> lt_app = new List<tm.Applicant>();
        public List<tm.MarkInfo> lt_mi = new List<tm.MarkInfo>();
        public List<tm.AddressService> lt_aos = new List<tm.AddressService>();
        public List<tm.Representative> lt_rep = new List<tm.Representative>();
        public List<tm.Address> lt_appaddy = new List<tm.Address>();
        public List<tm.Address> lt_repaddy = new List<tm.Address>();
        public Classes.updateX xt = new updateX();

        public int app_updateID = 0;
        public int appaddy_updateID = 0;
        public int mi_updateID = 0;
        public int rep_updateID = 0;
        public int repaddy_updateID = 0;
        public int aos_updateID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["pwalletID"] != null) && (this.Session["pwalletID"].ToString() != ""))
            {
                this.adminID = this.Session["pwalletID"].ToString();
            }

            if (base.Request.QueryString["XXX1234445"] != null)
            {
                this.vid = base.Request.QueryString["XXX1234445"].ToString();
                if (this.vid.Contains("OAI/TM/"))
                {
                    this.vid = this.vid.Replace("OAI/TM/", "");
                }
                this.Session["vid"] = vid;
            }
            else
            {
                // base.Response.Redirect("./appstatus.aspx");
            }
            if (base.Request.QueryString["XXX94384238"] != null)
            {
                this.aid = base.Request.QueryString["XXX94384238"].ToString();
                this.Session["aid"] = aid; this.xcode.Text = Request.QueryString["XXX94384238"].ToString();
            }
            else
            {
                // base.Response.Redirect("./appstatus.aspx");
            }

            this.serverpath = base.Server.MapPath("~/");
            if (this.Session["aid"] != null)
            {
                this.xaid.Value = this.Session["aid"].ToString();
            }
            if (this.Session["vid"] != null)
            {
                this.xvid.Value = this.Session["vid"].ToString();
            }
            else
            {
                //base.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
            }
            if (this.Session["amt"] != null)
            {
                this.xamt.Value = this.Session["amt"].ToString();
            }
            if (this.Session["gt"] != null)
            {
                this.xgt.Value = this.Session["gt"].ToString();
            }
            if (this.Session["pc"] != null)
            {
                this.xpc.Value = this.Session["pc"].ToString();
            }
            if (this.Session["pwalletID"] != null)
            {
                this.xpwalletID.Value = this.Session["pwalletID"].ToString();
            }
            if (this.Session["agentemail"] != null)
            {
                this.G_Agent_infoemail.Value = this.Session["agentemail"].ToString();
            }
            if (this.Session["cname"] != null)
            {
                this.xcname.Value = this.Session["cname"].ToString();
            }
            if (this.Session["agentpnumber"] != null)
            {
                this.G_Agent_infopnumber.Value = this.Session["agentpnumber"].ToString();
            }
            if (this.Session["applicantname"] != null)
            {
                this.xapplicantname.Value = this.Session["applicantname"].ToString();
            }
            if (this.Session["product_title"] != null)
            {
                this.xproduct_title.Value = this.Session["product_title"].ToString();
            }
            if (this.Session["log_staffID"] != null)
            {
                this.log_staffID = this.Session["log_staffID"].ToString();
            }
            if (this.Session["aid"] != null)
            {
                this.xcode.Text = this.Session["aid"].ToString();
            }
            if (base.IsPostBack)
            {
                this.lt_state = this.t.getState(this.residence.SelectedValue);
                if (this.lt_state.Count == 0)
                {
                    this.state_row = "1";
                    this.state_visible = "1";
                }
                this.lt_rep_state = this.t.getState(this.rep_residence.SelectedValue);
                if (this.lt_rep_state.Count == 0)
                {
                    this.rep_state_row = "1";
                    this.state_visible = "1";
                }
                this.national_class_desc.Text = this.t.getNationalClassDesc((this.national_class.SelectedIndex + 1).ToString());
                if (this.Session["aid"] != null)
                {
                    this.xaid.Value = this.Session["aid"].ToString();
                }
                if (this.Session["vid"] != null)
                {
                    this.xvid.Value = this.Session["vid"].ToString();
                }
                if (this.Session["amt"] != null)
                {
                    this.xamt.Value = this.Session["amt"].ToString();
                }
                if (this.Session["gt"] != null)
                {
                    this.xgt.Value = this.Session["gt"].ToString();
                }
                if (this.Session["pc"] != null)
                {
                    this.xpc.Value = this.Session["pc"].ToString();
                }
                if (this.Session["pwalletID"] != null)
                {
                    this.xpwalletID.Value = this.Session["pwalletID"].ToString();
                }
                if (this.Session["agentemail"] != null)
                {
                    this.G_Agent_infoemail.Value = this.Session["agentemail"].ToString();
                }
                if (this.Session["cname"] != null)
                {
                    this.xcname.Value = this.Session["cname"].ToString();
                }
                if (this.Session["agentpnumber"] != null)
                {
                    this.G_Agent_infopnumber.Value = this.Session["agentpnumber"].ToString();
                }
                if (this.Session["applicantname"] != null)
                {
                    this.xapplicantname.Value = this.Session["applicantname"].ToString();
                }
                if (this.Session["product_title"] != null)
                {
                    this.xproduct_title.Value = this.Session["product_title"].ToString();
                }
            }
            else
            {
                this.nationality.SelectedIndex = 159;
                this.rep_nationality.SelectedIndex = 159;
                this.residence.SelectedIndex = 159;
                this.rep_residence.SelectedIndex = 159;
                this.lt_nclass = this.t.getJNationalClasses();
                this.national_class_desc.Text = this.lt_nclass[0].xdescription.ToString();
                this.rep_xname.Text = this.xcname.Value;
                this.rep_xemail.Text = this.G_Agent_infoemail.Value;
                this.title_of_product.Text = this.xproduct_title.Value;
                this.rep_xtelephone.Text = this.G_Agent_infopnumber.Value;

                this.lt_pw = this.t.getStageByValidationID(this.vid);
                if (this.lt_pw.Count > 0)
                {
                    this.Session["pwalletID"] = lt_pw[0].ID;
                    this.Session["log_staffID"] = "0";
                    lt_app = t.getApplicantListByUserID(lt_pw[0].ID);
                    lt_mi = t.getMarkInfoByUserID(lt_pw[0].ID);
                    lt_aos = t.getAddressServiceListByID(lt_pw[0].ID);
                    lt_rep = t.getRepListByUserID(lt_pw[0].ID);
                    if (this.lt_app.Count > 0)
                    {
                        if ((lt_app[0].addressID != null) && (lt_app[0].addressID != "") && (lt_app[0].addressID != "0"))
                        {
                            lt_appaddy = t.getAddressByID(lt_app[0].addressID);
                        }
                    }
                    if (this.lt_rep.Count > 0)
                    {
                        if ((lt_rep[0].addressID != null) && (lt_rep[0].addressID != "") && (lt_rep[0].addressID != "0"))
                        {
                            lt_repaddy = t.getAddressByID(lt_rep[0].addressID);
                        }
                    }
                }

                if (this.lt_app.Count > 0)
                {
                    this.Session["lt_app"] = lt_app; this.Session["lt_appID"] = lt_app[0].ID; this.Session["ltapp_regdate"] = lt_app[0].reg_date;
                    this.xname.Text = this.lt_app[0].xname;
                    this.nationality.SelectedIndex = Convert.ToInt32(this.lt_app[0].nationality) - 1;
                    if (this.lt_appaddy.Count > 0)
                    {
                        this.Session["lt_appaddy"] = lt_appaddy; this.Session["lt_appaddyID"] = lt_appaddy[0].ID;
                        this.Session["ltappaddy_regdate"] = lt_appaddy[0].reg_date;
                        this.residence.SelectedIndex = Convert.ToInt32(this.lt_appaddy[0].countryID) - 1;
                        string stateID = this.lt_appaddy[0].stateID;
                        if (this.residence.SelectedIndex == 0x9f)
                        {
                            if ((stateID != null) || (stateID != ""))
                            {
                                this.xselectState.SelectedIndex = Convert.ToInt32(this.lt_appaddy[0].stateID) - 1;
                            }
                            else
                            {
                                this.xselectState.SelectedIndex = 0;
                            }
                            this.state_row = "0";
                        }
                        else
                        {
                            this.state_row = "1";
                        }
                        
                        this.xaddress.Text = this.lt_appaddy[0].street;
                        this.xtelephone.Text = this.lt_appaddy[0].telephone1;
                        this.xemail.Text = this.lt_appaddy[0].email1;
                    }
                }

                if (this.lt_mi.Count > 0)
                {
                    if (this.lt_mi.Count > 1)
                    {
                        for (int i = 1; i <= this.lt_mi.Count; i++)
                        {
                            this.xt.deleteMarkInfo(this.lt_mi[i].xID);
                            this.lt_mi.RemoveAt(i);
                        }
                    }
                    this.Session["lt_mi"] = lt_mi; this.Session["lt_miID"] = lt_mi[0].xID; this.Session["ltmi_regdate"] = lt_mi[0].reg_date;
                    this.title_of_product.Text = this.lt_mi[0].product_title;
                    this.nice_class_desc.Text = this.lt_mi[0].nice_class_desc;
                    this.txt_discalimer.Text = this.lt_mi[0].disclaimer;
                    if (this.lt_mi[0].disclaimer != "")
                    {
                        this.rbDisclaimer.SelectedValue = "YES";
                        this.disclaimer_text = "1";
                    }
                    this.tmType.SelectedIndex = Convert.ToInt32(this.lt_mi[0].tm_typeID) - 1;
                    this.logo_description.SelectedIndex = Convert.ToInt32(this.lt_mi[0].logo_descriptionID) - 1;
                    this.national_class.SelectedIndex = Convert.ToInt32(this.lt_mi[0].national_classID) - 1;
                    this.national_class_desc.Text = this.t.getNationalClassDesc(this.lt_mi[0].national_classID);
                    this.xdesc_national_class = "1";
                    if (this.logo_description.SelectedValue != "2")
                    {
                        this.logo_text = "1";
                    }
                    else
                    {
                        this.logo_text = "0";
                    }
                }

                if (this.lt_aos.Count > 0)
                {
                    this.Session["lt_aos"] = lt_aos; this.Session["lt_aosID"] = lt_aos[0].ID; this.Session["ltaos_regdate"] = lt_aos[0].reg_date;
                    this.aos_xselectState.SelectedIndex = Convert.ToInt32(this.lt_aos[0].stateID) - 1;
                    this.aos_xaddress.Text = this.lt_aos[0].street;
                    this.aos_xtelephone.Text = this.lt_aos[0].telephone1;
                    this.aos_xemail.Text = this.lt_aos[0].email1;
                }

                if (this.lt_rep.Count > 0)
                {
                    this.Session["lt_rep"] = lt_rep; this.Session["lt_repID"] = lt_rep[0].ID; this.Session["ltrep_regdate"] = lt_rep[0].reg_date;

                    this.rep_xname.Text = this.lt_rep[0].xname;
                    this.rep_nationality.SelectedIndex = Convert.ToInt32(this.lt_rep[0].nationality) - 1;
                    if (this.lt_repaddy.Count > 0)
                    {
                        this.Session["lt_repaddy"] = lt_repaddy; this.Session["lt_repaddyID"] = lt_repaddy[0].ID;
                        this.Session["ltrepaddy_regdate"] = lt_repaddy[0].reg_date;
                        this.rep_residence.SelectedIndex = Convert.ToInt32(this.lt_repaddy[0].countryID) - 1;
                        this.xselectRepState.SelectedIndex = Convert.ToInt32(this.lt_repaddy[0].stateID) - 1;
                        this.rep_address.Text = this.lt_repaddy[0].street;
                        this.rep_xtelephone.Text = this.lt_repaddy[0].telephone1;
                        this.rep_xemail.Text = this.lt_repaddy[0].email1;
                    }

                }

            }
            this.transID = this.Session["vid"].ToString();
            this.Session["xref"] = Convert.ToInt32(this.Session["xref"]) + 1;
            if (this.Session["xref"].ToString() != "1")
            {
                //if (this.Session["Trademark_item"] == null)
                //{
                //    base.Response.Redirect("./violation.aspx");
                //}
                //else
                //{
                //    Response.Redirect("./a_violation.aspx");
                //}
            }
            if (((this.Session["xapplication"] != null) && (this.Session["xapplication"].ToString() != "")) && (this.transID != this.Session["xapplication"].ToString()))
            {
                //if (this.Session["Trademark_item"] == null)
                //{
                //    base.Response.Redirect("./violation.aspx");
                //}
                //else
                //{
                //    Response.Redirect("./a_violation.aspx");
                //}
            }
            this.xdesc_national_class = "1";
            if (this.rbDisclaimer.SelectedValue == "YES")
            {
                this.disclaimer_text = "1";
            }
            else
            {
                this.disclaimer_text = "0";
            }
            if (this.logo_description.SelectedValue != "2")
            {
                this.logo_text = "1";
            }
            else
            {
                this.logo_text = "";
            }
           
        }
   
        protected void logo_description_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.national_class_desc.Text = this.t.getNationalClassDesc((this.national_class.SelectedIndex + 1).ToString());
            if (this.logo_description.SelectedValue != "2")
            {
                this.logo_text = "1";
            }
            else
            {
                this.logo_text = "";
            }
        }

        protected void national_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.national_class_desc.Text = this.t.getNationalClassDesc((this.national_class.SelectedIndex + 1).ToString());
            if (this.national_class_desc.Text != "")
            {
                this.xdesc_national_class = "1";
            }
            if (this.logo_description.SelectedValue != "2")
            {
                this.logo_text = "1";
            }
            else
            {
                this.logo_text = "";
            }
        }
        protected void rbDisclaimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rbDisclaimer.SelectedValue == "YES")
            {
                this.disclaimer_text = "1";
            }
            else
            {
                this.disclaimer_text = "0";
            }
        }

        protected void SaveAll_Click(object sender, EventArgs e)
        {
            if (this.Session["lt_app"] != null)
            {
                lt_app.Clear(); lt_app = (List<tm.Applicant>)this.Session["lt_app"];
            }
            if (this.Session["lt_mi"] != null)
            {
                lt_mi.Clear(); lt_mi = (List<tm.MarkInfo>)this.Session["lt_mi"];
            }
            if (this.Session["lt_aos"] != null)
            {
                lt_aos.Clear(); lt_aos = (List<tm.AddressService>)this.Session["lt_aos"];
            }
            if (this.Session["lt_rep"] != null)
            {
                lt_rep.Clear(); lt_rep = (List<tm.Representative>)this.Session["lt_rep"];
            }
            if (this.Session["lt_appaddy"] != null)
            {
                lt_appaddy.Clear(); lt_appaddy = (List<tm.Address>)this.Session["lt_appaddy"];
            }
            if (this.Session["lt_repaddy"] != null)
            {
                lt_repaddy.Clear(); lt_repaddy = (List<tm.Address>)this.Session["lt_repaddy"];
            }

            this.SaveAll.Visible = false;
            this.c_app.xname = this.xname.Text;
            this.c_app.nationality = this.nationality.Text;
            this.c_app.log_staff = Session["pwalletID"].ToString();
            this.c_app.reg_date = reg_date;
            this.c_app.visible = visible;
            this.c_app_addy.countryID = this.residence.Text;
            this.c_app_addy.stateID = this.xselectState.Text;
            this.c_app_addy.city = "";
            this.c_app_addy.street = this.xaddress.Text;
            this.c_app_addy.telephone1 = this.xtelephone.Text;
            this.c_app_addy.email1 = this.xemail.Text;
            this.c_app_addy.log_staff = Session["pwalletID"].ToString();
            this.c_app_addy.reg_date = reg_date;
            this.c_app_addy.visible = visible;

            this.c_mark.tm_typeID = this.tmType.SelectedValue;
            this.c_mark.logo_descriptionID = this.logo_description.SelectedValue;
            this.c_mark.product_title = this.title_of_product.Text;
            this.c_mark.nice_class = this.national_class.SelectedValue;
            this.c_mark.nice_class_desc = this.nice_class_desc.Text;
            this.c_mark.national_classID = this.national_class.SelectedValue;
            this.c_mark.disclaimer = this.txt_discalimer.Text;
            this.c_mark.log_staff = Session["pwalletID"].ToString();
            this.c_mark.reg_date = reg_date;
            this.c_mark.xvisible = visible;

            this.c_aos.stateID = this.aos_xselectState.Text;
            this.c_aos.city = "";
            this.c_aos.street = this.aos_xaddress.Text;
            this.c_aos.telephone1 = this.aos_xtelephone.Text;
            this.c_aos.email1 = this.aos_xemail.Text;
            this.c_aos.log_staff = Session["pwalletID"].ToString();
            this.c_aos.reg_date = reg_date;
            this.c_aos.visible = visible;
            this.c_rep.agent_code = this.xaid.Value;
            this.c_rep.xname = this.rep_xname.Text;
            this.c_rep.nationality = this.rep_nationality.SelectedValue;
            this.c_rep.log_staff = Session["pwalletID"].ToString();
            this.c_rep.reg_date = reg_date;
            this.c_rep.visible = visible;
            this.c_rep_addy.countryID = this.rep_residence.SelectedValue;
            this.c_rep_addy.stateID = this.xselectRepState.SelectedValue;
            this.c_rep_addy.city = "";
            this.c_rep_addy.street = this.rep_address.Text;
            this.c_rep_addy.telephone1 = this.rep_xtelephone.Text;
            this.c_rep_addy.email1 = this.rep_xemail.Text;
            this.c_rep_addy.reg_date = reg_date;
            this.c_rep_addy.log_staff = Session["pwalletID"].ToString();
            this.c_rep_addy.visible = visible;

            Session["c_app"] = c_app; Session["c_mark"] = c_mark; Session["c_aos"] = c_aos;
            Session["c_rep"] = c_rep; Session["c_app_addy"] = c_app_addy; Session["c_rep_addy"] = c_rep_addy;

            this.pwalletID = this.xpwalletID.Value;
            if (Session["lt_aosID"] != null) { c_aos.ID = Session["lt_aosID"].ToString(); }
            if (Session["lt_miID"] != null) { c_mark.xID = Session["lt_miID"].ToString(); }
            if (Session["lt_appID"] != null) { c_app.ID = Session["lt_appID"].ToString(); }
            if (Session["lt_repID"] != null) { c_rep.ID = Session["lt_repID"].ToString(); }
            if (Session["lt_appaddyID"] != null) { c_app_addy.ID = Session["lt_appaddyID"].ToString(); }
            if (Session["lt_repaddyID"] != null) { c_rep_addy.ID = Session["lt_repaddyID"].ToString(); }

            if ((lt_app.Count == 0) && (lt_aos.Count == 0) && (lt_rep.Count == 0) && (lt_mi.Count == 0) && (lt_appaddy.Count == 0) && (lt_repaddy.Count == 0))
            {
                this.xmarkID.Value = this.t.addTrademark(this.c_app, this.c_mark, this.c_aos, this.c_rep, this.c_app_addy, this.c_rep_addy, this.log_staffID);

                if (this.xmarkID.Value != "0")
                {
                    this.show_image_section = "1";
                    Session["mi_updateID"] = this.xmarkID.Value;
                    Response.Redirect("./trademark_refill_docs.aspx");
                }
            }
            else
            {
                if (lt_appaddy.Count == 0)
                {
                    this.appaddy_updateID = Convert.ToInt32(t.addAddress(c_app_addy,adminID));
                }
                else
                {
                    if (Session["ltappaddy_regdate"] != null) { c_app_addy.reg_date = this.Session["ltappaddy_regdate"].ToString(); }
                    this.appaddy_updateID = t.UpdateAddress(c_app_addy);
                }

                if (lt_app.Count == 0)
                {
                    if (lt_appaddy.Count == 0) { c_app.addressID = appaddy_updateID.ToString(); }
                    else { c_app.addressID = lt_appaddy[0].ID; }

                    this.app_updateID = Convert.ToInt32(t.addSoloApplicant(c_app));
                }
                else
                {
                    if (Session["ltapp_regdate"] != null) { c_app.reg_date = this.Session["ltapp_regdate"].ToString(); }
                    this.app_updateID = t.UpdateApplicant(c_app); 
                }

                if (lt_repaddy.Count == 0)
                {
                    this.repaddy_updateID = Convert.ToInt32(t.addAddress(c_rep_addy, adminID));
                }
                else
                {
                    if (Session["ltrepaddy_regdate"] != null) { c_rep_addy.reg_date = this.Session["ltrepaddy_regdate"].ToString(); }
                    this.repaddy_updateID = t.UpdateAddress(c_rep_addy);
                }

                if (lt_rep.Count == 0)
                {
                    if (lt_repaddy.Count == 0) {  c_rep.addressID = repaddy_updateID.ToString();}
                    else { c_rep.addressID = lt_repaddy[0].ID; }

                    this.rep_updateID = Convert.ToInt32(t.addSoloRepresentative(c_rep));
                }
                else
                {
                    if (Session["ltrep_regdate"] != null) { c_rep.reg_date = this.Session["ltrep_regdate"].ToString(); }
                    this.rep_updateID = t.UpdateRep(c_rep);
                }

                if (lt_aos.Count == 0)
                {
                    this.aos_updateID = Convert.ToInt32(t.addAos(c_aos, adminID));
                }
                else
                {
                    if (Session["ltaos_regdate"] != null) { c_aos.reg_date = this.Session["ltaos_regdate"].ToString(); }
                    this.aos_updateID = t.UpdateAos(c_aos);
                }

                if (lt_mi.Count == 0)
                {
                    this.mi_updateID = Convert.ToInt32(t.addMark(c_mark, adminID));
                    t.updateMarkReg(mi_updateID.ToString(), c_mark.tm_typeID);
                    Session["mi_updateID"] = c_mark.xID;
                    if (mi_updateID > 0)
                    {
                        Response.Redirect("./trademark_refill_docs.aspx");
                    }
                }
                else
                {
                    if (Session["ltmi_regdate"] != null) { c_mark.reg_date = this.Session["ltmi_regdate"].ToString(); }
                    this.mi_updateID = t.UpdateMark(c_mark);
                    t.updateMarkReg(c_mark.xID, c_mark.tm_typeID);
                    Session["mi_updateID"] = c_mark.xID;
                    if (mi_updateID > 0)
                    {
                        Response.Redirect("./trademark_refill_docs.aspx");
                    }
                }

            }


        }

     
    }
}