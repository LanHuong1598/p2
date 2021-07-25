using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2.Models.Entities;

namespace p2.Models.Handler
{
    public class SchoolRecord
    {
        public HttpPostedFileBase school_record_10_1 { get; set; }
        public HttpPostedFileBase school_record_10_2 { get; set; }
        public HttpPostedFileBase school_record_11_1 { get; set; }
        public HttpPostedFileBase school_record_11_2 { get; set; }
        public HttpPostedFileBase school_record_12_1 { get; set; }
        public HttpPostedFileBase school_record_12_2 { get; set; }
        public HttpPostedFileBase fileimage { get; set; }
        public float chemistry_10_1 { get; set; }
        public float math_10_1 { get; set; }
        public float physic_10_1 { get; set; }
        public float english_10_1 { get; set; }
        public float math_10_2 { get; set; }
        public float english_10_2 { get; set; }
        public float chemistry_10_2 { get; set; }
        public float physic_10_2 { get; set; }
        public float math_11_1 { get; set; }
        public float chemistry_11_1 { get; set; }
        public float english_11_1 { get; set; }
        public float physic_11_1 { get; set; }
        public float math_11_2 { get; set; }
        public float physic_11_2 { get; set; }
        public float chemistry_11_2 { get; set; }
        public float english_11_2 { get; set; } 
        public float math_12_1 { get; set; }
        public float chemistry_12_1 { get; set; }
        public float physic_12_1 { get; set; }
        public float english_12_1 { get; set; }
        public float math_12_2 { get; set; }
        public float chemistry_12_2 { get; set; }
        public float physic_12_2 { get; set; }
        public float english_12_2 { get; set; } 
    }
}