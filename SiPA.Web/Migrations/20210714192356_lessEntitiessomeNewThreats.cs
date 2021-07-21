using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class lessEntitiessomeNewThreats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Sacraments_SacramentId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Sacraments_SacramentId",
                table: "Histories");

            migrationBuilder.DropTable(
                name: "CommunityParishioner");

            migrationBuilder.DropTable(
                name: "GroupParishioner");

            migrationBuilder.DropTable(
                name: "Sacraments");

            migrationBuilder.DropTable(
                name: "Communities");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Histories_SacramentId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_SacramentId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "SacramentId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "SacramentId",
                table: "Certificates");

            migrationBuilder.AddColumn<int>(
                name: "ParishionerId",
                table: "SacramentTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SacramentTypes_ParishionerId",
                table: "SacramentTypes",
                column: "ParishionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SacramentTypes_Parishioners_ParishionerId",
                table: "SacramentTypes",
                column: "ParishionerId",
                principalTable: "Parishioners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SacramentTypes_Parishioners_ParishionerId",
                table: "SacramentTypes");

            migrationBuilder.DropIndex(
                name: "IX_SacramentTypes_ParishionerId",
                table: "SacramentTypes");

            migrationBuilder.DropColumn(
                name: "ParishionerId",
                table: "SacramentTypes");

            migrationBuilder.AddColumn<int>(
                name: "SacramentId",
                table: "Histories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SacramentId",
                table: "Certificates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meetings = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetingsDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sacraments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChristeningId = table.Column<int>(type: "int", nullable: true),
                    ParishionerId = table.Column<int>(type: "int", nullable: true),
                    SacramentTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sacraments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sacraments_Christenings_ChristeningId",
                        column: x => x.ChristeningId,
                        principalTable: "Christenings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sacraments_Parishioners_ParishionerId",
                        column: x => x.ParishionerId,
                        principalTable: "Parishioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sacraments_SacramentTypes_SacramentTypeId",
                        column: x => x.SacramentTypeId,
                        principalTable: "SacramentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommunityParishioner",
                columns: table => new
                {
                    CommunitiesId = table.Column<int>(type: "int", nullable: false),
                    ParishionersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityParishioner", x => new { x.CommunitiesId, x.ParishionersId });
                    table.ForeignKey(
                        name: "FK_CommunityParishioner_Communities_CommunitiesId",
                        column: x => x.CommunitiesId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityParishioner_Parishioners_ParishionersId",
                        column: x => x.ParishionersId,
                        principalTable: "Parishioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupParishioner",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    ParishionersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupParishioner", x => new { x.GroupsId, x.ParishionersId });
                    table.ForeignKey(
                        name: "FK_GroupParishioner_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupParishioner_Parishioners_ParishionersId",
                        column: x => x.ParishionersId,
                        principalTable: "Parishioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Histories_SacramentId",
                table: "Histories",
                column: "SacramentId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_SacramentId",
                table: "Certificates",
                column: "SacramentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityParishioner_ParishionersId",
                table: "CommunityParishioner",
                column: "ParishionersId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupParishioner_ParishionersId",
                table: "GroupParishioner",
                column: "ParishionersId");

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_ChristeningId",
                table: "Sacraments",
                column: "ChristeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_ParishionerId",
                table: "Sacraments",
                column: "ParishionerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sacraments_SacramentTypeId",
                table: "Sacraments",
                column: "SacramentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Sacraments_SacramentId",
                table: "Certificates",
                column: "SacramentId",
                principalTable: "Sacraments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Sacraments_SacramentId",
                table: "Histories",
                column: "SacramentId",
                principalTable: "Sacraments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
