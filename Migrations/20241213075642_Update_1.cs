using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class Update_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetail",
                table: "orderdetail");

            migrationBuilder.RenameTable(
                name: "orderdetail",
                newName: "orderDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderDetail",
                table: "orderDetail",
                column: "OrderDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderDetail",
                table: "orderDetail");

            migrationBuilder.RenameTable(
                name: "orderDetail",
                newName: "orderdetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderdetail",
                table: "orderdetail",
                column: "OrderDetailId");
        }
    }
}
