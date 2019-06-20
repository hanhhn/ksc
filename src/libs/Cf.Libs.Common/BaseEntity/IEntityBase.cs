using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Common.BaseEntity
{
    public interface IEntityBase<T> : IEntityRoot, IChangeableEntity, ICommonEntity<T>
    {
    }
}
