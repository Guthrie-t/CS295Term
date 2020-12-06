using CS295_Term.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CS295_Term.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private RecipeContext context;

        public RecipeRepository(RecipeContext r)
        {
            context = r;
        }
        public IQueryable<Recipe> Recipes
        {
            get
            {
                return context.Recipe;
            }
        }
        public void AddRecipe(Recipe recipe)
        {
            context.Recipe.Add(recipe);
            context.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            context.Recipe.Update(recipe);
            context.SaveChanges();
        }
        public void DeleteRecipe(Recipe recipe)
        {
            context.Recipe.Remove(recipe);
            context.SaveChanges();
        }
    }
}
