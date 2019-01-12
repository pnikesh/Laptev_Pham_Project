using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Laptev_Pham_Project.Migrations
{
    public partial class qerty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Flight_FlightID",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_FlightID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "FlightID",
                table: "Ticket");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalTime",
                table: "Flight",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "Flight",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Direct",
                table: "Flight",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TicketPrice",
                table: "Flight",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "Direct",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Flight");

            migrationBuilder.AddColumn<int>(
                name: "FlightID",
                table: "Ticket",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightID",
                table: "Ticket",
                column: "FlightID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Flight_FlightID",
                table: "Ticket",
                column: "FlightID",
                principalTable: "Flight",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
