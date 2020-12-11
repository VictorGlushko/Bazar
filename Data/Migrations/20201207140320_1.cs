using Microsoft.EntityFrameworkCore.Migrations;

namespace Bazar.Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaResources");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaResources",
                columns: table => new
                {
                    MediaResourcesId = table.Column<int>(type: "int", nullable: false),
                    GalleryPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaResources", x => x.MediaResourcesId);
                    table.ForeignKey(
                        name: "FK_MediaResources_Games_MediaResourcesId",
                        column: x => x.MediaResourcesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
