using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AST.WebApplication.Data;
using RazorPagesAppeals.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AST.WebApplication
{
    public class IndexModel : PageModel
    {
        private readonly AST.WebApplication.Data.ASTWebApplicationContext _context;

        public IndexModel(AST.WebApplication.Data.ASTWebApplicationContext context)
        {
            _context = context;
        }

        public IList<LogAppeal> LogAppeal { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string AppealType { get; set; }

        public async Task OnGetAsync()
        {
            LogAppeal = await _context.LogAppeal.ToListAsync();
        }
    }
}
