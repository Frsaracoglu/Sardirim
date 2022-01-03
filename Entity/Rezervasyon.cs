using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Rezervasyon
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public int CleintCount { get; set; }
        public string Description { get; set; }
        public int AdditionId { get; set; }
    }
}
