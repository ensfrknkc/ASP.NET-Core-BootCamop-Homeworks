using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Controllers
{
    public class ContentController : Controller
    {      
        private readonly ContentContext _context = null;
        public ContentController(ContentContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Add()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(Content model)
        {
            await _context.Contents.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Contents()
        {
            ViewBag.Contents = await _context.Contents.ToListAsync();
            //ViewBag.Contents.Clear();
            return View();
        }
        public async Task<IActionResult> ContentDetail(int id)
        {
            var contents = await _context.Contents.ToListAsync();
            var contentt= contents.Where(e => e.Id == id).ToList().FirstOrDefault();
            ViewBag.ContentDetail = contentt;
            try
            {
                ViewBag.Comments = await _context.Comments.ToListAsync();
            }
            catch (Exception)
            {

            }
            
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {                    
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Contents");
        }
    }
}
