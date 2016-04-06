using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Sannel.House.Control.Data;

namespace Sannel.House.Control.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20160406005238_FilledoutCurrentWeather")]
    partial class FilledoutCurrentWeather
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

                    b.Property<float>("DewPointC");

                    b.Property<float>("DewPointF");

                    b.Property<string>("FeelsLikeC");

                    b.Property<string>("FeelsLikeF");

                    b.Property<string>("HeatIndexC");

                    b.Property<string>("HeatIndexF");

                    b.Property<string>("HistoryUrl");

                    b.Property<string>("Icon");

                    b.Property<string>("IconUrl");

                    b.Property<long>("LocalEpoch");

                    b.Property<DateTime>("LocalTime");

                    b.Property<string>("LocalTimeZone");

                    b.Property<string>("LocalTimeZoneOffset");

                    b.Property<string>("NowCast");

                    b.Property<long>("ObservationEpoch");

                    b.Property<DateTime>("ObservationTime");

                    b.Property<string>("PrecipitationPerHourInches");

                    b.Property<string>("PrecipitationPerHourMetric");

                    b.Property<string>("PrecipitationTodayInches");

                    b.Property<string>("PrecipitationTodayMetric");

                    b.Property<string>("PressureIN");

                    b.Property<string>("PressureMB");

                    b.Property<string>("PressureTrend");

                    b.Property<string>("RelativeHumidity");

                    b.Property<string>("SolarRadiation");

                    b.Property<string>("StationId");

                    b.Property<float>("TemperatureC");

                    b.Property<float>("TemperatureF");

                    b.Property<string>("UV");

                    b.Property<string>("VisibilityKilometer");

                    b.Property<string>("VisibilityMiles");

                    b.Property<string>("Weather");

                    b.Property<string>("WindChillC");

                    b.Property<string>("WindChillF");

                    b.Property<string>("WindDegrees");

                    b.Property<string>("WindDirection");

                    b.Property<string>("WindGustKPH");

                    b.Property<string>("WindGustMPH");

                    b.Property<string>("WindKPH");

                    b.Property<string>("WindMPH");

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
