using Cf.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cf.Core.Infrastructure.Repository
{
    public interface IQueryableRepository<TEntity> where TEntity : IEntityRoot
    {
        IQueryable<TEntity> GetQuery();
    }
}