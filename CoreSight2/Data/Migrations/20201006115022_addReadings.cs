using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreSight2.Data.Migrations
{
    public partial class addReadings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temp1 = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Temp2 = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Temp3 = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Temp4 = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Hum1 = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Hum2 = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Hum3 = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Hum4 = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Readings");
        }
    }
}
