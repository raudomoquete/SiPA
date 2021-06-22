using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class CompleteDBWSacraments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sacrament_Parishioners_ParishionerId",
                table: "Sacrament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sacrament",
                table: "Sacrament");

            migrationBuilder.RenameTable(
                name: "Sacrament",
                newName: "Sacraments");

            migrationBuilder.RenameIndex(
                name: "IX_Sacrament_ParishionerId",
                table: "Sacraments",
                newName: "IX_Sacraments_ParishionerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sacraments",
                table: "Sacraments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_Parishioners_ParishionerId",
                table: "Sacraments",
                column: "ParishionerId",
                principalTable: "Parishioners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Parishioners_ParishionerId",
                table: "Sacraments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sacraments",
                table: "Sacraments");

            migrationBuilder.RenameTable(
                name: "Sacraments",
                newName: "Sacrament");

            migrationBuilder.RenameIndex(
                name: "IX_Sacraments_ParishionerId",
                table: "Sacrament",
                newName: "IX_Sacrament_ParishionerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sacrament",
                table: "Sacrament",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sacrament_Parishioners_ParishionerId",
                table: "Sacrament",
                column: "ParishionerId",
                principalTable: "Parishioners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
