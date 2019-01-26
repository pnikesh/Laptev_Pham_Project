using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Laptev_Pham_Project.Migrations
{
    public partial class GeneratingnewDBOrdersTicketsCustomerupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_ArrivalCity_ArrivalCityNameID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_DepartureCity_DepartureCityNameID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Flight_FlightID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Ticket_TicketID",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ArrivalCityNameID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_DepartureCityNameID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_FlightID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_TicketID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ArrivalCityNameID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DepartureCityNameID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "FlightID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TicketID",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customer",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalTimeFrom",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArrivalTimeTo",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartureTimeFrom",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartureTimeTo",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isRound",
                table: "Ticket",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Order",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Order",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "TotalSum",
                table: "Order",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OrderNumber",
                table: "Ticket",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ID",
                table: "Order",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_ID",
                table: "Order",
                column: "ID",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Order_OrderNumber",
                table: "Ticket",
                column: "OrderNumber",
                principalTable: "Order",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_ID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Order_OrderNumber",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_OrderNumber",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ArrivalTimeFrom",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ArrivalTimeTo",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "DepartureTimeFrom",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "DepartureTimeTo",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "isRound",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TotalSum",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Customer",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Order",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ArrivalCityNameID",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartureCityNameID",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlightID",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketID",
                table: "Order",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ArrivalCityNameID",
                table: "Order",
                column: "ArrivalCityNameID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DepartureCityNameID",
                table: "Order",
                column: "DepartureCityNameID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_FlightID",
                table: "Order",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TicketID",
                table: "Order",
                column: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ArrivalCity_ArrivalCityNameID",
                table: "Order",
                column: "ArrivalCityNameID",
                principalTable: "ArrivalCity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DepartureCity_DepartureCityNameID",
                table: "Order",
                column: "DepartureCityNameID",
                principalTable: "DepartureCity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Flight_FlightID",
                table: "Order",
                column: "FlightID",
                principalTable: "Flight",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Ticket_TicketID",
                table: "Order",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
