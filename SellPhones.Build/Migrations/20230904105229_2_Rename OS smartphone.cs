using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellPhones.Build.Migrations
{
    public partial class _2_RenameOSsmartphone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Operator_System",
                table: "Smartphone",
                newName: "OperatorSystem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Operator_System",
                table: "Smartphone",
                newName: "OperatorSystem");
        }
    }
}