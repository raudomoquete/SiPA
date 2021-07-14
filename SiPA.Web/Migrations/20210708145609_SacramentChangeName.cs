using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class SacramentChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "ParishionerFullName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "SacramentName",
                table: "Sacraments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParishionerFullName",
                table: "Sacraments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SacramentName",
                table: "Sacraments",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);
        }
    }
}
