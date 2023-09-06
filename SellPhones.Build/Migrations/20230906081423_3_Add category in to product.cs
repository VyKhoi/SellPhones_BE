using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellPhones.Build.Migrations
{
    public partial class _3_Addcategoryintoproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Product",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Product");
        }
    }
}