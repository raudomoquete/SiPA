using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class ModifyDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Christenings");

            migrationBuilder.DropTable(
                name: "FirstCommunions");

            migrationBuilder.DropColumn(
                name: "CeremonialCelebrant",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "GodfatherId",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "GodfatherName",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "GodmotherId",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "GodmotherName",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "PlaceofEvent",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "CeremonialCelebrant",
                table: "Confirmations");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Confirmations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Confirmations");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "Confirmations");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Confirmations");

            migrationBuilder.DropColumn(
                name: "GodfatherId",
                table: "Confirmations");

            migrationBuilder.DropColumn(
                name: "GodfatherName",
                table: "Confirmations");

            migrationBuilder.DropColumn(
                name: "GodmotherId",
                table: "Confirmations");

            migrationBuilder.DropColumn(
                name: "GodmotherName",
                table: "Confirmations");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "Confirmations");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "Confirmations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Confirmations");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Sacraments",
                newName: "SacramentName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sacraments",
                newName: "SacramentId");

            migrationBuilder.RenameColumn(
                name: "PlaceofEvent",
                table: "Confirmations",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Confirmations",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "CeremonialCelebrant",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CertificateId",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ChristeningDate",
                table: "Sacraments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Christening_CertificateId",
                table: "Sacraments",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "Christening_SacramentId1",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Sacraments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Sacraments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Sacraments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FatherId",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodfatherId",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodfatherName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodmotherId",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodmotherName",
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
                name: "MotherId",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceofEvent",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SacramentId1",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SacramentTypeId",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SacramentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SacramentTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_CertificateId",
                table: "Sacraments",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_Christening_CertificateId",
                table: "Sacraments",
                column: "Christening_CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_Christening_SacramentId1",
                table: "Sacraments",
                column: "Christening_SacramentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_SacramentId1",
                table: "Sacraments",
                column: "SacramentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_SacramentTypeId",
                table: "Sacraments",
                column: "SacramentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_Certificates_CertificateId",
                table: "Sacraments",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_Certificates_Christening_CertificateId",
                table: "Sacraments",
                column: "Christening_CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_Sacraments_Christening_SacramentId1",
                table: "Sacraments",
                column: "Christening_SacramentId1",
                principalTable: "Sacraments",
                principalColumn: "SacramentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_Sacraments_SacramentId1",
                table: "Sacraments",
                column: "SacramentId1",
                principalTable: "Sacraments",
                principalColumn: "SacramentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_SacramentTypes_SacramentTypeId",
                table: "Sacraments",
                column: "SacramentTypeId",
                principalTable: "SacramentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Certificates_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Certificates_Christening_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Sacraments_Christening_SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Sacraments_SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_SacramentTypes_SacramentTypeId",
                table: "Sacraments");

            migrationBuilder.DropTable(
                name: "SacramentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_Christening_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_Christening_SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_SacramentTypeId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "CeremonialCelebrant",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "ChristeningDate",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Christening_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Christening_FirstName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Christening_LastName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Christening_SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "GodfatherId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "GodfatherName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "GodmotherId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "GodmotherName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "PlaceofEvent",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "SacramentTypeId",
                table: "Sacraments");

            migrationBuilder.RenameColumn(
                name: "SacramentName",
                table: "Sacraments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SacramentId",
                table: "Sacraments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Confirmations",
                newName: "PlaceofEvent");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Confirmations",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "CeremonialCelebrant",
                table: "Weddings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Weddings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Weddings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GodfatherId",
                table: "Weddings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodfatherName",
                table: "Weddings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodmotherId",
                table: "Weddings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodmotherName",
                table: "Weddings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceofEvent",
                table: "Weddings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Weddings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CeremonialCelebrant",
                table: "Confirmations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Confirmations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Confirmations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FatherId",
                table: "Confirmations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Confirmations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodfatherId",
                table: "Confirmations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodfatherName",
                table: "Confirmations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodmotherId",
                table: "Confirmations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodmotherName",
                table: "Confirmations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherId",
                table: "Confirmations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "Confirmations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Confirmations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Christenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonialCelebrant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodfatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodfatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlaceofEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SacramentId = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "FirstCommunions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonialCelebrant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodfatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodfatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlaceofEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SacramentId = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Christenings_CertificateId",
                table: "Christenings",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Christenings_SacramentId",
                table: "Christenings",
                column: "SacramentId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstCommunions_CertificateId",
                table: "FirstCommunions",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstCommunions_SacramentId",
                table: "FirstCommunions",
                column: "SacramentId");
        }
    }
}
