using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using tadbir.Service.DTOs.InvoiceDTOs;

namespace tadbir.Service.Interfaces
{
    public interface IInvoiceService
    {
        Task<InvoiceListDto> AddNewInvoiceAsync(InvoiceDto invoiceDto, CancellationToken cancellationToken = default);
        Task<InvoiceListDto> EditInvoiceAsync(InvoiceDto invoiceDto, long invoiceId, CancellationToken cancellationToken = default);
        Task DeleteInvoiceAsync(long id, CancellationToken cancellationToken = default);
        Task<DetailedInvoiceDto> GetInvoiceAsync(long id, CancellationToken cancellationToken = default);
        Task<IEnumerable<InvoiceListDto>> GetInvoiceListAsync(CancellationToken cancellationToken = default);
    }
}