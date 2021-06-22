using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class CompleteDBWRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Parishioners_ParishionerId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestTypes_RequestTypeId",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Request",
                table: "Request");

            migrationBuilder.RenameTable(
                name: "Request",
                newName: "Requests");

            migrationBuilder.RenameIndex(
                name: "IX_Request_RequestTypeId",
                table: "Requests",
                newName: "IX_Requests_RequestTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_ParishionerId",
                table: "Requests",
                newName: "IX_Requests_ParishionerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Parishioners_ParishionerId",
                table: "Requests",
                column: "ParishionerId",
                principalTable: "Parishioners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests",
                column: "RequestTypeId",
                principalTable: "RequestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Parishioners_ParishionerId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "Request");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RequestTypeId",
                table: "Request",
                newName: "IX_Request_RequestTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_ParishionerId",
                table: "Request",
                newName: "IX_Request_ParishionerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Request",
                table: "Request",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Parishioners_ParishionerId",
                table: "Request",
                column: "ParishionerId",
                principalTable: "Parishioners",
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
    }
}
