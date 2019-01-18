using cld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

               // Encrypt3 pp = new Encrypt3();
           
                try
                {

                    var kk = Encrypt3.EncryptString("patATTAH3#", "patATTAH3#");
                    var kk2 = Encrypt3.DecryptString(kk, "patATTAH3#");
                    var pp = kk2;


                }
                catch(Exception ee)
                {
                    var kd = ee.Message;
                }

              
                //   string script = "document.getElementById('bgMark').style.background = \"url(\" + document.getElementById('"
                // + imgWaterMark.ClientID + "').src + \")  0 20  repeat \";";
                // if (ScriptManager.GetCurrent(this.Page) == null)
                //  Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "block", script, true);
                //else
                //   ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "block", script, true);
                //The watermark picture
                //  string ID = "test";
                // imgWaterMark.Src = ResolveUrl("~") + string.Format("Handlers/WaterMarks.ashx?id={0}", ID);
            }
        }
    }
}