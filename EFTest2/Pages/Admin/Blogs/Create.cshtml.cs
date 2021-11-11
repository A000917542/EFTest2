using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFTest2.Data;
using EFTest2.Models;

namespace EFTest2.Areas.Admin.Pages.Blogs
{
    public class CreateModel : PageModel
    {
        private readonly EFTest2.Data.EFTest2Context _context;

        public CreateModel(EFTest2.Data.EFTest2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PrimaryEmail"] = new SelectList(_context.Authors, "Email", "Email");
            return Page();
        }

        [BindProperty]
        public Blog Blog { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Blogs.Add(Blog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
