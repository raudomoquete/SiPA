using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class CertificateUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Certificates");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Certificates",
                newName: "Tipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Certificates",
                newName: "Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Certificates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "Certificates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Certificates",
                type: "datetime2",
                nullable: true);
        }
    }
}
