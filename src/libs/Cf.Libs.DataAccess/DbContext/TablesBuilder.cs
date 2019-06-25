using Cf.Libs.Core.Infrastructure.Entity;
using Cf.Libs.DataAccess.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Cf.Libs.DataAccess.DbContext
{
    public static class TablesBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            //dynamically load all entity and query type configurations
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type => (type.BaseType?.IsGenericType ?? false) && (type.BaseType.GetGenericTypeDefinition() == typeof(BaseEntity<>)));

            foreach (var typeConfiguration in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                configuration.ApplyConfiguration(modelBuilder);
            }
        }
    }
}