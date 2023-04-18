using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class TourRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TouristId",
                table: "TourRatings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TourRatings_TouristId",
                table: "TourRatings",
                column: "TouristId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourRatings_Users_TouristId",
                table: "TourRatings",
                column: "TouristId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourRatings_Users_TouristId",
                table: "TourRatings");

            migrationBuilder.DropIndex(
                name: "IX_TourRatings_TouristId",
                table: "TourRatings");

            migrationBuilder.DropColumn(
                name: "TouristId",
                table: "TourRatings");
        }
    }
}
