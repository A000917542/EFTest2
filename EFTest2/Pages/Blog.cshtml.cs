using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EFTest2.Data;
using EFTest2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFTest2.Pages
{
    public class BlogModel : PageModel
    {
        private readonly EFTest2Context db;

        public BlogModel(EFTest2Context dbContext)
        {
            db = dbContext;
        }

        [FromQuery]
        public Blog Blog { get; set; }

        public void OnGet(int id)
        {
            Blog = db.Blogs.Include(blog => blog.PrimaryAuthor).Include(blog => blog.Posts).FirstOrDefault(blog => blog.BlogId == id);
        }
    }
}
