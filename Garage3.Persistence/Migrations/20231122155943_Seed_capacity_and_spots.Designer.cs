﻿// <auto-generated />
using System;
using Garage3.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Garage3.Persistence.Migrations
{
    [DbContext(typeof(Garage3WebContext))]
    [Migration("20231122155943_Seed_capacity_and_spots")]
    partial class Seed_capacity_and_spots
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Garage3.Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Garage3.Core.Entities.Garage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("GarageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Garage");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 20,
                            GarageName = "Garage3"
                        });
                });

            modelBuilder.Entity("Garage3.Core.Entities.Spot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("Address")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<int>("GarageId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GarageId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Spot");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = false,
                            Address = 1,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9878),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9955),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 2,
                            Active = false,
                            Address = 2,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9960),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9961),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 3,
                            Active = false,
                            Address = 3,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9963),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9964),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 4,
                            Active = false,
                            Address = 4,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9965),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9966),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 5,
                            Active = false,
                            Address = 5,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9967),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9968),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 6,
                            Active = false,
                            Address = 6,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9971),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9972),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 7,
                            Active = false,
                            Address = 7,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9973),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9974),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 8,
                            Active = false,
                            Address = 8,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9976),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9977),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 9,
                            Active = false,
                            Address = 9,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9978),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9979),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 10,
                            Active = false,
                            Address = 10,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9981),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9982),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 11,
                            Active = false,
                            Address = 11,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9983),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9984),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 12,
                            Active = false,
                            Address = 12,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9986),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9987),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 13,
                            Active = false,
                            Address = 13,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9988),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9989),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 14,
                            Active = false,
                            Address = 14,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9990),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9991),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 15,
                            Active = false,
                            Address = 15,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9992),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9993),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 16,
                            Active = false,
                            Address = 16,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9994),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9995),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 17,
                            Active = false,
                            Address = 17,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9996),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9997),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 18,
                            Active = false,
                            Address = 18,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9999),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 698, DateTimeKind.Local),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 19,
                            Active = false,
                            Address = 19,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 698, DateTimeKind.Local).AddTicks(1),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 698, DateTimeKind.Local).AddTicks(3),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 20,
                            Active = false,
                            Address = 20,
                            CheckIn = new DateTime(2023, 11, 22, 16, 59, 43, 698, DateTimeKind.Local).AddTicks(4),
                            CheckOut = new DateTime(2023, 11, 22, 16, 59, 43, 698, DateTimeKind.Local).AddTicks(5),
                            GarageId = 1
                        });
                });

            modelBuilder.Entity("Garage3.Core.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.Property<int>("WheelsNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Garage3.Core.Entities.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleType");
                });

            modelBuilder.Entity("Garage3.Core.Entities.Spot", b =>
                {
                    b.HasOne("Garage3.Core.Entities.Garage", "Garage")
                        .WithMany("Spots")
                        .HasForeignKey("GarageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garage3.Core.Entities.Vehicle", "Vehicle")
                        .WithMany("Spots")
                        .HasForeignKey("VehicleId");

                    b.Navigation("Garage");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Garage3.Core.Entities.Vehicle", b =>
                {
                    b.HasOne("Garage3.Core.Entities.Customer", "Customer")
                        .WithMany("Vehicles")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garage3.Core.Entities.VehicleType", "VehicleType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("Garage3.Core.Entities.Customer", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Garage3.Core.Entities.Garage", b =>
                {
                    b.Navigation("Spots");
                });

            modelBuilder.Entity("Garage3.Core.Entities.Vehicle", b =>
                {
                    b.Navigation("Spots");
                });

            modelBuilder.Entity("Garage3.Core.Entities.VehicleType", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
