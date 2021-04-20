using tadbir.Data;
using tadbir.Entities;
using tadbir.Repository.Interfaces;

namespace tadbir.Repository.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(TadbirDbContext dbContext) : base(dbContext)
        {
        }
    }
}