namespace cld
{
    using admin ;
    using Classes ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class appstatusx : UserControl
    {
        public string agt;
        protected Button BtnCheckStatus;
      
        public string r;
        protected Button Save;
        public int showt;
        public string status = "N/A";
        public string data_status = "N/A";
        public tm t = new tm();
        protected TextBox xref;
        public zues z = new zues();

        public List<tm.Stage> lt_pwx = new List<tm.Stage>();
        public List<tm.Applicant> lt_appx = new List<tm.Applicant>();
        public List<tm.MarkInfo> lt_mix = new List<tm.MarkInfo>();
        public List<tm.AddressService> lt_aosx = new List<tm.AddressService>();
        public List<tm.Representative> lt_repx = new List<tm.Representative>();
        public List<tm.Address> lt_appaddyx = new List<tm.Address>();
        public List<tm.Address> lt_repaddyx = new List<tm.Address>();
        public int refill=0;
        public bool islogopic = true;
        public string agent_msg = "";
        public string msg = "";
        public string fullname = "";
        public string app_no = "";  


        protected void BtnCheckStatus_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("./appstatus.aspx?agt="+agt);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString["agt"] != null)
            {
                this.agt = base.Request.QueryString["agt"].ToString();
            }
            else
            {
              //  base.Response.Redirect("http://www.iponigeria.com");
            }
            if (Session["xvid"] != null)
            {
                this.r = Session["xvid"].ToString();
            }
            
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (this.xref.Text != "")
            {
                if (this.xref.Text.Contains("OAI/TM/"))
                {
                    this.xref.Text = this.xref.Text.Replace("OAI/TM/", "");
                }
                this.r = this.xref.Text;
                this.lt_pwx = this.t.getStageByUserIDAcc(this.xref.Text, this.agt);
                if (this.lt_pwx.Count > 0)
                {
                    Session["app_no"] = "OAI/TM/" + lt_pwx[0].validationID;
                    tm.Stage s = this.t.getStatusIDByvalidationID(this.xref.Text.Trim());

                    this.showt = 1;
                    lt_appx = t.getApplicantListByUserID(s.ID);
                    lt_mix = t.getMarkInfoByUserID(s.ID);
                    lt_aosx = t.getAddressServiceListByID(s.ID);
                    lt_repx = t.getRepListByUserID(s.ID);
                    if (this.lt_appx.Count > 0)
                    {
                        if ((lt_appx[0].addressID != null) && (lt_appx[0].addressID != "") && (lt_appx[0].addressID != "0"))
                        {
                            lt_appaddyx = t.getAddressByID(lt_appx[0].addressID);
                            if (lt_appaddyx.Count > 0)
                            {
                                Session["app_email"] = lt_appaddyx[0].email1;
                            }
                        }
                    }
                    if (this.lt_repx.Count > 0)
                    {
                        Session["fullname"] = lt_repx[0].xname;
                        if ((lt_repx[0].addressID != null) && (lt_repx[0].addressID != "") && (lt_repx[0].addressID != "0"))
                        {
                            lt_repaddyx = t.getAddressByID(lt_repx[0].addressID);
                            if (lt_appaddyx.Count > 0)
                            {
                                Session["rep_email"] = lt_repaddyx[0].email1;
                            }
                        }
                    }
                    if (this.lt_mix.Count > 0)
                    {
                        if ((lt_mix[0].logo_descriptionID != "2") && (lt_mix[0].logo_pic == "")) { islogopic = false; }
                    }
                    if ((Convert.ToInt32(s.status) == 1) &&
                        (lt_appx.Count == 1) && (lt_mix.Count == 1)&&
                        (lt_aosx.Count == 1) && (lt_repx.Count == 1)&&
                         (lt_appaddyx.Count == 1) && (lt_repaddyx.Count == 1)
                        )
                    {
                        if (lt_mix[0].logo_descriptionID != "2")
                        {
                            if (lt_mix[0].logo_pic != "")
                            {
                                refill = 0;
                                showStatus(lt_pwx);
                            }
                            else
                            {
                                status = "Filing"; data_status = "Uncompleted";
                                refill = 1;
                            }
                        }
                        else
                        {
                            refill = 0;
                            showStatus(lt_pwx);
                        }
                    }
                    else if ((Convert.ToInt32(s.status) == 1) &&
                        ((lt_appx.Count != 1) || (lt_mix.Count != 1) ||
                        (lt_aosx.Count != 1) || (lt_repx.Count != 1) ||
                         (lt_appaddyx.Count != 1) || (lt_repaddyx.Count != 1)
                        ))
                    {
                        status = "Filing"; data_status = "Uncompleted";
                            refill = 1;
                    }
                    else if (Convert.ToInt32(s.status) > 1)
                    {
                        refill = 0;
                        showStatus(lt_pwx);
                    }
                }
                
            }
            else
            {
                base.Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>");
            }
        }

        public void showStatus(List<tm.Stage> lt_p)
        {
            if (Session["fullname"] != null) { fullname = Session["fullname"].ToString(); }
            if (Session["app_no"] != null) { app_no = Session["app_no"].ToString(); }

            if (lt_p[0].status == "1")
            {
                this.status = "Verification";
                if (lt_p[0].data_status == "Fresh") 
                {
                    data_status = "Untreated"; 
                    agent_msg = "<strong>\"Verification Office\"</strong>";
                }
            }
            if (lt_p[0].status == "2")
            {
                if (lt_p[0].data_status == "Re-conduct search")
                {
                    data_status = "being re-conducted"; this.status = "Search";
                    agent_msg = "<strong>\"Search Office\"</strong>";
                }
                else if (lt_p[0].data_status == "Valid")
                { 
                    data_status = "awaiting attendance"; this.status = "Search"; 
                    agent_msg = "<strong>\"Verification Office\"</strong>";
                }
            }
            if (lt_p[0].status == "22")
            {
                this.status = "Search 2";
                if (lt_p[0].data_status == "Re-conduct search 1") 
                { 
                    data_status = "being re-conducted";
                    agent_msg = "<strong>\"Search Office\"</strong>";
                }
            }
            if (lt_p[0].status == "3")
            {
                if (lt_p[0].data_status == "Search Conducted")
                { 
                    data_status = "being processed"; this.status = "Search 2";
                    agent_msg = "<strong>\"Verification Office\"</strong>";
                
                }
                else if (lt_p[0].data_status == "Re-examine")
                { 
                    data_status = "being re-examined"; this.status = "Examiners";
                    agent_msg = "<strong>\"Verification Office\"</strong>";
                }
            }
            if (lt_p[0].status == "33")
            {
                this.status = "Examiners";
                if (lt_p[0].data_status == "Search 2 Conducted") 
                { 
                    data_status = "being examined";
                    agent_msg = "being examined";
                }
            }
            if (lt_p[0].status == "4")
            {
                this.status = "Acceptance";
                if (lt_p[0].data_status == "Registrable")
                {
                    data_status = "Accepted";
                    agent_msg = "<strong>\"Acceptance Office\"</strong> and is registrable";
                }
                else if (lt_p[0].data_status == "Refused")
                { 
                    data_status = "Refused";
                    agent_msg = "<strong>\"Acceptance Office\"</strong> and is not-registrable";
                }
                else if (lt_p[0].data_status == "Non-registrable") 
                { 
                    data_status = "not-registrable";
                    agent_msg = "<strong>\"Acceptance Office\"</strong> and is not-registrable";
                }
            }
            if (lt_p[0].status == "5" || lt_p[0].status == "11" || lt_p[0].status == "13")
            {
                if (lt_p[0].data_status == "Accepted") {
                    data_status = "being published"; this.status = "Publication";
                    agent_msg = "<strong>\"Publication Office\"</strong> and your acceptance letter is ready for collection";
                }
                else if (lt_p[0].data_status == "Deferred") 
                { 
                    data_status = "been deferred"; this.status = "Publication";
                    agent_msg = "<strong>\"Publication Office\"</strong>";
                }
                else if (lt_p[0].data_status == "acc_printed")
                {
                    data_status = "being published"; this.status = "Publication";
                    agent_msg = "<strong>\"Publication Office\"</strong> and your acceptance letter is ready for collection";
                }
                else if (lt_p[0].data_status == "Withdraw")
                {
                    data_status = "being published"; this.status = "Publication";
                    agent_msg = "<strong>\"Publication Office\"</strong> and your application has been withdrawn";
                }
                else if (lt_p[0].data_status == "kiv")
                {
                    data_status = "being processed"; this.status = "Publication";
                    agent_msg = "<strong>\"Publication Office\"</strong> and is being processed";
                }

            }
            if (lt_p[0].status == "6")
            {
                this.status = "Opposition";
                if (lt_p[0].data_status == "Published") {
                    data_status = "being published";
                    agent_msg = "<strong>\"Verification Office\"</strong>";
                }
                else {
                    data_status = "been opposed";
                    agent_msg = "<strong>\"Verification Office\"</strong>";
                }
            }
            if (lt_p[0].status == "7")
            {
                if (lt_p[0].data_status == "Not Opposed") {
                    data_status = "being processed"; this.status = "Certification";
                    agent_msg = "<strong>\"Verification Office\"</strong>";
                }
                else if (lt_p[0].data_status == "Deferred") 
                { 
                    data_status = "been deferred"; this.status = "Certification";
                    agent_msg = "<strong>\"Verification Office\"</strong>";
                }
            }
            if (lt_p[0].status == "8")
            {
                this.status = "Registrars";
                if (lt_p[0].data_status == "Certified")
                {
                    data_status = "being processed";
                    agent_msg = "<strong>\"Verification Office\"</strong>";
                }
            }
            if (lt_p[0].status == "9")
            {
                this.status = "Registrars";
                if (lt_p[0].data_status == "Registered")
                { 
                    data_status = "being registered";
                    agent_msg = "<strong>\"Verification Office\"</strong>"; 
                }
            }

            msg = "Dear " + fullname + ",<br/>";
            msg += "This is to notify you that your application (" + app_no + ") is currently at the  " + agent_msg + ".<br/>";
            msg += "Thank you.";
            Session["msg"] = msg;
            sendAlert();
        }

        protected void sendAlert()
        {          
                   
          //  if (Session["app_no"] != null) { app_no = Session["app_no"].ToString(); }
            if (Session["msg"] != null) { msg = Session["msg"].ToString(); }

            Classes.Email em = new Classes.Email();           

            string sub = "CLD APPLICATION STATUS FOR "+app_no;
            string f_email = "info@cldng.com";

            if (Session["rep_email"] != null) {
                em.sendMail("CLD APPLICATION STATUS", Session["rep_email"].ToString(), f_email, sub, msg, "");            
            }

            if (Session["app_email"] != null)
            {
                em.sendMail("CLD APPLICATION STATUS", Session["app_email"].ToString(), f_email, sub, msg, "");
            }

        }
    }
}

