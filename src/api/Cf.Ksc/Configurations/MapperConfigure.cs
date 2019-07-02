using AutoMapper;
using Cf.Ksc.Service;
using Cf.Libs.Service;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cf.Ksc.Configurations
{
    public static class MapperConfigure
    {
        public static void AddMapper()
        {
            Action<IMapperConfigurationExpression> InitMapper = config =>
            {
                config.AddCoreMapper();
                config.AddKscMapper();
            };
            Mapper.Initialize(InitMapper);
        }
    }
}