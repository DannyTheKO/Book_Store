using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Controllers
{
	[Route("[controller]")]
	public class BookStoreController : Controller
	{
		private readonly BookStoreV20Context _context;

		public BookStoreController(BookStoreV20Context context)
		{
			_context = context;
		}

		[HttpGet("Index")]
		public async Task<IActionResult> Index()
		{
			var books = await _context.Books
				.Include(b => b.Category)   // Load Category Table
				.Include(b => b.Publisher)  // Load Publisher Table
				.ToListAsync();

			if (books is null)
			{
				return View("Index", TempData["ErrorMessage"] = "Database in empty?");
			}

			return View("Index", books);
		}

		// GET: BookStore/CreateForm
		[HttpGet("CreateForm")]
		public IActionResult CreateForm()
		{
			return View("CreateForm");
		}

		// POST: BookStore/Create/{id}
		[HttpPost("BookStore/Create")]
		public async Task<IActionResult> Create([Bind("CategoryId", "PublisherId", "Title", "Author", "Release", "Price", "Picture")] Book book)
		{
			if (ModelState.IsValid)
			{
				_context.Add(book);
				await _context.SaveChangesAsync();

				return View("Index", TempData["SuccessMessage"] = "Successfully added books");
			}

			return View("Index");
		}

		// GET: BookStore/Edit/{id}
		[HttpGet("EditForm")]
		public IActionResult EditForm()
		{
			return View("EditForm");
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
