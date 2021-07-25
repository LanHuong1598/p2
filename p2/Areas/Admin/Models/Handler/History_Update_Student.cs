using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2.Areas.Admin.Models.Handler
{
    public class History_Update_Student
    {
        public string name { get; set; }

        public string date_of_birth { get; set; }
        public string sex { get; set; }
        public string permanent_residence { get; set; }
        public string enrolment { get; set; }
        public float totalmark { get; set; }
        public string edit_by_ip { get; set; }
        public string action { get; set; }
        public string edit_by_user { get; set; }
        public DateTime? edit_date { get; set; }

    }
}