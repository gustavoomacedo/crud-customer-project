using CustomerProject.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CustomerProject.Infra.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(255)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(255)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Phone)
                .HasColumnType("varchar(255)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.BirthDate)
                .HasColumnType("datetime")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
