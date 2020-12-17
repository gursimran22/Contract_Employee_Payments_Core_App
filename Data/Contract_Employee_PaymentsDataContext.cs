using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contract_Employee_Payments_Core_App.BusinessLayer;

namespace Contract_Employee_Payments_Core_App.Models
{
    //Database connection 
    public class Contract_Employee_PaymentsDataContext : DbContext
    {
        public Contract_Employee_PaymentsDataContext (DbContextOptions<Contract_Employee_PaymentsDataContext> options)
            : base(options)
        {
        }

        public DbSet<Contract_Employee_Payments_Core_App.BusinessLayer.ContractEmployee> ContractEmployee { get; set; }

        public DbSet<Contract_Employee_Payments_Core_App.BusinessLayer.Project> Project { get; set; }

        public DbSet<Contract_Employee_Payments_Core_App.BusinessLayer.TimeRecord> TimeRecord { get; set; }
    }
}
