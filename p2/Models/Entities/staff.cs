namespace p2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("staff")]
    public partial class staff
    {
        [Key]
        public Guid code { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string name { get; set; }

        [StringLength(15)]
        public string phone { get; set; }
    }
}
