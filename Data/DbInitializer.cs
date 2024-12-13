using Book_Store.Models;

public static class DbInitializer
{
	public static void Initialize(BookStoreV20Context context)
	{
		// Ensure database is created
		context.Database.EnsureCreated();

		// Check if there's already data
		if (context.Books.Any())
			return;

		// Add Categories
		var categories = new Category[]
		{
			new Category { CategoryName = "Fiction" },
			new Category { CategoryName = "Non-Fiction" },
			new Category { CategoryName = "Science" },
			new Category { CategoryName = "Technology" }
		};
		context.Categories.AddRange(categories);

		// Add Publishers
		var publishers = new Publisher[]
		{
			new Publisher { PublisherName = "Tech Books Inc", Phone = "123-456-7890", Address = "123 Tech Street" },
			new Publisher { PublisherName = "Science Press", Phone = "098-765-4321", Address = "456 Science Avenue" }
		};
		context.Publishers.AddRange(publishers);

		// Save changes to get IDs
		context.SaveChanges();

		// Add Books
		var books = new Book[]
		{
			new Book {
				Title = "C# Programming",
				Author = "John Doe",
				CategoryId = categories[3].CategoryId,
				PublisherId = publishers[0].PublisherId,
				Release = 2023,
				Price = 49.99f,
				Description = "Complete C# programming guide"
			},
			new Book {
				Title = "Physics Fundamentals",
				Author = "Jane Smith",
				CategoryId = categories[2].CategoryId,
				PublisherId = publishers[1].PublisherId,
				Release = 2023,
				Price = 39.99f,
				Description = "Basic physics concepts"
			}
		};
		context.Books.AddRange(books);
		context.SaveChanges();
	}
}