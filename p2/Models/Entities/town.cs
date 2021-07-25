namespace p2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("town")]
    public partial class town
    {
        [Key]
        [StringLength(10)]
        public string code { get; set; }

        public string name { get; set; }

        public string describe { get; set; }

        [StringLength(10)]
        public string districtcode { get; set; }
    }
}
