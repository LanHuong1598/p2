namespace p2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("province")]
    public partial class province
    {
        [Key]
        [StringLength(10)]
        public string code { get; set; }

        public string name { get; set; }

        public string describe { get; set; }

        public int? regioncode { get; set; }
    }
}
