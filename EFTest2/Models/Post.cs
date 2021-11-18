using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFTest2.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }
        
        public DateTime? PublishDate { get; set; }

        public bool IsPublished { get; set; } = false;

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}
