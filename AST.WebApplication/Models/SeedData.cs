using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AST.WebApplication.Data;
using System;
using System.Linq;

namespace RazorPagesAppeals.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ASTWebApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ASTWebApplicationContext>>()))
            {
                // Look for any appeals.
                if (context.LogAppeal.Any())
                {
                    return;   // DB has been seeded
                }

                context.LogAppeal.AddRange(
                    new RazorPagesAppeals.Models.LogAppeal
                    {
                        FirstName = "Mister",
                        LastName = "Milton",
                        Nationality = "British",
                        DateOfBirth = DateTime.Parse("1989-2-12")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}