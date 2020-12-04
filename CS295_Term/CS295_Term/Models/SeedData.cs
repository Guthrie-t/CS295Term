using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CS295_Term.Models
{
    public class SeedData
    {
        public static void Seed(RecipeContext context)
        {

            var recipes = new List<Recipe>
            {
                new Recipe
                {
                    RecipeId = 1,
                    RecipeName = "Macaroni and Cheese",
                    Ingredients = "5 cups milk, 1 lb elbow macaroni dry, 2 cups shredded cheddar cheese",
                    Instructions = "In a large pot, bring the milk to a boil. Add the pasta and stir constantly until the pasta is cooked, about 10 minutes. Turn off the heat, then add the cheddar. Stir until the cheese is melted and the pasta is evenly coated. Enjoy!",
                    Rating = 5,
                    Category = "Comfort Food",
                    DateSubmitted = DateTime.Parse("1/1/2019"),
                    Image = "/css/images/macncheese.jpg"
                },
                new Recipe
                {
                    RecipeId = 2,
                    RecipeName = "Peanut Butter Cookies",
                    Ingredients = "200g peanut butter (crunchy or smooth is fine), 175g golden caster sugar, ¼ tsp fine table salt, 1 large egg",
                    Instructions = "Heat oven to 180C/160C and line 2 large baking trays with baking parchment. Measure the peanut butter and sugar into a bowl. Add ¼ tsp fine table salt and mix well with a wooden spoon. Add the egg and mix again until the mixture forms a dough. Break off cherry tomato sized chunks of dough and place, well spaced apart, on the trays. Press the cookies down with the back of a fork to squash them a little. The cookies can now be frozen for 2 months, cook from frozen adding an extra min or 2 to the cooking time. Bake for 12 mins, until golden around the edges and paler in the centre. Cool on the trays for 10 mins, then transfer to a wire rack and cool completely. Store in a cookie jar for up to 3 days. ",
                    Rating = 4,
                    Category = "Dessert",
                    DateSubmitted = DateTime.Parse("5/13/2020"),
                    Image = "/css/images/pbcookies.jpg"
                },
                new Recipe
                {
                    RecipeId = 3,
                    RecipeName = "Fresh Pasta",
                    Ingredients = "300g ‘00’ pasta flour (plus extra for dusting), 2 eggs and 4 yolks (lightly beaten), semolina flour (for dusting)",
                    Instructions = "Put the flour in a food processor with ¾ of your egg mixture and a pinch of salt. Blitz to large crumbs – they should come together to form a dough when squeezed (if it feels a little dry gradually add a bit more egg). Tip the dough onto a lightly floured surface, knead for 1 min or until nice and smooth – don’t worry if it’s quite firm as it will soften when it rests. Cover with cling film and leave to rest for 30 mins. Cut away ¼ of the dough (keep the rest covered with cling film) and feed it through the widest setting on your pasta machine. (If you don’t have a machine, use a heavy rolling pin to roll the dough as thinly as possible.) Then fold into three, give the dough a quarter turn and feed through the pasta machine again. Repeat this process once more then continue to pass the dough through the machine, progressively narrowing the rollers, one notch at a time, until you have a smooth sheet of pasta. On the narrowest setting, feed the sheet through twice. Cut as required to use for filled pastas like tortellini, or cut into lengths to make spaghetti, linguine, tagliatelle, or pappardelle. Then, dust in semolina flour and set aside, or hang until dry (an hour will be enough time.) Store in a sealed container in the fridge and use within a couple of days, or freeze for 1 month.",
                    Rating = 3,
                    Category = "Classics From Scratch",
                    DateSubmitted = DateTime.Parse("3/25/2016"),
                    Image = "/css/images/pasta.jpg"
                },
                new Recipe
                {
                    RecipeId = 4,
                    RecipeName = "Earl Grey Martini",
                    Ingredients = "1 tbsp good loose-leaf Earl Grey tea, 700ml bottle of decent gin, ice",
                    Instructions = "Put the Earl Grey tea in a large jug. Pour the gin over and stir with a long-handled spoon for about 45 secs. Strain the gin through a tea strainer over a funnel back into the bottle. You’ll see small particles of leaf still suspended in the gin. Rinse out the jug and, using a coffee filter or some muslin inside the funnel, strain the gin a second time to remove all the particles. In this way, the gin will be stable and the flavour won’t change – it’ll be good for months and months until the final sip. To serve, shake or stir over ice – I like how the flavours change as the drink dilutes.",
                    Rating = 5,
                    Category = "Drinks",
                    DateSubmitted = DateTime.Parse("12/1/2020"),
                    Image = "/css/images/earlgreymartini.jpg"
                }
            };
                recipes.ForEach(r => context.Update(r));
                context.SaveChanges(); // stores all the reviews in the DB
            }
        }
    
}

