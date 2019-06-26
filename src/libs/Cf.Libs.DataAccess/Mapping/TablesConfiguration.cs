using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Cf.Libs.DataAccess.Mapping
{
    public static class TablesConfiguration
    {
        public static void ConfigureEntity(this ModelBuilder modelBuilder, Assembly instance)
        {
            //dynamically load all entity and query type configurations
            var typeConfigurations = instance.GetTypes().Where(type => (type.BaseType?.IsGenericType ?? false) && (type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)));

            foreach (var typeConfiguration in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                configuration.ApplyConfiguration(modelBuilder);
            }
        }
    }
}