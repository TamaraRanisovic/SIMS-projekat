using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class mainMergeKt3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationImages_Accomodations_AccomodationAccId",
                table: "AccomodationImages");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservations_Accomodations_AccomodationAccId",
                table: "AccomodationReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservations_Users_GuestId",
                table: "AccomodationReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_AccomodationReservations_AccomodationReservationId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_GuestId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestRatings_AccomodationReservations_AccomodationReservationId",
                table: "GuestRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AccomodationReservations_AccomodationReservationId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accomodations_AccomodationAccId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AccomodationReservationId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accomodations",
                table: "Accomodations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccomodationReservations",
                table: "AccomodationReservations");

            migrationBuilder.DropIndex(
                name: "IX_AccomodationReservations_AccomodationAccId",
                table: "AccomodationReservations");

            migrationBuilder.DropColumn(
                name: "AccomodationAccId",
                table: "AccomodationReservations");

            migrationBuilder.RenameColumn(
                name: "AccomodationReservationId",
                table: "Users",
                newName: "SuperOwner");

            migrationBuilder.RenameColumn(
                name: "AccomodationAccId",
                table: "Users",
                newName: "AccomodationId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AccomodationAccId",
                table: "Users",
                newName: "IX_Users_AccomodationId");

            migrationBuilder.RenameColumn(
                name: "AccId",
                table: "Accomodations",
                newName: "RecentlyRenovated");

            migrationBuilder.RenameColumn(
                name: "AccomodationReservationId",
                table: "AccomodationReservations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AccomodationAccId",
                table: "AccomodationImages",
                newName: "AccomodationRatingAccomodationId");

            migrationBuilder.RenameIndex(
                name: "IX_AccomodationImages_AccomodationAccId",
                table: "AccomodationImages",
                newName: "IX_AccomodationImages_AccomodationRatingAccomodationId");

            migrationBuilder.AddColumn<int>(
                name: "AccomodationRatingAccomodationId",
                table: "GuestRatings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "GuestRatings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdOwner",
                table: "GuestRatings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "RecentlyRenovated",
                table: "Accomodations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Accomodations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Accomodations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastRenovation",
                table: "Accomodations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AccomodationReservations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AccomodationReservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "AccomodationId",
                table: "AccomodationReservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Cancelled",
                table: "AccomodationReservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AccomodationId",
                table: "AccomodationImages",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accomodations",
                table: "Accomodations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccomodationReservations",
                table: "AccomodationReservations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AccommodationReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccId = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cancelled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccommodationReservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccomodationRating",
                columns: table => new
                {
                    AccomodationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cleanliness = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerFriendliness = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccomodationRating", x => x.AccomodationId);
                });

            migrationBuilder.CreateTable(
                name: "AccomodationReviews",
                columns: table => new
                {
                    AccomodationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Recommendations = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccomodationReviews", x => x.AccomodationId);
                });

            migrationBuilder.CreateTable(
                name: "OwnerReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cleanliness = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerFairness = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    AccomodationReservationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Images = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerReviews_AccomodationReservations_AccomodationReservationId",
                        column: x => x.AccomodationReservationId,
                        principalTable: "AccomodationReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "RenovationSuggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RenovationRating = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    AccomodationReservationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RenovationSuggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RenovationSuggestions_AccomodationReservations_AccomodationReservationId",
                        column: x => x.AccomodationReservationId,
                        principalTable: "AccomodationReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationReschedulingRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    ReservationId = table.Column<int>(type: "INTEGER", nullable: false),
                    NewStartingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NewEndingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Achievable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationReschedulingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationReschedulingRequests_AccomodationReservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "AccomodationReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestRatings_AccomodationRatingAccomodationId",
                table: "GuestRatings",
                column: "AccomodationRatingAccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccomodationReservations_AccomodationId",
                table: "AccomodationReservations",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccomodationReservations_UserId",
                table: "AccomodationReservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccomodationImages_AccomodationId",
                table: "AccomodationImages",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationReservations_UserId",
                table: "AccommodationReservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerReviews_AccomodationReservationId",
                table: "OwnerReviews",
                column: "AccomodationReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Renovations_AccomodationId",
                table: "Renovations",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_RenovationSuggestions_AccomodationReservationId",
                table: "RenovationSuggestions",
                column: "AccomodationReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationReschedulingRequests_ReservationId",
                table: "ReservationReschedulingRequests",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationImages_AccomodationRating_AccomodationRatingAccomodationId",
                table: "AccomodationImages",
                column: "AccomodationRatingAccomodationId",
                principalTable: "AccomodationRating",
                principalColumn: "AccomodationId",
                onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationReservations_Users_GuestId",
                table: "AccomodationReservations",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationReservations_Users_UserId",
                table: "AccomodationReservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_AccomodationReservations_AccomodationReservationId",
                table: "Accomodations",
                column: "AccomodationReservationId",
                principalTable: "AccomodationReservations",
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
                name: "FK_GuestRatings_AccomodationRating_AccomodationRatingAccomodationId",
                table: "GuestRatings",
                column: "AccomodationRatingAccomodationId",
                principalTable: "AccomodationRating",
                principalColumn: "AccomodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestRatings_AccomodationReservations_AccomodationReservationId",
                table: "GuestRatings",
                column: "AccomodationReservationId",
                principalTable: "AccomodationReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accomodations_AccomodationId",
                table: "Users",
                column: "AccomodationId",
                principalTable: "Accomodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationImages_AccomodationRating_AccomodationRatingAccomodationId",
                table: "AccomodationImages");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationImages_Accomodations_AccomodationId",
                table: "AccomodationImages");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservations_Accomodations_AccomodationId",
                table: "AccomodationReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservations_Users_GuestId",
                table: "AccomodationReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationReservations_Users_UserId",
                table: "AccomodationReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_AccomodationReservations_AccomodationReservationId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_GuestId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestRatings_AccomodationRating_AccomodationRatingAccomodationId",
                table: "GuestRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestRatings_AccomodationReservations_AccomodationReservationId",
                table: "GuestRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accomodations_AccomodationId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AccommodationReservations");

            migrationBuilder.DropTable(
                name: "AccomodationRating");

            migrationBuilder.DropTable(
                name: "AccomodationReviews");

            migrationBuilder.DropTable(
                name: "OwnerReviews");

            migrationBuilder.DropTable(
                name: "Renovations");

            migrationBuilder.DropTable(
                name: "RenovationSuggestions");

            migrationBuilder.DropTable(
                name: "ReservationReschedulingRequests");

            migrationBuilder.DropIndex(
                name: "IX_GuestRatings_AccomodationRatingAccomodationId",
                table: "GuestRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accomodations",
                table: "Accomodations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccomodationReservations",
                table: "AccomodationReservations");

            migrationBuilder.DropIndex(
                name: "IX_AccomodationReservations_AccomodationId",
                table: "AccomodationReservations");

            migrationBuilder.DropIndex(
                name: "IX_AccomodationReservations_UserId",
                table: "AccomodationReservations");

            migrationBuilder.DropIndex(
                name: "IX_AccomodationImages_AccomodationId",
                table: "AccomodationImages");

            migrationBuilder.DropColumn(
                name: "AccomodationRatingAccomodationId",
                table: "GuestRatings");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "GuestRatings");

            migrationBuilder.DropColumn(
                name: "IdOwner",
                table: "GuestRatings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Accomodations");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "Accomodations");

            migrationBuilder.DropColumn(
                name: "LastRenovation",
                table: "Accomodations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AccomodationReservations");

            migrationBuilder.DropColumn(
                name: "AccomodationId",
                table: "AccomodationReservations");

            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "AccomodationReservations");

            migrationBuilder.DropColumn(
                name: "AccomodationId",
                table: "AccomodationImages");

            migrationBuilder.RenameColumn(
                name: "SuperOwner",
                table: "Users",
                newName: "AccomodationReservationId");

            migrationBuilder.RenameColumn(
                name: "AccomodationId",
                table: "Users",
                newName: "AccomodationAccId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AccomodationId",
                table: "Users",
                newName: "IX_Users_AccomodationAccId");

            migrationBuilder.RenameColumn(
                name: "RecentlyRenovated",
                table: "Accomodations",
                newName: "AccId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AccomodationReservations",
                newName: "AccomodationReservationId");

            migrationBuilder.RenameColumn(
                name: "AccomodationRatingAccomodationId",
                table: "AccomodationImages",
                newName: "AccomodationAccId");

            migrationBuilder.RenameIndex(
                name: "IX_AccomodationImages_AccomodationRatingAccomodationId",
                table: "AccomodationImages",
                newName: "IX_AccomodationImages_AccomodationAccId");

            migrationBuilder.AlterColumn<int>(
                name: "AccId",
                table: "Accomodations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "AccomodationReservationId",
                table: "AccomodationReservations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "AccomodationAccId",
                table: "AccomodationReservations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accomodations",
                table: "Accomodations",
                column: "AccId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccomodationReservations",
                table: "AccomodationReservations",
                column: "AccomodationReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccomodationReservationId",
                table: "Users",
                column: "AccomodationReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccomodationReservations_AccomodationAccId",
                table: "AccomodationReservations",
                column: "AccomodationAccId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationImages_Accomodations_AccomodationAccId",
                table: "AccomodationImages",
                column: "AccomodationAccId",
                principalTable: "Accomodations",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationReservations_Accomodations_AccomodationAccId",
                table: "AccomodationReservations",
                column: "AccomodationAccId",
                principalTable: "Accomodations",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationReservations_Users_GuestId",
                table: "AccomodationReservations",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_AccomodationReservations_AccomodationReservationId",
                table: "Accomodations",
                column: "AccomodationReservationId",
                principalTable: "AccomodationReservations",
                principalColumn: "AccomodationReservationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_GuestId",
                table: "Comments",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestRatings_AccomodationReservations_AccomodationReservationId",
                table: "GuestRatings",
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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accomodations_AccomodationAccId",
                table: "Users",
                column: "AccomodationAccId",
                principalTable: "Accomodations",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
