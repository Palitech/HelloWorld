using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Data
{
    public class DataContextEF : DbContext 
    {
        public DbSet<Computer>? Computer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection = true;",
                    options => options.EnableRetryOnFailure());
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");
            modelBuilder.Entity<Computer>()
                //.HasNoKey();
                .HasKey(c => c.ComputerId);

                //.ToTable("TableName", "SchemaName");
        }


    }
}
