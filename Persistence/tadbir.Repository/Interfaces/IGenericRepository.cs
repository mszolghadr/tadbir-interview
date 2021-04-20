using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tadbir.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T Add(T t);

        void Delete(T entity);

        Task DeleteAsync(object key);

        T Get(object key);

        IQueryable<T> GetAll();

        Task<ICollection<T>> GetAllAsync();

        Task<T> GetAsync(object key);

        T Update(T t, object key);

        Task<T> UpdateAsync(T t, object key);
    }

}