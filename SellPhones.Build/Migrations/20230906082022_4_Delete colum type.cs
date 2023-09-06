using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellPhones.Build.Migrations
{
    public partial class _4_Deletecolumtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Product",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}