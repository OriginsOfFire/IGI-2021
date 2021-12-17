using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_953501_KUZAUKOU.Migrations
{
    public partial class EntitiesFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guitar_GuitarGroup_GuitarGroupId",
                table: "Guitar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuitarGroup",
                table: "GuitarGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guitar",
                table: "Guitar");

            migrationBuilder.RenameTable(
                name: "GuitarGroup",
                newName: "GuitarGroups");

            migrationBuilder.RenameTable(
                name: "Guitar",
                newName: "Guitars");

            migrationBuilder.RenameIndex(
                name: "IX_Guitar_GuitarGroupId",
                table: "Guitars",
                newName: "IX_Guitars_GuitarGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuitarGroups",
                table: "GuitarGroups",
                column: "GuitarGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guitars",
                table: "Guitars",
                column: "GuitarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_GuitarGroups_GuitarGroupId",
                table: "Guitars",
                column: "GuitarGroupId",
                principalTable: "GuitarGroups",
                principalColumn: "GuitarGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_GuitarGroups_GuitarGroupId",
                table: "Guitars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guitars",
                table: "Guitars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuitarGroups",
                table: "GuitarGroups");

            migrationBuilder.RenameTable(
                name: "Guitars",
                newName: "Guitar");

            migrationBuilder.RenameTable(
                name: "GuitarGroups",
                newName: "GuitarGroup");

            migrationBuilder.RenameIndex(
                name: "IX_Guitars_GuitarGroupId",
                table: "Guitar",
                newName: "IX_Guitar_GuitarGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guitar",
                table: "Guitar",
                column: "GuitarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuitarGroup",
                table: "GuitarGroup",
                column: "GuitarGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guitar_GuitarGroup_GuitarGroupId",
                table: "Guitar",
                column: "GuitarGroupId",
                principalTable: "GuitarGroup",
                principalColumn: "GuitarGroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
