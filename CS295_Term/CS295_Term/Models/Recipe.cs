using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CS295_Term.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }


        //use this when an ingredient exists
        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        //use this when an ingredient doesn't yet exist
        public void AddIngredient(string name, string amount)
        {
            Ingredient ingredient = new Ingredient
            {
                IngredientName = name,
                Amount = amount,
            };
            Ingredients.Add(ingredient);
        }
    }
}
