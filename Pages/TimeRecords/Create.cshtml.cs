using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Contract_Employee_Payments_Core_App.BusinessLayer;
using Contract_Employee_Payments_Core_App.Models;

namespace Contract_Employee_Payments_Core_App.Pages.TimeRecords
{
    public class CreateModel : PageModel
    {
        private readonly Contract_Employee_Payments_Core_App.Models.Contract_Employee_PaymentsDataContext _context;

        public CreateModel(Contract_Employee_Payments_Core_App.Models.Contract_Employee_PaymentsDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ContractEmployeeId"] = new SelectList(_context.ContractEmployee, "Id", "Name");
        ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "ProjectCode");
            return Page();
        }

        [BindProperty]
        public TimeRecord TimeRecord { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TimeRecord.Add(TimeRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
