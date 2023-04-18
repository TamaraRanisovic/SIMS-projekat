using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class TourRatingTouristId1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Users_touristId",
                table: "Rating");

            migrationBuilder.RenameColumn(
                name: "touristId",
                table: "Rating",
                newName: "TouristId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_touristId",
                table: "Rating",
                newName: "IX_Rating_TouristId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Users_TouristId",
                table: "Rating",
                column: "TouristId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Users_TouristId",
                table: "Rating");

            migrationBuilder.RenameColumn(
                name: "TouristId",
                table: "Rating",
                newName: "touristId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_TouristId",
                table: "Rating",
                newName: "IX_Rating_touristId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Users_touristId",
                table: "Rating",
                column: "touristId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
