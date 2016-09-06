using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Sannel.House.Thermostat.Data;

namespace Sannel.House.Thermostat.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20160904195204_InitalMigration")]
    partial class InitalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Sannel.House.Thermostat.Models.TemperatureEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<int>("DeviceId");

                    b.Property<double>("Humidity");

                    b.Property<double>("Presure");

                    b.Property<bool>("Synced");

                    b.Property<double>("TemperatureCelsius");

                    b.HasKey("Id");

                    b.ToTable("TemperatureEntries");
                });
        }
    }
}
