using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class InitialSqlServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", maxLength: 36, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IsAdmin = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Active = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "publisher",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publisher", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "orderBook",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", maxLength: 16, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    ReceiveAddress = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ReceivePhone = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    OrderReceive = table.Column<DateTime>(type: "datetime", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderBook", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_ OrderBook_Account",
                        column: x => x.AccountId,
                        principalTable: "account",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    PublisherId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Release = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Book_Category",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_Book_Publisher",
                        column: x => x.PublisherId,
                        principalTable: "publisher",
                        principalColumn: "PublisherId");
                });

            migrationBuilder.CreateTable(
                name: "orderdetail",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    OrderId = table.Column<int>(type: "int", maxLength: 16, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    TotalMoney = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderdetail", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Book",
                        column: x => x.BookId,
                        principalTable: "book",
                        principalColumn: "BookId");
                    table.ForeignKey(
                        name: "FK_OrderDetail_OrderBook",
                        column: x => x.OrderId,
                        principalTable: "orderBook",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateIndex(
                name: "Category_KEY",
                table: "book",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "Publisher_KEY",
                table: "book",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "Account_KEY",
                table: "orderBook",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "Book_KEY",
                table: "orderdetail",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "Order_KEY",
                table: "orderdetail",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderdetail");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "orderBook");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "publisher");

            migrationBuilder.DropTable(
                name: "account");
        }
    }
}
