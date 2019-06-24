using Cf.Libs.Core.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cf.Libs.Core.Infrastructure.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork, IDisposable
         where TContext : DbContext
    {
        public readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            if (_context.ChangeTracker.HasChanges())
            {
                foreach (var dbEntity in _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
                {
                    IChangeableEntity entity = dbEntity.Entity as IChangeableEntity;
                    if (entity == null)
                        continue;

                    if (dbEntity.State == EntityState.Added)
                    {
                        entity.Default(true, 0);
                        continue;
                    }

                    if (dbEntity.State == EntityState.Modified)
                    {
                        entity.Default(false, 0);
                    }
                }
            }

            return _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}