using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Core.Infrastructure.Entity
{
    public interface ICommonEntity<T>
    {
        T Id { get; set; }
        bool IsDeleted { get; }
        bool IsVisible { get; set; }
        string Note { get; set; }
    }
}