
using Project.Model.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.DTO.ViewModel
{
   public class InvoiceVM
    {
        public List<Item> ItemsList { get; set; }
        //header
        public int MainId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Date { get; set; }
        public double? Discount { get; set; }
        public int? Number { get; set; }
        public decimal? Total { get; set; }
        public decimal? NetTotal { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int PaymentMethodId { get; set; }

        //Details
         public  IEnumerable<Invoice_Details> InvoiceDetails { get; set; }
        public decimal Price { get; set; }
        public decimal RowTotal  { get; set; }

    }
}
