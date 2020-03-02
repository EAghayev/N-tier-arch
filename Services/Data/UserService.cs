using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Models;
using Core.Services.Data;
using CryptoHelper;

namespace Services.Data
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CheckEmail(string email)
        {
            User user = await _unitOfWork.User.SingleOrDefaultAsync(u => u.Email == email);

            if (user == null) return true;

            return false;
        }

        public async Task<User> CheckLogin(string email, string password)
        {
            User user = await _unitOfWork.User.SingleOrDefaultAsync(u => u.Email == email);

            if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
                return user;

            return null;
        }

        public async Task<User> CreateUser(User user)
        {
            user.AddedAt = DateTime.Now;
            user.Password = Crypto.HashPassword(user.Password);

            await _unitOfWork.User.AddAsync(user);

            await _unitOfWork.CommitAsync();

            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.User.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByToken(string token)
        {
            return await _unitOfWork.User.FindUserByToken(token);
        }
    }
}
