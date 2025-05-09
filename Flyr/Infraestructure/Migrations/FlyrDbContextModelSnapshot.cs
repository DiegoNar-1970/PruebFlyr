﻿// <auto-generated />
using System;
using Flyr.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(FlyrDbContext))]
    partial class FlyrDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Flyr.Domain.Entities.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("JourneyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("TransportId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("JourneyId");

                    b.HasIndex("TransportId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Flyr.Domain.Entities.Journey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Journeys");
                });

            modelBuilder.Entity("Flyr.Domain.Entities.Transport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FlightCarrier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("Flyr.Domain.Entities.Flight", b =>
                {
                    b.HasOne("Flyr.Domain.Entities.Journey", null)
                        .WithMany("Flights")
                        .HasForeignKey("JourneyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Flyr.Domain.Entities.Transport", "Transport")
                        .WithMany()
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("Flyr.Domain.Entities.Journey", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
