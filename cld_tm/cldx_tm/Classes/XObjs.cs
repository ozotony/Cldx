using System;

namespace cld.Classes
{
    public class XObjs
    {
        public string formatDate(string date)
        {
            if ((date == "") || (date == null))
            {
                date = DateTime.Today.Date.ToString("MM/dd/yyyy");
            }
            string str = "";
            string str2 = date.Substring(0, 2);
            string str3 = date.Substring(3, 2);
            str = date.Substring(6, 4);
            return (str + "-" + str2 + "-" + str3);
        }

        public string formatSearchDate(string date)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            if (date != "")
            {
                str = "";
                str2 = date.Substring(0, 2);
                str3 = date.Substring(3, 2);
                str = date.Substring(6, 4);
                str4 = str + "-" + str2 + "-" + str3;
            }
            return str4;
        }

        public class Address
        {
            public string city { get; set; }

            public string countryID { get; set; }

            public string email1 { get; set; }

            public string email2 { get; set; }

            public string ID { get; set; }

            public string lgaID { get; set; }

            public string log_staff { get; set; }

            public string reg_date { get; set; }

            public string stateID { get; set; }

            public string street { get; set; }

            public string telephone1 { get; set; }

            public string telephone2 { get; set; }

            public string visible { get; set; }

            public string xsync { get; set; }

            public string zip { get; set; }
        }

        public class Fee_details
        {
            public string fee_listID { get; set; }

            public string init_amt { get; set; }

            public string tech_amt { get; set; }

            public string tot_amt { get; set; }

            public string twalletID { get; set; }

            public string xid { get; set; }

            public string xlogstaff { get; set; }

            public string xqty { get; set; }

            public string xreg_date { get; set; }

            public string xsync { get; set; }

            public string xused { get; set; }

            public string xvisible { get; set; }
        }

        public class Fee_list
        {
            public string init_amt { get; set; }

            public string item { get; set; }

            public string item_code { get; set; }

            public string tech_amt { get; set; }

            public string xcategory { get; set; }

            public string xdesc { get; set; }

            public string xid { get; set; }

            public string xlogstaff { get; set; }

            public string xreg_date { get; set; }

            public string xsync { get; set; }

            public string xvisible { get; set; }
        }

        public class G_Admin_info
        {
            public string application_no { get; set; }

            public string filing_date { get; set; }

            public string id { get; set; }

            public string item_code { get; set; }

            public string log_staff { get; set; }

            public string reg_date { get; set; }

            public string reg_no { get; set; }

            public string rtm_number { get; set; }

            public string visible { get; set; }

            public string xname { get; set; }
        }

        public class G_Agent_info
        {
            public string addressID { get; set; }

            public string cname { get; set; }

            public string nationality { get; set; }

            public string sys_ID { get; set; }

            public string xid { get; set; }

            public string xname { get; set; }

            public string xpassword { get; set; }

            public string xreg_date { get; set; }

            public string xsync { get; set; }

            public string xvisible { get; set; }
        }

        public class G_App_info
        {
            public string application_no { get; set; }

            public string filing_date { get; set; }

            public string id { get; set; }

            public string item_code { get; set; }

            public string log_staff { get; set; }

            public string oai_no { get; set; }

            public string reg_date { get; set; }

            public string reg_no { get; set; }

            public string req_type { get; set; }

            public string rtm_number { get; set; }

            public string tm_title { get; set; }

            public string visible { get; set; }

            public string xclass { get; set; }

            public string xname { get; set; }

            public string xstat { get; set; }

            public string Sn { get; set; }

            public string Agent_Code { get; set; }

            public string description { get; set; }
        }

        public class G_Applicant_info
        {
            public string address { get; set; }

            public string id { get; set; }

            public string log_staff { get; set; }

            public string nationality { get; set; }

            public string trading_as { get; set; }

            public string visible { get; set; }

            public string xemail { get; set; }

            public string xmobile { get; set; }

            public string xname { get; set; }
        }

        public class G_Ass_info
        {
            public string ass_doc { get; set; }

            public string assignee_address { get; set; }

            public string assignee_name { get; set; }

            public string assignee_nationality { get; set; }

            public string assignor_address { get; set; }

            public string assignor_name { get; set; }

            public string assignor_nationality { get; set; }

            public string date_of_assignment { get; set; }

            public string log_staff { get; set; }

            public string xid { get; set; }

            public string xvisible { get; set; }
        }

        public class G_Cert_info
        {
            public string cert_doc { get; set; }

            public string log_staff { get; set; }

            public string pub_date { get; set; }

            public string pub_details { get; set; }

            public string pub_doc { get; set; }

            public string reg_date { get; set; }

            public string xid { get; set; }

            public string xvisible { get; set; }
        }

        public class G_Change_info
        {
            public string log_staff { get; set; }

            public string new_address { get; set; }

            public string new_goods { get; set; }

            public string new_name { get; set; }

            public string new_tm_class { get; set; }

            public string old_address { get; set; }

            public string old_goods { get; set; }

            public string old_name { get; set; }

            public string old_tm_class { get; set; }

            public string reg_date { get; set; }

            public string visible { get; set; }

            public string xid { get; set; }
        }

        public class G_Merger_info
        {
            public string log_staff { get; set; }

            public string merged_coy_name { get; set; }

            public string merger_date { get; set; }

            public string merger_doc { get; set; }

            public string merging_address { get; set; }

            public string merging_name { get; set; }

            public string original_address { get; set; }

            public string original_name { get; set; }

            public string visible { get; set; }

            public string xid { get; set; }
        }

        public class G_Other_items_info
        {
            public string log_staff { get; set; }

            public string reg_date { get; set; }

            public string req_details { get; set; }

            public string visible { get; set; }

            public string xid { get; set; }
        }

        public class G_Prelim_search_info
        {
            public string log_staff { get; set; }

            public string reg_date { get; set; }

            public string visible { get; set; }

            public string xclass { get; set; }

            public string xclass_desc { get; set; }

            public string xid { get; set; }

            public string xtitle { get; set; }
        }

        public class G_Pwallet
        {
            public string amt { get; set; }

            public string applicantID { get; set; }

            public string data_status { get; set; }

            public string log_officer { get; set; }

            public string reg_date { get; set; }

            public string stage { get; set; }

            public string status { get; set; }

            public string twalletID { get; set; }

            public string validationID { get; set; }

            public string visible { get; set; }

            public string xid { get; set; }
        }

        public class G_Renewal_info
        {
            public string log_staff { get; set; }

            public string prev_renewal_date { get; set; }

            public string reg_date { get; set; }

            public string renewal_type { get; set; }

            public string visible { get; set; }

            public string xid { get; set; }
        }

        public class G_Tm_info
        {
            public string app_letter_doc { get; set; }

            public string auth_doc { get; set; }

            public string disclaimer { get; set; }

            public string log_staff { get; set; }

            public string logo_descID { get; set; }

            public string logo_pic { get; set; }

            public string reg_date { get; set; }

            public string reg_number { get; set; }

            public string sup_doc1 { get; set; }

            public string tm_class { get; set; }

            public string tm_desc { get; set; }

            public string tm_title { get; set; }

            public string visible { get; set; }

            public string xid { get; set; }

            public string xtype { get; set; }
        }

        public class Gen_Agent_info
        {
            public string address { get; set; }

            public string code { get; set; }

            public string country { get; set; }

            public string email { get; set; }

            public string log_staff { get; set; }

            public string nationality { get; set; }

            public string state { get; set; }

            public string telephone { get; set; }

            public string xid { get; set; }

            public string xname { get; set; }

            public string xpassword { get; set; }

            public string xsync { get; set; }
        }

        public class Hwallet
        {
            public string fee_detailsID { get; set; }

            public string product_title { get; set; }

            public string transID { get; set; }

            public string used_date { get; set; }

            public string used_status { get; set; }

            public string xid { get; set; }

            public string xreg_date { get; set; }
        }

        public class Office_view
        {
            public string applicant_name { get; set; }

            public string log_staff { get; set; }

            public string logo_pic { get; set; }

            public string id2 { get; set; }

            public string oai_no { get; set; }

            public string product_title { get; set; }

            public string reg_dt { get; set; }

            public string reg_no { get; set; }

            public string rtm { get; set; }

            public string scmt { get; set; }

            public string tm_type { get; set; }

            public string xclass { get; set; }

            public string xid { get; set; }

            public string AcceptanceDate { get; set; }
            public string id { get; set; }

            public string xstat { get; set; }

            public string batches { get; set; }
            
            public string applicantID { get; set; }
            public string Office { get; set; }

            public string Sn { get; set; }

            public string TransactionId { get; set; }

            public string TransactionId2 { get; set; }

            public string Street { get; set; }

            public string CountryID { get; set; }

            public string AmendmentStatus { get; set; }

            public string RecordalID { get; set; }

            public string RECORDAL_TYPE { get; set; }

            public string RECORDAL_TYPE2 { get; set; }

            public string RECORDAL_STATUS { get; set; }
            public string Agent_Code { get; set; }

            public string Agent_Name { get; set; }

         

            public string Xaddress { get; set; }

            public string Xemail { get; set; }

            public string Xmobile { get; set; }


            public string moveapp { get; set; }

            public string description { get; set; }


            public string comments { get; set; }

            public int  Duration { get; set; }

            public string acc_p { get; set; }


        }


        public class Office_view2
        {
            public string applicant_name { get; set; }

          

            public string oai_no { get; set; }

            public string product_title { get; set; }

          

            public string File_no { get; set; }


            public string reg_dt { get; set; }


            public string RecordalID { get; set; }


            public string xclass { get; set; }



            public string RECORDAL_TYPE { get; set; }

            public string Sn { get; set; }

         


            //public string RECORDAL_TYPE { get; set; }

            public string RECORDAL_TYPE2 { get; set; }

            public string RECORDAL_STATUS { get; set; }

            public string   Approval_Date { get; set; }





        }


        public class P_ratio
        {
            public string p_type { get; set; }

            public string r_type { get; set; }

            public string xid { get; set; }

            public string xpartnerID { get; set; }

            public string xratio { get; set; }

            public string xreg_date { get; set; }

            public string xsync { get; set; }

            public string xvisible { get; set; }
        }

        public class Pwallet
        {
            public string reg_date { get; set; }

            public string xemail { get; set; }

            public string xid { get; set; }

            public string xmemberID { get; set; }

            public string xmembertype { get; set; }

            public string xmobile { get; set; }

            public string xpass { get; set; }

            public string data_status { get; set; }

            public string status { get; set; }
        }

        public class Scard
        {
            public string xid { get; set; }

            public string xlogstaff { get; set; }

            public string xnum { get; set; }

            public string xreg_date { get; set; }

            public string xsync { get; set; }

            public string xvalid { get; set; }

            public string xvisible { get; set; }
        }

        public class Shopping_card
        {
            public double amt { get; set; }

            public string item_code { get; set; }

            public string qty { get; set; }

            public double total_amt { get; set; }

            public string xid { get; set; }
        }

        public class Trademark_item
        {
            public string amt { get; set; }

            public string applicant_name { get; set; }

            public string hwalletID { get; set; }

            public string item_code { get; set; }

            public string product_title { get; set; }

            public string request_type { get; set; }

            public string transID { get; set; }

            public string xgt { get; set; }

            public string xmemberID { get; set; }
        }

        public class Twallet
        {
            public string ref_no { get; set; }

            public string transID { get; set; }

            public string xbankerID { get; set; }

            public string xgt { get; set; }

            public string xid { get; set; }

            public string xmemberID { get; set; }

            public string xpay_status { get; set; }

            public string xreg_date { get; set; }

            public string xsync { get; set; }

            public string xvisible { get; set; }

            public string tot_amt { get; set; }
        }

        public class XBanker
        {
            public string addressID { get; set; }

            public string bankname { get; set; }

            public string nationality { get; set; }

            public string sys_ID { get; set; }

            public string xid { get; set; }

            public string xname { get; set; }

            public string xpassword { get; set; }

            public string xposition { get; set; }

            public string xreg_date { get; set; }

            public string xsync { get; set; }

            public string xvisible { get; set; }
        }

        public class XMember
        {
            public string addressID { get; set; }

            public string cname { get; set; }

            public string nationality { get; set; }

            public string sys_ID { get; set; }

            public string xid { get; set; }

            public string xname { get; set; }

            public string xpassword { get; set; }

            public string xreg_date { get; set; }

            public string xsync { get; set; }

            public string xvisible { get; set; }
        }

        public class XPartner
        {
            public string addressID { get; set; }

            public string cname { get; set; }

            public string nationality { get; set; }

            public string sys_ID { get; set; }

            public string xid { get; set; }

            public string xname { get; set; }

            public string xpassword { get; set; }

            public string xreg_date { get; set; }

            public string xsync { get; set; }

            public string xvisible { get; set; }
        }

        public class Registration
        {
            public string xid { get; set; }
            public string AccrediationType { get; set; }
            public string Sys_ID { get; set; }
            public string Firstname { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string xpassword { get; set; }
            public string DateOfBrith { get; set; }
            public string IncorporatedDate { get; set; }
            public string Nationality { get; set; }
            public string PhoneNumber { get; set; }
            public string CompanyName { get; set; }
            public string CompanyAddress { get; set; }
            public string ContactPerson { get; set; }
            public string ContactPersonPhone { get; set; }
            public string CompanyWebsite { get; set; }
            public string Certificate { get; set; }
            public string Introduction { get; set; }
            public string Principal { get; set; }
            public string logo { get; set; }
            public string xreg_date { get; set; }
            public string xstatus { get; set; }
            public string xvisible { get; set; }
            public string xsync { get; set; }
        }

        public class Subagent
        {
            public string xid { get; set; }
            public string RegistrationID { get; set; }
            public string Firstname { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string xpassword { get; set; }
            public string Telephone { get; set; }
            public string DateOfBrith { get; set; }
            public string AssignID { get; set; }
            public string Sys_ID { get; set; }
            public string Address { get; set; }
            public string AgentPassport { get; set; }
            public string xreg_date { get; set; }
            public string xstatus { get; set; }
            public string xvisible { get; set; }
            public string xsync { get; set; }
        }

    }
}