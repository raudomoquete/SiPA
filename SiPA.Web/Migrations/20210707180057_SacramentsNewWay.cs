using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class SacramentsNewWay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Christenings_ChristeningId",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Confirmations_ConfirmationId",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_FirstCommunions_FirstCommunionId",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Weddings_WeddingId",
                table: "Sacraments");

            migrationBuilder.DropTable(
                name: "Christenings");

            migrationBuilder.DropTable(
                name: "Confirmations");

            migrationBuilder.DropTable(
                name: "FirstCommunions");

            migrationBuilder.DropTable(
                name: "Weddings");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_ChristeningId",
                table: "Sacraments");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_ConfirmationId",
                table: "Sacraments");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_FirstCommunionId",
                table: "Sacraments");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_WeddingId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "ChristeningId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "ConfirmationId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "FirstCommunionId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "WeddingId",
                table: "Sacraments");

            migrationBuilder.RenameColumn(
                name: "SacramentId",
                table: "Sacraments",
                newName: "Id");

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
                name: "BrideFullName",
                table: "Sacraments",
                type: "nvarchar(max)",
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
                name: "BridegroomFullName",
                table: "Sacraments",
                type: "nvarchar(max)",
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

            migrationBuilder.AddColumn<string>(
                name: "CeremonialCelebrant",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ChristeningDate",
                table: "Sacraments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Sacraments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmationDate",
                table: "Sacraments",
                type: "datetime2",
                nullable: true);

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

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstCommunionDate",
                table: "Sacraments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodFatherId",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
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
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodMotherName",
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
                name: "ParishionerFullName",
                table: "Sacraments",
                type: "nvarchar(max)",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "WeddingDate",
                table: "Sacraments",
                type: "datetime2",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ChristeningDate",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "ConfirmationDate",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "FirstCommunionDate",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "FirstName",
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
                name: "LastName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "ParishionerFullName",
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
                name: "WeddingDate",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "WeddingGodParents",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "WeddingGrooms",
                table: "Sacraments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sacraments",
                newName: "SacramentId");

            migrationBuilder.AddColumn<int>(
                name: "ChristeningId",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConfirmationId",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstCommunionId",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeddingId",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Christenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonialCelebrant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    ChristeningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodFatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodMotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodMotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParishionerId = table.Column<int>(type: "int", nullable: true),
                    PlaceofEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                        name: "FK_Christenings_Parishioners_ParishionerId",
                        column: x => x.ParishionerId,
                        principalTable: "Parishioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Confirmations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonialCelebrant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodFatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodMotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodMotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParishionerId = table.Column<int>(type: "int", nullable: true),
                    PlaceofEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                        name: "FK_Confirmations_Parishioners_ParishionerId",
                        column: x => x.ParishionerId,
                        principalTable: "Parishioners",
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
                    FatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstCommunionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParishionerId = table.Column<int>(type: "int", nullable: true),
                    PlaceofEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                        name: "FK_FirstCommunions_Parishioners_ParishionerId",
                        column: x => x.ParishionerId,
                        principalTable: "Parishioners",
                        principalColumn: "Id",
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
                    BrideFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideMotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideMotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomFatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomMotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomMotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    GodfatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodfatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParishionerId = table.Column<int>(type: "int", nullable: true),
                    WeddingDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        name: "FK_Weddings_Parishioners_ParishionerId",
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
                name: "IX_Sacraments_ConfirmationId",
                table: "Sacraments",
                column: "ConfirmationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_FirstCommunionId",
                table: "Sacraments",
                column: "FirstCommunionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_WeddingId",
                table: "Sacraments",
                column: "WeddingId");

            migrationBuilder.CreateIndex(
                name: "IX_Christenings_CertificateId",
                table: "Christenings",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Christenings_ParishionerId",
                table: "Christenings",
                column: "ParishionerId");

            migrationBuilder.CreateIndex(
                name: "IX_Confirmations_CertificateId",
                table: "Confirmations",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Confirmations_ParishionerId",
                table: "Confirmations",
                column: "ParishionerId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstCommunions_CertificateId",
                table: "FirstCommunions",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstCommunions_ParishionerId",
                table: "FirstCommunions",
                column: "ParishionerId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_CertificateId",
                table: "Weddings",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_ParishionerId",
                table: "Weddings",
                column: "ParishionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_Christenings_ChristeningId",
                table: "Sacraments",
                column: "ChristeningId",
                principalTable: "Christenings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_Confirmations_ConfirmationId",
                table: "Sacraments",
                column: "ConfirmationId",
                principalTable: "Confirmations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_FirstCommunions_FirstCommunionId",
                table: "Sacraments",
                column: "FirstCommunionId",
                principalTable: "FirstCommunions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_Weddings_WeddingId",
                table: "Sacraments",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
