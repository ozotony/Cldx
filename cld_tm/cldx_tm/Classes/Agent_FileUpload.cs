using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cld.Classes
{
    public class Agent_FileUpload
    {
        public string agent_code { get; set; }
        public string old_file { get; set; }
        public string new_file { get; set; }

        public DateTime Date_Uploaded { get; set; }

        public string Status { get; set; }

        public string pt_id { get; set; }
    }
}