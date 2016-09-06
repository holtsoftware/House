using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sannel.House.Web.Data.Migrations
{
    public partial class FixedSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Presure",
                table: "TemperatureEntries");

            migrationBuilder.AddColumn<double>(
                name: "Pressure",
                table: "TemperatureEntries",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pressure",
                table: "TemperatureEntries");

            migrationBuilder.AddColumn<double>(
                name: "Presure",
                table: "TemperatureEntries",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
