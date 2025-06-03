using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dvdrental.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Films",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReleaseYear",
                table: "Films",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "FullText",
                table: "Films",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Films",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Films",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Films",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RentalRate",
                table: "Films",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReplacementCost",
                table: "Films",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SpecialFeatures",
                table: "Films",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullText",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "RentalRate",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "ReplacementCost",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "SpecialFeatures",
                table: "Films");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Films",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "ReleaseYear",
                table: "Films",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
