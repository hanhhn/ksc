using Cf.Libs.Core.Infrastructure.Entity;

namespace Cf.Libs.Core.Infrastructure.DataAccess
{
    public interface IWriteRepository<TEntity> where TEntity : class, IEntityRoot
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        void Delete(TEntity entity);
        void UnDelete(TEntity entity);
    }
}