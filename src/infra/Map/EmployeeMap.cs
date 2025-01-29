using domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infra.Map;

internal class EmployeeMap : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");

        builder.Property(c => c.Id).ValueGeneratedOnAdd()
               .HasColumnName("Id");
        
        builder.Property(c => c.Name)
            .HasColumnName("BirthDate");
        
        builder.Property(c => c.Email)
            .HasColumnName("Email");

        builder.Property(c => c.DocumentNumber)
            .HasColumnName("DocumentNumber");

        builder.Property(c => c.Phone)
            .HasColumnName("Phone");
        
        builder.Property(c => c.Address)
            .HasColumnName("Address");
        
        builder.Property(c => c.AddressNumber)
            .HasColumnName("AddressNumber");
        
        builder.Property(c => c.City)
            .HasColumnName("City");
        
           builder.Property(c => c.State)
            .HasColumnName("State");
           
           builder.Property(c => c.Zip)
               .HasColumnName("Zip");
           
           builder.Property(c => c.ManagerName)
               .HasColumnName("ManagerName");

    }
}