using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using tadbir.Service.DTOs.ProductDTOs;

namespace tadbir.Service.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> AddNewProductAsync(ProductDto productDto, CancellationToken cancellationToken = default);
        Task<ProductDto> EditProductAsync(ProductDto productDto, long productId, CancellationToken cancellationToken = default);
        Task DeleteProductAsync(long id, CancellationToken cancellationToken = default);
        Task<ProductDto> GetProductAsync(long id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductListDto>> GetProductListAsync(CancellationToken cancellationToken = default);
    }
}