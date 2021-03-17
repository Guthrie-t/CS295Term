using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS295_Term.Migrations
{
    public partial class AttributesRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Attribute_AttributeID",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Attribute_AttributesAttributeID",
                table: "Recipe");

            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_AttributesAttributeID",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Category_AttributeID",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "AttributesAttributeID",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "AttributeID",
                table: "Category");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSubmitted",
                table: "Recipe",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Recipe",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OverallRating",
                table: "Recipe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserRating",
                table: "Recipe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Category",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Recipe_RecipeId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_RecipeId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "DateSubmitted",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "OverallRating",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "UserRating",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Category");

            migrationBuilder.AddColumn<int>(
                name: "AttributesAttributeID",
                table: "Recipe",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttributeID",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    AttributeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OverallRating = table.Column<int>(type: "int", nullable: false),
                    UserRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.AttributeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_AttributesAttributeID",
                table: "Recipe",
                column: "AttributesAttributeID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_AttributeID",
                table: "Category",
                column: "AttributeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Attribute_AttributeID",
                table: "Category",
                column: "AttributeID",
                principalTable: "Attribute",
                principalColumn: "AttributeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Attribute_AttributesAttributeID",
                table: "Recipe",
                column: "AttributesAttributeID",
                principalTable: "Attribute",
                principalColumn: "AttributeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
