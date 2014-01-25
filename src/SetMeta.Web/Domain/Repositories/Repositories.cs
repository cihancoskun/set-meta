using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SetMeta.Web.Domain.Entities;

namespace SetMeta.Web.Domain.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
           where TEntity : BaseEntity
    {
        protected SetMetaDbContext Context;

        public Repository()
        {
            Context = new SetMetaDbContext();
        }

        public virtual TEntity Create(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual void Delete(long id)
        {
            var entity = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(entity);
        }

        public void Delete(string publicId)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            var objects = Context.Set<TEntity>().Where(where).AsEnumerable();
            foreach (var item in objects)
            {
                Context.Set<TEntity>().Remove(item);
            }
        }

        public virtual void SoftDelete(long id, long deletedBy)
        {
            var entity = Context.Set<TEntity>().First(x => x.Id == id);
            entity.DeletedAt = DateTime.Now;
            entity.DeletedBy = deletedBy;
            entity.IsDeleted = true;
        }

        public void SoftDelete(string publicId, long deletedBy)
        {
            var entity = Context.Set<TEntity>().First(x => x.PublicId == publicId);
            entity.DeletedAt = DateTime.Now;
            entity.DeletedBy = deletedBy;
            entity.IsDeleted = true;
        }

        public void SoftDelete(Expression<Func<TEntity, bool>> where, long deletedBy)
        {
            var objects = Context.Set<TEntity>().Where(where).AsEnumerable();
            foreach (var item in objects)
            {
                item.DeletedAt = DateTime.Now;
                item.DeletedBy = deletedBy;
                item.IsDeleted = true;
            }
        }

        public bool Any(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return FindAll(where, includeProperties).Any();
        }

        public int Count(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return FindAll(where, includeProperties).Count();
        }

        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return FindAll(where, includeProperties).FirstOrDefault();
        }

        public virtual IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var items = where != null
                ? Context.Set<TEntity>().Where(s => !s.IsDeleted).Where(where)
                : Context.Set<TEntity>().Where(s => !s.IsDeleted);

            foreach (var property in includeProperties)
            {
                items.Include(property);
            }

            return items;
        }

        public virtual bool SaveChanges()
        {
            return 0 < Context.SaveChanges();
        }

        public void Dispose()
        {
            if (null != Context)
            {
                Context.Dispose();
            }
        }
    }
}