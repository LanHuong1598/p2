namespace p2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class imformation_user
    {
        [StringLength(15)]
        public string id { get; set; }

        public int? sex { get; set; }

        public DateTime? date_of_birth { get; set; }

        [StringLength(100)]
        public string place_of_birth { get; set; }

        [StringLength(50)]
        public string ethnic { get; set; }

        public string image { get; set; }

        public string email { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(20)]
        public string phone_of_parent { get; set; }

        public string name_of_receiver { get; set; }

        public string area_of_receiver { get; set; }

        [StringLength(20)]
        public string candidate_number { get; set; }

        public int? permanent_residence { get; set; }

        public int? enrollment_group { get; set; }

        public int? place_of_study { get; set; }

        public int? year_of_graduation { get; set; }

        public int? priority_object { get; set; }

        public int? area { get; set; }

        public double? math_10_1 { get; set; }

        public double? math_10_2 { get; set; }

        public double? math_11_1 { get; set; }

        public double? math_11_2 { get; set; }

        public double? math_12_1 { get; set; }

        public double? math_12_2 { get; set; }

        public double? physic_10_1 { get; set; }

        public double? physic_10_2 { get; set; }

        public double? physic_11_1 { get; set; }

        public double? physic_11_2 { get; set; }

        public double? physic_12_1 { get; set; }

        public double? physic_12_2 { get; set; }

        public double? chemistry_10_1 { get; set; }

        public double? chemistry_10_2 { get; set; }

        public double? chemistry_11_1 { get; set; }

        public double? chemistry_11_2 { get; set; }

        public double? chemistry_12_1 { get; set; }

        public double? chemistry_12_2 { get; set; }

        public double? english_10_1 { get; set; }

        public double? english_10_2 { get; set; }

        public double? english_11_1 { get; set; }

        public double? english_11_2 { get; set; }

        public double? english_12_1 { get; set; }

        public double? english_12_2 { get; set; }
    }
}
