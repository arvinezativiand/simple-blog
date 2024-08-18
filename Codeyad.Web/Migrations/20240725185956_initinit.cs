using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codeyad.Web.Migrations
{
    /// <inheritdoc />
    public partial class initinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryID",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Posts",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CategoryID",
                table: "Posts",
                newName: "IX_Posts_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SubCategoryId",
                table: "Posts",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_SubCategoryId",
                table: "Posts",
                column: "SubCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_SubCategoryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_SubCategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Posts",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                newName: "IX_Posts_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryID",
                table: "Posts",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
