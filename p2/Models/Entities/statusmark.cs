namespace p2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("statusmark")]
    public partial class statusmark
    {
        [Key]
        public Guid code { get; set; }

        public string codeview { get; set; }

        public string name { get; set; }

        public string describe { get; set; }

        public decimal? mark { get; set; }
    }
}
