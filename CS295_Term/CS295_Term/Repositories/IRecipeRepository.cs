using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS295_Term.Models;

namespace CS295_Term.Repositories
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes { get; }

        void AddRecipe(Recipe recipe);

        void UpdateRecipe(Recipe recipe);

        void DeleteRecipe(Recipe recipe);
    }
}
