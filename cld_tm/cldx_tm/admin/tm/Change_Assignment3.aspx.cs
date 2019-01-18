using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm
{
    public partial class Change_Assignment3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Form["transID"] != null)
            {
                xname.Value = Convert.ToString(Request.Form["transID"]);
                Double vvv = (Convert.ToDouble(Request.Form["vamount"])) / 100;
                vamount.Value = Convert.ToString(vvv);
                vtranid.Value = Convert.ToString(Request.Form["vtranid"]);

                vtype.Value = Convert.ToString(Request.Form["vtype"]);

                if (Request.Form["vtype"] != null)
                {
                    vvv = (Convert.ToDouble(Request.Form["vamount"]));
                    vamount.Value = Convert.ToString(vvv);

                }

            }
        }
    }
}