using System.Collections.Generic;

namespace tadbir.Service.DTOs.InvoiceDTOs
{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public string UserFullName { get; set; }
        public string Description { get; set; }
        public IEnumerable<InvoiceRowDto> Rows { get; set; }
    }
}