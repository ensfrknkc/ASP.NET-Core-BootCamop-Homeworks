using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class ContentViewModel
    {
        public int Id { get; set; }
        public List<Category> Categories { get; set; }
        public string Title { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Article { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
