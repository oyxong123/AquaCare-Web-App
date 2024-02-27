using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquaCare_Web_App.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    Model = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ph = table.Column<decimal>(type: "decimal(6,4)", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    SunlightIntensity = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    Salinity = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    Turbidity = table.Column<decimal>(type: "decimal(8,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Model);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensor");
        }
    }
}
