using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class GuestRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuestRatingId",
                table: "AccomodationReservations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccomodationReservations_GuestRatingId",
                table: "AccomodationReservations",
                column: "GuestRatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationReservations_GuestRatings_GuestRatingId",
                table: "AccomodationReservations",
                column: "GuestRatingId",
                principalTable: "GuestRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservations_GuestRatings_GuestRatingId",
                table: "AccomodationReservations");

            migrationBuilder.DropIndex(
                name: "IX_AccomodationReservations_GuestRatingId",
                table: "AccomodationReservations");

            migrationBuilder.DropColumn(
                name: "GuestRatingId",
                table: "AccomodationReservations");
        }
    }
}
