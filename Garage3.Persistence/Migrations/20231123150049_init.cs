using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Garage3.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SocialNum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GarageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    RegNum = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WheelsNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<int>(type: "int", nullable: false),
                    GarageId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spot_Garage_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spot_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Garage",
                columns: new[] { "Id", "Capacity", "GarageName" },
                values: new object[] { 1, 20, "Garage3" });

            migrationBuilder.InsertData(
                table: "Spot",
                columns: new[] { "Id", "Active", "Address", "CheckIn", "CheckOut", "GarageId", "VehicleId" },
                values: new object[,]
                {
                    { 1, false, 1, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8591), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8639), 1, null },
                    { 2, false, 2, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8645), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8647), 1, null },
                    { 3, false, 3, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8649), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8650), 1, null },
                    { 4, false, 4, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8652), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8653), 1, null },
                    { 5, false, 5, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8655), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8657), 1, null },
                    { 6, false, 6, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8661), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8662), 1, null },
                    { 7, false, 7, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8664), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8665), 1, null },
                    { 8, false, 8, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8667), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8668), 1, null },
                    { 9, false, 9, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8670), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8672), 1, null },
                    { 10, false, 10, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8674), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8676), 1, null },
                    { 11, false, 11, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8677), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8679), 1, null },
                    { 12, false, 12, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8681), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8682), 1, null },
                    { 13, false, 13, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8684), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8685), 1, null },
                    { 14, false, 14, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8687), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8688), 1, null },
                    { 15, false, 15, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8690), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8691), 1, null },
                    { 16, false, 16, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8693), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8694), 1, null },
                    { 17, false, 17, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8696), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8697), 1, null },
                    { 18, false, 18, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8700), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8702), 1, null },
                    { 19, false, 19, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8704), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8705), 1, null },
                    { 20, false, 20, new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8707), new DateTime(2023, 11, 23, 16, 0, 49, 266, DateTimeKind.Local).AddTicks(8708), 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spot_GarageId",
                table: "Spot",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_Spot_VehicleId",
                table: "Spot",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CustomerId",
                table: "Vehicle",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spot");

            migrationBuilder.DropTable(
                name: "Garage");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
