using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class DatesTourists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DatesId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DatesId",
                table: "Users",
                column: "DatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Dates_DatesId",
                table: "Users",
                column: "DatesId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Dates_DatesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DatesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DatesId",
                table: "Users");
        }
    }
}
