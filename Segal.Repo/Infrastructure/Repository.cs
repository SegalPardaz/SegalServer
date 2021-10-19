using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Segal.Repo.Infrastructure
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _db;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentException("There Is Not Entity");
            _dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentException("There Is Not Entity");
            _dbSet.Remove(entity);
        }

        public void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null) throw new ArgumentException("There Is Not Entity");
            _dbSet.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            var entity = _dbSet.Where(where);
            if (entity == null) throw new ArgumentException("There Is Not Entity");
            foreach (var item in entity)
            {
                _dbSet.Remove(item);
            }
        }


        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }
        public TEntity GetById(object id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null) throw new ArgumentException("There Is Not Entity");
            return entity;
        }




        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where);
        }


        #region Async

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.Where(where).FirstOrDefaultAsync();
        }



        public async Task<TEntity> GetByIdAsync(object id)
        {
            var entity = _dbSet.FindAsync(id);
            if (entity == null) throw new ArgumentException("There Is Not Entity");
            return await entity;
        }


        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.Where(where).ToListAsync();
        }





        #endregion



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

        ~Repository()
        {
            Dispose(false);
        }
    }
}
