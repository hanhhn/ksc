using System;

namespace Cf.Libs.Core.Infrastructure.Entity
{
    public interface IChangeableEntity
    {
        DateTime CreateDate { get; }
        string CreateUserId { get; }
        DateTime ModifiedDate { get; }
        string ModifyUserId { get; }
        string UpdatedToken { get; }
        void Default(bool isAdd, int userId);
    }
}