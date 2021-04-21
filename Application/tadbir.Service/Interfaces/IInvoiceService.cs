using System.Collections.Generic;
using System.Threading.Tasks;
using tadbir.Service.DTOs.InvoiceDTOs;

namespace tadbir.Service.Interfaces
{
    public interface IInvoiceService
    {
        Task<DetailedInvoiceDto> AddNewInvoiceAsync(InvoiceDto invoiceDto);
        Task<DetailedInvoiceDto> EditInvoiceAsync(InvoiceDto invoiceDto, long invoiceId);
        Task DeleteInvoiceAsync(long id);
        Task<DetailedInvoiceDto> GetInvoiceAsync(long id);
        Task<IEnumerable<InvoiceListDto>> GetInvoiceListAsync();
    }
}