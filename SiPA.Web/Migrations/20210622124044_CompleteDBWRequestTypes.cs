using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class CompleteDBWRequestTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_RequestType_RequestTypeId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestType_RequestTypeId",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestType",
                table: "RequestType");

            migrationBuilder.RenameTable(
                name: "RequestType",
                newName: "RequestTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestTypes",
                table: "RequestTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_RequestTypes_RequestTypeId",
                table: "Histories",
                column: "RequestTypeId",
                principalTable: "RequestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestTypes_RequestTypeId",
                table: "Request",
                column: "RequestTypeId",
                principalTable: "RequestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_RequestTypes_RequestTypeId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestTypes_RequestTypeId",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestTypes",
                table: "RequestTypes");

            migrationBuilder.RenameTable(
                name: "RequestTypes",
                newName: "RequestType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestType",
                table: "RequestType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_RequestType_RequestTypeId",
                table: "Histories",
                column: "RequestTypeId",
                principalTable: "RequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestType_RequestTypeId",
                table: "Request",
                column: "RequestTypeId",
                principalTable: "RequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
