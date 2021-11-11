using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFTest2.Data;
using EFTest2.Models;

namespace EFTest2.Areas.Admin.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly EFTest2.Data.EFTest2Context _context;

        public DetailsModel(EFTest2.Data.EFTest2Context context)
        {
            _context = context;
        }

        public Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = await _context.Authors.FirstOrDefaultAsync(m => m.Email == id);

            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
