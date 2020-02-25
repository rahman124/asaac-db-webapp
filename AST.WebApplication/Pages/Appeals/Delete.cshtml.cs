using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AST.WebApplication.Data;
using RazorPagesAppeals.Models;

namespace AST.WebApplication
{
    public class DeleteModel : PageModel
    {
        private readonly AST.WebApplication.Data.ASTWebApplicationContext _context;

        public DeleteModel(AST.WebApplication.Data.ASTWebApplicationContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LogAppeal = await _context.LogAppeal.FindAsync(id);

            if (LogAppeal != null)
            {
                _context.LogAppeal.Remove(LogAppeal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
