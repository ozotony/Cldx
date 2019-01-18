using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cld.Classes
{
    public class AppealUpload
    {
        public int id { get; set; }
        public string  DocumentId { get; set; }
        public string RegId { get; set; }
        public string Comment { get; set; }
        public string agentid { get; set; }
        public string DateUploaded { get; set; }
        public string FilePath { get; set; }
        public string Status { get; set; }
        public string ApproveBy { get; set; }
        public string DateApproved { get; set; }
    }
}