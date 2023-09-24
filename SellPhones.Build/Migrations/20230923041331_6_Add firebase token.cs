using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellPhones.Build.Migrations
{
    public partial class _6_Addfirebasetoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<string>(
                name: "FirebaseTokenWeb",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialId",
                table: "Users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirebaseTokenWeb",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SocialId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "OperatorSystem",
                table: "Smartphone",
                newName: "Operator_System");
        }
    }
}
