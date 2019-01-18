using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.admin;
using cld.Classes;



namespace cld
{
    public partial class corr_pwall : System.Web.UI.Page
    {
        zues z = new zues(); tm t = new tm();
        List<zues.Pwallet> lt_p = new List<zues.Pwallet>();
        List<zues.TmOffice> lt_tm_office = new List<zues.TmOffice>();
        protected void Page_Load(object sender, EventArgs e)
        {
            lt_p = z.getprintedPwalletIDs();
            foreach(zues.Pwallet p in lt_p)
            {
                zues.TmOffice c_tm_office = new zues.TmOffice();
                c_tm_office = z.getLastTmOfficeByID(p.ID);
                lt_tm_office.Add(c_tm_office);
            }

            foreach (zues.TmOffice tt in lt_tm_office)
            {
                z.updatePrintedPwallet(tt);
            }

        }
    }
}