using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class ChristeningSacramentName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SacramentTypeId",
                table: "Christenings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Christenings_SacramentTypeId",
                table: "Christenings",
                column: "SacramentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Christenings_SacramentTypes_SacramentTypeId",
                table: "Christenings",
                column: "SacramentTypeId",
                principalTable: "SacramentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Christenings_SacramentTypes_SacramentTypeId",
                table: "Christenings");

            migrationBuilder.DropIndex(
                name: "IX_Christenings_SacramentTypeId",
                table: "Christenings");

            migrationBuilder.DropColumn(
                name: "SacramentTypeId",
                table: "Christenings");
        }
    }
}
