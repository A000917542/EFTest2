using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFTest2.Data;
using EFTest2.Models;

namespace EFTest2.Areas.Admin.Pages.Blogs
{
    public class DeleteModel : PageModel
    {
        private readonly EFTest2.Data.EFTest2Context _context;

        public DeleteModel(EFTest2.Data.EFTest2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Blog Blog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog = await _context.Blogs
                .Include(b => b.PrimaryAuthor).FirstOrDefaultAsync(m => m.BlogId == id);

            if (Blog == null)
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

            Blog = await _context.Blogs.FindAsync(id);

            if (Blog != null)
            {
                _context.Blogs.Remove(Blog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
