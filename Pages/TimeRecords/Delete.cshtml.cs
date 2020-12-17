using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Contract_Employee_Payments_Core_App.BusinessLayer;
using Contract_Employee_Payments_Core_App.Models;

namespace Contract_Employee_Payments_Core_App.Pages.TimeRecords
{
    public class DeleteModel : PageModel
    {
        private readonly Contract_Employee_Payments_Core_App.Models.Contract_Employee_PaymentsDataContext _context;

        public DeleteModel(Contract_Employee_Payments_Core_App.Models.Contract_Employee_PaymentsDataContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TimeRecord = await _context.TimeRecord.FindAsync(id);

            if (TimeRecord != null)
            {
                _context.TimeRecord.Remove(TimeRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
