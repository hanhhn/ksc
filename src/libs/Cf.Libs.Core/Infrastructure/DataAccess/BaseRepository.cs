using Cf.Libs.Core.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cf.Libs.Core.Infrastructure.DataAccess
{
    public abstract class RepositoryBase<TContext, TEntity> : IRepositoryBase<TEntity>
            where TContext : DbContext, new()
            where TEntity : class, IEntityRoot
    {
        public readonly TContext DbContext;

        public RepositoryBase()
        {
        }

        public RepositoryBase(TContext context)
        {
            DbContext = context;
        }

        protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();

        public virtual IQueryable<TEntity> GetQuery()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Where(filter);
        }

        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            return null;
        }

        public virtual TEntity Get(params object[] keyValues)
        {
            return DbSet.Find(keyValues);
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
            DbSet.Remove(entity);
        }
    }
}
