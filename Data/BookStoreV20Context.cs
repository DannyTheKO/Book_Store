using Microsoft.EntityFrameworkCore;

namespace Book_Store.Models;

public partial class BookStoreV20Context : DbContext
{
	public BookStoreV20Context()
	{
	}

	public BookStoreV20Context(DbContextOptions<BookStoreV20Context> options)
		: base(options)
	{
	}

	public virtual DbSet<Account> Accounts { get; set; }

	public virtual DbSet<Book> Books { get; set; }

	public virtual DbSet<Category> Categories { get; set; }

	public virtual DbSet<OrderBook> OrderBook { get; set; }

	public virtual DbSet<Orderdetail> OrderDetail { get; set; }

	public virtual DbSet<Publisher> Publishers { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Account>(entity =>
		{
			entity.HasKey(e => e.AccountId);
			entity.Property(e => e.AccountId).ValueGeneratedOnAdd();

			entity.ToTable("account");

			entity.Property(e => e.AccountId).HasMaxLength(36);
			entity.Property(e => e.Address).HasMaxLength(512);
			entity.Property(e => e.Email).HasMaxLength(64);
			entity.Property(e => e.FullName).HasMaxLength(100);
			entity.Property(e => e.Password).HasMaxLength(256);
			entity.Property(e => e.Phone).HasMaxLength(64);
			entity.Property(e => e.Picture).HasMaxLength(512);
			entity.Property(e => e.Username).HasMaxLength(64);

			entity.Property(e => e.IsAdmin).HasMaxLength(1);
			entity.Property(e => e.Active).HasMaxLength(1);
		});

		modelBuilder.Entity<Book>(entity =>
		{
			entity.HasKey(e => e.BookId);
			entity.Property(e => e.BookId).ValueGeneratedOnAdd();

			entity.ToTable("book");

			entity.HasIndex(e => e.CategoryId, "Category_KEY");

			entity.HasIndex(e => e.PublisherId, "Publisher_KEY");

			entity.Property(e => e.BookId).HasMaxLength(10);
			entity.Property(e => e.Author).HasMaxLength(255);
			entity.Property(e => e.Description);
			entity.Property(e => e.Picture).HasMaxLength(255);
			entity.Property(e => e.Title).HasMaxLength(255);

			entity.HasOne(d => d.Category).WithMany(p => p.Books)
				.HasForeignKey(d => d.CategoryId)
				.HasConstraintName("FK_Book_Category");

			entity.HasOne(d => d.Publisher).WithMany(p => p.Books)
				.HasForeignKey(d => d.PublisherId)
				.HasConstraintName("FK_Book_Publisher");
		});

		modelBuilder.Entity<Category>(entity =>
		{
			entity.HasKey(e => e.CategoryId);
			entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();

			entity.ToTable("category");

			entity.Property(e => e.CategoryName).HasMaxLength(255);
		});

		modelBuilder.Entity<OrderBook>(entity =>
		{
			entity.HasKey(e => e.OrderId);
			entity.Property(e => e.OrderId).ValueGeneratedOnAdd();

			entity.ToTable("orderBook");

			entity.HasIndex(e => e.AccountId, "Account_KEY");

			entity.Property(e => e.OrderId).HasMaxLength(16);
			entity.Property(e => e.OrderDate).HasColumnType("datetime");
			entity.Property(e => e.OrderReceive).HasColumnType("datetime");
			entity.Property(e => e.ReceiveAddress).HasMaxLength(512);
			entity.Property(e => e.ReceivePhone).HasMaxLength(64);
			entity.Property(e => e.Status).HasMaxLength(16);

			entity.HasOne(d => d.Account).WithMany(p => p.OrderBook)
				.HasForeignKey(d => d.AccountId)
				.HasConstraintName("FK_ OrderBook_Account");
		});


		modelBuilder.Entity<Orderdetail>(entity =>
		{
			entity.HasKey(e => e.OrderDetailId);
			entity.Property(e => e.OrderDetailId).ValueGeneratedOnAdd();

			entity.ToTable("orderDetail");

			entity.HasIndex(e => e.BookId, "Book_KEY");

			entity.HasIndex(e => e.OrderId, "Order_KEY");

			entity.Property(e => e.BookId).HasMaxLength(10);
			entity.Property(e => e.OrderId).HasMaxLength(16);

			entity.HasOne(d => d.Book).WithMany(p => p.OrderDetail)
				.HasForeignKey(d => d.BookId)
				.HasConstraintName("FK_OrderDetail_Book");

			entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
				.HasForeignKey(d => d.OrderId)
				.HasConstraintName("FK_OrderDetail_OrderBook");
		});

		modelBuilder.Entity<Publisher>(entity =>
		{
			entity.HasKey(e => e.PublisherId);
			entity.Property(e => e.PublisherId).ValueGeneratedOnAdd();

			entity.ToTable("publisher");

			entity.Property(e => e.Address).HasMaxLength(45);
			entity.Property(e => e.Phone).HasMaxLength(45);
			entity.Property(e => e.PublisherName).HasMaxLength(255);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
