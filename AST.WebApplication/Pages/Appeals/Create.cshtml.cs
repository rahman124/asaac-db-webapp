using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AST.WebApplication.Data;
using RazorPagesAppeals.Models;

namespace AST.WebApplication
{
    public class CreateModel : PageModel
    {
        private readonly AST.WebApplication.Data.ASTWebApplicationContext _context;

        public CreateModel(AST.WebApplication.Data.ASTWebApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LogAppeal LogAppeal { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LogAppeal.Add(LogAppeal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
