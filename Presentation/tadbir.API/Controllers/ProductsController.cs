using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using tadbir.Service.DTOs.ProductDTOs;
using tadbir.Service.Interfaces;

namespace tadbir.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddNewProduct(ProductDto dto, CancellationToken cancellationToken)
        {
            return Ok(await _productService.AddNewProductAsync(dto, cancellationToken));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _productService.GetProductListAsync(cancellationToken));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetProduct(long id, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductAsync(id, cancellationToken);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EditProduct(long id, ProductDto dto, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _productService.EditProductAsync(dto, id, cancellationToken));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteProduct(long id, CancellationToken cancellationToken)
        {
            try
            {
                await _productService.DeleteProductAsync(id, cancellationToken);
                return NoContent();
            }
            catch (DbUpdateException)
            {
                return BadRequest("عملیات غیر مجاز");
            }
        }

        [HttpGet("droplist")]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<long, string>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDropDownList(CancellationToken cancellationToken)
        {
            return Ok(await _productService.GetDropDownListAsync(cancellationToken));
        }
    }
}