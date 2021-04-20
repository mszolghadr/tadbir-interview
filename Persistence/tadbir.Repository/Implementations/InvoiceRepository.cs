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
    }
}