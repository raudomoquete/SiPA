using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Requests_RequestId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestTypes_CertificatesTypes_CertificatesTypesId",
                table: "RequestTypes");

            migrationBuilder.DropIndex(
                name: "IX_RequestTypes_CertificatesTypesId",
                table: "RequestTypes");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CertificatesTypesId",
                table: "RequestTypes");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "CertificatesTypesId",
                table: "Certificates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CertificatesTypesId",
                table: "Certificates",
                column: "CertificatesTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_CertificatesTypes_CertificatesTypesId",
                table: "Certificates",
                column: "CertificatesTypesId",
                principalTable: "CertificatesTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_CertificatesTypes_CertificatesTypesId",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_CertificatesTypesId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "CertificatesTypesId",
                table: "Certificates");

            migrationBuilder.AddColumn<int>(
                name: "CertificatesTypesId",
                table: "RequestTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestTypes_CertificatesTypesId",
                table: "RequestTypes",
                column: "CertificatesTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestId",
                table: "Requests",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Requests_RequestId",
                table: "Requests",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTypes_CertificatesTypes_CertificatesTypesId",
                table: "RequestTypes",
                column: "CertificatesTypesId",
                principalTable: "CertificatesTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
