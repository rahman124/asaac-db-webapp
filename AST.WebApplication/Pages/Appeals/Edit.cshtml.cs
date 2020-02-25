using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AST.WebApplication.Data;
using RazorPagesAppeals.Models;

namespace AST.WebApplication
{
    public class EditModel : PageModel
    {
        private readonly AST.WebApplication.Data.ASTWebApplicationContext _context;

        public EditModel(AST.WebApplication.Data.ASTWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LogAppeal LogAppeal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LogAppeal = await _context.LogAppeal.FirstOrDefaultAsync(m => m.ID == id);

            if (LogAppeal == null)
            {
                return NotFound();
            }
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

            _context.Attach(LogAppeal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogAppealExists(LogAppeal.ID))
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

        private bool LogAppealExists(int id)
        {
            return _context.LogAppeal.Any(e => e.ID == id);
        }
    }
}
