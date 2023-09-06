using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAgentPro.Migrations
{
    public partial class AddedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: false),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyHolderFName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PolicyHolderLName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyHolderSsn = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    PolicyHolderDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LessThan3YearsDriving = table.Column<bool>(type: "bit", nullable: false),
                    PreviousCarrier = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    MovingViolationInLast5Years = table.Column<bool>(type: "bit", nullable: false),
                    ClaimInLast5Years = table.Column<bool>(type: "bit", nullable: false),
                    ForceMultiCarDiscount = table.Column<bool>(type: "bit", nullable: false),
                    QuotePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverFName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverLName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverSSN = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverLicenseState = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DriverDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SafeDrivingSchool = table.Column<bool>(type: "bit", nullable: false),
                    QuoteMultiplier = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_Drivers_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vin = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CurrentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnnualMileage = table.Column<int>(type: "int", nullable: false),
                    DaytimeRunningLights = table.Column<bool>(type: "bit", nullable: false),
                    AntilockBrakes = table.Column<bool>(type: "bit", nullable: false),
                    PassiveRestraints = table.Column<bool>(type: "bit", nullable: false),
                    AntiTheft = table.Column<bool>(type: "bit", nullable: false),
                    DaysDrivenPerWeek = table.Column<int>(type: "int", nullable: false),
                    MilesDrivenToWork = table.Column<int>(type: "int", nullable: false),
                    ReducedUsedDiscount = table.Column<bool>(type: "bit", nullable: false),
                    GarageAddressDifferentFromResidence = table.Column<bool>(type: "bit", nullable: false),
                    QuoteMultiplier = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrimaryDriverId = table.Column<int>(type: "int", nullable: false),
                    QuoteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DriverVehicle",
                columns: table => new
                {
                    DriversDriverId = table.Column<int>(type: "int", nullable: false),
                    VehiclesVehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverVehicle", x => new { x.DriversDriverId, x.VehiclesVehicleId });
                    table.ForeignKey(
                        name: "FK_DriverVehicle_Drivers_DriversDriverId",
                        column: x => x.DriversDriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverVehicle_Vehicles_VehiclesVehicleId",
                        column: x => x.VehiclesVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_QuoteId",
                table: "Drivers",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverVehicle_VehiclesVehicleId",
                table: "DriverVehicle",
                column: "VehiclesVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_QuoteId",
                table: "Vehicles",
                column: "QuoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverVehicle");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
