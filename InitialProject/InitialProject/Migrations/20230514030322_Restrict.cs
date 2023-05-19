using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class Restrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationImages_Accomodations_AccomodationAccId",
                table: "AccomodationImages");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservations_Accomodations_AccomodationAccId",
                table: "AccomodationReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservations_Users_GuestId",
                table: "AccomodationReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_AccomodationReservations_AccomodationReservationId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_Locations_LocationId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_Users_GuestId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_Users_OwnerId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkpoints_Tours_TourId",
                table: "Checkpoints");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Users_TouristId",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK_Dates_Tours_TourId",
                table: "Dates");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestRatings_Users_OwnerId",
                table: "GuestRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourImages_TourRatings_TourRatingId",
                table: "TourImages");

            migrationBuilder.DropForeignKey(
                name: "FK_TourImages_Tours_TourId",
                table: "TourImages");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristNotifications_TourReservations_TourReservationId",
                table: "TouristNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristNotifications_Users_TouristId",
                table: "TouristNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TourRatings_Tours_TourId",
                table: "TourRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourRatings_Users_TouristId",
                table: "TourRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourReservations_Checkpoints_CheckpointId",
                table: "TourReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_TourReservations_Tours_TourId",
                table: "TourReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_TourReservations_Users_TouristId",
                table: "TourReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Locations_LocationId",
                table: "Tours");

            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Users_GuideId",
                table: "Tours");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AccomodationReservations_AccomodationReservationId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accomodations_AccomodationAccId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Checkpoints_CheckpointId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Dates_DatesId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tours_TourId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationImages_Accomodations_AccomodationAccId",
                table: "AccomodationImages",
                column: "AccomodationAccId",
                principalTable: "Accomodations",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationReservations_Accomodations_AccomodationAccId",
                table: "AccomodationReservations",
                column: "AccomodationAccId",
                principalTable: "Accomodations",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationReservations_Users_GuestId",
                table: "AccomodationReservations",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_AccomodationReservations_AccomodationReservationId",
                table: "Accomodations",
                column: "AccomodationReservationId",
                principalTable: "AccomodationReservations",
                principalColumn: "AccomodationReservationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_Locations_LocationId",
                table: "Accomodations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_Users_GuestId",
                table: "Accomodations",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_Users_OwnerId",
                table: "Accomodations",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkpoints_Tours_TourId",
                table: "Checkpoints",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Users_TouristId",
                table: "Coupons",
                column: "TouristId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dates_Tours_TourId",
                table: "Dates",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestRatings_Users_OwnerId",
                table: "GuestRatings",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TourImages_TourRatings_TourRatingId",
                table: "TourImages",
                column: "TourRatingId",
                principalTable: "TourRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TourImages_Tours_TourId",
                table: "TourImages",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristNotifications_TourReservations_TourReservationId",
                table: "TouristNotifications",
                column: "TourReservationId",
                principalTable: "TourReservations",
                principalColumn: "TourReservationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristNotifications_Users_TouristId",
                table: "TouristNotifications",
                column: "TouristId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TourRatings_Tours_TourId",
                table: "TourRatings",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TourRatings_Users_TouristId",
                table: "TourRatings",
                column: "TouristId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TourReservations_Checkpoints_CheckpointId",
                table: "TourReservations",
                column: "CheckpointId",
                principalTable: "Checkpoints",
                principalColumn: "CheckpointId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TourReservations_Tours_TourId",
                table: "TourReservations",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TourReservations_Users_TouristId",
                table: "TourReservations",
                column: "TouristId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Locations_LocationId",
                table: "Tours",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Users_GuideId",
                table: "Tours",
                column: "GuideId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AccomodationReservations_AccomodationReservationId",
                table: "Users",
                column: "AccomodationReservationId",
                principalTable: "AccomodationReservations",
                principalColumn: "AccomodationReservationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accomodations_AccomodationAccId",
                table: "Users",
                column: "AccomodationAccId",
                principalTable: "Accomodations",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Checkpoints_CheckpointId",
                table: "Users",
                column: "CheckpointId",
                principalTable: "Checkpoints",
                principalColumn: "CheckpointId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Dates_DatesId",
                table: "Users",
                column: "DatesId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tours_TourId",
                table: "Users",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationImages_Accomodations_AccomodationAccId",
                table: "AccomodationImages");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservations_Accomodations_AccomodationAccId",
                table: "AccomodationReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservations_Users_GuestId",
                table: "AccomodationReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_AccomodationReservations_AccomodationReservationId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_Locations_LocationId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_Users_GuestId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_Users_OwnerId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkpoints_Tours_TourId",
                table: "Checkpoints");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Users_TouristId",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK_Dates_Tours_TourId",
                table: "Dates");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestRatings_Users_OwnerId",
                table: "GuestRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourImages_TourRatings_TourRatingId",
                table: "TourImages");

            migrationBuilder.DropForeignKey(
                name: "FK_TourImages_Tours_TourId",
                table: "TourImages");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristNotifications_TourReservations_TourReservationId",
                table: "TouristNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristNotifications_Users_TouristId",
                table: "TouristNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TourRatings_Tours_TourId",
                table: "TourRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourRatings_Users_TouristId",
                table: "TourRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourReservations_Checkpoints_CheckpointId",
                table: "TourReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_TourReservations_Tours_TourId",
                table: "TourReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_TourReservations_Users_TouristId",
                table: "TourReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Locations_LocationId",
                table: "Tours");

            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Users_GuideId",
                table: "Tours");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AccomodationReservations_AccomodationReservationId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accomodations_AccomodationAccId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Checkpoints_CheckpointId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Dates_DatesId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tours_TourId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationImages_Accomodations_AccomodationAccId",
                table: "AccomodationImages",
                column: "AccomodationAccId",
                principalTable: "Accomodations",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationReservations_Accomodations_AccomodationAccId",
                table: "AccomodationReservations",
                column: "AccomodationAccId",
                principalTable: "Accomodations",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationReservations_Users_GuestId",
                table: "AccomodationReservations",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_AccomodationReservations_AccomodationReservationId",
                table: "Accomodations",
                column: "AccomodationReservationId",
                principalTable: "AccomodationReservations",
                principalColumn: "AccomodationReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_Locations_LocationId",
                table: "Accomodations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_Users_GuestId",
                table: "Accomodations",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_Users_OwnerId",
                table: "Accomodations",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkpoints_Tours_TourId",
                table: "Checkpoints",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Users_TouristId",
                table: "Coupons",
                column: "TouristId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dates_Tours_TourId",
                table: "Dates",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestRatings_Users_OwnerId",
                table: "GuestRatings",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourImages_TourRatings_TourRatingId",
                table: "TourImages",
                column: "TourRatingId",
                principalTable: "TourRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourImages_Tours_TourId",
                table: "TourImages",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristNotifications_TourReservations_TourReservationId",
                table: "TouristNotifications",
                column: "TourReservationId",
                principalTable: "TourReservations",
                principalColumn: "TourReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristNotifications_Users_TouristId",
                table: "TouristNotifications",
                column: "TouristId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourRatings_Tours_TourId",
                table: "TourRatings",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourRatings_Users_TouristId",
                table: "TourRatings",
                column: "TouristId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourReservations_Checkpoints_CheckpointId",
                table: "TourReservations",
                column: "CheckpointId",
                principalTable: "Checkpoints",
                principalColumn: "CheckpointId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourReservations_Tours_TourId",
                table: "TourReservations",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourReservations_Users_TouristId",
                table: "TourReservations",
                column: "TouristId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Locations_LocationId",
                table: "Tours",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Users_GuideId",
                table: "Tours",
                column: "GuideId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AccomodationReservations_AccomodationReservationId",
                table: "Users",
                column: "AccomodationReservationId",
                principalTable: "AccomodationReservations",
                principalColumn: "AccomodationReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accomodations_AccomodationAccId",
                table: "Users",
                column: "AccomodationAccId",
                principalTable: "Accomodations",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Checkpoints_CheckpointId",
                table: "Users",
                column: "CheckpointId",
                principalTable: "Checkpoints",
                principalColumn: "CheckpointId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Dates_DatesId",
                table: "Users",
                column: "DatesId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tours_TourId",
                table: "Users",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
