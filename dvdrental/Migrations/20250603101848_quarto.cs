using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dvdrental.Migrations
{
    /// <inheritdoc />
    public partial class quarto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languages");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Films",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_LanguageId",
                table: "Films",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Languages_LanguageId",
                table: "Films",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Languages_LanguageId",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_LanguageId",
                table: "Films");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Films");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "LanguageId");
        }
    }
}
