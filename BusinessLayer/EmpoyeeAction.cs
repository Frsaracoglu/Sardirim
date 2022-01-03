using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer
{
    public class EmployeeAction
    {
        public bool EmployeesActionSave(EmployeeAction ea)
        {
            DataLayer.EmployeeAction CalısanHareketleriKayıt = new DataLayer.EmployeeAction();
            return CalısanHareketleriKayıt.EmployeesActionSave(ea);
        }
    }
}
