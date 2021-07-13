namespace p2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("area")]
    public partial class area
    {
        [StringLength(50)]
        public string id { get; set; }

        public int? level { get; set; }

        public string name { get; set; }

        [StringLength(50)]
        public string parent { get; set; }

        public int? region { get; set; }
    }
}
