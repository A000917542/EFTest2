using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFTest2.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        
        public string Name { get; set; }
        
        public DateTime? StartDate { get; set; }

        public ICollection<Post> Posts { get; set; }

        [ForeignKey("PrimaryAuthor")]
        [EmailAddress]
        public string PrimaryEmail { get; set; }

        public Author PrimaryAuthor { get; set; }
    }
}
