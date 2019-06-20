using Cf.Libs.Core.Infrastructure.Entity;
using Cf.Libs.Core.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cf.Libs.Core.Infrastructure.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork, IDisposable
         where TContext : DbContext, new()
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
                        DateTime date = DateTime.Now;
                        entity.CreateDate = date;
                        entity.CreateUserId = _request.UserId.ToString();
                        entity.ModifiedDate = date;
                        entity.ModifyUserId = _request.UserId.ToString();
                        entity.UpdatedToken = Guid.NewGuid().ToString();
                        continue;
                    }

                    if (dbEntity.State == EntityState.Modified)
                    {
                        DateTime date = DateTime.Now;
                        entity.ModifiedDate = date;
                        entity.ModifyUserId = _request.UserId.ToString();
                        entity.UpdatedToken = Guid.NewGuid().ToString();
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
