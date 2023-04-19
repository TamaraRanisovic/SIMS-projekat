using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class Res : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AccomodationReservations",
                newName: "AccomodationReservationId");

            migrationBuilder.AddColumn<int>(
                name: "AccomodationReservationId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccomodationReservationId",
                table: "Accomodations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccomodationReservationId",
                table: "Users",
                column: "AccomodationReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accomodations_AccomodationReservationId",
                table: "Accomodations",
                column: "AccomodationReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_AccomodationReservations_AccomodationReservationId",
                table: "Accomodations",
                column: "AccomodationReservationId",
                principalTable: "AccomodationReservations",
                principalColumn: "AccomodationReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AccomodationReservations_AccomodationReservationId",
                table: "Users",
                column: "AccomodationReservationId",
                principalTable: "AccomodationReservations",
                principalColumn: "AccomodationReservationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_AccomodationReservations_AccomodationReservationId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AccomodationReservations_AccomodationReservationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AccomodationReservationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Accomodations_AccomodationReservationId",
                table: "Accomodations");

            migrationBuilder.DropColumn(
                name: "AccomodationReservationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AccomodationReservationId",
                table: "Accomodations");

            migrationBuilder.RenameColumn(
                name: "AccomodationReservationId",
                table: "AccomodationReservations",
                newName: "Id");
        }
    }
}
