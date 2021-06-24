using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class SacramentsCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SacramentId",
                table: "Histories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Histories_SacramentId",
                table: "Histories",
                column: "SacramentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Sacraments_SacramentId",
                table: "Histories",
                column: "SacramentId",
                principalTable: "Sacraments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Sacraments_SacramentId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_SacramentId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "SacramentId",
                table: "Histories");
        }
    }
}
