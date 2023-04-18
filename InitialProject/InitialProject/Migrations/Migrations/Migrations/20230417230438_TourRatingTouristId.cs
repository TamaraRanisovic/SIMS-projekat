using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class TourRatingTouristId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "touristId",
                table: "Rating",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Users_touristId",
                table: "Rating",
                column: "touristId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "TouristId",
                table: "Rating",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Users_TouristId",
                table: "Rating",
                column: "TouristId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
