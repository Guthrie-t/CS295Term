using Microsoft.EntityFrameworkCore.Migrations;

namespace CS295_Term.Migrations
{
    public partial class RecipeFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_IngredientList_IngredientListId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "IngredientList");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_IngredientListId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IngredientListId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "PrivacyToggle",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UserRating",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "FoodGroup",
                table: "Ingredients");

            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeID",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeID",
                table: "Ingredients",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipeID",
                table: "Ingredients",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipeID",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeID",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "Ingredients");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientListId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrivacyToggle",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRating",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FoodGroup",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IngredientList",
                columns: table => new
                {
                    IngredientListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IngredientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientList", x => x.IngredientListId);
                    table.ForeignKey(
                        name: "FK_IngredientList_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_IngredientListId",
                table: "Recipes",
                column: "IngredientListId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientList_IngredientId",
                table: "IngredientList",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_IngredientList_IngredientListId",
                table: "Recipes",
                column: "IngredientListId",
                principalTable: "IngredientList",
                principalColumn: "IngredientListId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
