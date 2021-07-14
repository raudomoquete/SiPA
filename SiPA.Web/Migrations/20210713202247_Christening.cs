using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class Christening : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrideFatherId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BrideFatherName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BrideFirstName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BrideFullName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BrideId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BrideLastName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BrideMotherId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BrideMotherName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BridegroomFatherId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BridegroomFatherName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BridegroomFirstName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BridegroomFullName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BridegroomId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BridegroomLastName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BridegroomMotherId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "BridegroomMotherName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "CeremonialCelebrant",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "GodFatherId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "GodFatherName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "GodMotherId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "GodMotherName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "ParishionerGodParents",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "ParishionerParents",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "PlaceofEvent",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "WeddingBrideParents",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "WeddingBridegroomParents",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "WeddingGodParents",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "WeddingGrooms",
                table: "Sacraments");

            migrationBuilder.AddColumn<int>(
                name: "ChristeningId",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Christenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceofEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    BaptizedParents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GodFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodFatherId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    GodMotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodMotherId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    BaptizedGodParents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CeremonialCelebrant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChristeningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ParishionerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Christenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Christenings_Parishioners_ParishionerId",
                        column: x => x.ParishionerId,
                        principalTable: "Parishioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_ChristeningId",
                table: "Sacraments",
                column: "ChristeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Christenings_ParishionerId",
                table: "Christenings",
                column: "ParishionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_Christenings_ChristeningId",
                table: "Sacraments",
                column: "ChristeningId",
                principalTable: "Christenings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Christenings_ChristeningId",
                table: "Sacraments");

            migrationBuilder.DropTable(
                name: "Christenings");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_ChristeningId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "ChristeningId",
                table: "Sacraments");

            migrationBuilder.AddColumn<string>(
                name: "BrideFatherId",
                table: "Sacraments",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrideFatherName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrideFirstName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrideFullName",
                table: "Sacraments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrideId",
                table: "Sacraments",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrideLastName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrideMotherId",
                table: "Sacraments",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrideMotherName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BridegroomFatherId",
                table: "Sacraments",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BridegroomFatherName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BridegroomFirstName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BridegroomFullName",
                table: "Sacraments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BridegroomId",
                table: "Sacraments",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BridegroomLastName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BridegroomMotherId",
                table: "Sacraments",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BridegroomMotherName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CeremonialCelebrant",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Sacraments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "Sacraments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherId",
                table: "Sacraments",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodFatherId",
                table: "Sacraments",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodFatherName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodMotherId",
                table: "Sacraments",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodMotherName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherId",
                table: "Sacraments",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParishionerGodParents",
                table: "Sacraments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParishionerParents",
                table: "Sacraments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceofEvent",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeddingBrideParents",
                table: "Sacraments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeddingBridegroomParents",
                table: "Sacraments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeddingGodParents",
                table: "Sacraments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeddingGrooms",
                table: "Sacraments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
