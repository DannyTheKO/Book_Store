using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

		private async Task PopulateViewBag()
		{
			ViewBag.Categories = await _context.Categories.ToListAsync();
			ViewBag.Publishers = await _context.Publishers.ToListAsync();
		}

		public class BookForm
		{
			[DisplayName("Category ID")]
			[Required(ErrorMessage = "Category Is required")]
			public int? CategoryId { get; set; }

			[DisplayName("Publisher ID")]
			[Required(ErrorMessage = "Publisher is required")]
			public int? PublisherId { get; set; }

			[DisplayName("Title")]
			[Required(ErrorMessage = "Title is required")]
			public string? Title { get; set; }

			[DisplayName("Author")]
			[Required(ErrorMessage = "Author is required")]
			public string? Author { get; set; }

			[DisplayName("Release Date")]
			[DataType(DataType.Date)]
			[Required(ErrorMessage = "Release Date is required")]
			public DateTime? Release { get; set; }

			[DisplayName("Price")]
			[Required(ErrorMessage = "Price is required")]
			public float? Price { get; set; }

			[DisplayName("Description")]
			[MaxLength(1024)]
			public string? Description { get; set; }

			[DisplayName("Picture")]
			public string? Picture { get; set; }
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
				return View("Index", TempData["ErrorMessage"] = "Database is empty?");
			}

			return View("Index", books);
		}

		// GET: BookStore/CreateForm
		[HttpGet("CreateForm")]
		public async Task<IActionResult> CreateForm()
		{
			await PopulateViewBag();
			return View("CreateForm");
		}

		// POST: BookStore/Create/
		[HttpPost("Create")]
		public async Task<IActionResult> Create(BookForm bookForm)
		{
			if (!ModelState.IsValid)
			{
				await PopulateViewBag();
				return View("CreateForm", TempData["ErrorMessage"] = "Failed to add books");
			}

			var book = new Book();
			await book.Initialize(bookForm);

			_context.Add(book);
			await _context.SaveChangesAsync();
			TempData["SuccessMessage"] = $"Book ID: {book.BookId} Added";
			return RedirectToAction("Index");
		}

		// GET: BookStore/Edit/{id}
		[HttpGet("EditForm")]
		public async Task<IActionResult> EditForm(int bookId)
		{
			var book = await _context.Books.FindAsync(bookId);
			if (book is null)
			{
				return RedirectToAction("Index", TempData["ErrorMessage"] = "Books not exist ?");
			}

			await PopulateViewBag();
			return View("EditForm", book);
		}

		// POST: BookStore/Edit/{bookId}
		[HttpPost("Edit")]
		public async Task<IActionResult> Edit(Book editedBook)
		{
			var book = await _context.Books.FindAsync(editedBook.BookId);
			if (book is null)
			{
				TempData["ErrorMessage"] = "Fail!";
				return View("EditForm", editedBook);
			}

			book.CategoryId = editedBook.CategoryId;
			book.PublisherId = editedBook.PublisherId;
			book.Title = editedBook.Title;
			book.Author = editedBook.Author;
			book.Release = editedBook.Release;
			book.Price = editedBook.Price;
			book.Description = editedBook.Description;
			book.Picture = editedBook.Picture;

			_context.Books.Update(book);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index",
				TempData["SuccessMessage"] = $"Book ID: {editedBook.BookId} has been edited");
		}

		// GET: BookStore/Delete/{BookId}
		[HttpGet("Delete")]
		public async Task<IActionResult> Delete([FromQuery] int bookId)
		{
			// Validation
			var SelectedBook = await _context.Books.FindAsync(bookId);
			if (SelectedBook == null) // FOUND! 
			{
				return RedirectToAction("Index", TempData["ErrorMessage"] = "Book is not found!");
			}

			_context.Remove(SelectedBook);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index", TempData["SuccessMessage"] = "Book deleted successfully.");
		}
	}
}
