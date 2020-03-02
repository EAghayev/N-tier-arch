using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class PipelineConfiguration : IEntityTypeConfiguration<Pipeline>
    {
        public void Configure(EntityTypeBuilder<Pipeline> builder)
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
               .HasOne(c => c.Project)
               .WithMany(c => c.Pipelines)
               .HasForeignKey(c => c.ProjectId);

            builder
               .Property(m => m.Name)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(m => m.Icon)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(m => m.Color)
               .IsRequired()
               .HasMaxLength(50);

            builder
              .Property(m => m.Order)
              .IsRequired();

            builder
                .ToTable("Pipelines");
        }
    }
}
