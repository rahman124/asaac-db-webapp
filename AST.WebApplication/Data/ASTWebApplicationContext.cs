using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesAppeals.Models;

namespace AST.WebApplication.Data
{
    public class ASTWebApplicationContext : DbContext
    {
        public ASTWebApplicationContext (DbContextOptions<ASTWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesAppeals.Models.LogAppeal> LogAppeal { get; set; }
    }
}
