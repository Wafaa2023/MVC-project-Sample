using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.GenericRepository
{
    /// <summary>
    /// Represents a generic repository interface that provides the basic CRUD operations
    /// </summary>
    /// <typeparam name="T">The type of the model class</typeparam>
    /// <typeparam name="TKey">The type of the primary key for the model class</typeparam>
    public interface IRepository<T, TKey> where T : class
    {
        IEnumerable<T>
       Get(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "");

        T GetByID(object id);
        void Add(T entity);
        void DeleteByID(object id);
        void Delete(T entityToDelete);
        void DeleteList(List<T> entityToDeleteList);
        void Update(T entityToUpdate);
        void SaveChanges();

     //   void BulkSaveChanges();

    }
}
