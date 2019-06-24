using Cf.Libs.Core.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cf.Libs.Core.Infrastructure.DataAccess
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IEntityRoot
    {
        public readonly DbContext DbContext;

        public BaseRepository()
        {
        }

        public BaseRepository(DbContext context)
        {
            DbContext = context;
        }

        protected DbSet<TEntity> DbSet
        {
            get
            {
                DbSet<TEntity> entity = DbContext.Set<TEntity>();
                if (entity == null)
                {
                    throw new NullReferenceException("Entity can not be set!");
                }

                return entity;
            }
        }

        public virtual IQueryable<TEntity> GetQuery()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Where(filter);
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            return orderBy(DbSet.Where(filter));
        }

        public virtual TEntity Get(params object[] keyValues)
        {
            return DbSet.Find(keyValues);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsEnumerable();
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            IDeleteEntity common = entity as IDeleteEntity;
            if (common != null)
            {
                common.Delete();
            }
        }

        public virtual void UnDelete(TEntity entity)
        {
            IDeleteEntity common = entity as IDeleteEntity;
            if (common != null)
            {
                common.UnDelete();
            }
        }
    }
}
