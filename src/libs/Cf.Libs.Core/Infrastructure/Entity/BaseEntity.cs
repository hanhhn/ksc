using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cf.Libs.Core.Infrastructure.Entity
{
    public class BaseEntity<T> : IEntityRoot, IChangeableEntity, ICommonEntity<T>
    {
        public T Id { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsVisible { get; set; }
        public DateTime CreateDate { get; private set; }
        public string CreateUserId { get; private set; }
        public DateTime ModifiedDate { get; private set; }
        public string ModifyUserId { get; private set; }
        public string UpdatedToken { get; private set; }
        public string Note { get; set; }

        public BaseEntity()
        {
            if(typeof(T).ToString() == typeof(string).ToString())
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                Id = (T)converter.ConvertFromInvariantString(Guid.NewGuid().ToString());
            }
        }

        public void Default(bool isAdd, int userId)
        {
            DateTime date = DateTime.Now;
            if (isAdd)
            {
                CreateDate = date;
                CreateUserId = userId.ToString();
                ModifiedDate = date;
                ModifyUserId = userId.ToString();
                UpdatedToken = Guid.NewGuid().ToString();
            }
            else
            {
                ModifiedDate = date;
                ModifyUserId = userId.ToString();
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