using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTutorial.Migrations
{
    public partial class update_customer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Reviewer",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Reviewer",
                table: "Customers",
                nullable: false,
                defaultValue: false);
        }
    }
}
