using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int ContentId { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
    }
}
