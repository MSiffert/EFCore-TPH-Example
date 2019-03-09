using System;
using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Female>().HasBaseType<Person>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
