using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mshroo3i.Data.Migrations
{
    public partial class addproductsection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductSectionId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSections_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSectionId",
                table: "Products",
                column: "ProductSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSections_Name",
                table: "ProductSections",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSections_StoreId",
                table: "ProductSections",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSections_ProductSectionId",
                table: "Products",
                column: "ProductSectionId",
                principalTable: "ProductSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSections_ProductSectionId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductSections");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductSectionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductSectionId",
                table: "Products");
        }
    }
}
