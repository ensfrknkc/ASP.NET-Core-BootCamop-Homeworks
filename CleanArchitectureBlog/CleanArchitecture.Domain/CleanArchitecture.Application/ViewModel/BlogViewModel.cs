using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.ViewModel
{
    public class BlogViewModel
    {
        public string Title { get; set; }
        //public int CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        public List<CategoryViewModel> Categories { get; set; }
        public List<int> SelectedCategories { get; set; }
        public List<TagViewModel> Tags { get; set; }
        public List<int> SelectedTags { get; set; }
        public string Article { get; set; }

        public string UserName { get; set; }
        public int UserId { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
