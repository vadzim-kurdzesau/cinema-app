using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Database.Migrations
{
    public partial class ConfigureRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaHallEntityMovieEntity");

            migrationBuilder.CreateTable(
                name: "Movies_In_Halls",
                columns: table => new
                {
                    HallsId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies_In_Halls", x => new { x.HallsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_Movies_In_Halls_CinemaHalls_HallsId",
                        column: x => x.HallsId,
                        principalTable: "CinemaHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_In_Halls_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_In_Halls_MoviesId",
                table: "Movies_In_Halls",
                column: "MoviesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies_In_Halls");

            migrationBuilder.CreateTable(
                name: "CinemaHallEntityMovieEntity",
                columns: table => new
                {
                    HallsId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHallEntityMovieEntity", x => new { x.HallsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CinemaHallEntityMovieEntity_CinemaHalls_HallsId",
                        column: x => x.HallsId,
                        principalTable: "CinemaHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaHallEntityMovieEntity_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHallEntityMovieEntity_MoviesId",
                table: "CinemaHallEntityMovieEntity",
                column: "MoviesId");
        }
    }
}
