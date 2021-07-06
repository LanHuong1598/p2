namespace p2.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<account_user> account_user { get; set; }
        public virtual DbSet<admission_group> admission_group { get; set; }
        public virtual DbSet<area> areas { get; set; }
        public virtual DbSet<area_object> area_object { get; set; }
        public virtual DbSet<imformation_user> imformation_user { get; set; }
        public virtual DbSet<priority_object> priority_object { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account_user>()
                .Property(e => e.email)
                .IsFixedLength();

            modelBuilder.Entity<area>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .Property(e => e.parent)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
