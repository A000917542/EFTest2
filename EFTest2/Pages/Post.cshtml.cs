using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFTest2.Data;
using EFTest2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EFTest2.Pages
{
    public class PostModel : PageModel
    {
        private readonly EFTest2Context db;

        public PostModel(EFTest2Context dbContext)
        {
            db = dbContext;
        }

        [FromQuery]
        public Post Post { get; set; }

        public void OnGet(int id)
        {
            Post = db.Posts.Include(post => post.Authors).Include(post => post.Blog).Include(post => post.Blog.PrimaryAuthor).FirstOrDefault(post => post.PostId == id);
        }
    }
}
