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
        public virtual DbSet<limit_candidate> limit_candidate { get; set; }
        public virtual DbSet<priority_object> priority_object { get; set; }
        public virtual DbSet<room> rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account_user>()
                .Property(e => e.email)
                .IsFixedLength();

            modelBuilder.Entity<area>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .Property(e => e.parent)
                .IsUnicode(false);

            modelBuilder.Entity<imformation_user>()
                .Property(e => e.permanent_residence)
                .IsUnicode(false);

            modelBuilder.Entity<imformation_user>()
                .Property(e => e.place_of_study_10)
                .IsUnicode(false);

            modelBuilder.Entity<imformation_user>()
                .Property(e => e.place_of_study_11)
                .IsUnicode(false);

            modelBuilder.Entity<imformation_user>()
                .Property(e => e.place_of_study_12)
                .IsUnicode(false);

            modelBuilder.Entity<imformation_user>()
                .Property(e => e.area)
                .IsUnicode(false);

            modelBuilder.Entity<imformation_user>()
                .Property(e => e.exam_id)
                .IsUnicode(false);

            modelBuilder.Entity<imformation_user>()
                .Property(e => e.room_id)
                .IsFixedLength();

            modelBuilder.Entity<room>()
                .Property(e => e.name)
                .IsFixedLength();
        }
    }
}
