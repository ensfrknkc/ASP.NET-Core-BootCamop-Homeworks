using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Models
{
    public class Blog : Entity
    {
        public string Title { get; set; }
        //public int CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        public virtual List<Category> Categories { get; set; }
        public string Article { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int UserId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
