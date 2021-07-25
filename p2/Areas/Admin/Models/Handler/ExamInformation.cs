using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2.Areas.Admin.Models.Handler
{
    public class ExamInformation : SummaryInformation
    {
        public string room_id { get; set; }
        public string exam_id { get; set; }
        public double? total_mark { get; set; }

    }
}