using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class CompleteDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CivilStatus",
                table: "Users",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "datetime2",
                maxLength: 13,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Identification",
                table: "Users",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReceivedSacraments",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Parishioners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parishioners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParishionerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestTypes_Parishioners_ParishionerId",
                        column: x => x.ParishionerId,
                        principalTable: "Parishioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sacraments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParishionerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sacraments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sacraments_Parishioners_ParishionerId",
                        column: x => x.ParishionerId,
                        principalTable: "Parishioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestTypeId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParishionerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_Parishioners_ParishionerId",
                        column: x => x.ParishionerId,
                        principalTable: "Parishioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Histories_RequestTypes_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SacramentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParishionerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_Parishioners_ParishionerId",
                        column: x => x.ParishionerId,
                        principalTable: "Parishioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Certificates_Sacraments_SacramentId",
                        column: x => x.SacramentId,
                        principalTable: "Sacraments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Certificates_ParishionerId",
                table: "Certificates",
                column: "ParishionerId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_SacramentId",
                table: "Certificates",
                column: "SacramentId");

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
                name: "IX_Histories_ParishionerId",
                table: "Histories",
                column: "ParishionerId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_RequestTypeId",
                table: "Histories",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTypes_ParishionerId",
                table: "RequestTypes",
                column: "ParishionerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_ParishionerId",
                table: "Sacraments",
                column: "ParishionerId");

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
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Weddings");

            migrationBuilder.DropTable(
                name: "RequestTypes");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Sacraments");

            migrationBuilder.DropTable(
                name: "Parishioners");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CivilStatus",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Identification",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReceivedSacraments",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
