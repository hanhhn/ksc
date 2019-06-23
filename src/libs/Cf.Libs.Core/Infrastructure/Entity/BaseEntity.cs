using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cf.Libs.Core.Infrastructure.Entity
{
    public class BaseEntity<T> : IEntityRoot, IChangeableEntity, ICommonEntity<T>
    {
        [Column(Order = 0)]
        public T Id { get; set; }

        [Column(Order = 93)]
        public bool IsDeleted { get; private set; }

        [Column(Order = 94)]
        public bool IsVisible { get; set; }

        [Column(Order = 95)]
        public DateTime CreateDate { get; set; }

        [Column(Order = 96)]
        public string CreateUserId { get; set; }

        [Column(Order = 97)]
        public DateTime ModifiedDate { get; set; }

        [Column(Order = 98)]
        public string ModifyUserId { get; set; }

        [Column(Order = 99)]
        public string UpdatedToken { get; set; }

        [Column(Order = 100)]
        public string Note { get; set; }
    }
}