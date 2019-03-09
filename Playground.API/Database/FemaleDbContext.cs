using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Playground.API.Database.Entities;
using Playground.Entity.Database;
using Playground.Entity.Database.Entities;

namespace Playground.API.Database
{
    public class FemaleDbContext : BaseDbContext
    {
        public override DbSet<Person> Person { get; set; }
        public DbSet<Female> Female { get; set; }

        public FemaleDbContext(DbContextOptions<FemaleDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Female>()
                .HasBaseType<Person>();
            
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entityEntry in this.ChangeTracker.Entries())
            {
                if (entityEntry.Entity is Person)
                    entityEntry.Property("Discriminator").CurrentValue = "Female";
            }

            return base.SaveChanges();
        }
    }
}
