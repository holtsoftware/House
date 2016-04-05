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
                    LocalEpoch = table.Column<long>(nullable: false),
                    LocalTime = table.Column<DateTime>(nullable: false),
                    LocalTimeZone = table.Column<string>(nullable: true),
                    LocalTimeZoneOffset = table.Column<string>(nullable: true),
                    ObservationEpoch = table.Column<long>(nullable: false),
                    ObservationTime = table.Column<DateTime>(nullable: false),
                    RelativeHumidity = table.Column<string>(nullable: true),
                    StationId = table.Column<string>(nullable: true),
                    TemperatureC = table.Column<float>(nullable: false),
                    TemperatureF = table.Column<float>(nullable: false),
                    TemperatureString = table.Column<string>(nullable: true),
                    Weather = table.Column<string>(nullable: true),
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
