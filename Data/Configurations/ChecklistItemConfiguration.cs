using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ChecklistItemConfiguration : IEntityTypeConfiguration<ChecklistItem>
    {
        public void Configure(EntityTypeBuilder<ChecklistItem> builder)
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
                .HasOne(c => c.Checklist)
                .WithMany(c => c.ChecklistItems)
                .HasForeignKey(c => c.ChecklistId);

            builder
                .Property(c => c.IsDone)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(c => c.Content)
                .HasMaxLength(200)
                .IsRequired();

            builder
               .ToTable("ChecklistItems");
        }
    }
}
