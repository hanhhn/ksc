using System;

namespace Cf.Libs.Core.Infrastructure.Entity
{
    public class BaseEntity<T> : IEntityRoot, IChangeableEntity, ICommonEntity<T>
    {
        public T Id { get; set; }
        public bool IsDeleted { get; private set; }
        public bool IsVisible { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifyUserId { get; set; }
        public string UpdatedToken { get; set; }
        public string Note { get; set; }
    }
}