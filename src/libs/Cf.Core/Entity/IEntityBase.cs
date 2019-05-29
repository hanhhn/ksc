using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Core.Entity
{
    public interface IEntityBase<T> : IEntityRoot, IChangeableEntity, ICommonEntity<T>
    {
    }
}
