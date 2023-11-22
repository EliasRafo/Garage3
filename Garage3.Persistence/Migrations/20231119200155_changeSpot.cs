using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeSpot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Address",
                table: "Spot",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Spot");
        }
    }
}
