using domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infra.Map;

public class EmployeeContactMap: IEntityTypeConfiguration<EmployeeContact>
{
    public void Configure(EntityTypeBuilder<EmployeeContact> builder)
    {
        builder.ToTable("EmployeeContact");

        builder.Property(c => c.Id).ValueGeneratedOnAdd()
            .HasColumnName("Id");
        
        builder.Property(c => c.EmployeeId)
            .HasColumnName("EmployeeId");
        
        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(20)
            .HasColumnName("PhoneNumber");
        
        builder.Property(c => c.ContactName)
            .HasMaxLength(150)
            .HasColumnName("ContactName");
        
        builder.HasOne(c => c.Employee)
            .WithMany(e => e.Contacts)
            .HasForeignKey(c => c.EmployeeId);
    }

}