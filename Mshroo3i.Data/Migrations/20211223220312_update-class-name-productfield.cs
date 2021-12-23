using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mshroo3i.Data.Migrations
{
    public partial class updateclassnameproductfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductOptionId",
                table: "ProductFieldOptions",
                newName: "ProductFieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductFieldId",
                table: "ProductFieldOptions",
                newName: "ProductOptionId");
        }
    }
}
