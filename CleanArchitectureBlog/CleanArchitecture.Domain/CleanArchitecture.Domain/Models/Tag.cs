using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Models
{
    public class Tag : Entity
    {
        public virtual  ICollection<Blog> Blogs { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
