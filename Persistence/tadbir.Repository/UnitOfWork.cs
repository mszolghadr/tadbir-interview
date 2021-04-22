using System.Threading.Tasks;
using tadbir.Data;
using tadbir.Repository.Interfaces;
using tadbir.Repository.Implementations;
using System;
using System.Threading;

namespace tadbir.Repository
{

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed = false;
        private readonly TadbirDbContext _dbContext;

        public UnitOfWork(TadbirDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private IInvoiceRepository _invoiceRepository;
        private IProductRepository _productRepository;

        public IInvoiceRepository InvoiceRepository => _invoiceRepository ??= new InvoiceRepository(_dbContext);
        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_dbContext);

        public void Commit() => _dbContext.SaveChanges();
        public async Task<int> CommitAsync(CancellationToken cancellationToken) => await _dbContext.SaveChangesAsync(cancellationToken);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _dbContext?.Dispose();
            }

            _disposed = true;
        }
    }
}