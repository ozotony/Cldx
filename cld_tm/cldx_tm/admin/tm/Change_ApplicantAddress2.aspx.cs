using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm
{
    public partial class Change_ApplicantAddress2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["transID"] != null)
            {
                xname.Value = Request.QueryString["transID"];  //Convert.ToString(Request.Form["transID"]);
                // Int32 vvv = (Convert.ToInt32(Request.Form["vamount"])) / 100;
                // vamount.Value = Convert.ToString(vvv);
                vtranid.Value = Request.QueryString["vtranid"]; // Convert.ToString(Request.Form["vtranid"]);

            }

        }
    }
}