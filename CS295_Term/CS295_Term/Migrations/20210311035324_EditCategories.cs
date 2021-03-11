using Microsoft.EntityFrameworkCore.Migrations;

namespace CS295_Term.Migrations
{
    public partial class EditCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Recipe_RecipeId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_RecipeId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Category");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Recipe",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_CategoryID",
                table: "Recipe",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Category_CategoryID",
                table: "Recipe",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Category_CategoryID",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_CategoryID",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Recipe");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_RecipeId",
                table: "Category",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Recipe_RecipeId",
                table: "Category",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
