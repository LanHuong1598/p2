namespace p2.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class area_object
    {
        public int id { get; set; }

        public string name { get; set; }

        public string describe { get; set; }

        public double? mark { get; set; }
    }
}
