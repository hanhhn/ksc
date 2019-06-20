using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Core.Infrastructure.DataAccess
{
    public interface IWriteRepository<TEntity> where TEntity : class, IEntityRoot
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Delete(TEntity entity);
    }
}
