﻿// <auto-generated />
using System;
using Garage3.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Garage3.Persistence.Migrations
{
    [DbContext(typeof(Garage3WebContext))]
    partial class Garage3WebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

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
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8591),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8639),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 2,
                            Active = false,
                            Address = 2,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8645),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8647),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 3,
                            Active = false,
                            Address = 3,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8649),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8650),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 4,
                            Active = false,
                            Address = 4,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8652),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8653),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 5,
                            Active = false,
                            Address = 5,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8655),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8657),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 6,
                            Active = false,
                            Address = 6,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8661),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8662),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 7,
                            Active = false,
                            Address = 7,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8664),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8665),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 8,
                            Active = false,
                            Address = 8,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8667),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8668),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 9,
                            Active = false,
                            Address = 9,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8670),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8672),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 10,
                            Active = false,
                            Address = 10,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8674),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8676),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 11,
                            Active = false,
                            Address = 11,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8677),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8679),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 12,
                            Active = false,
                            Address = 12,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8681),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8682),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 13,
                            Active = false,
                            Address = 13,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8684),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8685),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 14,
                            Active = false,
                            Address = 14,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8687),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8688),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 15,
                            Active = false,
                            Address = 15,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8690),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8691),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 16,
                            Active = false,
                            Address = 16,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8693),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8694),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 17,
                            Active = false,
                            Address = 17,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8696),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8697),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 18,
                            Active = false,
                            Address = 18,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8700),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8702),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 19,
                            Active = false,
                            Address = 19,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8704),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8705),
                            GarageId = 1
                        },
                        new
                        {
                            Id = 20,
                            Active = false,
                            Address = 20,
                            CheckIn = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8707),
                            CheckOut = new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8708),
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
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("RegNum")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

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
