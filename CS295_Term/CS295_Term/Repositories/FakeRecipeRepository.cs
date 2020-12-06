using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS295_Term.Models;

namespace CS295_Term.Repositories
{
    public class FakeRecipeRepository : IRecipeRepository
    {
        List<Recipe> recipes = new List<Recipe>();

        public IQueryable<Recipe> Recipes
        {
            get { return recipes.AsQueryable<Recipe>(); }
        }

        public void AddRecipe(Recipe recipe)
        {
            recipe.RecipeId = recipes.Count;
            recipes.Add(recipe);
        }

        public void DeleteRecipe(Recipe recipe)
        {
        }

        public void UpdateRecipe(Recipe recipe)
        {
        }
    }
}
