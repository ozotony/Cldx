using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static cld.Classes.zues;

namespace cld.Classes
{
    public class Cards
    {
        public MarkInfo MarkInfo { get;set; }

        public tm.Address lt_addy { get; set; }

        public tm.AddressService AddressService { get; set; }

        public tm.Applicant Applicant { get; set; }

        public zues.Pwallet Pwallet { get; set; }

        public tm.Representative Representative { get; set; }

        public tm.Address lt_rep_addy { get; set; }

        public tm.Stage lt_stage { get; set; }

        public zues.TmOffice lt_tm_office { get; set; }

        public string AcceptanceDate { get; set; }
    }
}