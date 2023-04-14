using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class Removing_tours_fromddates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Dates_DatesId",
                table: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_Tours_DatesId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "DatesId",
                table: "Tours");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DatesId",
                table: "Tours",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tours_DatesId",
                table: "Tours",
                column: "DatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Dates_DatesId",
                table: "Tours",
                column: "DatesId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
