using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class firstcommunion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirstCommunionId",
                table: "Parishioners",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstCommunionId",
                table: "Certificates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FirstCommunions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstCommunionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceofEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    ParishionerParents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CeremonialCelebrant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SacramentTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstCommunions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FirstCommunions_SacramentTypes_SacramentTypeId",
                        column: x => x.SacramentTypeId,
                        principalTable: "SacramentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parishioners_FirstCommunionId",
                table: "Parishioners",
                column: "FirstCommunionId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_FirstCommunionId",
                table: "Certificates",
                column: "FirstCommunionId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstCommunions_SacramentTypeId",
                table: "FirstCommunions",
                column: "SacramentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_FirstCommunions_FirstCommunionId",
                table: "Certificates",
                column: "FirstCommunionId",
                principalTable: "FirstCommunions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parishioners_FirstCommunions_FirstCommunionId",
                table: "Parishioners",
                column: "FirstCommunionId",
                principalTable: "FirstCommunions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_FirstCommunions_FirstCommunionId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Parishioners_FirstCommunions_FirstCommunionId",
                table: "Parishioners");

            migrationBuilder.DropTable(
                name: "FirstCommunions");

            migrationBuilder.DropIndex(
                name: "IX_Parishioners_FirstCommunionId",
                table: "Parishioners");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_FirstCommunionId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "FirstCommunionId",
                table: "Parishioners");

            migrationBuilder.DropColumn(
                name: "FirstCommunionId",
                table: "Certificates");
        }
    }
}
