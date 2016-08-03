using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sannel.House.Web.Data.Migrations
{
    public partial class AddedStartAndEndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemperatureSettings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoolTemperatureC = table.Column<double>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: true),
                    HeatTemperatureC = table.Column<double>(nullable: false),
                    LongEndDate = table.Column<long>(nullable: true),
                    LongStartDate = table.Column<long>(nullable: true),
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
        }
    }
}
