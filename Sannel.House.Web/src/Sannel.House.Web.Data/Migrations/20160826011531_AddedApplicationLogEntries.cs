using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sannel.House.Web.Data.Migrations
{
    public partial class AddedApplicationLogEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationLogEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApplicationId = table.Column<string>(maxLength: 256, nullable: false),
                    DeviceId = table.Column<int>(nullable: true),
                    EntryDateTime = table.Column<DateTime>(nullable: false),
                    Exception = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationLogEntries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationLogEntries");
        }
    }
}
