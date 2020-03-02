using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private TaskManagmentDbContext _context => Context as TaskManagmentDbContext;

        public ProjectRepository(TaskManagmentDbContext context) : base(context) { }
    }
}
