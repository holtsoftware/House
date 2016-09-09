using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sannel.House.Web.Data.Migrations
{
    public partial class ChangedDateTypeForTemperatureSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "StartTime",
                table: "TemperatureSettings",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EndTime",
                table: "TemperatureSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "TemperatureSettings",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "TemperatureSettings",
                nullable: true);
        }
    }
}
