using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class SolutionS
    {
        public Dictionary<string, long> Find(DateTime? from,DateTime? to)
        {
            var invoices = new List<Invoice>();

            Dictionary<string, long> result = new Dictionary<string, long>();

            IEnumerable<Invoice> filteredInvoices = invoices;

            if (from != null)
            {
                filteredInvoices = filteredInvoices.Where(i => i.CreationDate >= from.Value);
            }

            if (to != null)
            {
                filteredInvoices = filteredInvoices.Where(i => i.CreationDate <= to.Value);
            }
            var d = filteredInvoices.SelectMany(f => f.InvoiceItems);
            foreach (var invoice in filteredInvoices)
            {
                foreach (var item in invoice.InvoiceItems)
                {
                    if (result.ContainsKey(item.Name))
                    {
                        result[item.Name] += item.Count;
                    }
                    else
                    {
                        result[item.Name] = item.Count;
                    }
                }
            }

            return result;
        }

        public void Question2()
        {
            // something about unpaids invoices
        }
    }

    public class InvoiceItem
    {
        // A name of an item e.g. eggs.
        public string Name { get; set; }
        // A number of bought items e.g. 10.
        public uint Count { get; set; }
        // A price of an item e.g. 20.5.
        public decimal Price { get; set; }
    }

    public class Invoice
    {
        // A unique numerical identifier of an invoice (mandatory)
        public int Id { get; set; }
        // A short description of an invoice (optional).
        public string Description { get; set; }
        // A number of an invoice e.g. 134/10/2018 (mandatory).
        public string Number { get; set; }
        // An issuer of an invoice e.g. Metz-Anderson, 600  Hickman Street,Illinois (mandatory).
        public string Seller { get; set; }
        // A buyer of a service or a product e.g. John Smith, 4285  Deercove Drive, Dallas (mandatory).
        public string Buyer { get; set; }
        // A date when an invoice was issued (mandatory).
        public DateTime CreationDate { get; set; }
        // A date when an invoice was paid (optional).
        public DateTime? AcceptanceDate { get; set; }
        // A collection of invoice items for a given invoice (can be empty but is never null).
        public IList<InvoiceItem> InvoiceItems { get; }

        public Invoice()
        {
            InvoiceItems = new List<InvoiceItem>();
        }
    }


}
