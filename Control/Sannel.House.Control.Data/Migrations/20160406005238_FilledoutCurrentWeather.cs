using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Sannel.House.Control.Data.Migrations
{
    public partial class FilledoutCurrentWeather : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "TemperatureString", table: "CurrentWeather");
            migrationBuilder.AddColumn<float>(
                name: "DewPointC",
                table: "CurrentWeather",
                nullable: false,
                defaultValue: 0f);
            migrationBuilder.AddColumn<float>(
                name: "DewPointF",
                table: "CurrentWeather",
                nullable: false,
                defaultValue: 0f);
            migrationBuilder.AddColumn<string>(
                name: "FeelsLikeC",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "FeelsLikeF",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "HeatIndexC",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "HeatIndexF",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "HistoryUrl",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "NowCast",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "PrecipitationPerHourInches",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "PrecipitationPerHourMetric",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "PrecipitationTodayInches",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "PrecipitationTodayMetric",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "PressureIN",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "PressureMB",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "PressureTrend",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "SolarRadiation",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "UV",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "VisibilityKilometer",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "VisibilityMiles",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "WindChillC",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "WindChillF",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "WindDegrees",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "WindDirection",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "WindGustKPH",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "WindGustMPH",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "WindKPH",
                table: "CurrentWeather",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "WindMPH",
                table: "CurrentWeather",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DewPointC", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "DewPointF", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "FeelsLikeC", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "FeelsLikeF", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "HeatIndexC", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "HeatIndexF", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "HistoryUrl", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "Icon", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "NowCast", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "PrecipitationPerHourInches", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "PrecipitationPerHourMetric", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "PrecipitationTodayInches", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "PrecipitationTodayMetric", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "PressureIN", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "PressureMB", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "PressureTrend", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "SolarRadiation", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "UV", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "VisibilityKilometer", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "VisibilityMiles", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "WindChillC", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "WindChillF", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "WindDegrees", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "WindDirection", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "WindGustKPH", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "WindGustMPH", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "WindKPH", table: "CurrentWeather");
            migrationBuilder.DropColumn(name: "WindMPH", table: "CurrentWeather");
            migrationBuilder.AddColumn<string>(
                name: "TemperatureString",
                table: "CurrentWeather",
                nullable: true);
        }
    }
}
