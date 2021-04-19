using System.Collections.Generic;

namespace tadbir.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public IEnumerable<InvoiceRow> Rows { get; set; }
    }
}