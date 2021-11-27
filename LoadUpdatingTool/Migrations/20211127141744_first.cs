using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoadUpdatingTool.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicePoints",
                columns: table => new
                {
                    gid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDENTIFICATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONVERSION_INFO = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePoints", x => x.gid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicePoints");
        }
    }
}
