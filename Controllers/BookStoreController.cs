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
            var books = await _context.Books
                .Include(b => b.Category)   // Load Category Table
                .Include(b => b.Publisher)  // Load Publisher Table
                .ToListAsync();

            if (books is null)
            {
                return Problem("Entity is BookStoreV20Context is null");
            }

            return View(books);
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

        // GET: BookStore/Edit/{id}
        public IActionResult Edit()
        {
            return View();
        }

        // GET: BookStore/Delete/
        [HttpGet]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> DeleteForm(string? id)
        {
            // Validation
            var SelectedBook = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(b => b.BookId == id);
            if (SelectedBook != null) // FOUND!
            {
                return View("Delete", SelectedBook);
            }
            else
            {
                TempData["ErrorMessage"] = "The book you are trying to delete does not exist.";
                return RedirectToAction(nameof(Index));
            }
        }


        // POST: BookStore/Delete/{BookId}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(string BookId)
        {
            if (BookId == null)
            {
                return NotFound();
            }

            // Validation
            var SelectedBook = await _context.Books.FindAsync(BookId);
            if (SelectedBook != null) // FOUND! 
            {
                _context.Remove(SelectedBook);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Book deleted successfully.";
            }
            else // NOT FOUND!
            {
                return NotFound("This book is not found!");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
