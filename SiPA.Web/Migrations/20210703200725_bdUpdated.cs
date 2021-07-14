using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class bdUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Christening_FirstName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Christening_LastName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Confirmation_FirstName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Confirmation_LastName",
                table: "Sacraments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Christening_FirstName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Christening_LastName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Confirmation_FirstName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Confirmation_LastName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
