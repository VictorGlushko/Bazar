using Microsoft.EntityFrameworkCore.Migrations;

namespace Bazar.Data.Migrations
{
    public partial class AddModesAnPlatforms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameMode_Mode_ModesId",
                table: "GameMode");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlatform_Platform_PlatformsId",
                table: "GamePlatform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Platform",
                table: "Platform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mode",
                table: "Mode");

            migrationBuilder.RenameTable(
                name: "Platform",
                newName: "Platforms");

            migrationBuilder.RenameTable(
                name: "Mode",
                newName: "Modes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Platforms",
                table: "Platforms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modes",
                table: "Modes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameMode_Modes_ModesId",
                table: "GameMode",
                column: "ModesId",
                principalTable: "Modes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlatform_Platforms_PlatformsId",
                table: "GamePlatform",
                column: "PlatformsId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameMode_Modes_ModesId",
                table: "GameMode");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlatform_Platforms_PlatformsId",
                table: "GamePlatform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Platforms",
                table: "Platforms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modes",
                table: "Modes");

            migrationBuilder.RenameTable(
                name: "Platforms",
                newName: "Platform");

            migrationBuilder.RenameTable(
                name: "Modes",
                newName: "Mode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Platform",
                table: "Platform",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mode",
                table: "Mode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameMode_Mode_ModesId",
                table: "GameMode",
                column: "ModesId",
                principalTable: "Mode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlatform_Platform_PlatformsId",
                table: "GamePlatform",
                column: "PlatformsId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
