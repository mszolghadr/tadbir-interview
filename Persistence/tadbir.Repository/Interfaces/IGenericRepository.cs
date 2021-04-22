using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace tadbir.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T Add(T t);

        void Delete(T entity);

        Task DeleteAsync(object key, CancellationToken cancellationToken = default);

        T Get(object key);

        IQueryable<T> GetAll();

        Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<T> GetAsync(object key, CancellationToken cancellationToken = default);

        T Update(T t, object key);

        Task<T> UpdateAsync(T t, object key, CancellationToken cancellationToken = default);
    }

}