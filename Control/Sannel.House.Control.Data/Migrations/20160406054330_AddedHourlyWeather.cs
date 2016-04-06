using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Sannel.House.Control.Data.Migrations
{
    public partial class AddedHourlyWeather : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HourlyWeather",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Condition = table.Column<string>(nullable: true),
                    DewPointC = table.Column<string>(nullable: true),
                    DewPointF = table.Column<string>(nullable: true),
                    FeelsLikeC = table.Column<string>(nullable: true),
                    FeelsLikeF = table.Column<string>(nullable: true),
                    HeatIndexC = table.Column<string>(nullable: true),
                    HeatIndexF = table.Column<string>(nullable: true),
                    Hour = table.Column<DateTime>(nullable: false),
                    Humidity = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    IconUrl = table.Column<string>(nullable: true),
                    MSLPInches = table.Column<string>(nullable: true),
                    MSLPMetric = table.Column<string>(nullable: true),
                    POP = table.Column<string>(nullable: true),
                    QPFInches = table.Column<string>(nullable: true),
                    QPFMetric = table.Column<string>(nullable: true),
                    Sky = table.Column<string>(nullable: true),
                    SnowInches = table.Column<string>(nullable: true),
                    SnowMetric = table.Column<string>(nullable: true),
                    TempC = table.Column<string>(nullable: true),
                    TempF = table.Column<string>(nullable: true),
                    UVI = table.Column<string>(nullable: true),
                    WX = table.Column<string>(nullable: true),
                    WindChillC = table.Column<string>(nullable: true),
                    WindChillF = table.Column<string>(nullable: true),
                    WindDirection = table.Column<string>(nullable: true),
                    WindDirectionDegrees = table.Column<string>(nullable: true),
                    WindSpeedKPH = table.Column<string>(nullable: true),
                    WindSpeedMPH = table.Column<string>(nullable: true),
                    fctcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlyWeather", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("HourlyWeather");
        }
    }
}
