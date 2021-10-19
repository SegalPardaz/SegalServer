using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Segal.Repo.Repositories.Repositories;

namespace Segal.Repo.Infrastructure
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        UserRepository UserRepository { get; }
        void Save();
        Task<int> SaveAsync();
    }
}
