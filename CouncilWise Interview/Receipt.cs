using System.Collections.Generic;
using System.Text;

namespace CouncilWise
{
    internal class Receipt
    {
        public ICollection<ReceiptItem> Items { get; set; }
        public decimal Total { get; set; }
        public decimal TaxTotal { get; set; }

        public Receipt(ICollection<ReceiptItem> items, decimal total, decimal taxTotal)
        {
            this.Items = items;
            this.Total = total;
            this.TaxTotal = taxTotal;
        }

        public override string ToString()
        {
            string output = "";

            output = "Receipt\nItems:";

            foreach (ReceiptItem item in Items)
            {
                output += ($"\n{item.Name.ToString()}\n" +
                    $"\t{item.Quantity.ToString()}\t{item.UnitPrice.ToString()}\t{(item.IncludesTax ? item.UnitPrice * item.Quantity : item.UnitPrice * item.Quantity * 1.1m)}");
            }

            return output + $"\nTotal:\t {Total}\nGST:\t {TaxTotal}\n";
        }
    }
}
