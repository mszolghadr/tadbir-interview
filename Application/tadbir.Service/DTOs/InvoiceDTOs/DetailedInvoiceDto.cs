using System;
using System.Collections.Generic;
using System.Linq;

namespace tadbir.Service.DTOs.InvoiceDTOs
{
    public class DetailedInvoiceDto
    {
        public long Id { get; set; }

        public long Serial { get; set; }

        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;

        public string UserFullName { get; set; }

        public string Description { get; set; }

        public long TotalPrice { get { return Rows.Sum(r => r.TotalPrice); } }

        public long TotalDiscountAmount { get { return Rows.Sum(r => r.TotalDiscountAmount); } }

        public long TotalDiscountedPrice { get { return TotalPrice - TotalDiscountAmount; } }

        public IEnumerable<DetailedInvoiceRowDto> Rows { get; set; }
    }
}