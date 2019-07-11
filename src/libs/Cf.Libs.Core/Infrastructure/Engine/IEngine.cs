using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Core.Infrastructure.Engine
{
    public interface IEngine
    {
        IServiceProvider GetServiceProvider();
        T Resolve<T>() where T : class;
        object Resolve(Type type);
    }
}
