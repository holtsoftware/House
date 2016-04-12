using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Sannel.House.Control.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherCondition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DewPointCelsius = table.Column<float>(nullable: false),
                    DewPointFahrenheit = table.Column<float>(nullable: false),
                    FeelsLikeCelsius = table.Column<float>(nullable: false),
                    FeelsLikeFahrenheit = table.Column<float>(nullable: false),
                    HeatIndexCelsius = table.Column<float>(nullable: false),
                    HeatIndexFahrenheit = table.Column<float>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    IconUrl = table.Column<string>(nullable: true),
                    LocalEpoch = table.Column<long>(nullable: false),
                    LocalTime = table.Column<DateTime>(nullable: false),
                    Precipitation1HourInches = table.Column<float>(nullable: false),
                    Precipitation1HourMetric = table.Column<float>(nullable: false),
                    PrecipitationTodayInches = table.Column<float>(nullable: false),
                    PrecipitationTodayMetric = table.Column<float>(nullable: false),
                    PresureInches = table.Column<float>(nullable: false),
                    PresureMillibar = table.Column<float>(nullable: false),
                    PresureTrending = table.Column<string>(nullable: true),
                    RelativeHumidity = table.Column<float>(nullable: false),
                    SolarRadiation = table.Column<string>(nullable: true),
                    StationId = table.Column<string>(nullable: true),
                    TempratureCelsius = table.Column<float>(nullable: false),
                    TempratureFahrenheit = table.Column<float>(nullable: false),
                    UV = table.Column<float>(nullable: false),
                    VisibilityKilometers = table.Column<float>(nullable: false),
                    VisibilityMiles = table.Column<float>(nullable: false),
                    Weather = table.Column<string>(nullable: true),
                    WindChillCelsius = table.Column<float>(nullable: false),
                    WindChillFahrenheit = table.Column<float>(nullable: false),
                    WindDegrees = table.Column<float>(nullable: false),
                    WindDirection = table.Column<string>(nullable: true),
                    WindGustKilometersPerHour = table.Column<float>(nullable: false),
                    WindGustMilesPerHour = table.Column<float>(nullable: false),
                    WindKilometerPerHour = table.Column<float>(nullable: false),
                    WindMilesPerHour = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherCondition", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("WeatherCondition");
        }
    }
}
