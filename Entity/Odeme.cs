using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Odeme
    {
        public int Id { get; set; }
        public int CheckID { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal KDV { get; set; }
        public decimal LastTotal { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
    }
}
