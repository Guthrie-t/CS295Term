using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS295_Term.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CS295_Term.Models
{
    public class SeedData
    {
        public static void Seed(IRecipeRepository repo, UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            List<Recipe> recipes = repo.Recipes.ToList();

            //Begin Categories for reuse
            Category comfortFood = new Category
            {
                Name = "Comfort Food"
            };
            repo.AddCategory(comfortFood);

            Category dessert = new Category
            {
                Name = "Dessert"
            };
            repo.AddCategory(dessert);

            Category fromScratch = new Category
            {
                Name = "From Scratch"
            };
            repo.AddCategory(fromScratch);

            Category drinks = new Category
            {
                Name = "Drinks"
            };
            repo.AddCategory(drinks);

            var result = roleManager.CreateAsync(new IdentityRole("Member")).Result;
            result = roleManager.CreateAsync(new IdentityRole("Admin")).Result;

            // Seeding a default administrator. They will need to change their password after logging in.
            SiteUser siteadmin = new SiteUser
            {
                UserName = "SiteAdmin",
            };
            userManager.CreateAsync(siteadmin, "Secret-123").Wait();
            IdentityRole adminRole = roleManager.FindByNameAsync("Admin").Result;
            userManager.AddToRoleAsync(siteadmin, adminRole.Name);





            //begin actual recipes
            if (recipes.Count == 0)
            {

                Recipe recipe = new Recipe
                {
                    RecipeName = "Macaroni and Cheese",
                    Ingredients = "5 cups milk, 1 lb elbow macaroni dry, 2 cups shredded cheddar cheese",
                    Instructions = "In a large pot, bring the milk to a boil. Add the pasta and stir constantly until " +
                    "the pasta is cooked, about 10 minutes. Turn off the heat, then add the cheddar. " +
                    "Stir until the cheese is melted and the pasta is evenly coated. Enjoy!",
                     OverallRating = 4,
                     UserRating = 3,
                     DateSubmitted = DateTime.Parse("1/1/2019"),
                     LastUpdated = DateTime.Parse("2/14/2020"),
                     Category = comfortFood,
                    Image = "/css/images/macncheese.jpg",
                    User = new SiteUser() { UserName = "BigBertha12", Nickname = "Bertha"}
                   
                };

                repo.AddRecipe(recipe);

                recipe = new Recipe
                {
                    RecipeName = "Peanut Butter Cookies",
                    Ingredients = "200g peanut butter (crunchy or smooth is fine), 175g golden caster sugar, ¼ tsp fine table salt, 1 large egg",
                    Instructions = "Heat oven to 180C/160C and line 2 large baking trays with baking parchment. " +
                        "Measure the peanut butter and sugar into a bowl. Add ¼ tsp fine table salt and mix well with a wooden spoon. " +
                        "Add the egg and mix again until the mixture forms a dough. Break off cherry tomato sized chunks of dough and place, " +
                        "well spaced apart, on the trays. Press the cookies down with the back of a fork to squash them a little. The cookies " +
                        "can now be frozen for 2 months, cook from frozen adding an extra min or 2 to the cooking time. Bake for 12 mins, until " +
                        "golden around the edges and paler in the centre. Cool on the trays for 10 mins, then transfer to a wire rack and cool completely. " +
                        "Store in a cookie jar for up to 3 days. ",

                    OverallRating = 5,
                    UserRating = 5,
                    DateSubmitted = DateTime.Parse("7/18/2019"),
                    LastUpdated = DateTime.Parse("5/13/2020"),
                    Category = dessert,
                    Image = "/css/images/pbcookies.jpg",
                    User = new SiteUser() { UserName = "Riliye", Nickname = "Tiff" }
                };
                repo.AddRecipe(recipe);

                recipe = new Recipe
                {
                    RecipeName = "Fresh Pasta",
                    Ingredients = "300g ‘00’ pasta flour (plus extra for dusting), 2 eggs and 4 yolks (lightly beaten), semolina flour (for dusting)",
                    Instructions = "Put the flour in a food processor with ¾ of your egg mixture and a pinch of salt. Blitz to large crumbs – " +
                    "they should come together to form a dough when squeezed (if it feels a little dry gradually add a bit more egg). Tip the " +
                    "dough onto a lightly floured surface, knead for 1 min or until nice and smooth – don’t worry if it’s quite firm as it will soften " +
                    "when it rests. Cover with cling film and leave to rest for 30 mins. Cut away ¼ of the dough (keep the rest covered with cling film) " +
                    "and feed it through the widest setting on your pasta machine. (If you don’t have a machine, use a heavy rolling pin to roll the " +
                    "dough as thinly as possible.) Then fold into three, give the dough a quarter turn and feed through the pasta machine again. Repeat " +
                    "this process once more then continue to pass the dough through the machine, progressively narrowing the rollers, one notch at a time, " +
                    "until you have a smooth sheet of pasta. On the narrowest setting, feed the sheet through twice. Cut as required to use for filled pastas " +
                    "like tortellini, or cut into lengths to make spaghetti, linguine, tagliatelle, or pappardelle. Then, dust in semolina flour and set aside, " +
                    "or hang until dry (an hour will be enough time.) Store in a sealed container in the fridge and use within a couple of days, or freeze for 1 month.",
                     OverallRating = 3,
                     UserRating = 4,
                     DateSubmitted = DateTime.Parse("3/25/2016"),
                     LastUpdated = DateTime.Parse("12/13/2020"),
                     Category = fromScratch,
                    Image = "/css/images/pasta.jpg",
                    User = new SiteUser() { UserName = "Richard12", Nickname = "DudeBro" }
                };
                repo.AddRecipe(recipe);

                recipe = new Recipe
                {
                    RecipeName = "Earl Grey Martini",
                    Ingredients = "1 tbsp good loose-leaf Earl Grey tea, 700ml bottle of decent gin, ice",
                    Instructions = "Put the Earl Grey tea in a large jug. Pour the gin over and stir with a long-handled spoon for about 45 secs. " +
                    "Strain the gin through a tea strainer over a funnel back into the bottle. You’ll see small particles of leaf still suspended in the gin. " +
                    "Rinse out the jug and, using a coffee filter or some muslin inside the funnel, strain the gin a second time to remove all the particles. " +
                    "In this way, the gin will be stable and the flavour won’t change – it’ll be good for months and months until the final sip. To serve, " +
                    "shake or stir over ice – I like how the flavours change as the drink dilutes.",

                    OverallRating = 3,
                    UserRating = 5,
                    DateSubmitted = DateTime.Parse("12/1/2020"),
                    LastUpdated = DateTime.Parse("12/1/2020"),
                    Category = drinks,
                    Image = "/css/images/earlgreymartini.jpg",
                    User = new SiteUser() { UserName = "Charleston", Nickname = "Charlie" }
                };
                repo.AddRecipe(recipe);

                recipe = new Recipe
                {
                    RecipeName = "Homemade Chili",
                    Ingredients = "1.5lbs lean ground beef, 1 onion(chopped), 1 small green bell pepper(chopped), 2 garlic cloves (minced), 2 (16oz) cans red kidney beans" +
                    "(rinsed and drained), 2(14.5oz) cans diced tomatoes, 2-3 tbsp chili powder, 1 tsp salt, 1 tsp pepper, 1 tsp ground cumin",
                    Instructions = "Cook first 4 ingredients in a large skillet over medium-high heat, stirring until beef crumbles and is no longer pink; drain. " +
                    "Place mixture in 5-quart slow cooker; stir in beans and remaining ingredients. Cook at HIGH 3 to 4 hours or at LOW 5 to 6 hours. Note: If you " +
                    "want to thicken this saucy chili, stir in finely crushed saltine crackers until the desired thickness is achieved.",

                    OverallRating = 5,
                    UserRating = 5,
                    DateSubmitted = DateTime.Parse("3/9/2020"),
                    LastUpdated = DateTime.Parse("3/9/2020"),
                    Category = comfortFood,
                    Image = "/css/images/chili.jpg",
                    User = new SiteUser() { UserName = "HiddlestoneHobbit", Nickname = "Bilbo" }
                };
                repo.AddRecipe(recipe);

                recipe = new Recipe
                {
                    RecipeName = "Lemon Blueberry Layered Dessert",
                    Ingredients = "15 lemon cookies (coarsely crushed), 1(21oz) can blueberry pie filling, 1(8oz, thawed) container frozen whippped topping, 1 (14oz) can sweetened" +
                    "condensed milk, 1 (6oz, thawed) can frozen lemonade concentrate",
                    Instructions = "Sprinkle 1 tablespoon crushed cookies into each of 8 (8-ounce) parfait glasses. Spoon 1 1/2 tablespoons pie filling over cookies in each glass." +
                    "Spoon whipped topping into a bowl; fold in condensed milk and lemonade concentrate. Spoon 2 tablespoons whipped topping mixture over pie filling in each glass. " +
                    "Repeat layers once. Top evenly with remaining crushed cookies. Cover and chill 4 hours.",

                    OverallRating = 4,
                    UserRating = 2,
                    DateSubmitted = DateTime.Parse("3/9/2020"),
                    LastUpdated = DateTime.Parse("3/9/2020"),
                    Category = dessert,
                    Image = "/css/images/lemonblueberry.jpg",
                    User = new SiteUser() { UserName = "MasterChief", Nickname = "MC" }
                };
                repo.AddRecipe(recipe);

                recipe = new Recipe
                {
                    RecipeName = "From Scratch Oven Fries",
                    Ingredients = "1.5lbs medium sized baking potatoes (peeled and cut into 0.5in thick strips), 1tbsp vegetable oil, 1/2 tsp kosher salt",
                    Instructions = "Preheat oven to 450°. Rinse potatoes in cold water. Drain and pat dry. Toss together potatoes, oil, and salt in a large bowl." +
                    "Place a lightly greased wire rack in a jelly-roll pan. Arrange potatoes in a single layer on wire rack." +
                    "Bake at 450° for 40 to 45 minutes or until browned. Serve immediately with ketchup, if desired.",

                    OverallRating = 3,
                    UserRating = 5,
                    DateSubmitted = DateTime.Parse("3/9/2020"),
                    LastUpdated = DateTime.Parse("3/9/2020"),
                    Category = fromScratch,
                    Image = "/css/images/fries.jpg",
                    User = new SiteUser() { UserName = "Huckleberry", Nickname = "Huckleberry" }
                };
                repo.AddRecipe(recipe);

                recipe = new Recipe
                {
                    RecipeName = "Whiskey Sour",
                    Ingredients = "2 ounces bourbon whiskey, 1 ounce lemon juice, 1 1/2 tbsps maple syrup (or simple syrup), garnish of orange peel and cocktail cherry, ice for serving",
                    Instructions = "Add the bourbon whiskey, lemon juice, and syrup to a cocktail shaker. Fill with a handful of ice and shake until very cold." +
                    "Strain the drink into a lowball or Old Fashioned glass. Serve with ice, an orange peel and a cocktail cherry. ",

                    OverallRating = 5,
                    UserRating = 5,
                    DateSubmitted = DateTime.Parse("3/9/2020"),
                    LastUpdated = DateTime.Parse("3/9/2020"),
                    Category = drinks,
                    Image = "/css/images/whiskeysour.jpg",
                    User = new SiteUser() { UserName = "CheepCheep", Nickname = "Chicken" }
                };
                repo.AddRecipe(recipe);


            };
            
        }
    }

}
