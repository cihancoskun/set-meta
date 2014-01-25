using System;
using System.Linq;
using System.Linq.Expressions;
using SetMeta.Web.Domain.Entities;

namespace SetMeta.Web.Domain.Repositories
{
    public interface IRepository<TEntity>
          where TEntity : BaseEntity
    {
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);

        void SoftDelete(long id, long deletedBy);
        void SoftDelete(string publicId, long deletedBy);
        void SoftDelete(Expression<Func<TEntity, bool>> where, long deletedBy);

        void Delete(long id);
        void Delete(string publicId);
        void Delete(Expression<Func<TEntity, bool>> where);

        TEntity FindOne(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties);

        bool Any(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties);
        int Count(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties);

        bool SaveChanges();
    }
}
