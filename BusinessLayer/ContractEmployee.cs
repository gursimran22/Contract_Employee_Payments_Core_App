using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contract_Employee_Payments_Core_App.BusinessLayer
{
    //A contract employee with hourly wage
    public class ContractEmployee
    {
       public int Id { get; set; }

        public string Name { get; set; }

        public decimal HourlyRate { get; set; }

    }
}
