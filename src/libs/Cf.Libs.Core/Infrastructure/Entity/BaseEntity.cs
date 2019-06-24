using System;
using System.ComponentModel;
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
        public DateTime CreateDate { get; private set; }

        [Column(Order = 96)]
        public string CreateUserId { get; private set; }

        [Column(Order = 97)]
        public DateTime ModifiedDate { get; private set; }

        [Column(Order = 98)]
        public string ModifyUserId { get; private set; }

        [Column(Order = 99)]
        public string UpdatedToken { get; private set; }

        [Column(Order = 100)]
        public string Note { get; set; }

        public BaseEntity()
        {
            if(typeof(T).ToString() == typeof(string).ToString())
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                Id = (T)converter.ConvertFromInvariantString(Guid.NewGuid().ToString());
            }
        }

        public void Default(bool isAdd, int createUserId, int modifyUserId)
        {
            DateTime date = DateTime.Now;
            if (isAdd)
            {
                CreateDate = date;
                CreateUserId = createUserId.ToString();
                ModifiedDate = date;
                ModifyUserId = modifyUserId.ToString();
                UpdatedToken = Guid.NewGuid().ToString();
            }
            else
            {
                ModifiedDate = date;
                ModifyUserId = modifyUserId.ToString();
                UpdatedToken = Guid.NewGuid().ToString();
            }
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void UnDelete()
        {
            IsDeleted = false;
        }
    }
}