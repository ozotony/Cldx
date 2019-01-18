using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace cld.admin.tm.search_unit
{
    public partial class imp_recs : System.Web.UI.Page
    {
        public string adminID = "0";
        public string excel_name = "";
        public string path = "";
        public string validate_txt = "";
        public string upload_txt = "";
        public string serverpath = "";
        public string pwalletID ="0";
        public string showLoader = "";
        public Classes.tm t = new Classes.tm();
        public Classes.tm.Stage c_pwallet = new Classes.tm.Stage();
        public Classes.tm.Address c_app_addy = new Classes.tm.Address();
        public Classes.tm.Address c_rep_addy = new Classes.tm.Address();
        public Classes.tm.Applicant c_app=new Classes.tm.Applicant();
        public Classes.tm.MarkInfo c_mi = new Classes.tm.MarkInfo();
        public Classes.tm.AddressService c_aos = new Classes.tm.AddressService();
        public Classes.tm.Representative c_rep = new Classes.tm.Representative();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["pwalletID"] != null)
            {
                if (this.Session["pwalletID"].ToString() != "")
                {
                    this.adminID = this.Session["pwalletID"].ToString();
                }
                else
                {
                    base.Response.Redirect("../xcontrol.aspx");
                }
            }
            else
            {
                base.Response.Redirect("../xcontrol.aspx");
            }
            btnImportReport.Visible = false; btnRefresh.Visible = false;
            this.serverpath = base.Server.MapPath("~/");
        }

        protected void btnImportReport_Click(object sender, EventArgs e)
        {
            if (Session["cur_excel_name"] != null)
            {
                insertExcelRecords(Session["cur_excel_name"].ToString());
            }
        }

        protected string valid(OleDbDataReader myreader, string colname)//if any columns are found null then they are replaced by zero
        {
            if (colname != "Filing Date")
            {
                object val = myreader[colname]; 
                    if (val != DBNull.Value)
                    return val.ToString();
                    else
                    return Convert.ToString(0);
            }
            else
            {
                object val = myreader[colname];
                if (val != DBNull.Value)
                {
                    if (val.ToString().Length >= 10)
                    {
                        val = val.ToString().Substring(0, 10);
                        string[] d = val.ToString().Split('/');
                        string xday = d[1].Trim(); string xmonth = d[0].Trim(); string xyear = d[2].Trim();
                        if (xday.Length < 2) { xday = "0" + xday; } if (xmonth.Length < 2) { xmonth = "0" + xmonth; }
                        val = xyear.Substring(0,4) + "-" + xmonth + "-" + xday;
                        return val.ToString();
                    }
                    else
                    {
                        return Convert.ToString(0);
                    }
                }
                if (val != DBNull.Value)
                return val.ToString();
                 else
                return Convert.ToString(0);                
            }          
        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            excel_name=adminID+"_"+DateTime.Now.TimeOfDay.ToString();
            path=base.Server.MapPath("~/") + "admin\\tm\\SI\\"+excel_name;
            if (this.excel_doc.HasFile)
            {
                showLoader = "<img alt=\"loader\" class=\"style1\" src=\"../../../images/ajax_loader.gif\" />";
                 string excel_succ = this.t.doUploadExcelDoc("22", base.Server.MapPath("~/") + "admin/tm/SI/", this.excel_doc);
                 if ((excel_succ != "") && (excel_succ != "bformat"))
                 {
                     Session["cur_excel_name"] = excel_succ;
                     validate_txt = getExcelCount(excel_succ).ToString() + " Record(s) found in the excel sheet <br/>";
                     excel_doc.Visible = false;
                     btnValidate.Visible = false;
                     btnImportReport.Visible = true;
                     showLoader = "";
                 }
                 else if ((excel_succ != "") && (excel_succ == "bformat"))
                 {
                     showLoader = "";
                     validate_txt = "Document is not a valid excel sheet! Please re-upload a valid file!!<br/>";
                 }
                 else if ((excel_succ == "") && (excel_succ != "bformat"))
                 {
                     showLoader = "";
                     validate_txt = "No Record found in the excel sheet<br/>";
                 }
            }
        }

        public Int32 getExcelCount(string path)
        {
            Int32 cnt= 0;
            OleDbConnection oconn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 8.0");
            try
            {
                OleDbCommand ocmd = new OleDbCommand("select * from [Mark$]", oconn);
                oconn.Open();
                OleDbDataReader odr = ocmd.ExecuteReader();              
                while (odr.Read())
                {
                    cnt = cnt+1; //cnt = Convert.ToInt32(valid(odr, 0));
                }
                oconn.Close();                
            }
            catch (DataException ee)
            {}
            finally
            {}
            return cnt;
        }

        public void insertExcelRecords(string path)
        {
            showLoader = "<img alt=\"loader\" class=\"style1\" src=\"../../../images/ajax_loader.gif\" />";
            Int32 cnt = 0; string rec_exists = "";
            OleDbConnection oconn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 8.0");
            try
            {
                OleDbCommand ocmd = new OleDbCommand("select * from [Mark$]", oconn);
                oconn.Open();
                OleDbDataReader odr = ocmd.ExecuteReader();

                while (odr.Read())
                {   //Pwallet record
                    c_pwallet.validationID = valid(odr, "File Number");
                    c_pwallet.applicantID = "CLD/SA/"+adminID;
                    c_pwallet.log_officer = "0";
                    c_pwallet.amt = "15000";
                    c_pwallet.stage = "5";
                    c_pwallet.status = "9";
                    c_pwallet.data_status = "Registered";
                    string xdate = valid(odr, "Filing Date");
                    if (xdate == "0"){ xdate= t.formatExcelDate(xdate);}
                    c_pwallet.reg_date = xdate;
                    c_pwallet.visible = "1";
                    rec_exists = t.getPwalletID(c_pwallet.validationID);

                    if (rec_exists == "")
                    {
                    if (((this.c_pwallet.validationID != "0") && (this.c_pwallet.amt != "")) && ((this.c_pwallet.applicantID != "")))
                        {
                            this.pwalletID = this.t.addExcelPwallet(this.serverpath, this.c_pwallet);
                            if (this.pwalletID != "0")
                            {
                                this.Session["pwalletID"] = this.pwalletID;
                                xpwall.Value = this.pwalletID;
                                G_Agent_infocode.Value = c_pwallet.applicantID;
                            }
                        }
                        //Applicant Adderss record
                        c_app_addy.countryID = t.getCountryIDByCode(valid(odr, "Applicant Residence country"));
                        xResidence.Value = c_app_addy.countryID;
                        c_app_addy.street = valid(odr, "Applicant Address");
                        c_app_addy.city = valid(odr, "Applicant City");
                        c_app_addy.stateID = valid(odr, "Applicant State");
                        c_app_addy.zip = valid(odr, "Applicant Zip");
                        c_app_addy.telephone1 = valid(odr, "Applicant Telephone");
                        c_app_addy.email1 = valid(odr, "Applicant E-mail");
                        c_app_addy.log_staff = xpwall.Value;
                        c_app_addy.reg_date = xdate;
                        c_app_addy.visible = "1";

                        //Applicant record
                        c_app.xname = valid(odr, "Applicant Name(s)");
                        c_app.xtype = valid(odr, "Applicant Type");
                        c_app.tax_id_type = valid(odr, "Tax Applicant Id type");
                        c_app.tax_id_number = valid(odr, "Applicant Tax Id number");
                        c_app.individual_id_number = valid(odr, "Applicant Individual Id type");
                        c_app.nationality = t.getCountryIDByCode(valid(odr, "Applicant National country"));
                        c_app.log_staff = xpwall.Value;
                        c_app.reg_date = xdate;
                        c_app.visible = "1";

                        string appID = t.addExcelApplicant(c_app, c_app_addy);

                        //AOS record
                        c_aos.countryID = t.getCountryIDByCode(valid(odr, "Applicant Residence country"));
                        c_aos.street = valid(odr, "AOS Address");
                        c_aos.city = valid(odr, "AOS City");
                        c_aos.stateID = valid(odr, "AOS State");
                        c_aos.zip = valid(odr, "AOS Zip");
                        c_aos.telephone1 = valid(odr, "AOS Telephone");
                        c_aos.email1 = valid(odr, "AOS E-mail");
                        c_aos.log_staff = xpwall.Value;
                        c_aos.reg_date = xdate;
                        c_aos.visible = "1";

                        string aosID = t.addExcelAos(c_aos);

                        //Representative Adderss record
                        c_rep_addy.countryID = t.getCountryIDByCode(valid(odr, "Rep Residence country"));
                        c_rep_addy.street = valid(odr, "Rep Street");
                        c_rep_addy.city = valid(odr, "Rep City");
                        c_rep_addy.stateID = valid(odr, "Rep State");
                        c_rep_addy.zip = valid(odr, "Rep Zip");
                        c_rep_addy.telephone1 = valid(odr, "Rep Telephone");
                        c_rep_addy.email1 = valid(odr, "Rep E-mail");
                        c_rep_addy.log_staff = xpwall.Value;
                        c_rep_addy.reg_date = xdate;
                        c_rep_addy.visible = "1";

                        //Representative record
                        c_rep.xname = valid(odr, "Rep Name");
                        c_rep.agent_code = G_Agent_infocode.Value;
                        c_rep.individual_id_number = valid(odr, "Rep Individual Id type");
                        c_rep.nationality = t.getCountryIDByCode(valid(odr, "Rep National country"));
                        c_rep.log_staff = xpwall.Value;
                        c_rep.reg_date = xdate;
                        c_rep.visible = "1";

                        string repID = t.addExcelRepresentative(c_rep, c_rep_addy, adminID);

                        //Mark record
                        string tm_type = "";
                        if (xResidence.Value == "160") { tm_type = "1"; } else { tm_type = "2"; }
                        c_mi.tm_typeID = tm_type;
                        c_mi.sign_type = valid(odr, "Sign type");
                        c_mi.product_title = valid(odr, "Mark Name");
                        c_mi.disclaimer = valid(odr, "Disclaimer");
                        c_mi.vienna_class = valid(odr, "Viena Classes");
                        c_mi.logo_descriptionID = t.getLogoDescriptionID(valid(odr, "Logo description"));
                        c_mi.nice_class = valid(odr, "National Classes");
                        c_mi.national_classID = valid(odr, "National Classes");
                        c_mi.log_staff = xpwall.Value;
                        c_mi.reg_date = xdate;
                        c_mi.xvisible = "1";
                        cnt = cnt + 1;
                        string markID = t.addExcelMark(c_mi);
                        string updatemarkID = t.updateMarkReg(markID, tm_type);
                    }
                }
                oconn.Close();
            }
            catch (DataException ee)
            {
                showLoader = "";
            }
            finally
            {
                showLoader = "";
                validate_txt = cnt +" Record(s) inserted successfully";
                btnRefresh.Visible = true;
            }            
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("./imp_recs.aspx");
        }

    }
}