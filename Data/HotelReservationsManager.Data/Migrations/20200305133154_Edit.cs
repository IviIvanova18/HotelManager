using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationsManager.Data.Migrations
{
    public partial class Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Reservations_ReservationId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ReservationId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Clients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReservationId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ReservationId",
                table: "Clients",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Reservations_ReservationId",
                table: "Clients",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
