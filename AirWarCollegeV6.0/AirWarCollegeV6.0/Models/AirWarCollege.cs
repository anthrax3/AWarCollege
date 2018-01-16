namespace AirWarCollegeV6._0.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AirWarCollege : DbContext
    {
        public AirWarCollege()
            : base("name=AirWarCollege")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Alumnus> Alumni { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Commandant> Commandants { get; set; }
        public virtual DbSet<cyberAlert> cyberAlerts { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<Study_Material> Study_Materials { get; set; }
        public virtual DbSet<Synopsis> Synopsis { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
