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
    public class DetailsModel : PageModel
    {
        private readonly AST.WebApplication.Data.ASTWebApplicationContext _context;

        public DetailsModel(AST.WebApplication.Data.ASTWebApplicationContext context)
        {
            _context = context;
        }

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
    }
}
