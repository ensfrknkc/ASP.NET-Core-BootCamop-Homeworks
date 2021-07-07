using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Content
    {
        public int Id { get; set; }
        public ICollection<Category> Categories { get; set; }
        public string Title { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Article { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
