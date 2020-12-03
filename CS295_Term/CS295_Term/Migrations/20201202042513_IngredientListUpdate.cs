using Microsoft.EntityFrameworkCore.Migrations;

namespace CS295_Term.Migrations
{
    public partial class IngredientListUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasure",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "IngredientListId",
                table: "Recipes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IngredientList",
                columns: table => new
                {
                    IngredientListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(nullable: true),
                    Amount = table.Column<string>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IngredientListId",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitOfMeasure",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
