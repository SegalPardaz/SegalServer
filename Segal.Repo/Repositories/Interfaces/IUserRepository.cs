using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Segal.Data.Models;
using Segal.Repo.Infrastructure;

namespace Segal.Repo.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> UserIsExist(string username);
    }
}
