using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManager.Data.Migrations
{
    public partial class ChangeEventModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EventAddresses_EventId",
                table: "EventAddresses");

            migrationBuilder.DropColumn(
                name: "IsLimitReached",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PeopleLimit",
                table: "Events");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationTime",
                table: "Events",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificationUser",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventAddresses_EventId",
                table: "EventAddresses",
                column: "EventId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EventAddresses_EventId",
                table: "EventAddresses");

            migrationBuilder.DropColumn(
                name: "ModificationTime",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ModificationUser",
                table: "Events");

            migrationBuilder.AddColumn<bool>(
                name: "IsLimitReached",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PeopleLimit",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventAddresses_EventId",
                table: "EventAddresses",
                column: "EventId");
        }
    }
}
