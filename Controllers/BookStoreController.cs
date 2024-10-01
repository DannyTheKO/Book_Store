using Microsoft.AspNetCore.Mvc;
using Book_Store.Models;

namespace Book_Store.Controllers
{
    public class BookStoreController : Controller
    {
        //Create a List
        List<Book> book_list = new List<Book>()
            {
                new Book
                {
                    BookId = "1",
                    CategoryId = 1,
                    PublisherId = 1,
                    Title = "Book Title",
                    Author = "Book Author",
                    Release = 2022,
                    Price = 19.99f,
                    Description = "Book Description",
                    Picture = "book.jpg"
                }
            };

        // GET: BookStore/Index
        public IActionResult Index()
        {
            return View(book_list);
        }

        // GET: BookStore/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET BookStore/Edit/{id}
        public IActionResult Edit()
        {
            return View();
        }

        // GET BookStore/Delete/{id}
        public IActionResult Delete()
        {
            return View();
        }
    }
}
