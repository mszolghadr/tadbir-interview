using System;

namespace tadbir.Service.DTOs.InvoiceDTOs
{
    public class InvoiceListDto
    {
        public long Id { get; set; }
        public string UserFullName { get; set; }
        public long Serial { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}