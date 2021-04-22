using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using tadbir.Entities;
using tadbir.Repository.Interfaces;
using tadbir.Service.DTOs.ProductDTOs;
using tadbir.Service.Interfaces;

namespace tadbir.Service.Implementations
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _productRepository = _unitOfWork.ProductRepository;
        }

        public async Task<ProductDto> AddNewProductAsync(ProductDto productDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Product>(productDto);
            _productRepository.Add(entity);
            await _unitOfWork.CommitAsync();
            productDto.Id = entity.Id;
            return productDto;
        }

        public async Task DeleteProductAsync(long id, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<ProductDto> EditProductAsync(ProductDto productDto, long productId, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetAsync(productId);
            if (entity == null)
                throw new KeyNotFoundException();
            _mapper.Map(productDto, entity);
            await _productRepository.UpdateAsync(entity, productId);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task<ProductDto> GetProductAsync(long id, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetAsync(id);
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task<IEnumerable<ProductListDto>> GetProductListAsync(CancellationToken cancellationToken)
        {
            var entities = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductListDto>>(entities);
        }
    }
}
