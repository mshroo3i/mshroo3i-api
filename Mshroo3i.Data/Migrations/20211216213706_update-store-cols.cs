using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mshroo3i.Data.Migrations
{
    public partial class updatestorecols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stores",
                newName: "NameAr");

            migrationBuilder.AddColumn<string>(
                name: "WhatsAppUri",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "Stores",
                newName: "Name");
            
            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Stores");
            
            migrationBuilder.DropColumn(
                name: "WhatsAppUri",
                table: "Stores");
        }
    }
}
