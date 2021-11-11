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
    public class IndexModel : PageModel
    {
        private readonly EFTest2.Data.EFTest2Context _context;

        public IndexModel(EFTest2.Data.EFTest2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; }

        public async Task OnGetAsync()
        {
            Author = await _context.Authors.ToListAsync();
        }
    }
}
