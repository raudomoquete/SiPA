using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class Sacraments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Christenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SacramentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceofEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodfatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodfatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CeremonialCelebrant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Christenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Christenings_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Christenings_Sacraments_SacramentId",
                        column: x => x.SacramentId,
                        principalTable: "Sacraments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Confirmations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SacramentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceofEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodfatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodfatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CeremonialCelebrant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confirmations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Confirmations_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Confirmations_Sacraments_SacramentId",
                        column: x => x.SacramentId,
                        principalTable: "Sacraments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FirstCommunions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SacramentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceofEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodfatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodfatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CeremonialCelebrant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstCommunions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FirstCommunions_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FirstCommunions_Sacraments_SacramentId",
                        column: x => x.SacramentId,
                        principalTable: "Sacraments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weddings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SacramentId = table.Column<int>(type: "int", nullable: true),
                    BrideName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceofEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideFatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideMotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideMotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomFatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomMotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomMotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodfatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodfatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CeremonialCelebrant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weddings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weddings_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weddings_Sacraments_SacramentId",
                        column: x => x.SacramentId,
                        principalTable: "Sacraments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Christenings_CertificateId",
                table: "Christenings",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Christenings_SacramentId",
                table: "Christenings",
                column: "SacramentId");

            migrationBuilder.CreateIndex(
                name: "IX_Confirmations_CertificateId",
                table: "Confirmations",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Confirmations_SacramentId",
                table: "Confirmations",
                column: "SacramentId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstCommunions_CertificateId",
                table: "FirstCommunions",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstCommunions_SacramentId",
                table: "FirstCommunions",
                column: "SacramentId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_CertificateId",
                table: "Weddings",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_SacramentId",
                table: "Weddings",
                column: "SacramentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Christenings");

            migrationBuilder.DropTable(
                name: "Confirmations");

            migrationBuilder.DropTable(
                name: "FirstCommunions");

            migrationBuilder.DropTable(
                name: "Weddings");
        }
    }
}
