using Microsoft.AspNetCore.Mvc;
using Book_Store.Models;

namespace Book_Store.Controllers
{
    public class BookStoreController : Controller
    {
        //Create a List
        List<Book> book_list = new List<Book>()
                {
                    new Book {Id = 1, Title = "Continuous Delivery", Author = "Jez Humble & David Farley", Publisher = "Addison-Wesley Professional; 1st edition", Avaliable = 198, Price = 78.32M, CreateOn = new DateOnly(2010, 8, 1), IsActive = ActiveStatus.N, GenreId = 1}
                };

        public IActionResult Index()
        {
            return View(book_list);
        }

        public IActionResult Create()
        {
            return View(book_list);
        }

        public IActionResult Edit()
        {
            return View(book_list);
        }

        public IActionResult Delete()
        {
            return View(book_list);
        }
    }
}
