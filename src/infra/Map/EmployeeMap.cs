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
            .HasMaxLength(150)
            .HasColumnName("Email");

        builder.Property(c => c.DocumentNumber)
            .HasMaxLength(20)
            .HasColumnName("DocumentNumber");

        builder.Property(c => c.Phone)
            .HasMaxLength(15)
            .HasColumnName("Phone");
        
        builder.Property(c => c.Address)
            .HasMaxLength(250)
            .HasColumnName("Address");
        
        builder.Property(c => c.AddressNumber)
            .HasColumnName("AddressNumber");
        
        builder.Property(c => c.City)
            .HasMaxLength(100)
            .HasColumnName("City");
        
           builder.Property(c => c.State)
               .HasMaxLength(100)
            .HasColumnName("State");
           
           builder.Property(c => c.Zip)
               .HasMaxLength(10)
               .HasColumnName("Zip");
           
           builder.Property(c => c.ManagerName)
               .HasMaxLength(150)
               .HasColumnName("ManagerName");

    }
}