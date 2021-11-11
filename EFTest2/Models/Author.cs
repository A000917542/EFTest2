using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFTest2.Models
{
    public class Author
    {
        [Key]
        [EmailAddress]
        public string Email { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<Blog> Blogs { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
