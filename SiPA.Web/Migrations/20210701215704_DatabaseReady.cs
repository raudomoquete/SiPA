using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class DatabaseReady : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confirmations");

            migrationBuilder.DropTable(
                name: "Weddings");

            migrationBuilder.AddColumn<string>(
                name: "BrideFatherId",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
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
                name: "BrideId",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
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
                type: "nvarchar(50)",
                maxLength: 50,
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
                type: "nvarchar(50)",
                maxLength: 50,
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
                name: "BridegroomId",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
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
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BridegroomMotherName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Christening_Id",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmationDate",
                table: "Sacraments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Confirmation_CertificateId",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Confirmation_FirstName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Confirmation_Id",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Confirmation_LastName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Confirmation_SacramentId1",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WeddingDate",
                table: "Sacraments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Wedding_CertificateId",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Wedding_Id",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Wedding_SacramentId1",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_Confirmation_CertificateId",
                table: "Sacraments",
                column: "Confirmation_CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_Confirmation_SacramentId1",
                table: "Sacraments",
                column: "Confirmation_SacramentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_Wedding_CertificateId",
                table: "Sacraments",
                column: "Wedding_CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_Wedding_SacramentId1",
                table: "Sacraments",
                column: "Wedding_SacramentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_Certificates_Confirmation_CertificateId",
                table: "Sacraments",
                column: "Confirmation_CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_Certificates_Wedding_CertificateId",
                table: "Sacraments",
                column: "Wedding_CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_Sacraments_Confirmation_SacramentId1",
                table: "Sacraments",
                column: "Confirmation_SacramentId1",
                principalTable: "Sacraments",
                principalColumn: "SacramentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_Sacraments_Wedding_SacramentId1",
                table: "Sacraments",
                column: "Wedding_SacramentId1",
                principalTable: "Sacraments",
                principalColumn: "SacramentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Certificates_Confirmation_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Certificates_Wedding_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Sacraments_Confirmation_SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Sacraments_Wedding_SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_Confirmation_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_Confirmation_SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_Wedding_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_Wedding_SacramentId1",
                table: "Sacraments");

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
                name: "Christening_Id",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "ConfirmationDate",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Confirmation_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Confirmation_FirstName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Confirmation_Id",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Confirmation_LastName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Confirmation_SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "WeddingDate",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Wedding_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Wedding_Id",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Wedding_SacramentId1",
                table: "Sacraments");

            migrationBuilder.CreateTable(
                name: "Confirmations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SacramentId = table.Column<int>(type: "int", nullable: true)
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
                        principalColumn: "SacramentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weddings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrideFatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideMotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideMotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomFatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomMotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomMotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SacramentId = table.Column<int>(type: "int", nullable: true)
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
                        principalColumn: "SacramentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confirmations_CertificateId",
                table: "Confirmations",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Confirmations_SacramentId",
                table: "Confirmations",
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
    }
}
