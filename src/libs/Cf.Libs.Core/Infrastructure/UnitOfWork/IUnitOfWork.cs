using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Core.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
