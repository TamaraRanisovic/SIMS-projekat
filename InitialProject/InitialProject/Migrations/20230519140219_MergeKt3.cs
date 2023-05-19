using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class MergeKt3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuideId",
                table: "TourRequests",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TouristId",
                table: "TourRequests",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TourRequestId",
                table: "TouristNotifications",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "TouristNotifications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TourRequests_GuideId",
                table: "TourRequests",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_TourRequests_TouristId",
                table: "TourRequests",
                column: "TouristId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristNotifications_TourRequestId",
                table: "TouristNotifications",
                column: "TourRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristNotifications_TourRequests_TourRequestId",
                table: "TouristNotifications",
                column: "TourRequestId",
                principalTable: "TourRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourRequests_Users_GuideId",
                table: "TourRequests",
                column: "GuideId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourRequests_Users_TouristId",
                table: "TourRequests",
                column: "TouristId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristNotifications_TourRequests_TourRequestId",
                table: "TouristNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TourRequests_Users_GuideId",
                table: "TourRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TourRequests_Users_TouristId",
                table: "TourRequests");

            migrationBuilder.DropIndex(
                name: "IX_TourRequests_GuideId",
                table: "TourRequests");

            migrationBuilder.DropIndex(
                name: "IX_TourRequests_TouristId",
                table: "TourRequests");

            migrationBuilder.DropIndex(
                name: "IX_TouristNotifications_TourRequestId",
                table: "TouristNotifications");

            migrationBuilder.DropColumn(
                name: "GuideId",
                table: "TourRequests");

            migrationBuilder.DropColumn(
                name: "TouristId",
                table: "TourRequests");

            migrationBuilder.DropColumn(
                name: "TourRequestId",
                table: "TouristNotifications");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "TouristNotifications");
        }
    }
}
