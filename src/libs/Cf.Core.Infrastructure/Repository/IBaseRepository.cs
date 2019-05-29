using Cf.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Core.Infrastructure.Repository
{
    public interface IRepositoryBase<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>, IQueryableRepository<TEntity>
        where TEntity : class, IEntityRoot
    {
    }
}
