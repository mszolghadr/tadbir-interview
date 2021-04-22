using System.Threading;
using System.Threading.Tasks;
using tadbir.Repository.Interfaces;

namespace tadbir.Repository
{
    public interface IUnitOfWork
    {
        IInvoiceRepository InvoiceRepository { get; }
        IProductRepository ProductRepository { get; }

        void Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}