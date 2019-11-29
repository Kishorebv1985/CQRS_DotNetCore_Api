using CQRS_Assignment.Service.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Assignment.Repository
{
    public class EmployeeContext : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }

        public EmployeeContext(DbContextOptions options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeeEntity>().HasData(new EmployeeEntity() { Id = 1, Name = "Kishore", Department = "Engineering" });
        }
    }
}
