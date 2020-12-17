using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contract_Employee_Payments_Core_App.BusinessLayer;
using Contract_Employee_Payments_Core_App.Models;

namespace Contract_Employee_Payments_Core_App.Pages.TimeRecords
{
    public class EditModel : PageModel
    {
        private readonly Contract_Employee_Payments_Core_App.Models.Contract_Employee_PaymentsDataContext _context;

        public EditModel(Contract_Employee_Payments_Core_App.Models.Contract_Employee_PaymentsDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TimeRecord TimeRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TimeRecord = await _context.TimeRecord
                .Include(t => t.ContractEmployee)
                .Include(t => t.Project).FirstOrDefaultAsync(m => m.Id == id);

            if (TimeRecord == null)
            {
                return NotFound();
            }
           ViewData["ContractEmployeeId"] = new SelectList(_context.ContractEmployee, "Id", "Name");
           ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "ProjectCode");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TimeRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeRecordExists(TimeRecord.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TimeRecordExists(int id)
        {
            return _context.TimeRecord.Any(e => e.Id == id);
        }
    }
}
