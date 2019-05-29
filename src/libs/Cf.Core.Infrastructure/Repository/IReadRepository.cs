using Cf.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cf.Core.Infrastructure.Repository
{
    public interface IReadRepository<TEntity> where TEntity : IEntityRoot
    {
        TEntity Get(params object[] keyValues);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
    }
}
