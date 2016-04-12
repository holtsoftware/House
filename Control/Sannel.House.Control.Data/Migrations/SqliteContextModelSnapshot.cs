using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Sannel.House.Control.Data;

namespace Sannel.House.Control.Data.Migrations
{
    [DbContext(typeof(SqliteContext))]
    partial class SqliteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("Sannel.House.Control.Data.Models.WeatherAstronomy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("AgeOfMoon");

                    b.Property<int>("Astronomy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<float>("PercentIlluminated");

                    b.Property<DateTime>("Sunrise");

                    b.Property<DateTime>("Sunset");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Sannel.House.Control.Data.Models.WeatherCondition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<float>("DewPointCelsius");

                    b.Property<float>("DewPointFahrenheit");

                    b.Property<float>("FeelsLikeCelsius");

                    b.Property<float>("FeelsLikeFahrenheit");

                    b.Property<float>("HeatIndexCelsius");

                    b.Property<float>("HeatIndexFahrenheit");

                    b.Property<string>("Icon");

                    b.Property<string>("IconUrl");

                    b.Property<long>("LocalEpoch");

                    b.Property<DateTime>("LocalTime");

                    b.Property<float>("Precipitation1HourInches");

                    b.Property<float>("Precipitation1HourMetric");

                    b.Property<float>("PrecipitationTodayInches");

                    b.Property<float>("PrecipitationTodayMetric");

                    b.Property<float>("PresureInches");

                    b.Property<float>("PresureMillibar");

                    b.Property<string>("PresureTrending");

                    b.Property<float>("RelativeHumidity");

                    b.Property<string>("SolarRadiation");

                    b.Property<string>("StationId");

                    b.Property<float>("TempratureCelsius");

                    b.Property<float>("TempratureFahrenheit");

                    b.Property<float>("UV");

                    b.Property<float>("VisibilityKilometers");

                    b.Property<float>("VisibilityMiles");

                    b.Property<string>("Weather");

                    b.Property<float>("WindChillCelsius");

                    b.Property<float>("WindChillFahrenheit");

                    b.Property<float>("WindDegrees");

                    b.Property<string>("WindDirection");

                    b.Property<float>("WindGustKilometersPerHour");

                    b.Property<float>("WindGustMilesPerHour");

                    b.Property<float>("WindKilometerPerHour");

                    b.Property<float>("WindMilesPerHour");

                    b.HasKey("Id");
                });
        }
    }
}
