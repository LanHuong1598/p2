namespace p2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("region")]
    public partial class region
    {
        [Key]
        [StringLength(10)]
        public string code { get; set; }

        public string name { get; set; }

        public string describe { get; set; }
    }
}
