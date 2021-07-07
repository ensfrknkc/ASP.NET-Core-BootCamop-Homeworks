using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {

        public BlogRepository(BlogDbContext context) : base(context)
        {

        }

        public async Task AddWithCategories(Blog blog)
        {
            _context.Categories.AttachRange(blog.Categories);

            await base.Add(blog);

        }

        public List<Blog> GetAllByCategory(int categoryId)
        {

            return _context.Blogs.Where(x => x.Categories.Any(y => y.Id == categoryId && y.Status)).ToList();
        }

        
    }
}
