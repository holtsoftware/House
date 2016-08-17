using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sannel.House.Web.Data.Migrations
{
    public partial class UpdatedTemperatureSettingsObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongEndDate",
                table: "TemperatureSettings");

            migrationBuilder.DropColumn(
                name: "LongStartDate",
                table: "TemperatureSettings");

            migrationBuilder.DropColumn(
                name: "ShortEndTime",
                table: "TemperatureSettings");

            migrationBuilder.DropColumn(
                name: "ShortTimeStart",
                table: "TemperatureSettings");

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "TemperatureSettings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEndOnly",
                table: "TemperatureSettings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStartOnly",
                table: "TemperatureSettings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "TemperatureSettings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "TemperatureSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "TemperatureSettings");

            migrationBuilder.DropColumn(
                name: "IsEndOnly",
                table: "TemperatureSettings");

            migrationBuilder.DropColumn(
                name: "IsStartOnly",
                table: "TemperatureSettings");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "TemperatureSettings");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "TemperatureSettings");

            migrationBuilder.AddColumn<long>(
                name: "LongEndDate",
                table: "TemperatureSettings",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LongStartDate",
                table: "TemperatureSettings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShortEndTime",
                table: "TemperatureSettings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShortTimeStart",
                table: "TemperatureSettings",
                nullable: true);
        }
    }
}
