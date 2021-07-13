namespace p2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class limit_candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int female_south { get; set; }

        public int? female_north { get; set; }

        public int? male_south { get; set; }

        public int? male_north { get; set; }
    }
}
