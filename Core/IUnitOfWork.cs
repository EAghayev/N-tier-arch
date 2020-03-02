using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;

namespace Core
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IProjectRepository Project { get; }
        Task<int> CommitAsync();
    }
}
