using Cf.Libs.Core.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Cf.Libs.DataAccess.Mapping
{
    public class EntityTypeConfiguration<TEntity> : IMappingConfiguration, IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            PropertyInfo prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.UpdatedToken));
            if(prop != null)
            {
                builder.Property(nameof(IChangeableEntity.UpdatedToken)).IsConcurrencyToken();
            }
        }

        public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}