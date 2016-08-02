using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sannel.House.Web.Data.Migrations
{
    public partial class UpdatedTempratureSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemperatureDefaults");

            migrationBuilder.CreateTable(
                name: "TemperatureSettings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoolTemperatureC = table.Column<double>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: true),
                    HeatTemperatureC = table.Column<double>(nullable: false),
                    Hour = table.Column<int>(nullable: false),
                    Minute = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureSettings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemperatureSettings");

            migrationBuilder.CreateTable(
                name: "TemperatureDefaults",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoolTemperatureC = table.Column<double>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    HeatTemperatureC = table.Column<double>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureDefaults", x => x.Id);
                });
        }
    }
}
