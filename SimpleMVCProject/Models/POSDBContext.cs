using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleMVCProject.Models
{
    public class POSDBContext: DbContext
    {
        public POSDBContext():base("name=MainConnection")
        {
            Database.SetInitializer<POSDBContext>(null);
        }

        //Create Table
        public DbSet<StudentModel> Students { get; set; }

        public DbSet<ContactUsModel> ContactUs { get; set; }

        public DbSet<CityModel> Cities { get; set; }

        public DbSet<TownshipModel> Townships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentModel>().ToTable("Student");
            modelBuilder.Entity<CityModel>().ToTable("City");
            modelBuilder.Entity<TownshipModel>().ToTable("Township");
        }

    }
}