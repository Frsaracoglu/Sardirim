using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer
{
    public class Employees
    {
        public bool EmployeesEntryControl(string password, int UserId)
        {
            DataLayer.Employees CalısanGiris = new DataLayer.Employees();
            return CalısanGiris.EmployeesEntryControl(password, UserId);
        }
        public void EmployeesGetbyInformation(ComboBox cb)
        {
            DataLayer.Employees CalısanBilgileri = new DataLayer.Employees();
            return CalısanBilgileri.EmployeesGetbyInformation(cb);
        }
        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}
