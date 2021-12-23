using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mshroo3i.Data.Migrations
{
    public partial class renametoproductfieldoption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Options",
                schema: "dbo",
                newName: "ProductFieldOptions"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ProductFieldOptions",
                schema: "dbo",
                newName: "Options"
            );
        }
    }
}
