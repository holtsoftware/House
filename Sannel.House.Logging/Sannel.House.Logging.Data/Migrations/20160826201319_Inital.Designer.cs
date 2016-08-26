using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Sannel.House.Logging.Data;

namespace Sannel.House.Logging.Data.Migrations
{
    [DbContext(typeof(LoggingContext))]
    [Migration("20160826201319_Inital")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Sannel.House.Logging.Models.ApplicationLogEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationId");

                    b.Property<int?>("DeviceId");

                    b.Property<DateTime>("EntryDateTime");

                    b.Property<string>("Exception");

                    b.Property<string>("Message");

                    b.Property<bool>("Synced");

                    b.HasKey("Id");

                    b.ToTable("ApplicationLogEntries");
                });
        }
    }
}
