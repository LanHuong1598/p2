namespace p2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("district")]
    public partial class district
    {
        [Key]
        [StringLength(50)]
        public string code { get; set; }

        public string name { get; set; }

        public string describe { get; set; }

        [StringLength(50)]
        public string provincecode { get; set; }
    }
}
