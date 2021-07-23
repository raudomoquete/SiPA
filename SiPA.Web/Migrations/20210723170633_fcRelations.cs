using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class fcRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_FirstCommunions_FirstCommunionId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Parishioners_FirstCommunions_FirstCommunionId",
                table: "Parishioners");

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
                name: "CreatedAt",
                table: "FirstCommunions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "FirstCommunions");

            migrationBuilder.DropColumn(
                name: "FirstCommunionId",
                table: "Certificates");

            migrationBuilder.AddColumn<int>(
                name: "ParishionerId",
                table: "FirstCommunions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FirstCommunions_ParishionerId",
                table: "FirstCommunions",
                column: "ParishionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FirstCommunions_Parishioners_ParishionerId",
                table: "FirstCommunions",
                column: "ParishionerId",
                principalTable: "Parishioners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirstCommunions_Parishioners_ParishionerId",
                table: "FirstCommunions");

            migrationBuilder.DropIndex(
                name: "IX_FirstCommunions_ParishionerId",
                table: "FirstCommunions");

            migrationBuilder.DropColumn(
                name: "ParishionerId",
                table: "FirstCommunions");

            migrationBuilder.AddColumn<int>(
                name: "FirstCommunionId",
                table: "Parishioners",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "FirstCommunions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "FirstCommunions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FirstCommunionId",
                table: "Certificates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parishioners_FirstCommunionId",
                table: "Parishioners",
                column: "FirstCommunionId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_FirstCommunionId",
                table: "Certificates",
                column: "FirstCommunionId");

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
    }
}
