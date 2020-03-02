using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class ProjectUserConfiguration : IEntityTypeConfiguration<ProjectUser>
    {
        public void Configure(EntityTypeBuilder<ProjectUser> builder)
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
               .HasOne(c => c.User)
               .WithMany(c => c.ProjectUsers)
               .HasForeignKey(c => c.UserId);

            builder
              .HasOne(c => c.Project)
              .WithMany(c => c.ProjectUsers)
              .HasForeignKey(c => c.ProjectId);

            builder
               .Property(m => m.InviteToken)
               .HasMaxLength(50);

            builder
                .ToTable("ProjectUsers");
        }
    }
}
