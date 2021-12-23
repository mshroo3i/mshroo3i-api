using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mshroo3i.Data.Migrations
{
    public partial class renametoproductfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ProductOptions",
                newName: "ProductFields");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOptions_ProductId",
                table: "ProductFields",
                newName: "IX_ProductFields_ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ProductFields",
                newName: "ProductOptions");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFields_ProductId",
                table: "ProductOptions",
                newName: "IX_ProductOptions_ProductId");
        }
    }
}
