using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using tadbir.Service.DTOs.InvoiceDTOs;
using tadbir.Service.Interfaces;

namespace tadbir.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly ILogger<InvoicesController> _logger;
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(ILogger<InvoicesController> logger, IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(DetailedInvoiceDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddNewInvoice(InvoiceDto dto, CancellationToken cancellationToken)
        {
            return Ok(await _invoiceService.AddNewInvoiceAsync(dto, cancellationToken));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InvoiceListDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _invoiceService.GetInvoiceListAsync(cancellationToken));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DetailedInvoiceDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetProduct(long id, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceService.GetInvoiceAsync(id, cancellationToken);
            if (invoice == null)
                return NotFound();
            return Ok(invoice);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DetailedInvoiceDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EditProduct(long id, InvoiceDto dto, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _invoiceService.EditInvoiceAsync(dto, id, cancellationToken));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteProduct(long id, CancellationToken cancellationToken)
        {
            await _invoiceService.DeleteInvoiceAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
