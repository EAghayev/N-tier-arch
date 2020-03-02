using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IProjectService
    {
        Task<Project> CreateProject(Project project);
        IEnumerable<Project> GetProjectByUserId(int userId);
    }
}
