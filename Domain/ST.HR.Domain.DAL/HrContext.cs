using Microsoft.EntityFrameworkCore;
using ST.HR.Domain.DAL.Init;
using ST.HR.Domain.Entities;

namespace ST.HR.Domain.DAL
{
    public class HrContext : DbContext
    {
        public HrContext(DbContextOptions<HrContext> options) : base(options)
        {
        }
        
        public HrContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            
            optionsBuilder.UseSqlite("DataSource=/home/user/RiderProjects/ST.HR/UI/ST.HR.UI/app.db", 
                b => b.MigrationsAssembly("ST.HR.Domain.DAL"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasData(EmployeeInitData.Get());
            
            modelBuilder.Entity<SalaryRule>()
                .HasData(SalaryRuleInitData.Get());
        }

        public virtual DbSet<Employee> Employees { get; set; }
        
        public virtual DbSet<SalaryRule> SalaryRules { get; set; }
    }
}
