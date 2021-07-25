namespace p2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prestudent")]
    public partial class prestudent
    {
        [Key]
        public Guid code { get; set; }

        [StringLength(15)]
        public string identity_card { get; set; }

        public string name { get; set; }

        public string first_name { get; set; }

        public string middle_name { get; set; }

        public string last_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_of_birth { get; set; }

        public string place_of_birth { get; set; }

        [StringLength(10)]
        public string sex { get; set; }

        public string address { get; set; }

        [StringLength(15)]
        public string phone { get; set; }

        public string email { get; set; }

        [StringLength(10)]
        public string towncode { get; set; }

        [StringLength(10)]
        public string provincecode { get; set; }

        [StringLength(10)]
        public string districtcode { get; set; }

        public string image { get; set; }

        public Guid? record_10_1_code { get; set; }

        public Guid? record_10_2_code { get; set; }

        public Guid? record_11_1_code { get; set; }

        public Guid? record_11_2_code { get; set; }

        public Guid? record_12_1_code { get; set; }

        public Guid? record_12_2_code { get; set; }

        public string village { get; set; }

        public Guid? enrollment_code { get; set; }

        public Guid? statusmark_code { get; set; }

        public Guid? regionmark_code { get; set; }

        [StringLength(10)]
        public string ethnic { get; set; }

        public double? totalmark { get; set; }

        public int? region { get; set; }

        [StringLength(10)]
        public string armycheckid { get; set; }

        [StringLength(10)]
        public string candidateid { get; set; }

        public string school_address_10 { get; set; }

        public string school_address_11 { get; set; }

        public string school_address_12 { get; set; }

        public int? school_year { get; set; }

        [StringLength(20)]
        public string phone_of_parent { get; set; }

        public string name_of_receiver { get; set; }

        public int? active { get; set; }
    }
}
