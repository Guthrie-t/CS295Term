using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS295_Term.Migrations
{
    public partial class Attributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "DateSubmitted",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Recipe");

            migrationBuilder.AddColumn<int>(
                name: "AttributesAttributeID",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Recipe",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    AttributeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OverallRating = table.Column<int>(nullable: false),
                    UserRating = table.Column<int>(nullable: false),
                    DateSubmitted = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.AttributeID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AttributeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Category_Attribute_AttributeID",
                        column: x => x.AttributeID,
                        principalTable: "Attribute",
                        principalColumn: "AttributeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_AttributesAttributeID",
                table: "Recipe",
                column: "AttributesAttributeID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_AttributeID",
                table: "Category",
                column: "AttributeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Attribute_AttributesAttributeID",
                table: "Recipe",
                column: "AttributesAttributeID",
                principalTable: "Attribute",
                principalColumn: "AttributeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_AspNetUsers_UserId",
                table: "Recipe",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Attribute_AttributesAttributeID",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_AspNetUsers_UserId",
                table: "Recipe");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_AttributesAttributeID",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "AttributesAttributeID",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recipe");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSubmitted",
                table: "Recipe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "RecipeId", "Category", "DateSubmitted", "Image", "Ingredients", "Instructions", "Rating", "RecipeName" },
                values: new object[,]
                {
                    { 1, "Comfort Food", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/css/images/macncheese.jpg", "5 cups milk, 1 lb elbow macaroni dry, 2 cups shredded cheddar cheese", "In a large pot, bring the milk to a boil. Add the pasta and stir constantly until the pasta is cooked, about 10 minutes. Turn off the heat, then add the cheddar. Stir until the cheese is melted and the pasta is evenly coated. Enjoy!", 5, "Macaroni and Cheese" },
                    { 2, "Dessert", new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "/css/images/pbcookies.jpg", "200g peanut butter (crunchy or smooth is fine), 175g golden caster sugar, ¼ tsp fine table salt, 1 large egg", "Heat oven to 180C/160C and line 2 large baking trays with baking parchment. Measure the peanut butter and sugar into a bowl. Add ¼ tsp fine table salt and mix well with a wooden spoon. Add the egg and mix again until the mixture forms a dough. Break off cherry tomato sized chunks of dough and place, well spaced apart, on the trays. Press the cookies down with the back of a fork to squash them a little. The cookies can now be frozen for 2 months, cook from frozen adding an extra min or 2 to the cooking time. Bake for 12 mins, until golden around the edges and paler in the centre. Cool on the trays for 10 mins, then transfer to a wire rack and cool completely. Store in a cookie jar for up to 3 days. ", 4, "Peanut Butter Cookies" },
                    { 3, "Classics From Scratch", new DateTime(2016, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "/css/images/pasta.jpg", "300g ‘00’ pasta flour (plus extra for dusting), 2 eggs and 4 yolks (lightly beaten), semolina flour (for dusting)", "Put the flour in a food processor with ¾ of your egg mixture and a pinch of salt. Blitz to large crumbs – they should come together to form a dough when squeezed (if it feels a little dry gradually add a bit more egg). Tip the dough onto a lightly floured surface, knead for 1 min or until nice and smooth – don’t worry if it’s quite firm as it will soften when it rests. Cover with cling film and leave to rest for 30 mins. Cut away ¼ of the dough (keep the rest covered with cling film) and feed it through the widest setting on your pasta machine. (If you don’t have a machine, use a heavy rolling pin to roll the dough as thinly as possible.) Then fold into three, give the dough a quarter turn and feed through the pasta machine again. Repeat this process once more then continue to pass the dough through the machine, progressively narrowing the rollers, one notch at a time, until you have a smooth sheet of pasta. On the narrowest setting, feed the sheet through twice. Cut as required to use for filled pastas like tortellini, or cut into lengths to make spaghetti, linguine, tagliatelle, or pappardelle. Then, dust in semolina flour and set aside, or hang until dry (an hour will be enough time.) Store in a sealed container in the fridge and use within a couple of days, or freeze for 1 month.", 3, "Fresh Pasta" },
                    { 4, "Drinks", new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/css/images/earlgreymartini.jpg", "1 tbsp good loose-leaf Earl Grey tea, 700ml bottle of decent gin, ice", "Put the Earl Grey tea in a large jug. Pour the gin over and stir with a long-handled spoon for about 45 secs. Strain the gin through a tea strainer over a funnel back into the bottle. You’ll see small particles of leaf still suspended in the gin. Rinse out the jug and, using a coffee filter or some muslin inside the funnel, strain the gin a second time to remove all the particles. In this way, the gin will be stable and the flavour won’t change – it’ll be good for months and months until the final sip. To serve, shake or stir over ice – I like how the flavours change as the drink dilutes.", 5, "Earl Grey Martini" }
                });
        }
    }
}
