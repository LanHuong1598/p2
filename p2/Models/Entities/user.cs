namespace p2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        [Key]
        public Guid code { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        public string password { get; set; }

        public Guid? prestudent_code { get; set; }

        [StringLength(20)]
        public string identity_card { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string address { get; set; }
    }
}
