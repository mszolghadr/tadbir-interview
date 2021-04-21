using System.Threading.Tasks;
using tadbir.Entities;

namespace tadbir.Repository.Interfaces
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {

        Task<Invoice> GetWithRowsAsync(long invoiceId);
    }
}