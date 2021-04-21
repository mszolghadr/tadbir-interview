using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tadbir.Service.DTOs.InvoiceDTOs;
using tadbir.Service.Interfaces;

namespace tadbir.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly ILogger<InvoicesController> _logger;
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(ILogger<InvoicesController> logger, IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DetailedInvoiceDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<DetailedInvoiceDto>>> Get()
        {
            return Ok(await _invoiceService.GetInvoiceListAsync());
        }
    }
}
