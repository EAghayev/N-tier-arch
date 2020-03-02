using Microsoft.EntityFrameworkCore;
using Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ChecklistConfiguration : IEntityTypeConfiguration<Checklist>
    {
        public void Configure(EntityTypeBuilder<Checklist> builder)
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
                .HasOne(c => c.Task)
                .WithMany(c => c.Checklists)
                .HasForeignKey(c => c.PipelineTaskId);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Checklists");
        }
    }
}
