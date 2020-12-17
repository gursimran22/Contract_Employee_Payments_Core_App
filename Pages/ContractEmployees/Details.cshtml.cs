using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Contract_Employee_Payments_Core_App.BusinessLayer;
using Contract_Employee_Payments_Core_App.Models;

namespace Contract_Employee_Payments_Core_App.Pages.ContractEmployees
{
    //get details of employee
    public class DetailsModel : PageModel
    {
        private readonly Contract_Employee_Payments_Core_App.Models.Contract_Employee_PaymentsDataContext _context;

        public DetailsModel(Contract_Employee_Payments_Core_App.Models.Contract_Employee_PaymentsDataContext context)
        {
            _context = context;
        }

        public ContractEmployee ContractEmployee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContractEmployee = await _context.ContractEmployee.FirstOrDefaultAsync(m => m.Id == id);

            if (ContractEmployee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
