using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sannel.House.Web.Data.Migrations
{
    public partial class ChangeToTemperatureSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEndOnly",
                table: "TemperatureSettings");

            migrationBuilder.DropColumn(
                name: "IsStartOnly",
                table: "TemperatureSettings");

            migrationBuilder.AddColumn<bool>(
                name: "IsTimeOnly",
                table: "TemperatureSettings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTimeOnly",
                table: "TemperatureSettings");

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
        }
    }
}
