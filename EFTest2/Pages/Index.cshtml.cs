using EFTest2.Data;
using EFTest2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTest2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly EFTest2Context db;

        [FromForm]
        public Blog Blog { get; set; }

        public List<Blog> BlogList { get; set; }

        public IndexModel(ILogger<IndexModel> logger, EFTest2Context dbContext)
        {
            _logger = logger;
            db = dbContext;
        }

        public void OnGet()
        {
            var query = db.Blogs;
            BlogList = query.ToList();
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(Blog);
                db.SaveChanges();
            }

            BlogList = db.Blogs.ToList();
        }
    }
}
