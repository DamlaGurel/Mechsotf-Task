using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingOrganizer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Meetings",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Meetings",
                newName: "MeetingDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Meetings",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Meetings");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Meetings",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "MeetingDate",
                table: "Meetings",
                newName: "EndDate");
        }
    }
}
