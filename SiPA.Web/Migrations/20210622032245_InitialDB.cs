using Microsoft.EntityFrameworkCore.Migrations;

namespace SiPA.Web.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parishioners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FixedPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parishioners", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parishioners");
        }
    }
}
