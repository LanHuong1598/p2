namespace p2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("record")]
    public partial class record
    {
        [Key]
        public Guid code { get; set; }

        public string link { get; set; }

        public double? english { get; set; }

        public double? math { get; set; }

        public double? physics { get; set; }

        public double? chemistry { get; set; }

        public double? biology { get; set; }

        public double? geography { get; set; }

        public double? literature { get; set; }

        public double? history { get; set; }

        public double? foreign_language { get; set; }

        public double? civic_Education { get; set; }
    }
}
