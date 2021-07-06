namespace p2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class account_user
    {
        [StringLength(15)]
        public string id { get; set; }

        public string name { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(50)]
        public string password { get; set; }
    }
}
