using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Sannel.House.Control.Data;

namespace Sannel.House.Control.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20160405180734_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("Sannel.House.Control.Data.Models.CurrentWeather", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("LocalEpoch");

                    b.Property<DateTime>("LocalTime");

                    b.Property<string>("LocalTimeZone");

                    b.Property<string>("LocalTimeZoneOffset");

                    b.Property<long>("ObservationEpoch");

                    b.Property<DateTime>("ObservationTime");

                    b.Property<string>("RelativeHumidity");

                    b.Property<string>("StationId");

                    b.Property<float>("TemperatureC");

                    b.Property<float>("TemperatureF");

                    b.Property<string>("TemperatureString");

                    b.Property<string>("Weather");

                    b.Property<string>("WindString");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Sannel.House.Control.Data.Models.Temperature", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Value");

                    b.HasKey("Id");
                });
        }
    }
}
