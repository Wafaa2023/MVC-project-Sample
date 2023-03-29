using System;
using System.Data.Entity;

namespace Project.Core.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        void SaveChanges();
    }
}