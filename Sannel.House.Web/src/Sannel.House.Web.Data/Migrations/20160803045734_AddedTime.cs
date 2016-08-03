using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sannel.House.Web.Data.Migrations
{
    public partial class AddedTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShortEndTime",
                table: "TemperatureSettings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShortTimeStart",
                table: "TemperatureSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortEndTime",
                table: "TemperatureSettings");

            migrationBuilder.DropColumn(
                name: "ShortTimeStart",
                table: "TemperatureSettings");
        }
    }
}
