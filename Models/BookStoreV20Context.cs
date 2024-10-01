using System;
using System.Collections.Generic;
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

    public virtual DbSet<Orderbook> Orderbooks { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=127.0.0.1;Database=book_store_v2.0;User=root;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PRIMARY");

            entity.ToTable("account");

            entity.Property(e => e.AccountId).HasMaxLength(36);
            entity.Property(e => e.Active).HasColumnType("bit(1)");
            entity.Property(e => e.Address).HasMaxLength(512);
            entity.Property(e => e.Email).HasMaxLength(64);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsAdmin).HasColumnType("bit(1)");
            entity.Property(e => e.Password).HasMaxLength(256);
            entity.Property(e => e.Phone).HasMaxLength(64);
            entity.Property(e => e.Picture).HasMaxLength(512);
            entity.Property(e => e.Usernane).HasMaxLength(64);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PRIMARY");

            entity.ToTable("book");

            entity.HasIndex(e => e.CategoryId, "Category_KEY");

            entity.HasIndex(e => e.PublisherId, "Publisher_KEY");

            entity.Property(e => e.BookId).HasMaxLength(10);
            entity.Property(e => e.Author).HasMaxLength(255);
            entity.Property(e => e.Picture).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.CategoryName).HasMaxLength(255);
        });

        modelBuilder.Entity<Orderbook>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("orderbook");

            entity.HasIndex(e => e.AccountId, "Account_KEY");

            entity.Property(e => e.OrderId).HasMaxLength(16);
            entity.Property(e => e.AccountId).HasMaxLength(36);
            entity.Property(e => e.Note).HasMaxLength(512);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderReceive).HasColumnType("datetime");
            entity.Property(e => e.ReceiveAddress).HasMaxLength(512);
            entity.Property(e => e.ReceivePhone).HasMaxLength(64);
            entity.Property(e => e.Status).HasMaxLength(16);
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PRIMARY");

            entity.ToTable("orderdetail");

            entity.HasIndex(e => e.BookId, "Book_KEY");

            entity.HasIndex(e => e.OrderId, "Order_KEY");

            entity.Property(e => e.BookId).HasMaxLength(10);
            entity.Property(e => e.OrderId).HasMaxLength(16);
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.PublisherId).HasName("PRIMARY");

            entity.ToTable("publisher");

            entity.Property(e => e.Address).HasMaxLength(45);
            entity.Property(e => e.Phone).HasMaxLength(45);
            entity.Property(e => e.PublisherName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
