using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2.Areas.Admin.Models.Handler
{
    public class Statistic_Student
    {
        public int? total { get; set; }
        public int? south_male { get; set; }
        public int? south_female { get; set; }
        public int? north_male { get; set; }
        public int? north_female { get; set; }
        public int? male { get; set; }
        public int? female { get; set; }
        public int? south_total { get; set; }
        public int? north_total { get; set; }
    }
}