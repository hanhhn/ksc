using Cf.Libs.Core.Infrastructure.Entity;
using Cf.Libs.Core.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cf.Libs.Core.Infrastructure.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork, IDisposable
         where TContext : DbContext
    {
        private readonly IRequestContext _request;
        public readonly TContext _context;

        public UnitOfWork(TContext context, IRequestContext request)
        {
            _request = request;
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
                        entity.Default(true, _request.UserId, _request.UserId);
                        continue;
                    }

                    if (dbEntity.State == EntityState.Modified)
                    {
                        entity.Default(false, _request.UserId, _request.UserId);
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