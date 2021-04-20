using System.Threading.Tasks;
using tadbir.Data;
using tadbir.Repository.Interfaces;
using tadbir.Repository.Implementations;

namespace tadbir.Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly TadbirDbContext _dbContext;

        public UnitOfWork(TadbirDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private IInvoiceRepository _invoiceRepository;
        private IProductRepository _productRepository;

        public IInvoiceRepository NoticeRepository => _invoiceRepository ??= new InvoiceRepository(_dbContext);
        public IProductRepository PositionRepository => _productRepository ??= new ProductRepository(_dbContext);

        public void Commit() => _dbContext.SaveChanges();
        public async Task<int> CommitAsync() => await _dbContext.SaveChangesAsync();
    }
}