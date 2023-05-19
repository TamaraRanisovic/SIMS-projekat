using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class novaAccPolja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_Locations_LocationId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Locations_LocationId",
                table: "Tours");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastRenovation",
                table: "Accomodations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "RecentlyRenovated",
                table: "Accomodations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_Locations_LocationId",
                table: "Accomodations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Locations_LocationId",
                table: "Tours",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_Locations_LocationId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Locations_LocationId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "LastRenovation",
                table: "Accomodations");

            migrationBuilder.DropColumn(
                name: "RecentlyRenovated",
                table: "Accomodations");

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_Locations_LocationId",
                table: "Accomodations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Locations_LocationId",
                table: "Tours",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
