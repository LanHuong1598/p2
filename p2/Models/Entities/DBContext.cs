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

        public virtual DbSet<district> districts { get; set; }
        public virtual DbSet<enrollment> enrollments { get; set; }
        public virtual DbSet<history_update_student> history_update_student { get; set; }
        public virtual DbSet<prestudent> prestudents { get; set; }
        public virtual DbSet<province> provinces { get; set; }
        public virtual DbSet<record> records { get; set; }
        public virtual DbSet<region> regions { get; set; }
        public virtual DbSet<regionmark> regionmarks { get; set; }
        public virtual DbSet<staff> staffs { get; set; }
        public virtual DbSet<statusmark> statusmarks { get; set; }
        public virtual DbSet<town> towns { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<district>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<district>()
                .Property(e => e.provincecode)
                .IsUnicode(false);

            modelBuilder.Entity<enrollment>()
                .Property(e => e.codeview)
                .IsUnicode(false);

            modelBuilder.Entity<history_update_student>()
                .Property(e => e.identity_card)
                .IsUnicode(false);

            modelBuilder.Entity<history_update_student>()
                .Property(e => e.codeview)
                .IsUnicode(false);

            modelBuilder.Entity<history_update_student>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<history_update_student>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<history_update_student>()
                .Property(e => e.towncode)
                .IsUnicode(false);

            modelBuilder.Entity<history_update_student>()
                .Property(e => e.provincecode)
                .IsUnicode(false);

            modelBuilder.Entity<history_update_student>()
                .Property(e => e.districtcode)
                .IsUnicode(false);

            modelBuilder.Entity<history_update_student>()
                .Property(e => e.village)
                .IsUnicode(false);

            modelBuilder.Entity<history_update_student>()
                .Property(e => e.armycheckid)
                .IsUnicode(false);

            modelBuilder.Entity<history_update_student>()
                .Property(e => e.candidateid)
                .IsUnicode(false);

            modelBuilder.Entity<history_update_student>()
                .Property(e => e.edit_by_ip)
                .IsUnicode(false);

            modelBuilder.Entity<history_update_student>()
                .Property(e => e.student_id)
                .IsUnicode(false);

            modelBuilder.Entity<prestudent>()
                .Property(e => e.identity_card)
                .IsUnicode(false);

            modelBuilder.Entity<prestudent>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<prestudent>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<prestudent>()
                .Property(e => e.towncode)
                .IsUnicode(false);

            modelBuilder.Entity<prestudent>()
                .Property(e => e.provincecode)
                .IsUnicode(false);

            modelBuilder.Entity<prestudent>()
                .Property(e => e.districtcode)
                .IsUnicode(false);

            modelBuilder.Entity<prestudent>()
                .Property(e => e.armycheckid)
                .IsUnicode(false);

            modelBuilder.Entity<prestudent>()
                .Property(e => e.candidateid)
                .IsUnicode(false);

            modelBuilder.Entity<prestudent>()
                .Property(e => e.phone_of_parent)
                .IsUnicode(false);

            modelBuilder.Entity<province>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<region>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<regionmark>()
                .Property(e => e.codeview)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<statusmark>()
                .Property(e => e.codeview)
                .IsUnicode(false);

            modelBuilder.Entity<town>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<town>()
                .Property(e => e.districtcode)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.identity_card)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.phone)
                .IsUnicode(false);
        }
    }
}
