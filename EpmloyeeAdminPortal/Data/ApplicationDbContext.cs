using EpmloyeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EpmloyeeAdminPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : 
            base(options) { }
        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Salary)
                      .HasPrecision(18, 4);

                entity.Property(e => e.Name)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(e => e.IsDeleted)
                      .HasDefaultValue(false);
            });
        }
    }
}
