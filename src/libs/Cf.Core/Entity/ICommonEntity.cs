using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Core.Entity
{
    public interface ICommonEntity<T>
    {
        T Id { get; set; }
        bool IsDeleted { get; set; }
        bool IsVisibale { get; set; }
    }
}
