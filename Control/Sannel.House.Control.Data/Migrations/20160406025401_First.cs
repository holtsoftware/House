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
                name: "CurrentWeather",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DewPointC = table.Column<float>(nullable: false),
                    DewPointF = table.Column<float>(nullable: false),
                    FeelsLikeC = table.Column<string>(nullable: true),
                    FeelsLikeF = table.Column<string>(nullable: true),
                    HeatIndexC = table.Column<string>(nullable: true),
                    HeatIndexF = table.Column<string>(nullable: true),
                    HistoryUrl = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    IconUrl = table.Column<string>(nullable: true),
                    LocalEpoch = table.Column<long>(nullable: false),
                    LocalTime = table.Column<DateTime>(nullable: false),
                    LocalTimeZone = table.Column<string>(nullable: true),
                    LocalTimeZoneOffset = table.Column<string>(nullable: true),
                    NowCast = table.Column<string>(nullable: true),
                    ObservationEpoch = table.Column<long>(nullable: false),
                    ObservationTime = table.Column<DateTime>(nullable: false),
                    PrecipitationPerHourInches = table.Column<string>(nullable: true),
                    PrecipitationPerHourMetric = table.Column<string>(nullable: true),
                    PrecipitationTodayInches = table.Column<string>(nullable: true),
                    PrecipitationTodayMetric = table.Column<string>(nullable: true),
                    PressureIN = table.Column<string>(nullable: true),
                    PressureMB = table.Column<string>(nullable: true),
                    PressureTrend = table.Column<string>(nullable: true),
                    RelativeHumidity = table.Column<string>(nullable: true),
                    SolarRadiation = table.Column<string>(nullable: true),
                    StationId = table.Column<string>(nullable: true),
                    TemperatureC = table.Column<float>(nullable: false),
                    TemperatureF = table.Column<float>(nullable: false),
                    UV = table.Column<string>(nullable: true),
                    VisibilityKilometer = table.Column<string>(nullable: true),
                    VisibilityMiles = table.Column<string>(nullable: true),
                    Weather = table.Column<string>(nullable: true),
                    WindChillC = table.Column<string>(nullable: true),
                    WindChillF = table.Column<string>(nullable: true),
                    WindDegrees = table.Column<string>(nullable: true),
                    WindDirection = table.Column<string>(nullable: true),
                    WindGustKPH = table.Column<string>(nullable: true),
                    WindGustMPH = table.Column<string>(nullable: true),
                    WindKPH = table.Column<string>(nullable: true),
                    WindMPH = table.Column<string>(nullable: true),
                    WindString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentWeather", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("CurrentWeather");
            migrationBuilder.DropTable("Temperature");
        }
    }
}
