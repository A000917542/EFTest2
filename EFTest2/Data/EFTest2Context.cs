using EFTest2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTest2.Data
{
    public class EFTest2Context : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }

        public EFTest2Context(DbContextOptions<EFTest2Context> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    // builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Blogging2;Integrated Security=true;");
        //    // builder.UseSqlite(@"Data Source=c:\Temp\blogging2.db");
        //}
    }
}
