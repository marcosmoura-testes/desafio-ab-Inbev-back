using domain.Entity;
using infra.Map;
using Microsoft.EntityFrameworkCore;

namespace infra;

public class BaseContext: DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options)
        : base(options)
    {

    }
    
    public DbSet<Employee> Employee { get; set; }
    public DbSet<EmployeeContact> EmployeeContact { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeMap());
        modelBuilder.ApplyConfiguration(new EmployeeContactMap());
    }

}