using Microsoft.EntityFrameworkCore.Migrations;

namespace Bazar.Data.Migrations
{
    public partial class AddGameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Game_GameId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Game_GamesId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameMode_Game_GamesId",
                table: "GameMode");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlatform_Game_GamesId",
                table: "GamePlatform");

            migrationBuilder.DropForeignKey(
                name: "FK_GameTag_Game_GamesId",
                table: "GameTag");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaResources_Game_MediaResourcesId",
                table: "MediaResources");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemRequirements_Game_SystemRequirementsId",
                table: "SystemRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "PreviewImagePath",
                table: "MediaResources");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Games_GameId",
                table: "Comment",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Games_GamesId",
                table: "GameGenre",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameMode_Games_GamesId",
                table: "GameMode",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlatform_Games_GamesId",
                table: "GamePlatform",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameTag_Games_GamesId",
                table: "GameTag",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaResources_Games_MediaResourcesId",
                table: "MediaResources",
                column: "MediaResourcesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemRequirements_Games_SystemRequirementsId",
                table: "SystemRequirements",
                column: "SystemRequirementsId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Games_GameId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Games_GamesId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameMode_Games_GamesId",
                table: "GameMode");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlatform_Games_GamesId",
                table: "GamePlatform");

            migrationBuilder.DropForeignKey(
                name: "FK_GameTag_Games_GamesId",
                table: "GameTag");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaResources_Games_MediaResourcesId",
                table: "MediaResources");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemRequirements_Games_SystemRequirementsId",
                table: "SystemRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.AddColumn<string>(
                name: "PreviewImagePath",
                table: "MediaResources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Game_GameId",
                table: "Comment",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Game_GamesId",
                table: "GameGenre",
                column: "GamesId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameMode_Game_GamesId",
                table: "GameMode",
                column: "GamesId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlatform_Game_GamesId",
                table: "GamePlatform",
                column: "GamesId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameTag_Game_GamesId",
                table: "GameTag",
                column: "GamesId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaResources_Game_MediaResourcesId",
                table: "MediaResources",
                column: "MediaResourcesId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemRequirements_Game_SystemRequirementsId",
                table: "SystemRequirements",
                column: "SystemRequirementsId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
