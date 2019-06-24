namespace Cf.Libs.Core.Infrastructure.Entity
{
    public interface IDeleteEntity
    {
        bool IsDeleted { get; }
        bool IsVisible { get; set; }
        void Delete();
        void UnDelete();
    }
}
