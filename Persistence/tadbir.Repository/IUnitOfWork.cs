using System.Threading.Tasks;

namespace tadbir.Repository
{
    public interface IUnitOfWork
    {


        void Commit();

        Task<int> CommitAsync();
    }
}