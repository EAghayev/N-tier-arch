using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<User> GetUserByToken(string token);
        Task<User> GetUserById(int id);
        Task<User> CheckLogin(string email, string password);
        Task<bool> CheckEmail(string email);
    }
}
