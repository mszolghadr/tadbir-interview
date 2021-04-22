using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tadbir.Data;
using tadbir.Repository.Interfaces;

namespace tadbir.Repository.Implementations
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TadbirDbContext _dbContext;

        public GenericRepository(TadbirDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public virtual async Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public virtual T Get(object key)
        {
            return _dbContext.Set<T>().Find(key);
        }

        public virtual async Task<T> GetAsync(object key, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().FindAsync(key, cancellationToken);
        }

        public virtual T Add(T t)
        {
            _dbContext.Set<T>().Add(t);
            return t;
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual async Task DeleteAsync(object key, CancellationToken cancellationToken)
        {
            T exist = await _dbContext.Set<T>().FindAsync(key, cancellationToken);
            if (exist != null)
            {
                _dbContext.Set<T>().Remove(exist);
            }
        }

        public virtual T Update(T t, object key)
        {
            if (t == null)
                return null;
            T exist = _dbContext.Set<T>().Find(key);
            if (exist != null)
            {
                _dbContext.Entry(exist).CurrentValues.SetValues(t);
            }
            return exist;
        }

        public virtual async Task<T> UpdateAsync(T t, object key, CancellationToken cancellationToken)
        {
            if (t == null)
                return null;
            T exist = await _dbContext.Set<T>().FindAsync(key, cancellationToken);
            if (exist != null)
            {
                _dbContext.Entry(exist).CurrentValues.SetValues(t);
            }
            return exist;
        }
    }
}