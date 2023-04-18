using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class TourRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TourRatingId",
                table: "TourImages",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TourId",
                table: "Coupons",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuideKnowledge = table.Column<int>(type: "INTEGER", nullable: false),
                    GuideLanguage = table.Column<int>(type: "INTEGER", nullable: false),
                    TourAmusement = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    TouristId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Users_TouristId",
                        column: x => x.TouristId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourImages_TourRatingId",
                table: "TourImages",
                column: "TourRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_TouristId",
                table: "Rating",
                column: "TouristId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourImages_Rating_TourRatingId",
                table: "TourImages",
                column: "TourRatingId",
                principalTable: "Rating",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourImages_Rating_TourRatingId",
                table: "TourImages");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_TourImages_TourRatingId",
                table: "TourImages");

            migrationBuilder.DropColumn(
                name: "TourRatingId",
                table: "TourImages");

            migrationBuilder.AlterColumn<int>(
                name: "TourId",
                table: "Coupons",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
