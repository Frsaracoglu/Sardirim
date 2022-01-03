using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class SalesModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
