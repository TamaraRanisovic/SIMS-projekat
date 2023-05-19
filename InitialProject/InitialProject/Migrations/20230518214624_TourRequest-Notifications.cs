using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class TourRequestNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TourRequestId",
                table: "TouristNotifications",
                type: "INTEGER",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristNotifications_TourRequests_TourRequestId",
                table: "TouristNotifications");

            migrationBuilder.DropIndex(
                name: "IX_TouristNotifications_TourRequestId",
                table: "TouristNotifications");

            migrationBuilder.DropColumn(
                name: "TourRequestId",
                table: "TouristNotifications");
        }
    }
}
