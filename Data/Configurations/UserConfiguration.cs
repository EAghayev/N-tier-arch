using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                  .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .UseIdentityColumn();

            builder
               .Property(m => m.Status)
               .IsRequired()
               .HasDefaultValue(true);

            builder
              .Property(m => m.ModifiedBy)
              .HasMaxLength(100);

            builder
               .Property(m => m.AddedBy)
               .HasMaxLength(100);


            builder
               .Property(m => m.Fullname)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(m => m.Email)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(m => m.Password)
               .IsRequired()
               .HasMaxLength(100);

            builder
               .Property(m => m.Token)
               .HasMaxLength(50);

            builder
                .ToTable("Users");
        }
    }
}
