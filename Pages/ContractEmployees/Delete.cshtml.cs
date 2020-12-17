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
    //Removes  a contract employee
    public class DeleteModel : PageModel
    {
        private readonly Contract_Employee_Payments_Core_App.Models.Contract_Employee_PaymentsDataContext _context;

        public DeleteModel(Contract_Employee_Payments_Core_App.Models.Contract_Employee_PaymentsDataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContractEmployee = await _context.ContractEmployee.FindAsync(id);

            if (ContractEmployee != null)
            {
                _context.ContractEmployee.Remove(ContractEmployee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
