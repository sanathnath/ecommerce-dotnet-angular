using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductTitle",
                table: "Products",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                table: "Products",
                newName: "Quantity");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discount",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Products",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Products",
                newName: "ProductTitle");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "ProductDescription");
        }
    }
}
