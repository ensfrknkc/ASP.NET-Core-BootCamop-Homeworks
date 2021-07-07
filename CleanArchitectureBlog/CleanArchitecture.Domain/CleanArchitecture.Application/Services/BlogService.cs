using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModel;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository = null;
        private readonly IMapper _mapper;
        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<bool> Add(BlogViewModel blog)
        {
            //List<Category> categories = new List<Category>();
            //foreach (var item in blog.Categories)
            //{
            //    categories.Add(new Category { Id = item.Id });
            //}
            blog.Categories = blog.SelectedCategories.Select(x => new CategoryViewModel { Id = x }).ToList();

            int id = await _blogRepository.Add(new Domain.Models.Blog { Article = blog.Article,
                CreatedAt = DateTime.Now, Title = blog.Title, UserId = blog.UserId, 
                Categories = _mapper.Map<List<Category>>(blog.Categories)});
            return id > 0;
        }

        public async Task AddWithCategories(BlogViewModel blog)
        {
            blog.Categories = blog.SelectedCategories.Select(x => new CategoryViewModel { Id = x }).ToList();
            await _blogRepository.AddWithCategories(_mapper.Map<Blog>(blog));
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BlogViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<BlogViewModel> GetAllByCategory(int categoryId)
        {
            List<BlogViewModel> blogs = new List<BlogViewModel>();
            var currentBlogs = _blogRepository.GetAllByCategory(categoryId);

            foreach (var item in currentBlogs)
            {
                //List<CategoryViewModel> categories = new List<CategoryViewModel>();
                //foreach (var category in item.Categories)
                //{
                //    categories.Add(new CategoryViewModel { Description = category.Description, Id=category.Id, Name=category.Name, Status=category.Status });
                //}


                blogs.Add(new BlogViewModel { Article = item.Article, Title = item.Title,
                    Categories = _mapper.Map<List<CategoryViewModel>>(item.Categories) });
            }
           return blogs;
        }

        public BlogViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(BlogViewModel entity)
        {
            throw new NotImplementedException();
        }

      
    }
}
