using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm
{
    public partial class Change_ApplicantAgent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["transID"] != null)
            {
                xname.Value = Convert.ToString(Request.Form["transID"]);
                xname2.Value = Convert.ToString(Request.Form["xname"]);
                xaddress.Value = Convert.ToString(Request.Form["xaddress"]);
                xemail.Value = Convert.ToString(Request.Form["xemail"]);
                xPhoneNumber.Value = Convert.ToString(Request.Form["xPhoneNumber"]);
                Int32 vvv = (Convert.ToInt32(Request.Form["vamount"])) / 100;
                vamount.Value = Convert.ToString(vvv);
                vtranid.Value = Convert.ToString(Request.Form["vtranid"]);

                xpwalletID.Value= Convert.ToString(Request.Form["xpwalletID"]);

            }

        }
    }
}