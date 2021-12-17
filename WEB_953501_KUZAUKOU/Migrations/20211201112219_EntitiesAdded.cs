using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_953501_KUZAUKOU.Migrations
{
    public partial class EntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuitarGroup",
                columns: table => new
                {
                    GuitarGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarGroup", x => x.GuitarGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Guitar",
                columns: table => new
                {
                    GuitarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuitarName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Strings = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    GuitarGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guitar", x => x.GuitarId);
                    table.ForeignKey(
                        name: "FK_Guitar_GuitarGroup_GuitarGroupId",
                        column: x => x.GuitarGroupId,
                        principalTable: "GuitarGroup",
                        principalColumn: "GuitarGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guitar_GuitarGroupId",
                table: "Guitar",
                column: "GuitarGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guitar");

            migrationBuilder.DropTable(
                name: "GuitarGroup");
        }
    }
}
