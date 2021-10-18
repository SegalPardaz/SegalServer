using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Segal.Data.Repositories.Repositories;

namespace Segal.Data.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        protected readonly DbContext _db;
        public UnitOfWork()
        {
            _db = new TContext();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _db.SaveChangesAsync();
        }

        private UserRepository userRepository;

        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_db);
                }

                return userRepository;
            }
        }


        private bool Disposed = false;

        protected virtual void Dispose(bool dispose)
        {
            if (!Disposed)
            {
                if (dispose)
                {
                    _db.Dispose();
                }
            }

            Disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
