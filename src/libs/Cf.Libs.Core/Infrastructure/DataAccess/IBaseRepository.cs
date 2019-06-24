using Cf.Libs.Core.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Core.Infrastructure.DataAccess
{
    public interface IBaseRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>, IQueryableRepository<TEntity>
        where TEntity : class, IEntityRoot
    {
    }
}
