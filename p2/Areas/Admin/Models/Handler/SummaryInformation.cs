using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2.Areas.Admin.Models.Handler
{
    public class SummaryInformation
    {
        public string name { get; set; }

        public string date_of_birth { get; set; }
        public string sex { get; set; }
        public string permanent_residence { get; set; }
        public string admission_group { get; set; }
    }
}