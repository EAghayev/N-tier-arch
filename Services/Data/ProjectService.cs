using Core;
using Core.Models;
using Core.Services.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services.Data
{
    public class ProjectService: IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Project> CreateProject(Project project)
        {
            project.AddedAt = DateTime.Now;
            project.ModifiedAt = DateTime.Now;

            await _unitOfWork.Project.AddAsync(project);

            await _unitOfWork.CommitAsync();

            return project;
        }

        public IEnumerable<Project> GetProjectByUserId(int userId)
        {
            return _unitOfWork.Project.Find(p => p.UserId == userId);
        }
    }
}
