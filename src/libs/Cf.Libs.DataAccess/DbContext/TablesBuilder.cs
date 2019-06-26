using Cf.Libs.DataAccess.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Cf.Libs.DataAccess.DbContext
{
    public class TablesBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            //dynamically load all entity and query type configurations

            modelBuilder.ConfigureEntity(Assembly.GetExecutingAssembly());
        }
    }
}