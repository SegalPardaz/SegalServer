using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Segal.Data.DatabaseContext;
using Segal.Data.Models;
using Segal.Repo.Infrastructure;
using Segal.Repo.Repositories.Interfaces;

namespace Segal.Repo.Repositories.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private DbContext _dbContext;

        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = (dbContext ?? (SegalDbContext)dbContext);
        }
    }
}
