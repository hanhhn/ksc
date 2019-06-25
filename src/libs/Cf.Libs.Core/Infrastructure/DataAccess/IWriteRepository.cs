using Cf.Libs.Core.Infrastructure.Entity;

namespace Cf.Libs.Core.Infrastructure.DataAccess
{
    public interface IWriteRepository<TEntity> where TEntity : class, IEntityRoot
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Delete(TEntity entity);
        void UnDelete(TEntity entity);
    }
}