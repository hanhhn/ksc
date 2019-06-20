using Cf.Libs.Core.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cf.Libs.Core.Infrastructure.DataAccess
{
    public interface IQueryableRepository<TEntity> where TEntity : IEntityRoot
    {
        IQueryable<TEntity> GetQuery();
    }
}