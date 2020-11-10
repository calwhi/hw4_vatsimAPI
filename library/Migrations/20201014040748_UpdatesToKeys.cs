using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace library.Migrations
{
    public partial class UpdatesToKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Controllers",
                columns: table => new
                {
                    Cid = table.Column<string>(nullable: false),
                    Callsign = table.Column<string>(nullable: false),
                    TimeLogon = table.Column<string>(nullable: false),
                    Realname = table.Column<string>(nullable: true),
                    Clienttype = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Server = table.Column<string>(nullable: true),
                    Protrevision = table.Column<string>(nullable: true),
                    TimeLastAtisReceived = table.Column<string>(nullable: true),
                    AtisMessage = table.Column<string>(nullable: true),
                    Frequency = table.Column<string>(nullable: true),
                    Facilitytype = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true),
                    Visualrange = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controllers", x => new { x.Cid, x.Callsign, x.TimeLogon });
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Cid = table.Column<string>(nullable: false),
                    Callsign = table.Column<string>(nullable: false),
                    TimeLogon = table.Column<string>(nullable: false),
                    PlannedDepairport = table.Column<string>(nullable: false),
                    PlannedDestairport = table.Column<string>(nullable: false),
                    Realname = table.Column<string>(nullable: true),
                    Clienttype = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Server = table.Column<string>(nullable: true),
                    Protrevision = table.Column<string>(nullable: true),
                    TimeLastAtisReceived = table.Column<string>(nullable: true),
                    PlannedAircraft = table.Column<string>(nullable: true),
                    PlannedAltitude = table.Column<string>(nullable: true),
                    PlannedAltairport = table.Column<string>(nullable: true),
                    PlannedDepairportLat = table.Column<string>(nullable: true),
                    PlannedDestairportLon = table.Column<string>(nullable: true),
                    PlannedDepairportLon = table.Column<string>(nullable: true),
                    PlannedDestairportLat = table.Column<string>(nullable: true),
                    PlannedFlighttype = table.Column<string>(nullable: true),
                    PlannedDeptime = table.Column<string>(nullable: true),
                    PlannedActdeptime = table.Column<string>(nullable: true),
                    PlannedHrsenroute = table.Column<string>(nullable: true),
                    PlannedMinenroute = table.Column<string>(nullable: true),
                    PlannedHrsfuel = table.Column<string>(nullable: true),
                    PlannedMinfuel = table.Column<string>(nullable: true),
                    PlannedRemarks = table.Column<string>(nullable: true),
                    PlannedRevision = table.Column<string>(nullable: true),
                    PlannedRoute = table.Column<string>(nullable: true),
                    PlannedTascruise = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => new { x.Cid, x.Callsign, x.TimeLogon, x.PlannedDepairport, x.PlannedDestairport });
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Cid = table.Column<string>(nullable: false),
                    Callsign = table.Column<string>(nullable: false),
                    TimeLogon = table.Column<string>(nullable: false),
                    Realname = table.Column<string>(nullable: true),
                    Clienttype = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Server = table.Column<string>(nullable: true),
                    Protrevision = table.Column<string>(nullable: true),
                    TimeLastAtisReceived = table.Column<string>(nullable: true),
                    FlightCid = table.Column<string>(nullable: true),
                    FlightCallsign = table.Column<string>(nullable: true),
                    FlightTimeLogon = table.Column<string>(nullable: true),
                    FlightPlannedDepairport = table.Column<string>(nullable: true),
                    FlightPlannedDestairport = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => new { x.Cid, x.Callsign, x.TimeLogon });
                    table.ForeignKey(
                        name: "FK_Pilots_Flights_FlightCid_FlightCallsign_FlightTimeLogon_FlightPlannedDepairport_FlightPlannedDestairport",
                        columns: x => new { x.FlightCid, x.FlightCallsign, x.FlightTimeLogon, x.FlightPlannedDepairport, x.FlightPlannedDestairport },
                        principalTable: "Flights",
                        principalColumns: new[] { "Cid", "Callsign", "TimeLogon", "PlannedDepairport", "PlannedDestairport" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Cid = table.Column<string>(nullable: false),
                    Callsign = table.Column<string>(nullable: false),
                    TimeLogon = table.Column<string>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Realname = table.Column<string>(nullable: true),
                    Clienttype = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Server = table.Column<string>(nullable: true),
                    Protrevision = table.Column<string>(nullable: true),
                    TimeLastAtisReceived = table.Column<string>(nullable: true),
                    Altitude = table.Column<string>(nullable: true),
                    Groundspeed = table.Column<string>(nullable: true),
                    Transponder = table.Column<string>(nullable: true),
                    Heading = table.Column<string>(nullable: true),
                    QNH_iHg = table.Column<string>(nullable: true),
                    QNH_Mb = table.Column<string>(nullable: true),
                    VatsimClientPilotCallsign = table.Column<string>(nullable: true),
                    VatsimClientPilotCid = table.Column<string>(nullable: true),
                    VatsimClientPilotTimeLogon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => new { x.Cid, x.Callsign, x.TimeLogon, x.TimeStamp });
                    table.ForeignKey(
                        name: "FK_Positions_Pilots_VatsimClientPilotCid_VatsimClientPilotCallsign_VatsimClientPilotTimeLogon",
                        columns: x => new { x.VatsimClientPilotCid, x.VatsimClientPilotCallsign, x.VatsimClientPilotTimeLogon },
                        principalTable: "Pilots",
                        principalColumns: new[] { "Cid", "Callsign", "TimeLogon" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_FlightCid_FlightCallsign_FlightTimeLogon_FlightPlannedDepairport_FlightPlannedDestairport",
                table: "Pilots",
                columns: new[] { "FlightCid", "FlightCallsign", "FlightTimeLogon", "FlightPlannedDepairport", "FlightPlannedDestairport" });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_VatsimClientPilotCid_VatsimClientPilotCallsign_VatsimClientPilotTimeLogon",
                table: "Positions",
                columns: new[] { "VatsimClientPilotCid", "VatsimClientPilotCallsign", "VatsimClientPilotTimeLogon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Controllers");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
