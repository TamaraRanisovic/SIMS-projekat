using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class renAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationImages_Accomodations_AccomodationId",
                table: "AccomodationImages");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservations_Accomodations_AccomodationId",
                table: "AccomodationReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_AccomodationReservations_AccomodationReservationId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_Users_GuestId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_Users_OwnerId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_GuestId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestRatings_Users_OwnerId",
                table: "GuestRatings");

            migrationBuilder.CreateTable(
                name: "Renovations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccomodationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renovations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Renovations_Accomodations_AccomodationId",
                        column: x => x.AccomodationId,
                        principalTable: "Accomodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Renovations_AccomodationId",
                table: "Renovations",
                column: "AccomodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationImages_Accomodations_AccomodationId",
                table: "AccomodationImages",
                column: "AccomodationId",
                principalTable: "Accomodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationReservations_Accomodations_AccomodationId",
                table: "AccomodationReservations",
                column: "AccomodationId",
                principalTable: "Accomodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_AccomodationReservations_AccomodationReservationId",
                table: "Accomodations",
                column: "AccomodationReservationId",
                principalTable: "AccomodationReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_Users_GuestId",
                table: "Accomodations",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_Users_OwnerId",
                table: "Accomodations",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_GuestId",
                table: "Comments",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestRatings_Users_OwnerId",
                table: "GuestRatings",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationImages_Accomodations_AccomodationId",
                table: "AccomodationImages");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservations_Accomodations_AccomodationId",
                table: "AccomodationReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_AccomodationReservations_AccomodationReservationId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_Users_GuestId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_Users_OwnerId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_GuestId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestRatings_Users_OwnerId",
                table: "GuestRatings");

            migrationBuilder.DropTable(
                name: "Renovations");

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationImages_Accomodations_AccomodationId",
                table: "AccomodationImages",
                column: "AccomodationId",
                principalTable: "Accomodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationReservations_Accomodations_AccomodationId",
                table: "AccomodationReservations",
                column: "AccomodationId",
                principalTable: "Accomodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_AccomodationReservations_AccomodationReservationId",
                table: "Accomodations",
                column: "AccomodationReservationId",
                principalTable: "AccomodationReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_Users_GuestId",
                table: "Accomodations",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_Users_OwnerId",
                table: "Accomodations",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_GuestId",
                table: "Comments",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestRatings_Users_OwnerId",
                table: "GuestRatings",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
