using System;
using Xunit;
using CS295_Term.Controllers;
using CS295_Term.Models;
using CS295_Term.Repositories;
using System.Linq;

namespace RecipeTests
{
    public class RecipeTests
    {
        [Fact]
        public void AddRecipeTest()
        {
            
            var fakeRepo = new FakeRecipeRepository();
            var controller = new RecipeController(fakeRepo, null, null);
            var recipe = new Recipe()
            {
                RecipeName = "Test",
                Ingredients = "Test",
                Instructions = "Test"
            };

            controller.EditRecipe(recipe);

            var retrieve = fakeRepo.Recipes.ToList()[0];
            Assert.Equal("Test", retrieve.RecipeName);
        }
        [Fact]
        public void EditRecipeTest()
        {
            var fakeRepo = new FakeRecipeRepository();
            var controller = new RecipeController(fakeRepo, null, null);
            var recipe = new Recipe()
            {
                RecipeName = "Test",
                Ingredients = "Test",
                Instructions = "Test",
            };

            controller.EditRecipe(recipe);

            recipe.RecipeName = "Not A Test";

            controller.EditRecipe(recipe);

            var retrieve = fakeRepo.Recipes.ToList()[0];
            Assert.Equal("Not A Test", retrieve.RecipeName);
        }
    }
}
