using BookSession.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSession.Controllers
{
    public class BookController : Controller
    {
        List<BookViewModel> books;
        public BookController()
        {
            books = new List<BookViewModel>()
            {
                new BookViewModel
                {
                    bookName="Ktp1",
                    author="Enes"
                },
                new BookViewModel
                {
                    bookName="Ktp2",
                    author="Furkan"
                }
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {

            books.Add(model);

            if (HttpContext.Session.Get<List<BookViewModel>>("books") == default)
            {
                HttpContext.Session.Set<List<BookViewModel>>("books", books);
            }
            return View("Listeleme", books);
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(SearchViewModel model)
        {
            List<BookViewModel> books = HttpContext.Session.Get<List<BookViewModel>>("books");
            BookViewModel book = books.FirstOrDefault(x => x.bookName.ToLower() == model.bookName.ToLower());
            ViewBag.Book = book.bookName;
            ViewBag.Author = book.author;
            return View("Search");
        }
        public IActionResult Favori(string bookFav)
        {
            string bookFavName = string.Empty;

            if (Request.Cookies.ContainsKey("bookFavori"))
                bookFavName = Request.Cookies["bookFavori"];
            else
            {
                CookieOptions options = new CookieOptions();
                options.Path = "/";
                options.Expires = new DateTimeOffset(DateTime.Now.AddHours(5));

                Response.Cookies.Append("bookFavori", bookFav, options);
            }
            return View("Listeleme");
        }
    }
}
