using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class PipelineTaskConfiguration : IEntityTypeConfiguration<PipelineTask>
    {
        public void Configure(EntityTypeBuilder<PipelineTask> builder)
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
               .HasOne(c => c.Pipeline)
               .WithMany(c => c.Tasks)
               .HasForeignKey(c => c.PipelineId);

            builder
               .Property(m => m.Title)
               .IsRequired()
               .HasMaxLength(200);

            builder
               .Property(m => m.Desc)
               .HasMaxLength(500);

            builder
               .Property(m => m.IsDone)
               .HasDefaultValue(false);

            builder
               .HasOne(c => c.User)
               .WithMany(c => c.Tasks)
               .HasForeignKey(c => c.UserId);

            builder
                .ToTable("PipelineTasks");
        }
    }
}
