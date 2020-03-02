using Core;
using Core.Repositories;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskManagmentDbContext _context;
        private IUserRepository _userRepository;
        private IProjectRepository _projectRepository;

        public IUserRepository User => _userRepository ??= new UserRepository(_context);
        public IProjectRepository Project => _projectRepository ??= new ProjectRepository(_context);

        public UnitOfWork(TaskManagmentDbContext context)
        {
            this._context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
