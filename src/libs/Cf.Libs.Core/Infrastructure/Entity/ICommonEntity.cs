using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Core.Infrastructure.Entity
{
    public interface ICommonEntity<T>
    {
        T Id { get; set; }
        bool IsDeleted { get; set; }
        bool IsVisible { get; set; }
    }
}