using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTest2.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }
        
        public DateTime? PublishDate { get; set; }

        public bool IsPublished { get; set; } = false;

        public string Content { get; set; }

        public Blog Blog { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}
