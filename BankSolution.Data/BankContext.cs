using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BankSolution.Data
{
    public partial class BankContext : DbContext
    {
        public BankContext()
            : base("name=BankContext")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.States)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.State)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.State)
                .WillCascadeOnDelete(false);
        }
    }
}
