using cld.admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace cld.admin.tm
{
    using cld.Classes;
    using System.ComponentModel;
    using System.Data;
    using System.Net.Mail;
    public partial class opposition : Page
    {
        public string admin = "0";
        public string criteria = "";
        public string criteria_type = "";
        public string data_status = "Published";
        public string dateFrom = "";
        public string dateFromArr = "";
        public string dateTo = "";
        public string dateToArr = "";
        protected GridView gvX;
        public List<XObjs.Office_view> lt_m = new List<XObjs.Office_view>();
        public List<zues.MarkInfo> lt_mi = new List<zues.MarkInfo>();
        public int max;
        public string stage = "6";
        public long x_cnt;
        public zues z = new zues();

        protected void btnReloadPage_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("opposition.aspx");
        }

        protected void btnSearch_Click2(object sender, EventArgs e)
        {
            string ss = "";
            string ss2 = "";
            string succ = "";
            foreach (GridViewRow row in gvX.Rows)
            {
                CheckBox chkBox = row.FindControl("cbSelect") as CheckBox;


                if (chkBox.Checked)
                {
                    Label Id = row.FindControl("lblLogStaff") as Label;

                   ss = Id.Text;


                   Label Id2 = row.FindControl("applicantID") as Label;

                   ss2 = Id2.Text;


                    

                   zues z = new zues();

                  succ = this.z.a_tm_office(ss, "7", "Not Opposed", "", "", "", "", this.admin);
                  Retriever vv = new Retriever();
                  XObjs.Registration ts = vv.getRegistrationByID2(ss2);

                  SendMail(ts);


                }

               

            }
            Response.Redirect("opposition.aspx");
         //   Response.Write("<script>window.opener.location.href = window.opener.location.href </script>");
        }

        public void SendMail(XObjs.Registration rr)
        {

            this.lt_m = (List<XObjs.Office_view>)this.Session["lt_m"];

            XObjs.Office_view bb = (from c in this.lt_m select c).FirstOrDefault(); ;
            
            string html_msg = "";
            
            string vname = rr.Firstname ;

            html_msg = "Dear " + vname + "<br/>";

            html_msg = html_msg + "This is to notify you that your application " + bb.product_title + " with file no " + bb.reg_no + " and online id " + bb.oai_no + " has been cleared from opposition and Trademark Registration certificate is now ready for collection. <br/>";

            html_msg = html_msg + "You are required to pay the stipulated fees on your agent platform and submit the online forms for collection of the Trademark Registration Certificate. <br/> ";


            html_msg = html_msg + "Kindly contact Customer support for more information. <br/> <br/>";

            html_msg = html_msg + "Online Team <br/>";


            html_msg = html_msg + "Trademarks, Patents and Designs Registry <br/>";

            html_msg = html_msg + "Commercial law department <br/>";

            html_msg = html_msg + "FMITI <br/>";

          //  Email pp = new Email();

        //   pp.sendMail("PAYX ALERT", "ozotony@yahoo.com", "admin@xpay.com", "Trademark Application notification", html_msg, "");


            sendemail(rr.Email, html_msg);


        }


        public void sendemail(string vemail, String ss)
        {
            try
            {
                int port = 0x24b;


                MailMessage mail = new MailMessage();
                mail.From =
           new MailAddress("paymentsupport@einaosolutions.com", "TRADEMARK ALERT");
                // new MailAddress("tradeservices@fsdhgroup.com");
                mail.Priority = MailPriority.High;

                mail.To.Add(
    new MailAddress(vemail));

                //    new MailAddress("ozotony@yahoo.com"));



                //mail.CC.Add(new MailAddress("Anthony.Ozoagu@firstcitygroup.com"));

                mail.Subject = "Trademark Application notification";

                mail.IsBodyHtml = true;
                //String ss2 = "Dear " + vcompany + ",<br/> <br/>" + " Thank you for completing the accreditation form for Agents of Trademarks, Patents and Designs Registry<br/>";
                //ss2 = ss2 + "To gain access to your account, you would need to click here (http://ipo.cldng.com/a_login.aspx) to validate your account " + "<br/>";
                //ss2 = ss2 + "Please keep your password safe and do not share your log in details with anyone. You may change your password at your convenience. In the event that you cannot remember your password, kindly follow the instructions provided for password recovery." + "<br/>";
                //ss2 = ss2 + "Please do not reply this mail" + "<br/><br/>";
                //ss2 = ss2 + "Email: info@iponigeria.com or go online to use our live feedback form .<br/><br/>";

                //String ss = "<html> <head> </head> <body>" + ss2 + "</body> </html>";

                //  mail.Body = ss;

                mail.Body = ss;

                SmtpClient client = new SmtpClient("88.150.164.30");
                //  SmtpClient client = new SmtpClient("192.168.0.12");

                client.Port = port;

                client.Credentials = new System.Net.NetworkCredential("paymentsupport@einaosolutions.com", "Zues.4102.Hector");



                //   new System.Net.NetworkCredential("ebusiness@firstcitygroup.com", "welcome@123");
                //   new System.Net.NetworkCredential(q60.smtp_user, q60.smtp_password);







                client.Send(mail);

            }
            catch (Exception ee)
            {


            }



        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> fulltext = new List<string>();
            string str = this.kword.Value.Replace("'", "");
            this.dateFrom = this.z.formatSearchDate(this.datepickerFrom.Value);
            this.dateTo = this.z.formatSearchDate(this.datepickerTo.Value);
            if ((this.dateTo == "") || (this.dateTo == null))
            {
                this.dateTo = DateTime.Today.Date.ToString("yyyy-MM-dd");
            }
            foreach (string str2 in str.Split(new char[] { ' ' }))
            {
                if (str2 != "")
                {
                    fulltext.Add(str2);
                }
            }
            if (this.selectSearchCriteria.SelectedValue == "product_title")
            {
                this.lt_m = this.z.getNewAdminSearchMarkInfoRS(this.stage, this.data_status, this.selectSearchCriteria.SelectedValue, fulltext, this.dateFrom, this.dateTo);
                if (this.lt_m.Count<XObjs.Office_view>() > 0)
                {
                    this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
                    this.Session["lt_m"] = this.lt_m;
                    this.gvX.DataSource = this.lt_m;
                    this.gvX.DataBind();
                    this.criteria = string.Concat(new object[] { this.lt_m.Count<XObjs.Office_view>(), " result(s) found for search criteria (", this.kword.Value, ")!!" });
                }
                else
                {
                    this.criteria = "No result found for search criteria (" + this.kword.Value + ")!!";
                }
            }
            else if (fulltext.Count<string>() == 1)
            {
                this.lt_m = this.z.getNewAdminSearchMarkInfoRS(this.stage, this.data_status, this.selectSearchCriteria.SelectedValue, fulltext, this.dateFrom, this.dateTo);
                if (this.lt_m.Count<XObjs.Office_view>() > 0)
                {
                    this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
                    this.Session["lt_m"] = this.lt_m;
                    this.gvX.DataSource = this.lt_m;
                    this.gvX.DataBind();
                    this.criteria = string.Concat(new object[] { this.lt_m.Count<XObjs.Office_view>(), " result(s) found for search criteria (", this.kword.Value, ")!!" });
                }
                else
                {
                    this.criteria = "No result found for search criteria (" + this.kword.Value + ")!!";
                }
            }
            else
            {
                this.criteria = "The Application number cannot be more one (1) !!";
            }
        }

        protected void gvX_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvX.PageIndex = e.NewPageIndex;
            if (this.Session["lt_m2"] != null)
            {
                DataView sortedView = (DataView)this.Session["lt_m2"];
                this.gvX.DataSource = sortedView;
                this.gvX.DataBind();

            }
            else  if (this.Session["lt_m"] != null)
            {
                this.lt_m.Clear();
                this.lt_m = (List<XObjs.Office_view>)this.Session["lt_m"];
            
            this.gvX.DataSource = this.lt_m;
            this.gvX.DataBind();
            }
            if (this.Session["x_cnt"] != null)
            {
                this.x_cnt = Convert.ToInt32(this.Session["x_cnt"]);
            }
        }

        protected void gvX_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "TmViewClick")
            {
                GridViewRow namingContainer = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                int rowIndex = namingContainer.RowIndex;
                string str = e.CommandArgument.ToString();
                base.Response.Redirect("opposition_data_detailsx.aspx?x=" + str);
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["pwalletID"] != null) && (this.Session["pwalletID"].ToString() != ""))
            {
                this.admin = this.Session["pwalletID"].ToString();
            }
            else
            {
                base.Response.Redirect("./xcontrol.aspx");
            }
            this.max = Convert.ToInt32(ConfigurationManager.AppSettings["o_unit_limit"]);
            if (!base.IsPostBack)
            {
                //this.gvX.PageSize = 100;
                //this.Session["lt_m"] = null;
                //this.Session["x_cnt"] = null;
                //this.lt_m = this.z.getNew_MarkInfoRSX(this.stage, this.data_status, 0, this.max);
                //this.Session["x_cnt"] = this.x_cnt = this.lt_m.Count;
                //this.Session["lt_m"] = this.lt_m;
                //this.gvX.DataSource = this.lt_m;
                //this.gvX.DataBind();
                //this.Session["lt_m2"] = null;
            }
            else if (this.Session["x_cnt"] != null)
            {
                this.x_cnt = Convert.ToInt32(this.Session["x_cnt"]);
            }
        }

            public SortDirection dir
    {
        get
        {
            if (ViewState["dirState"] == null)
            {
                ViewState["dirState"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["dirState"];
        } 
        set
        {
            ViewState["dirState"] = value;
        }
 
    }




            private static DataTable ConvertToDatatable<T>(List<T> data)
            {
                PropertyDescriptorCollection props =
                    TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                    else
                        table.Columns.Add(prop.Name, prop.PropertyType);
                }
                object[] values = new object[props.Count];
                foreach (T item in data)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
                return table;
            }


          protected void gvEmployee_Sorting(object sender, GridViewSortEventArgs e)
    {
       // BindData();
        if (this.Session["lt_m"] != null)
        {
            this.lt_m =(List<XObjs.Office_view>) this.Session["lt_m"];
            this.gvX.DataSource = this.lt_m;
            this.gvX.DataBind();

        }
        DataTable dt = new DataTable();

        dt = ConvertToDatatable(this.lt_m);
        {
            string SortDir = string.Empty;
            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                SortDir = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                SortDir = "Asc";
            }
            DataView sortedView = new DataView(dt);
            sortedView.Sort = e.SortExpression + " " + SortDir;
            this.gvX.DataSource = sortedView;
            this.gvX.DataBind();

            

            this.Session["lt_m2"] = sortedView;
        }
    }
}
    }

   