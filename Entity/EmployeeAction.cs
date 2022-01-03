using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class EmpoyeeAction
    {
        public int ID { get; set; }
        public int EmplooyeesID { get; set; }
        public int Action { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
