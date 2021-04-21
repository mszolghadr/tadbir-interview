using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tadbir.Service.DTOs.ProductDTOs;
using tadbir.Service.Interfaces;

namespace tadbir.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get(CancellationToken cancellationToken)
        {
            return Ok(await _productService.GetProductListAsync(cancellationToken));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDto>> AddNewProduct(ProductDto dto, CancellationToken cancellationToken)
        {
            return Ok(await _productService.AddNewProductAsync(dto, cancellationToken));
        }
    }
}