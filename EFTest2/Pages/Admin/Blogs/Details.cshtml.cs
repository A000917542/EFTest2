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
    public class DetailsModel : PageModel
    {
        private readonly EFTest2.Data.EFTest2Context _context;

        public DetailsModel(EFTest2.Data.EFTest2Context context)
        {
            _context = context;
        }

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
    }
}
