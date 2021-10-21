using Segal.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Segal.Common.Helpers;
using Segal.Data.DatabaseContext;
using Segal.Repo.Infrastructure;

namespace Segal.Services.Interfaces
{
    public class AuthService : IAuthService
    {
        private IUnitOfWork<SegalDbContext> _db { get; set; }

        public AuthService(IUnitOfWork<SegalDbContext> db)
        {
            _db = db;
        }
        public async Task<User> Login(string username, string password)
        {
           var user=await _db.UserRepository.UserIsExist(username);
           if (!Utilities.VrifayPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return null;

           return user;
        }

        public async Task<bool> Register(User user, string password)
        {
           byte[] passwordHash, passwordSalt;
           Utilities.CreatePasswordHash(password, out passwordHash, out passwordSalt);
           await _db.UserRepository.InsertAsync(user);
           await _db.SaveAsync();

           return true;
        }
    }
}
