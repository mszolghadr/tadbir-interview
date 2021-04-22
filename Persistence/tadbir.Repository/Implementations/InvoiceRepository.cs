using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tadbir.Data;
using tadbir.Entities;
using tadbir.Repository.Interfaces;

namespace tadbir.Repository.Implementations
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(TadbirDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Invoice> GetWithRowsAsync(long invoiceId, CancellationToken cancellationToken)
        {
            return await _dbContext.Invoices.Include(i => i.Rows).ThenInclude(r => r.Product).FirstOrDefaultAsync(i => i.Id == invoiceId, cancellationToken);
        }
    }
}