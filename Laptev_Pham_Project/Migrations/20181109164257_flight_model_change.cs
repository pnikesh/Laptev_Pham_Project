using Microsoft.EntityFrameworkCore.Migrations;

namespace Laptev_Pham_Project.Migrations
{
    public partial class flight_model_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_ArrivalCity_ArrivalCityID",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_DepartureCity_DepartureCityID",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_ArrivalCityID",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_DepartureCityID",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "ArrivalCityID",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "DepartureCityID",
                table: "Flight");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalCity",
                table: "Flight",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartureCity",
                table: "Flight",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalCity",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "DepartureCity",
                table: "Flight");

            migrationBuilder.AddColumn<int>(
                name: "ArrivalCityID",
                table: "Flight",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartureCityID",
                table: "Flight",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ArrivalCityID",
                table: "Flight",
                column: "ArrivalCityID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DepartureCityID",
                table: "Flight",
                column: "DepartureCityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_ArrivalCity_ArrivalCityID",
                table: "Flight",
                column: "ArrivalCityID",
                principalTable: "ArrivalCity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_DepartureCity_DepartureCityID",
                table: "Flight",
                column: "DepartureCityID",
                principalTable: "DepartureCity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
