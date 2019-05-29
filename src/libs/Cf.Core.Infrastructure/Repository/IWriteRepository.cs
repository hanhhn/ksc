using Cf.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Core.Infrastructure.Repository
{
    public interface IWriteRepository<TEntity> where TEntity : class, IEntityRoot
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Delete(TEntity entity);
    }
}
