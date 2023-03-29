using Project.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.GenericRepository
{
   
     public abstract class EFRepository<T, TKey> : IRepository<T, TKey>
          where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        readonly protected DbSet<T> _objectSet;

        public EFRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _objectSet = unitOfWork.Context.Set<T>();
        }

        public virtual IEnumerable<T> Get(
          Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          string includeProperties = "")
        {
            IQueryable<T> query = _objectSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual T GetByID(object id)
        {
            return _objectSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            _objectSet.Add(entity);
        }
        public virtual void AddRange(List<T> lst)
        {
            _objectSet.AddRange(lst);
        }
        public virtual void DeleteByID(object id)
        {
            T entityToDelete = _objectSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            _objectSet.Remove(entityToDelete);
        }

        public virtual void DeleteList(List<T> entityToDeleteList)
        {
            _objectSet.RemoveRange(entityToDeleteList);
        }

        public virtual void Update(T entityToUpdate)
        {
            _objectSet.Attach(entityToUpdate);
            _unitOfWork.Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public void SaveChanges()
        {
            this._unitOfWork.SaveChanges();
        }

       
    }

}
