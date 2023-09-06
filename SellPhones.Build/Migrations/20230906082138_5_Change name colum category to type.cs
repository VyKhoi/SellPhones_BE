using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellPhones.Build.Migrations
{
    public partial class _5_Changenamecolumcategorytotype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Product",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Product",
                newName: "Category");
        }
    }
}