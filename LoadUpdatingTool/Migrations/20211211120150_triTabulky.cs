using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoadUpdatingTool.Migrations
{
    public partial class triTabulky : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SYS_LOAD_INFORMATION_evw",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURVE_NUMBER = table.Column<int>(type: "int", nullable: true),
                    ENERGY_MWH = table.Column<decimal>(type: "numeric(38,10)", nullable: true),
                    NUMBER_OF_CUSTOMERS = table.Column<int>(type: "int", nullable: true),
                    PEAK_POWER = table.Column<decimal>(type: "numeric(38,10)", nullable: true),
                    REACTIVE_POWER = table.Column<decimal>(type: "numeric(38,10)", nullable: true),
                    INSERTION_TIME = table.Column<DateTime>(type: "datetime2", nullable: true),
                    gid = table.Column<int>(type: "int", nullable: true),
                    rwo_gid = table.Column<int>(type: "int", nullable: true),
                    rwo_code = table.Column<decimal>(type: "numeric(38,8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_LOAD_INFORMATION_evw", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TEE_LOAD_INFORMATION_evw",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INSERTION_TIME = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PEAK_POWER = table.Column<decimal>(type: "numeric(38,8)", nullable: true),
                    NUMBER_OF_CUSTOMERS = table.Column<int>(type: "int", nullable: true),
                    REACTIVE_POWER = table.Column<decimal>(type: "numeric(38,8)", nullable: true),
                    CURVE_NUMBER = table.Column<int>(type: "int", nullable: true),
                    ENERGY_MWH = table.Column<decimal>(type: "numeric(38,8)", nullable: true),
                    POWER_FACTOR = table.Column<decimal>(type: "numeric(38,8)", nullable: true),
                    gid = table.Column<int>(type: "int", nullable: true),
                    rwo_gid = table.Column<int>(type: "int", nullable: true),
                    rwo_code = table.Column<decimal>(type: "numeric(38,8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEE_LOAD_INFORMATION_evw", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TEE_SERVICE_POINT_evw",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDENTIFICATION = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    gid = table.Column<int>(type: "int", nullable: true),
                    CONVERSION_INFO = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEE_SERVICE_POINT_evw", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SYS_LOAD_INFORMATION_evw");

            migrationBuilder.DropTable(
                name: "TEE_LOAD_INFORMATION_evw");

            migrationBuilder.DropTable(
                name: "TEE_SERVICE_POINT_evw");
        }
    }
}
