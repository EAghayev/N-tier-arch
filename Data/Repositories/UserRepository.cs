using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private TaskManagmentDbContext _context => Context as TaskManagmentDbContext;
        public UserRepository(TaskManagmentDbContext context)
         : base(context)
        { }


        public async Task<User> FindUserByToken(string token)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Token == token);
        }
    }
}
