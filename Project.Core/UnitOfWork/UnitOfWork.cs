
using System;
using System.Data.Entity;
namespace Project.Core.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext _context = null;


        public UnitOfWork(DbContext DBContext)
        {
            if (this._context == null)
            {
                this._context = DBContext;
                this._context.Configuration.LazyLoadingEnabled = true;
                this._context.Database.CommandTimeout = 180;
                this._context.Configuration.ProxyCreationEnabled = true;

            }

            //_user = user;
        }

        public DbContext Context
        {
            get
            {
                if (this._context != null)
                {
                    return this._context;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }


        public void SaveChanges()
        {
            this._context.SaveChanges();
        }


        
        #region  Dispose

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


   

    }
}