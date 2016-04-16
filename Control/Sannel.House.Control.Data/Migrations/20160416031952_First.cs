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
                name: "WeatherAstronomy",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AgeOfMoon = table.Column<float>(nullable: false),
                    Astronomy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    PercentIlluminated = table.Column<float>(nullable: false),
                    Sunrise = table.Column<DateTime>(nullable: false),
                    Sunset = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherAstronomy", x => x.Id);
                });
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
                    ForcastUrl = table.Column<string>(nullable: true),
                    HeatIndexCelsius = table.Column<float>(nullable: false),
                    HeatIndexFahrenheit = table.Column<float>(nullable: false),
                    HistoryUrl = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    IconUrl = table.Column<string>(nullable: true),
                    LocalEpoch = table.Column<long>(nullable: false),
                    LocalTime = table.Column<DateTime>(nullable: false),
                    ObservationUrl = table.Column<string>(nullable: true),
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
            migrationBuilder.CreateTable(
                name: "WeatherHourly",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DewPointCelsius = table.Column<float>(nullable: false),
                    DewPointFahrenheit = table.Column<float>(nullable: false),
                    FeelsLikeCelsius = table.Column<float>(nullable: false),
                    FeelsLikeFahrenheit = table.Column<float>(nullable: false),
                    HeatIndexCelsius = table.Column<float>(nullable: false),
                    HeatIndexFahrenheit = table.Column<float>(nullable: false),
                    Humidity = table.Column<float>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    IconUrl = table.Column<string>(nullable: true),
                    MSLPEnglish = table.Column<float>(nullable: false),
                    MSLPMetric = table.Column<float>(nullable: false),
                    ProbabilityOfPrecipitation = table.Column<float>(nullable: false),
                    QuantitativePrecipitationForecastEnglish = table.Column<float>(nullable: false),
                    QuantitativePrecipitationForecastMetric = table.Column<float>(nullable: false),
                    Sky = table.Column<float>(nullable: false),
                    SnowInches = table.Column<float>(nullable: false),
                    SnowMillimeter = table.Column<float>(nullable: false),
                    TemperatureCelsius = table.Column<float>(nullable: false),
                    TemperatureFahrenheit = table.Column<float>(nullable: false),
                    UVIndex = table.Column<float>(nullable: false),
                    WX = table.Column<string>(nullable: true),
                    WindChillCelsius = table.Column<float>(nullable: false),
                    WindChillFahrenheit = table.Column<float>(nullable: false),
                    WindDirection = table.Column<string>(nullable: true),
                    WindDirectionDegrees = table.Column<float>(nullable: false),
                    WindSpeedKPH = table.Column<float>(nullable: false),
                    WindSpeedMPH = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherHourly", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("WeatherAstronomy");
            migrationBuilder.DropTable("WeatherCondition");
            migrationBuilder.DropTable("WeatherHourly");
        }
    }
}
