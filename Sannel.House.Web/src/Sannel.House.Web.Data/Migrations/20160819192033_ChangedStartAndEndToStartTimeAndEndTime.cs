using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sannel.House.Web.Data.Migrations
{
    public partial class ChangedStartAndEndToStartTimeAndEndTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "TemperatureSettings");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "TemperatureSettings");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "TemperatureSettings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "TemperatureSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "TemperatureSettings");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "TemperatureSettings");

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "TemperatureSettings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "TemperatureSettings",
                nullable: true);
        }
    }
}
