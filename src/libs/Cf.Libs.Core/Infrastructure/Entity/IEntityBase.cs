using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Core.Infrastructure.Entity
{
    public interface IEntityBase<T> : IEntityRoot, IChangeableEntity, ICommonEntity<T>
    {
    }
}
