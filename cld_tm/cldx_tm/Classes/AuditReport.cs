using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cld.Classes
{
    public class AuditReport
    {
        public string transactionid { get; set; }
        public string username { get; set; }
        public string logdate { get; set; }
        public string operation { get; set; }
        public string module { get; set; }
        public string status { get; set; }
        public string oldtitle{ get; set; }
        public string newtitle { get; set; }
        public string oldclass { get; set; }
        public string newclass { get; set; }
        public string oldapplicantname { get; set; }
        public string newapplicantname { get; set; }
    }
}