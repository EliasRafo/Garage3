using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Garage3.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Seed_capacity_and_spots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Garage",
                columns: new[] { "Id", "Capacity", "GarageName" },
                values: new object[] { 1, 20, "Garage3" });

            migrationBuilder.InsertData(
                table: "Spot",
                columns: new[] { "Id", "Active", "Address", "CheckIn", "CheckOut", "GarageId", "VehicleId" },
                values: new object[,]
                {
                    { 1, false, 1, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9878), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9955), 1, null },
                    { 2, false, 2, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9960), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9961), 1, null },
                    { 3, false, 3, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9963), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9964), 1, null },
                    { 4, false, 4, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9965), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9966), 1, null },
                    { 5, false, 5, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9967), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9968), 1, null },
                    { 6, false, 6, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9971), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9972), 1, null },
                    { 7, false, 7, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9973), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9974), 1, null },
                    { 8, false, 8, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9976), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9977), 1, null },
                    { 9, false, 9, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9978), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9979), 1, null },
                    { 10, false, 10, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9981), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9982), 1, null },
                    { 11, false, 11, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9983), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9984), 1, null },
                    { 12, false, 12, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9986), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9987), 1, null },
                    { 13, false, 13, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9988), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9989), 1, null },
                    { 14, false, 14, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9990), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9991), 1, null },
                    { 15, false, 15, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9992), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9993), 1, null },
                    { 16, false, 16, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9994), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9995), 1, null },
                    { 17, false, 17, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9996), new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9997), 1, null },
                    { 18, false, 18, new DateTime(2023, 11, 22, 16, 59, 43, 697, DateTimeKind.Local).AddTicks(9999), new DateTime(2023, 11, 22, 16, 59, 43, 698, DateTimeKind.Local), 1, null },
                    { 19, false, 19, new DateTime(2023, 11, 22, 16, 59, 43, 698, DateTimeKind.Local).AddTicks(1), new DateTime(2023, 11, 22, 16, 59, 43, 698, DateTimeKind.Local).AddTicks(3), 1, null },
                    { 20, false, 20, new DateTime(2023, 11, 22, 16, 59, 43, 698, DateTimeKind.Local).AddTicks(4), new DateTime(2023, 11, 22, 16, 59, 43, 698, DateTimeKind.Local).AddTicks(5), 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Spot",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Garage",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
