namespace Cf.Libs.Core.Infrastructure.Entity
{
    public interface ICommonEntity<T> : IDeleteEntity
    {
        T Id { get; }
        string Note { get; set; }
    }
}