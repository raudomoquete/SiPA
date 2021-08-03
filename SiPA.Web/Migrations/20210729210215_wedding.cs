using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class wedding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weddings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceOfEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideFatherId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    BrideMotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideMotherId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    BrideGroomFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideGroomFatherId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    BrideGroomMotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideGroomMotherId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    GodMother = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodMotherId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    GodFather = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GoFatherId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    WeedingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CeremonialCelebrant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SacramentTypeId = table.Column<int>(type: "int", nullable: true),
                    ParishionersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weddings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weddings_Parishioners_ParishionersId",
                        column: x => x.ParishionersId,
                        principalTable: "Parishioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weddings_SacramentTypes_SacramentTypeId",
                        column: x => x.SacramentTypeId,
                        principalTable: "SacramentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_ParishionersId",
                table: "Weddings",
                column: "ParishionersId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_SacramentTypeId",
                table: "Weddings",
                column: "SacramentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weddings");
        }
    }
}
