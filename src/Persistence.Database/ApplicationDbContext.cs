using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;
using Persistence.Database.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TblAdn> TblAdn { get; set; }
      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Database schema
            // builder.HasDefaultSchema("genetic");
            ModelConfig(builder);
        }


        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new TblAdnConfiguration(modelBuilder.Entity<TblAdn>());
        }
    }
}
