using Microsoft.EntityFrameworkCore.Migrations;

namespace Mshroo3i.Data.Migrations
{
    public partial class addindex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_stores_shortcode",
                table: "stores",
                column: "shortcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_stores_shortcode",
                table: "stores");
        }
    }
}
