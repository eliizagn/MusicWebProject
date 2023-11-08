using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicWebProject.Migrations
{
    /// <inheritdoc />
    public partial class AddSongYearinSongsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SongYear",
                table: "Albums");

            migrationBuilder.AddColumn<DateOnly>(
                name: "SongYear",
                table: "Albums",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SongYear",
                table: "Albums");

            migrationBuilder.AddColumn<int>(
                name: "SongYear",
                table: "Albums",
                type: "integer",
                nullable: true);
        }
    }
}
