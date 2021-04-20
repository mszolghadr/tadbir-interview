using System.Collections.Generic;

namespace tadbir.Entities
{
    public class Invoice
    {
        public long Id { get; set; }

        public IEnumerable<InvoiceRow> Rows { get; set; }
    }
}