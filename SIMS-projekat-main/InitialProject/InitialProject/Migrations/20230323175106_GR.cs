using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class GR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "AccomodationReservationId",
                table: "GuestRatings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GuestRatings_AccomodationReservationId",
                table: "GuestRatings",
                column: "AccomodationReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestRatings_AccomodationReservations_AccomodationReservationId",
                table: "GuestRatings",
                column: "AccomodationReservationId",
                principalTable: "AccomodationReservations",
                principalColumn: "AccomodationReservationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestRatings_AccomodationReservations_AccomodationReservationId",
                table: "GuestRatings");

            migrationBuilder.DropIndex(
                name: "IX_GuestRatings_AccomodationReservationId",
                table: "GuestRatings");

            migrationBuilder.DropColumn(
                name: "AccomodationReservationId",
                table: "GuestRatings");

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
    }
}
