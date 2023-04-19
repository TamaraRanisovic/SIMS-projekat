using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class AccRes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservation_Accomodations_AccomodationAccId",
                table: "AccomodationReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservation_Users_GuestId",
                table: "AccomodationReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccomodationReservation",
                table: "AccomodationReservation");

            migrationBuilder.RenameTable(
                name: "AccomodationReservation",
                newName: "AccomodationReservations");

            migrationBuilder.RenameIndex(
                name: "IX_AccomodationReservation_GuestId",
                table: "AccomodationReservations",
                newName: "IX_AccomodationReservations_GuestId");

            migrationBuilder.RenameIndex(
                name: "IX_AccomodationReservation_AccomodationAccId",
                table: "AccomodationReservations",
                newName: "IX_AccomodationReservations_AccomodationAccId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccomodationReservations",
                table: "AccomodationReservations",
                column: "Id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservations_Accomodations_AccomodationAccId",
                table: "AccomodationReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservations_Users_GuestId",
                table: "AccomodationReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccomodationReservations",
                table: "AccomodationReservations");

            migrationBuilder.RenameTable(
                name: "AccomodationReservations",
                newName: "AccomodationReservation");

            migrationBuilder.RenameIndex(
                name: "IX_AccomodationReservations_GuestId",
                table: "AccomodationReservation",
                newName: "IX_AccomodationReservation_GuestId");

            migrationBuilder.RenameIndex(
                name: "IX_AccomodationReservations_AccomodationAccId",
                table: "AccomodationReservation",
                newName: "IX_AccomodationReservation_AccomodationAccId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccomodationReservation",
                table: "AccomodationReservation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationReservation_Accomodations_AccomodationAccId",
                table: "AccomodationReservation",
                column: "AccomodationAccId",
                principalTable: "Accomodations",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationReservation_Users_GuestId",
                table: "AccomodationReservation",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
