using Microsoft.EntityFrameworkCore;
using Core.Models;
using Data.Configurations;

namespace Data
{
    public class TaskManagmentDbContext:DbContext
    {
        public TaskManagmentDbContext(DbContextOptions<TaskManagmentDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ChecklistConfiguration());
            builder.ApplyConfiguration(new ChecklistItemConfiguration());
            builder.ApplyConfiguration(new PipelineConfiguration());
            builder.ApplyConfiguration(new PipelineTaskConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new ProjectUserConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }
        public DbSet<Pipeline> Pipelines { get; set; }
        public DbSet<PipelineTask> PipelineTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
