using System;
using System.Collections.Generic;

namespace tadbir.Entities
{
    public class Invoice
    {
        public long Id { get; set; }

        public long Serial { get; set; }

        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;

        public string UserFullName { get; set; }

        public string Description { get; set; }

        public List<InvoiceRow> Rows { get; set; }
    }
}