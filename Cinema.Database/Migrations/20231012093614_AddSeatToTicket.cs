using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Database.Migrations
{
    public partial class AddSeatToTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeatHallId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SeatNumber",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatHallId_SeatNumber",
                table: "Tickets",
                columns: new[] { "SeatHallId", "SeatNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Seats_SeatHallId_SeatNumber",
                table: "Tickets",
                columns: new[] { "SeatHallId", "SeatNumber" },
                principalTable: "Seats",
                principalColumns: new[] { "HallId", "Number" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seats_SeatHallId_SeatNumber",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_SeatHallId_SeatNumber",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SeatHallId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SeatNumber",
                table: "Tickets");
        }
    }
}
