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

            modelBuilder.Entity("Sannel.House.Control.Data.Models.StoredDevice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<uint>("ShortId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Sannel.House.WUnderground.Models.WeatherAstronomy", b =>
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

            modelBuilder.Entity("Sannel.House.WUnderground.Models.WeatherCondition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<float>("DewPointCelsius");

                    b.Property<float>("DewPointFahrenheit");

                    b.Property<float>("FeelsLikeCelsius");

                    b.Property<float>("FeelsLikeFahrenheit");

                    b.Property<string>("ForcastUrl");

                    b.Property<float>("HeatIndexCelsius");

                    b.Property<float>("HeatIndexFahrenheit");

                    b.Property<string>("HistoryUrl");

                    b.Property<string>("Icon");

                    b.Property<string>("IconUrl");

                    b.Property<long>("LocalEpoch");

                    b.Property<DateTime>("LocalTime");

                    b.Property<string>("ObservationUrl");

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

            modelBuilder.Entity("Sannel.House.WUnderground.Models.WeatherHourly", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("Date");

                    b.Property<float>("DewPointCelsius");

                    b.Property<float>("DewPointFahrenheit");

                    b.Property<float>("FeelsLikeCelsius");

                    b.Property<float>("FeelsLikeFahrenheit");

                    b.Property<float>("HeatIndexCelsius");

                    b.Property<float>("HeatIndexFahrenheit");

                    b.Property<float>("Humidity");

                    b.Property<string>("Icon");

                    b.Property<string>("IconUrl");

                    b.Property<float>("MSLPEnglish");

                    b.Property<float>("MSLPMetric");

                    b.Property<float>("ProbabilityOfPrecipitation");

                    b.Property<float>("QuantitativePrecipitationForecastEnglish");

                    b.Property<float>("QuantitativePrecipitationForecastMetric");

                    b.Property<float>("Sky");

                    b.Property<float>("SnowInches");

                    b.Property<float>("SnowMillimeter");

                    b.Property<float>("TemperatureCelsius");

                    b.Property<float>("TemperatureFahrenheit");

                    b.Property<float>("UVIndex");

                    b.Property<string>("WX");

                    b.Property<float>("WindChillCelsius");

                    b.Property<float>("WindChillFahrenheit");

                    b.Property<string>("WindDirection");

                    b.Property<float>("WindDirectionDegrees");

                    b.Property<float>("WindSpeedKPH");

                    b.Property<float>("WindSpeedMPH");

                    b.HasKey("Id");
                });
        }
    }
}
