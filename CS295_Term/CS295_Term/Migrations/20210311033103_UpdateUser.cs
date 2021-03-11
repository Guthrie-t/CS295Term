using Microsoft.EntityFrameworkCore.Migrations;

namespace CS295_Term.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Recipe",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_UpdatedById",
                table: "Recipe",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_AspNetUsers_UpdatedById",
                table: "Recipe",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_AspNetUsers_UpdatedById",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_UpdatedById",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Recipe");
        }
    }
}
