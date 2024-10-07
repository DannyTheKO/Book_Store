using Microsoft.AspNetCore.Mvc;
using Book_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Controllers
{
    public class BookStoreController : Controller
    {
        //Create a List
        private readonly BookStoreV20Context _context;

        public BookStoreController(BookStoreV20Context context)
        {
            _context = context;
        }



        // GET: BookStore/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (_context is null)
            {
                return Problem("Entity is BookStoreV20Context is null");
            }

            return View(await _context.Books.ToListAsync());
        }

        // GET: BookStore/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookStore/Create/{id}
        [HttpPost("BookStore/Create")]
        public async Task<IActionResult> Create([Bind("BookId", "CategoryId", "PublisherId", "Title", "Author", "Release", "Price", "Picture")] Book book)
		{
			if (ModelState.IsValid)
			{
				_context.Add(book);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			return View(book);
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
