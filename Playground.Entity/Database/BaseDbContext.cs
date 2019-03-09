using Microsoft.EntityFrameworkCore;
using Playground.Entity.Database.Entities;

namespace Playground.Entity.Database
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<House> House { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person", "dbo");
            modelBuilder.Entity<House>().ToTable("House", "dbo");

            modelBuilder.Entity<Person>().HasOne(e => e.House).WithMany(e => e.Persons);
            modelBuilder.Entity<House>().HasMany(e => e.Persons).WithOne(e => e.House);
        }
    }
}
