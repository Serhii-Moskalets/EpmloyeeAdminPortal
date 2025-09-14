using EpmloyeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EpmloyeeAdminPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : 
            base(options) { }
        public DbSet<Employee> Employees { get; set; } = null!;
    }
}
