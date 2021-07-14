using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class FinalDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Certificates_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Certificates_Christening_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Certificates_Confirmation_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Certificates_Wedding_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Sacraments_Christening_SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Sacraments_Confirmation_SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Sacraments_SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sacraments_Sacraments_Wedding_SacramentId1",
                table: "Sacraments");

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
                name: "IX_Sacraments_Confirmation_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropIndex(
                name: "IX_Sacraments_Confirmation_SacramentId1",
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
                name: "Christening_Id",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Christening_SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "ConfirmationDate",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Confirmation_CertificateId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Confirmation_Id",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Confirmation_SacramentId1",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
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
                name: "Id",
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
                name: "UpdatedAt",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "WeddingDate",
                table: "Sacraments");

            migrationBuilder.RenameColumn(
                name: "Wedding_SacramentId1",
                table: "Sacraments",
                newName: "WeddingId");

            migrationBuilder.RenameColumn(
                name: "Wedding_Id",
                table: "Sacraments",
                newName: "FirstCommunionId");

            migrationBuilder.RenameColumn(
                name: "Wedding_CertificateId",
                table: "Sacraments",
                newName: "ConfirmationId");

            migrationBuilder.RenameColumn(
                name: "SacramentId1",
                table: "Sacraments",
                newName: "ChristeningId");

            migrationBuilder.RenameIndex(
                name: "IX_Sacraments_Wedding_SacramentId1",
                table: "Sacraments",
                newName: "IX_Sacraments_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_Sacraments_Wedding_CertificateId",
                table: "Sacraments",
                newName: "IX_Sacraments_ConfirmationId");

            migrationBuilder.RenameIndex(
                name: "IX_Sacraments_SacramentId1",
                table: "Sacraments",
                newName: "IX_Sacraments_ChristeningId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Groups",
                newName: "GroupName");

            migrationBuilder.RenameColumn(
                name: "Meetings",
                table: "Groups",
                newName: "MeetingsDate");

            migrationBuilder.AlterColumn<string>(
                name: "SacramentName",
                table: "Sacraments",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "Certificates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Christenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParishionerId = table.Column<int>(type: "int", nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChristeningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceofEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodFatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodMotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodmMotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CeremonialCelebrant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    ParishionerId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceofEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodFatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodMotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GodMotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CeremonialCelebrant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    ParishionerId = table.Column<int>(type: "int", nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstCommunionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceofEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CeremonialCelebrant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    ParishionerId = table.Column<int>(type: "int", nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    BrideFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrideId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BridegroomId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WeddingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    GodmotherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                name: "IX_Sacraments_FirstCommunionId",
                table: "Sacraments",
                column: "FirstCommunionId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IX_Sacraments_FirstCommunionId",
                table: "Sacraments");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "Certificates");

            migrationBuilder.RenameColumn(
                name: "WeddingId",
                table: "Sacraments",
                newName: "Wedding_SacramentId1");

            migrationBuilder.RenameColumn(
                name: "FirstCommunionId",
                table: "Sacraments",
                newName: "Wedding_Id");

            migrationBuilder.RenameColumn(
                name: "ConfirmationId",
                table: "Sacraments",
                newName: "Wedding_CertificateId");

            migrationBuilder.RenameColumn(
                name: "ChristeningId",
                table: "Sacraments",
                newName: "SacramentId1");

            migrationBuilder.RenameIndex(
                name: "IX_Sacraments_WeddingId",
                table: "Sacraments",
                newName: "IX_Sacraments_Wedding_SacramentId1");

            migrationBuilder.RenameIndex(
                name: "IX_Sacraments_ConfirmationId",
                table: "Sacraments",
                newName: "IX_Sacraments_Wedding_CertificateId");

            migrationBuilder.RenameIndex(
                name: "IX_Sacraments_ChristeningId",
                table: "Sacraments",
                newName: "IX_Sacraments_SacramentId1");

            migrationBuilder.RenameColumn(
                name: "MeetingsDate",
                table: "Groups",
                newName: "Meetings");

            migrationBuilder.RenameColumn(
                name: "GroupName",
                table: "Groups",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "SacramentName",
                table: "Sacraments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

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

            migrationBuilder.AddColumn<int>(
                name: "Christening_Id",
                table: "Sacraments",
                type: "int",
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
                name: "ConfirmationDate",
                table: "Sacraments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Confirmation_CertificateId",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Confirmation_Id",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Confirmation_SacramentId1",
                table: "Sacraments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Sacraments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Sacraments",
                type: "datetime2",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sacraments",
                type: "int",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Sacraments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WeddingDate",
                table: "Sacraments",
                type: "datetime2",
                nullable: true);

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
                name: "IX_Sacraments_Confirmation_CertificateId",
                table: "Sacraments",
                column: "Confirmation_CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_Confirmation_SacramentId1",
                table: "Sacraments",
                column: "Confirmation_SacramentId1");

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
                name: "FK_Sacraments_Sacraments_Christening_SacramentId1",
                table: "Sacraments",
                column: "Christening_SacramentId1",
                principalTable: "Sacraments",
                principalColumn: "SacramentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sacraments_Sacraments_Confirmation_SacramentId1",
                table: "Sacraments",
                column: "Confirmation_SacramentId1",
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
                name: "FK_Sacraments_Sacraments_Wedding_SacramentId1",
                table: "Sacraments",
                column: "Wedding_SacramentId1",
                principalTable: "Sacraments",
                principalColumn: "SacramentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
