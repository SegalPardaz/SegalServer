using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Segal.Data.Infrastructure
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(object id);
        void Delete(Expression<Func<TEntity,bool>> where);



        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);


        //-------------------------------------------------//
        Task InsertAsync(TEntity entity);


        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where);

    }
}
