using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Common.BaseEntity
{
    public interface ICommonEntity<T>
    {
        T Id { get; set; }
        bool IsDeleted { get; set; }
        bool IsVisible { get; set; }
    }
}